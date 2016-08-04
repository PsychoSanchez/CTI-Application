namespace BCTI.DialogBoxes
{
    partial class BMessageForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BMessageForm));
            this.headPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.OKbutton = new System.Windows.Forms.Button();
            this.rightResizer = new System.Windows.Forms.Panel();
            this.leftResizer = new System.Windows.Forms.Panel();
            this.bottomResizer = new System.Windows.Forms.Panel();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.OKpanel = new System.Windows.Forms.Panel();
            this.AbortRetryIgnorePanel = new System.Windows.Forms.Panel();
            this.IgnoreButton = new System.Windows.Forms.Button();
            this.RetryButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            this.YesNoCancelPanel = new System.Windows.Forms.Panel();
            this.CancelYNCButton = new System.Windows.Forms.Button();
            this.NoYNCButton = new System.Windows.Forms.Button();
            this.YesYNCButton = new System.Windows.Forms.Button();
            this.OKCancelPanel = new System.Windows.Forms.Panel();
            this.OKOCButton = new System.Windows.Forms.Button();
            this.CancelOCButton = new System.Windows.Forms.Button();
            this.RetryCancelPanel = new System.Windows.Forms.Panel();
            this.RetryRCButton = new System.Windows.Forms.Button();
            this.CancelRCButton = new System.Windows.Forms.Button();
            this.YesNoPanel = new System.Windows.Forms.Panel();
            this.YesYNButton = new System.Windows.Forms.Button();
            this.NoYNButton = new System.Windows.Forms.Button();
            this.iconsList = new System.Windows.Forms.ImageList(this.components);
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.additionButton = new System.Windows.Forms.Button();
            this.headPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.OKpanel.SuspendLayout();
            this.AbortRetryIgnorePanel.SuspendLayout();
            this.YesNoCancelPanel.SuspendLayout();
            this.OKCancelPanel.SuspendLayout();
            this.RetryCancelPanel.SuspendLayout();
            this.YesNoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.SystemColors.Control;
            this.headPanel.Controls.Add(this.titleLabel);
            this.headPanel.Controls.Add(this.closeButton);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(474, 28);
            this.headPanel.TabIndex = 0;
            this.headPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.Location = new System.Drawing.Point(4, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(76, 16);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Exception";
            this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.titleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.titleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.Location = new System.Drawing.Point(439, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 2;
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
            // OKbutton
            // 
            this.OKbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.OKbutton.FlatAppearance.BorderSize = 0;
            this.OKbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OKbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.OKbutton.Location = new System.Drawing.Point(41, 0);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(88, 25);
            this.OKbutton.TabIndex = 3;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = false;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            this.OKbutton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OKbutton_MouseClick);
            this.OKbutton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.OKbutton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // rightResizer
            // 
            this.rightResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.rightResizer.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightResizer.Location = new System.Drawing.Point(471, 28);
            this.rightResizer.Name = "rightResizer";
            this.rightResizer.Size = new System.Drawing.Size(3, 191);
            this.rightResizer.TabIndex = 59;
            // 
            // leftResizer
            // 
            this.leftResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.leftResizer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftResizer.Location = new System.Drawing.Point(0, 28);
            this.leftResizer.Name = "leftResizer";
            this.leftResizer.Size = new System.Drawing.Size(3, 191);
            this.leftResizer.TabIndex = 58;
            // 
            // bottomResizer
            // 
            this.bottomResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.bottomResizer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomResizer.Location = new System.Drawing.Point(0, 219);
            this.bottomResizer.Name = "bottomResizer";
            this.bottomResizer.Size = new System.Drawing.Size(474, 3);
            this.bottomResizer.TabIndex = 57;
            // 
            // iconBox
            // 
            this.iconBox.BackgroundImage = global::BCTI.Properties.Resources.Close_Program;
            this.iconBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconBox.ErrorImage = null;
            this.iconBox.Location = new System.Drawing.Point(59, 73);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(40, 38);
            this.iconBox.TabIndex = 2;
            this.iconBox.TabStop = false;
            // 
            // OKpanel
            // 
            this.OKpanel.Controls.Add(this.OKbutton);
            this.OKpanel.Location = new System.Drawing.Point(148, 176);
            this.OKpanel.Name = "OKpanel";
            this.OKpanel.Size = new System.Drawing.Size(170, 25);
            this.OKpanel.TabIndex = 60;
            // 
            // AbortRetryIgnorePanel
            // 
            this.AbortRetryIgnorePanel.Controls.Add(this.IgnoreButton);
            this.AbortRetryIgnorePanel.Controls.Add(this.RetryButton);
            this.AbortRetryIgnorePanel.Controls.Add(this.AbortButton);
            this.AbortRetryIgnorePanel.Location = new System.Drawing.Point(23, 176);
            this.AbortRetryIgnorePanel.Name = "AbortRetryIgnorePanel";
            this.AbortRetryIgnorePanel.Size = new System.Drawing.Size(430, 25);
            this.AbortRetryIgnorePanel.TabIndex = 4;
            // 
            // IgnoreButton
            // 
            this.IgnoreButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.IgnoreButton.FlatAppearance.BorderSize = 0;
            this.IgnoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IgnoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IgnoreButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.IgnoreButton.Location = new System.Drawing.Point(299, 0);
            this.IgnoreButton.Name = "IgnoreButton";
            this.IgnoreButton.Size = new System.Drawing.Size(131, 25);
            this.IgnoreButton.TabIndex = 61;
            this.IgnoreButton.Text = "Продолжить";
            this.IgnoreButton.UseVisualStyleBackColor = false;
            this.IgnoreButton.Click += new System.EventHandler(this.IgnoreButton_Click);
            this.IgnoreButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.IgnoreButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // RetryButton
            // 
            this.RetryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.RetryButton.FlatAppearance.BorderSize = 0;
            this.RetryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RetryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RetryButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RetryButton.Location = new System.Drawing.Point(149, 0);
            this.RetryButton.Name = "RetryButton";
            this.RetryButton.Size = new System.Drawing.Size(144, 25);
            this.RetryButton.TabIndex = 61;
            this.RetryButton.Text = "Сохранить отчет";
            this.RetryButton.UseVisualStyleBackColor = false;
            this.RetryButton.Click += new System.EventHandler(this.RetryRCButton_Click);
            this.RetryButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.RetryButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // AbortButton
            // 
            this.AbortButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.AbortButton.FlatAppearance.BorderSize = 0;
            this.AbortButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AbortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AbortButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AbortButton.Location = new System.Drawing.Point(0, 0);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(143, 25);
            this.AbortButton.TabIndex = 0;
            this.AbortButton.Text = "Отправить отчет";
            this.AbortButton.UseVisualStyleBackColor = false;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            this.AbortButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.AbortButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // YesNoCancelPanel
            // 
            this.YesNoCancelPanel.Controls.Add(this.CancelYNCButton);
            this.YesNoCancelPanel.Controls.Add(this.NoYNCButton);
            this.YesNoCancelPanel.Controls.Add(this.YesYNCButton);
            this.YesNoCancelPanel.Location = new System.Drawing.Point(22, 176);
            this.YesNoCancelPanel.Name = "YesNoCancelPanel";
            this.YesNoCancelPanel.Size = new System.Drawing.Size(431, 25);
            this.YesNoCancelPanel.TabIndex = 61;
            // 
            // CancelYNCButton
            // 
            this.CancelYNCButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.CancelYNCButton.FlatAppearance.BorderSize = 0;
            this.CancelYNCButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelYNCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelYNCButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelYNCButton.Location = new System.Drawing.Point(334, 0);
            this.CancelYNCButton.Name = "CancelYNCButton";
            this.CancelYNCButton.Size = new System.Drawing.Size(97, 25);
            this.CancelYNCButton.TabIndex = 61;
            this.CancelYNCButton.Text = "Отмена";
            this.CancelYNCButton.UseVisualStyleBackColor = false;
            this.CancelYNCButton.Click += new System.EventHandler(this.CancelRCButton_Click);
            this.CancelYNCButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.CancelYNCButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // NoYNCButton
            // 
            this.NoYNCButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.NoYNCButton.FlatAppearance.BorderSize = 0;
            this.NoYNCButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoYNCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoYNCButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NoYNCButton.Location = new System.Drawing.Point(166, 0);
            this.NoYNCButton.Name = "NoYNCButton";
            this.NoYNCButton.Size = new System.Drawing.Size(88, 25);
            this.NoYNCButton.TabIndex = 61;
            this.NoYNCButton.Text = "Нет";
            this.NoYNCButton.UseVisualStyleBackColor = false;
            this.NoYNCButton.Click += new System.EventHandler(this.NoYNButton_Click);
            this.NoYNCButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.NoYNCButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // YesYNCButton
            // 
            this.YesYNCButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.YesYNCButton.FlatAppearance.BorderSize = 0;
            this.YesYNCButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YesYNCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YesYNCButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.YesYNCButton.Location = new System.Drawing.Point(0, 0);
            this.YesYNCButton.Name = "YesYNCButton";
            this.YesYNCButton.Size = new System.Drawing.Size(88, 25);
            this.YesYNCButton.TabIndex = 0;
            this.YesYNCButton.Text = "Да";
            this.YesYNCButton.UseVisualStyleBackColor = false;
            this.YesYNCButton.Click += new System.EventHandler(this.YesYNButton_Click);
            this.YesYNCButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.YesYNCButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // OKCancelPanel
            // 
            this.OKCancelPanel.Controls.Add(this.OKOCButton);
            this.OKCancelPanel.Controls.Add(this.CancelOCButton);
            this.OKCancelPanel.Location = new System.Drawing.Point(22, 176);
            this.OKCancelPanel.Name = "OKCancelPanel";
            this.OKCancelPanel.Size = new System.Drawing.Size(431, 25);
            this.OKCancelPanel.TabIndex = 62;
            // 
            // OKOCButton
            // 
            this.OKOCButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.OKOCButton.FlatAppearance.BorderSize = 0;
            this.OKOCButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKOCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OKOCButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.OKOCButton.Location = new System.Drawing.Point(105, 0);
            this.OKOCButton.Name = "OKOCButton";
            this.OKOCButton.Size = new System.Drawing.Size(97, 25);
            this.OKOCButton.TabIndex = 63;
            this.OKOCButton.Text = "OK";
            this.OKOCButton.UseVisualStyleBackColor = false;
            this.OKOCButton.Click += new System.EventHandler(this.OKbutton_Click);
            this.OKOCButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.OKOCButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // CancelOCButton
            // 
            this.CancelOCButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.CancelOCButton.FlatAppearance.BorderSize = 0;
            this.CancelOCButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelOCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelOCButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelOCButton.Location = new System.Drawing.Point(214, 0);
            this.CancelOCButton.Name = "CancelOCButton";
            this.CancelOCButton.Size = new System.Drawing.Size(97, 25);
            this.CancelOCButton.TabIndex = 63;
            this.CancelOCButton.Text = "Отмена";
            this.CancelOCButton.UseVisualStyleBackColor = false;
            this.CancelOCButton.Click += new System.EventHandler(this.CancelRCButton_Click);
            this.CancelOCButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.CancelOCButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // RetryCancelPanel
            // 
            this.RetryCancelPanel.Controls.Add(this.RetryRCButton);
            this.RetryCancelPanel.Controls.Add(this.CancelRCButton);
            this.RetryCancelPanel.Location = new System.Drawing.Point(127, 176);
            this.RetryCancelPanel.Name = "RetryCancelPanel";
            this.RetryCancelPanel.Size = new System.Drawing.Size(206, 25);
            this.RetryCancelPanel.TabIndex = 63;
            // 
            // RetryRCButton
            // 
            this.RetryRCButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.RetryRCButton.FlatAppearance.BorderSize = 0;
            this.RetryRCButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RetryRCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RetryRCButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RetryRCButton.Location = new System.Drawing.Point(0, 0);
            this.RetryRCButton.Name = "RetryRCButton";
            this.RetryRCButton.Size = new System.Drawing.Size(97, 25);
            this.RetryRCButton.TabIndex = 63;
            this.RetryRCButton.Text = "Повторить";
            this.RetryRCButton.UseVisualStyleBackColor = false;
            this.RetryRCButton.Click += new System.EventHandler(this.RetryRCButton_Click);
            this.RetryRCButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.RetryRCButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // CancelRCButton
            // 
            this.CancelRCButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.CancelRCButton.FlatAppearance.BorderSize = 0;
            this.CancelRCButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelRCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelRCButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelRCButton.Location = new System.Drawing.Point(109, 0);
            this.CancelRCButton.Name = "CancelRCButton";
            this.CancelRCButton.Size = new System.Drawing.Size(97, 25);
            this.CancelRCButton.TabIndex = 63;
            this.CancelRCButton.Text = "Отмена";
            this.CancelRCButton.UseVisualStyleBackColor = false;
            this.CancelRCButton.Click += new System.EventHandler(this.CancelRCButton_Click);
            this.CancelRCButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.CancelRCButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // YesNoPanel
            // 
            this.YesNoPanel.Controls.Add(this.YesYNButton);
            this.YesNoPanel.Controls.Add(this.NoYNButton);
            this.YesNoPanel.Location = new System.Drawing.Point(127, 176);
            this.YesNoPanel.Name = "YesNoPanel";
            this.YesNoPanel.Size = new System.Drawing.Size(206, 25);
            this.YesNoPanel.TabIndex = 64;
            // 
            // YesYNButton
            // 
            this.YesYNButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.YesYNButton.FlatAppearance.BorderSize = 0;
            this.YesYNButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YesYNButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YesYNButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.YesYNButton.Location = new System.Drawing.Point(0, 0);
            this.YesYNButton.Name = "YesYNButton";
            this.YesYNButton.Size = new System.Drawing.Size(97, 25);
            this.YesYNButton.TabIndex = 63;
            this.YesYNButton.Text = "Да";
            this.YesYNButton.UseVisualStyleBackColor = false;
            this.YesYNButton.Click += new System.EventHandler(this.YesYNButton_Click);
            this.YesYNButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.YesYNButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // NoYNButton
            // 
            this.NoYNButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.NoYNButton.FlatAppearance.BorderSize = 0;
            this.NoYNButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoYNButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoYNButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NoYNButton.Location = new System.Drawing.Point(109, 0);
            this.NoYNButton.Name = "NoYNButton";
            this.NoYNButton.Size = new System.Drawing.Size(97, 25);
            this.NoYNButton.TabIndex = 63;
            this.NoYNButton.Text = "Нет";
            this.NoYNButton.UseVisualStyleBackColor = false;
            this.NoYNButton.Click += new System.EventHandler(this.NoYNButton_Click);
            this.NoYNButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.NoYNButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // iconsList
            // 
            this.iconsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconsList.ImageStream")));
            this.iconsList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconsList.Images.SetKeyName(0, "Close_Program.png");
            this.iconsList.Images.SetKeyName(1, "Info_1.png");
            this.iconsList.Images.SetKeyName(2, "Screen Shot 2014-03-26 at 6.01.54 AM 2.png");
            this.iconsList.Images.SetKeyName(3, "w128h1281338911352help.png");
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoEllipsis = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.descriptionLabel.Location = new System.Drawing.Point(116, 73);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(242, 60);
            this.descriptionLabel.TabIndex = 65;
            this.descriptionLabel.Text = "Description";
            // 
            // additionButton
            // 
            this.additionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.additionButton.FlatAppearance.BorderSize = 0;
            this.additionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.additionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.additionButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.additionButton.Location = new System.Drawing.Point(178, 143);
            this.additionButton.Name = "additionButton";
            this.additionButton.Size = new System.Drawing.Size(118, 25);
            this.additionButton.TabIndex = 66;
            this.additionButton.Text = "Подробности";
            this.additionButton.UseVisualStyleBackColor = false;
            this.additionButton.Visible = false;
            // 
            // BMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(474, 222);
            this.Controls.Add(this.additionButton);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.OKpanel);
            this.Controls.Add(this.YesNoPanel);
            this.Controls.Add(this.RetryCancelPanel);
            this.Controls.Add(this.OKCancelPanel);
            this.Controls.Add(this.YesNoCancelPanel);
            this.Controls.Add(this.AbortRetryIgnorePanel);
            this.Controls.Add(this.rightResizer);
            this.Controls.Add(this.leftResizer);
            this.Controls.Add(this.bottomResizer);
            this.Controls.Add(this.iconBox);
            this.Controls.Add(this.headPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BMessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.OKpanel.ResumeLayout(false);
            this.AbortRetryIgnorePanel.ResumeLayout(false);
            this.YesNoCancelPanel.ResumeLayout(false);
            this.OKCancelPanel.ResumeLayout(false);
            this.RetryCancelPanel.ResumeLayout(false);
            this.YesNoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ImageList closeButtonImage;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Panel rightResizer;
        private System.Windows.Forms.Panel leftResizer;
        private System.Windows.Forms.Panel bottomResizer;
        private System.Windows.Forms.Panel OKpanel;
        private System.Windows.Forms.Panel AbortRetryIgnorePanel;
        private System.Windows.Forms.Button RetryButton;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Button IgnoreButton;
        private System.Windows.Forms.Button CancelYNCButton;
        private System.Windows.Forms.Button NoYNCButton;
        private System.Windows.Forms.Button YesYNCButton;
        private System.Windows.Forms.Panel YesNoCancelPanel;
        private System.Windows.Forms.Panel OKCancelPanel;
        private System.Windows.Forms.Button OKOCButton;
        private System.Windows.Forms.Button CancelOCButton;
        private System.Windows.Forms.Panel RetryCancelPanel;
        private System.Windows.Forms.Button RetryRCButton;
        private System.Windows.Forms.Button CancelRCButton;
        private System.Windows.Forms.Panel YesNoPanel;
        private System.Windows.Forms.Button YesYNButton;
        private System.Windows.Forms.Button NoYNButton;
        private System.Windows.Forms.ImageList iconsList;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button additionButton;
    }
}
