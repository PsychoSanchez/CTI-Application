namespace BCTI
{
    partial class HistoryCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryCard));
            this.label1 = new System.Windows.Forms.Label();
            this.detailsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.playImages = new System.Windows.Forms.ImageList(this.components);
            this.typeImages = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.playButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.typePicture = new System.Windows.Forms.PictureBox();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(120, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Неизвестно";
            // 
            // detailsButton
            // 
            this.detailsButton.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.detailsButton.FlatAppearance.BorderSize = 0;
            this.detailsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detailsButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailsButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.detailsButton.Location = new System.Drawing.Point(149, 49);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(56, 30);
            this.detailsButton.TabIndex = 4;
            this.detailsButton.Text = "Детали";
            this.detailsButton.UseVisualStyleBackColor = false;
            this.detailsButton.Click += new System.EventHandler(this.detailsButton_Click);
            this.detailsButton.MouseEnter += new System.EventHandler(this.detailsButton_MouseEnter);
            this.detailsButton.MouseLeave += new System.EventHandler(this.detailsButton_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(120, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
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
            // panel1
            // 
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Controls.Add(this.detailsButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 82);
            this.panel1.TabIndex = 7;
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.playButton.BackgroundImage = global::BCTI.Properties.Resources.play_small;
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Location = new System.Drawing.Point(211, 49);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(56, 30);
            this.playButton.TabIndex = 5;
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.MouseEnter += new System.EventHandler(this.detailsButton_MouseEnter);
            this.playButton.MouseLeave += new System.EventHandler(this.detailsButton_MouseLeave);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addButton.Location = new System.Drawing.Point(87, 49);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(56, 30);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            this.addButton.MouseEnter += new System.EventHandler(this.detailsButton_MouseEnter);
            this.addButton.MouseLeave += new System.EventHandler(this.detailsButton_MouseLeave);
            // 
            // typePicture
            // 
            this.typePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.typePicture.Location = new System.Drawing.Point(84, 7);
            this.typePicture.Name = "typePicture";
            this.typePicture.Size = new System.Drawing.Size(30, 30);
            this.typePicture.TabIndex = 1;
            this.typePicture.TabStop = false;
            // 
            // avatar
            // 
            this.avatar.BackgroundImage = global::BCTI.Properties.Resources.no_photo;
            this.avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.avatar.Location = new System.Drawing.Point(3, 7);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(75, 72);
            this.avatar.TabIndex = 0;
            this.avatar.TabStop = false;
            // 
            // HistoryCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typePicture);
            this.Controls.Add(this.avatar);
            this.Controls.Add(this.panel1);
            this.Name = "HistoryCard";
            this.Size = new System.Drawing.Size(271, 82);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.typePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.PictureBox typePicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button detailsButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList playImages;
        private System.Windows.Forms.ImageList typeImages;
        private System.Windows.Forms.Panel panel1;
    }
}
