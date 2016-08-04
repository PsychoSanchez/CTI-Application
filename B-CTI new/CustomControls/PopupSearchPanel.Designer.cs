namespace BCTI.CustomControls
{
    partial class PopupSearchPanel
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
            this.QuickSearchPanel = new BCTI.CustomControls.BTableLayotPanel();
            this.SuspendLayout();
            // 
            // QuickSearchPanel
            // 
            this.QuickSearchPanel.AutoScroll = true;
            this.QuickSearchPanel.AutoSize = true;
            this.QuickSearchPanel.BackColor = System.Drawing.Color.White;
            this.QuickSearchPanel.ColumnCount = 1;
            this.QuickSearchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.QuickSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuickSearchPanel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuickSearchPanel.Location = new System.Drawing.Point(2, 1);
            this.QuickSearchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.QuickSearchPanel.Name = "QuickSearchPanel";
            this.QuickSearchPanel.RowCount = 1;
            this.QuickSearchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.QuickSearchPanel.Size = new System.Drawing.Size(214, 26);
            this.QuickSearchPanel.TabIndex = 0;
            // 
            // PopupSearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.Controls.Add(this.QuickSearchPanel);
            this.Name = "PopupSearchPanel";
            this.Padding = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.Size = new System.Drawing.Size(218, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BTableLayotPanel QuickSearchPanel;
    }
}
