namespace BCTI.SettingUC
{
    partial class Sound
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
            this.Ringtone = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Play = new System.Windows.Forms.Button();
            this.SoundSplash = new BCTI.CustomControls.BCheckbox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ringtone
            // 
            this.Ringtone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ringtone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Ringtone.Cursor = System.Windows.Forms.Cursors.Default;
            this.Ringtone.DisplayMember = "Ring01";
            this.Ringtone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Ringtone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ringtone.FormattingEnabled = true;
            this.Ringtone.Items.AddRange(new object[] {
            "Ring01",
            "Ring02",
            "Ring03",
            "Ring04",
            "Ring05",
            "Ring06",
            "Ring07",
            "Ring08",
            "Ring09",
            "Ring10"});
            this.Ringtone.Location = new System.Drawing.Point(106, 42);
            this.Ringtone.Margin = new System.Windows.Forms.Padding(2);
            this.Ringtone.Name = "Ringtone";
            this.Ringtone.Size = new System.Drawing.Size(261, 23);
            this.Ringtone.TabIndex = 1;
            this.Ringtone.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Звук звонка";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Play
            // 
            this.Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.Play.FlatAppearance.BorderSize = 0;
            this.Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Play.ForeColor = System.Drawing.Color.White;
            this.Play.Location = new System.Drawing.Point(371, 42);
            this.Play.Margin = new System.Windows.Forms.Padding(2);
            this.Play.MaximumSize = new System.Drawing.Size(80, 24);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(80, 24);
            this.Play.TabIndex = 3;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = false;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // SoundSplash
            // 
            this.SoundSplash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SoundSplash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.SoundSplash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SoundSplash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SoundSplash.Location = new System.Drawing.Point(8, 18);
            this.SoundSplash.Margin = new System.Windows.Forms.Padding(0);
            this.SoundSplash.MaximumSize = new System.Drawing.Size(1000, 24);
            this.SoundSplash.MinimumSize = new System.Drawing.Size(0, 22);
            this.SoundSplash.Name = "SoundSplash";
            this.SoundSplash.Size = new System.Drawing.Size(443, 24);
            this.SoundSplash.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Ringtone);
            this.groupBox1.Controls.Add(this.Play);
            this.groupBox1.Controls.Add(this.SoundSplash);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 85);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройка звуковых уведомлений";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel3.Size = new System.Drawing.Size(456, 87);
            this.panel3.TabIndex = 35;
            // 
            // Sound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Sound";
            this.Size = new System.Drawing.Size(456, 155);
            this.Load += new System.EventHandler(this.Sound_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox Ringtone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Play;
        private CustomControls.BCheckbox SoundSplash;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
    }
}
