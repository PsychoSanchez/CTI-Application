namespace BCTI.SettingUC
{
    partial class Integration
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.TraySettings = new System.Windows.Forms.GroupBox();
            this.CallerID = new System.Windows.Forms.Label();
            this.CallerIDlabel = new System.Windows.Forms.TextBox();
            this.UpdateLabel = new System.Windows.Forms.Label();
            this.Sipaddheader = new System.Windows.Forms.TextBox();
            this.CallToCheckBox = new BCTI.CustomControls.BCheckbox();
            this.TelCheckBox = new BCTI.CustomControls.BCheckbox();
            this.BasterToCheckBox = new BCTI.CustomControls.BCheckbox();
            this.panel2.SuspendLayout();
            this.TraySettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel2.Controls.Add(this.TraySettings);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel2.Size = new System.Drawing.Size(612, 153);
            this.panel2.TabIndex = 35;
            // 
            // TraySettings
            // 
            this.TraySettings.AutoSize = true;
            this.TraySettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))),((int)(((byte)(227)))));
            this.TraySettings.Controls.Add(this.BasterToCheckBox);
            this.TraySettings.Controls.Add(this.TelCheckBox);
            this.TraySettings.Controls.Add(this.CallerID);
            this.TraySettings.Controls.Add(this.CallerIDlabel);
            this.TraySettings.Controls.Add(this.UpdateLabel);
            this.TraySettings.Controls.Add(this.Sipaddheader);
            this.TraySettings.Controls.Add(this.CallToCheckBox);
            this.TraySettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.TraySettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TraySettings.Location = new System.Drawing.Point(0, 2);
            this.TraySettings.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.TraySettings.Name = "TraySettings";
            this.TraySettings.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.TraySettings.Size = new System.Drawing.Size(612, 151);
            this.TraySettings.TabIndex = 30;
            this.TraySettings.TabStop = false;
            this.TraySettings.Text = "Ассоциации файлов";
            // 
            // CallerID
            // 
            this.CallerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CallerID.Location = new System.Drawing.Point(4, 43);
            this.CallerID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CallerID.Name = "CallerID";
            this.CallerID.Size = new System.Drawing.Size(124, 22);
            this.CallerID.TabIndex = 23;
            this.CallerID.Text = "Caller ID";
            this.CallerID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CallerIDlabel
            // 
            this.CallerIDlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CallerIDlabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CallerIDlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CallerIDlabel.Location = new System.Drawing.Point(133, 43);
            this.CallerIDlabel.Name = "CallerIDlabel";
            this.CallerIDlabel.Size = new System.Drawing.Size(476, 22);
            this.CallerIDlabel.TabIndex = 24;
            this.CallerIDlabel.TextChanged += new System.EventHandler(this.CallerIDlabel_TextChanged);
            // 
            // UpdateLabel
            // 
            this.UpdateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateLabel.Location = new System.Drawing.Point(4, 17);
            this.UpdateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UpdateLabel.Name = "UpdateLabel";
            this.UpdateLabel.Size = new System.Drawing.Size(124, 22);
            this.UpdateLabel.TabIndex = 20;
            this.UpdateLabel.Text = "SIPADDHEADER ";
            this.UpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Sipaddheader
            // 
            this.Sipaddheader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Sipaddheader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Sipaddheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Sipaddheader.Location = new System.Drawing.Point(133, 17);
            this.Sipaddheader.Name = "Sipaddheader";
            this.Sipaddheader.Size = new System.Drawing.Size(476, 22);
            this.Sipaddheader.TabIndex = 21;
            this.Sipaddheader.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CallToCheckBox
            // 
            this.CallToCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CallToCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))),((int)(((byte)(227)))));
            this.CallToCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CallToCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CallToCheckBox.Location = new System.Drawing.Point(8, 69);
            this.CallToCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.CallToCheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.CallToCheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.CallToCheckBox.Name = "CallToCheckBox";
            this.CallToCheckBox.Size = new System.Drawing.Size(601, 22);
            this.CallToCheckBox.TabIndex = 22;
            // 
            // TelCheckBox
            // 
            this.TelCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TelCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))),((int)(((byte)(227)))));
            this.TelCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TelCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TelCheckBox.Location = new System.Drawing.Point(8, 91);
            this.TelCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.TelCheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.TelCheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.TelCheckBox.Name = "TelCheckBox";
            this.TelCheckBox.Size = new System.Drawing.Size(601, 22);
            this.TelCheckBox.TabIndex = 25;
            // 
            // BasterToCheckBox
            // 
            this.BasterToCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BasterToCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))),((int)(((byte)(227)))));
            this.BasterToCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BasterToCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BasterToCheckBox.Location = new System.Drawing.Point(8, 113);
            this.BasterToCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.BasterToCheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.BasterToCheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.BasterToCheckBox.Name = "BasterToCheckBox";
            this.BasterToCheckBox.Size = new System.Drawing.Size(601, 22);
            this.BasterToCheckBox.TabIndex = 26;
            // 
            // Integration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))),((int)(((byte)(227)))));
            this.Controls.Add(this.panel2);
            this.Name = "Integration";
            this.Size = new System.Drawing.Size(612, 150);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.TraySettings.ResumeLayout(false);
            this.TraySettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox TraySettings;
        private System.Windows.Forms.TextBox Sipaddheader;
        private System.Windows.Forms.Label UpdateLabel;
        private CustomControls.BCheckbox CallToCheckBox;
        private System.Windows.Forms.Label CallerID;
        private System.Windows.Forms.TextBox CallerIDlabel;
        private CustomControls.BCheckbox BasterToCheckBox;
        private CustomControls.BCheckbox TelCheckBox;
    }
}
