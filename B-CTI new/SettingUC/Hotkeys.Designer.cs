namespace BCTI.SettingUC
{
    partial class Hotkeys
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
            this.DialHotkeyBox = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.UpdateLabel = new System.Windows.Forms.Label();
            this.DialHotkey = new System.Windows.Forms.TextBox();
            this.OpenBLfBeforeCall = new System.Windows.Forms.RadioButton();
            this.InstantCall = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DialHotkeyBox.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DialHotkeyBox
            // 
            this.DialHotkeyBox.AutoSize = true;
            this.DialHotkeyBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.DialHotkeyBox.Controls.Add(this.panel3);
            this.DialHotkeyBox.Controls.Add(this.DialHotkey);
            this.DialHotkeyBox.Controls.Add(this.OpenBLfBeforeCall);
            this.DialHotkeyBox.Controls.Add(this.InstantCall);
            this.DialHotkeyBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.DialHotkeyBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DialHotkeyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DialHotkeyBox.Location = new System.Drawing.Point(0, 2);
            this.DialHotkeyBox.Name = "DialHotkeyBox";
            this.DialHotkeyBox.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.DialHotkeyBox.Size = new System.Drawing.Size(372, 113);
            this.DialHotkeyBox.TabIndex = 0;
            this.DialHotkeyBox.TabStop = false;
            this.DialHotkeyBox.Text = "Dial Hotkey";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Controls.Add(this.UpdateLabel);
            this.panel3.Location = new System.Drawing.Point(5, 86);
            this.panel3.MinimumSize = new System.Drawing.Size(0, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 26);
            this.panel3.TabIndex = 33;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Right;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(303, 0);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 24);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // UpdateLabel
            // 
            this.UpdateLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.UpdateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateLabel.Location = new System.Drawing.Point(0, 0);
            this.UpdateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UpdateLabel.Name = "UpdateLabel";
            this.UpdateLabel.Size = new System.Drawing.Size(222, 26);
            this.UpdateLabel.TabIndex = 20;
            this.UpdateLabel.Text = "Время нажатия клавиш (мс)";
            this.UpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DialHotkey
            // 
            this.DialHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DialHotkey.BackColor = System.Drawing.Color.White;
            this.DialHotkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DialHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DialHotkey.Location = new System.Drawing.Point(9, 20);
            this.DialHotkey.Margin = new System.Windows.Forms.Padding(2);
            this.DialHotkey.Name = "DialHotkey";
            this.DialHotkey.ReadOnly = true;
            this.DialHotkey.Size = new System.Drawing.Size(356, 22);
            this.DialHotkey.TabIndex = 0;
            this.DialHotkey.Text = "Alt+C";
            this.DialHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DialHotkey_KeyDown);
            // 
            // OpenBLfBeforeCall
            // 
            this.OpenBLfBeforeCall.AutoSize = true;
            this.OpenBLfBeforeCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenBLfBeforeCall.Location = new System.Drawing.Point(9, 47);
            this.OpenBLfBeforeCall.Margin = new System.Windows.Forms.Padding(2);
            this.OpenBLfBeforeCall.Name = "OpenBLfBeforeCall";
            this.OpenBLfBeforeCall.Size = new System.Drawing.Size(263, 20);
            this.OpenBLfBeforeCall.TabIndex = 2;
            this.OpenBLfBeforeCall.Text = "Открыть блф панель перед звонком";
            this.OpenBLfBeforeCall.UseVisualStyleBackColor = true;
            this.OpenBLfBeforeCall.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // InstantCall
            // 
            this.InstantCall.AutoSize = true;
            this.InstantCall.Checked = true;
            this.InstantCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InstantCall.Location = new System.Drawing.Point(9, 67);
            this.InstantCall.Margin = new System.Windows.Forms.Padding(2);
            this.InstantCall.Name = "InstantCall";
            this.InstantCall.Size = new System.Drawing.Size(223, 20);
            this.InstantCall.TabIndex = 1;
            this.InstantCall.TabStop = true;
            this.InstantCall.Text = "Звонить сразу после нажатия";
            this.InstantCall.UseVisualStyleBackColor = true;
            this.InstantCall.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.DialHotkeyBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel1.Size = new System.Drawing.Size(372, 115);
            this.panel1.TabIndex = 3;
            // 
            // Hotkeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Hotkeys";
            this.Size = new System.Drawing.Size(372, 135);
            this.DialHotkeyBox.ResumeLayout(false);
            this.DialHotkeyBox.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox DialHotkeyBox;
        private System.Windows.Forms.TextBox DialHotkey;
        private System.Windows.Forms.RadioButton OpenBLfBeforeCall;
        private System.Windows.Forms.RadioButton InstantCall;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label UpdateLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
