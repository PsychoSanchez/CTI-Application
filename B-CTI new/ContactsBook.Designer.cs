namespace BCTI
{
    partial class ContactsBook
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactsBook));
            this.searchBox = new System.Windows.Forms.RichTextBox();
            this.headPanel = new System.Windows.Forms.Panel();
            this.rightAdResizer = new System.Windows.Forms.Panel();
            this.leftAdResizer = new System.Windows.Forms.Panel();
            this.topResizer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.onBLF = new System.Windows.Forms.DataGridViewImageColumn();
            this.avaColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organisationColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.numberColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.secondNumber = new System.Windows.Forms.DataGridViewLinkColumn();
            this.emailColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.toAvatars = new System.Windows.Forms.ImageList(this.components);
            this.onBLFImage = new System.Windows.Forms.ImageList(this.components);
            this.bottomResizer = new System.Windows.Forms.Panel();
            this.leftResizer = new System.Windows.Forms.Panel();
            this.rightResizer = new System.Windows.Forms.Panel();
            this.searchPictureBox = new System.Windows.Forms.PictureBox();
            this.addButton = new System.Windows.Forms.Button();
            this.createImages = new System.Windows.Forms.ImageList(this.components);
            this.headPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.searchBox.Location = new System.Drawing.Point(12, 44);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(183, 20);
            this.searchBox.TabIndex = 50;
            this.searchBox.Text = "";
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))),((int)(((byte)(227)))));
            this.headPanel.Controls.Add(this.rightAdResizer);
            this.headPanel.Controls.Add(this.leftAdResizer);
            this.headPanel.Controls.Add(this.topResizer);
            this.headPanel.Controls.Add(this.label1);
            this.headPanel.Controls.Add(this.closeButton);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(699, 28);
            this.headPanel.TabIndex = 48;
            this.headPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDoubleClick);
            this.headPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // rightAdResizer
            // 
            this.rightAdResizer.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightAdResizer.Location = new System.Drawing.Point(694, 5);
            this.rightAdResizer.Name = "rightAdResizer";
            this.rightAdResizer.Size = new System.Drawing.Size(5, 23);
            this.rightAdResizer.TabIndex = 14;
            this.rightAdResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.rightAdResizer.MouseEnter += new System.EventHandler(this.rightSizer_MouseEnter);
            this.rightAdResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.rightAdResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseMove);
            this.rightAdResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // leftAdResizer
            // 
            this.leftAdResizer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftAdResizer.Location = new System.Drawing.Point(0, 5);
            this.leftAdResizer.Name = "leftAdResizer";
            this.leftAdResizer.Size = new System.Drawing.Size(5, 23);
            this.leftAdResizer.TabIndex = 13;
            this.leftAdResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.leftAdResizer.MouseEnter += new System.EventHandler(this.rightSizer_MouseEnter);
            this.leftAdResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.leftAdResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftSizer_MouseMove);
            this.leftAdResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // topResizer
            // 
            this.topResizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.topResizer.Location = new System.Drawing.Point(0, 0);
            this.topResizer.Name = "topResizer";
            this.topResizer.Size = new System.Drawing.Size(699, 5);
            this.topResizer.TabIndex = 12;
            this.topResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.topResizer.MouseEnter += new System.EventHandler(this.downResizer_MouseEnter);
            this.topResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.topResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topSizer_MouseMove);
            this.topResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Книга контактов";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.closeButton.Location = new System.Drawing.Point(660, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 10;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.onBLF,
            this.avaColumn,
            this.nameColumn,
            this.organisationColumn,
            this.numberColumn,
            this.secondNumber,
            this.emailColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(9, 71);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(683, 257);
            this.dataGridView1.TabIndex = 46;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // onBLF
            // 
            this.onBLF.FillWeight = 112.6903F;
            this.onBLF.HeaderText = "Панель";
            this.onBLF.MinimumWidth = 30;
            this.onBLF.Name = "onBLF";
            this.onBLF.ReadOnly = true;
            this.onBLF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // avaColumn
            // 
            this.avaColumn.FillWeight = 59.33345F;
            this.avaColumn.HeaderText = "Фото";
            this.avaColumn.MinimumWidth = 30;
            this.avaColumn.Name = "avaColumn";
            this.avaColumn.ReadOnly = true;
            this.avaColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // nameColumn
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.nameColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nameColumn.FillWeight = 44.15793F;
            this.nameColumn.HeaderText = "Имя";
            this.nameColumn.MinimumWidth = 30;
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // organisationColumn
            // 
            this.organisationColumn.ActiveLinkColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.organisationColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.organisationColumn.FillWeight = 44.15793F;
            this.organisationColumn.HeaderText = "Организация";
            this.organisationColumn.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.organisationColumn.LinkColor = System.Drawing.Color.White;
            this.organisationColumn.MinimumWidth = 30;
            this.organisationColumn.Name = "organisationColumn";
            this.organisationColumn.ReadOnly = true;
            this.organisationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.organisationColumn.VisitedLinkColor = System.Drawing.Color.White;
            // 
            // numberColumn
            // 
            this.numberColumn.ActiveLinkColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.numberColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.numberColumn.FillWeight = 44.15793F;
            this.numberColumn.HeaderText = "Номер";
            this.numberColumn.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.numberColumn.LinkColor = System.Drawing.Color.White;
            this.numberColumn.MinimumWidth = 30;
            this.numberColumn.Name = "numberColumn";
            this.numberColumn.ReadOnly = true;
            this.numberColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.numberColumn.VisitedLinkColor = System.Drawing.Color.White;
            // 
            // secondNumber
            // 
            this.secondNumber.ActiveLinkColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.secondNumber.DefaultCellStyle = dataGridViewCellStyle5;
            this.secondNumber.FillWeight = 166.3362F;
            this.secondNumber.HeaderText = "Второй номер";
            this.secondNumber.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.secondNumber.LinkColor = System.Drawing.Color.White;
            this.secondNumber.MinimumWidth = 30;
            this.secondNumber.Name = "secondNumber";
            this.secondNumber.ReadOnly = true;
            this.secondNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.secondNumber.VisitedLinkColor = System.Drawing.Color.White;
            // 
            // emailColumn
            // 
            this.emailColumn.ActiveLinkColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.emailColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.emailColumn.FillWeight = 154.4117F;
            this.emailColumn.HeaderText = "Электронный адрес";
            this.emailColumn.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.emailColumn.LinkColor = System.Drawing.Color.White;
            this.emailColumn.MinimumWidth = 150;
            this.emailColumn.Name = "emailColumn";
            this.emailColumn.ReadOnly = true;
            this.emailColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.emailColumn.VisitedLinkColor = System.Drawing.Color.White;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 48);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
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
            this.bottomResizer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomResizer.Location = new System.Drawing.Point(0, 329);
            this.bottomResizer.Name = "bottomResizer";
            this.bottomResizer.Size = new System.Drawing.Size(699, 5);
            this.bottomResizer.TabIndex = 51;
            this.bottomResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.bottomResizer.MouseEnter += new System.EventHandler(this.downResizer_MouseEnter);
            this.bottomResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.bottomResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.downResizer_MouseMove);
            this.bottomResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // leftResizer
            // 
            this.leftResizer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftResizer.Location = new System.Drawing.Point(0, 28);
            this.leftResizer.Name = "leftResizer";
            this.leftResizer.Size = new System.Drawing.Size(5, 301);
            this.leftResizer.TabIndex = 52;
            this.leftResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.leftResizer.MouseEnter += new System.EventHandler(this.rightSizer_MouseEnter);
            this.leftResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.leftResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftSizer_MouseMove);
            this.leftResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // rightResizer
            // 
            this.rightResizer.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightResizer.Location = new System.Drawing.Point(694, 28);
            this.rightResizer.Name = "rightResizer";
            this.rightResizer.Size = new System.Drawing.Size(5, 301);
            this.rightResizer.TabIndex = 53;
            this.rightResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.rightResizer.MouseEnter += new System.EventHandler(this.rightSizer_MouseEnter);
            this.rightResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.rightResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseMove);
            this.rightResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // searchPictureBox
            // 
            this.searchPictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchPictureBox.BackgroundImage = global::BCTI.Properties.Resources.SearchLong;
            this.searchPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.searchPictureBox.Location = new System.Drawing.Point(9, 43);
            this.searchPictureBox.Name = "searchPictureBox";
            this.searchPictureBox.Size = new System.Drawing.Size(208, 24);
            this.searchPictureBox.TabIndex = 49;
            this.searchPictureBox.TabStop = false;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.addButton.BackgroundImage = global::BCTI.Properties.Resources.AddContact;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.addButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.addButton.Location = new System.Drawing.Point(229, 40);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(111, 28);
            this.addButton.TabIndex = 47;
            this.addButton.Text = "Создать";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            this.addButton.MouseEnter += new System.EventHandler(this.addButton_MouseEnter);
            this.addButton.MouseLeave += new System.EventHandler(this.addButton_MouseLeave);
            // 
            // createImages
            // 
            this.createImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("createImages.ImageStream")));
            this.createImages.TransparentColor = System.Drawing.Color.Transparent;
            this.createImages.Images.SetKeyName(0, "contact.bmp");
            this.createImages.Images.SetKeyName(1, "contact_on.bmp");
            // 
            // ContactsBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(699, 334);
            this.ControlBox = false;
            this.Controls.Add(this.rightResizer);
            this.Controls.Add(this.leftResizer);
            this.Controls.Add(this.bottomResizer);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.searchPictureBox);
            this.Controls.Add(this.headPanel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.addButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(380, 200);
            this.Name = "ContactsBook";
            this.Text = "Книга контактов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContactsBook_FormClosed);
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox searchBox;
        private System.Windows.Forms.PictureBox searchPictureBox;
        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ImageList closeButtonImage;
        private System.Windows.Forms.DataGridViewImageColumn onBLF;
        private System.Windows.Forms.DataGridViewImageColumn avaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewLinkColumn organisationColumn;
        private System.Windows.Forms.DataGridViewLinkColumn numberColumn;
        private System.Windows.Forms.DataGridViewLinkColumn secondNumber;
        private System.Windows.Forms.DataGridViewLinkColumn emailColumn;
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
    }
}