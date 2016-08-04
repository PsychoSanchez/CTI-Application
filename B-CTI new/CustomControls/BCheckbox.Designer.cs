namespace BCTI.CustomControls
{
    partial class BCheckbox
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
            this.CheckBoxText = new System.Windows.Forms.Label();
            this.CheckBoxPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // CheckBoxText
            // 
            this.CheckBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxText.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckBoxText.Location = new System.Drawing.Point(38, 3);
            this.CheckBoxText.Margin = new System.Windows.Forms.Padding(0);
            this.CheckBoxText.MinimumSize = new System.Drawing.Size(53, 26);
            this.CheckBoxText.Name = "CheckBoxText";
            this.CheckBoxText.Size = new System.Drawing.Size(86, 26);
            this.CheckBoxText.TabIndex = 0;
            this.CheckBoxText.Text = "label1";
            this.CheckBoxText.Click += new System.EventHandler(this.CheckBox_Click);
            this.CheckBoxText.MouseEnter += new System.EventHandler(this.CheckBoxPanel_MouseEnter);
            this.CheckBoxText.MouseLeave += new System.EventHandler(this.CheckBoxPanel_MouseLeave);
            // 
            // CheckBoxPanel
            // 
            this.CheckBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxPanel.BackColor = System.Drawing.SystemColors.Window;
            this.CheckBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CheckBoxPanel.Location = new System.Drawing.Point(0, 6);
            this.CheckBoxPanel.MaximumSize = new System.Drawing.Size(35, 15);
            this.CheckBoxPanel.MinimumSize = new System.Drawing.Size(35, 15);
            this.CheckBoxPanel.Name = "CheckBoxPanel";
            this.CheckBoxPanel.Size = new System.Drawing.Size(35, 15);
            this.CheckBoxPanel.TabIndex = 1;
            this.CheckBoxPanel.EnabledChanged += new System.EventHandler(this.BCheckbox_EnabledChanged);
            this.CheckBoxPanel.Click += new System.EventHandler(this.CheckBox_Click);
            this.CheckBoxPanel.MouseEnter += new System.EventHandler(this.CheckBoxPanel_MouseEnter);
            this.CheckBoxPanel.MouseLeave += new System.EventHandler(this.CheckBoxPanel_MouseLeave);
            // 
            // BCheckbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.CheckBoxPanel);
            this.Controls.Add(this.CheckBoxText);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(1000, 25);
            this.MinimumSize = new System.Drawing.Size(0, 22);
            this.Name = "BCheckbox";
            this.Size = new System.Drawing.Size(125, 22);
            this.Load += new System.EventHandler(this.BCheckbox_Load);
            this.EnabledChanged += new System.EventHandler(this.BCheckbox_EnabledChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CheckBoxText;
        private System.Windows.Forms.Panel CheckBoxPanel;
    }
}
