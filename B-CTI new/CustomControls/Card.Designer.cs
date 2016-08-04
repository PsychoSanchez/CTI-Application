namespace BCTI
{
    partial class Card
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Card));
            this.buttonUp = new System.Windows.Forms.Panel();
            this.buttonDown = new System.Windows.Forms.Panel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.SecondName = new System.Windows.Forms.Label();
            this.SecondNumber = new System.Windows.Forms.Label();
            this.FirstNumber = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Tip = new System.Windows.Forms.ToolTip(this.components);
            this.CardContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.позвонитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menunumber1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menunumber2 = new System.Windows.Forms.ToolStripMenuItem();
            this.историяЗвонковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.CardContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUp.BackgroundImage = global::BCTI.Properties.Resources.up;
            this.buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUp.Location = new System.Drawing.Point(194, 8);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(10, 10);
            this.buttonUp.TabIndex = 9;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            this.buttonUp.MouseEnter += new System.EventHandler(this.buttonUp_MouseEnter);
            this.buttonUp.MouseLeave += new System.EventHandler(this.buttonUp_MouseLeave);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.BackgroundImage = global::BCTI.Properties.Resources.down;
            this.buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDown.Location = new System.Drawing.Point(194, 20);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(10, 10);
            this.buttonDown.TabIndex = 10;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            this.buttonDown.MouseEnter += new System.EventHandler(this.buttonDown_MouseEnter);
            this.buttonDown.MouseLeave += new System.EventHandler(this.buttonDown_MouseLeave);
            // 
            // nameLabel
            // 
            this.nameLabel.AllowDrop = true;
            this.nameLabel.AutoEllipsis = true;
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.CausesValidation = false;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(64, 2);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 21);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.UseCompatibleTextRendering = true;
            this.nameLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.avatar_DragDrop);
            this.nameLabel.DragEnter += new System.Windows.Forms.DragEventHandler(this.avatar_DragEnter);
            this.nameLabel.DragLeave += new System.EventHandler(this.avatar_DragLeave);
            this.nameLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Card_MouseClick);
            this.nameLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            this.nameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.avatar_MouseDown);
            this.nameLabel.MouseEnter += new System.EventHandler(this.Card_MouseEnter);
            this.nameLabel.MouseLeave += new System.EventHandler(this.Card_MouseLeave);
            this.nameLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.avatar_MouseMove);
            this.nameLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.avatar_MouseUp);
            // 
            // SecondName
            // 
            this.SecondName.AllowDrop = true;
            this.SecondName.AutoEllipsis = true;
            this.SecondName.AutoSize = true;
            this.SecondName.CausesValidation = false;
            this.SecondName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SecondName.Location = new System.Drawing.Point(64, 18);
            this.SecondName.Name = "SecondName";
            this.SecondName.Size = new System.Drawing.Size(0, 21);
            this.SecondName.TabIndex = 8;
            this.SecondName.UseCompatibleTextRendering = true;
            this.SecondName.DragDrop += new System.Windows.Forms.DragEventHandler(this.avatar_DragDrop);
            this.SecondName.DragEnter += new System.Windows.Forms.DragEventHandler(this.avatar_DragEnter);
            this.SecondName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Card_MouseClick);
            this.SecondName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            this.SecondName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.avatar_MouseDown);
            this.SecondName.MouseEnter += new System.EventHandler(this.Card_MouseEnter);
            this.SecondName.MouseLeave += new System.EventHandler(this.Card_MouseLeave);
            this.SecondName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.avatar_MouseMove);
            // 
            // SecondNumber
            // 
            this.SecondNumber.AllowDrop = true;
            this.SecondNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondNumber.AutoEllipsis = true;
            this.SecondNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(255)))));
            this.SecondNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SecondNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SecondNumber.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SecondNumber.Location = new System.Drawing.Point(117, 40);
            this.SecondNumber.Name = "SecondNumber";
            this.SecondNumber.Size = new System.Drawing.Size(88, 22);
            this.SecondNumber.TabIndex = 7;
            this.SecondNumber.Text = "label2";
            this.SecondNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SecondNumber.Click += new System.EventHandler(this.SecondNumner_Click);
            this.SecondNumber.DragDrop += new System.Windows.Forms.DragEventHandler(this.avatar_DragDrop);
            this.SecondNumber.DragEnter += new System.Windows.Forms.DragEventHandler(this.avatar_DragEnter);
            this.SecondNumber.DragLeave += new System.EventHandler(this.avatar_DragLeave);
            this.SecondNumber.MouseEnter += new System.EventHandler(this.Number_MouseEnter);
            this.SecondNumber.MouseLeave += new System.EventHandler(this.Number_MouseLeave);
            // 
            // FirstNumber
            // 
            this.FirstNumber.AllowDrop = true;
            this.FirstNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FirstNumber.BackColor = System.Drawing.Color.LightCoral;
            this.FirstNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FirstNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FirstNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstNumber.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FirstNumber.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.FirstNumber.Location = new System.Drawing.Point(66, 40);
            this.FirstNumber.Name = "FirstNumber";
            this.FirstNumber.Size = new System.Drawing.Size(47, 22);
            this.FirstNumber.TabIndex = 6;
            this.FirstNumber.Text = "label1";
            this.FirstNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FirstNumber.Click += new System.EventHandler(this.number_Click);
            this.FirstNumber.DragDrop += new System.Windows.Forms.DragEventHandler(this.avatar_DragDrop);
            this.FirstNumber.DragEnter += new System.Windows.Forms.DragEventHandler(this.avatar_DragEnter);
            this.FirstNumber.DragLeave += new System.EventHandler(this.avatar_DragLeave);
            this.FirstNumber.MouseEnter += new System.EventHandler(this.Number_MouseEnter);
            this.FirstNumber.MouseLeave += new System.EventHandler(this.Number_MouseLeave);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "no_photo.bmp");
            this.imageList1.Images.SetKeyName(1, "down.png");
            this.imageList1.Images.SetKeyName(2, "down_active.png");
            this.imageList1.Images.SetKeyName(3, "down_on.png");
            this.imageList1.Images.SetKeyName(4, "up.png");
            this.imageList1.Images.SetKeyName(5, "up_active.png");
            this.imageList1.Images.SetKeyName(6, "up_on.png");
            // 
            // Tip
            // 
            this.Tip.BackColor = System.Drawing.SystemColors.HighlightText;
            // 
            // CardContextMenu
            // 
            this.CardContextMenu.BackColor = System.Drawing.SystemColors.Control;
            this.CardContextMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CardContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.CardContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.позвонитьToolStripMenuItem,
            this.историяЗвонковToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.CardContextMenu.Name = "contextMenuStrip1";
            this.CardContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.CardContextMenu.ShowImageMargin = false;
            this.CardContextMenu.Size = new System.Drawing.Size(165, 92);
            // 
            // позвонитьToolStripMenuItem
            // 
            this.позвонитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menunumber1,
            this.menunumber2});
            this.позвонитьToolStripMenuItem.Name = "позвонитьToolStripMenuItem";
            this.позвонитьToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.позвонитьToolStripMenuItem.Text = "Позвонить";
            // 
            // menunumber1
            // 
            this.menunumber1.Name = "menunumber1";
            this.menunumber1.Size = new System.Drawing.Size(138, 22);
            this.menunumber1.Text = "#Number1";
            this.menunumber1.Click += new System.EventHandler(this.menunumber1_Click);
            // 
            // menunumber2
            // 
            this.menunumber2.Name = "menunumber2";
            this.menunumber2.Size = new System.Drawing.Size(138, 22);
            this.menunumber2.Text = "#Number2";
            this.menunumber2.Click += new System.EventHandler(this.menunumber2_Click);
            // 
            // историяЗвонковToolStripMenuItem
            // 
            this.историяЗвонковToolStripMenuItem.Name = "историяЗвонковToolStripMenuItem";
            this.историяЗвонковToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.историяЗвонковToolStripMenuItem.Text = "История звонков";
            this.историяЗвонковToolStripMenuItem.Click += new System.EventHandler(this.историяЗвонковToolStripMenuItem_Click);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // avatar
            // 
            this.avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avatar.Location = new System.Drawing.Point(4, 4);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(58, 58);
            this.avatar.TabIndex = 11;
            this.avatar.TabStop = false;
            this.avatar.DragDrop += new System.Windows.Forms.DragEventHandler(this.avatar_DragDrop);
            this.avatar.DragEnter += new System.Windows.Forms.DragEventHandler(this.avatar_DragEnter);
            this.avatar.DragLeave += new System.EventHandler(this.avatar_DragLeave);
            this.avatar.Paint += new System.Windows.Forms.PaintEventHandler(this.avatar_Paint);
            this.avatar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Card_MouseClick);
            this.avatar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            this.avatar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.avatar_MouseDown);
            this.avatar.MouseEnter += new System.EventHandler(this.Card_MouseEnter);
            this.avatar.MouseLeave += new System.EventHandler(this.Card_MouseLeave);
            this.avatar.MouseHover += new System.EventHandler(this.avatar_MouseHover);
            this.avatar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.avatar_MouseMove);
            this.avatar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.avatar_MouseUp);
            // 
            // Card
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Controls.Add(this.avatar);
            this.Controls.Add(this.FirstNumber);
            this.Controls.Add(this.SecondNumber);
            this.Controls.Add(this.SecondName);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.nameLabel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 2, 1);
            this.MaximumSize = new System.Drawing.Size(209, 126);
            this.Name = "Card";
            this.Size = new System.Drawing.Size(209, 66);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.avatar_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.avatar_DragEnter);
            this.DragLeave += new System.EventHandler(this.avatar_DragLeave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Card_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.avatar_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Card_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Card_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.avatar_MouseMove);
            this.CardContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label FirstNumber;
        private System.Windows.Forms.Label SecondNumber;
        private System.Windows.Forms.Label SecondName;
        private System.Windows.Forms.ToolTip Tip;
        private System.Windows.Forms.Panel buttonUp;
        private System.Windows.Forms.Panel buttonDown;
        private System.Windows.Forms.ContextMenuStrip CardContextMenu;
        private System.Windows.Forms.ToolStripMenuItem позвонитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem историяЗвонковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menunumber1;
        private System.Windows.Forms.ToolStripMenuItem menunumber2;
        private System.Windows.Forms.PictureBox avatar;
    }
}
