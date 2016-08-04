namespace BCTI
{
    partial class History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headPanel = new System.Windows.Forms.Panel();
            this.topResizer = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.headLabel = new System.Windows.Forms.Label();
            this.day2Button = new System.Windows.Forms.Button();
            this.day3Button = new System.Windows.Forms.Button();
            this.day7Button = new System.Windows.Forms.Button();
            this.arrowButton = new System.Windows.Forms.Button();
            this.todayButton = new System.Windows.Forms.Button();
            this.incomingButton = new System.Windows.Forms.Button();
            this.outcomingButton = new System.Windows.Forms.Button();
            this.unUnsweredButton = new System.Windows.Forms.Button();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.downResizer = new System.Windows.Forms.Panel();
            this.searchPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Loading = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.RingsTable = new BCTI.CustomControls.BTableLayotPanel();
            this.headPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchPictureBox)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(3, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 23);
            this.label5.TabIndex = 58;
            this.label5.Text = "Когда:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(2, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 57;
            this.label4.Text = "От кого / кому:";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "";
            this.columnHeader17.Width = 261;
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.headPanel.Controls.Add(this.topResizer);
            this.headPanel.Controls.Add(this.closeButton);
            this.headPanel.Controls.Add(this.headLabel);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(319, 28);
            this.headPanel.TabIndex = 56;
            this.headPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // topResizer
            // 
            this.topResizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.topResizer.Location = new System.Drawing.Point(0, 0);
            this.topResizer.Name = "topResizer";
            this.topResizer.Size = new System.Drawing.Size(319, 5);
            this.topResizer.TabIndex = 56;
            this.topResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.topResizer.MouseEnter += new System.EventHandler(this.downResizer_MouseEnter);
            this.topResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.topResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topSizer_MouseMove);
            this.topResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.closeButton.Location = new System.Drawing.Point(284, 5);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 55;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // headLabel
            // 
            this.headLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.headLabel.Location = new System.Drawing.Point(3, 4);
            this.headLabel.Name = "headLabel";
            this.headLabel.Size = new System.Drawing.Size(125, 19);
            this.headLabel.TabIndex = 54;
            this.headLabel.Text = "История";
            this.headLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.headLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // day2Button
            // 
            this.day2Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.day2Button.FlatAppearance.BorderSize = 0;
            this.day2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.day2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.day2Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.day2Button.Location = new System.Drawing.Point(131, 61);
            this.day2Button.Name = "day2Button";
            this.day2Button.Size = new System.Drawing.Size(32, 23);
            this.day2Button.TabIndex = 62;
            this.day2Button.Text = "-2";
            this.day2Button.UseVisualStyleBackColor = false;
            this.day2Button.Click += new System.EventHandler(this.arrowButton_Click);
            // 
            // day3Button
            // 
            this.day3Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.day3Button.FlatAppearance.BorderSize = 0;
            this.day3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.day3Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.day3Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.day3Button.Location = new System.Drawing.Point(166, 61);
            this.day3Button.Name = "day3Button";
            this.day3Button.Size = new System.Drawing.Size(32, 23);
            this.day3Button.TabIndex = 63;
            this.day3Button.Text = "-3";
            this.day3Button.UseVisualStyleBackColor = false;
            this.day3Button.Click += new System.EventHandler(this.arrowButton_Click);
            // 
            // day7Button
            // 
            this.day7Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.day7Button.FlatAppearance.BorderSize = 0;
            this.day7Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.day7Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.day7Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.day7Button.Location = new System.Drawing.Point(200, 61);
            this.day7Button.Name = "day7Button";
            this.day7Button.Size = new System.Drawing.Size(32, 23);
            this.day7Button.TabIndex = 64;
            this.day7Button.Text = "-7";
            this.day7Button.UseVisualStyleBackColor = false;
            this.day7Button.Click += new System.EventHandler(this.arrowButton_Click);
            // 
            // arrowButton
            // 
            this.arrowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.arrowButton.FlatAppearance.BorderSize = 0;
            this.arrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.arrowButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.arrowButton.Location = new System.Drawing.Point(234, 61);
            this.arrowButton.Name = "arrowButton";
            this.arrowButton.Size = new System.Drawing.Size(80, 23);
            this.arrowButton.TabIndex = 65;
            this.arrowButton.Text = "<->";
            this.arrowButton.UseVisualStyleBackColor = false;
            this.arrowButton.Click += new System.EventHandler(this.arrowButton_Click);
            // 
            // todayButton
            // 
            this.todayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.todayButton.FlatAppearance.BorderSize = 0;
            this.todayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.todayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.todayButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.todayButton.Location = new System.Drawing.Point(62, 61);
            this.todayButton.Name = "todayButton";
            this.todayButton.Size = new System.Drawing.Size(66, 23);
            this.todayButton.TabIndex = 66;
            this.todayButton.Text = "Сегодня";
            this.todayButton.UseVisualStyleBackColor = false;
            this.todayButton.Click += new System.EventHandler(this.arrowButton_Click);
            // 
            // incomingButton
            // 
            this.incomingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.incomingButton.FlatAppearance.BorderSize = 0;
            this.incomingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.incomingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.incomingButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.incomingButton.Location = new System.Drawing.Point(6, 88);
            this.incomingButton.Name = "incomingButton";
            this.incomingButton.Size = new System.Drawing.Size(101, 23);
            this.incomingButton.TabIndex = 67;
            this.incomingButton.Text = "Входящие";
            this.incomingButton.UseVisualStyleBackColor = false;
            this.incomingButton.Click += new System.EventHandler(this.incomingButton_Click);
            // 
            // outcomingButton
            // 
            this.outcomingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.outcomingButton.FlatAppearance.BorderSize = 0;
            this.outcomingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.outcomingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outcomingButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.outcomingButton.Location = new System.Drawing.Point(110, 88);
            this.outcomingButton.Name = "outcomingButton";
            this.outcomingButton.Size = new System.Drawing.Size(101, 23);
            this.outcomingButton.TabIndex = 68;
            this.outcomingButton.Text = "Исходящие";
            this.outcomingButton.UseVisualStyleBackColor = false;
            this.outcomingButton.Click += new System.EventHandler(this.outcomingButton_Click);
            // 
            // unUnsweredButton
            // 
            this.unUnsweredButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.unUnsweredButton.FlatAppearance.BorderSize = 0;
            this.unUnsweredButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unUnsweredButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unUnsweredButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.unUnsweredButton.Location = new System.Drawing.Point(214, 88);
            this.unUnsweredButton.Name = "unUnsweredButton";
            this.unUnsweredButton.Size = new System.Drawing.Size(100, 23);
            this.unUnsweredButton.TabIndex = 69;
            this.unUnsweredButton.Text = "Без ответа";
            this.unUnsweredButton.UseVisualStyleBackColor = false;
            this.unUnsweredButton.Click += new System.EventHandler(this.unUnsweredButton_Click);
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // downResizer
            // 
            this.downResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.downResizer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.downResizer.Location = new System.Drawing.Point(0, 524);
            this.downResizer.Name = "downResizer";
            this.downResizer.Size = new System.Drawing.Size(319, 3);
            this.downResizer.TabIndex = 70;
            this.downResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.downResizer.MouseEnter += new System.EventHandler(this.downResizer_MouseEnter);
            this.downResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.downResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.downResizer_MouseMove);
            this.downResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // searchPictureBox
            // 
            this.searchPictureBox.BackgroundImage = global::BCTI.Properties.Resources.SearchLong;
            this.searchPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.searchPictureBox.Location = new System.Drawing.Point(131, 33);
            this.searchPictureBox.Name = "searchPictureBox";
            this.searchPictureBox.Size = new System.Drawing.Size(183, 24);
            this.searchPictureBox.TabIndex = 59;
            this.searchPictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(317, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 496);
            this.panel1.TabIndex = 71;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 496);
            this.panel2.TabIndex = 72;
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.panel3.Controls.Add(this.RingsTable);
            this.panel3.Location = new System.Drawing.Point(5, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(309, 404);
            this.panel3.TabIndex = 0;
            // 
            // Loading
            // 
            this.Loading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Loading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Loading.Enabled = false;
            this.Loading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Loading.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Loading.Location = new System.Drawing.Point(5, 114);
            this.Loading.Name = "Loading";
            this.Loading.Size = new System.Drawing.Size(309, 407);
            this.Loading.TabIndex = 73;
            this.Loading.Text = "Загрузка истории звонков...";
            this.Loading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Loading.Visible = false;
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SearchBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.SearchBox.Location = new System.Drawing.Point(133, 36);
            this.SearchBox.MaximumSize = new System.Drawing.Size(161, 19);
            this.SearchBox.MinimumSize = new System.Drawing.Size(161, 19);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(161, 16);
            this.SearchBox.TabIndex = 74;
            this.SearchBox.Text = "Введите номер или имя";
            this.SearchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SearchBox_MouseClick);
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            this.SearchBox.Leave += new System.EventHandler(this.SearchBox_Leave);
            this.SearchBox.MouseEnter += new System.EventHandler(this.SearchBox_MouseEnter);
            this.SearchBox.MouseLeave += new System.EventHandler(this.SearchBox_MouseLeave);
            // 
            // RingsTable
            // 
            this.RingsTable.AutoScroll = true;
            this.RingsTable.AutoSize = true;
            this.RingsTable.BackColor = System.Drawing.Color.White;
            this.RingsTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.RingsTable.ColumnCount = 1;
            this.RingsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RingsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RingsTable.Location = new System.Drawing.Point(0, 0);
            this.RingsTable.Name = "RingsTable";
            this.RingsTable.Padding = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.RingsTable.RowCount = 1;
            this.RingsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RingsTable.Size = new System.Drawing.Size(309, 404);
            this.RingsTable.TabIndex = 75;
            this.RingsTable.Resize += new System.EventHandler(this.RingsTable_Resize);
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(319, 527);
            this.ControlBox = false;
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.Loading);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.downResizer);
            this.Controls.Add(this.unUnsweredButton);
            this.Controls.Add(this.outcomingButton);
            this.Controls.Add(this.incomingButton);
            this.Controls.Add(this.todayButton);
            this.Controls.Add(this.arrowButton);
            this.Controls.Add(this.day7Button);
            this.Controls.Add(this.day3Button);
            this.Controls.Add(this.day2Button);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.headPanel);
            this.Controls.Add(this.searchPictureBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(319, 527);
            this.MinimumSize = new System.Drawing.Size(319, 527);
            this.Name = "History";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "История";
            this.Shown += new System.EventHandler(this.History_Shown);
            this.headPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchPictureBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox searchPictureBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label headLabel;
        private System.Windows.Forms.Button day2Button;
        private System.Windows.Forms.Button day3Button;
        private System.Windows.Forms.Button day7Button;
        private System.Windows.Forms.Button arrowButton;
        private System.Windows.Forms.Button todayButton;
        private System.Windows.Forms.Button incomingButton;
        private System.Windows.Forms.Button outcomingButton;
        private System.Windows.Forms.Button unUnsweredButton;
        private System.Windows.Forms.ImageList closeButtonImage;
        private System.Windows.Forms.Panel topResizer;
        private System.Windows.Forms.Panel downResizer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Loading;
        private System.Windows.Forms.TextBox SearchBox;
        private CustomControls.BTableLayotPanel RingsTable;
    }
}