namespace BCTI
{
    partial class ImageCutter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageCutter));
            this.cutButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.avatarBox = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cutButton
            // 
            this.cutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cutButton.FlatAppearance.BorderSize = 0;
            this.cutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cutButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cutButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cutButton.Location = new System.Drawing.Point(0, 370);
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(185, 30);
            this.cutButton.TabIndex = 4;
            this.cutButton.Text = "Принять";
            this.cutButton.UseVisualStyleBackColor = false;
            this.cutButton.Click += new System.EventHandler(this.cutButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 28);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Аватар";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.Location = new System.Drawing.Point(305, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 1;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.exitButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
            // 
            // avatarBox
            // 
            this.avatarBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.avatarBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.avatarBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avatarBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.avatarBox.Location = new System.Drawing.Point(0, 29);
            this.avatarBox.MaximumSize = new System.Drawing.Size(1024, 768);
            this.avatarBox.MinimumSize = new System.Drawing.Size(100, 100);
            this.avatarBox.Name = "avatarBox";
            this.avatarBox.Size = new System.Drawing.Size(340, 340);
            this.avatarBox.TabIndex = 3;
            this.avatarBox.TabStop = false;
            this.avatarBox.Paint += new System.Windows.Forms.PaintEventHandler(this.avatarBox_Paint);
            this.avatarBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.avatarBox_MouseDown);
            this.avatarBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.avatarBox_MouseMove);
            this.avatarBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.avatarBox_MouseUp);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Coral;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelButton.Location = new System.Drawing.Point(185, 370);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(155, 30);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // ImageCutter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(340, 400);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.cutButton);
            this.Controls.Add(this.avatarBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1280, 1024);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "ImageCutter";
            this.Text = "ImageCutter";
            this.Load += new System.EventHandler(this.ImageCutter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cutButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox avatarBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ImageList closeButtonImage;
    }
}