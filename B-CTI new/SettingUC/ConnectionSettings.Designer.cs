namespace BCTI.SettingUC
{
    partial class ConnectionSettingsForm
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.numberLabel = new System.Windows.Forms.Label();
            this.numberTextbox = new System.Windows.Forms.TextBox();
            this.loginTextbox = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passTextbox = new System.Windows.Forms.TextBox();
            this.portTextbox = new System.Windows.Forms.TextBox();
            this.ipserverTextbox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SaveAndApply = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AutoConnect = new BCTI.CustomControls.BCheckbox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MD5Auth = new BCTI.CustomControls.BCheckbox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numberLabel
            // 
            this.numberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numberLabel.AutoSize = true;
            this.numberLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.numberLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberLabel.Location = new System.Drawing.Point(7, 84);
            this.numberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(55, 18);
            this.numberLabel.TabIndex = 33;
            this.numberLabel.Text = "Номер";
            // 
            // numberTextbox
            // 
            this.numberTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberTextbox.Location = new System.Drawing.Point(156, 82);
            this.numberTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numberTextbox.Name = "numberTextbox";
            this.numberTextbox.Size = new System.Drawing.Size(281, 24);
            this.numberTextbox.TabIndex = 30;
            // 
            // loginTextbox
            // 
            this.loginTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginTextbox.Location = new System.Drawing.Point(156, 22);
            this.loginTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loginTextbox.Name = "loginTextbox";
            this.loginTextbox.Size = new System.Drawing.Size(281, 24);
            this.loginTextbox.TabIndex = 23;
            // 
            // loginLabel
            // 
            this.loginLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.loginLabel.AutoSize = true;
            this.loginLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.loginLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginLabel.Location = new System.Drawing.Point(7, 24);
            this.loginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(141, 18);
            this.loginLabel.TabIndex = 27;
            this.loginLabel.Text = "Имя пользователя";
            // 
            // passLabel
            // 
            this.passLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.passLabel.AutoSize = true;
            this.passLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.passLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passLabel.Location = new System.Drawing.Point(7, 55);
            this.passLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(61, 18);
            this.passLabel.TabIndex = 31;
            this.passLabel.Text = "Пароль";
            // 
            // portLabel
            // 
            this.portLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.portLabel.AutoSize = true;
            this.portLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.portLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.portLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.portLabel.Location = new System.Drawing.Point(7, 53);
            this.portLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(43, 18);
            this.portLabel.TabIndex = 28;
            this.portLabel.Text = "Порт";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Адрес сервера";
            // 
            // passTextbox
            // 
            this.passTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passTextbox.Location = new System.Drawing.Point(156, 53);
            this.passTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passTextbox.Name = "passTextbox";
            this.passTextbox.PasswordChar = '*';
            this.passTextbox.Size = new System.Drawing.Size(281, 24);
            this.passTextbox.TabIndex = 24;
            // 
            // portTextbox
            // 
            this.portTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.portTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.portTextbox.Location = new System.Drawing.Point(156, 51);
            this.portTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.portTextbox.Name = "portTextbox";
            this.portTextbox.Size = new System.Drawing.Size(281, 24);
            this.portTextbox.TabIndex = 29;
            // 
            // ipserverTextbox
            // 
            this.ipserverTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipserverTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ipserverTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ipserverTextbox.Location = new System.Drawing.Point(156, 20);
            this.ipserverTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ipserverTextbox.Name = "ipserverTextbox";
            this.ipserverTextbox.Size = new System.Drawing.Size(281, 24);
            this.ipserverTextbox.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.portLabel);
            this.groupBox2.Controls.Add(this.numberLabel);
            this.groupBox2.Controls.Add(this.portTextbox);
            this.groupBox2.Controls.Add(this.ipserverTextbox);
            this.groupBox2.Controls.Add(this.numberTextbox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(0, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 115);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server";
            // 
            // SaveAndApply
            // 
            this.SaveAndApply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveAndApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.SaveAndApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveAndApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.SaveAndApply.ForeColor = System.Drawing.Color.White;
            this.SaveAndApply.Location = new System.Drawing.Point(7, 3);
            this.SaveAndApply.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.SaveAndApply.MaximumSize = new System.Drawing.Size(500, 30);
            this.SaveAndApply.Name = "SaveAndApply";
            this.SaveAndApply.Size = new System.Drawing.Size(430, 28);
            this.SaveAndApply.TabIndex = 35;
            this.SaveAndApply.Text = "Сохранить (Права администратора)";
            this.SaveAndApply.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SaveAndApply.Click += new System.EventHandler(this.SaveSettingsClicked);
            this.SaveAndApply.MouseEnter += new System.EventHandler(this.SaveAndApply_MouseEnter);
            this.SaveAndApply.MouseLeave += new System.EventHandler(this.SaveAndApply_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.groupBox1.Controls.Add(this.passLabel);
            this.groupBox1.Controls.Add(this.loginLabel);
            this.groupBox1.Controls.Add(this.passTextbox);
            this.groupBox1.Controls.Add(this.loginTextbox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 83);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credentials";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel2.Controls.Add(this.AutoConnect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 229);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel2.Size = new System.Drawing.Size(444, 27);
            this.panel2.TabIndex = 36;
            // 
            // AutoConnect
            // 
            this.AutoConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.AutoConnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.AutoConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutoConnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AutoConnect.Location = new System.Drawing.Point(0, 2);
            this.AutoConnect.Margin = new System.Windows.Forms.Padding(0);
            this.AutoConnect.MaximumSize = new System.Drawing.Size(1000, 25);
            this.AutoConnect.MinimumSize = new System.Drawing.Size(0, 22);
            this.AutoConnect.Name = "AutoConnect";
            this.AutoConnect.Size = new System.Drawing.Size(444, 25);
            this.AutoConnect.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel3.Controls.Add(this.MD5Auth);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 85);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel3.Size = new System.Drawing.Size(444, 27);
            this.panel3.TabIndex = 37;
            // 
            // MD5Auth
            // 
            this.MD5Auth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.MD5Auth.Dock = System.Windows.Forms.DockStyle.Top;
            this.MD5Auth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MD5Auth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MD5Auth.Location = new System.Drawing.Point(0, 2);
            this.MD5Auth.Margin = new System.Windows.Forms.Padding(0);
            this.MD5Auth.MaximumSize = new System.Drawing.Size(1000, 25);
            this.MD5Auth.MinimumSize = new System.Drawing.Size(0, 22);
            this.MD5Auth.Name = "MD5Auth";
            this.MD5Auth.Size = new System.Drawing.Size(444, 25);
            this.MD5Auth.TabIndex = 32;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel4.Size = new System.Drawing.Size(444, 85);
            this.panel4.TabIndex = 37;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel5.Controls.Add(this.groupBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 112);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel5.Size = new System.Drawing.Size(444, 117);
            this.panel5.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.panel1.Controls.Add(this.SaveAndApply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 256);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 3, 4, 3);
            this.panel1.Size = new System.Drawing.Size(444, 34);
            this.panel1.TabIndex = 38;
            // 
            // ConnectionSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(400, 326);
            this.Name = "ConnectionSettingsForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.Size = new System.Drawing.Size(445, 385);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.TextBox numberTextbox;
        private System.Windows.Forms.TextBox loginTextbox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passTextbox;
        private System.Windows.Forms.TextBox portTextbox;
        private System.Windows.Forms.TextBox ipserverTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label SaveAndApply;
        private CustomControls.BCheckbox MD5Auth;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.BCheckbox AutoConnect;
    }
}
