namespace BCTI.SettingUC
{
    partial class PatternSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.TraySettings = new System.Windows.Forms.GroupBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.PatternPathLabel = new System.Windows.Forms.Label();
            this.PatternPath = new System.Windows.Forms.TextBox();
            this.PatternPAthFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.patternTableGroupBox = new System.Windows.Forms.GroupBox();
            this.addRow = new System.Windows.Forms.Button();
            this.patternTable = new BCTI.CustomControls.BTableLayotPanel();
            this.panel2.SuspendLayout();
            this.TraySettings.SuspendLayout();
            this.patternTableGroupBox.SuspendLayout();
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
            this.panel2.Size = new System.Drawing.Size(368, 86);
            this.panel2.TabIndex = 37;
            // 
            // TraySettings
            // 
            this.TraySettings.AutoSize = true;
            this.TraySettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TraySettings.Controls.Add(this.clearButton);
            this.TraySettings.Controls.Add(this.BrowseButton);
            this.TraySettings.Controls.Add(this.PatternPathLabel);
            this.TraySettings.Controls.Add(this.PatternPath);
            this.TraySettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.TraySettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TraySettings.Location = new System.Drawing.Point(0, 2);
            this.TraySettings.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.TraySettings.Name = "TraySettings";
            this.TraySettings.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.TraySettings.Size = new System.Drawing.Size(368, 84);
            this.TraySettings.TabIndex = 30;
            this.TraySettings.TabStop = false;
            this.TraySettings.Text = "Файл шаблона для номера";
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clearButton.Location = new System.Drawing.Point(259, 42);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(102, 23);
            this.clearButton.TabIndex = 23;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clearButton_MouseClick);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BrowseButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BrowseButton.Location = new System.Drawing.Point(226, 41);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(27, 23);
            this.BrowseButton.TabIndex = 22;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PatternPathLabel
            // 
            this.PatternPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PatternPathLabel.ForeColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.PatternPathLabel.Location = new System.Drawing.Point(4, 17);
            this.PatternPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PatternPathLabel.Name = "PatternPathLabel";
            this.PatternPathLabel.Size = new System.Drawing.Size(170, 22);
            this.PatternPathLabel.TabIndex = 20;
            this.PatternPathLabel.Text = "Путь к файлу шаблона";
            this.PatternPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PatternPath
            // 
            this.PatternPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatternPath.BackColor = System.Drawing.Color.White;
            this.PatternPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PatternPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PatternPath.Location = new System.Drawing.Point(7, 42);
            this.PatternPath.Name = "PatternPath";
            this.PatternPath.ReadOnly = true;
            this.PatternPath.Size = new System.Drawing.Size(213, 22);
            this.PatternPath.TabIndex = 21;
            // 
            // patternTableGroupBox
            // 
            this.patternTableGroupBox.AutoSize = true;
            this.patternTableGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.patternTableGroupBox.Controls.Add(this.addRow);
            this.patternTableGroupBox.Controls.Add(this.patternTable);
            this.patternTableGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patternTableGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.patternTableGroupBox.Location = new System.Drawing.Point(0, 86);
            this.patternTableGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.patternTableGroupBox.Name = "patternTableGroupBox";
            this.patternTableGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.patternTableGroupBox.Size = new System.Drawing.Size(368, 199);
            this.patternTableGroupBox.TabIndex = 38;
            this.patternTableGroupBox.TabStop = false;
            this.patternTableGroupBox.Text = "Таблица шаблонов";
            // 
            // addRow
            // 
            this.addRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.addRow.FlatAppearance.BorderSize = 0;
            this.addRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addRow.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addRow.Location = new System.Drawing.Point(226, 8);
            this.addRow.Name = "addRow";
            this.addRow.Size = new System.Drawing.Size(135, 23);
            this.addRow.TabIndex = 0;
            this.addRow.Text = "Добавить шаблон";
            this.addRow.UseVisualStyleBackColor = false;
            this.addRow.Click += new System.EventHandler(this.addRow_Click);
            // 
            // patternTable
            // 
            this.patternTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patternTable.AutoScroll = true;
            this.patternTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.patternTable.ColumnCount = 1;
            this.patternTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.patternTable.Location = new System.Drawing.Point(7, 34);
            this.patternTable.Margin = new System.Windows.Forms.Padding(0);
            this.patternTable.Name = "patternTable";
            this.patternTable.Padding = new System.Windows.Forms.Padding(25, 1, 1, 1);
            this.patternTable.RowCount = 1;
            this.patternTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.patternTable.Size = new System.Drawing.Size(354, 146);
            this.patternTable.TabIndex = 23;
            // 
            // PatternSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.patternTableGroupBox);
            this.Controls.Add(this.panel2);
            this.Name = "PatternSettings";
            this.Size = new System.Drawing.Size(368, 285);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.TraySettings.ResumeLayout(false);
            this.TraySettings.PerformLayout();
            this.patternTableGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox TraySettings;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Label PatternPathLabel;
        private System.Windows.Forms.TextBox PatternPath;
        private System.Windows.Forms.OpenFileDialog PatternPAthFileDialog;
        private System.Windows.Forms.GroupBox patternTableGroupBox;
        private CustomControls.BTableLayotPanel patternTable;
        private System.Windows.Forms.Button addRow;
        private System.Windows.Forms.Button clearButton;
    }
}
