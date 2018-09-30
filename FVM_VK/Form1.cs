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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (FormIsActive)
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(39, 111, 169)), 0f, 0f, Width - 1, Height - 1);
            else
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(158, 158, 158)), 0f, 0f, Width - 1, Height - 1);

            if (tokennotvalid)
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(213, 0, 0)), textBox_token.Location.X - 1, textBox_token.Location.Y - 1, textBox_token.Width + 1, textBox_token.Height + 1);
        }
        #endregion
        #region Threads
        private int _t_ = 0;
        private bool tokennotvalid = false;
        private void Updater()
        {
            while (true)
            {
                Thread.Sleep(100);
                Invoke((MethodInvoker)delegate ()
                {
                    Refresh();
                });
            }
        }
        #endregion
        #region Form1_Load
        private Thread updater;
        private void Form1_Load(object sender, EventArgs e)
        {
            updater = new Thread(Updater);
            updater.Start();
        }
        #endregion
        #region Exit
        private void Exit()
        {
            if (updater.IsAlive)
                updater.Suspend();
            Environment.Exit(Environment.ExitCode);
        }
        #endregion

        private void button_about_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.Show();
        }

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
            MessageBox.Show("Сейчас будет открыт сайт в браузере.\n\nРекомендуем выбрать \"VK API\"\n(возможно и остальные подойдут, но тестировалось на нем)");
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
                Thread.Sleep(200);
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
                    //MessageBox.Show(nr);
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
                SendAudio(OPF.FileName);
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
            Thread.Sleep(1000);

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
        public void SendAudio(string path)
        {
            int id = Convert.ToInt32(mm.VKRequest(Token, "users.get").Split(new string[] { "\"id\":" }, StringSplitOptions.None)[1].Split(',')[0]);

            string _url_multipart = mm.VKRequest(Token, "docs.getMessagesUploadServer", "type=audio_message&peer_id=" + id); //запрос ссылки на загрузку
            string url_multipart = _url_multipart.Split(new string[] { "upload_url" }, StringSplitOptions.None)[1].Split('"')[2].Replace(@"\", ""); //чистим запрос, получаем "чистую" ссылку
            string filevk = mm.UploadMultipart(url_multipart, path, Path.GetExtension(path)).Split('"')[3].Split('"')[0]; //загружаем файл и получаем ссылку на файл

            string res = mm.VKRequest(Token, "docs.save", $"file={filevk}"); //сохраняем файл как документ (его не видно в общем списке)


            string owner_id = res.Split(new string[] { "owner_id" }, StringSplitOptions.None)[1].Split(',')[0].Split(':')[1]; //получаем твой id
            string media_id = res.Split(new string[] { "id" }, StringSplitOptions.None)[1].Split(',')[0].Split(':')[1]; //получаем номер документа с голосовухой
            int dialog = Convert.ToInt32(listBox_IMs.SelectedItem.ToString().Split(':')[1]);

            //отправляем сообщение
            string sendRes = mm.VKRequest(Token, "messages.send", $"peer_id={dialog}&attachment=doc{owner_id}_{media_id}");

            SystemSounds.Exclamation.Play();
        }
        #endregion

        private void button_speechsend_Click(object sender, EventArgs e)
        {
            string wav = SpeakToWav(textBox_speech.Text);
            SendAudio(wav);
        }

        #region drag and drop
        private void panel_file_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in FileList)
            {
                if (FileList.Length > 1)
                    Thread.Sleep(3000);
                SendAudio(file);
            }
           
        }

        private void panel_file_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        #endregion


    }
}
