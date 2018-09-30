namespace FVM_VK
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_minimize = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_about = new System.Windows.Forms.Button();
            this.label_header = new System.Windows.Forms.Label();
            this.textBox_token = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_getaccesstoken = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_file = new System.Windows.Forms.Panel();
            this.button_ChooseFileAndSend = new System.Windows.Forms.Button();
            this.panel_synth = new System.Windows.Forms.Panel();
            this.button_speechsend = new System.Windows.Forms.Button();
            this.textBox_speech = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_IMs = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel_file.SuspendLayout();
            this.panel_synth.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_minimize
            // 
            this.button_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_minimize.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_minimize.FlatAppearance.BorderSize = 0;
            this.button_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_minimize.Image = global::FVM_VK.Properties.Resources.minimize;
            this.button_minimize.Location = new System.Drawing.Point(478, 1);
            this.button_minimize.Name = "button_minimize";
            this.button_minimize.Size = new System.Drawing.Size(25, 25);
            this.button_minimize.TabIndex = 11;
            this.button_minimize.UseVisualStyleBackColor = true;
            this.button_minimize.Click += new System.EventHandler(this.button_minimize_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_exit.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_exit.FlatAppearance.BorderSize = 0;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Image = global::FVM_VK.Properties.Resources.cross;
            this.button_exit.Location = new System.Drawing.Point(506, 1);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(25, 25);
            this.button_exit.TabIndex = 10;
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_about
            // 
            this.button_about.FlatAppearance.BorderSize = 0;
            this.button_about.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_about.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_about.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.button_about.Location = new System.Drawing.Point(450, 1);
            this.button_about.Name = "button_about";
            this.button_about.Size = new System.Drawing.Size(25, 25);
            this.button_about.TabIndex = 9;
            this.button_about.Text = "i";
            this.button_about.UseVisualStyleBackColor = true;
            this.button_about.Click += new System.EventHandler(this.button_about_Click);
            // 
            // label_header
            // 
            this.label_header.AutoSize = true;
            this.label_header.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.label_header.Location = new System.Drawing.Point(5, 5);
            this.label_header.Name = "label_header";
            this.label_header.Size = new System.Drawing.Size(348, 16);
            this.label_header.TabIndex = 12;
            this.label_header.Text = "Фейковые голосовые сообщения для VK.com";
            // 
            // textBox_token
            // 
            this.textBox_token.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.textBox_token.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_token.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.textBox_token.Location = new System.Drawing.Point(121, 30);
            this.textBox_token.Name = "textBox_token";
            this.textBox_token.Size = new System.Drawing.Size(323, 20);
            this.textBox_token.TabIndex = 13;
            this.textBox_token.UseSystemPasswordChar = true;
            this.textBox_token.TextChanged += new System.EventHandler(this.textBox_token_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Access token:";
            // 
            // button_getaccesstoken
            // 
            this.button_getaccesstoken.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_getaccesstoken.Location = new System.Drawing.Point(450, 29);
            this.button_getaccesstoken.Name = "button_getaccesstoken";
            this.button_getaccesstoken.Size = new System.Drawing.Size(70, 22);
            this.button_getaccesstoken.TabIndex = 15;
            this.button_getaccesstoken.Text = "Получить";
            this.button_getaccesstoken.UseVisualStyleBackColor = true;
            this.button_getaccesstoken.Click += new System.EventHandler(this.button_getaccesstoken_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_file);
            this.panel1.Controls.Add(this.panel_synth);
            this.panel1.Controls.Add(this.listBox_IMs);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(15, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 158);
            this.panel1.TabIndex = 16;
            // 
            // panel_file
            // 
            this.panel_file.AllowDrop = true;
            this.panel_file.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_file.Controls.Add(this.button_ChooseFileAndSend);
            this.panel_file.Enabled = false;
            this.panel_file.Location = new System.Drawing.Point(141, 5);
            this.panel_file.Name = "panel_file";
            this.panel_file.Size = new System.Drawing.Size(361, 75);
            this.panel_file.TabIndex = 2;
            this.panel_file.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel_file_DragDrop);
            this.panel_file.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_file_DragEnter);
            // 
            // button_ChooseFileAndSend
            // 
            this.button_ChooseFileAndSend.AllowDrop = true;
            this.button_ChooseFileAndSend.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ChooseFileAndSend.Location = new System.Drawing.Point(90, 25);
            this.button_ChooseFileAndSend.Name = "button_ChooseFileAndSend";
            this.button_ChooseFileAndSend.Size = new System.Drawing.Size(180, 22);
            this.button_ChooseFileAndSend.TabIndex = 0;
            this.button_ChooseFileAndSend.Text = "Выбрать файл и отправить";
            this.button_ChooseFileAndSend.UseVisualStyleBackColor = true;
            this.button_ChooseFileAndSend.Click += new System.EventHandler(this.button_ChooseFileAndSend_Click);
            this.button_ChooseFileAndSend.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel_file_DragDrop);
            this.button_ChooseFileAndSend.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_file_DragEnter);
            // 
            // panel_synth
            // 
            this.panel_synth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_synth.Controls.Add(this.button_speechsend);
            this.panel_synth.Controls.Add(this.textBox_speech);
            this.panel_synth.Controls.Add(this.label2);
            this.panel_synth.Enabled = false;
            this.panel_synth.Location = new System.Drawing.Point(141, 79);
            this.panel_synth.Name = "panel_synth";
            this.panel_synth.Size = new System.Drawing.Size(361, 75);
            this.panel_synth.TabIndex = 1;
            // 
            // button_speechsend
            // 
            this.button_speechsend.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_speechsend.Location = new System.Drawing.Point(263, 26);
            this.button_speechsend.Name = "button_speechsend";
            this.button_speechsend.Size = new System.Drawing.Size(76, 22);
            this.button_speechsend.TabIndex = 2;
            this.button_speechsend.Text = "Отправить";
            this.button_speechsend.UseVisualStyleBackColor = true;
            this.button_speechsend.Click += new System.EventHandler(this.button_speechsend_Click);
            // 
            // textBox_speech
            // 
            this.textBox_speech.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.textBox_speech.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_speech.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.textBox_speech.Location = new System.Drawing.Point(69, 27);
            this.textBox_speech.Name = "textBox_speech";
            this.textBox_speech.Size = new System.Drawing.Size(188, 20);
            this.textBox_speech.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.label2.Location = new System.Drawing.Point(15, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 73);
            this.label2.TabIndex = 0;
            this.label2.Text = "Текст:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBox_IMs
            // 
            this.listBox_IMs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.listBox_IMs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_IMs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.listBox_IMs.FormattingEnabled = true;
            this.listBox_IMs.Location = new System.Drawing.Point(0, 0);
            this.listBox_IMs.Name = "listBox_IMs";
            this.listBox_IMs.Size = new System.Drawing.Size(135, 158);
            this.listBox_IMs.TabIndex = 0;
            this.listBox_IMs.SelectedIndexChanged += new System.EventHandler(this.listBox_IMs_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(532, 230);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_getaccesstoken);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_token);
            this.Controls.Add(this.label_header);
            this.Controls.Add(this.button_minimize);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_about);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.panel1.ResumeLayout(false);
            this.panel_file.ResumeLayout(false);
            this.panel_synth.ResumeLayout(false);
            this.panel_synth.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Icon = global::FVM_VK.Properties.Resources.VK_Logo;
        }

        #endregion

        private System.Windows.Forms.Button button_minimize;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_about;
        private System.Windows.Forms.Label label_header;
        private System.Windows.Forms.TextBox textBox_token;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_getaccesstoken;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox_IMs;
        private System.Windows.Forms.Panel panel_synth;
        private System.Windows.Forms.Panel panel_file;
        private System.Windows.Forms.Button button_ChooseFileAndSend;
        private System.Windows.Forms.Button button_speechsend;
        private System.Windows.Forms.TextBox textBox_speech;
        private System.Windows.Forms.Label label2;
    }
}

