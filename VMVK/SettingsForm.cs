using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace VMVK
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            SetStyle(ControlStyles.UserPaint, true);

            InitializeComponent();

            textBox_token.Text = Settings.AccessToken;
            textBox_ffmpeg.Text = Settings.ffmpegPath;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            base.OnPaint(e);

            e.Graphics.FillRectangle(Program.mainForm.borderBrush, 0, 0, Width, 30);
            e.Graphics.DrawRectangle(Program.mainForm.borderPen, 0, 0, Width - 1, Height - 1);

            e.Graphics.DrawString("Настройки", Program.mainForm.headerFont, Program.mainForm.textBrush, 14, 9);
        }

        #region move window
        private void SettingsForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Cursor.Position.Y - Top <= 32)
            {
                DLLImport.ReleaseCapture();
                DLLImport.SendMessage(Handle, DLLImport.WM_NCLBUTTONDOWN, DLLImport.HT_CAPTION, 0);
            }
        }
        #endregion

        private void windowControlButton_exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button_getToken_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сейчас будет открыт сайт с инструкцией для получения токена.\nМожно использовать любое приложение, но для работы нужен доступ к сообщениям (для отправки) и к документам (т.к. все голосовые сообщения загружаются как документ)");
            Process.Start("https://vkhost.github.io/");
        }

        private void textBox_token_TextChanged(object sender, EventArgs e) => Settings.AccessToken = textBox_token.Text;

        private void button_setffmpeg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "ffmpeg.exe|ffmpeg.exe";
                if (ofd.ShowDialog() == DialogResult.OK)
                    Settings.ffmpegPath = ofd.FileName;
            }
            textBox_ffmpeg.Text = Settings.ffmpegPath;
        }
    }
}
