namespace BCTI
{
    partial class Details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Details));
            this.detalisLabel = new System.Windows.Forms.Label();
            this.numberLabel2 = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.organisationLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.headPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.numberLabel = new System.Windows.Forms.Label();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.copyButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.listenButton = new System.Windows.Forms.Button();
            this.leftBorder = new System.Windows.Forms.Panel();
            this.rightBorder = new System.Windows.Forms.Panel();
            this.bottomBorder = new System.Windows.Forms.Panel();
            this.line = new System.Windows.Forms.Panel();
            this.avaBox = new System.Windows.Forms.Panel();
            this.ClientInfoPanel = new System.Windows.Forms.Panel();
            this.secondNumberLabel = new System.Windows.Forms.Label();
            this.headPanel.SuspendLayout();
            this.ClientInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // detalisLabel
            // 
            this.detalisLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.detalisLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detalisLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.detalisLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.detalisLabel.Location = new System.Drawing.Point(5, 145);
            this.detalisLabel.Name = "detalisLabel";
            this.detalisLabel.Size = new System.Drawing.Size(316, 96);
            this.detalisLabel.TabIndex = 66;
            this.detalisLabel.Text = "Входящий вызов\r\nНомер абонента: +1111111111\r\nВызов совершён: 00:00:00\r\nДлительнос" +
    "ть: 00:00:00\r\nПеревод: нет";
            this.detalisLabel.UseCompatibleTextRendering = true;
            // 
            // numberLabel2
            // 
            this.numberLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numberLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numberLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numberLabel2.Location = new System.Drawing.Point(111, 85);
            this.numberLabel2.Name = "numberLabel2";
            this.numberLabel2.Size = new System.Drawing.Size(72, 23);
            this.numberLabel2.TabIndex = 64;
            this.numberLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emailLabel
            // 
            this.emailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.emailLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.emailLabel.Location = new System.Drawing.Point(111, 58);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(142, 24);
            this.emailLabel.TabIndex = 63;
            this.emailLabel.Text = "Нет почты";
            this.emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // organisationLabel
            // 
            this.organisationLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.organisationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.organisationLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.organisationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.organisationLabel.Location = new System.Drawing.Point(111, 31);
            this.organisationLabel.Name = "organisationLabel";
            this.organisationLabel.Size = new System.Drawing.Size(142, 24);
            this.organisationLabel.TabIndex = 62;
            this.organisationLabel.Text = "Нет организации";
            this.organisationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel
            // 
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoLabel.Location = new System.Drawing.Point(110, 3);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(180, 17);
            this.infoLabel.TabIndex = 60;
            this.infoLabel.Text = "Неизвестный абонент";
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.headPanel.Controls.Add(this.closeButton);
            this.headPanel.Controls.Add(this.numberLabel);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(326, 28);
            this.headPanel.TabIndex = 58;
            this.headPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.BackgroundImage = global::BCTI.Properties.Resources.close1;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.closeButton.Location = new System.Drawing.Point(291, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 59;
            this.closeButton.TabStop = false;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // numberLabel
            // 
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numberLabel.Location = new System.Drawing.Point(3, 6);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(251, 17);
            this.numberLabel.TabIndex = 58;
            this.numberLabel.Text = "Детали вызова:";
            this.numberLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.numberLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.numberLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // copyButton
            // 
            this.copyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.copyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.copyButton.FlatAppearance.BorderSize = 0;
            this.copyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.copyButton.Image = global::BCTI.Properties.Resources.copy;
            this.copyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.copyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.copyButton.Location = new System.Drawing.Point(207, 244);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(114, 24);
            this.copyButton.TabIndex = 69;
            this.copyButton.Text = "Текст в буфер";
            this.copyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.copyButton.UseVisualStyleBackColor = false;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.downloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.downloadButton.FlatAppearance.BorderSize = 0;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downloadButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.downloadButton.Image = global::BCTI.Properties.Resources.download;
            this.downloadButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.downloadButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.downloadButton.Location = new System.Drawing.Point(105, 244);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(99, 24);
            this.downloadButton.TabIndex = 68;
            this.downloadButton.Text = "Скачать";
            this.downloadButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // listenButton
            // 
            this.listenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.listenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.listenButton.FlatAppearance.BorderSize = 0;
            this.listenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listenButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listenButton.Image = global::BCTI.Properties.Resources.play_small;
            this.listenButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.listenButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listenButton.Location = new System.Drawing.Point(5, 244);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(97, 24);
            this.listenButton.TabIndex = 67;
            this.listenButton.Text = "Слушать";
            this.listenButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.listenButton.UseVisualStyleBackColor = false;
            this.listenButton.Click += new System.EventHandler(this.listenButton_Click);
            // 
            // leftBorder
            // 
            this.leftBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.leftBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftBorder.Location = new System.Drawing.Point(0, 28);
            this.leftBorder.MaximumSize = new System.Drawing.Size(2, 0);
            this.leftBorder.Name = "leftBorder";
            this.leftBorder.Size = new System.Drawing.Size(2, 245);
            this.leftBorder.TabIndex = 70;
            // 
            // rightBorder
            // 
            this.rightBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.rightBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightBorder.Location = new System.Drawing.Point(324, 28);
            this.rightBorder.MaximumSize = new System.Drawing.Size(2, 0);
            this.rightBorder.Name = "rightBorder";
            this.rightBorder.Size = new System.Drawing.Size(2, 245);
            this.rightBorder.TabIndex = 71;
            // 
            // bottomBorder
            // 
            this.bottomBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.bottomBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomBorder.Location = new System.Drawing.Point(2, 271);
            this.bottomBorder.MaximumSize = new System.Drawing.Size(0, 2);
            this.bottomBorder.Name = "bottomBorder";
            this.bottomBorder.Size = new System.Drawing.Size(322, 2);
            this.bottomBorder.TabIndex = 72;
            // 
            // line
            // 
            this.line.BackgroundImage = global::BCTI.Properties.Resources.line;
            this.line.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.line.Location = new System.Drawing.Point(111, 23);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(201, 5);
            this.line.TabIndex = 73;
            // 
            // avaBox
            // 
            this.avaBox.BackgroundImage = global::BCTI.Properties.Resources.no_photo;
            this.avaBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avaBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.avaBox.Location = new System.Drawing.Point(3, 3);
            this.avaBox.Name = "avaBox";
            this.avaBox.Size = new System.Drawing.Size(105, 105);
            this.avaBox.TabIndex = 74;
            // 
            // ClientInfoPanel
            // 
            this.ClientInfoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientInfoPanel.Controls.Add(this.infoLabel);
            this.ClientInfoPanel.Controls.Add(this.organisationLabel);
            this.ClientInfoPanel.Controls.Add(this.emailLabel);
            this.ClientInfoPanel.Controls.Add(this.numberLabel2);
            this.ClientInfoPanel.Controls.Add(this.secondNumberLabel);
            this.ClientInfoPanel.Controls.Add(this.line);
            this.ClientInfoPanel.Controls.Add(this.avaBox);
            this.ClientInfoPanel.Location = new System.Drawing.Point(5, 31);
            this.ClientInfoPanel.Name = "ClientInfoPanel";
            this.ClientInfoPanel.Size = new System.Drawing.Size(316, 111);
            this.ClientInfoPanel.TabIndex = 75;
            // 
            // secondNumberLabel
            // 
            this.secondNumberLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.secondNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondNumberLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.secondNumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.secondNumberLabel.Location = new System.Drawing.Point(186, 85);
            this.secondNumberLabel.Name = "secondNumberLabel";
            this.secondNumberLabel.Size = new System.Drawing.Size(127, 23);
            this.secondNumberLabel.TabIndex = 65;
            this.secondNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(326, 273);
            this.ControlBox = false;
            this.Controls.Add(this.ClientInfoPanel);
            this.Controls.Add(this.bottomBorder);
            this.Controls.Add(this.rightBorder);
            this.Controls.Add(this.leftBorder);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.listenButton);
            this.Controls.Add(this.detalisLabel);
            this.Controls.Add(this.headPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Details_FormClosing);
            this.headPanel.ResumeLayout(false);
            this.ClientInfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button listenButton;
        private System.Windows.Forms.Label detalisLabel;
        private System.Windows.Forms.Label numberLabel2;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label organisationLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.ImageList closeButtonImage;
        private System.Windows.Forms.Panel leftBorder;
        private System.Windows.Forms.Panel rightBorder;
        private System.Windows.Forms.Panel bottomBorder;
        private System.Windows.Forms.Panel line;
        private System.Windows.Forms.Panel avaBox;
        private System.Windows.Forms.Panel ClientInfoPanel;
        private System.Windows.Forms.Label secondNumberLabel;
    }
}