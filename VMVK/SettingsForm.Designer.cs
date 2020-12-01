namespace VMVK
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.textBox_token = new System.Windows.Forms.TextBox();
            this.button_getToken = new System.Windows.Forms.Button();
            this.textBox_ffmpeg = new System.Windows.Forms.TextBox();
            this.button_setffmpeg = new System.Windows.Forms.Button();
            this.customLabel3 = new VMVK.CustomLabel();
            this.customLabel2 = new VMVK.CustomLabel();
            this.customLabel1 = new VMVK.CustomLabel();
            this.windowControlButton_exit = new VMVK.Custom_Controls.WindowControlButton();
            this.SuspendLayout();
            // 
            // textBox_token
            // 
            this.textBox_token.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.textBox_token.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_token.ForeColor = System.Drawing.Color.White;
            this.textBox_token.Location = new System.Drawing.Point(107, 70);
            this.textBox_token.Name = "textBox_token";
            this.textBox_token.Size = new System.Drawing.Size(281, 21);
            this.textBox_token.TabIndex = 6;
            this.textBox_token.UseSystemPasswordChar = true;
            this.textBox_token.TextChanged += new System.EventHandler(this.textBox_token_TextChanged);
            // 
            // button_getToken
            // 
            this.button_getToken.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button_getToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_getToken.Location = new System.Drawing.Point(107, 96);
            this.button_getToken.Name = "button_getToken";
            this.button_getToken.Size = new System.Drawing.Size(90, 23);
            this.button_getToken.TabIndex = 7;
            this.button_getToken.Text = "Получить";
            this.button_getToken.UseVisualStyleBackColor = true;
            this.button_getToken.Click += new System.EventHandler(this.button_getToken_Click);
            // 
            // textBox_ffmpeg
            // 
            this.textBox_ffmpeg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.textBox_ffmpeg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ffmpeg.ForeColor = System.Drawing.Color.White;
            this.textBox_ffmpeg.Location = new System.Drawing.Point(107, 139);
            this.textBox_ffmpeg.Name = "textBox_ffmpeg";
            this.textBox_ffmpeg.ReadOnly = true;
            this.textBox_ffmpeg.Size = new System.Drawing.Size(281, 21);
            this.textBox_ffmpeg.TabIndex = 9;
            // 
            // button_setffmpeg
            // 
            this.button_setffmpeg.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button_setffmpeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_setffmpeg.Location = new System.Drawing.Point(107, 164);
            this.button_setffmpeg.Name = "button_setffmpeg";
            this.button_setffmpeg.Size = new System.Drawing.Size(90, 23);
            this.button_setffmpeg.TabIndex = 10;
            this.button_setffmpeg.Text = "Выбрать";
            this.button_setffmpeg.UseVisualStyleBackColor = true;
            this.button_setffmpeg.Click += new System.EventHandler(this.button_setffmpeg_Click);
            // 
            // customLabel3
            // 
            this.customLabel3.AutoSize = true;
            this.customLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.customLabel3.Location = new System.Drawing.Point(12, 141);
            this.customLabel3.Name = "customLabel3";
            this.customLabel3.Size = new System.Drawing.Size(77, 13);
            this.customLabel3.TabIndex = 8;
            this.customLabel3.Text = "ffmpeg.exe:";
            // 
            // customLabel2
            // 
            this.customLabel2.AutoSize = true;
            this.customLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.customLabel2.Location = new System.Drawing.Point(12, 73);
            this.customLabel2.Name = "customLabel2";
            this.customLabel2.Size = new System.Drawing.Size(89, 13);
            this.customLabel2.TabIndex = 5;
            this.customLabel2.Text = "Access Token:";
            // 
            // customLabel1
            // 
            this.customLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.customLabel1.Location = new System.Drawing.Point(12, 34);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(376, 33);
            this.customLabel1.TabIndex = 4;
            this.customLabel1.Text = "Для работы приложения требуется Access Token ВК\r\n(ключ доступа)";
            // 
            // windowControlButton_exit
            // 
            this.windowControlButton_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.windowControlButton_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.windowControlButton_exit.iconPattern = VMVK.Custom_Controls.WindowControlButton.IconPatterns.Exit;
            this.windowControlButton_exit.Location = new System.Drawing.Point(370, 2);
            this.windowControlButton_exit.Name = "windowControlButton_exit";
            this.windowControlButton_exit.Size = new System.Drawing.Size(28, 28);
            this.windowControlButton_exit.TabIndex = 3;
            this.windowControlButton_exit.UseVisualStyleBackColor = false;
            this.windowControlButton_exit.Click += new System.EventHandler(this.windowControlButton_exit_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(400, 206);
            this.Controls.Add(this.button_setffmpeg);
            this.Controls.Add(this.textBox_ffmpeg);
            this.Controls.Add(this.customLabel3);
            this.Controls.Add(this.button_getToken);
            this.Controls.Add(this.textBox_token);
            this.Controls.Add(this.customLabel2);
            this.Controls.Add(this.customLabel1);
            this.Controls.Add(this.windowControlButton_exit);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SettingsForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom_Controls.WindowControlButton windowControlButton_exit;
        private CustomLabel customLabel1;
        private CustomLabel customLabel2;
        private System.Windows.Forms.TextBox textBox_token;
        private System.Windows.Forms.Button button_getToken;
        private CustomLabel customLabel3;
        private System.Windows.Forms.TextBox textBox_ffmpeg;
        private System.Windows.Forms.Button button_setffmpeg;
    }
}