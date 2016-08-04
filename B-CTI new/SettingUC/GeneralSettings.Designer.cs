namespace BCTI.SettingUC
{
    partial class GeneralSettings
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
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.UpdateLabel = new System.Windows.Forms.Label();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.CheckForUpdates = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CommonSettings = new System.Windows.Forms.GroupBox();
            this.StartWithWindows = new BCTI.CustomControls.BCheckbox();
            this.DoNotDisturb = new BCTI.CustomControls.BCheckbox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LastVersion = new System.Windows.Forms.Label();
            this.CurrentVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CommonSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguageComboBox.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LanguageComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Location = new System.Drawing.Point(182, 20);
            this.LanguageComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(412, 24);
            this.LanguageComboBox.TabIndex = 22;
            this.LanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_SelectedIndexChanged);
            // 
            // UpdateLabel
            // 
            this.UpdateLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.UpdateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateLabel.Location = new System.Drawing.Point(8, 19);
            this.UpdateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UpdateLabel.MaximumSize = new System.Drawing.Size(170, 30);
            this.UpdateLabel.MinimumSize = new System.Drawing.Size(100, 25);
            this.UpdateLabel.Name = "UpdateLabel";
            this.UpdateLabel.Size = new System.Drawing.Size(170, 28);
            this.UpdateLabel.TabIndex = 20;
            this.UpdateLabel.Text = "Обновления";
            this.UpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateLabel.UseCompatibleTextRendering = true;
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LanguageLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LanguageLabel.Location = new System.Drawing.Point(8, 19);
            this.LanguageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LanguageLabel.MaximumSize = new System.Drawing.Size(170, 28);
            this.LanguageLabel.MinimumSize = new System.Drawing.Size(170, 28);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(170, 28);
            this.LanguageLabel.TabIndex = 19;
            this.LanguageLabel.Text = "Язык";
            this.LanguageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LanguageLabel.UseCompatibleTextRendering = true;
            // 
            // CheckForUpdates
            // 
            this.CheckForUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckForUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.CheckForUpdates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckForUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckForUpdates.ForeColor = System.Drawing.Color.White;
            this.CheckForUpdates.Location = new System.Drawing.Point(183, 19);
            this.CheckForUpdates.Name = "CheckForUpdates";
            this.CheckForUpdates.Size = new System.Drawing.Size(411, 28);
            this.CheckForUpdates.TabIndex = 29;
            this.CheckForUpdates.Text = "Проверить обновления";
            this.CheckForUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckForUpdates.Click += new System.EventHandler(this.CheckForUpdates_Click);
            this.CheckForUpdates.MouseEnter += new System.EventHandler(this.CheckForUpdates_MouseEnter);
            this.CheckForUpdates.MouseLeave += new System.EventHandler(this.CheckForUpdates_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel1.Size = new System.Drawing.Size(597, 2);
            this.panel1.TabIndex = 35;
            // 
            // CommonSettings
            // 
            this.CommonSettings.AutoSize = true;
            this.CommonSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.CommonSettings.Controls.Add(this.StartWithWindows);
            this.CommonSettings.Controls.Add(this.DoNotDisturb);
            this.CommonSettings.Controls.Add(this.LanguageLabel);
            this.CommonSettings.Controls.Add(this.LanguageComboBox);
            this.CommonSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.CommonSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CommonSettings.Location = new System.Drawing.Point(0, 2);
            this.CommonSettings.Margin = new System.Windows.Forms.Padding(2, 3, 4, 2);
            this.CommonSettings.Name = "CommonSettings";
            this.CommonSettings.Padding = new System.Windows.Forms.Padding(2, 3, 4, 2);
            this.CommonSettings.Size = new System.Drawing.Size(597, 113);
            this.CommonSettings.TabIndex = 30;
            this.CommonSettings.TabStop = false;
            this.CommonSettings.Text = "Общие";
            // 
            // StartWithWindows
            // 
            this.StartWithWindows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartWithWindows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.StartWithWindows.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartWithWindows.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StartWithWindows.Location = new System.Drawing.Point(7, 75);
            this.StartWithWindows.Margin = new System.Windows.Forms.Padding(0);
            this.StartWithWindows.MaximumSize = new System.Drawing.Size(1000, 22);
            this.StartWithWindows.MinimumSize = new System.Drawing.Size(0, 22);
            this.StartWithWindows.Name = "StartWithWindows";
            this.StartWithWindows.Size = new System.Drawing.Size(586, 22);
            this.StartWithWindows.TabIndex = 31;
            this.StartWithWindows.Checked_Changed += new System.EventHandler(this.StartWithWindows_Checked_Changed);
            // 
            // DoNotDisturb
            // 
            this.DoNotDisturb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DoNotDisturb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.DoNotDisturb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DoNotDisturb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DoNotDisturb.Location = new System.Drawing.Point(8, 49);
            this.DoNotDisturb.Margin = new System.Windows.Forms.Padding(0);
            this.DoNotDisturb.MaximumSize = new System.Drawing.Size(1000, 22);
            this.DoNotDisturb.MinimumSize = new System.Drawing.Size(0, 22);
            this.DoNotDisturb.Name = "DoNotDisturb";
            this.DoNotDisturb.Size = new System.Drawing.Size(586, 22);
            this.DoNotDisturb.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 115);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel2.Size = new System.Drawing.Size(597, 2);
            this.panel2.TabIndex = 36;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.groupBox1.Controls.Add(this.LastVersion);
            this.groupBox1.Controls.Add(this.CurrentVersion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.UpdateLabel);
            this.groupBox1.Controls.Add(this.CheckForUpdates);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 117);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 4, 2);
            this.groupBox1.Size = new System.Drawing.Size(597, 119);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обновление";
            // 
            // LastVersion
            // 
            this.LastVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LastVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.LastVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastVersion.Location = new System.Drawing.Point(182, 75);
            this.LastVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LastVersion.Name = "LastVersion";
            this.LastVersion.Size = new System.Drawing.Size(412, 28);
            this.LastVersion.TabIndex = 33;
            this.LastVersion.Text = "#LastVersion";
            this.LastVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LastVersion.UseCompatibleTextRendering = true;
            // 
            // CurrentVersion
            // 
            this.CurrentVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.CurrentVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentVersion.Location = new System.Drawing.Point(182, 47);
            this.CurrentVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentVersion.Name = "CurrentVersion";
            this.CurrentVersion.Size = new System.Drawing.Size(412, 28);
            this.CurrentVersion.TabIndex = 32;
            this.CurrentVersion.Text = "#Version";
            this.CurrentVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CurrentVersion.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.MaximumSize = new System.Drawing.Size(170, 30);
            this.label2.MinimumSize = new System.Drawing.Size(100, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 28);
            this.label2.TabIndex = 31;
            this.label2.Text = "Последняя доступная";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.MaximumSize = new System.Drawing.Size(170, 30);
            this.label1.MinimumSize = new System.Drawing.Size(100, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 28);
            this.label1.TabIndex = 30;
            this.label1.Text = "Текущая версия:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.CommonSettings);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(294, 111);
            this.Name = "GeneralSettings";
            this.Size = new System.Drawing.Size(597, 341);
            this.Load += new System.EventHandler(this.GeneralSettings_Load);
            this.CommonSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.Label UpdateLabel;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.Label CheckForUpdates;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox CommonSettings;
        private CustomControls.BCheckbox DoNotDisturb;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LastVersion;
        private System.Windows.Forms.Label CurrentVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CustomControls.BCheckbox StartWithWindows;
    }
}
