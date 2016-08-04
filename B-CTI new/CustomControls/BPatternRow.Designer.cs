namespace BCTI.CustomControls
{
    partial class BPatternRow
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
            this.prependTextBox = new System.Windows.Forms.TextBox();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.matchTextBox = new System.Windows.Forms.TextBox();
            this.buttonUp = new System.Windows.Forms.Panel();
            this.buttonDown = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prependTextBox
            // 
            this.prependTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.prependTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prependTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prependTextBox.Location = new System.Drawing.Point(3, 8);
            this.prependTextBox.Name = "prependTextBox";
            this.prependTextBox.Size = new System.Drawing.Size(100, 16);
            this.prependTextBox.TabIndex = 0;
            this.prependTextBox.TextChanged += new System.EventHandler(this.prependTextBox_TextChanged);
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.prefixTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.prefixTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prefixTextBox.Location = new System.Drawing.Point(109, 8);
            this.prefixTextBox.Name = "prefixTextBox";
            this.prefixTextBox.Size = new System.Drawing.Size(100, 16);
            this.prefixTextBox.TabIndex = 1;
            this.prefixTextBox.TextChanged += new System.EventHandler(this.prefixTextBox_TextChanged);
            // 
            // matchTextBox
            // 
            this.matchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.matchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matchTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.matchTextBox.Location = new System.Drawing.Point(215, 8);
            this.matchTextBox.Name = "matchTextBox";
            this.matchTextBox.Size = new System.Drawing.Size(100, 16);
            this.matchTextBox.TabIndex = 2;
            this.matchTextBox.TextChanged += new System.EventHandler(this.matchTextBox_TextChanged);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonUp.BackgroundImage = global::BCTI.Properties.Resources.up;
            this.buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUp.Location = new System.Drawing.Point(321, 11);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(10, 10);
            this.buttonUp.TabIndex = 11;
            this.buttonUp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonUp_MouseClick);
            this.buttonUp.MouseEnter += new System.EventHandler(this.buttonUp_MouseEnter);
            this.buttonUp.MouseLeave += new System.EventHandler(this.buttonUp_MouseLeave);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonDown.BackgroundImage = global::BCTI.Properties.Resources.down;
            this.buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDown.Location = new System.Drawing.Point(321, 23);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(10, 10);
            this.buttonDown.TabIndex = 12;
            this.buttonDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonDown_MouseClick);
            this.buttonDown.MouseEnter += new System.EventHandler(this.buttonDown_MouseEnter);
            this.buttonDown.MouseLeave += new System.EventHandler(this.buttonDown_MouseLeave);
            // 
            // deleteButton
            // 
            this.deleteButton.AutoSize = true;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.Location = new System.Drawing.Point(322, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(10, 9);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "X";
            this.deleteButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.deleteButton_MouseClick);
            this.deleteButton.MouseEnter += new System.EventHandler(this.deleteButton_MouseEnter);
            this.deleteButton.MouseLeave += new System.EventHandler(this.deleteButton_MouseLeave);
            // 
            // BPatternRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.matchTextBox);
            this.Controls.Add(this.prefixTextBox);
            this.Controls.Add(this.prependTextBox);
            this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.MinimumSize = new System.Drawing.Size(334, 33);
            this.Name = "BPatternRow";
            this.Size = new System.Drawing.Size(334, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox prependTextBox;
        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.TextBox matchTextBox;
        private System.Windows.Forms.Panel buttonUp;
        private System.Windows.Forms.Panel buttonDown;
        private System.Windows.Forms.Label deleteButton;
    }
}
