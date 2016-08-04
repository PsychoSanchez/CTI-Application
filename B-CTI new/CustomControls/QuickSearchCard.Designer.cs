namespace BCTI.CustomControls
{
    partial class QuickSearchCard
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
            this.FilterText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FilterText
            // 
            this.FilterText.AutoEllipsis = true;
            this.FilterText.BackColor = System.Drawing.Color.White;
            this.FilterText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FilterText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilterText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.FilterText.Location = new System.Drawing.Point(0, 0);
            this.FilterText.Name = "FilterText";
            this.FilterText.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.FilterText.Size = new System.Drawing.Size(215, 20);
            this.FilterText.TabIndex = 0;
            this.FilterText.Text = "Поисковой фильтр";
            this.FilterText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FilterText.Click += new System.EventHandler(this.label1_Click);
            this.FilterText.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.FilterText.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // QuickSearchCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.FilterText);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(215, 20);
            this.MinimumSize = new System.Drawing.Size(200, 20);
            this.Name = "QuickSearchCard";
            this.Size = new System.Drawing.Size(215, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label FilterText;
    }
}
