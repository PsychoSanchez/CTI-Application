namespace BCTI
{
    partial class Preview
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
            this.ClientInfoPanel = new System.Windows.Forms.Panel();
            this.infoLabel = new System.Windows.Forms.Label();
            this.organisationLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.numberLabel2 = new System.Windows.Forms.Label();
            this.secondNumberLabel = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.Panel();
            this.avaBox = new System.Windows.Forms.Panel();
            this.ClientInfoPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.ClientInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientInfoPanel.Location = new System.Drawing.Point(2, 2);
            this.ClientInfoPanel.Name = "ClientInfoPanel";
            this.ClientInfoPanel.Size = new System.Drawing.Size(310, 114);
            this.ClientInfoPanel.TabIndex = 76;
            this.ClientInfoPanel.MouseEnter += new System.EventHandler(this.Preview_MouseEnter);
            // 
            // infoLabel
            // 
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoLabel.Location = new System.Drawing.Point(112, 3);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(195, 19);
            this.infoLabel.TabIndex = 60;
            this.infoLabel.Text = "Неизвестный абонент";
            this.infoLabel.MouseEnter += new System.EventHandler(this.Preview_MouseEnter);
            // 
            // organisationLabel
            // 
            this.organisationLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.organisationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.organisationLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.organisationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.organisationLabel.Location = new System.Drawing.Point(115, 34);
            this.organisationLabel.Name = "organisationLabel";
            this.organisationLabel.Size = new System.Drawing.Size(192, 22);
            this.organisationLabel.TabIndex = 62;
            this.organisationLabel.Text = "Нет организации";
            this.organisationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.organisationLabel.MouseEnter += new System.EventHandler(this.Preview_MouseEnter);
            // 
            // emailLabel
            // 
            this.emailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.emailLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.emailLabel.Location = new System.Drawing.Point(115, 61);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(192, 22);
            this.emailLabel.TabIndex = 63;
            this.emailLabel.Text = "Нет почты";
            this.emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.emailLabel.MouseEnter += new System.EventHandler(this.Preview_MouseEnter);
            // 
            // numberLabel2
            // 
            this.numberLabel2.AutoEllipsis = true;
            this.numberLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(255)))));
            this.numberLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numberLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numberLabel2.Location = new System.Drawing.Point(115, 88);
            this.numberLabel2.Name = "numberLabel2";
            this.numberLabel2.Size = new System.Drawing.Size(92, 22);
            this.numberLabel2.TabIndex = 64;
            this.numberLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numberLabel2.MouseEnter += new System.EventHandler(this.Preview_MouseEnter);
            // 
            // secondNumberLabel
            // 
            this.secondNumberLabel.AutoEllipsis = true;
            this.secondNumberLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(255)))));
            this.secondNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondNumberLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.secondNumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.secondNumberLabel.Location = new System.Drawing.Point(212, 88);
            this.secondNumberLabel.Name = "secondNumberLabel";
            this.secondNumberLabel.Size = new System.Drawing.Size(95, 22);
            this.secondNumberLabel.TabIndex = 65;
            this.secondNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.secondNumberLabel.MouseEnter += new System.EventHandler(this.Preview_MouseEnter);
            // 
            // line
            // 
            this.line.BackgroundImage = global::BCTI.Properties.Resources.line;
            this.line.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.line.Location = new System.Drawing.Point(114, 24);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(193, 5);
            this.line.TabIndex = 73;
            // 
            // avaBox
            // 
            this.avaBox.BackgroundImage = global::BCTI.Properties.Resources.no_photo;
            this.avaBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avaBox.Location = new System.Drawing.Point(5, 5);
            this.avaBox.Name = "avaBox";
            this.avaBox.Size = new System.Drawing.Size(105, 105);
            this.avaBox.TabIndex = 74;
            this.avaBox.MouseEnter += new System.EventHandler(this.Preview_MouseEnter);
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(314, 118);
            this.ControlBox = false;
            this.Controls.Add(this.ClientInfoPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(314, 118);
            this.MinimumSize = new System.Drawing.Size(310, 114);
            this.Name = "Preview";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Preview";
            this.MouseEnter += new System.EventHandler(this.Preview_MouseEnter);
            this.ClientInfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ClientInfoPanel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label organisationLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label numberLabel2;
        private System.Windows.Forms.Label secondNumberLabel;
        private System.Windows.Forms.Panel line;
        private System.Windows.Forms.Panel avaBox;
    }
}