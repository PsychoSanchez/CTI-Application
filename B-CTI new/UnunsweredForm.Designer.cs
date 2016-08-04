namespace BCTI
{
    partial class UnunsweredForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnunsweredForm));
            this.headPanel = new System.Windows.Forms.Panel();
            this.headLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.headPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.headPanel.Controls.Add(this.headLabel);
            this.headPanel.Controls.Add(this.closeButton);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(171, 28);
            this.headPanel.TabIndex = 0;
            this.headPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // headLabel
            // 
            this.headLabel.AutoSize = true;
            this.headLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headLabel.Location = new System.Drawing.Point(4, 5);
            this.headLabel.Name = "headLabel";
            this.headLabel.Size = new System.Drawing.Size(116, 18);
            this.headLabel.TabIndex = 1;
            this.headLabel.Text = "Пропущенные";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.Location = new System.Drawing.Point(136, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // infoLabel
            // 
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoLabel.ForeColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.infoLabel.Location = new System.Drawing.Point(0, 31);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(171, 35);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "#MissedCalls";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.infoLabel.Click += new System.EventHandler(this.UnunsweredForm_Click);
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // UnunsweredForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(171, 68);
            this.ControlBox = false;
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.headPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnunsweredForm";
            this.Text = "UnunsweredForm";
            this.Click += new System.EventHandler(this.UnunsweredForm_Click);
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label headLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.ImageList closeButtonImage;
    }
}