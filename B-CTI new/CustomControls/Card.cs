using System;
using System.Drawing;
using System.Windows.Forms;
using AsteriskManager;
using BCTI.Properties;
using BCTI.Helpers;
using System.Collections.Generic;

namespace BCTI
{
    public partial class Card : UserControl
    {
        public bool bSelected = false;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public event EventHandler<EventArgs> cardClicked;
        public event EventHandler<CustEventArgs> numberClicked;
        public event EventHandler<EventArgs> orderChangeUp;
        public event EventHandler<EventArgs> orderChangeDown;
        public event EventHandler<EventArgs> EditClicked;
        public event EventHandler<EventArgs> ShowHistory;
        public event EventHandler<EventArgs> DeleteCard;
        public ClientsData client = new ClientsData();
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        /// <summary>
        /// Конструктор
        /// </summary>
        public Card()
        {
            InitializeComponent();
            //Шрифты
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.InitFonts(CardContextMenu);

            BLFPanel.ApplyLanguage += GeneralSettings_Language_Changed;

            Localization = Localizator.GetFormLocalization("Card", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            Localizator.MakeLocalizationAllContextMenu(CardContextMenu, Localization);

        }
        /// <summary>
        /// Инициализатор клиента
        /// </summary>
        /// <param name="newClient">Клиент для инициализации на карточке</param>
        private void GeneralSettings_Language_Changed(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization("Card", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            Localizator.MakeLocalizationAllContextMenu(CardContextMenu, Localization);
            SetClient(client);
        }

        public void SetClient(ClientsData newClient)
        {
            client = newClient;
            if (newClient.Name.Contains(" "))
            {
                var name = client.Name.Split(' ');
                nameLabel.Text = name[0];
                if (name.Length > 1)
                    SecondName.Text = name[1];
            }
            else
            {
                nameLabel.Text = newClient.Name;
                SecondName.Text = string.Empty;
            }
            FirstNumber.Text = newClient.Prefix + newClient.Number;
            SecondNumber.Text = newClient.SecondNumber;
            if (string.IsNullOrEmpty(SecondNumber.Text))
            {
                try
                {
                    SecondNumber.Text = Localization[SecondNumber.Name][1];
                }
                catch
                {
                    SecondNumber.Text = "Неизвестно";
                }
            }
            menunumber1.Text = newClient.Number;
            if (!string.IsNullOrEmpty((newClient.SecondNumber)))
                if (позвонитьToolStripMenuItem.DropDownItems.Count == 1)
                {
                    add_toolstripNumber2(newClient.SecondNumber);
                }
                else
                {
                    menunumber2.Text = newClient.SecondNumber;
                }
            else
            {
                if (позвонитьToolStripMenuItem.DropDownItems.Count > 1)
                    позвонитьToolStripMenuItem.DropDownItems.Remove(позвонитьToolStripMenuItem.DropDownItems[1]);
                //menunumber2.Text = "Не указан";
            }
            ///Автарка
            ImageLoader img = new ImageLoader(client);
            if (img.IsImageExists())
            {
                avatar.BackgroundImage = img.CircleImage(Color.Transparent);
            }
            else avatar.BackgroundImage = img.CircleImage(imageList1.Images[0], Color.Transparent);

            buttonDown.BackColor = Color.Transparent;
            buttonUp.BackColor = Color.Transparent;
            UpdateStatus();

            ///Подсказки для кнопок
            Tip.SetToolTip(nameLabel, newClient.Name);
            Tip.SetToolTip(SecondName, newClient.Name);

            try
            {
                Tip.SetToolTip(FirstNumber, Localization[позвонитьToolStripMenuItem.Name][0] + newClient.Prefix + newClient.Number);
                if (!string.IsNullOrEmpty(newClient.SecondNumber))
                {
                    Tip.SetToolTip(SecondNumber, Localization[позвонитьToolStripMenuItem.Name][0] + newClient.SecondNumber);
                }
                else
                {
                    Tip.SetToolTip(SecondNumber, Localization[SecondNumber.Name][2]);
                }
            }
            catch
            {
                Tip.SetToolTip(FirstNumber, "Позвонить на номер " + newClient.Prefix + newClient.Number);
                if (!string.IsNullOrEmpty(newClient.SecondNumber))
                {
                    Tip.SetToolTip(SecondNumber, "Позвонить на номер " + newClient.SecondNumber);
                }
                else
                {
                    Tip.SetToolTip(SecondNumber, "У этого контакта нет второго номера");
                }
            }

            prev = new Preview(client);

            //Шрифты
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.InitFonts(CardContextMenu);

            ///Устанавливаем картинку, если номер не помещается в кнопку
            if (FirstNumber.Width < TextRenderer.MeasureText(FirstNumber.Text, new Font(FirstNumber.Font.FontFamily, FirstNumber.Font.Size, FirstNumber.Font.Style)).Width)
            {
                FirstNumber.Text = "";
                FirstNumber.Image = Resources.callpanel;
                FirstNumber.ImageAlign = ContentAlignment.MiddleCenter;
            }
            else
                if (FirstNumber.Image != null)
                FirstNumber.Image = null;
        }
        /// <summary>
        /// Обновление статуса контакта
        /// </summary>
        public void UpdateStatus()
        {
            switch (client.BLFStatus)
            {
                case ClientStatus.Online:
                    FirstNumber.BackColor = Color.FromArgb(0, 171, 57);
                    StatusColor = Color.FromArgb(0, 171, 57);
                    break;
                case ClientStatus.Calling:
                    FirstNumber.BackColor = Color.FromArgb(205, 103, 0);
                    StatusColor = Color.FromArgb(205, 103, 0);
                    break;
                case ClientStatus.Talk:
                    FirstNumber.BackColor = Color.FromArgb(45, 203, 152);
                    StatusColor = Color.FromArgb(45, 203, 152);
                    break;
                case ClientStatus.Unknown:
                    FirstNumber.BackColor = Color.FromArgb(255, 128, 128);
                    StatusColor = Color.FromArgb(255, 128, 128);
                    break;
                case ClientStatus.Hold:
                    FirstNumber.BackColor = Color.FromArgb(45, 203, 152);
                    StatusColor = Color.FromArgb(45, 203, 152);
                    break;
                default:
                    FirstNumber.BackColor = Color.FromArgb(255, 128, 128);
                    StatusColor = Color.FromArgb(255, 128, 128);
                    break;
            }
            try
            {
                this.BeginInvoke((MethodInvoker)(() => avatar.Refresh()));
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }
        }


        /// <summary>
        /// Возвращает основной номер
        /// </summary>
        /// <returns></returns>
        public string getMainNumber()
        {
            return FirstNumber.Text;
        }
        public void SearchForm()
        {
            buttonDown.Hide();
            buttonUp.Hide();
        }
        public void DefaultForm()
        {
            buttonDown.Show();
            buttonUp.Show();
        }
        private void number_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(client.Prefix))
            {
                numberClicked?.Invoke(this, new CustEventArgs(client.Prefix + client.Number));
            }
            else
            {
                numberClicked?.Invoke(this, new CustEventArgs(client.Number));
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            orderChangeUp?.Invoke(this, null);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            orderChangeDown?.Invoke(this, null);
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            numberClicked?.Invoke(this, new CustEventArgs(FirstNumber.Text));
        }

        private void SecondNumner_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(client.SecondNumber))
                numberClicked?.Invoke(this, new CustEventArgs(client.SecondNumber));
        }
        private void историяЗвонковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHistory?.Invoke(this, null);
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, null);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCard?.Invoke(this, null);
        }

        private void menunumber1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem temp = sender as ToolStripMenuItem;
            if (!string.IsNullOrEmpty(temp.Text))
                numberClicked(this, new CustEventArgs(temp.Text));
        }

        private void menunumber2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem temp = sender as ToolStripMenuItem;
            if (temp.Text != "Не указан")
                if (!string.IsNullOrEmpty(temp.Text))
                    numberClicked(this, new CustEventArgs(temp.Text));
        }
        #region DragAndDrop

        private void avatar_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void avatar_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Card)) is Card)
            {
                Card_MouseEnter(this, null);
                var car = (Card)e.Data.GetData(typeof(Card));
                car.NoSelection();
                e.Effect = DragDropEffects.Move;
            }
        }
        public bool bIsDragging = false;

        private void avatar_DragDrop(object sender, DragEventArgs e)
        {
            prev?.Hide();

            if (e.Data.GetData(typeof(Card)) is Card)
            {
                var card = (Card)e.Data.GetData(typeof(Card));
                ClientsData prevcard = this.client;
                int tempposition = prevcard.onBLFposition;
                prevcard.onBLFposition = card.client.onBLFposition;
                card.client.onBLFposition = tempposition;
                SetClient(card.client);
                card.SetClient(prevcard);
                if (card.bSelected && !this.bSelected)
                {
                    this.SetSelected();
                    card.SetDeselected();
                }
                else if (this.bSelected && !card.bSelected)
                {
                    card.SetSelected();
                    this.SetDeselected();
                }
                else if (card.bSelected && this.bSelected)
                {
                    card.SetSelected();
                    this.SetSelected();
                }
            }

        }

        public void add_toolstripNumber2(string text)
        {
            ToolStripDropDownItem menunumber2 = new ToolStripMenuItem(text);
            menunumber2.Click += menunumber2_Click;
            позвонитьToolStripMenuItem.DropDownItems.Add(menunumber2);
        }
        private void avatar_DragLeave(object sender, EventArgs e)
        {
            Card_MouseLeave(this, null);
        }

        private void avatar_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void avatar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && buttonDown.Visible)
            {
                this.DoDragDrop(this, DragDropEffects.Move);
            }
        }

        #endregion
        #region PreviewCard

        Preview prev;
        private void avatar_MouseHover(object sender, EventArgs e)
        {

            prev.Show();
            //add.Location = PointToScreen(MousePosition);
            var MousePos = PointToScreen(avatar.Location);
            if ((SystemInformation.VirtualScreen.Width < MousePos.X + avatar.Width + 1 + prev.Width))
            {
                if ((SystemInformation.VirtualScreen.Height < MousePos.Y + avatar.Height + 1 + prev.Height))
                {
                    prev.DesktopLocation = new Point(MousePosition.X - prev.Width - 1, MousePosition.Y - prev.Height - 1);
                }
                else
                {
                    prev.DesktopLocation = new Point(MousePosition.X - prev.Width - 1, MousePosition.Y - 1);
                }
            }
            else if ((SystemInformation.VirtualScreen.Height < MousePos.Y + avatar.Height + 1 + prev.Height))
            {
                prev.DesktopLocation = new Point(MousePosition.X + 1, MousePosition.Y - prev.Height - 1);
            }
            else
            {
                prev.DesktopLocation = new Point(MousePosition.X + 1, MousePosition.Y + 1);
            }
        }
        #endregion
        #region CardFocusMethods
        private void Card_MouseClick(object sender, MouseEventArgs e)
        {
            if (prev != null)
                prev.Hide();
            if (e.Button == MouseButtons.Left)
            {
                bSelected = !bSelected;
                buttonDown.BackColor = Color.Transparent;
                buttonUp.BackColor = Color.Transparent;
                if (bSelected)
                {
                    buttonDown.BackgroundImage = Resources.down_active;
                    buttonUp.BackgroundImage = Resources.up_active;
                    this.BackColor = Color.FromArgb(102, 153, 255);
                    nameLabel.ForeColor = Color.White;
                    SecondName.ForeColor = Color.White;
                    buttonUp.BackColor = Color.Transparent;
                    buttonDown.BackColor = Color.Transparent;
                }
                else
                {
                    buttonDown.BackgroundImage = Resources.down;
                    buttonUp.BackgroundImage = Resources.up;
                    this.BackColor = Colors.WhiteTheme.MainGray;
                    nameLabel.ForeColor = SystemColors.ControlText;
                    SecondName.ForeColor = SystemColors.ControlText;
                    buttonUp.BackColor = Color.Transparent;
                    buttonDown.BackColor = Color.Transparent;
                }
                cardClicked(this, null);
            }
            else if (e.Button == MouseButtons.Right)
            {
                bSelected = true;
                buttonDown.BackgroundImage = Resources.down_active;
                buttonUp.BackgroundImage = Resources.up_active;
                this.BackColor = Color.FromArgb(102, 153, 255);
                nameLabel.ForeColor = Color.White;
                SecondName.ForeColor = Color.White;
                buttonUp.BackColor = Color.Transparent;
                buttonDown.BackColor = Color.Transparent;
                cardClicked(this, null);
                CardContextMenu.Show(MousePosition);
            }
        }
        private void Number_MouseLeave(object sender, EventArgs e)
        {
            if (!bSelected)
            {
                this.BackColor = Colors.WhiteTheme.MainGray;
                NoSelection();
            }
            if (sender is Label)
            {
                Label b = sender as Label;
                b.BackColor = Color.FromArgb(152, 152, 255);
                UpdateStatus();
            }

        }
        private void Card_MouseEnter(object sender, EventArgs e)
        {
            if (!bSelected && !bIsDragging)
            {
                this.BackColor = Color.Gray;
                MouseOver();
            }
        }

        private void Card_MouseLeave(object sender, EventArgs e)
        {
            if (!bSelected && !bIsDragging)
            {
                this.BackColor = Colors.WhiteTheme.MainGray;
                NoSelection();
            }

            prev?.Hide();
        }
        private void Number_MouseEnter(object sender, EventArgs e)
        {
            if (!bSelected)
            {
                this.BackColor = Color.Gray;
                MouseOver();
            }
            if (sender is Label)
            {
                Label b = sender as Label;
                b.BackColor = Color.FromArgb(0, 45, 146);
            }
        }
        public void SetSelected()
        {
            this.bSelected = true;
            buttonDown.BackgroundImage = Resources.down_active;
            buttonUp.BackgroundImage = Resources.up_active;
            this.BackColor = Color.FromArgb(102, 153, 255);
            nameLabel.ForeColor = Color.White;
            SecondName.ForeColor = Color.White;
            buttonUp.BackColor = Color.Transparent;
            buttonDown.BackColor = Color.Transparent;
        }
        public void SetDeselected()
        {
            this.bSelected = false;
            this.BackColor = Colors.WhiteTheme.MainGray;
            nameLabel.ForeColor = SystemColors.ControlText;
            SecondName.ForeColor = SystemColors.ControlText;
            buttonDown.BackColor = Color.Transparent;
            buttonUp.BackColor = Color.Transparent;
            buttonDown.BackgroundImage = Resources.down;
            buttonUp.BackgroundImage = Resources.up;
        }
        private void buttonUp_MouseEnter(object sender, EventArgs e)
        {
            if (!bSelected)
            {
                this.BackColor = Color.Gray;
                MouseOver();
                buttonUp.BackgroundImage = Resources.up_on;
            }
            else
            {
                buttonUp.BackgroundImage = Resources.up_on;
            }
        }

        private void buttonUp_MouseLeave(object sender, EventArgs e)
        {
            if (!bSelected)
            {
                this.BackColor = Colors.WhiteTheme.MainGray;
                NoSelection();
                buttonUp.BackgroundImage = Resources.up;
            }
            else
            {
                buttonUp.BackgroundImage = Resources.up_active;
            }
        }

        private void buttonDown_MouseEnter(object sender, EventArgs e)
        {
            if (!bSelected)
            {
                this.BackColor = Color.Gray;
                MouseOver();
                buttonDown.BackgroundImage = Resources.down_on;
            }
            else
            {
                buttonDown.BackgroundImage = Resources.down_on;
            }
        }

        private void buttonDown_MouseLeave(object sender, EventArgs e)
        {
            if (!bSelected)
            {
                //var pos = this.PointToClient(Cursor.Position);
                //if (!this.ClientRectangle.Contains(pos))
                //{
                this.BackColor = Colors.WhiteTheme.MainGray;
                NoSelection();
                //}
                buttonDown.BackgroundImage = Resources.down;
            }
            else
            {
                buttonDown.BackgroundImage = Resources.down_active;
            }
        }
        public void ChangeFocus()
        {
            if (!bSelected)
            {
                this.BackColor = Colors.WhiteTheme.MainGray;
                nameLabel.ForeColor = SystemColors.ControlText;
                SecondName.ForeColor = SystemColors.ControlText;
                buttonDown.BackColor = Color.Transparent;
                buttonUp.BackColor = Color.Transparent;
                buttonDown.BackgroundImage = Resources.down;
                buttonUp.BackgroundImage = Resources.up;
            }
            else
            {
                buttonDown.BackgroundImage = Resources.down_active;
                buttonUp.BackgroundImage = Resources.up_active;
                this.BackColor = Color.FromArgb(102, 153, 255);
                nameLabel.ForeColor = Color.White;
                SecondName.ForeColor = Color.White;
                buttonDown.BackColor = Color.Transparent;
                buttonUp.BackColor = Color.Transparent;
            }
        }
        private void MouseOver()
        {
            this.BackColor = Color.Gray;

            nameLabel.ForeColor = Color.White;
            SecondName.ForeColor = Color.White;
            buttonDown.BackColor = Color.Transparent;
            buttonUp.BackColor = Color.Transparent;
            CircleColor = Colors.WhiteTheme.MainColor;
            avatar.Refresh();
        }
        public void NoSelection()
        {

            this.BackColor = Colors.WhiteTheme.MainGray;
            nameLabel.ForeColor = SystemColors.ControlText;
            SecondName.ForeColor = SystemColors.ControlText;
            buttonDown.BackColor = Color.Transparent;
            buttonUp.BackColor = Color.Transparent;
            CircleColor = Colors.WhiteTheme.ButtonMainColor;
            avatar.Refresh();
        }
        #endregion
        #region Paint
        Color CircleColor = Colors.WhiteTheme.ButtonMainColor;
        private void avatar_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen myPen = new Pen(CircleColor, 2);
            graphics.DrawEllipse(myPen, 0, 0,
                      avatar.Width - 2, avatar.Height - 2);

            Brush brush = new SolidBrush(StatusColor);
            graphics.DrawEllipse(myPen, avatar.Width - 16, avatar.Height - 15, 13, 13);
            graphics.FillEllipse(brush, avatar.Width - 16, avatar.Height - 15, 13, 13);
            myPen.Dispose();
            brush.Dispose();
        }
        Color StatusColor = Colors.WhiteTheme.Red;
        #endregion

    }
}
