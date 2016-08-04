namespace BCTI.SettingUC
{
    partial class Debug
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
            this.OpenLogMagazine = new System.Windows.Forms.Label();
            this.DeleteAmiLogsButton = new System.Windows.Forms.Label();
            this.TraySettings = new System.Windows.Forms.GroupBox();
            this.AmiLog = new BCTI.CustomControls.BCheckbox();
            this.LogFolderButton = new System.Windows.Forms.Label();
            this.DebuggingBox = new System.Windows.Forms.GroupBox();
            this.EventLog = new BCTI.CustomControls.BCheckbox();
            this.DeleteEventLog = new System.Windows.Forms.Label();
            this.OpenEventLog = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TraySettings.SuspendLayout();
            this.DebuggingBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenLogMagazine
            // 
            this.OpenLogMagazine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenLogMagazine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.OpenLogMagazine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenLogMagazine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenLogMagazine.ForeColor = System.Drawing.Color.White;
            this.OpenLogMagazine.Location = new System.Drawing.Point(6, 43);
            this.OpenLogMagazine.Name = "OpenLogMagazine";
            this.OpenLogMagazine.Size = new System.Drawing.Size(343, 28);
            this.OpenLogMagazine.TabIndex = 37;
            this.OpenLogMagazine.Text = "Журнал событий";
            this.OpenLogMagazine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OpenLogMagazine.Click += new System.EventHandler(this.OpenLogMagazine_Click);
            this.OpenLogMagazine.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.OpenLogMagazine.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // DeleteAmiLogsButton
            // 
            this.DeleteAmiLogsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.DeleteAmiLogsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteAmiLogsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteAmiLogsButton.ForeColor = System.Drawing.Color.White;
            this.DeleteAmiLogsButton.Location = new System.Drawing.Point(6, 41);
            this.DeleteAmiLogsButton.Name = "DeleteAmiLogsButton";
            this.DeleteAmiLogsButton.Size = new System.Drawing.Size(170, 28);
            this.DeleteAmiLogsButton.TabIndex = 38;
            this.DeleteAmiLogsButton.Text = "Удалить файлы логов";
            this.DeleteAmiLogsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DeleteAmiLogsButton.Click += new System.EventHandler(this.DeleteAmiLogsButton_Click);
            this.DeleteAmiLogsButton.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.DeleteAmiLogsButton.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // TraySettings
            // 
            this.TraySettings.AutoSize = true;
            this.TraySettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TraySettings.Controls.Add(this.AmiLog);
            this.TraySettings.Controls.Add(this.LogFolderButton);
            this.TraySettings.Controls.Add(this.DeleteAmiLogsButton);
            this.TraySettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.TraySettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TraySettings.Location = new System.Drawing.Point(0, 2);
            this.TraySettings.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.TraySettings.Name = "TraySettings";
            this.TraySettings.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.TraySettings.Size = new System.Drawing.Size(353, 85);
            this.TraySettings.TabIndex = 41;
            this.TraySettings.TabStop = false;
            this.TraySettings.Text = "Данные сервера Астериск";
            // 
            // AmiLog
            // 
            this.AmiLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AmiLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.AmiLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmiLog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AmiLog.Location = new System.Drawing.Point(6, 16);
            this.AmiLog.Margin = new System.Windows.Forms.Padding(0);
            this.AmiLog.MaximumSize = new System.Drawing.Size(1000, 22);
            this.AmiLog.MinimumSize = new System.Drawing.Size(0, 22);
            this.AmiLog.Name = "AmiLog";
            this.AmiLog.Size = new System.Drawing.Size(343, 22);
            this.AmiLog.TabIndex = 40;
            // 
            // LogFolderButton
            // 
            this.LogFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogFolderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.LogFolderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogFolderButton.ForeColor = System.Drawing.Color.White;
            this.LogFolderButton.Location = new System.Drawing.Point(179, 41);
            this.LogFolderButton.Name = "LogFolderButton";
            this.LogFolderButton.Size = new System.Drawing.Size(170, 28);
            this.LogFolderButton.TabIndex = 41;
            this.LogFolderButton.Text = "Показать в папке";
            this.LogFolderButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LogFolderButton.Click += new System.EventHandler(this.LogFolderButton_Click);
            this.LogFolderButton.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.LogFolderButton.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // DebuggingBox
            // 
            this.DebuggingBox.AutoSize = true;
            this.DebuggingBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.DebuggingBox.Controls.Add(this.EventLog);
            this.DebuggingBox.Controls.Add(this.DeleteEventLog);
            this.DebuggingBox.Controls.Add(this.OpenLogMagazine);
            this.DebuggingBox.Controls.Add(this.OpenEventLog);
            this.DebuggingBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.DebuggingBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DebuggingBox.Location = new System.Drawing.Point(0, 89);
            this.DebuggingBox.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.DebuggingBox.Name = "DebuggingBox";
            this.DebuggingBox.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.DebuggingBox.Size = new System.Drawing.Size(353, 118);
            this.DebuggingBox.TabIndex = 42;
            this.DebuggingBox.TabStop = false;
            this.DebuggingBox.Text = "Отладка приложения";
            // 
            // EventLog
            // 
            this.EventLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EventLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.EventLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EventLog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EventLog.Location = new System.Drawing.Point(6, 16);
            this.EventLog.Margin = new System.Windows.Forms.Padding(0);
            this.EventLog.MaximumSize = new System.Drawing.Size(1000, 22);
            this.EventLog.MinimumSize = new System.Drawing.Size(0, 22);
            this.EventLog.Name = "EventLog";
            this.EventLog.Size = new System.Drawing.Size(344, 22);
            this.EventLog.TabIndex = 39;
            // 
            // DeleteEventLog
            // 
            this.DeleteEventLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.DeleteEventLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteEventLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteEventLog.ForeColor = System.Drawing.Color.White;
            this.DeleteEventLog.Location = new System.Drawing.Point(6, 74);
            this.DeleteEventLog.Name = "DeleteEventLog";
            this.DeleteEventLog.Size = new System.Drawing.Size(170, 28);
            this.DeleteEventLog.TabIndex = 41;
            this.DeleteEventLog.Text = "Удалить файл логов";
            this.DeleteEventLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DeleteEventLog.Click += new System.EventHandler(this.DeleteEventLog_Click);
            this.DeleteEventLog.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.DeleteEventLog.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // OpenEventLog
            // 
            this.OpenEventLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenEventLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.OpenEventLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenEventLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenEventLog.ForeColor = System.Drawing.Color.White;
            this.OpenEventLog.Location = new System.Drawing.Point(179, 74);
            this.OpenEventLog.Name = "OpenEventLog";
            this.OpenEventLog.Size = new System.Drawing.Size(170, 28);
            this.OpenEventLog.TabIndex = 40;
            this.OpenEventLog.Text = "Открыть файл";
            this.OpenEventLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OpenEventLog.Click += new System.EventHandler(this.OpenEventLog_Click);
            this.OpenEventLog.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.OpenEventLog.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 207);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 2);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 2);
            this.panel1.TabIndex = 43;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 87);
            this.panel2.MaximumSize = new System.Drawing.Size(0, 2);
            this.panel2.MinimumSize = new System.Drawing.Size(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 2);
            this.panel2.TabIndex = 44;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.MaximumSize = new System.Drawing.Size(0, 2);
            this.panel3.MinimumSize = new System.Drawing.Size(0, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(353, 2);
            this.panel3.TabIndex = 45;
            // 
            // Debug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DebuggingBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TraySettings);
            this.Controls.Add(this.panel3);
            this.Name = "Debug";
            this.Size = new System.Drawing.Size(353, 309);
            this.TraySettings.ResumeLayout(false);
            this.DebuggingBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OpenLogMagazine;
        private System.Windows.Forms.Label DeleteAmiLogsButton;
        private CustomControls.BCheckbox AmiLog;
        private CustomControls.BCheckbox EventLog;
        private System.Windows.Forms.GroupBox TraySettings;
        private System.Windows.Forms.GroupBox DebuggingBox;
        private System.Windows.Forms.Label LogFolderButton;
        private System.Windows.Forms.Label OpenEventLog;
        private System.Windows.Forms.Label DeleteEventLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
