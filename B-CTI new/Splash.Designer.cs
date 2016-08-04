namespace BCTI
{
    partial class Splash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.UserInfoPanel = new System.Windows.Forms.Panel();
            this.organisationLabel = new System.Windows.Forms.Label();
            this.whenBox = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.headPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.numberLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.timeDurationLabel = new System.Windows.Forms.Label();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.TimePanel = new System.Windows.Forms.Panel();
            this.leftBorder = new System.Windows.Forms.Panel();
            this.rightBorder = new System.Windows.Forms.Panel();
            this.bottomBorder = new System.Windows.Forms.Panel();
            this.Images = new System.Windows.Forms.ImageList(this.components);
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.RedirectMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NotBlindRedirectMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.UnionSplashPanel = new System.Windows.Forms.Panel();
            this.ArrowPanel = new System.Windows.Forms.Panel();
            this.TransferToAvatarPanel = new System.Windows.Forms.Panel();
            this.ToTransferAvatarPanel = new System.Windows.Forms.Panel();
            this.Line = new System.Windows.Forms.Panel();
            this.CreateContactPanel = new System.Windows.Forms.Panel();
            this.CreateContactLabel = new System.Windows.Forms.Label();
            this.HistoryPanel = new System.Windows.Forms.Panel();
            this.HistoryLabel = new System.Windows.Forms.Label();
            this.avatarBox = new System.Windows.Forms.Panel();
            this.mailButton = new System.Windows.Forms.Button();
            this.ConferencePanel = new System.Windows.Forms.Panel();
            this.ConferenceLabel = new System.Windows.Forms.Label();
            this.CmdPanel = new System.Windows.Forms.Panel();
            this.CmdLabel = new System.Windows.Forms.Label();
            this.HoldPanel = new System.Windows.Forms.Panel();
            this.Answer = new System.Windows.Forms.Label();
            this.HoldLabel = new System.Windows.Forms.Label();
            this.BlindTransferPanel = new System.Windows.Forms.Panel();
            this.BlindTransferLabel = new System.Windows.Forms.Label();
            this.TransferPanel = new System.Windows.Forms.Panel();
            this.TransferLabel = new System.Windows.Forms.Label();
            this.HangupPanel = new System.Windows.Forms.Panel();
            this.HangupLabel = new System.Windows.Forms.Label();
            this.ToTransferNameLabel = new System.Windows.Forms.Label();
            this.TransferToNameLabel = new System.Windows.Forms.Label();
            this.UserInfoPanel.SuspendLayout();
            this.headPanel.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.TimePanel.SuspendLayout();
            this.RedirectMenuStrip.SuspendLayout();
            this.NotBlindRedirectMenuStrip.SuspendLayout();
            this.UnionSplashPanel.SuspendLayout();
            this.CreateContactPanel.SuspendLayout();
            this.HistoryPanel.SuspendLayout();
            this.ConferencePanel.SuspendLayout();
            this.CmdPanel.SuspendLayout();
            this.HoldPanel.SuspendLayout();
            this.BlindTransferPanel.SuspendLayout();
            this.TransferPanel.SuspendLayout();
            this.HangupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserInfoPanel
            // 
            this.UserInfoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.UserInfoPanel.Controls.Add(this.Line);
            this.UserInfoPanel.Controls.Add(this.CreateContactPanel);
            this.UserInfoPanel.Controls.Add(this.HistoryPanel);
            this.UserInfoPanel.Controls.Add(this.avatarBox);
            this.UserInfoPanel.Controls.Add(this.organisationLabel);
            this.UserInfoPanel.Controls.Add(this.whenBox);
            this.UserInfoPanel.Controls.Add(this.mailButton);
            this.UserInfoPanel.Controls.Add(this.infoLabel);
            this.UserInfoPanel.Controls.Add(this.nameLabel);
            this.UserInfoPanel.Location = new System.Drawing.Point(5, 32);
            this.UserInfoPanel.Name = "UserInfoPanel";
            this.UserInfoPanel.Size = new System.Drawing.Size(301, 111);
            this.UserInfoPanel.TabIndex = 52;
            this.UserInfoPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.UserInfoPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.UserInfoPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // organisationLabel
            // 
            this.organisationLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(254)))));
            this.organisationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.organisationLabel.ForeColor = System.Drawing.Color.Gray;
            this.organisationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.organisationLabel.Location = new System.Drawing.Point(111, 64);
            this.organisationLabel.Name = "organisationLabel";
            this.organisationLabel.Size = new System.Drawing.Size(187, 13);
            this.organisationLabel.TabIndex = 46;
            // 
            // whenBox
            // 
            this.whenBox.AutoEllipsis = true;
            this.whenBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.whenBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.whenBox.ForeColor = System.Drawing.Color.White;
            this.whenBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.whenBox.Location = new System.Drawing.Point(111, 44);
            this.whenBox.Name = "whenBox";
            this.whenBox.Size = new System.Drawing.Size(187, 17);
            this.whenBox.TabIndex = 45;
            this.whenBox.Text = "Вы не общались ранее";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoEllipsis = true;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoLabel.Location = new System.Drawing.Point(113, 3);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(152, 17);
            this.infoLabel.TabIndex = 6;
            this.infoLabel.Text = "Неизвестный абонент";
            this.infoLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.infoLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.infoLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoEllipsis = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(113, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(152, 17);
            this.nameLabel.TabIndex = 50;
            this.nameLabel.Text = "#UserName";
            this.nameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.nameLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.nameLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.headPanel.Controls.Add(this.closeButton);
            this.headPanel.Controls.Add(this.numberLabel);
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(480, 29);
            this.headPanel.TabIndex = 45;
            this.headPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.closeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.closeButton.Location = new System.Drawing.Point(441, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 6;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // numberLabel
            // 
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numberLabel.Location = new System.Drawing.Point(3, 5);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(415, 21);
            this.numberLabel.TabIndex = 5;
            this.numberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.numberLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.numberLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.numberLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.timeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.timeLabel.Location = new System.Drawing.Point(0, 0);
            this.timeLabel.MaximumSize = new System.Drawing.Size(200, 40);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(164, 40);
            this.timeLabel.TabIndex = 50;
            this.timeLabel.Text = "Время: 00:00:00";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.timeLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.timeLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.timeLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // durationLabel
            // 
            this.durationLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.durationLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.durationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.durationLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.durationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.durationLabel.Location = new System.Drawing.Point(0, 65);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(164, 45);
            this.durationLabel.TabIndex = 49;
            this.durationLabel.Text = "00:00:00";
            this.durationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.durationLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.durationLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.durationLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // timeDurationLabel
            // 
            this.timeDurationLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.timeDurationLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeDurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.timeDurationLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timeDurationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.timeDurationLabel.Location = new System.Drawing.Point(0, 40);
            this.timeDurationLabel.Name = "timeDurationLabel";
            this.timeDurationLabel.Size = new System.Drawing.Size(164, 25);
            this.timeDurationLabel.TabIndex = 55;
            this.timeDurationLabel.Text = "Продолжительность";
            this.timeDurationLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.timeDurationLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.timeDurationLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.timeDurationLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.ConferencePanel);
            this.ButtonsPanel.Controls.Add(this.CmdPanel);
            this.ButtonsPanel.Controls.Add(this.HoldPanel);
            this.ButtonsPanel.Controls.Add(this.BlindTransferPanel);
            this.ButtonsPanel.Controls.Add(this.TransferPanel);
            this.ButtonsPanel.Controls.Add(this.HangupPanel);
            this.ButtonsPanel.Location = new System.Drawing.Point(5, 146);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(468, 50);
            this.ButtonsPanel.TabIndex = 51;
            // 
            // TimePanel
            // 
            this.TimePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.TimePanel.Controls.Add(this.durationLabel);
            this.TimePanel.Controls.Add(this.timeDurationLabel);
            this.TimePanel.Controls.Add(this.timeLabel);
            this.TimePanel.Location = new System.Drawing.Point(309, 32);
            this.TimePanel.Name = "TimePanel";
            this.TimePanel.Size = new System.Drawing.Size(164, 111);
            this.TimePanel.TabIndex = 57;
            // 
            // leftBorder
            // 
            this.leftBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.leftBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftBorder.Location = new System.Drawing.Point(0, 0);
            this.leftBorder.Margin = new System.Windows.Forms.Padding(0);
            this.leftBorder.MaximumSize = new System.Drawing.Size(2, 1000);
            this.leftBorder.Name = "leftBorder";
            this.leftBorder.Size = new System.Drawing.Size(2, 200);
            this.leftBorder.TabIndex = 58;
            // 
            // rightBorder
            // 
            this.rightBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.rightBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightBorder.Location = new System.Drawing.Point(476, 0);
            this.rightBorder.Margin = new System.Windows.Forms.Padding(0);
            this.rightBorder.MaximumSize = new System.Drawing.Size(2, 1000);
            this.rightBorder.Name = "rightBorder";
            this.rightBorder.Size = new System.Drawing.Size(2, 200);
            this.rightBorder.TabIndex = 59;
            // 
            // bottomBorder
            // 
            this.bottomBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.bottomBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomBorder.Location = new System.Drawing.Point(2, 198);
            this.bottomBorder.Margin = new System.Windows.Forms.Padding(0);
            this.bottomBorder.MaximumSize = new System.Drawing.Size(1000, 2);
            this.bottomBorder.Name = "bottomBorder";
            this.bottomBorder.Size = new System.Drawing.Size(474, 2);
            this.bottomBorder.TabIndex = 60;
            // 
            // Images
            // 
            this.Images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Images.ImageStream")));
            this.Images.TransparentColor = System.Drawing.Color.Transparent;
            this.Images.Images.SetKeyName(0, "blind_trasfer.bmp");
            this.Images.Images.SetKeyName(1, "blind_trasfer_off.bmp");
            this.Images.Images.SetKeyName(2, "blind_trasfer_on.bmp");
            this.Images.Images.SetKeyName(3, "cmd.bmp");
            this.Images.Images.SetKeyName(4, "cmd_off.bmp");
            this.Images.Images.SetKeyName(5, "cmd_on.bmp");
            this.Images.Images.SetKeyName(6, "conference.bmp");
            this.Images.Images.SetKeyName(7, "conference_off.bmp");
            this.Images.Images.SetKeyName(8, "conference_on.bmp");
            this.Images.Images.SetKeyName(9, "edit_contact.bmp");
            this.Images.Images.SetKeyName(10, "edit_contact_on.bmp");
            this.Images.Images.SetKeyName(11, "hangup.bmp");
            this.Images.Images.SetKeyName(12, "hangup_off.bmp");
            this.Images.Images.SetKeyName(13, "hangup_on.bmp");
            this.Images.Images.SetKeyName(14, "history.bmp");
            this.Images.Images.SetKeyName(15, "history_on.bmp");
            this.Images.Images.SetKeyName(16, "hold.bmp");
            this.Images.Images.SetKeyName(17, "hold_off.bmp");
            this.Images.Images.SetKeyName(18, "hold_on.bmp");
            this.Images.Images.SetKeyName(19, "no_avatar.bmp");
            this.Images.Images.SetKeyName(20, "no_avatar_on.bmp");
            this.Images.Images.SetKeyName(21, "trasfer.bmp");
            this.Images.Images.SetKeyName(22, "trasfer_off.bmp");
            this.Images.Images.SetKeyName(23, "trasfer_on.bmp");
            this.Images.Images.SetKeyName(24, "mail.bmp");
            this.Images.Images.SetKeyName(25, "mail_on.bmp");
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripTextBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 22);
            this.toolStripTextBox1.Text = "Номер";
            this.toolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStripTextBox1_KeyDown);
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            this.toolStripTextBox1.MouseEnter += new System.EventHandler(this.toolStripTextBox1_MouseEnter);
            this.toolStripTextBox1.MouseLeave += new System.EventHandler(this.toolStripTextBox1_MouseLeave);
            // 
            // RedirectMenuStrip
            // 
            this.RedirectMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.RedirectMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.RedirectMenuStrip.Name = "contextMenuStrip1";
            this.RedirectMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.RedirectMenuStrip.ShowImageMargin = false;
            this.RedirectMenuStrip.Size = new System.Drawing.Size(136, 28);
            this.RedirectMenuStrip.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            // 
            // NotBlindRedirectMenuStrip
            // 
            this.NotBlindRedirectMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.NotBlindRedirectMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2});
            this.NotBlindRedirectMenuStrip.Name = "contextMenuStrip1";
            this.NotBlindRedirectMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.NotBlindRedirectMenuStrip.ShowImageMargin = false;
            this.NotBlindRedirectMenuStrip.Size = new System.Drawing.Size(136, 28);
            this.NotBlindRedirectMenuStrip.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.NotBlindRedirectMenuStrip_Closed);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripTextBox2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 22);
            this.toolStripTextBox2.Text = "Номер";
            // 
            // UnionSplashPanel
            // 
            this.UnionSplashPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.UnionSplashPanel.Controls.Add(this.TransferToNameLabel);
            this.UnionSplashPanel.Controls.Add(this.ToTransferNameLabel);
            this.UnionSplashPanel.Controls.Add(this.ArrowPanel);
            this.UnionSplashPanel.Controls.Add(this.TransferToAvatarPanel);
            this.UnionSplashPanel.Controls.Add(this.ToTransferAvatarPanel);
            this.UnionSplashPanel.Location = new System.Drawing.Point(5, 32);
            this.UnionSplashPanel.Name = "UnionSplashPanel";
            this.UnionSplashPanel.Size = new System.Drawing.Size(301, 111);
            this.UnionSplashPanel.TabIndex = 2;
            this.UnionSplashPanel.Visible = false;
            // 
            // ArrowPanel
            // 
            this.ArrowPanel.BackgroundImage = global::BCTI.Properties.Resources.w128h1281338911640arrowright2;
            this.ArrowPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ArrowPanel.Location = new System.Drawing.Point(126, 18);
            this.ArrowPanel.Name = "ArrowPanel";
            this.ArrowPanel.Size = new System.Drawing.Size(50, 50);
            this.ArrowPanel.TabIndex = 54;
            // 
            // TransferToAvatarPanel
            // 
            this.TransferToAvatarPanel.BackgroundImage = global::BCTI.Properties.Resources.no_photo;
            this.TransferToAvatarPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TransferToAvatarPanel.Location = new System.Drawing.Point(218, 3);
            this.TransferToAvatarPanel.Name = "TransferToAvatarPanel";
            this.TransferToAvatarPanel.Size = new System.Drawing.Size(80, 80);
            this.TransferToAvatarPanel.TabIndex = 53;
            // 
            // ToTransferAvatarPanel
            // 
            this.ToTransferAvatarPanel.BackgroundImage = global::BCTI.Properties.Resources.no_photo;
            this.ToTransferAvatarPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ToTransferAvatarPanel.Location = new System.Drawing.Point(3, 3);
            this.ToTransferAvatarPanel.Name = "ToTransferAvatarPanel";
            this.ToTransferAvatarPanel.Size = new System.Drawing.Size(80, 80);
            this.ToTransferAvatarPanel.TabIndex = 52;
            // 
            // Line
            // 
            this.Line.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Line.BackgroundImage = global::BCTI.Properties.Resources.line;
            this.Line.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Line.Location = new System.Drawing.Point(113, 38);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(184, 1);
            this.Line.TabIndex = 54;
            // 
            // CreateContactPanel
            // 
            this.CreateContactPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(254)))));
            this.CreateContactPanel.BackgroundImage = global::BCTI.Properties.Resources.edit_contact;
            this.CreateContactPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CreateContactPanel.Controls.Add(this.CreateContactLabel);
            this.CreateContactPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateContactPanel.Location = new System.Drawing.Point(206, 80);
            this.CreateContactPanel.Name = "CreateContactPanel";
            this.CreateContactPanel.Size = new System.Drawing.Size(92, 28);
            this.CreateContactPanel.TabIndex = 53;
            this.CreateContactPanel.Click += new System.EventHandler(this.contactButton_Click);
            this.CreateContactPanel.MouseEnter += new System.EventHandler(this.contactButton_MouseEnter);
            this.CreateContactPanel.MouseLeave += new System.EventHandler(this.contactButton_MouseLeave);
            // 
            // CreateContactLabel
            // 
            this.CreateContactLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateContactLabel.BackColor = System.Drawing.Color.Transparent;
            this.CreateContactLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateContactLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateContactLabel.ForeColor = System.Drawing.Color.White;
            this.CreateContactLabel.Location = new System.Drawing.Point(31, 0);
            this.CreateContactLabel.Name = "CreateContactLabel";
            this.CreateContactLabel.Size = new System.Drawing.Size(60, 27);
            this.CreateContactLabel.TabIndex = 1;
            this.CreateContactLabel.Text = "Создать контакт";
            this.CreateContactLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CreateContactLabel.UseCompatibleTextRendering = true;
            this.CreateContactLabel.Click += new System.EventHandler(this.contactButton_Click);
            this.CreateContactLabel.MouseEnter += new System.EventHandler(this.contactButton_MouseEnter);
            this.CreateContactLabel.MouseLeave += new System.EventHandler(this.contactButton_MouseLeave);
            // 
            // HistoryPanel
            // 
            this.HistoryPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(254)))));
            this.HistoryPanel.BackgroundImage = global::BCTI.Properties.Resources.history;
            this.HistoryPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HistoryPanel.Controls.Add(this.HistoryLabel);
            this.HistoryPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HistoryPanel.Location = new System.Drawing.Point(111, 80);
            this.HistoryPanel.Name = "HistoryPanel";
            this.HistoryPanel.Size = new System.Drawing.Size(92, 28);
            this.HistoryPanel.TabIndex = 52;
            this.HistoryPanel.Click += new System.EventHandler(this.historyButton_Click);
            this.HistoryPanel.MouseEnter += new System.EventHandler(this.historyButton_MouseEnter);
            this.HistoryPanel.MouseLeave += new System.EventHandler(this.historyButton_MouseLeave);
            // 
            // HistoryLabel
            // 
            this.HistoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HistoryLabel.BackColor = System.Drawing.Color.Transparent;
            this.HistoryLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HistoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HistoryLabel.ForeColor = System.Drawing.Color.White;
            this.HistoryLabel.Location = new System.Drawing.Point(29, 0);
            this.HistoryLabel.Name = "HistoryLabel";
            this.HistoryLabel.Size = new System.Drawing.Size(61, 26);
            this.HistoryLabel.TabIndex = 1;
            this.HistoryLabel.Text = "История звонков";
            this.HistoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HistoryLabel.UseCompatibleTextRendering = true;
            this.HistoryLabel.Click += new System.EventHandler(this.historyButton_Click);
            this.HistoryLabel.MouseEnter += new System.EventHandler(this.historyButton_MouseEnter);
            this.HistoryLabel.MouseLeave += new System.EventHandler(this.historyButton_MouseLeave);
            // 
            // avatarBox
            // 
            this.avatarBox.BackgroundImage = global::BCTI.Properties.Resources.no_photo;
            this.avatarBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avatarBox.Location = new System.Drawing.Point(3, 3);
            this.avatarBox.Name = "avatarBox";
            this.avatarBox.Size = new System.Drawing.Size(105, 105);
            this.avatarBox.TabIndex = 51;
            this.avatarBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.avatarBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.avatarBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // mailButton
            // 
            this.mailButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.mailButton.BackgroundImage = global::BCTI.Properties.Resources.mail;
            this.mailButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mailButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mailButton.FlatAppearance.BorderSize = 0;
            this.mailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mailButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.mailButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mailButton.Location = new System.Drawing.Point(268, 3);
            this.mailButton.Name = "mailButton";
            this.mailButton.Size = new System.Drawing.Size(30, 25);
            this.mailButton.TabIndex = 41;
            this.mailButton.UseVisualStyleBackColor = false;
            this.mailButton.Click += new System.EventHandler(this.mailButton_Click);
            this.mailButton.MouseEnter += new System.EventHandler(this.mailButton_MouseEnter);
            this.mailButton.MouseLeave += new System.EventHandler(this.mailButton_MouseLeave);
            // 
            // ConferencePanel
            // 
            this.ConferencePanel.BackgroundImage = global::BCTI.Properties.Resources.conference_off;
            this.ConferencePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConferencePanel.Controls.Add(this.ConferenceLabel);
            this.ConferencePanel.Location = new System.Drawing.Point(393, 0);
            this.ConferencePanel.Name = "ConferencePanel";
            this.ConferencePanel.Size = new System.Drawing.Size(75, 48);
            this.ConferencePanel.TabIndex = 61;
            this.ConferencePanel.MouseEnter += new System.EventHandler(this.ConferencePanel_MouseEnter);
            this.ConferencePanel.MouseLeave += new System.EventHandler(this.ConferencePanel_MouseLeave);
            // 
            // ConferenceLabel
            // 
            this.ConferenceLabel.AutoEllipsis = true;
            this.ConferenceLabel.BackColor = System.Drawing.Color.Transparent;
            this.ConferenceLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ConferenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConferenceLabel.ForeColor = System.Drawing.Color.White;
            this.ConferenceLabel.Location = new System.Drawing.Point(0, 33);
            this.ConferenceLabel.Name = "ConferenceLabel";
            this.ConferenceLabel.Size = new System.Drawing.Size(75, 15);
            this.ConferenceLabel.TabIndex = 0;
            this.ConferenceLabel.Text = "Конференция";
            this.ConferenceLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ConferenceLabel.MouseEnter += new System.EventHandler(this.ConferencePanel_MouseEnter);
            this.ConferenceLabel.MouseLeave += new System.EventHandler(this.ConferencePanel_MouseLeave);
            // 
            // CmdPanel
            // 
            this.CmdPanel.BackgroundImage = global::BCTI.Properties.Resources.cmd_off;
            this.CmdPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CmdPanel.Controls.Add(this.CmdLabel);
            this.CmdPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmdPanel.Location = new System.Drawing.Point(314, 0);
            this.CmdPanel.Name = "CmdPanel";
            this.CmdPanel.Size = new System.Drawing.Size(76, 48);
            this.CmdPanel.TabIndex = 60;
            this.CmdPanel.Click += new System.EventHandler(this.ScriptButton_Click);
            this.CmdPanel.MouseEnter += new System.EventHandler(this.ScriptButton_MouseEnter);
            this.CmdPanel.MouseLeave += new System.EventHandler(this.ScriptButton_MouseLeave);
            // 
            // CmdLabel
            // 
            this.CmdLabel.AutoEllipsis = true;
            this.CmdLabel.BackColor = System.Drawing.Color.Transparent;
            this.CmdLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmdLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CmdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CmdLabel.ForeColor = System.Drawing.Color.White;
            this.CmdLabel.Location = new System.Drawing.Point(0, 33);
            this.CmdLabel.Name = "CmdLabel";
            this.CmdLabel.Size = new System.Drawing.Size(76, 15);
            this.CmdLabel.TabIndex = 0;
            this.CmdLabel.Text = "Скрипт";
            this.CmdLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CmdLabel.Click += new System.EventHandler(this.ScriptButton_Click);
            this.CmdLabel.MouseEnter += new System.EventHandler(this.ScriptButton_MouseEnter);
            this.CmdLabel.MouseLeave += new System.EventHandler(this.ScriptButton_MouseLeave);
            // 
            // HoldPanel
            // 
            this.HoldPanel.BackgroundImage = global::BCTI.Properties.Resources.hold_off;
            this.HoldPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HoldPanel.Controls.Add(this.Answer);
            this.HoldPanel.Controls.Add(this.HoldLabel);
            this.HoldPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HoldPanel.Location = new System.Drawing.Point(157, 0);
            this.HoldPanel.Name = "HoldPanel";
            this.HoldPanel.Size = new System.Drawing.Size(75, 48);
            this.HoldPanel.TabIndex = 59;
            this.HoldPanel.Click += new System.EventHandler(this.holdButton_Click);
            this.HoldPanel.MouseEnter += new System.EventHandler(this.HoldLabel_MouseEnter);
            this.HoldPanel.MouseLeave += new System.EventHandler(this.HoldLabel_MouseLeave);
            // 
            // Answer
            // 
            this.Answer.AutoEllipsis = true;
            this.Answer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Answer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Answer.ForeColor = System.Drawing.Color.White;
            this.Answer.Location = new System.Drawing.Point(0, 0);
            this.Answer.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Answer.Name = "Answer";
            this.Answer.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Answer.Size = new System.Drawing.Size(75, 48);
            this.Answer.TabIndex = 1;
            this.Answer.Text = "Ответить";
            this.Answer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Answer.Click += new System.EventHandler(this.Answer_Click);
            this.Answer.MouseEnter += new System.EventHandler(this.Answer_MouseEnter);
            this.Answer.MouseLeave += new System.EventHandler(this.Answer_MouseLeave);
            // 
            // HoldLabel
            // 
            this.HoldLabel.AutoEllipsis = true;
            this.HoldLabel.BackColor = System.Drawing.Color.Transparent;
            this.HoldLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HoldLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HoldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HoldLabel.ForeColor = System.Drawing.Color.White;
            this.HoldLabel.Location = new System.Drawing.Point(0, 33);
            this.HoldLabel.Name = "HoldLabel";
            this.HoldLabel.Size = new System.Drawing.Size(75, 15);
            this.HoldLabel.TabIndex = 0;
            this.HoldLabel.Text = "Удержание";
            this.HoldLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HoldLabel.Click += new System.EventHandler(this.holdButton_Click);
            this.HoldLabel.MouseEnter += new System.EventHandler(this.HoldLabel_MouseEnter);
            this.HoldLabel.MouseLeave += new System.EventHandler(this.HoldLabel_MouseLeave);
            // 
            // BlindTransferPanel
            // 
            this.BlindTransferPanel.BackgroundImage = global::BCTI.Properties.Resources.blind_trasfer_off;
            this.BlindTransferPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BlindTransferPanel.Controls.Add(this.BlindTransferLabel);
            this.BlindTransferPanel.Location = new System.Drawing.Point(78, 0);
            this.BlindTransferPanel.Name = "BlindTransferPanel";
            this.BlindTransferPanel.Size = new System.Drawing.Size(76, 48);
            this.BlindTransferPanel.TabIndex = 58;
            this.BlindTransferPanel.Click += new System.EventHandler(this.redirectButton_Click);
            this.BlindTransferPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.redirectButton_MouseClick);
            this.BlindTransferPanel.MouseEnter += new System.EventHandler(this.BlindTransferPanel_MouseEnter);
            this.BlindTransferPanel.MouseLeave += new System.EventHandler(this.BlindTransferPanel_MouseLeave);
            // 
            // BlindTransferLabel
            // 
            this.BlindTransferLabel.AutoEllipsis = true;
            this.BlindTransferLabel.BackColor = System.Drawing.Color.Transparent;
            this.BlindTransferLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BlindTransferLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BlindTransferLabel.ForeColor = System.Drawing.Color.White;
            this.BlindTransferLabel.Location = new System.Drawing.Point(0, 33);
            this.BlindTransferLabel.Name = "BlindTransferLabel";
            this.BlindTransferLabel.Size = new System.Drawing.Size(76, 15);
            this.BlindTransferLabel.TabIndex = 0;
            this.BlindTransferLabel.Text = "Слепой перевод";
            this.BlindTransferLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BlindTransferLabel.Click += new System.EventHandler(this.redirectButton_Click);
            this.BlindTransferLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.redirectButton_MouseClick);
            this.BlindTransferLabel.MouseEnter += new System.EventHandler(this.BlindTransferPanel_MouseEnter);
            this.BlindTransferLabel.MouseLeave += new System.EventHandler(this.BlindTransferPanel_MouseLeave);
            // 
            // TransferPanel
            // 
            this.TransferPanel.BackgroundImage = global::BCTI.Properties.Resources.trasfer_off;
            this.TransferPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TransferPanel.Controls.Add(this.TransferLabel);
            this.TransferPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransferPanel.Location = new System.Drawing.Point(0, 0);
            this.TransferPanel.Name = "TransferPanel";
            this.TransferPanel.Size = new System.Drawing.Size(75, 48);
            this.TransferPanel.TabIndex = 57;
            this.TransferPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TransferPanel_MouseClick);
            this.TransferPanel.MouseEnter += new System.EventHandler(this.TransferPanel_MouseEnter);
            this.TransferPanel.MouseLeave += new System.EventHandler(this.TransferPanel_MouseLeave);
            // 
            // TransferLabel
            // 
            this.TransferLabel.BackColor = System.Drawing.Color.Transparent;
            this.TransferLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransferLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TransferLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TransferLabel.ForeColor = System.Drawing.Color.White;
            this.TransferLabel.Location = new System.Drawing.Point(0, 33);
            this.TransferLabel.Name = "TransferLabel";
            this.TransferLabel.Size = new System.Drawing.Size(75, 15);
            this.TransferLabel.TabIndex = 0;
            this.TransferLabel.Text = "Перевести";
            this.TransferLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TransferLabel.MouseEnter += new System.EventHandler(this.TransferPanel_MouseEnter);
            this.TransferLabel.MouseLeave += new System.EventHandler(this.TransferPanel_MouseLeave);
            // 
            // HangupPanel
            // 
            this.HangupPanel.BackgroundImage = global::BCTI.Properties.Resources.hangup_off;
            this.HangupPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HangupPanel.Controls.Add(this.HangupLabel);
            this.HangupPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HangupPanel.Location = new System.Drawing.Point(235, 0);
            this.HangupPanel.Name = "HangupPanel";
            this.HangupPanel.Size = new System.Drawing.Size(76, 48);
            this.HangupPanel.TabIndex = 56;
            this.HangupPanel.Click += new System.EventHandler(this.hangupButton_Click);
            this.HangupPanel.MouseEnter += new System.EventHandler(this.hangupButton_MouseEnter);
            this.HangupPanel.MouseLeave += new System.EventHandler(this.hangupButton_MouseLeave);
            // 
            // HangupLabel
            // 
            this.HangupLabel.BackColor = System.Drawing.Color.Transparent;
            this.HangupLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HangupLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HangupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HangupLabel.ForeColor = System.Drawing.Color.White;
            this.HangupLabel.Location = new System.Drawing.Point(0, 33);
            this.HangupLabel.Name = "HangupLabel";
            this.HangupLabel.Size = new System.Drawing.Size(76, 15);
            this.HangupLabel.TabIndex = 0;
            this.HangupLabel.Text = "Сбросить";
            this.HangupLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HangupLabel.Click += new System.EventHandler(this.hangupButton_Click);
            this.HangupLabel.MouseEnter += new System.EventHandler(this.hangupButton_MouseEnter);
            this.HangupLabel.MouseLeave += new System.EventHandler(this.hangupButton_MouseLeave);
            // 
            // ToTransferNameLabel
            // 
            this.ToTransferNameLabel.AutoEllipsis = true;
            this.ToTransferNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToTransferNameLabel.Location = new System.Drawing.Point(3, 90);
            this.ToTransferNameLabel.Name = "ToTransferNameLabel";
            this.ToTransferNameLabel.Size = new System.Drawing.Size(125, 17);
            this.ToTransferNameLabel.TabIndex = 55;
            this.ToTransferNameLabel.Text = "#UserName";
            // 
            // TransferToNameLabel
            // 
            this.TransferToNameLabel.AutoEllipsis = true;
            this.TransferToNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TransferToNameLabel.Location = new System.Drawing.Point(172, 90);
            this.TransferToNameLabel.Name = "TransferToNameLabel";
            this.TransferToNameLabel.Size = new System.Drawing.Size(125, 17);
            this.TransferToNameLabel.TabIndex = 56;
            this.TransferToNameLabel.Text = "#UserName";
            this.TransferToNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(478, 200);
            this.ControlBox = false;
            this.Controls.Add(this.UnionSplashPanel);
            this.Controls.Add(this.bottomBorder);
            this.Controls.Add(this.rightBorder);
            this.Controls.Add(this.leftBorder);
            this.Controls.Add(this.TimePanel);
            this.Controls.Add(this.UserInfoPanel);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.headPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(480, 207);
            this.MinimumSize = new System.Drawing.Size(475, 200);
            this.Name = "Splash";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Splash_FormClosing);
            this.Load += new System.EventHandler(this.Splash_Load);
            this.Shown += new System.EventHandler(this.Splash_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            this.UserInfoPanel.ResumeLayout(false);
            this.headPanel.ResumeLayout(false);
            this.ButtonsPanel.ResumeLayout(false);
            this.TimePanel.ResumeLayout(false);
            this.RedirectMenuStrip.ResumeLayout(false);
            this.RedirectMenuStrip.PerformLayout();
            this.NotBlindRedirectMenuStrip.ResumeLayout(false);
            this.NotBlindRedirectMenuStrip.PerformLayout();
            this.UnionSplashPanel.ResumeLayout(false);
            this.CreateContactPanel.ResumeLayout(false);
            this.HistoryPanel.ResumeLayout(false);
            this.ConferencePanel.ResumeLayout(false);
            this.CmdPanel.ResumeLayout(false);
            this.HoldPanel.ResumeLayout(false);
            this.BlindTransferPanel.ResumeLayout(false);
            this.TransferPanel.ResumeLayout(false);
            this.HangupPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel UserInfoPanel;
        private System.Windows.Forms.Label organisationLabel;
        private System.Windows.Forms.Label whenBox;
        private System.Windows.Forms.Button mailButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label timeDurationLabel;
        private System.Windows.Forms.ImageList closeButtonImage;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel HangupPanel;
        private System.Windows.Forms.Label HangupLabel;
        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Panel TimePanel;
        private System.Windows.Forms.Panel avatarBox;
        private System.Windows.Forms.Panel Line;
        private System.Windows.Forms.Panel CreateContactPanel;
        private System.Windows.Forms.Label CreateContactLabel;
        private System.Windows.Forms.Panel HistoryPanel;
        private System.Windows.Forms.Label HistoryLabel;
        private System.Windows.Forms.Panel BlindTransferPanel;
        private System.Windows.Forms.Label BlindTransferLabel;
        private System.Windows.Forms.Panel TransferPanel;
        private System.Windows.Forms.Label TransferLabel;
        private System.Windows.Forms.Panel ConferencePanel;
        private System.Windows.Forms.Label ConferenceLabel;
        private System.Windows.Forms.Panel CmdPanel;
        private System.Windows.Forms.Label CmdLabel;
        private System.Windows.Forms.Panel HoldPanel;
        private System.Windows.Forms.Label HoldLabel;
        private System.Windows.Forms.Panel leftBorder;
        private System.Windows.Forms.Panel rightBorder;
        private System.Windows.Forms.Panel bottomBorder;
        private System.Windows.Forms.ImageList Images;
        private System.Windows.Forms.Label Answer;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ContextMenuStrip RedirectMenuStrip;
        private System.Windows.Forms.ContextMenuStrip NotBlindRedirectMenuStrip;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.Panel UnionSplashPanel;
        private System.Windows.Forms.Panel TransferToAvatarPanel;
        private System.Windows.Forms.Panel ToTransferAvatarPanel;
        private System.Windows.Forms.Panel ArrowPanel;
        private System.Windows.Forms.Label TransferToNameLabel;
        private System.Windows.Forms.Label ToTransferNameLabel;
    }
}