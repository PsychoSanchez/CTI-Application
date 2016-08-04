namespace BCTI
{
    partial class Authorization
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.headPanel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.numberLabel = new System.Windows.Forms.Label();
            this.numberTextbox = new System.Windows.Forms.TextBox();
            this.loginTextbox = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passTextbox = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.ipserverTextbox = new System.Windows.Forms.TextBox();
            this.portTextbox = new System.Windows.Forms.TextBox();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.autoconnectPanel = new System.Windows.Forms.Panel();
            this.AutoConnect = new BCTI.CustomControls.BCheckbox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.autoconnectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.AutoSize = true;
            this.headPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headPanel.Location = new System.Drawing.Point(3, 4);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(120, 20);
            this.headPanel.TabIndex = 0;
            this.headPanel.Text = "Авторизация";
            this.headPanel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.headPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.panel1.Controls.Add(this.headPanel);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 27);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.exitButton.Location = new System.Drawing.Point(247, 5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(32, 18);
            this.exitButton.TabIndex = 1;
            this.exitButton.TabStop = false;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.exitButton_MouseEnter);
            this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
            // 
            // numberLabel
            // 
            this.numberLabel.AutoEllipsis = true;
            this.numberLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.numberLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numberLabel.Location = new System.Drawing.Point(1, 144);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numberLabel.Size = new System.Drawing.Size(106, 26);
            this.numberLabel.TabIndex = 9;
            this.numberLabel.Text = "Number";
            this.numberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numberTextbox
            // 
            this.numberTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberTextbox.Location = new System.Drawing.Point(113, 144);
            this.numberTextbox.MaximumSize = new System.Drawing.Size(154, 26);
            this.numberTextbox.MinimumSize = new System.Drawing.Size(154, 26);
            this.numberTextbox.Name = "numberTextbox";
            this.numberTextbox.Size = new System.Drawing.Size(154, 24);
            this.numberTextbox.TabIndex = 4;
            this.numberTextbox.Enter += new System.EventHandler(this.loginTextbox_Enter);
            this.numberTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginTextbox_KeyDown);
            this.numberTextbox.Leave += new System.EventHandler(this.loginTextbox_Leave);
            // 
            // loginTextbox
            // 
            this.loginTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginTextbox.Location = new System.Drawing.Point(113, 8);
            this.loginTextbox.MaximumSize = new System.Drawing.Size(154, 26);
            this.loginTextbox.MinimumSize = new System.Drawing.Size(154, 26);
            this.loginTextbox.Name = "loginTextbox";
            this.loginTextbox.Size = new System.Drawing.Size(154, 24);
            this.loginTextbox.TabIndex = 0;
            this.loginTextbox.Enter += new System.EventHandler(this.loginTextbox_Enter);
            this.loginTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginTextbox_KeyDown);
            this.loginTextbox.Leave += new System.EventHandler(this.loginTextbox_Leave);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoEllipsis = true;
            this.loginLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.loginLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loginLabel.Location = new System.Drawing.Point(1, 8);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.loginLabel.Size = new System.Drawing.Size(106, 26);
            this.loginLabel.TabIndex = 5;
            this.loginLabel.Text = "Username";
            this.loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // passLabel
            // 
            this.passLabel.AutoEllipsis = true;
            this.passLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.passLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.passLabel.Location = new System.Drawing.Point(1, 42);
            this.passLabel.Name = "passLabel";
            this.passLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.passLabel.Size = new System.Drawing.Size(106, 26);
            this.passLabel.TabIndex = 6;
            this.passLabel.Text = "Password";
            this.passLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // portLabel
            // 
            this.portLabel.AutoEllipsis = true;
            this.portLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.portLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.portLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.portLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.portLabel.Location = new System.Drawing.Point(1, 110);
            this.portLabel.Name = "portLabel";
            this.portLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.portLabel.Size = new System.Drawing.Size(106, 26);
            this.portLabel.TabIndex = 8;
            this.portLabel.Text = "Port";
            this.portLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(1, 76);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(106, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP Address";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // passTextbox
            // 
            this.passTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passTextbox.Location = new System.Drawing.Point(113, 42);
            this.passTextbox.MaximumSize = new System.Drawing.Size(154, 26);
            this.passTextbox.MinimumSize = new System.Drawing.Size(154, 26);
            this.passTextbox.Name = "passTextbox";
            this.passTextbox.PasswordChar = '*';
            this.passTextbox.Size = new System.Drawing.Size(154, 24);
            this.passTextbox.TabIndex = 1;
            this.passTextbox.Enter += new System.EventHandler(this.loginTextbox_Enter);
            this.passTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginTextbox_KeyDown);
            this.passTextbox.Leave += new System.EventHandler(this.loginTextbox_Leave);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.mainPanel.Controls.Add(this.ipserverTextbox);
            this.mainPanel.Controls.Add(this.portTextbox);
            this.mainPanel.Controls.Add(this.numberTextbox);
            this.mainPanel.Controls.Add(this.passTextbox);
            this.mainPanel.Controls.Add(this.loginTextbox);
            this.mainPanel.Controls.Add(this.loginLabel);
            this.mainPanel.Controls.Add(this.numberLabel);
            this.mainPanel.Controls.Add(this.passLabel);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.portLabel);
            this.mainPanel.Location = new System.Drawing.Point(5, 30);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(274, 178);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.TabStop = true;
            // 
            // ipserverTextbox
            // 
            this.ipserverTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ipserverTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ipserverTextbox.Location = new System.Drawing.Point(113, 76);
            this.ipserverTextbox.MaxLength = 15;
            this.ipserverTextbox.Name = "ipserverTextbox";
            this.ipserverTextbox.Size = new System.Drawing.Size(154, 24);
            this.ipserverTextbox.TabIndex = 2;
            this.ipserverTextbox.TextChanged += new System.EventHandler(this.ipserver_TextChanged);
            this.ipserverTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginTextbox_KeyDown);
            // 
            // portTextbox
            // 
            this.portTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.portTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.portTextbox.Location = new System.Drawing.Point(113, 110);
            this.portTextbox.MaxLength = 5;
            this.portTextbox.Name = "portTextbox";
            this.portTextbox.Size = new System.Drawing.Size(154, 24);
            this.portTextbox.TabIndex = 3;
            this.portTextbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.portTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginTextbox_KeyDown);
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 27);
            this.panel3.MaximumSize = new System.Drawing.Size(2, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 266);
            this.panel3.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(282, 27);
            this.panel4.MaximumSize = new System.Drawing.Size(2, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 266);
            this.panel4.TabIndex = 5;
            // 
            // autoconnectPanel
            // 
            this.autoconnectPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.autoconnectPanel.Controls.Add(this.AutoConnect);
            this.autoconnectPanel.Location = new System.Drawing.Point(5, 211);
            this.autoconnectPanel.Name = "autoconnectPanel";
            this.autoconnectPanel.Size = new System.Drawing.Size(274, 34);
            this.autoconnectPanel.TabIndex = 1;
            this.autoconnectPanel.TabStop = true;
            // 
            // AutoConnect
            // 
            this.AutoConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.AutoConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutoConnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AutoConnect.Location = new System.Drawing.Point(3, 3);
            this.AutoConnect.Margin = new System.Windows.Forms.Padding(0);
            this.AutoConnect.MaximumSize = new System.Drawing.Size(1000, 22);
            this.AutoConnect.MinimumSize = new System.Drawing.Size(0, 22);
            this.AutoConnect.Name = "AutoConnect";
            this.AutoConnect.Size = new System.Drawing.Size(264, 22);
            this.AutoConnect.TabIndex = 0;
            this.AutoConnect.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(2, 291);
            this.panel6.MaximumSize = new System.Drawing.Size(0, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(280, 2);
            this.panel6.TabIndex = 5;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoEllipsis = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.StatusLabel.Location = new System.Drawing.Point(5, 248);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(190, 40);
            this.StatusLabel.TabIndex = 9;
            this.StatusLabel.Text = "Авторизуйтесь для начала работы";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusLabel.UseCompatibleTextRendering = true;
            // 
            // acceptButton
            // 
            this.acceptButton.AutoEllipsis = true;
            this.acceptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.acceptButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.ForeColor = System.Drawing.Color.White;
            this.acceptButton.Location = new System.Drawing.Point(193, 256);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(79, 25);
            this.acceptButton.TabIndex = 8;
            this.acceptButton.Text = "Войти";
            this.acceptButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.acceptButton.UseCompatibleTextRendering = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            this.acceptButton.MouseEnter += new System.EventHandler(this.acceptButton_Enter);
            this.acceptButton.MouseLeave += new System.EventHandler(this.acceptButton_Leave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(284, 293);
            this.ControlBox = false;
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.autoconnectPanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authorization";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Authorization_FormClosing);
            this.Shown += new System.EventHandler(this.Authorization_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.autoconnectPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label headPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.TextBox numberTextbox;
        private System.Windows.Forms.TextBox loginTextbox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passTextbox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ImageList closeButtonImage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel autoconnectPanel;
        private CustomControls.BCheckbox AutoConnect;
        private System.Windows.Forms.TextBox portTextbox;
        private System.Windows.Forms.TextBox ipserverTextbox;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label acceptButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

