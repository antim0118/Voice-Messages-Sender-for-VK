using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FVM_VK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region WndProc (move window)
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                m.Result = (IntPtr)2;  // move
                return;
            }
            base.WndProc(ref m);
        }
        #endregion
        #region form paint
        public bool FormIsActive
        {
            get
            {
                return ActiveForm == this;
            }
        }

        float drawpbar = 0f;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (FormIsActive)
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(39, 111, 169)), 0f, 0f, Width - 1, Height - 1);
            else
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(158, 158, 158)), 0f, 0f, Width - 1, Height - 1);

            if (tokennotvalid)
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(213, 0, 0)), textBox_token.Location.X - 1, textBox_token.Location.Y - 1, textBox_token.Width + 1, textBox_token.Height + 1);

            if (progress > drawpbar)
                drawpbar += (progress - drawpbar) / 30f;
            else if (progress < drawpbar)
                drawpbar += (progress - drawpbar) / 5f;
            if (drawpbar >= 99.5)
                drawpbar = 100;
            if (drawpbar <= 0.5)
                drawpbar = 0;
            //progress bar
            e.Graphics.DrawLine(new Pen(Color.FromArgb(39, 111, 169), 3), 1, Height - 3, Width / 100f * drawpbar - 1, Height - 3);
        }
        #endregion
        #region Timers
        private bool tokennotvalid = false;
        private void timer_paint_Tick(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate ()
            {
                Refresh();
            });
        }
        #endregion
        #region Form1_Load
        private void Form1_Load(object sender, EventArgs e)
        {
			//уже поздно убирать этот метод, т.к. корректирую исходник перед загрузкой
        }
        #endregion
        #region Exit
        private void Exit()
        {
            Environment.Exit(Environment.ExitCode);
        }
        #endregion
        #region Button <ABOUT>
        private void button_about_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.Show();
        }
        #endregion
        #region Control buttons (exit and minimize)
        private void button_exit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void button_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion
        #region Form1_SizeChanged
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
        }
        #endregion
        #region button_GetAccessToken_Click
        private void button_getaccesstoken_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сейчас будет открыт сайт в браузере.\n\nРекомендуем выбрать \"VK API\"\n(возможно и остальные подойдут, но тестировалось только на нем)");
            Process.Start("https://vkhost.github.io/");
        }
        #endregion
        #region Token manipulations
        private void textBox_token_TextChanged(object sender, EventArgs e)
        {
            TokenShtotoDelaet();
            RefreshIM();
        }
        #region TokenShtotoDelaet
        private void TokenShtotoDelaet() //ТокенШтотоДелает. Хорошее название не так ли?
        {
            bool val = TokenIsValid;
            tokennotvalid = !val;
            Invoke((MethodInvoker)delegate ()
            {
                panel1.Enabled = val;
            });
        }
        #endregion

        public string Token
        {
            get
            {
                return textBox_token.Text;
            }
        }
        public bool TokenIsValid
        {
            get
            {
                if(Token.Length < 70)
                {
                    return false;
                }
                else
                {
                    var resp = mm.VKRequest(Token, "users.get");
                    return resp.Contains("first_name");
                }
            }
        }
        #endregion
        #region RefreshIM and Dialog class
        private void RefreshIM()
        {
            if (!TokenIsValid)
                return;

            var resp_dialogs = mm.VKRequest(Token, "messages.getDialogs", "preview_length=1");
            resp_dialogs = resp_dialogs.Replace("{", "{\n").Replace(",", ",\n");
            var dialogs = resp_dialogs.Split(new string[] { "\"message\":{" }, StringSplitOptions.None);

            List<Dialog> ds = new List<Dialog>();
            foreach(var di in dialogs)
            {
                if (di.Contains("chat_id"))
                {
                    int id = 0;
                    string title = null;
                    foreach(var l in di.Split('\n'))
                    {
                        if (l.Contains("\"title\""))
                        {
                            title = l.Split(new string[] { "\"title\":\"" }, StringSplitOptions.None)[1].Replace("\",", "");
                        }
                        if (l.Contains("chat_id"))
                        {
                            string strid = l.Split(new string[] { "\"chat_id\":" }, StringSplitOptions.None)[1].Replace(",", "");
                            id = Convert.ToInt32(strid);
                        }
                    }

                    if (id != 0 && title != null)
                        ds.Add(new Dialog(id, title, false));
                }else if (di.Contains("user_id"))
                {
                    int id = 0;
                    foreach (var l in di.Split('\n'))
                    {
                        if (l.Contains("user_id"))
                        {
                            string strid = l.Split(new string[] { "\"user_id\":" }, StringSplitOptions.None)[1].Replace(",", "");
                            id = Convert.ToInt32(strid);
                        }
                    }

                    if (id != 0 && id > 0)
                        ds.Add(new Dialog(id, ""));
                }
            }

            foreach (var dd in ds)
            {
                listBox_IMs.Items.Add(dd.Title + "                              :" + dd.Id);
            }
        }
        public class Dialog
        {
            public int Id;
            public string Title;
            public Dialog(int id, string title, bool isUser = true)
            {
                if (isUser)
                {
                    Id = id;
                    var nr = mm.VKRequest(Program.form1.Token, "users.get", $"user_ids={id}");
                    string name = nr.Split(new string[] { "\"first_name\":\"" }, StringSplitOptions.None)[1].Split('"')[0].Replace("\",", "");
                    string lname = nr.Split(new string[] { "\"last_name\":\"" }, StringSplitOptions.None)[1].Split('"')[0].Replace("\",", "");
                    Title = $"{name} {lname}";
                }
                else
                {
                    Id = 2000000000 + id;
                    Title = title;
                }
                Thread.Sleep(10);
            }
        }
        #endregion

        private void listBox_IMs_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_file.Enabled = true;
            panel_synth.Enabled = true;
        }

        private void button_ChooseFileAndSend_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog(); //просим файл
            OPF.Filter = "MP3|*.mp3|Waveform Audio File|*.wav|OGG|*.ogg";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                //создаем новый поток, чтобы не было подвисаний
                Thread th = new Thread(() => SendAudio(OPF.FileName));
                th.Start();
            }
        }

        #region SpeakToWav
        public string SpeakToWav(string mess)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            string output = Path.GetTempPath() + "/speech" + $"{DateTime.Now.Second + DateTime.Now.Millisecond}_{rnd.Next(51, 19294)}.wav";
            while (File.Exists(output))
            {
                output = Path.GetTempPath() + "/speech" + $"{DateTime.Now.Second + DateTime.Now.Millisecond}_{rnd.Next(1, 51)}.wav";
            }
            Thread t = new Thread(() => SpeechTh(mess, output));
            t.Start();
            while (t.ThreadState != System.Threading.ThreadState.Stopped)
            {
                Thread.Sleep(10);
            }

            return output;
        }

        public string file = "";
        public void SpeechTh(string mess, string output)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            file = output;
            synth.SetOutputToWaveFile(output);
            synth.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(synth_SpeakCompleted);
            PromptBuilder builder = new PromptBuilder();
            builder.AppendText(mess);
            synth.SpeakAsync(builder);
        }

        void synth_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            System.Media.SoundPlayer m_SoundPlayer = new System.Media.SoundPlayer(file);
            m_SoundPlayer.Play();
            m_SoundPlayer.Stop();
        }
        #endregion
        #region SendAudio
        float progress = 0f;
        bool SendInProgress = false;
        public void SendAudio(string path)
        {
            Invoke((MethodInvoker)delegate ()
            {
                button_ChooseFileAndSend.Enabled = false;
                button_speechsend.Enabled = false;
            });
            if (SendInProgress)
            {
                SystemSounds.Exclamation.Play();
                return;
            }
            SendInProgress = true;
            progress = 0f; //немного щиткодинга, чтобы симулировать прогресс загрузки (хотя она и так загружается)
            int id = Convert.ToInt32(mm.VKRequest(Token, "users.get").Split(new string[] { "\"id\":" }, StringSplitOptions.None)[1].Split(',')[0]);
            progress = 12f;
            string _url_multipart = mm.VKRequest(Token, "docs.getMessagesUploadServer", "type=audio_message&peer_id=" + id); //запрос ссылки на загрузку
            progress = 24f;
            string url_multipart = _url_multipart.Split(new string[] { "upload_url" }, StringSplitOptions.None)[1].Split('"')[2].Replace(@"\", ""); //чистим запрос, получаем "чистую" ссылку
            progress = 36f;
            string filevk = mm.UploadMultipart(url_multipart, path, Path.GetExtension(path)).Split('"')[3].Split('"')[0]; //загружаем файл и получаем ссылку на файл
            progress = 48f;
            if (!filevk.ToLower().Contains("empty_file"))
            {
                string res = mm.VKRequest(Token, "docs.save", $"file={filevk}"); //сохраняем файл как документ (его не видно в общем списке)
                progress = 60f;
                string owner_id = res.Split(new string[] { "owner_id" }, StringSplitOptions.None)[1].Split(',')[0].Split(':')[1]; //получаем твой id
                progress = 72f;
                string media_id = res.Split(new string[] { "id" }, StringSplitOptions.None)[1].Split(',')[0].Split(':')[1]; //получаем номер документа-голосового сообщения
                progress = 84f;
                Invoke((MethodInvoker)delegate ()
                {
                    int dialog = Convert.ToInt32(listBox_IMs.SelectedItem.ToString().Split(':')[1]);
                    progress = 96f;
                //отправляем сообщение
                string sendRes = mm.VKRequest(Token, "messages.send", $"peer_id={dialog}&attachment=doc{owner_id}_{media_id}");
                });
            }
            Invoke((MethodInvoker)delegate ()
            {
                button_ChooseFileAndSend.Enabled = true;
                button_speechsend.Enabled = true;
            });
            progress = 100f;
            SystemSounds.Exclamation.Play();
            SendInProgress = false;
        }
        #endregion
        #region Button_speechsend
        private void button_speechsend_Click(object sender, EventArgs e)
        {
            string wav = SpeakToWav(textBox_speech.Text);
            Thread th = new Thread(() => SendAudio(wav));
            th.Start();
        }
        #endregion
    }
}
