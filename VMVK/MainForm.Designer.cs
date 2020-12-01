namespace VMVK
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox_dialogs = new System.Windows.Forms.ListBox();
            this.customLabel1 = new VMVK.CustomLabel();
            this.windowControlButton_settings = new VMVK.Custom_Controls.WindowControlButton();
            this.customProgressbar1 = new VMVK.Custom_Controls.CustomProgressbar();
            this.windowControlButton_exit = new VMVK.Custom_Controls.WindowControlButton();
            this.windowControlButton_hide = new VMVK.Custom_Controls.WindowControlButton();
            this.panel_send = new System.Windows.Forms.Panel();
            this.button_send = new System.Windows.Forms.Button();
            this.button_chooseFile = new System.Windows.Forms.Button();
            this.customLabel_file = new VMVK.CustomLabel();
            this.panel1.SuspendLayout();
            this.panel_send.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listBox_dialogs);
            this.panel1.Controls.Add(this.customLabel1);
            this.panel1.Location = new System.Drawing.Point(12, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 239);
            this.panel1.TabIndex = 6;
            // 
            // listBox_dialogs
            // 
            this.listBox_dialogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.listBox_dialogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_dialogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.listBox_dialogs.FormattingEnabled = true;
            this.listBox_dialogs.Location = new System.Drawing.Point(-1, 28);
            this.listBox_dialogs.Name = "listBox_dialogs";
            this.listBox_dialogs.Size = new System.Drawing.Size(160, 210);
            this.listBox_dialogs.TabIndex = 1;
            this.listBox_dialogs.SelectedIndexChanged += new System.EventHandler(this.listBox_dialogs_SelectedIndexChanged);
            // 
            // customLabel1
            // 
            this.customLabel1.AutoSize = true;
            this.customLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.customLabel1.Location = new System.Drawing.Point(6, 7);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(60, 13);
            this.customLabel1.TabIndex = 0;
            this.customLabel1.Text = "Диалоги:";
            // 
            // windowControlButton_settings
            // 
            this.windowControlButton_settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.windowControlButton_settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.windowControlButton_settings.iconPattern = VMVK.Custom_Controls.WindowControlButton.IconPatterns.Settings;
            this.windowControlButton_settings.Location = new System.Drawing.Point(408, 2);
            this.windowControlButton_settings.Name = "windowControlButton_settings";
            this.windowControlButton_settings.Size = new System.Drawing.Size(28, 28);
            this.windowControlButton_settings.TabIndex = 5;
            this.windowControlButton_settings.UseVisualStyleBackColor = false;
            this.windowControlButton_settings.Click += new System.EventHandler(this.windowControlButton_settings_Click);
            // 
            // customProgressbar1
            // 
            this.customProgressbar1.Location = new System.Drawing.Point(2, 288);
            this.customProgressbar1.Name = "customProgressbar1";
            this.customProgressbar1.Size = new System.Drawing.Size(496, 10);
            this.customProgressbar1.TabIndex = 4;
            this.customProgressbar1.Val = 0F;
            // 
            // windowControlButton_exit
            // 
            this.windowControlButton_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.windowControlButton_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.windowControlButton_exit.iconPattern = VMVK.Custom_Controls.WindowControlButton.IconPatterns.Exit;
            this.windowControlButton_exit.Location = new System.Drawing.Point(470, 2);
            this.windowControlButton_exit.Name = "windowControlButton_exit";
            this.windowControlButton_exit.Size = new System.Drawing.Size(28, 28);
            this.windowControlButton_exit.TabIndex = 2;
            this.windowControlButton_exit.UseVisualStyleBackColor = false;
            this.windowControlButton_exit.Click += new System.EventHandler(this.windowControlButton_exit_Click);
            // 
            // windowControlButton_hide
            // 
            this.windowControlButton_hide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.windowControlButton_hide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.windowControlButton_hide.iconPattern = VMVK.Custom_Controls.WindowControlButton.IconPatterns.Hide;
            this.windowControlButton_hide.Location = new System.Drawing.Point(442, 2);
            this.windowControlButton_hide.Name = "windowControlButton_hide";
            this.windowControlButton_hide.Size = new System.Drawing.Size(28, 28);
            this.windowControlButton_hide.TabIndex = 1;
            this.windowControlButton_hide.UseVisualStyleBackColor = false;
            // 
            // panel_send
            // 
            this.panel_send.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_send.Controls.Add(this.button_send);
            this.panel_send.Controls.Add(this.button_chooseFile);
            this.panel_send.Controls.Add(this.customLabel_file);
            this.panel_send.Location = new System.Drawing.Point(178, 43);
            this.panel_send.Name = "panel_send";
            this.panel_send.Size = new System.Drawing.Size(310, 114);
            this.panel_send.TabIndex = 7;
            // 
            // button_send
            // 
            this.button_send.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_send.Location = new System.Drawing.Point(112, 67);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(90, 23);
            this.button_send.TabIndex = 9;
            this.button_send.Text = "Отправить";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_chooseFile
            // 
            this.button_chooseFile.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button_chooseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_chooseFile.Location = new System.Drawing.Point(16, 67);
            this.button_chooseFile.Name = "button_chooseFile";
            this.button_chooseFile.Size = new System.Drawing.Size(90, 23);
            this.button_chooseFile.TabIndex = 8;
            this.button_chooseFile.Text = "Выбрать";
            this.button_chooseFile.UseVisualStyleBackColor = true;
            this.button_chooseFile.Click += new System.EventHandler(this.button_chooseFile_Click);
            // 
            // customLabel_file
            // 
            this.customLabel_file.AutoSize = true;
            this.customLabel_file.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.customLabel_file.Location = new System.Drawing.Point(13, 28);
            this.customLabel_file.Name = "customLabel_file";
            this.customLabel_file.Size = new System.Drawing.Size(42, 13);
            this.customLabel_file.TabIndex = 0;
            this.customLabel_file.Text = "Файл:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.panel_send);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.windowControlButton_settings);
            this.Controls.Add(this.customProgressbar1);
            this.Controls.Add(this.windowControlButton_exit);
            this.Controls.Add(this.windowControlButton_hide);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Voice Messages Sender for VK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_send.ResumeLayout(false);
            this.panel_send.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Custom_Controls.WindowControlButton windowControlButton_hide;
        private Custom_Controls.WindowControlButton windowControlButton_exit;
        private Custom_Controls.CustomProgressbar customProgressbar1;
        private Custom_Controls.WindowControlButton windowControlButton_settings;
        private System.Windows.Forms.Panel panel1;
        private CustomLabel customLabel1;
        private System.Windows.Forms.ListBox listBox_dialogs;
        private System.Windows.Forms.Panel panel_send;
        private CustomLabel customLabel_file;
        private System.Windows.Forms.Button button_chooseFile;
        private System.Windows.Forms.Button button_send;
    }
}

