namespace BCTI
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.headPanel = new System.Windows.Forms.Panel();
            this.rightResizer2 = new System.Windows.Forms.Panel();
            this.leftResizer2 = new System.Windows.Forms.Panel();
            this.topResizer = new System.Windows.Forms.Panel();
            this.headLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.closeButtonImage = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SettingsTree = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SettingTab = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AccButton = new System.Windows.Forms.Label();
            this.CancellButton = new System.Windows.Forms.Label();
            this.Defaults = new System.Windows.Forms.Label();
            this.leftResizer = new System.Windows.Forms.Panel();
            this.downResizer = new System.Windows.Forms.Panel();
            this.rightResizer = new System.Windows.Forms.Panel();
            this.maincontainer = new System.Windows.Forms.Panel();
            this.headPanel.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.maincontainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.headPanel.Controls.Add(this.rightResizer2);
            this.headPanel.Controls.Add(this.leftResizer2);
            this.headPanel.Controls.Add(this.topResizer);
            this.headPanel.Controls.Add(this.headLabel);
            this.headPanel.Controls.Add(this.closeButton);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(583, 28);
            this.headPanel.TabIndex = 0;
            this.headPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // rightResizer2
            // 
            this.rightResizer2.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightResizer2.Location = new System.Drawing.Point(578, 5);
            this.rightResizer2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rightResizer2.Name = "rightResizer2";
            this.rightResizer2.Size = new System.Drawing.Size(5, 23);
            this.rightResizer2.TabIndex = 1;
            this.rightResizer2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.rightResizer2.MouseEnter += new System.EventHandler(this.rightSizer_MouseEnter);
            this.rightResizer2.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.rightResizer2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseMove);
            this.rightResizer2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // leftResizer2
            // 
            this.leftResizer2.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftResizer2.Location = new System.Drawing.Point(0, 5);
            this.leftResizer2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.leftResizer2.Name = "leftResizer2";
            this.leftResizer2.Size = new System.Drawing.Size(5, 23);
            this.leftResizer2.TabIndex = 3;
            this.leftResizer2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.leftResizer2.MouseEnter += new System.EventHandler(this.rightSizer_MouseEnter);
            this.leftResizer2.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.leftResizer2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftSizer_MouseMove);
            this.leftResizer2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // topResizer
            // 
            this.topResizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.topResizer.Location = new System.Drawing.Point(0, 0);
            this.topResizer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.topResizer.Name = "topResizer";
            this.topResizer.Size = new System.Drawing.Size(583, 5);
            this.topResizer.TabIndex = 2;
            this.topResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.topResizer.MouseEnter += new System.EventHandler(this.downResizer_MouseEnter);
            this.topResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.topResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topSizer_MouseMove);
            this.topResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // headLabel
            // 
            this.headLabel.AutoSize = true;
            this.headLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headLabel.Location = new System.Drawing.Point(4, 5);
            this.headLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.headLabel.Name = "headLabel";
            this.headLabel.Size = new System.Drawing.Size(100, 20);
            this.headLabel.TabIndex = 1;
            this.headLabel.Text = "Настройки";
            this.headLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseDown);
            this.headLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseMove);
            this.headLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headPanel_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(545, 5);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(32, 18);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // closeButtonImage
            // 
            this.closeButtonImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("closeButtonImage.ImageStream")));
            this.closeButtonImage.TransparentColor = System.Drawing.Color.Transparent;
            this.closeButtonImage.Images.SetKeyName(0, "close.bmp");
            this.closeButtonImage.Images.SetKeyName(1, "close_on.bmp");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(6, 3);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.SettingsTree);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(577, 388);
            this.splitContainer1.SplitterDistance = 147;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // SettingsTree
            // 
            this.SettingsTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.SettingsTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SettingsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingsTree.ForeColor = System.Drawing.SystemColors.WindowText;
            this.SettingsTree.FullRowSelect = true;
            this.SettingsTree.HideSelection = false;
            this.SettingsTree.ItemHeight = 18;
            this.SettingsTree.Location = new System.Drawing.Point(0, 0);
            this.SettingsTree.Margin = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.SettingsTree.Name = "SettingsTree";
            this.SettingsTree.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SettingsTree.ShowLines = false;
            this.SettingsTree.ShowPlusMinus = false;
            this.SettingsTree.ShowRootLines = false;
            this.SettingsTree.Size = new System.Drawing.Size(147, 388);
            this.SettingsTree.TabIndex = 0;
            this.SettingsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SettingsTree_AfterSelect);
            this.SettingsTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SettingsTree_NodeMouseClick);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.SettingTab);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2, 0, 6, 3);
            this.panel2.Size = new System.Drawing.Size(429, 358);
            this.panel2.TabIndex = 0;
            // 
            // SettingTab
            // 
            this.SettingTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.SettingTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingTab.Location = new System.Drawing.Point(2, 0);
            this.SettingTab.Margin = new System.Windows.Forms.Padding(1);
            this.SettingTab.Name = "SettingTab";
            this.SettingTab.Padding = new System.Windows.Forms.Padding(1);
            this.SettingTab.Size = new System.Drawing.Size(421, 355);
            this.SettingTab.TabIndex = 0;
            this.SettingTab.TabStop = false;
            this.SettingTab.Text = "#SettingTabName";
            this.SettingTab.UseCompatibleTextRendering = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.AccButton);
            this.panel1.Controls.Add(this.CancellButton);
            this.panel1.Controls.Add(this.Defaults);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 358);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.MaximumSize = new System.Drawing.Size(1200, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel1.Size = new System.Drawing.Size(429, 30);
            this.panel1.TabIndex = 11;
            // 
            // AccButton
            // 
            this.AccButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.AccButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AccButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AccButton.ForeColor = System.Drawing.Color.White;
            this.AccButton.Location = new System.Drawing.Point(307, 0);
            this.AccButton.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AccButton.Name = "AccButton";
            this.AccButton.Size = new System.Drawing.Size(116, 30);
            this.AccButton.TabIndex = 14;
            this.AccButton.Text = "Применить";
            this.AccButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AccButton.Click += new System.EventHandler(this.ApplySettings_Click);
            this.AccButton.MouseEnter += new System.EventHandler(this.Defaults_MouseEnter);
            this.AccButton.MouseLeave += new System.EventHandler(this.Defaults_MouseLeave);
            // 
            // CancellButton
            // 
            this.CancellButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancellButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.CancellButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancellButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancellButton.ForeColor = System.Drawing.Color.White;
            this.CancellButton.Location = new System.Drawing.Point(188, 0);
            this.CancellButton.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CancellButton.Name = "CancellButton";
            this.CancellButton.Size = new System.Drawing.Size(116, 30);
            this.CancellButton.TabIndex = 13;
            this.CancellButton.Text = "OK";
            this.CancellButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CancellButton.Click += new System.EventHandler(this.OKButton_Click);
            this.CancellButton.MouseEnter += new System.EventHandler(this.Defaults_MouseEnter);
            this.CancellButton.MouseLeave += new System.EventHandler(this.Defaults_MouseLeave);
            // 
            // Defaults
            // 
            this.Defaults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Defaults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.Defaults.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Defaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Defaults.ForeColor = System.Drawing.Color.White;
            this.Defaults.Location = new System.Drawing.Point(2, 0);
            this.Defaults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Defaults.Name = "Defaults";
            this.Defaults.Size = new System.Drawing.Size(116, 30);
            this.Defaults.TabIndex = 12;
            this.Defaults.Text = "По умолчанию";
            this.Defaults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Defaults.Click += new System.EventHandler(this.DefaultButton_Click);
            this.Defaults.MouseEnter += new System.EventHandler(this.Defaults_MouseEnter);
            this.Defaults.MouseLeave += new System.EventHandler(this.Defaults_MouseLeave);
            // 
            // leftResizer
            // 
            this.leftResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.leftResizer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftResizer.Location = new System.Drawing.Point(0, 28);
            this.leftResizer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.leftResizer.Name = "leftResizer";
            this.leftResizer.Size = new System.Drawing.Size(3, 394);
            this.leftResizer.TabIndex = 2;
            this.leftResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.leftResizer.MouseEnter += new System.EventHandler(this.rightSizer_MouseEnter);
            this.leftResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.leftResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftSizer_MouseMove);
            this.leftResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // downResizer
            // 
            this.downResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.downResizer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.downResizer.Location = new System.Drawing.Point(0, 422);
            this.downResizer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.downResizer.Name = "downResizer";
            this.downResizer.Size = new System.Drawing.Size(580, 3);
            this.downResizer.TabIndex = 1;
            this.downResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.downResizer.MouseEnter += new System.EventHandler(this.downResizer_MouseEnter);
            this.downResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.downResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.downResizer_MouseMove);
            this.downResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // rightResizer
            // 
            this.rightResizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.rightResizer.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightResizer.Location = new System.Drawing.Point(580, 28);
            this.rightResizer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rightResizer.Name = "rightResizer";
            this.rightResizer.Size = new System.Drawing.Size(3, 397);
            this.rightResizer.TabIndex = 0;
            this.rightResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseDown);
            this.rightResizer.MouseEnter += new System.EventHandler(this.rightSizer_MouseEnter);
            this.rightResizer.MouseLeave += new System.EventHandler(this.rightSizer_MouseLeave);
            this.rightResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseMove);
            this.rightResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightSizer_MouseUp);
            // 
            // maincontainer
            // 
            this.maincontainer.Controls.Add(this.splitContainer1);
            this.maincontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maincontainer.Location = new System.Drawing.Point(0, 28);
            this.maincontainer.Margin = new System.Windows.Forms.Padding(0);
            this.maincontainer.Name = "maincontainer";
            this.maincontainer.Padding = new System.Windows.Forms.Padding(6, 3, 0, 6);
            this.maincontainer.Size = new System.Drawing.Size(583, 397);
            this.maincontainer.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(583, 425);
            this.ControlBox = false;
            this.Controls.Add(this.leftResizer);
            this.Controls.Add(this.downResizer);
            this.Controls.Add(this.rightResizer);
            this.Controls.Add(this.maincontainer);
            this.Controls.Add(this.headPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(583, 278);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.maincontainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label headLabel;
        private System.Windows.Forms.ImageList closeButtonImage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView SettingsTree;
        private System.Windows.Forms.GroupBox SettingTab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel topResizer;
        private System.Windows.Forms.Panel leftResizer;
        private System.Windows.Forms.Panel downResizer;
        private System.Windows.Forms.Panel rightResizer2;
        private System.Windows.Forms.Panel leftResizer2;
        private System.Windows.Forms.Panel rightResizer;
        private System.Windows.Forms.Label Defaults;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel maincontainer;
        private System.Windows.Forms.Label AccButton;
        private System.Windows.Forms.Label CancellButton;
    }
}