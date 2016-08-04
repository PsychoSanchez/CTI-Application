namespace BCTI
{
    partial class ExcelFeature
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelFeature));
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.InfoLabel = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.rightResizer = new System.Windows.Forms.Panel();
            this.leftResizer = new System.Windows.Forms.Panel();
            this.bottomResizer = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ChooseFileButton = new System.Windows.Forms.Label();
            this.GoButton = new System.Windows.Forms.Label();
            this.AutoCall = new BCTI.CustomControls.BCheckbox();
            this.bTableLayotPanel1 = new BCTI.CustomControls.BTableLayotPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "openFileDialog1";
            this.FileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.Location = new System.Drawing.Point(361, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 1;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 28);
            this.panel1.TabIndex = 7;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Автодозвон";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoLabel.ForeColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.InfoLabel.Location = new System.Drawing.Point(6, 89);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(126, 16);
            this.InfoLabel.TabIndex = 8;
            this.InfoLabel.Text = "Очередь звонков:";
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.NextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextButton.FlatAppearance.BorderSize = 0;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NextButton.Location = new System.Drawing.Point(231, 85);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(162, 23);
            this.NextButton.TabIndex = 9;
            this.NextButton.Text = "Следующий звонок";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            this.NextButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.NextButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // rightResizer
            // 
            this.rightResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))),((int)(((byte)(227)))));
            this.rightResizer.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightResizer.Location = new System.Drawing.Point(399, 28);
            this.rightResizer.Name = "rightResizer";
            this.rightResizer.Size = new System.Drawing.Size(3, 216);
            this.rightResizer.TabIndex = 56;
            // 
            // leftResizer
            // 
            this.leftResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))),((int)(((byte)(227)))));
            this.leftResizer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftResizer.Location = new System.Drawing.Point(0, 28);
            this.leftResizer.Name = "leftResizer";
            this.leftResizer.Size = new System.Drawing.Size(3, 216);
            this.leftResizer.TabIndex = 55;
            // 
            // bottomResizer
            // 
            this.bottomResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))),((int)(((byte)(227)))));
            this.bottomResizer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomResizer.Location = new System.Drawing.Point(0, 244);
            this.bottomResizer.Name = "bottomResizer";
            this.bottomResizer.Size = new System.Drawing.Size(402, 3);
            this.bottomResizer.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 30);
            this.label2.TabIndex = 57;
            this.label2.Text = "Выберите Excel файл со списком контактов и нажмите \"Начать\"";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // ChooseFileButton
            // 
            this.ChooseFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ChooseFileButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ChooseFileButton.Location = new System.Drawing.Point(362, 34);
            this.ChooseFileButton.Name = "ChooseFileButton";
            this.ChooseFileButton.Size = new System.Drawing.Size(31, 22);
            this.ChooseFileButton.TabIndex = 58;
            this.ChooseFileButton.Text = "...";
            this.ChooseFileButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChooseFileButton.Click += new System.EventHandler(this.button1_Click);
            this.ChooseFileButton.MouseEnter += new System.EventHandler(this.ChooseFileButton_MouseEnter);
            this.ChooseFileButton.MouseLeave += new System.EventHandler(this.ChooseFileButton_MouseLeave);
            // 
            // GoButton
            // 
            this.GoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.GoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GoButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GoButton.Location = new System.Drawing.Point(318, 59);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(75, 23);
            this.GoButton.TabIndex = 59;
            this.GoButton.Text = "Начать";
            this.GoButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            this.GoButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.GoButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // AutoCall
            // 
            this.AutoCall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))),((int)(((byte)(227)))));
            this.AutoCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutoCall.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AutoCall.Location = new System.Drawing.Point(9, 60);
            this.AutoCall.Margin = new System.Windows.Forms.Padding(0);
            this.AutoCall.MaximumSize = new System.Drawing.Size(1000, 25);
            this.AutoCall.MinimumSize = new System.Drawing.Size(0, 22);
            this.AutoCall.Name = "AutoCall";
            this.AutoCall.Size = new System.Drawing.Size(306, 22);
            this.AutoCall.TabIndex = 10;
            this.AutoCall.Checked_Changed += new System.EventHandler(this.AutoCall_Checked_Changed);
            // 
            // bTableLayotPanel1
            // 
            this.bTableLayotPanel1.ColumnCount = 1;
            this.bTableLayotPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bTableLayotPanel1.Location = new System.Drawing.Point(9, 110);
            this.bTableLayotPanel1.Name = "bTableLayotPanel1";
            this.bTableLayotPanel1.RowCount = 1;
            this.bTableLayotPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bTableLayotPanel1.Size = new System.Drawing.Size(384, 128);
            this.bTableLayotPanel1.TabIndex = 60;
            // 
            // ExcelFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(402, 247);
            this.ControlBox = false;
            this.Controls.Add(this.bTableLayotPanel1);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.ChooseFileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rightResizer);
            this.Controls.Add(this.leftResizer);
            this.Controls.Add(this.bottomResizer);
            this.Controls.Add(this.AutoCall);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelFeature";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList closeButtonImage;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Button NextButton;
        private CustomControls.BCheckbox AutoCall;
        private System.Windows.Forms.Panel rightResizer;
        private System.Windows.Forms.Panel leftResizer;
        private System.Windows.Forms.Panel bottomResizer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ChooseFileButton;
        private System.Windows.Forms.Label GoButton;
        private CustomControls.BTableLayotPanel bTableLayotPanel1;
    }
}