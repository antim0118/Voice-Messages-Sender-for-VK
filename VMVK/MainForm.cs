using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Windows.Forms;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VMVK.Custom_Controls;

namespace VMVK
{
    public partial class MainForm : Form
    {
        #region vars
        public Pen borderPen;
        public Brush borderBrush, textBrush;
        public Font headerFont;
        string version;
        #endregion

        #region form init
        public MainForm()
        {
            var v = Assembly.GetExecutingAssembly().GetName().Version;
            version = $"v{v.Major}.{v.Minor}";

            SetStyle(ControlStyles.UserPaint, true);

            InitializeComponent();

            borderPen = new Pen(Color.FromArgb(74, 118, 168), 2f);
            borderBrush = new SolidBrush(Color.FromArgb(38, 38, 38));
            textBrush = new SolidBrush(Color.FromArgb(189, 189, 189));
            headerFont = new Font(Font, FontStyle.Bold);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Settings.firstStart)
                windowControlButton_settings_Click(null, EventArgs.Empty);
            CheckToken();
            CheckForSendPossibility();
        }
        #endregion


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            base.OnPaint(e);

            e.Graphics.FillRectangle(borderBrush, 0, 0, Width, 30);
            e.Graphics.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);

            e.Graphics.DrawString("VMVK " + version, headerFont, textBrush, 14, 9);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) => Settings.Save();

        #region control buttons
        private void windowControlButton_exit_Click(object sender, EventArgs e) => Close();
        private void windowControlButton_hide_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void windowControlButton_settings_Click(object sender, EventArgs e)
        {
            WaitingControl wait = new WaitingControl();
            wait.Dock = DockStyle.Fill;
            this.Controls.Add(wait);
            wait.BringToFront();
            this.Invalidate();

            var settings = new SettingsForm();
            settings.StartPosition = FormStartPosition.Manual;
            settings.Location = new Point(Left + Width / 2 - settings.Width / 2, Top + Height / 2 - settings.Height / 2);
            settings.ShowDialog();

            this.Controls.Remove(wait);
            wait.Dispose();

            CheckToken();
        }
        #endregion

        #region move window
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Cursor.Position.Y - Top <= 32)
            {
                DLLImport.ReleaseCapture();
                DLLImport.SendMessage(Handle, DLLImport.WM_NCLBUTTONDOWN, DLLImport.HT_CAPTION, 0);
            }
        }
        #endregion

        /// <summary>Проверка на токен, которая вызывается при запуске, либо после закрытия настроек</summary>
        void CheckToken()
        {
            if (!Settings.AccessTokenIsValid && !Settings.firstStart)
            {
                MessageBox.Show("Access Token неправильный, либо время действия токена истекло.");
                return;
            }

            listBox_dialogs.Items.Clear();
            Application.DoEvents();
            SystemSounds.Exclamation.Play();
            var conversations = Program.api.Messages.GetConversations(new VkNet.Model.RequestParams.GetConversationsParams
            {
                Extended = true,
                Fields = new string[] { "id", "first_name", "last_name" }
            });
            foreach (var conv in conversations.Items)
            {
                string convname = string.Empty;
                if (!conv.Conversation.CanWrite.Allowed) continue;
                if (conv.Conversation.Peer.Type == VkNet.Enums.SafetyEnums.ConversationPeerType.Chat)
                    convname = "[Б]" + conv.Conversation.ChatSettings.Title;
                else
                {
                    long id = conv.Conversation.Peer.Id;
                    if (id > 0) // is user
                    {
                        var profile = conversations.Profiles.FirstOrDefault(z => z.Id == conv.Conversation.Peer.Id);
                        if (profile != null)
                            convname = profile.FirstName + " " + profile.LastName;
                    }
                    else //is group
                    {
                        var group = conversations.Groups.FirstOrDefault(z => z.Id == conv.Conversation.Peer.Id * -1);
                        if (group != null)
                            convname = "[Г]" + group.Name;
                    }
                }
                listBox_dialogs.Items.Add(new ConversationStruct(convname, conv.Conversation.Peer.Id));
            }
        }

        private void listBox_dialogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckForSendPossibility();
        }

        private void button_chooseFile_Click(object sender, EventArgs e)
        {
            if (!CheckForSendPossibility()) return;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Аудиофайл|*.mp3;*.wav;*.ogg;*.flac";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Settings.selectedFile = ofd.FileName;
                    customLabel_file.Text = "Файл: ../" + Path.GetFileName(ofd.FileName);
                }
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (!Settings.ffmpegPathIsValid)
            {
                MessageBox.Show("Файл ffmpeg.exe не был найден, либо был перемещён");
                return;
            }
            if (Settings.selectedFile.Length == 0 || !File.Exists(Settings.selectedFile)) return;
            if (listBox_dialogs.SelectedItem == null) return;
            ConversationStruct conv = (ConversationStruct)listBox_dialogs.SelectedItem;

            Random rand = new Random();
            Directory.CreateDirectory(Settings.tempPath);
            string tempFilePath = Path.Combine(Settings.tempPath, rand.Next(10, 9999) + ".ogg");
            ffmpeg.ProcessAudio(Settings.selectedFile, tempFilePath);

            //получение адреса загрузки
            var _sv = Program.api.Docs.GetMessagesUploadServer(conv.Id, DocMessageType.AudioMessage);
            string sv = _sv.UploadUrl;

            //загрузка
            string _uploadResponse = Program.UploadMultipart(sv, tempFilePath);
            UploadResponse uploadResponse = JsonConvert.DeserializeObject<UploadResponse>(_uploadResponse);

            //сохранение
            var saveInfo = Program.api.Docs.Save(uploadResponse.file, Path.GetFileName(tempFilePath), null);
            Attachment attachment = saveInfo.FirstOrDefault();

            //отправка
            if (attachment != null)
            {
                Program.api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                {
                    PeerId = conv.Id,
                    Attachments = new MediaAttachment[] { attachment.Instance },
                    RandomId = rand.Next(0, 999)
                });
            }
            else
                MessageBox.Show("Почему-то файл не был загружен, либо что-то пошло не так в ходе отправки/подготовки.");

            File.Delete(tempFilePath);
        }

        /// <summary>Проверка на возможность отправки</summary>
        bool CheckForSendPossibility()
        {
            bool b = Settings.AccessTokenIsValid && listBox_dialogs.SelectedItem != null;
            panel_send.Enabled = b;

            return b;
        }
    }
}
