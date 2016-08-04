namespace BCTI.CustomControls
{
    partial class HiddenSplash
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
            this.components = new System.ComponentModel.Container();
            this.Hangup = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.TimeName = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.переводToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.удержаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скриптToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.конференцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Avatar = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Hangup
            // 
            this.Hangup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Hangup.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Hangup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Hangup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Hangup.ForeColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.Hangup.Location = new System.Drawing.Point(172, 2);
            this.Hangup.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Hangup.Name = "Hangup";
            this.Hangup.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Hangup.Size = new System.Drawing.Size(42, 26);
            this.Hangup.TabIndex = 1;
            this.Hangup.Text = "X";
            this.Hangup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Hangup.Click += new System.EventHandler(this.Hangup_Click);
            this.Hangup.MouseEnter += new System.EventHandler(this.Hangup_MouseEnter);
            this.Hangup.MouseLeave += new System.EventHandler(this.Hangup_MouseLeave);
            // 
            // Time
            // 
            this.Time.ForeColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.Time.Location = new System.Drawing.Point(83, 15);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(81, 13);
            this.Time.TabIndex = 2;
            this.Time.Text = "#timer";
            this.Time.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Time_MouseClick);
            this.Time.MouseEnter += new System.EventHandler(this.Time_MouseEnter);
            this.Time.MouseLeave += new System.EventHandler(this.Time_MouseLeave);
            // 
            // UserName
            // 
            this.UserName.AutoEllipsis = true;
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UserName.Location = new System.Drawing.Point(34, 0);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(130, 15);
            this.UserName.TabIndex = 3;
            this.UserName.Text = "Name";
            this.UserName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Time_MouseClick);
            this.UserName.MouseEnter += new System.EventHandler(this.Time_MouseEnter);
            this.UserName.MouseLeave += new System.EventHandler(this.Time_MouseLeave);
            // 
            // TimeName
            // 
            this.TimeName.AutoSize = true;
            this.TimeName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TimeName.Location = new System.Drawing.Point(34, 15);
            this.TimeName.Name = "TimeName";
            this.TimeName.Size = new System.Drawing.Size(43, 13);
            this.TimeName.TabIndex = 4;
            this.TimeName.Text = "Время:";
            this.TimeName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Time_MouseClick);
            this.TimeName.MouseEnter += new System.EventHandler(this.Time_MouseEnter);
            this.TimeName.MouseLeave += new System.EventHandler(this.Time_MouseLeave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переводToolStripMenuItem,
            this.удержаниеToolStripMenuItem,
            this.скриптToolStripMenuItem,
            this.конференцияToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 92);
            // 
            // переводToolStripMenuItem
            // 
            this.переводToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.переводToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.переводToolStripMenuItem.Name = "переводToolStripMenuItem";
            this.переводToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.переводToolStripMenuItem.Text = "Перевод";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // удержаниеToolStripMenuItem
            // 
            this.удержаниеToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.удержаниеToolStripMenuItem.Name = "удержаниеToolStripMenuItem";
            this.удержаниеToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.удержаниеToolStripMenuItem.Text = "Удержание";
            // 
            // скриптToolStripMenuItem
            // 
            this.скриптToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.скриптToolStripMenuItem.Name = "скриптToolStripMenuItem";
            this.скриптToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.скриптToolStripMenuItem.Text = "Скрипт";
            this.скриптToolStripMenuItem.Click += new System.EventHandler(this.скриптToolStripMenuItem_Click);
            // 
            // конференцияToolStripMenuItem
            // 
            this.конференцияToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.конференцияToolStripMenuItem.Name = "конференцияToolStripMenuItem";
            this.конференцияToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.конференцияToolStripMenuItem.Text = "Конференция";
            // 
            // Avatar
            // 
            this.Avatar.BackgroundImage = global::BCTI.Properties.Resources.outgoing;
            this.Avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Avatar.Location = new System.Drawing.Point(2, 2);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(26, 26);
            this.Avatar.TabIndex = 0;
            this.Avatar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Time_MouseClick);
            this.Avatar.MouseEnter += new System.EventHandler(this.Time_MouseEnter);
            this.Avatar.MouseLeave += new System.EventHandler(this.Time_MouseLeave);
            // 
            // HiddenSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Hangup);
            this.Controls.Add(this.TimeName);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.Avatar);
            this.Name = "HiddenSplash";
            this.Size = new System.Drawing.Size(217, 30);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Time_MouseClick);
            this.MouseEnter += new System.EventHandler(this.Time_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Time_MouseLeave);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Avatar;
        private System.Windows.Forms.Label Hangup;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label TimeName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem переводToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удержаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скриптToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem конференцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}
