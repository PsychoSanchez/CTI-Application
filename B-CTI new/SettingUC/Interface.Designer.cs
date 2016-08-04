namespace BCTI.SettingUC
{
    partial class Interface
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
            this.Theme = new System.Windows.Forms.Label();
            this.TraySettings = new System.Windows.Forms.GroupBox();
            this.EnableTray = new BCTI.CustomControls.BCheckbox();
            this.MinimizeTray = new BCTI.CustomControls.BCheckbox();
            this.OneClickIcon = new BCTI.CustomControls.BCheckbox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.blfOnTop = new BCTI.CustomControls.BCheckbox();
            this.ThemeStyle = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TraySettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Theme
            // 
            this.Theme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Theme.Location = new System.Drawing.Point(6, 20);
            this.Theme.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Theme.Name = "Theme";
            this.Theme.Size = new System.Drawing.Size(170, 25);
            this.Theme.TabIndex = 0;
            this.Theme.Text = "Цветовая тема";
            this.Theme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Theme.Click += new System.EventHandler(this.Theme_Click);
            // 
            // TraySettings
            // 
            this.TraySettings.AutoSize = true;
            this.TraySettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TraySettings.Controls.Add(this.EnableTray);
            this.TraySettings.Controls.Add(this.MinimizeTray);
            this.TraySettings.Controls.Add(this.OneClickIcon);
            this.TraySettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.TraySettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TraySettings.Location = new System.Drawing.Point(0, 2);
            this.TraySettings.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.TraySettings.Name = "TraySettings";
            this.TraySettings.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.TraySettings.Size = new System.Drawing.Size(448, 114);
            this.TraySettings.TabIndex = 30;
            this.TraySettings.TabStop = false;
            this.TraySettings.Text = "Настройки трея";
            // 
            // EnableTray
            // 
            this.EnableTray.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnableTray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.EnableTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnableTray.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EnableTray.Location = new System.Drawing.Point(10, 20);
            this.EnableTray.Margin = new System.Windows.Forms.Padding(0);
            this.EnableTray.MaximumSize = new System.Drawing.Size(1000, 22);
            this.EnableTray.MinimumSize = new System.Drawing.Size(0, 22);
            this.EnableTray.Name = "EnableTray";
            this.EnableTray.Size = new System.Drawing.Size(435, 22);
            this.EnableTray.TabIndex = 32;
            // 
            // MinimizeTray
            // 
            this.MinimizeTray.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeTray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.MinimizeTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimizeTray.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimizeTray.Location = new System.Drawing.Point(10, 76);
            this.MinimizeTray.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeTray.MaximumSize = new System.Drawing.Size(1000, 22);
            this.MinimizeTray.MinimumSize = new System.Drawing.Size(0, 22);
            this.MinimizeTray.Name = "MinimizeTray";
            this.MinimizeTray.Size = new System.Drawing.Size(435, 22);
            this.MinimizeTray.TabIndex = 30;
            // 
            // OneClickIcon
            // 
            this.OneClickIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OneClickIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.OneClickIcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OneClickIcon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OneClickIcon.Location = new System.Drawing.Point(10, 48);
            this.OneClickIcon.Margin = new System.Windows.Forms.Padding(0);
            this.OneClickIcon.MaximumSize = new System.Drawing.Size(1000, 22);
            this.OneClickIcon.MinimumSize = new System.Drawing.Size(0, 22);
            this.OneClickIcon.Name = "OneClickIcon";
            this.OneClickIcon.Size = new System.Drawing.Size(435, 22);
            this.OneClickIcon.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.groupBox1.Controls.Add(this.blfOnTop);
            this.groupBox1.Controls.Add(this.Theme);
            this.groupBox1.Controls.Add(this.ThemeStyle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 88);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки Панели";
            // 
            // blfOnTop
            // 
            this.blfOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blfOnTop.AutoSize = true;
            this.blfOnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.blfOnTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.blfOnTop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.blfOnTop.Location = new System.Drawing.Point(10, 49);
            this.blfOnTop.Margin = new System.Windows.Forms.Padding(0);
            this.blfOnTop.MaximumSize = new System.Drawing.Size(1000, 22);
            this.blfOnTop.MinimumSize = new System.Drawing.Size(0, 22);
            this.blfOnTop.Name = "blfOnTop";
            this.blfOnTop.Size = new System.Drawing.Size(445, 22);
            this.blfOnTop.TabIndex = 3;
            // 
            // ThemeStyle
            // 
            this.ThemeStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.ThemeStyle.DisplayMember = "Светлая";
            this.ThemeStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ThemeStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThemeStyle.FormattingEnabled = true;
            this.ThemeStyle.Items.AddRange(new object[] {
            "Светлая"});
            this.ThemeStyle.Location = new System.Drawing.Point(182, 20);
            this.ThemeStyle.Margin = new System.Windows.Forms.Padding(2);
            this.ThemeStyle.Name = "ThemeStyle";
            this.ThemeStyle.Size = new System.Drawing.Size(263, 24);
            this.ThemeStyle.TabIndex = 2;
            this.ThemeStyle.ValueMember = "Светлая";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.panel2.Controls.Add(this.TraySettings);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 90);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel2.Size = new System.Drawing.Size(448, 116);
            this.panel2.TabIndex = 34;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel3.Size = new System.Drawing.Size(448, 90);
            this.panel3.TabIndex = 34;
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Interface";
            this.Size = new System.Drawing.Size(448, 288);
            this.TraySettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Theme;
        private System.Windows.Forms.GroupBox TraySettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CustomControls.BCheckbox blfOnTop;
        private CustomControls.BCheckbox EnableTray;
        private CustomControls.BCheckbox OneClickIcon;
        private CustomControls.BCheckbox MinimizeTray;
        private System.Windows.Forms.ComboBox ThemeStyle;
    }
}
