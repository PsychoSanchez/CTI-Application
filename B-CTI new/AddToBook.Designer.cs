namespace BCTI
{
    partial class AddToBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddToBook));
            this.headPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.headLabel = new System.Windows.Forms.Label();
            this.notesBox = new System.Windows.Forms.TextBox();
            this.secondNumberBox = new System.Windows.Forms.TextBox();
            this.DateLabel = new System.Windows.Forms.Label();
            this.birthdayBox = new System.Windows.Forms.DateTimePicker();
            this.adressBox = new System.Windows.Forms.TextBox();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.organisationBox = new System.Windows.Forms.TextBox();
            this.positionBox = new System.Windows.Forms.TextBox();
            this.onBLFImage = new System.Windows.Forms.ImageList(this.components);
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.enavaListImage = new System.Windows.Forms.ImageList(this.components);
            this.avatarDialog = new System.Windows.Forms.OpenFileDialog();
            this.avaListImage = new System.Windows.Forms.ImageList(this.components);
            this.left = new System.Windows.Forms.Panel();
            this.right = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.avatarBox = new System.Windows.Forms.PictureBox();
            this.line = new System.Windows.Forms.Panel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.prefixBox = new System.Windows.Forms.TextBox();
            this.onBLFPanel = new System.Windows.Forms.Panel();
            this.onBLFlab = new System.Windows.Forms.Label();
            this.onBLFCheckBox = new System.Windows.Forms.Panel();
            this.CancButton = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Label();
            this.bottom = new System.Windows.Forms.Panel();
            this.headPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarBox)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.onBLFPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.headPanel.Controls.Add(this.closeButton);
            this.headPanel.Controls.Add(this.headLabel);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(329, 28);
            this.headPanel.TabIndex = 40;
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
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.closeButton.Location = new System.Drawing.Point(291, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 8;
            this.closeButton.TabStop = false;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // headLabel
            // 
            this.headLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.headLabel.Location = new System.Drawing.Point(9, 5);
            this.headLabel.Name = "headLabel";
            this.headLabel.Size = new System.Drawing.Size(171, 18);
            this.headLabel.TabIndex = 2;
            this.headLabel.Text = "Создать контакт";
            this.headLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.headLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // notesBox
            // 
            this.notesBox.BackColor = System.Drawing.Color.White;
            this.notesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.notesBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.notesBox.Location = new System.Drawing.Point(4, 82);
            this.notesBox.Margin = new System.Windows.Forms.Padding(2);
            this.notesBox.Multiline = true;
            this.notesBox.Name = "notesBox";
            this.notesBox.Size = new System.Drawing.Size(311, 48);
            this.notesBox.TabIndex = 10;
            this.notesBox.Text = "Заметки";
            this.notesBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nameBox_MouseClick);
            this.notesBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            this.notesBox.Leave += new System.EventHandler(this.notesBox_Leave);
            // 
            // secondNumberBox
            // 
            this.secondNumberBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondNumberBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.secondNumberBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.secondNumberBox.Location = new System.Drawing.Point(4, 31);
            this.secondNumberBox.MaximumSize = new System.Drawing.Size(10000, 24);
            this.secondNumberBox.Name = "secondNumberBox";
            this.secondNumberBox.Size = new System.Drawing.Size(311, 24);
            this.secondNumberBox.TabIndex = 8;
            this.secondNumberBox.Text = "Дополнительный номер";
            this.secondNumberBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nameBox_MouseClick);
            this.secondNumberBox.TextChanged += new System.EventHandler(this.secondNumberBox_TextChanged);
            this.secondNumberBox.Leave += new System.EventHandler(this.secondNumberBox_Leave);
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateLabel.ForeColor = System.Drawing.Color.Black;
            this.DateLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DateLabel.Location = new System.Drawing.Point(3, 60);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(110, 16);
            this.DateLabel.TabIndex = 25;
            this.DateLabel.Text = "День рождения:";
            // 
            // birthdayBox
            // 
            this.birthdayBox.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.birthdayBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.birthdayBox.Location = new System.Drawing.Point(113, 58);
            this.birthdayBox.MaxDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.birthdayBox.MinDate = new System.DateTime(1905, 1, 1, 0, 0, 0, 0);
            this.birthdayBox.Name = "birthdayBox";
            this.birthdayBox.Size = new System.Drawing.Size(202, 20);
            this.birthdayBox.TabIndex = 9;
            this.birthdayBox.Value = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            // 
            // adressBox
            // 
            this.adressBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.adressBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.adressBox.Location = new System.Drawing.Point(143, 90);
            this.adressBox.MaximumSize = new System.Drawing.Size(172, 24);
            this.adressBox.Name = "adressBox";
            this.adressBox.Size = new System.Drawing.Size(172, 24);
            this.adressBox.TabIndex = 4;
            this.adressBox.Text = "Адрес";
            this.adressBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nameBox_MouseClick);
            this.adressBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            this.adressBox.Leave += new System.EventHandler(this.adressBox_Leave);
            // 
            // emailBox
            // 
            this.emailBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.emailBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.emailBox.Location = new System.Drawing.Point(143, 116);
            this.emailBox.MaximumSize = new System.Drawing.Size(172, 24);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(172, 24);
            this.emailBox.TabIndex = 5;
            this.emailBox.Text = "Электронная почта";
            this.emailBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nameBox_MouseClick);
            this.emailBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            this.emailBox.Leave += new System.EventHandler(this.emailBox_Leave);
            // 
            // nameBox
            // 
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.nameBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nameBox.Location = new System.Drawing.Point(143, 4);
            this.nameBox.MaximumSize = new System.Drawing.Size(172, 24);
            this.nameBox.Name = "nameBox";
            this.nameBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nameBox.Size = new System.Drawing.Size(172, 24);
            this.nameBox.TabIndex = 1;
            this.nameBox.Text = "Имя";
            this.nameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nameBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nameBox_MouseClick);
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            this.nameBox.Leave += new System.EventHandler(this.nameBox_Leave);
            // 
            // numberBox
            // 
            this.numberBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.numberBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.numberBox.Location = new System.Drawing.Point(93, 4);
            this.numberBox.MaximumSize = new System.Drawing.Size(10000, 24);
            this.numberBox.Name = "numberBox";
            this.numberBox.Size = new System.Drawing.Size(222, 24);
            this.numberBox.TabIndex = 7;
            this.numberBox.Text = "Номер";
            this.numberBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nameBox_MouseClick);
            this.numberBox.TextChanged += new System.EventHandler(this.numberBox_TextChanged);
            this.numberBox.Leave += new System.EventHandler(this.numberBox_Leave);
            // 
            // organisationBox
            // 
            this.organisationBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.organisationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.organisationBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.organisationBox.Location = new System.Drawing.Point(143, 64);
            this.organisationBox.MaximumSize = new System.Drawing.Size(172, 24);
            this.organisationBox.Name = "organisationBox";
            this.organisationBox.Size = new System.Drawing.Size(172, 24);
            this.organisationBox.TabIndex = 3;
            this.organisationBox.Text = "Организация";
            this.organisationBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nameBox_MouseClick);
            this.organisationBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            this.organisationBox.Leave += new System.EventHandler(this.organisationBox_Leave);
            // 
            // positionBox
            // 
            this.positionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.positionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.positionBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.positionBox.Location = new System.Drawing.Point(143, 30);
            this.positionBox.MaximumSize = new System.Drawing.Size(172, 24);
            this.positionBox.Name = "positionBox";
            this.positionBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.positionBox.Size = new System.Drawing.Size(172, 24);
            this.positionBox.TabIndex = 2;
            this.positionBox.Text = "Должность";
            this.positionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.positionBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nameBox_MouseClick);
            this.positionBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            this.positionBox.Leave += new System.EventHandler(this.positionBox_Leave);
            // 
            // onBLFImage
            // 
            this.onBLFImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("onBLFImage.ImageStream")));
            this.onBLFImage.TransparentColor = System.Drawing.Color.Transparent;
            this.onBLFImage.Images.SetKeyName(0, "blf_off.bmp");
            this.onBLFImage.Images.SetKeyName(1, "blf_on.bmp");
            this.onBLFImage.Images.SetKeyName(2, "blf_on_.bmp");
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // enavaListImage
            // 
            this.enavaListImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("enavaListImage.ImageStream")));
            this.enavaListImage.TransparentColor = System.Drawing.Color.Transparent;
            this.enavaListImage.Images.SetKeyName(0, "eng_add_photo.bmp");
            this.enavaListImage.Images.SetKeyName(1, "eng_add_photoactive.bmp");
            // 
            // avatarDialog
            // 
            this.avatarDialog.FileName = "avatarDialog";
            this.avatarDialog.Filter = "Изображения(*.BMP;*.JPG)|*.BMP;*.JPG;*.JPEG";
            this.avatarDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.avatarDialog_FileOk);
            // 
            // avaListImage
            // 
            this.avaListImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("avaListImage.ImageStream")));
            this.avaListImage.TransparentColor = System.Drawing.Color.Transparent;
            this.avaListImage.Images.SetKeyName(0, "add_contact.bmp");
            this.avaListImage.Images.SetKeyName(1, "add_contact_on.bmp");
            // 
            // left
            // 
            this.left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.left.Dock = System.Windows.Forms.DockStyle.Left;
            this.left.Location = new System.Drawing.Point(0, 28);
            this.left.MaximumSize = new System.Drawing.Size(2, 1000);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(2, 352);
            this.left.TabIndex = 42;
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.right.Dock = System.Windows.Forms.DockStyle.Right;
            this.right.Location = new System.Drawing.Point(327, 28);
            this.right.MaximumSize = new System.Drawing.Size(2, 1000);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(2, 352);
            this.right.TabIndex = 43;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TopPanel.Controls.Add(this.avatarBox);
            this.TopPanel.Controls.Add(this.line);
            this.TopPanel.Controls.Add(this.positionBox);
            this.TopPanel.Controls.Add(this.organisationBox);
            this.TopPanel.Controls.Add(this.nameBox);
            this.TopPanel.Controls.Add(this.emailBox);
            this.TopPanel.Controls.Add(this.adressBox);
            this.TopPanel.Location = new System.Drawing.Point(5, 31);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Padding = new System.Windows.Forms.Padding(3);
            this.TopPanel.Size = new System.Drawing.Size(319, 144);
            this.TopPanel.TabIndex = 44;
            // 
            // avatarBox
            // 
            this.avatarBox.BackgroundImage = global::BCTI.Properties.Resources.add_contact;
            this.avatarBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avatarBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.avatarBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avatarBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.avatarBox.Location = new System.Drawing.Point(4, 4);
            this.avatarBox.Name = "avatarBox";
            this.avatarBox.Size = new System.Drawing.Size(136, 136);
            this.avatarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarBox.TabIndex = 12;
            this.avatarBox.TabStop = false;
            this.avatarBox.Click += new System.EventHandler(this.avatarBox_Click);
            this.avatarBox.MouseEnter += new System.EventHandler(this.avatarBox_MouseEnter);
            this.avatarBox.MouseLeave += new System.EventHandler(this.avatarBox_MouseLeave);
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.line.BackgroundImage = global::BCTI.Properties.Resources.line1;
            this.line.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.line.Location = new System.Drawing.Point(141, 56);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(174, 6);
            this.line.TabIndex = 29;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.BottomPanel.Controls.Add(this.prefixBox);
            this.BottomPanel.Controls.Add(this.onBLFPanel);
            this.BottomPanel.Controls.Add(this.notesBox);
            this.BottomPanel.Controls.Add(this.numberBox);
            this.BottomPanel.Controls.Add(this.secondNumberBox);
            this.BottomPanel.Controls.Add(this.birthdayBox);
            this.BottomPanel.Controls.Add(this.DateLabel);
            this.BottomPanel.Location = new System.Drawing.Point(5, 178);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Padding = new System.Windows.Forms.Padding(3);
            this.BottomPanel.Size = new System.Drawing.Size(319, 166);
            this.BottomPanel.TabIndex = 45;
            // 
            // prefixBox
            // 
            this.prefixBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prefixBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prefixBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.prefixBox.Location = new System.Drawing.Point(4, 4);
            this.prefixBox.MaximumSize = new System.Drawing.Size(10000, 24);
            this.prefixBox.Name = "prefixBox";
            this.prefixBox.Size = new System.Drawing.Size(86, 24);
            this.prefixBox.TabIndex = 6;
            this.prefixBox.Text = "Префикс";
            this.prefixBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nameBox_MouseClick);
            this.prefixBox.TextChanged += new System.EventHandler(this.prefixBox_TextChanged);
            this.prefixBox.Leave += new System.EventHandler(this.prefixBox_Leave);
            // 
            // onBLFPanel
            // 
            this.onBLFPanel.BackColor = System.Drawing.Color.White;
            this.onBLFPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.onBLFPanel.Controls.Add(this.onBLFlab);
            this.onBLFPanel.Controls.Add(this.onBLFCheckBox);
            this.onBLFPanel.Location = new System.Drawing.Point(4, 133);
            this.onBLFPanel.Name = "onBLFPanel";
            this.onBLFPanel.Size = new System.Drawing.Size(311, 29);
            this.onBLFPanel.TabIndex = 29;
            // 
            // onBLFlab
            // 
            this.onBLFlab.AutoSize = true;
            this.onBLFlab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.onBLFlab.Location = new System.Drawing.Point(52, 5);
            this.onBLFlab.Name = "onBLFlab";
            this.onBLFlab.Size = new System.Drawing.Size(185, 16);
            this.onBLFlab.TabIndex = 29;
            this.onBLFlab.Text = "Отображать на панели BLF";
            this.onBLFlab.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onBlf_MouseClick);
            this.onBLFlab.MouseEnter += new System.EventHandler(this.onBLFCheckBox_MouseEnter);
            this.onBLFlab.MouseLeave += new System.EventHandler(this.onBLFCheckBox_MouseLeave);
            // 
            // onBLFCheckBox
            // 
            this.onBLFCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.onBLFCheckBox.Location = new System.Drawing.Point(11, 6);
            this.onBLFCheckBox.Name = "onBLFCheckBox";
            this.onBLFCheckBox.Size = new System.Drawing.Size(35, 15);
            this.onBLFCheckBox.TabIndex = 11;
            this.onBLFCheckBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onBlf_MouseClick);
            this.onBLFCheckBox.MouseEnter += new System.EventHandler(this.onBLFCheckBox_MouseEnter);
            this.onBLFCheckBox.MouseLeave += new System.EventHandler(this.onBLFCheckBox_MouseLeave);
            // 
            // CancButton
            // 
            this.CancButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.CancButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancButton.Location = new System.Drawing.Point(167, 348);
            this.CancButton.Name = "CancButton";
            this.CancButton.Size = new System.Drawing.Size(100, 26);
            this.CancButton.TabIndex = 13;
            this.CancButton.Text = "Отменить";
            this.CancButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CancButton.Click += new System.EventHandler(this.cancelButton_Click);
            this.CancButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.CancButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveButton.Location = new System.Drawing.Point(62, 348);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 26);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.SaveButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // bottom
            // 
            this.bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom.Location = new System.Drawing.Point(2, 378);
            this.bottom.MaximumSize = new System.Drawing.Size(500, 2);
            this.bottom.Name = "bottom";
            this.bottom.Size = new System.Drawing.Size(325, 2);
            this.bottom.TabIndex = 44;
            // 
            // AddToBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(329, 380);
            this.ControlBox = false;
            this.Controls.Add(this.bottom);
            this.Controls.Add(this.CancButton);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.headPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 380);
            this.Name = "AddToBook";
            this.Text = "00";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddToBook_FormClosing);
            this.Load += new System.EventHandler(this.AddToBook_Load);
            this.headPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarBox)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.onBLFPanel.ResumeLayout(false);
            this.onBLFPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label headLabel;
        private System.Windows.Forms.TextBox secondNumberBox;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.DateTimePicker birthdayBox;
        private System.Windows.Forms.TextBox adressBox;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.PictureBox avatarBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox numberBox;
        private System.Windows.Forms.TextBox organisationBox;
        private System.Windows.Forms.TextBox positionBox;
        private System.Windows.Forms.ImageList onBLFImage;
        private System.Windows.Forms.ImageList closeButtonImage;
        private System.Windows.Forms.ImageList enavaListImage;
        private System.Windows.Forms.TextBox notesBox;
        private System.Windows.Forms.Panel line;
        private System.Windows.Forms.OpenFileDialog avatarDialog;
        private System.Windows.Forms.ImageList avaListImage;
        private System.Windows.Forms.Panel left;
        private System.Windows.Forms.Panel right;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Label CancButton;
        private System.Windows.Forms.Label SaveButton;
        private System.Windows.Forms.Panel onBLFPanel;
        private System.Windows.Forms.Label onBLFlab;
        private System.Windows.Forms.Panel onBLFCheckBox;
        private System.Windows.Forms.Panel bottom;
        private System.Windows.Forms.TextBox prefixBox;
    }
}