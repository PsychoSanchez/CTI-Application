namespace BCTI
{
    partial class DatesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatesForm));
            this.headPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.headLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.acceptDate = new System.Windows.Forms.Button();
            this.toDateBox = new System.Windows.Forms.DateTimePicker();
            this.fromDateBox = new System.Windows.Forms.DateTimePicker();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.headPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))),((int)(((byte)(227)))));
            this.headPanel.Controls.Add(this.closeButton);
            this.headPanel.Controls.Add(this.headLabel);
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(250, 28);
            this.headPanel.TabIndex = 53;
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
            this.closeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.closeButton.Location = new System.Drawing.Point(211, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 55;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // headLabel
            // 
            this.headLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.headLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.headLabel.Location = new System.Drawing.Point(3, 4);
            this.headLabel.Name = "headLabel";
            this.headLabel.Size = new System.Drawing.Size(78, 18);
            this.headLabel.TabIndex = 54;
            this.headLabel.Text = "Интервал";
            this.headLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toLabel.Location = new System.Drawing.Point(16, 81);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(25, 16);
            this.toLabel.TabIndex = 52;
            this.toLabel.Text = "По";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fromLabel.Location = new System.Drawing.Point(16, 54);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(18, 16);
            this.fromLabel.TabIndex = 51;
            this.fromLabel.Text = "С";
            // 
            // acceptDate
            // 
            this.acceptDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(171)))), ((int)(((byte)(57)))));
            this.acceptDate.FlatAppearance.BorderSize = 0;
            this.acceptDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceptDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.acceptDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.acceptDate.Location = new System.Drawing.Point(80, 124);
            this.acceptDate.Name = "acceptDate";
            this.acceptDate.Size = new System.Drawing.Size(90, 23);
            this.acceptDate.TabIndex = 50;
            this.acceptDate.Text = "Принять";
            this.acceptDate.UseVisualStyleBackColor = false;
            this.acceptDate.Click += new System.EventHandler(this.acceptDate_Click);
            // 
            // toDateBox
            // 
            this.toDateBox.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.toDateBox.Location = new System.Drawing.Point(47, 78);
            this.toDateBox.Name = "toDateBox";
            this.toDateBox.Size = new System.Drawing.Size(186, 21);
            this.toDateBox.TabIndex = 49;
            // 
            // fromDateBox
            // 
            this.fromDateBox.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.fromDateBox.Location = new System.Drawing.Point(48, 51);
            this.fromDateBox.Name = "fromDateBox";
            this.fromDateBox.Size = new System.Drawing.Size(185, 21);
            this.fromDateBox.TabIndex = 48;
            this.fromDateBox.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // DatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 172);
            this.ControlBox = false;
            this.Controls.Add(this.headPanel);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.acceptDate);
            this.Controls.Add(this.toDateBox);
            this.Controls.Add(this.fromDateBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(250, 172);
            this.MinimumSize = new System.Drawing.Size(250, 172);
            this.Name = "DatesForm";
            this.headPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label headLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Button acceptDate;
        private System.Windows.Forms.DateTimePicker toDateBox;
        private System.Windows.Forms.DateTimePicker fromDateBox;
        private System.Windows.Forms.ImageList closeButtonImage;
    }
}