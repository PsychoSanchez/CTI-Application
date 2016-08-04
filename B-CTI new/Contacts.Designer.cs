namespace BCTI
{
    partial class Contacts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contacts));
            this.headPanel = new System.Windows.Forms.Panel();
            this.rightAdResizer = new System.Windows.Forms.Panel();
            this.leftAdResizer = new System.Windows.Forms.Panel();
            this.topResizer = new System.Windows.Forms.Panel();
            this.HeadLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.toAvatars = new System.Windows.Forms.ImageList(this.components);
            this.onBLFImage = new System.Windows.Forms.ImageList(this.components);
            this.bottomResizer = new System.Windows.Forms.Panel();
            this.leftResizer = new System.Windows.Forms.Panel();
            this.rightResizer = new System.Windows.Forms.Panel();
            this.createImages = new System.Windows.Forms.ImageList(this.components);
            this.NoContactsLabel = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ImportFile = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ImportButton = new System.Windows.Forms.Label();
            this.ClearFilter = new System.Windows.Forms.Label();
            this.autoCallButton = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Label();
            this.ExportButton = new System.Windows.Forms.Label();
            this.searchPictureBox = new System.Windows.Forms.PictureBox();
            this.QuickSearchPanel = new BCTI.CustomControls.PopupSearchPanel();
            this.ContactsPanel = new BCTI.CustomControls.BTableLayotPanel();
            this.PanelLabel6 = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.PanelLabel5 = new System.Windows.Forms.Label();
            this.PanelLabel4 = new System.Windows.Forms.Label();
            this.PanelLabel3 = new System.Windows.Forms.Label();
            this.PanelLabel1 = new System.Windows.Forms.Label();
            this.headPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchPictureBox)).BeginInit();
            this.ContactsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.headPanel.Controls.Add(this.rightAdResizer);
            this.headPanel.Controls.Add(this.leftAdResizer);
            this.headPanel.Controls.Add(this.topResizer);
            this.headPanel.Controls.Add(this.HeadLabel);
            this.headPanel.Controls.Add(this.closeButton);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(750, 28);
            this.headPanel.TabIndex = 48;
            this.headPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDoubleClick);
            this.headPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // rightAdResizer
            // 
            this.rightAdResizer.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightAdResizer.Location = new System.Drawing.Point(745, 5);
            this.rightAdResizer.Name = "rightAdResizer";
            this.rightAdResizer.Size = new System.Drawing.Size(5, 23);
            this.rightAdResizer.TabIndex = 14;
            // 
            // leftAdResizer
            // 
            this.leftAdResizer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftAdResizer.Location = new System.Drawing.Point(0, 5);
            this.leftAdResizer.Name = "leftAdResizer";
            this.leftAdResizer.Size = new System.Drawing.Size(5, 23);
            this.leftAdResizer.TabIndex = 13;
            // 
            // topResizer
            // 
            this.topResizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.topResizer.Location = new System.Drawing.Point(0, 0);
            this.topResizer.Name = "topResizer";
            this.topResizer.Size = new System.Drawing.Size(750, 5);
            this.topResizer.TabIndex = 12;
            // 
            // HeadLabel
            // 
            this.HeadLabel.AutoSize = true;
            this.HeadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeadLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HeadLabel.Location = new System.Drawing.Point(3, 5);
            this.HeadLabel.Name = "HeadLabel";
            this.HeadLabel.Size = new System.Drawing.Size(151, 20);
            this.HeadLabel.TabIndex = 11;
            this.HeadLabel.Text = "Книга контактов";
            this.HeadLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.HeadLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.HeadLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.closeButton.Location = new System.Drawing.Point(711, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 10;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 48);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // toAvatars
            // 
            this.toAvatars.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.toAvatars.ImageSize = new System.Drawing.Size(38, 34);
            this.toAvatars.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // onBLFImage
            // 
            this.onBLFImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("onBLFImage.ImageStream")));
            this.onBLFImage.TransparentColor = System.Drawing.Color.Transparent;
            this.onBLFImage.Images.SetKeyName(0, "blf_on_.bmp");
            this.onBLFImage.Images.SetKeyName(1, "blf_on.bmp");
            this.onBLFImage.Images.SetKeyName(2, "blf_off.bmp");
            this.onBLFImage.Images.SetKeyName(3, "no_photo.bmp");
            // 
            // bottomResizer
            // 
            this.bottomResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.bottomResizer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomResizer.Location = new System.Drawing.Point(0, 569);
            this.bottomResizer.Name = "bottomResizer";
            this.bottomResizer.Size = new System.Drawing.Size(750, 3);
            this.bottomResizer.TabIndex = 51;
            this.bottomResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.bottomResizer.MouseEnter += new System.EventHandler(this.downResizer_MouseEnter);
            this.bottomResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.bottomResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.downResizer_MouseMove);
            this.bottomResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // leftResizer
            // 
            this.leftResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.leftResizer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftResizer.Location = new System.Drawing.Point(0, 28);
            this.leftResizer.Name = "leftResizer";
            this.leftResizer.Size = new System.Drawing.Size(3, 541);
            this.leftResizer.TabIndex = 52;
            // 
            // rightResizer
            // 
            this.rightResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.rightResizer.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightResizer.Location = new System.Drawing.Point(747, 28);
            this.rightResizer.Name = "rightResizer";
            this.rightResizer.Size = new System.Drawing.Size(3, 541);
            this.rightResizer.TabIndex = 53;
            // 
            // createImages
            // 
            this.createImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("createImages.ImageStream")));
            this.createImages.TransparentColor = System.Drawing.Color.Transparent;
            this.createImages.Images.SetKeyName(0, "contact.bmp");
            this.createImages.Images.SetKeyName(1, "contact_on.bmp");
            // 
            // NoContactsLabel
            // 
            this.NoContactsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoContactsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NoContactsLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.NoContactsLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoContactsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoContactsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.NoContactsLabel.Location = new System.Drawing.Point(8, 63);
            this.NoContactsLabel.Name = "NoContactsLabel";
            this.NoContactsLabel.Size = new System.Drawing.Size(734, 478);
            this.NoContactsLabel.TabIndex = 55;
            this.NoContactsLabel.Text = "Ваш список контактов пуст. Для добавления контакта нажмите кнопку \"Создать\"";
            this.NoContactsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NoContactsLabel.MouseEnter += new System.EventHandler(this.NoContactsLabel_MouseEnter);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.searchBox.Location = new System.Drawing.Point(13, 36);
            this.searchBox.MaximumSize = new System.Drawing.Size(182, 23);
            this.searchBox.MinimumSize = new System.Drawing.Size(182, 22);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(182, 17);
            this.searchBox.TabIndex = 56;
            this.searchBox.Text = "Введите номер или имя";
            this.searchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.searchBox_MouseClick);
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            this.searchBox.Leave += new System.EventHandler(this.searchBox_Leave);
            this.searchBox.MouseEnter += new System.EventHandler(this.searchBox_MouseEnter);
            this.searchBox.MouseLeave += new System.EventHandler(this.searchBox_MouseLeave);
            this.searchBox.MouseHover += new System.EventHandler(this.searchBox_MouseHover);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "auto_call.png");
            this.imageList1.Images.SetKeyName(1, "auto_call_on.png");
            // 
            // ImportFile
            // 
            this.ImportFile.FileName = "openFileDialog1";
            this.ImportFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ImportFile_FileOk);
            // 
            // ImportButton
            // 
            this.ImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ImportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImportButton.ForeColor = System.Drawing.Color.White;
            this.ImportButton.Image = global::BCTI.Properties.Resources.download;
            this.ImportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImportButton.Location = new System.Drawing.Point(537, 543);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(100, 24);
            this.ImportButton.TabIndex = 61;
            this.ImportButton.Text = "Импорт";
            this.ImportButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.ImportButton, "Импортировать контакты из Excel таблицы");
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            this.ImportButton.MouseEnter += new System.EventHandler(this.label9_MouseEnter);
            this.ImportButton.MouseLeave += new System.EventHandler(this.label9_MouseLeave);
            // 
            // ClearFilter
            // 
            this.ClearFilter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ClearFilter.Location = new System.Drawing.Point(199, 35);
            this.ClearFilter.Name = "ClearFilter";
            this.ClearFilter.Size = new System.Drawing.Size(22, 22);
            this.ClearFilter.TabIndex = 65;
            this.ClearFilter.Text = "X";
            this.ClearFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.ClearFilter, "Очистить фильтр");
            this.ClearFilter.Click += new System.EventHandler(this.ClearFilter_Click);
            // 
            // autoCallButton
            // 
            this.autoCallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoCallButton.BackColor = System.Drawing.Color.Transparent;
            this.autoCallButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.autoCallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.autoCallButton.ForeColor = System.Drawing.Color.White;
            this.autoCallButton.Image = ((System.Drawing.Image)(resources.GetObject("autoCallButton.Image")));
            this.autoCallButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.autoCallButton.Location = new System.Drawing.Point(619, 33);
            this.autoCallButton.Name = "autoCallButton";
            this.autoCallButton.Size = new System.Drawing.Size(121, 26);
            this.autoCallButton.TabIndex = 64;
            this.autoCallButton.Text = "Автодозвон";
            this.autoCallButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.autoCallButton, "Обзвон списка контактов из Excel таблицы");
            this.autoCallButton.Click += new System.EventHandler(this.button1_Click);
            this.autoCallButton.MouseEnter += new System.EventHandler(this.autoCallButton_MouseEnter);
            this.autoCallButton.MouseLeave += new System.EventHandler(this.autoCallButton_MouseLeave);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.Location = new System.Drawing.Point(226, 33);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(102, 26);
            this.addButton.TabIndex = 63;
            this.addButton.Text = "Создать ";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.addButton, "Создать контакт");
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            this.addButton.MouseEnter += new System.EventHandler(this.addButton_MouseEnter);
            this.addButton.MouseLeave += new System.EventHandler(this.addButton_MouseLeave);
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ExportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExportButton.ForeColor = System.Drawing.Color.White;
            this.ExportButton.Image = global::BCTI.Properties.Resources.export;
            this.ExportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExportButton.Location = new System.Drawing.Point(641, 543);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(100, 24);
            this.ExportButton.TabIndex = 62;
            this.ExportButton.Text = "Экспорт";
            this.ExportButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.ExportButton, "Экспортировать книгу контактов в Excel таблицу ");
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            this.ExportButton.MouseEnter += new System.EventHandler(this.label9_MouseEnter);
            this.ExportButton.MouseLeave += new System.EventHandler(this.label9_MouseLeave);
            // 
            // searchPictureBox
            // 
            this.searchPictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchPictureBox.BackgroundImage")));
            this.searchPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.searchPictureBox.Location = new System.Drawing.Point(8, 33);
            this.searchPictureBox.Name = "searchPictureBox";
            this.searchPictureBox.Size = new System.Drawing.Size(214, 26);
            this.searchPictureBox.TabIndex = 49;
            this.searchPictureBox.TabStop = false;
            // 
            // QuickSearchPanel
            // 
            this.QuickSearchPanel.AutoSize = true;
            this.QuickSearchPanel.BackColor = System.Drawing.SystemColors.ControlText;
            this.QuickSearchPanel.Location = new System.Drawing.Point(8, 59);
            this.QuickSearchPanel.MaximumSize = new System.Drawing.Size(214, 500);
            this.QuickSearchPanel.Name = "QuickSearchPanel";
            this.QuickSearchPanel.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.QuickSearchPanel.Size = new System.Drawing.Size(214, 25);
            this.QuickSearchPanel.TabIndex = 66;
            // 
            // ContactsPanel
            // 
            this.ContactsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsPanel.AutoScroll = true;
            this.ContactsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContactsPanel.BackColor = System.Drawing.Color.White;
            this.ContactsPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.ContactsPanel.ColumnCount = 6;
            this.ContactsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.ContactsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.ContactsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ContactsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.ContactsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.ContactsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.ContactsPanel.Controls.Add(this.PanelLabel6, 4, 0);
            this.ContactsPanel.Controls.Add(this.emailLabel, 5, 0);
            this.ContactsPanel.Controls.Add(this.PanelLabel5, 3, 0);
            this.ContactsPanel.Controls.Add(this.PanelLabel4, 2, 0);
            this.ContactsPanel.Controls.Add(this.PanelLabel3, 1, 0);
            this.ContactsPanel.Controls.Add(this.PanelLabel1, 0, 0);
            this.ContactsPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContactsPanel.Location = new System.Drawing.Point(8, 63);
            this.ContactsPanel.Name = "ContactsPanel";
            this.ContactsPanel.Padding = new System.Windows.Forms.Padding(1);
            this.ContactsPanel.RowCount = 2;
            this.ContactsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.ContactsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ContactsPanel.Size = new System.Drawing.Size(734, 478);
            this.ContactsPanel.TabIndex = 58;
            this.ContactsPanel.MouseEnter += new System.EventHandler(this.NoContactsLabel_MouseEnter);
            // 
            // PanelLabel6
            // 
            this.PanelLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.PanelLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelLabel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLabel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PanelLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PanelLabel6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PanelLabel6.Location = new System.Drawing.Point(441, 2);
            this.PanelLabel6.Margin = new System.Windows.Forms.Padding(0);
            this.PanelLabel6.Name = "PanelLabel6";
            this.PanelLabel6.Size = new System.Drawing.Size(140, 21);
            this.PanelLabel6.TabIndex = 4;
            this.PanelLabel6.Text = "Телефоны";
            // 
            // emailLabel
            // 
            this.emailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.emailLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.emailLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.emailLabel.Location = new System.Drawing.Point(582, 2);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(150, 21);
            this.emailLabel.TabIndex = 5;
            this.emailLabel.Text = "E-mail";
            // 
            // PanelLabel5
            // 
            this.PanelLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.PanelLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelLabel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLabel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PanelLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PanelLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PanelLabel5.Location = new System.Drawing.Point(310, 2);
            this.PanelLabel5.Margin = new System.Windows.Forms.Padding(0);
            this.PanelLabel5.Name = "PanelLabel5";
            this.PanelLabel5.Size = new System.Drawing.Size(130, 21);
            this.PanelLabel5.TabIndex = 3;
            this.PanelLabel5.Text = "Компания";
            // 
            // PanelLabel4
            // 
            this.PanelLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.PanelLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PanelLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PanelLabel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PanelLabel4.Location = new System.Drawing.Point(138, 2);
            this.PanelLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.PanelLabel4.Name = "PanelLabel4";
            this.PanelLabel4.Size = new System.Drawing.Size(171, 21);
            this.PanelLabel4.TabIndex = 2;
            this.PanelLabel4.Text = "Имя";
            // 
            // PanelLabel3
            // 
            this.PanelLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.PanelLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PanelLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PanelLabel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PanelLabel3.Location = new System.Drawing.Point(70, 2);
            this.PanelLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.PanelLabel3.Name = "PanelLabel3";
            this.PanelLabel3.Size = new System.Drawing.Size(67, 21);
            this.PanelLabel3.TabIndex = 1;
            this.PanelLabel3.Text = "Фото";
            // 
            // PanelLabel1
            // 
            this.PanelLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.PanelLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PanelLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PanelLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PanelLabel1.Location = new System.Drawing.Point(2, 2);
            this.PanelLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.PanelLabel1.Name = "PanelLabel1";
            this.PanelLabel1.Size = new System.Drawing.Size(67, 21);
            this.PanelLabel1.TabIndex = 0;
            this.PanelLabel1.Text = "Панель";
            // 
            // Contacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(750, 572);
            this.ControlBox = false;
            this.Controls.Add(this.QuickSearchPanel);
            this.Controls.Add(this.ClearFilter);
            this.Controls.Add(this.autoCallButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.NoContactsLabel);
            this.Controls.Add(this.ContactsPanel);
            this.Controls.Add(this.rightResizer);
            this.Controls.Add(this.leftResizer);
            this.Controls.Add(this.bottomResizer);
            this.Controls.Add(this.searchPictureBox);
            this.Controls.Add(this.headPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(380, 200);
            this.Name = "Contacts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Книга контактов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContactsBook_FormClosed);
            this.Shown += new System.EventHandler(this.Contacts_Shown);
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchPictureBox)).EndInit();
            this.ContactsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox searchPictureBox;
        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Label HeadLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ImageList closeButtonImage;
        private System.Windows.Forms.ImageList toAvatars;
        private System.Windows.Forms.ImageList onBLFImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.Panel rightAdResizer;
        private System.Windows.Forms.Panel leftAdResizer;
        private System.Windows.Forms.Panel topResizer;
        private System.Windows.Forms.Panel bottomResizer;
        private System.Windows.Forms.Panel leftResizer;
        private System.Windows.Forms.Panel rightResizer;
        private System.Windows.Forms.ImageList createImages;
        private System.Windows.Forms.Label PanelLabel1;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label PanelLabel6;
        private System.Windows.Forms.Label PanelLabel5;
        private System.Windows.Forms.Label PanelLabel4;
        private System.Windows.Forms.Label PanelLabel3;
        private System.Windows.Forms.Label NoContactsLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ImageList imageList1;
        private CustomControls.BTableLayotPanel ContactsPanel;
        private System.Windows.Forms.OpenFileDialog ImportFile;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label ExportButton;
        private System.Windows.Forms.Label autoCallButton;
        private System.Windows.Forms.Label addButton;
        private System.Windows.Forms.Label ClearFilter;
        private CustomControls.PopupSearchPanel QuickSearchPanel;
        public System.Windows.Forms.Label ImportButton;
    }
}