namespace BCTI
{
    partial class ringCard
    {
        /// <summary> 
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ringCard));
            this.ContactName = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.playImages = new System.Windows.Forms.ImageList(this.components);
            this.typeImages = new System.Windows.Forms.ImageList(this.components);
            this.MainPabel = new System.Windows.Forms.Panel();
            this.AddButton = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Label();
            this.Details = new System.Windows.Forms.Label();
            this.CallNumber = new System.Windows.Forms.Label();
            this.typePicture = new System.Windows.Forms.PictureBox();
            this.Border = new System.Windows.Forms.Panel();
            this.MainPabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typePicture)).BeginInit();
            this.Border.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContactName
            // 
            this.ContactName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactName.AutoEllipsis = true;
            this.ContactName.BackColor = System.Drawing.Color.Transparent;
            this.ContactName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContactName.Location = new System.Drawing.Point(37, 1);
            this.ContactName.Name = "ContactName";
            this.ContactName.Size = new System.Drawing.Size(139, 16);
            this.ContactName.TabIndex = 2;
            this.ContactName.Text = "Неизвестно";
            this.ContactName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainPabel_MouseDoubleClick);
            this.ContactName.MouseEnter += new System.EventHandler(this.RingMouseEnter);
            this.ContactName.MouseLeave += new System.EventHandler(this.RingMouseLeave);
            // 
            // Time
            // 
            this.Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Time.BackColor = System.Drawing.Color.Transparent;
            this.Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.Time.Location = new System.Drawing.Point(184, 1);
            this.Time.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Time.Name = "Time";
            this.Time.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Time.Size = new System.Drawing.Size(126, 16);
            this.Time.TabIndex = 6;
            this.Time.Text = "Дата-Время";
            this.Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Time.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainPabel_MouseDoubleClick);
            this.Time.MouseEnter += new System.EventHandler(this.RingMouseEnter);
            this.Time.MouseLeave += new System.EventHandler(this.RingMouseLeave);
            // 
            // playImages
            // 
            this.playImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("playImages.ImageStream")));
            this.playImages.TransparentColor = System.Drawing.Color.Transparent;
            this.playImages.Images.SetKeyName(0, "play.bmp");
            this.playImages.Images.SetKeyName(1, "playfocus.bmp");
            // 
            // typeImages
            // 
            this.typeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("typeImages.ImageStream")));
            this.typeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.typeImages.Images.SetKeyName(0, "incoming.png");
            this.typeImages.Images.SetKeyName(1, "outgoing.png");
            this.typeImages.Images.SetKeyName(2, "unanswered.png");
            // 
            // MainPabel
            // 
            this.MainPabel.BackColor = System.Drawing.Color.White;
            this.MainPabel.Controls.Add(this.AddButton);
            this.MainPabel.Controls.Add(this.playButton);
            this.MainPabel.Controls.Add(this.ContactName);
            this.MainPabel.Controls.Add(this.Details);
            this.MainPabel.Controls.Add(this.CallNumber);
            this.MainPabel.Controls.Add(this.typePicture);
            this.MainPabel.Controls.Add(this.Time);
            this.MainPabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPabel.Location = new System.Drawing.Point(1, 1);
            this.MainPabel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPabel.Name = "MainPabel";
            this.MainPabel.Padding = new System.Windows.Forms.Padding(1);
            this.MainPabel.Size = new System.Drawing.Size(308, 38);
            this.MainPabel.TabIndex = 7;
            this.MainPabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainPabel_MouseDoubleClick);
            this.MainPabel.MouseEnter += new System.EventHandler(this.RingMouseEnter);
            this.MainPabel.MouseLeave += new System.EventHandler(this.RingMouseLeave);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButton.ForeColor = System.Drawing.Color.White;
            this.AddButton.Location = new System.Drawing.Point(168, 19);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(17, 17);
            this.AddButton.TabIndex = 11;
            this.AddButton.Text = "+";
            this.AddButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AddButton.UseCompatibleTextRendering = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click_1);
            this.AddButton.MouseEnter += new System.EventHandler(this.AddButton_MouseEnter);
            this.AddButton.MouseLeave += new System.EventHandler(this.AddButton_MouseLeave);
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.playButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.playButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playButton.Image = global::BCTI.Properties.Resources.play_small;
            this.playButton.Location = new System.Drawing.Point(256, 19);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(50, 17);
            this.playButton.TabIndex = 10;
            this.playButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.MouseEnter += new System.EventHandler(this.playButton_MouseEnter);
            this.playButton.MouseLeave += new System.EventHandler(this.playButton_MouseLeave);
            // 
            // Details
            // 
            this.Details.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Details.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.Details.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Details.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Details.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Details.Location = new System.Drawing.Point(188, 19);
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(65, 17);
            this.Details.TabIndex = 8;
            this.Details.Text = "Детали";
            this.Details.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Details.Click += new System.EventHandler(this.detailsButton_Click);
            this.Details.MouseEnter += new System.EventHandler(this.Details_MouseEnter);
            this.Details.MouseLeave += new System.EventHandler(this.Details_MouseLeave);
            // 
            // CallNumber
            // 
            this.CallNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CallNumber.AutoEllipsis = true;
            this.CallNumber.AutoSize = true;
            this.CallNumber.BackColor = System.Drawing.Color.White;
            this.CallNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CallNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CallNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.CallNumber.Location = new System.Drawing.Point(38, 19);
            this.CallNumber.Name = "CallNumber";
            this.CallNumber.Size = new System.Drawing.Size(56, 16);
            this.CallNumber.TabIndex = 7;
            this.CallNumber.Text = "Number";
            this.CallNumber.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CallNumber_MouseClick);
            this.CallNumber.MouseEnter += new System.EventHandler(this.CallNumber_MouseEnter);
            this.CallNumber.MouseLeave += new System.EventHandler(this.CallNumber_MouseLeave);
            // 
            // typePicture
            // 
            this.typePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.typePicture.Location = new System.Drawing.Point(2, 3);
            this.typePicture.Margin = new System.Windows.Forms.Padding(0);
            this.typePicture.Name = "typePicture";
            this.typePicture.Size = new System.Drawing.Size(32, 32);
            this.typePicture.TabIndex = 1;
            this.typePicture.TabStop = false;
            this.typePicture.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainPabel_MouseDoubleClick);
            this.typePicture.MouseEnter += new System.EventHandler(this.RingMouseEnter);
            this.typePicture.MouseLeave += new System.EventHandler(this.RingMouseLeave);
            // 
            // Border
            // 
            this.Border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Border.Controls.Add(this.MainPabel);
            this.Border.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Border.Location = new System.Drawing.Point(0, 0);
            this.Border.Margin = new System.Windows.Forms.Padding(0);
            this.Border.Name = "Border";
            this.Border.Padding = new System.Windows.Forms.Padding(1);
            this.Border.Size = new System.Drawing.Size(310, 40);
            this.Border.TabIndex = 7;
            this.Border.MouseEnter += new System.EventHandler(this.RingMouseEnter);
            this.Border.MouseLeave += new System.EventHandler(this.RingMouseLeave);
            // 
            // ringCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.Border);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(315, 40);
            this.Name = "ringCard";
            this.Size = new System.Drawing.Size(310, 40);
            this.MouseEnter += new System.EventHandler(this.RingMouseEnter);
            this.MouseLeave += new System.EventHandler(this.RingMouseLeave);
            this.MainPabel.ResumeLayout(false);
            this.MainPabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typePicture)).EndInit();
            this.Border.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox typePicture;
        private System.Windows.Forms.Label ContactName;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.ImageList playImages;
        private System.Windows.Forms.ImageList typeImages;
        private System.Windows.Forms.Panel MainPabel;
        private System.Windows.Forms.Panel Border;
        private System.Windows.Forms.Label Details;
        private System.Windows.Forms.Label playButton;
        private System.Windows.Forms.Label AddButton;
        private System.Windows.Forms.Label CallNumber;
    }
}
