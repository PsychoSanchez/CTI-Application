namespace BCTI.SettingUC
{
    partial class SavedData
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
            this.TraySettings = new System.Windows.Forms.GroupBox();
            this.PLayBackServFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ApachePass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateLabel = new System.Windows.Forms.Label();
            this.ApacheLogin = new System.Windows.Forms.TextBox();
            this.DeleteHistory = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AsteriskLogsDialog = new System.Windows.Forms.Label();
            this.PlaybackDialog = new System.Windows.Forms.Label();
            this.LogFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ReplayFolder = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TraySettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TraySettings
            // 
            this.TraySettings.AutoSize = true;
            this.TraySettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TraySettings.Controls.Add(this.PLayBackServFolder);
            this.TraySettings.Controls.Add(this.label4);
            this.TraySettings.Controls.Add(this.ApachePass);
            this.TraySettings.Controls.Add(this.label1);
            this.TraySettings.Controls.Add(this.UpdateLabel);
            this.TraySettings.Controls.Add(this.ApacheLogin);
            this.TraySettings.Controls.Add(this.DeleteHistory);
            this.TraySettings.Controls.Add(this.label2);
            this.TraySettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.TraySettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TraySettings.Location = new System.Drawing.Point(0, 2);
            this.TraySettings.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.TraySettings.Name = "TraySettings";
            this.TraySettings.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.TraySettings.Size = new System.Drawing.Size(435, 182);
            this.TraySettings.TabIndex = 31;
            this.TraySettings.TabStop = false;
            this.TraySettings.Text = "Данные разговоров";
            // 
            // PLayBackServFolder
            // 
            this.PLayBackServFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PLayBackServFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PLayBackServFolder.Location = new System.Drawing.Point(183, 77);
            this.PLayBackServFolder.MinimumSize = new System.Drawing.Size(164, 25);
            this.PLayBackServFolder.Name = "PLayBackServFolder";
            this.PLayBackServFolder.Size = new System.Drawing.Size(249, 24);
            this.PLayBackServFolder.TabIndex = 50;
            this.PLayBackServFolder.Leave += new System.EventHandler(this.PLayBackServFolder_Leave);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.MaximumSize = new System.Drawing.Size(170, 30);
            this.label4.MinimumSize = new System.Drawing.Size(100, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 25);
            this.label4.TabIndex = 49;
            this.label4.Text = "Папка на сервере";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.UseCompatibleTextRendering = true;
            // 
            // ApachePass
            // 
            this.ApachePass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApachePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApachePass.Location = new System.Drawing.Point(183, 48);
            this.ApachePass.MinimumSize = new System.Drawing.Size(164, 25);
            this.ApachePass.Name = "ApachePass";
            this.ApachePass.Size = new System.Drawing.Size(249, 24);
            this.ApachePass.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.MaximumSize = new System.Drawing.Size(170, 30);
            this.label1.MinimumSize = new System.Drawing.Size(100, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 47;
            this.label1.Text = "Apache Password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.UseCompatibleTextRendering = true;
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
            this.UpdateLabel.Size = new System.Drawing.Size(170, 25);
            this.UpdateLabel.TabIndex = 46;
            this.UpdateLabel.Text = "Apache Login";
            this.UpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateLabel.UseCompatibleTextRendering = true;
            // 
            // ApacheLogin
            // 
            this.ApacheLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApacheLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApacheLogin.Location = new System.Drawing.Point(183, 19);
            this.ApacheLogin.MinimumSize = new System.Drawing.Size(164, 25);
            this.ApacheLogin.Name = "ApacheLogin";
            this.ApacheLogin.Size = new System.Drawing.Size(249, 24);
            this.ApacheLogin.TabIndex = 45;
            // 
            // DeleteHistory
            // 
            this.DeleteHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.DeleteHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteHistory.ForeColor = System.Drawing.Color.White;
            this.DeleteHistory.Location = new System.Drawing.Point(5, 138);
            this.DeleteHistory.Name = "DeleteHistory";
            this.DeleteHistory.Size = new System.Drawing.Size(427, 28);
            this.DeleteHistory.TabIndex = 44;
            this.DeleteHistory.Text = "Удалить историю разговоров";
            this.DeleteHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DeleteHistory.Click += new System.EventHandler(this.DeleteHistory_Click);
            this.DeleteHistory.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.DeleteHistory.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(427, 28);
            this.label2.TabIndex = 43;
            this.label2.Text = "Удалить сохраненные записи разговоров";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.groupBox1.Controls.Add(this.AsteriskLogsDialog);
            this.groupBox1.Controls.Add(this.PlaybackDialog);
            this.groupBox1.Controls.Add(this.LogFolder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ReplayFolder);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 186);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.groupBox1.Size = new System.Drawing.Size(435, 92);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пути для сохранения файлов";
            // 
            // AsteriskLogsDialog
            // 
            this.AsteriskLogsDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AsteriskLogsDialog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.AsteriskLogsDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AsteriskLogsDialog.ForeColor = System.Drawing.Color.White;
            this.AsteriskLogsDialog.Location = new System.Drawing.Point(403, 49);
            this.AsteriskLogsDialog.Name = "AsteriskLogsDialog";
            this.AsteriskLogsDialog.Size = new System.Drawing.Size(29, 25);
            this.AsteriskLogsDialog.TabIndex = 50;
            this.AsteriskLogsDialog.Text = "...";
            this.AsteriskLogsDialog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AsteriskLogsDialog.Click += new System.EventHandler(this.AsteriskLogsDialog_Click);
            this.AsteriskLogsDialog.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.AsteriskLogsDialog.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // PlaybackDialog
            // 
            this.PlaybackDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaybackDialog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.PlaybackDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlaybackDialog.ForeColor = System.Drawing.Color.White;
            this.PlaybackDialog.Location = new System.Drawing.Point(403, 19);
            this.PlaybackDialog.Name = "PlaybackDialog";
            this.PlaybackDialog.Size = new System.Drawing.Size(29, 25);
            this.PlaybackDialog.TabIndex = 49;
            this.PlaybackDialog.Text = "...";
            this.PlaybackDialog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PlaybackDialog.Click += new System.EventHandler(this.PlaybackDialog_Click);
            this.PlaybackDialog.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.PlaybackDialog.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // LogFolder
            // 
            this.LogFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogFolder.Location = new System.Drawing.Point(183, 49);
            this.LogFolder.MinimumSize = new System.Drawing.Size(164, 25);
            this.LogFolder.Name = "LogFolder";
            this.LogFolder.Size = new System.Drawing.Size(220, 24);
            this.LogFolder.TabIndex = 48;
            this.LogFolder.TextChanged += new System.EventHandler(this.LogFolder_TextChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.MaximumSize = new System.Drawing.Size(170, 30);
            this.label3.MinimumSize = new System.Drawing.Size(100, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 25);
            this.label3.TabIndex = 47;
            this.label3.Text = "Логи астериск";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(8, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.MaximumSize = new System.Drawing.Size(170, 30);
            this.label5.MinimumSize = new System.Drawing.Size(100, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 25);
            this.label5.TabIndex = 46;
            this.label5.Text = "Записи разговоров";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.UseCompatibleTextRendering = true;
            // 
            // ReplayFolder
            // 
            this.ReplayFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplayFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReplayFolder.Location = new System.Drawing.Point(183, 19);
            this.ReplayFolder.MinimumSize = new System.Drawing.Size(164, 25);
            this.ReplayFolder.Name = "ReplayFolder";
            this.ReplayFolder.Size = new System.Drawing.Size(220, 24);
            this.ReplayFolder.TabIndex = 45;
            this.ReplayFolder.TextChanged += new System.EventHandler(this.ReplayFolder_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 2);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 2);
            this.panel1.TabIndex = 44;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 184);
            this.panel2.MaximumSize = new System.Drawing.Size(0, 2);
            this.panel2.MinimumSize = new System.Drawing.Size(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 2);
            this.panel2.TabIndex = 45;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 278);
            this.panel3.MaximumSize = new System.Drawing.Size(0, 2);
            this.panel3.MinimumSize = new System.Drawing.Size(0, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(435, 2);
            this.panel3.TabIndex = 45;
            // 
            // SavedData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TraySettings);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SavedData";
            this.Size = new System.Drawing.Size(435, 313);
            this.TraySettings.ResumeLayout(false);
            this.TraySettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox TraySettings;
        private System.Windows.Forms.Label DeleteHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ApacheLogin;
        private System.Windows.Forms.Label UpdateLabel;
        private System.Windows.Forms.TextBox ApachePass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox LogFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ReplayFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label PlaybackDialog;
        private System.Windows.Forms.Label AsteriskLogsDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PLayBackServFolder;
    }
}
