namespace BCTI
{
    partial class BLFPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLFPanel));
            this.settingsButton = new System.Windows.Forms.Button();
            this.contactsButton = new System.Windows.Forms.Button();
            this.BlfStatusLabel = new System.Windows.Forms.Label();
            this.BlfNumberLabel = new System.Windows.Forms.Label();
            this.HeadPanel = new System.Windows.Forms.Panel();
            this.topResizer = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.topButtonsImageList = new System.Windows.Forms.ImageList(this.components);
            this.BottomControls = new System.Windows.Forms.Panel();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.неБеспокоитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomResizer = new System.Windows.Forms.Panel();
            this.BlfMain = new System.Windows.Forms.Panel();
            this.NotFound = new System.Windows.Forms.Label();
            this.bOnBlfPanel = new BCTI.CustomControls.BTableLayotPanel();
            this.HiddenSplashPanel = new System.Windows.Forms.Panel();
            this.StatusToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.historyButton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.rightBorder = new System.Windows.Forms.Panel();
            this.leftBorder = new System.Windows.Forms.Panel();
            this.searchBoxImage = new System.Windows.Forms.Panel();
            this.ClearFilter = new System.Windows.Forms.Label();
            this.NoContacts = new System.Windows.Forms.Label();
            this.MissedCallsLabel = new System.Windows.Forms.Label();
            this.HeadPanel.SuspendLayout();
            this.TrayMenu.SuspendLayout();
            this.BlfMain.SuspendLayout();
            this.searchBoxImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsButton
            // 
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.settingsButton.Location = new System.Drawing.Point(164, 31);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(50, 50);
            this.settingsButton.TabIndex = 13;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            this.settingsButton.MouseEnter += new System.EventHandler(this.settingsButton_MouseEnter);
            this.settingsButton.MouseLeave += new System.EventHandler(this.settingsButton_MouseLeave);
            // 
            // contactsButton
            // 
            this.contactsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.contactsButton.FlatAppearance.BorderSize = 0;
            this.contactsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.contactsButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.contactsButton.Location = new System.Drawing.Point(111, 31);
            this.contactsButton.Name = "contactsButton";
            this.contactsButton.Size = new System.Drawing.Size(50, 50);
            this.contactsButton.TabIndex = 12;
            this.contactsButton.UseVisualStyleBackColor = true;
            this.contactsButton.Click += new System.EventHandler(this.contactsButton_Click);
            this.contactsButton.MouseEnter += new System.EventHandler(this.contactsButton_MouseEnter);
            this.contactsButton.MouseLeave += new System.EventHandler(this.contactsButton_MouseLeave);
            // 
            // BlfStatusLabel
            // 
            this.BlfStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.BlfStatusLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BlfStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.BlfStatusLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BlfStatusLabel.Location = new System.Drawing.Point(5, 59);
            this.BlfStatusLabel.Name = "BlfStatusLabel";
            this.BlfStatusLabel.Size = new System.Drawing.Size(50, 22);
            this.BlfStatusLabel.TabIndex = 10;
            this.BlfStatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BlfStatusLabel.Click += new System.EventHandler(this.BlfStatusLabel_Click);
            // 
            // BlfNumberLabel
            // 
            this.BlfNumberLabel.AutoEllipsis = true;
            this.BlfNumberLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.BlfNumberLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BlfNumberLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlfNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BlfNumberLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BlfNumberLabel.Location = new System.Drawing.Point(5, 31);
            this.BlfNumberLabel.Name = "BlfNumberLabel";
            this.BlfNumberLabel.Size = new System.Drawing.Size(50, 28);
            this.BlfNumberLabel.TabIndex = 9;
            this.BlfNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BlfNumberLabel.Click += new System.EventHandler(this.BlfNumberLabel_Click);
            // 
            // HeadPanel
            // 
            this.HeadPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.HeadPanel.Controls.Add(this.topResizer);
            this.HeadPanel.Controls.Add(this.closeButton);
            this.HeadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeadPanel.Location = new System.Drawing.Point(0, 0);
            this.HeadPanel.Name = "HeadPanel";
            this.HeadPanel.Size = new System.Drawing.Size(219, 28);
            this.HeadPanel.TabIndex = 8;
            this.HeadPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HeadPanel_MouseDoubleClick);
            this.HeadPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.HeadPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.HeadPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // topResizer
            // 
            this.topResizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.topResizer.Location = new System.Drawing.Point(0, 0);
            this.topResizer.Name = "topResizer";
            this.topResizer.Size = new System.Drawing.Size(219, 5);
            this.topResizer.TabIndex = 1;
            this.topResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.topResizer.MouseEnter += new System.EventHandler(this.downResizer_MouseEnter);
            this.topResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.topResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topSizer_MouseMove);
            this.topResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.Location = new System.Drawing.Point(183, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // topButtonsImageList
            // 
            this.topButtonsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("topButtonsImageList.ImageStream")));
            this.topButtonsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.topButtonsImageList.Images.SetKeyName(0, "history.bmp");
            this.topButtonsImageList.Images.SetKeyName(1, "history_on.bmp");
            this.topButtonsImageList.Images.SetKeyName(2, "contacts.bmp");
            this.topButtonsImageList.Images.SetKeyName(3, "contacts_on.bmp");
            this.topButtonsImageList.Images.SetKeyName(4, "settings.bmp");
            this.topButtonsImageList.Images.SetKeyName(5, "settings_on.bmp");
            // 
            // BottomControls
            // 
            this.BottomControls.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BottomControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomControls.Location = new System.Drawing.Point(0, 151);
            this.BottomControls.Name = "BottomControls";
            this.BottomControls.Size = new System.Drawing.Size(218, 30);
            this.BottomControls.TabIndex = 17;
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.TrayMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "B-CTI";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // TrayMenu
            // 
            this.TrayMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TrayMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TrayMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrayMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reconnectToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.неБеспокоитьToolStripMenuItem,
            this.toolStripSeparator1,
            this.настройкиToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.TrayMenu.Name = "TrayMenu";
            this.TrayMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TrayMenu.ShowCheckMargin = true;
            this.TrayMenu.ShowImageMargin = false;
            this.TrayMenu.Size = new System.Drawing.Size(188, 154);
            // 
            // reconnectToolStripMenuItem
            // 
            this.reconnectToolStripMenuItem.AutoToolTip = true;
            this.reconnectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
            this.reconnectToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.reconnectToolStripMenuItem.Text = "Connect";
            this.reconnectToolStripMenuItem.ToolTipText = "Connect or Reconnect to server";
            this.reconnectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(184, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItem1.Text = "Журнал событий";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // неБеспокоитьToolStripMenuItem
            // 
            this.неБеспокоитьToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.неБеспокоитьToolStripMenuItem.Checked = true;
            this.неБеспокоитьToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.неБеспокоитьToolStripMenuItem.Name = "неБеспокоитьToolStripMenuItem";
            this.неБеспокоитьToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.неБеспокоитьToolStripMenuItem.Text = "Не беспокоить";
            this.неБеспокоитьToolStripMenuItem.Click += new System.EventHandler(this.неБеспокоитьToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // bottomResizer
            // 
            this.bottomResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.bottomResizer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomResizer.Location = new System.Drawing.Point(0, 287);
            this.bottomResizer.Name = "bottomResizer";
            this.bottomResizer.Size = new System.Drawing.Size(219, 3);
            this.bottomResizer.TabIndex = 0;
            this.bottomResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.bottomResizer.MouseEnter += new System.EventHandler(this.downResizer_MouseEnter);
            this.bottomResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.bottomResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.downResizer_MouseMove);
            this.bottomResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // BlfMain
            // 
            this.BlfMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BlfMain.Controls.Add(this.NotFound);
            this.BlfMain.Controls.Add(this.bOnBlfPanel);
            this.BlfMain.Controls.Add(this.HiddenSplashPanel);
            this.BlfMain.Controls.Add(this.BottomControls);
            this.BlfMain.Location = new System.Drawing.Point(1, 108);
            this.BlfMain.Name = "BlfMain";
            this.BlfMain.Size = new System.Drawing.Size(218, 181);
            this.BlfMain.TabIndex = 18;
            // 
            // NotFound
            // 
            this.NotFound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NotFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NotFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.NotFound.Location = new System.Drawing.Point(0, 0);
            this.NotFound.Name = "NotFound";
            this.NotFound.Size = new System.Drawing.Size(218, 152);
            this.NotFound.TabIndex = 23;
            this.NotFound.Text = "По вашему запросу не найдено контактов. Нажмите Enter, чтобы позвонить\r\n.";
            this.NotFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NotFound.Visible = false;
            // 
            // bOnBlfPanel
            // 
            this.bOnBlfPanel.AutoScroll = true;
            this.bOnBlfPanel.ColumnCount = 1;
            this.bOnBlfPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bOnBlfPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bOnBlfPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOnBlfPanel.Location = new System.Drawing.Point(0, 33);
            this.bOnBlfPanel.Name = "bOnBlfPanel";
            this.bOnBlfPanel.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.bOnBlfPanel.RowCount = 1;
            this.bOnBlfPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bOnBlfPanel.Size = new System.Drawing.Size(218, 118);
            this.bOnBlfPanel.TabIndex = 23;
            this.bOnBlfPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.bOnBlfPanel_DragDrop);
            this.bOnBlfPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.bOnBlfPanel_DragEnter);
            this.bOnBlfPanel.DragLeave += new System.EventHandler(this.BLFPanel_DragLeave);
            this.bOnBlfPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bOnBlfPanel_MouseUp);
            this.bOnBlfPanel.Resize += new System.EventHandler(this.onBLFPanel_Resize);
            // 
            // HiddenSplashPanel
            // 
            this.HiddenSplashPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HiddenSplashPanel.Location = new System.Drawing.Point(0, 0);
            this.HiddenSplashPanel.MaximumSize = new System.Drawing.Size(222, 200);
            this.HiddenSplashPanel.Name = "HiddenSplashPanel";
            this.HiddenSplashPanel.Size = new System.Drawing.Size(218, 33);
            this.HiddenSplashPanel.TabIndex = 23;
            this.HiddenSplashPanel.Visible = false;
            // 
            // historyButton
            // 
            this.historyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.historyButton.FlatAppearance.BorderSize = 0;
            this.historyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historyButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.historyButton.Location = new System.Drawing.Point(58, 31);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(50, 50);
            this.historyButton.TabIndex = 11;
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            this.historyButton.MouseEnter += new System.EventHandler(this.historyButton_MouseEnter);
            this.historyButton.MouseLeave += new System.EventHandler(this.historyButton_MouseLeave);
            // 
            // SearchBox
            // 
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.85F);
            this.SearchBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.SearchBox.Location = new System.Drawing.Point(4, 1);
            this.SearchBox.MinimumSize = new System.Drawing.Size(175, 21);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(175, 17);
            this.SearchBox.TabIndex = 19;
            this.SearchBox.Text = "Введите номер или имя";
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            this.SearchBox.MouseEnter += new System.EventHandler(this.SearchBox_MouseEnter);
            this.SearchBox.MouseLeave += new System.EventHandler(this.SearchBox_MouseLeave);
            // 
            // rightBorder
            // 
            this.rightBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.rightBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightBorder.Location = new System.Drawing.Point(217, 28);
            this.rightBorder.Name = "rightBorder";
            this.rightBorder.Size = new System.Drawing.Size(2, 259);
            this.rightBorder.TabIndex = 20;
            // 
            // leftBorder
            // 
            this.leftBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.leftBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftBorder.Location = new System.Drawing.Point(0, 28);
            this.leftBorder.Name = "leftBorder";
            this.leftBorder.Size = new System.Drawing.Size(2, 259);
            this.leftBorder.TabIndex = 21;
            // 
            // searchBoxImage
            // 
            this.searchBoxImage.BackgroundImage = global::BCTI.Properties.Resources.SearchLong;
            this.searchBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBoxImage.Controls.Add(this.ClearFilter);
            this.searchBoxImage.Controls.Add(this.SearchBox);
            this.searchBoxImage.Location = new System.Drawing.Point(5, 84);
            this.searchBoxImage.Name = "searchBoxImage";
            this.searchBoxImage.Size = new System.Drawing.Size(209, 24);
            this.searchBoxImage.TabIndex = 22;
            // 
            // ClearFilter
            // 
            this.ClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ClearFilter.Location = new System.Drawing.Point(185, -2);
            this.ClearFilter.Name = "ClearFilter";
            this.ClearFilter.Size = new System.Drawing.Size(24, 22);
            this.ClearFilter.TabIndex = 20;
            this.ClearFilter.Text = "x";
            this.ClearFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClearFilter.Click += new System.EventHandler(this.ClearFilter_Click);
            // 
            // NoContacts
            // 
            this.NoContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoContacts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NoContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoContacts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.NoContacts.Location = new System.Drawing.Point(3, 113);
            this.NoContacts.Name = "NoContacts";
            this.NoContacts.Size = new System.Drawing.Size(213, 174);
            this.NoContacts.TabIndex = 20;
            this.NoContacts.Text = "Список избранных контактов пуст. Вы можете добавить их из книги контактов\r\n.";
            this.NoContacts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NoContacts.Click += new System.EventHandler(this.NoContacts_Click);
            // 
            // MissedCallsLabel
            // 
            this.MissedCallsLabel.BackColor = System.Drawing.Color.Maroon;
            this.MissedCallsLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MissedCallsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.MissedCallsLabel.ForeColor = System.Drawing.Color.Transparent;
            this.MissedCallsLabel.Location = new System.Drawing.Point(91, 64);
            this.MissedCallsLabel.Name = "MissedCallsLabel";
            this.MissedCallsLabel.Size = new System.Drawing.Size(16, 16);
            this.MissedCallsLabel.TabIndex = 23;
            this.MissedCallsLabel.Text = "10";
            this.MissedCallsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MissedCallsLabel.UseCompatibleTextRendering = true;
            this.MissedCallsLabel.Visible = false;
            this.MissedCallsLabel.Click += new System.EventHandler(this.historyButton_Click);
            this.MissedCallsLabel.MouseEnter += new System.EventHandler(this.historyButton_MouseEnter);
            this.MissedCallsLabel.MouseLeave += new System.EventHandler(this.historyButton_MouseLeave);
            // 
            // BLFPanel
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(219, 290);
            this.ControlBox = false;
            this.Controls.Add(this.MissedCallsLabel);
            this.Controls.Add(this.NoContacts);
            this.Controls.Add(this.leftBorder);
            this.Controls.Add(this.rightBorder);
            this.Controls.Add(this.bottomResizer);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.contactsButton);
            this.Controls.Add(this.historyButton);
            this.Controls.Add(this.BlfStatusLabel);
            this.Controls.Add(this.BlfNumberLabel);
            this.Controls.Add(this.HeadPanel);
            this.Controls.Add(this.searchBoxImage);
            this.Controls.Add(this.BlfMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(219, 510);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(219, 188);
            this.Name = "BLFPanel";
            this.ShowInTaskbar = false;
            this.Text = "B-CTI";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.BLFPanel_Load);
            this.Shown += new System.EventHandler(this.newBLFPanel_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.bOnBlfPanel_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.bOnBlfPanel_DragEnter);
            this.DragLeave += new System.EventHandler(this.BLFPanel_DragLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bOnBlfPanel_MouseUp);
            this.HeadPanel.ResumeLayout(false);
            this.TrayMenu.ResumeLayout(false);
            this.BlfMain.ResumeLayout(false);
            this.searchBoxImage.ResumeLayout(false);
            this.searchBoxImage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button contactsButton;
        private System.Windows.Forms.Label BlfStatusLabel;
        private System.Windows.Forms.Label BlfNumberLabel;
        private System.Windows.Forms.Panel HeadPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ImageList closeButtonImage;
        private System.Windows.Forms.ImageList topButtonsImageList;
        private System.Windows.Forms.Panel BottomControls;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem неБеспокоитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel topResizer;
        private System.Windows.Forms.Panel bottomResizer;
        private System.Windows.Forms.Panel BlfMain;
        private System.Windows.Forms.ToolTip StatusToolTip;
        private System.Windows.Forms.ToolStripMenuItem reconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Panel rightBorder;
        private System.Windows.Forms.Panel leftBorder;
        private System.Windows.Forms.Panel searchBoxImage;
        private System.Windows.Forms.Label NoContacts;
        private System.Windows.Forms.Label NotFound;
        private System.Windows.Forms.Label ClearFilter;
        private CustomControls.BTableLayotPanel bOnBlfPanel;
        private System.Windows.Forms.Panel HiddenSplashPanel;
        private System.Windows.Forms.Label MissedCallsLabel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button historyButton;
    }
}