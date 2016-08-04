namespace BCTI
{
    partial class BeforeSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeforeSplash));
            this.headPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.topSizer = new System.Windows.Forms.Panel();
            this.headLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.downResizer = new System.Windows.Forms.Panel();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.rightSizer = new System.Windows.Forms.Panel();
            this.leftSizer = new System.Windows.Forms.Panel();
            this.headPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.headPanel.Controls.Add(this.panel2);
            this.headPanel.Controls.Add(this.panel1);
            this.headPanel.Controls.Add(this.topSizer);
            this.headPanel.Controls.Add(this.headLabel);
            this.headPanel.Controls.Add(this.closeButton);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(209, 28);
            this.headPanel.TabIndex = 0;
            this.headPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(204, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 23);
            this.panel2.TabIndex = 4;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.panel2.MouseEnter += new System.EventHandler(this.rightSizer_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 23);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.panel1.MouseEnter += new System.EventHandler(this.rightSizer_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftSizer_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // topSizer
            // 
            this.topSizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.topSizer.Location = new System.Drawing.Point(0, 0);
            this.topSizer.Name = "topSizer";
            this.topSizer.Size = new System.Drawing.Size(209, 5);
            this.topSizer.TabIndex = 2;
            this.topSizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.topSizer.MouseEnter += new System.EventHandler(this.downResizer_MouseEnter);
            this.topSizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.topSizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topSizer_MouseMove);
            this.topSizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // headLabel
            // 
            this.headLabel.AutoSize = true;
            this.headLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headLabel.Location = new System.Drawing.Point(4, 5);
            this.headLabel.Name = "headLabel";
            this.headLabel.Size = new System.Drawing.Size(49, 16);
            this.headLabel.TabIndex = 1;
            this.headLabel.Text = "label1";
            this.headLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.SystemColors.Control;
            this.closeButton.Location = new System.Drawing.Point(174, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.button1_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            this.closeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BeforeSplash_MouseMove);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelButton.Location = new System.Drawing.Point(64, 61);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(130, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Отменить вызов";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            this.cancelButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BeforeSplash_MouseMove);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.Location = new System.Drawing.Point(64, 34);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(47, 17);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "label1";
            this.statusLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BeforeSplash_MouseMove);
            // 
            // avatar
            // 
            this.avatar.BackgroundImage = global::BCTI.Properties.Resources.no_photo;
            this.avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avatar.Location = new System.Drawing.Point(8, 34);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(50, 50);
            this.avatar.TabIndex = 1;
            this.avatar.TabStop = false;
            this.avatar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BeforeSplash_MouseMove);
            // 
            // downResizer
            // 
            this.downResizer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.downResizer.Location = new System.Drawing.Point(0, 90);
            this.downResizer.Name = "downResizer";
            this.downResizer.Size = new System.Drawing.Size(209, 5);
            this.downResizer.TabIndex = 4;
            this.downResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.downResizer.MouseEnter += new System.EventHandler(this.downResizer_MouseEnter);
            this.downResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.downResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.downResizer_MouseMove);
            this.downResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // rightSizer
            // 
            this.rightSizer.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightSizer.Location = new System.Drawing.Point(204, 28);
            this.rightSizer.Name = "rightSizer";
            this.rightSizer.Size = new System.Drawing.Size(5, 62);
            this.rightSizer.TabIndex = 5;
            this.rightSizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.rightSizer.MouseEnter += new System.EventHandler(this.rightSizer_MouseEnter);
            this.rightSizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.rightSizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseMove);
            this.rightSizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // leftSizer
            // 
            this.leftSizer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftSizer.Location = new System.Drawing.Point(0, 28);
            this.leftSizer.Name = "leftSizer";
            this.leftSizer.Size = new System.Drawing.Size(5, 62);
            this.leftSizer.TabIndex = 6;
            this.leftSizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.leftSizer.MouseEnter += new System.EventHandler(this.rightSizer_MouseEnter);
            this.leftSizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.leftSizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftSizer_MouseMove);
            this.leftSizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // BeforeSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(209, 95);
            this.ControlBox = false;
            this.Controls.Add(this.leftSizer);
            this.Controls.Add(this.rightSizer);
            this.Controls.Add(this.downResizer);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.avatar);
            this.Controls.Add(this.headPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BeforeSplash";
            this.Shown += new System.EventHandler(this.BeforeSplash_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeforeSplash_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BeforeSplash_MouseMove);
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label headLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.Panel downResizer;
        private System.Windows.Forms.ImageList closeButtonImage;
        private System.Windows.Forms.Panel topSizer;
        private System.Windows.Forms.Panel rightSizer;
        private System.Windows.Forms.Panel leftSizer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}