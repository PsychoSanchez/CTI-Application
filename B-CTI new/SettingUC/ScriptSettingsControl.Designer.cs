namespace BCTI.SettingUC
{
    partial class ScriptSettingsControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ParamsGroupBox = new System.Windows.Forms.GroupBox();
            this.DestinationCheckBox = new BCTI.CustomControls.BCheckbox();
            this.DialStatusCheckBox = new BCTI.CustomControls.BCheckbox();
            this.UniqueidCheckBox = new BCTI.CustomControls.BCheckbox();
            this.Uniqueid2CheckBox = new BCTI.CustomControls.BCheckbox();
            this.CurrentStatusCheckBox = new BCTI.CustomControls.BCheckbox();
            this.ChannelCheckBox = new BCTI.CustomControls.BCheckbox();
            this.ConnectedLineNameCheckBox = new BCTI.CustomControls.BCheckbox();
            this.ConnectedLineNumCheckBox = new BCTI.CustomControls.BCheckbox();
            this.CallerIDNameCheckBox = new BCTI.CustomControls.BCheckbox();
            this.CallerIDNumCheckBox = new BCTI.CustomControls.BCheckbox();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.ParamsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel1.Controls.Add(this.ParamsGroupBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel1.Size = new System.Drawing.Size(319, 256);
            this.panel1.TabIndex = 1;
            // 
            // ParamsGroupBox
            // 
            this.ParamsGroupBox.AutoSize = true;
            this.ParamsGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.ParamsGroupBox.Controls.Add(this.DestinationCheckBox);
            this.ParamsGroupBox.Controls.Add(this.DialStatusCheckBox);
            this.ParamsGroupBox.Controls.Add(this.UniqueidCheckBox);
            this.ParamsGroupBox.Controls.Add(this.Uniqueid2CheckBox);
            this.ParamsGroupBox.Controls.Add(this.CurrentStatusCheckBox);
            this.ParamsGroupBox.Controls.Add(this.ChannelCheckBox);
            this.ParamsGroupBox.Controls.Add(this.ConnectedLineNameCheckBox);
            this.ParamsGroupBox.Controls.Add(this.ConnectedLineNumCheckBox);
            this.ParamsGroupBox.Controls.Add(this.CallerIDNameCheckBox);
            this.ParamsGroupBox.Controls.Add(this.CallerIDNumCheckBox);
            this.ParamsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ParamsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParamsGroupBox.Location = new System.Drawing.Point(0, 2);
            this.ParamsGroupBox.Name = "ParamsGroupBox";
            this.ParamsGroupBox.Size = new System.Drawing.Size(319, 254);
            this.ParamsGroupBox.TabIndex = 1;
            this.ParamsGroupBox.TabStop = false;
            this.ParamsGroupBox.Text = "Параметры звонка";
            // 
            // DestinationCheckBox
            // 
            this.DestinationCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.DestinationCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DestinationCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DestinationCheckBox.Location = new System.Drawing.Point(6, 151);
            this.DestinationCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.DestinationCheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.DestinationCheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.DestinationCheckBox.Name = "DestinationCheckBox";
            this.DestinationCheckBox.Size = new System.Drawing.Size(300, 22);
            this.DestinationCheckBox.TabIndex = 9;
            this.DestinationCheckBox.Checked_Changed += new System.EventHandler(this.UniqueidCheckBox_Checked_Changed);
            // 
            // DialStatusCheckBox
            // 
            this.DialStatusCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DialStatusCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.DialStatusCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DialStatusCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DialStatusCheckBox.Location = new System.Drawing.Point(6, 173);
            this.DialStatusCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.DialStatusCheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.DialStatusCheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.DialStatusCheckBox.Name = "DialStatusCheckBox";
            this.DialStatusCheckBox.Size = new System.Drawing.Size(300, 22);
            this.DialStatusCheckBox.TabIndex = 8;
            this.DialStatusCheckBox.Checked_Changed += new System.EventHandler(this.UniqueidCheckBox_Checked_Changed);
            // 
            // UniqueidCheckBox
            // 
            this.UniqueidCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UniqueidCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.UniqueidCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UniqueidCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UniqueidCheckBox.Location = new System.Drawing.Point(6, 193);
            this.UniqueidCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.UniqueidCheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.UniqueidCheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.UniqueidCheckBox.Name = "UniqueidCheckBox";
            this.UniqueidCheckBox.Size = new System.Drawing.Size(300, 22);
            this.UniqueidCheckBox.TabIndex = 7;
            this.UniqueidCheckBox.Checked_Changed += new System.EventHandler(this.UniqueidCheckBox_Checked_Changed);
            // 
            // Uniqueid2CheckBox
            // 
            this.Uniqueid2CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Uniqueid2CheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Uniqueid2CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Uniqueid2CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Uniqueid2CheckBox.Location = new System.Drawing.Point(6, 215);
            this.Uniqueid2CheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.Uniqueid2CheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.Uniqueid2CheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.Uniqueid2CheckBox.Name = "Uniqueid2CheckBox";
            this.Uniqueid2CheckBox.Size = new System.Drawing.Size(300, 22);
            this.Uniqueid2CheckBox.TabIndex = 6;
            this.Uniqueid2CheckBox.Checked_Changed += new System.EventHandler(this.UniqueidCheckBox_Checked_Changed);
            // 
            // CurrentStatusCheckBox
            // 
            this.CurrentStatusCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentStatusCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.CurrentStatusCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentStatusCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CurrentStatusCheckBox.Location = new System.Drawing.Point(6, 129);
            this.CurrentStatusCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.CurrentStatusCheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.CurrentStatusCheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.CurrentStatusCheckBox.Name = "CurrentStatusCheckBox";
            this.CurrentStatusCheckBox.Size = new System.Drawing.Size(300, 22);
            this.CurrentStatusCheckBox.TabIndex = 5;
            this.CurrentStatusCheckBox.Checked_Changed += new System.EventHandler(this.UniqueidCheckBox_Checked_Changed);
            // 
            // ChannelCheckBox
            // 
            this.ChannelCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChannelCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.ChannelCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChannelCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChannelCheckBox.Location = new System.Drawing.Point(6, 107);
            this.ChannelCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.ChannelCheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.ChannelCheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.ChannelCheckBox.Name = "ChannelCheckBox";
            this.ChannelCheckBox.Size = new System.Drawing.Size(300, 22);
            this.ChannelCheckBox.TabIndex = 4;
            this.ChannelCheckBox.Checked_Changed += new System.EventHandler(this.UniqueidCheckBox_Checked_Changed);
            // 
            // ConnectedLineNameCheckBox
            // 
            this.ConnectedLineNameCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectedLineNameCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.ConnectedLineNameCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConnectedLineNameCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ConnectedLineNameCheckBox.Location = new System.Drawing.Point(6, 85);
            this.ConnectedLineNameCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.ConnectedLineNameCheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.ConnectedLineNameCheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.ConnectedLineNameCheckBox.Name = "ConnectedLineNameCheckBox";
            this.ConnectedLineNameCheckBox.Size = new System.Drawing.Size(300, 22);
            this.ConnectedLineNameCheckBox.TabIndex = 3;
            this.ConnectedLineNameCheckBox.Checked_Changed += new System.EventHandler(this.UniqueidCheckBox_Checked_Changed);
            // 
            // ConnectedLineNumCheckBox
            // 
            this.ConnectedLineNumCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectedLineNumCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.ConnectedLineNumCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConnectedLineNumCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ConnectedLineNumCheckBox.Location = new System.Drawing.Point(6, 63);
            this.ConnectedLineNumCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.ConnectedLineNumCheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.ConnectedLineNumCheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.ConnectedLineNumCheckBox.Name = "ConnectedLineNumCheckBox";
            this.ConnectedLineNumCheckBox.Size = new System.Drawing.Size(300, 22);
            this.ConnectedLineNumCheckBox.TabIndex = 2;
            this.ConnectedLineNumCheckBox.Checked_Changed += new System.EventHandler(this.UniqueidCheckBox_Checked_Changed);
            // 
            // CallerIDNameCheckBox
            // 
            this.CallerIDNameCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CallerIDNameCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.CallerIDNameCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CallerIDNameCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CallerIDNameCheckBox.Location = new System.Drawing.Point(6, 41);
            this.CallerIDNameCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.CallerIDNameCheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.CallerIDNameCheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.CallerIDNameCheckBox.Name = "CallerIDNameCheckBox";
            this.CallerIDNameCheckBox.Size = new System.Drawing.Size(300, 22);
            this.CallerIDNameCheckBox.TabIndex = 1;
            this.CallerIDNameCheckBox.Checked_Changed += new System.EventHandler(this.UniqueidCheckBox_Checked_Changed);
            // 
            // CallerIDNumCheckBox
            // 
            this.CallerIDNumCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CallerIDNumCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.CallerIDNumCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CallerIDNumCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CallerIDNumCheckBox.Location = new System.Drawing.Point(6, 19);
            this.CallerIDNumCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.CallerIDNumCheckBox.MaximumSize = new System.Drawing.Size(1000, 25);
            this.CallerIDNumCheckBox.MinimumSize = new System.Drawing.Size(0, 22);
            this.CallerIDNumCheckBox.Name = "CallerIDNumCheckBox";
            this.CallerIDNumCheckBox.Size = new System.Drawing.Size(300, 22);
            this.CallerIDNumCheckBox.TabIndex = 0;
            this.CallerIDNumCheckBox.Checked_Changed += new System.EventHandler(this.UniqueidCheckBox_Checked_Changed);
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(283, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(9, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(268, 22);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.groupBox1.Size = new System.Drawing.Size(319, 62);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Путь к файлу";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel2.Size = new System.Drawing.Size(319, 64);
            this.panel2.TabIndex = 33;
            // 
            // ScriptSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ScriptSettingsControl";
            this.Size = new System.Drawing.Size(319, 310);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ParamsGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomControls.BCheckbox CallerIDNumCheckBox;
        private CustomControls.BCheckbox CallerIDNameCheckBox;
        private CustomControls.BCheckbox ConnectedLineNumCheckBox;
        private CustomControls.BCheckbox ConnectedLineNameCheckBox;
        private CustomControls.BCheckbox ChannelCheckBox;
        private CustomControls.BCheckbox CurrentStatusCheckBox;
        private CustomControls.BCheckbox Uniqueid2CheckBox;
        private CustomControls.BCheckbox UniqueidCheckBox;
        private CustomControls.BCheckbox DialStatusCheckBox;
        private CustomControls.BCheckbox DestinationCheckBox;
        private System.Windows.Forms.GroupBox ParamsGroupBox;
        private System.Windows.Forms.Panel panel2;
    }
}
