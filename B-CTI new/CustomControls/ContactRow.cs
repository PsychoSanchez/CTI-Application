using System;
using System.Drawing;
using System.Windows.Forms;
using AsteriskManager;
using BCTI.Properties;
using BCTI.DialogBoxes;
using BCTI.Helpers;
using System.Collections.Generic;
using BCTI.CustomControls;

namespace BCTI
{
    public partial class ContactRow : UserControl
    {
        #region Containers

        public BPanel OnBLFBorder = new BPanel();
        public BPanel onBLF = new BPanel();
        public BPanel PhotoBorder = new BPanel();
        public BPanel PhotoPanel = new BPanel();
        BPanel innerPhoto = new BPanel();
        BPanel innerPhoto1 = new BPanel();
        BPanel innerPhoto2 = new BPanel();
        PictureBox photo = new PictureBox();
        public BPanel NameBorder = new BPanel();
        public BPanel NamePanel = new BPanel();
        Label NameLabel = new Label();
        public BPanel ComapnyBorder = new BPanel();
        public BPanel CompanyPanel = new BPanel();
        BPanel CompanyContainer = new BPanel();
        Label CompanyNameLabel = new Label();
        public BPanel PhoneBorder = new BPanel();
        public BPanel PhonePanel = new BPanel();
        Label FirstNumber = new Label();
        Label SecondNumber = new Label();
        public BPanel EmailBorder = new BPanel();
        public BPanel EmailPanel = new BPanel();
        PictureBox EmailConntainer = new PictureBox();
        Label EmailLabel = new Label();
        public ClientsData _Client;
        public bool Selected = false;
        public event EventHandler RowSelected;
        public event EventHandler DeleteContact;
        public event EventHandler<CustEventArgs> NumberClicked;
        public int RowNumber;

        #endregion
        /// <summary>
        /// Инициализируем строку для книги контактов со множеством подконтейнеров
        /// </summary>
        /// <param name="client">Пользователь</param>
        /// <param name="_RowNumber">Номер строки</param>
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        public ContactRow(ClientsData client, int _RowNumber)
        {
            _Client = client;
            RowNumber = _RowNumber;
            InitializeComponent();

            OnBLFBorder.MaximumSize = new Size(200, 47);
            OnBLFBorder.Dock = DockStyle.Fill;
            OnBLFBorder.Margin = new Padding(0, 3, 0, 0);
            OnBLFBorder.Padding = new Padding(0, 1, 0, 0);
            OnBLFBorder.BackColor = Color.Gray;

            onBLF.MaximumSize = new Size(200, 45);
            onBLF.Dock = DockStyle.Fill;
            onBLF.Parent = OnBLFBorder;
            onBLF.Margin = new Padding(0, 2, 0, 2);
            onBLF.Padding = new Padding(0);
            onBLF.BackColor = Color.LightGray;
            onBLF.MouseEnter += RowMouseEnter;
            onBLF.MouseClick += OnBLF_MouseClick;
            onBLF.MouseLeave += RowMouseLeave;
            if (_Client.onBLF)
            {
                onBLF.BackgroundImage = onBLFImage.Images[0];
                onBLF.BackgroundImageLayout = ImageLayout.Center;
            }
            else
            {
                onBLF.BackgroundImage = onBLFImage.Images[2];
                onBLF.BackgroundImageLayout = ImageLayout.Center;
            }

            PhotoBorder.MaximumSize = new Size(200, 47);
            PhotoBorder.Dock = DockStyle.Fill;
            PhotoBorder.Margin = new Padding(0, 3, 0, 0);
            PhotoBorder.Padding = new Padding(0, 1, 0, 0);
            PhotoBorder.BackColor = Color.Gray;

            PhotoPanel.MaximumSize = new Size(200, 45);
            PhotoPanel.Dock = DockStyle.Fill;
            PhotoPanel.Parent = PhotoBorder;
            PhotoPanel.Margin = new Padding(0, 2, 0, 2);
            PhotoPanel.Padding = new Padding(10, 0, 10, 0);
            PhotoPanel.BackColor = Color.LightGray;
            PhotoPanel.MouseEnter += RowMouseEnter;
            PhotoPanel.MouseClick += RowMouseClick;
            PhotoPanel.MouseLeave += RowMouseLeave;
            PhotoPanel.MouseDoubleClick += RowDoubleClick;

            innerPhoto.MaximumSize = new Size(200, 45);
            innerPhoto.Dock = DockStyle.Fill;
            innerPhoto.Parent = PhotoPanel;
            innerPhoto.Margin = new Padding(1, 0, 1, 0);
            innerPhoto.Padding = new Padding(1, 0, 1, 0);
            innerPhoto.BackColor = Color.Gray;
            innerPhoto.MouseEnter += RowMouseEnter;
            innerPhoto.MouseClick += RowMouseClick;
            innerPhoto.MouseLeave += RowMouseLeave;
            innerPhoto.MouseDoubleClick += RowDoubleClick;


            innerPhoto1.MaximumSize = new Size(200, 45);
            innerPhoto1.Dock = DockStyle.Fill;
            innerPhoto1.Parent = innerPhoto;
            innerPhoto1.Margin = new Padding(3);
            innerPhoto1.Padding = new Padding(3);
            innerPhoto1.BackColor = Color.White;
            innerPhoto1.MouseEnter += RowMouseEnter;
            innerPhoto1.MouseClick += RowMouseClick;
            innerPhoto1.MouseLeave += RowMouseLeave;
            innerPhoto1.MouseDoubleClick += RowDoubleClick;

            innerPhoto2.MaximumSize = new Size(200, 45);
            innerPhoto2.Dock = DockStyle.Fill;
            innerPhoto2.Parent = innerPhoto1;
            innerPhoto2.Margin = new Padding(0);
            innerPhoto2.Padding = new Padding(1);
            innerPhoto2.BackColor = Color.Gray;
            innerPhoto2.MouseEnter += RowMouseEnter;
            innerPhoto2.MouseClick += RowMouseClick;
            innerPhoto2.MouseLeave += RowMouseLeave;
            innerPhoto2.MouseDoubleClick += RowDoubleClick;


            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            ImageLoader img = new ImageLoader(_Client);
            if (img.IsImageExists())
            {
                photo.BackgroundImage = img.Load();
            }
            else photo.BackgroundImage = onBLFImage.Images[3];
            photo.Parent = innerPhoto2;
            photo.BackgroundImageLayout = ImageLayout.Stretch;
            photo.Dock = DockStyle.Fill;
            photo.MouseEnter += RowMouseEnter;
            photo.MouseLeave += RowMouseLeave;
            photo.MouseClick += RowMouseClick;
            photo.MouseDoubleClick += RowDoubleClick;



            NameBorder.MaximumSize = new Size(200, 47);
            NameBorder.Dock = DockStyle.Fill;
            NameBorder.Margin = new Padding(0, 3, 0, 0);
            NameBorder.Padding = new Padding(0, 1, 0, 0);
            NameBorder.BackColor = Color.Gray;

            NamePanel.MaximumSize = new Size(600, 45);
            NamePanel.Dock = DockStyle.Fill;
            NamePanel.Parent = NameBorder;
            NamePanel.Margin = new Padding(0, 2, 0, 2);
            NamePanel.Padding = new Padding(0);
            NamePanel.BackColor = Color.LightGray;
            NamePanel.MouseEnter += RowMouseEnter;
            NamePanel.MouseClick += RowMouseClick;
            NamePanel.MouseLeave += RowMouseLeave;
            NameLabel.Text = client.Name.Replace(" ", " \r\n");
            NameLabel.AutoEllipsis = true;
            NameLabel.Parent = NamePanel;
            NameLabel.AutoSize = false;
            NameLabel.Dock = DockStyle.Fill;
            NameLabel.Font = new Font("Century Gothic", 11);
            NameLabel.Padding = new Padding(3);
            NameLabel.TextAlign = ContentAlignment.TopLeft;
            NameLabel.MouseEnter += RowMouseEnter;
            NameLabel.MouseLeave += RowMouseLeave;
            NameLabel.MouseClick += RowMouseClick;
            NameLabel.MouseDoubleClick += RowDoubleClick;
            UserInterfaceAPI.InitFonts(NameLabel);


            ComapnyBorder.MaximumSize = new Size(200, 47);
            ComapnyBorder.Dock = DockStyle.Fill;
            ComapnyBorder.Margin = new Padding(0, 3, 0, 0);
            ComapnyBorder.Padding = new Padding(0, 1, 0, 0);
            ComapnyBorder.BackColor = Color.Gray;

            CompanyPanel.MaximumSize = new Size(200, 45);
            CompanyPanel.Dock = DockStyle.Fill;
            CompanyPanel.Parent = ComapnyBorder;
            CompanyPanel.Margin = new Padding(0, 2, 0, 2);
            CompanyPanel.Padding = new Padding(3);
            CompanyPanel.BackColor = Color.LightGray;
            CompanyPanel.MouseEnter += RowMouseEnter;
            CompanyPanel.MouseClick += RowMouseClick;
            CompanyPanel.MouseLeave += RowMouseLeave;
            CompanyPanel.MouseDoubleClick += RowDoubleClick;


            CompanyContainer.MaximumSize = new Size(150, 45);
            CompanyContainer.Dock = DockStyle.Fill;
            CompanyContainer.Parent = CompanyPanel;
            CompanyContainer.Margin = new Padding(0, 2, 0, 2);
            CompanyContainer.Padding = new Padding(3);
            CompanyContainer.BackColor = Color.FromArgb(153, 153, 153);
            CompanyContainer.MouseEnter += RowMouseEnter;
            CompanyContainer.MouseClick += RowMouseClick;
            CompanyContainer.MouseLeave += RowMouseLeave;
            CompanyContainer.MouseDoubleClick += RowDoubleClick;

            CompanyNameLabel.Font = new Font("Century Gothic", 12);
            if (!string.IsNullOrEmpty(client.organisation))
            {
                CompanyNameLabel.Text = client.organisation;
            }
            else
            {
                CompanyNameLabel.Text = "None";
            }
            CompanyNameLabel.Parent = CompanyContainer;
            CompanyNameLabel.Location = new Point(0, 8);
            CompanyNameLabel.Size = new Size(CompanyContainer.Width - 30, 20);
            CompanyNameLabel.BackColor = Color.FromArgb(153, 153, 153);
            CompanyNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            CompanyNameLabel.AutoEllipsis = true;
            CompanyNameLabel.AutoSize = false;
            CompanyNameLabel.MouseEnter += RowMouseEnter;
            CompanyNameLabel.MouseClick += RowMouseClick;
            CompanyNameLabel.MouseLeave += RowMouseLeave;
            CompanyNameLabel.MouseDoubleClick += RowDoubleClick;
            CompanyNameLabel.ForeColor = Color.White;
            UserInterfaceAPI.InitFonts(CompanyNameLabel);

            PhoneBorder.MaximumSize = new Size(200, 47);
            PhoneBorder.Dock = DockStyle.Fill;
            PhoneBorder.Margin = new Padding(0, 3, 0, 0);
            PhoneBorder.Padding = new Padding(0, 1, 0, 0);
            PhoneBorder.BackColor = Color.Gray;

            PhonePanel.MaximumSize = new Size(200, 45);
            PhonePanel.Dock = DockStyle.Fill;
            PhonePanel.Parent = PhoneBorder;
            PhonePanel.Margin = new Padding(0, 2, 0, 2);
            PhonePanel.Padding = new Padding(3);
            PhonePanel.BackColor = Color.LightGray;
            PhonePanel.MouseEnter += RowMouseEnter;
            PhonePanel.MouseClick += RowMouseClick;
            PhonePanel.MouseLeave += RowMouseLeave;
            PhonePanel.MouseDoubleClick += RowDoubleClick;
            FirstNumber.Font = new Font("Century Gothic", (float)11.25);
            FirstNumber.ForeColor = Color.White;
            if (!string.IsNullOrEmpty(client.Number))
            {
                FirstNumber.Text = client.Prefix + client.Number;
                call1.Text = "Позвонить на " + client.Number;
            }
            else
            {
                FirstNumber.Text = "None";
                contextMenuStrip1.Items.Remove(call1);
            }
            FirstNumber.Dock = DockStyle.Top;
            FirstNumber.MaximumSize = new Size(200, 18);
            FirstNumber.Parent = PhonePanel;
            FirstNumber.BackColor = Color.FromArgb(153, 153, 153);
            FirstNumber.TextAlign = ContentAlignment.TopCenter;
            FirstNumber.AutoEllipsis = true;
            FirstNumber.AutoSize = false;
            FirstNumber.Cursor = Cursors.Hand;
            FirstNumber.MouseEnter += Number_MouseEnter;
            FirstNumber.MouseClick += FirstNumber_MouseClick;
            FirstNumber.MouseLeave += Number_MouseLeave;
            UserInterfaceAPI.InitFonts(FirstNumber);

            SecondNumber.Font = new Font("Century Gothic", (float)11.25);
            SecondNumber.ForeColor = Color.White;
            if (!string.IsNullOrEmpty(client.SecondNumber))
            {
                SecondNumber.Text = client.SecondNumber;
                call2.Text = "Позвонить на " + client.SecondNumber;
            }
            else
            {
                SecondNumber.Text = "None";
                contextMenuStrip1.Items.Remove(call2);
            }
            SecondNumber.Dock = DockStyle.Bottom;
            SecondNumber.MaximumSize = new Size(200, 18);
            SecondNumber.Cursor = Cursors.Hand;
            SecondNumber.Parent = PhonePanel;
            SecondNumber.BackColor = Color.FromArgb(153, 153, 153);
            SecondNumber.TextAlign = ContentAlignment.TopCenter;
            SecondNumber.AutoEllipsis = true;
            SecondNumber.AutoSize = false;
            SecondNumber.MouseEnter += Number_MouseEnter;
            SecondNumber.MouseClick += FirstNumber_MouseClick;
            SecondNumber.MouseLeave += Number_MouseLeave;
            UserInterfaceAPI.InitFonts(SecondNumber);

            EmailBorder.MaximumSize = new Size(200, 47);
            EmailBorder.Dock = DockStyle.Fill;
            EmailBorder.Margin = new Padding(0, 3, 0, 0);
            EmailBorder.Padding = new Padding(0, 1, 0, 0);
            EmailBorder.BackColor = Color.Gray;

            EmailPanel.MaximumSize = new Size(200, 45);
            EmailPanel.Dock = DockStyle.Fill;
            EmailPanel.Margin = new Padding(0, 2, 0, 2);
            EmailPanel.Padding = new Padding(3);
            EmailPanel.Parent = EmailBorder;
            EmailPanel.BackColor = Color.LightGray;
            EmailPanel.MouseEnter += RowMouseEnter;
            EmailPanel.MouseClick += EmailPanel_MouseClick;
            EmailPanel.MouseLeave += RowMouseLeave;
            EmailPanel.MouseDoubleClick += RowDoubleClick;

            EmailConntainer.Parent = EmailPanel;
            EmailConntainer.MaximumSize = new Size(200, 45);
            EmailConntainer.Dock = DockStyle.Fill;
            EmailConntainer.Margin = new Padding(0);
            EmailConntainer.Padding = new Padding(0);
            EmailConntainer.BackgroundImage = Resources.mail_off;
            EmailConntainer.BackgroundImageLayout = ImageLayout.Stretch;
            EmailConntainer.BackColor = Color.LightGray;
            EmailConntainer.MouseEnter += RowMouseEnter;
            EmailConntainer.MouseClick += EmailPanel_MouseClick;
            EmailConntainer.MouseLeave += RowMouseLeave;
            EmailConntainer.Cursor = Cursors.Hand;


            EmailLabel.Parent = EmailConntainer;
            EmailLabel.Cursor = Cursors.Hand;
            EmailLabel.Font = new Font("Century Gothic", (float)8.75);
            EmailLabel.ForeColor = Color.White;
            if (!string.IsNullOrEmpty(client.email))
            {
                EmailLabel.Text = client.email;
            }
            else
            {
                EmailLabel.Text = "None";
            }
            EmailLabel.Dock = DockStyle.Bottom;
            EmailLabel.MaximumSize = new Size(200, 18);
            EmailLabel.BackColor = Color.FromArgb(153, 153, 153);
            EmailLabel.TextAlign = ContentAlignment.BottomCenter;
            EmailLabel.AutoEllipsis = true;
            EmailLabel.AutoSize = false;
            EmailLabel.MouseEnter += RowMouseEnter;
            EmailLabel.MouseClick += EmailPanel_MouseClick;
            EmailLabel.MouseLeave += RowMouseLeave;
            UserInterfaceAPI.InitFonts(EmailLabel);

            Localization = Localizator.GetFormLocalization("ContactRow", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            Localizator.MakeLocalizationAllContextMenu(contextMenuStrip1, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            if (!string.IsNullOrEmpty(client.SecondNumber))
            {
                SecondNumber.Text = client.SecondNumber;
                try
                {
                    call2.Text = Localization[call2.Name][0] + client.SecondNumber;
                }
                catch
                {
                    call2.Text = "Позвонить на " + client.SecondNumber;
                }
            }
            else
            {
                SecondNumber.Text = "None";
                contextMenuStrip1.Items.Remove(call2);
            }

            if (!string.IsNullOrEmpty(client.Number))
            {
                FirstNumber.Text = client.Prefix + client.Number;
                try
                {
                    call1.Text = Localization[call1.Name][0] + client.Number;
                }
                catch
                {
                    call1.Text = "Позвонить на " + client.Number;
                }
            }
            else
            {
                SecondNumber.Text = "None";
                contextMenuStrip1.Items.Remove(call1);
            }
            //if (!string.IsNullOrEmpty(client.Number))
            //{
            //    FirstNumber.Text = client.Prefix + client.Number;
            //    call1.Text = "Позвонить на " + client.Number;
            //}
            //else
            //{
            //    FirstNumber.Text = "None";
            //    contextMenuStrip1.Items.Remove(call1);
            //}
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization("ContactRow", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            Localizator.MakeLocalizationAllContextMenu(contextMenuStrip1, Localization);

            if (!string.IsNullOrEmpty(_Client.SecondNumber))
            {
                SecondNumber.Text = _Client.SecondNumber;
                try
                {
                    call2.Text = Localization[call2.Name][0] + _Client.SecondNumber;
                }
                catch
                {
                    call2.Text = "Позвонить на " + _Client.SecondNumber;
                }
            }
            else
            {
                SecondNumber.Text = "None";
                contextMenuStrip1.Items.Remove(call2);
            }

            if (!string.IsNullOrEmpty(_Client.Number))
            {
                FirstNumber.Text = _Client.Prefix + _Client.Number;
                try
                {
                    call1.Text = Localization[call1.Name][0] + _Client.Number;
                }
                catch
                {
                    call1.Text = "Позвонить на " + _Client.Number;
                }
            }
            else
            {
                SecondNumber.Text = "None";
                contextMenuStrip1.Items.Remove(call1);
            }
        }

        private void EmailPanel_MouseClick(object sender, MouseEventArgs e)
        {
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = string.Format("mailto:" + _Client.email + "?subject=" + "&body=Created with B-CTI");
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.RedirectStandardOutput = false;
            proc.Start();
        }

        public void SwapRow(ContactRow _Row)
        {
            _Client = _Row._Client;
            Selected = _Row.Selected;
            UpdateData();
        }
        private void UpdateData()
        {
            NameLabel.Text = _Client.Name.Replace(" ", "\r\n");
            if (_Client.onBLF)
            {
                if (!Selected)
                    onBLF.BackgroundImage = onBLFImage.Images[0];
                else
                {
                    onBLF.BackgroundImage = onBLFImage.Images[1];
                }
            }
            else
            {
                onBLF.BackgroundImage = onBLFImage.Images[2];
            }

            ImageLoader img = new ImageLoader(_Client);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (img.IsImageExists())
            {
                photo.BackgroundImage = img.Load();
            }
            else photo.BackgroundImage = onBLFImage.Images[3];

            if (!string.IsNullOrEmpty(_Client.organisation))
            {
                CompanyNameLabel.Text = _Client.organisation;
            }
            else
            {
                CompanyNameLabel.Text = "None";
            }
            if (!string.IsNullOrEmpty(_Client.Number))
            {
                FirstNumber.Text = _Client.Prefix + _Client.Number;
            }
            else
            {
                FirstNumber.Text = "None";
            }
            if (!string.IsNullOrEmpty(_Client.SecondNumber))
            {
                SecondNumber.Text = _Client.SecondNumber;
            }
            else
            {
                SecondNumber.Text = "None";
            }
            if (!string.IsNullOrEmpty(_Client.email))
            {
                EmailLabel.Text = _Client.email;
            }
            else
            {
                EmailLabel.Text = "None";
            }
        }


        #region ClickHandlers
        private void RowDoubleClick(object sender, MouseEventArgs e)
        {
            if (!Selected)
            {
                if (RowSelected != null)
                {
                    RowSelected(this, e);
                }
                if (_Client.onBLF)
                {
                    onBLF.BackgroundImage = onBLFImage.Images[1];
                }

                CompanyNameLabel.BackColor = Color.FromArgb(102, 153, 255);
                CompanyContainer.BackColor = Color.FromArgb(102, 153, 255);
                FirstNumber.BackColor = Color.FromArgb(102, 153, 255);
                SecondNumber.BackColor = Color.FromArgb(102, 153, 255);
                EmailConntainer.BackgroundImage = Resources.mail_clicked;
                EmailPanel.BackColor = Color.FromArgb(204, 204, 255);
                PhonePanel.BackColor = Color.FromArgb(204, 204, 255);
                CompanyPanel.BackColor = Color.FromArgb(204, 204, 255);
                NamePanel.BackColor = Color.FromArgb(204, 204, 255);
                PhotoPanel.BackColor = Color.FromArgb(204, 204, 255);
                onBLF.BackColor = Color.FromArgb(204, 204, 255);
                EmailLabel.BackColor = Color.FromArgb(102, 153, 255);
                Selected = true;
            }
            AddToBook ATB = new AddToBook(_Client);
            ATB.ShowDialog(this);
            _Client = ATB.newClient;
            UpdateData();
        }
        private void FirstNumber_MouseClick(object sender, MouseEventArgs e)
        {
            Label l = sender as Label;
            if (l.Text != "None")
                if (NumberClicked != null)
                    NumberClicked(this, new CustEventArgs(l.Text));
        }

        private void Number_MouseLeave(object sender, EventArgs e)
        {
            Label l = sender as Label;
            if (Selected)
            {
                l.BackColor = Colors.WhiteTheme.ButtonHover;
            }
            else
            {
                l.BackColor = Color.FromArgb(153, 153, 153);
            }
            if (!Selected)
            {
                EmailPanel.BackColor = Color.LightGray;
                PhonePanel.BackColor = Color.LightGray;
                CompanyPanel.BackColor = Color.LightGray;
                NamePanel.BackColor = Color.LightGray;
                PhotoPanel.BackColor = Color.LightGray;
                onBLF.BackColor = Color.LightGray;
            }
        }

        private void Number_MouseEnter(object sender, EventArgs e)
        {
            Label l = sender as Label;
            l.BackColor = Color.FromArgb(0, 45, 146);
            if (!Selected)
            {
                EmailPanel.BackColor = Color.FromArgb(240, 240, 240);
                PhonePanel.BackColor = Color.FromArgb(240, 240, 240);
                CompanyPanel.BackColor = Color.FromArgb(240, 240, 240);
                NamePanel.BackColor = Color.FromArgb(240, 240, 240);
                PhotoPanel.BackColor = Color.FromArgb(240, 240, 240);
                onBLF.BackColor = Color.FromArgb(240, 240, 240);
            }
        }
        /// <summary>
        /// Клик по строке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!Selected)
                {
                    if (RowSelected != null)
                    {
                        RowSelected(this, e);
                    }
                    if (_Client.onBLF)
                    {
                        onBLF.BackgroundImage = onBLFImage.Images[1];
                    }

                    CompanyNameLabel.BackColor = Color.FromArgb(102, 153, 255);
                    CompanyContainer.BackColor = Color.FromArgb(102, 153, 255);
                    FirstNumber.BackColor = Color.FromArgb(102, 153, 255);
                    SecondNumber.BackColor = Color.FromArgb(102, 153, 255);
                    EmailConntainer.BackgroundImage = Resources.mail_clicked;
                    EmailPanel.BackColor = Color.FromArgb(204, 204, 255);
                    PhonePanel.BackColor = Color.FromArgb(204, 204, 255);
                    CompanyPanel.BackColor = Color.FromArgb(204, 204, 255);
                    NamePanel.BackColor = Color.FromArgb(204, 204, 255);
                    PhotoPanel.BackColor = Color.FromArgb(204, 204, 255);
                    onBLF.BackColor = Color.FromArgb(204, 204, 255);
                    EmailLabel.BackColor = Color.FromArgb(102, 153, 255);
                    Selected = true;
                }
                contextMenuStrip1.Show(MousePosition);
            }
            if (e.Button == MouseButtons.Left)
                if (!Selected)
                {
                    if (RowSelected != null)
                    {
                        RowSelected(this, e);
                    }
                    if (_Client.onBLF)
                    {
                        onBLF.BackgroundImage = onBLFImage.Images[1];
                    }

                    CompanyNameLabel.BackColor = Color.FromArgb(102, 153, 255);
                    CompanyContainer.BackColor = Color.FromArgb(102, 153, 255);
                    FirstNumber.BackColor = Color.FromArgb(102, 153, 255);
                    SecondNumber.BackColor = Color.FromArgb(102, 153, 255);
                    EmailConntainer.BackgroundImage = Resources.mail_clicked;
                    EmailPanel.BackColor = Color.FromArgb(204, 204, 255);
                    PhonePanel.BackColor = Color.FromArgb(204, 204, 255);
                    CompanyPanel.BackColor = Color.FromArgb(204, 204, 255);
                    NamePanel.BackColor = Color.FromArgb(204, 204, 255);
                    PhotoPanel.BackColor = Color.FromArgb(204, 204, 255);
                    onBLF.BackColor = Color.FromArgb(204, 204, 255);
                    EmailLabel.BackColor = Color.FromArgb(102, 153, 255);
                    Selected = true;
                }
                else
                {
                    if (_Client.onBLF)
                    {
                        onBLF.BackgroundImage = onBLFImage.Images[0];
                    }
                    EmailPanel.BackColor = Color.LightGray;
                    PhonePanel.BackColor = Color.LightGray;
                    CompanyPanel.BackColor = Color.LightGray;
                    NamePanel.BackColor = Color.LightGray;
                    PhotoPanel.BackColor = Color.LightGray;
                    onBLF.BackColor = Color.LightGray;
                    CompanyNameLabel.BackColor = Color.FromArgb(153, 153, 153);
                    CompanyContainer.BackColor = Color.FromArgb(153, 153, 153);
                    FirstNumber.BackColor = Color.FromArgb(153, 153, 153);
                    SecondNumber.BackColor = Color.FromArgb(153, 153, 153);
                    EmailConntainer.BackgroundImage = Resources.mail_off;
                    EmailLabel.BackColor = Color.FromArgb(153, 153, 153);
                    Selected = false;
                }

        }
        #endregion

        private void RowMouseLeave(object sender, EventArgs e)
        {
            if (!Selected)
            {
                EmailPanel.BackColor = Color.LightGray;
                PhonePanel.BackColor = Color.LightGray;
                CompanyPanel.BackColor = Color.LightGray;
                NamePanel.BackColor = Color.LightGray;
                PhotoPanel.BackColor = Color.LightGray;
                onBLF.BackColor = Color.LightGray;
            }
        }

        private void RowMouseEnter(object sender, EventArgs e)
        {
            if (!Selected)
            {

                EmailPanel.BackColor = Color.FromArgb(240, 240, 240);
                PhonePanel.BackColor = Color.FromArgb(240, 240, 240);
                CompanyPanel.BackColor = Color.FromArgb(240, 240, 240);
                NamePanel.BackColor = Color.FromArgb(240, 240, 240);
                PhotoPanel.BackColor = Color.FromArgb(240, 240, 240);
                onBLF.BackColor = Color.FromArgb(240, 240, 240);
            }

        }
        private void OnBLF_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                _Client.onBLF = !_Client.onBLF;
                if (_Client.onBLF)
                {
                    if (!Selected)
                        onBLF.BackgroundImage = onBLFImage.Images[0];
                    else
                        onBLF.BackgroundImage = onBLFImage.Images[1];
                }
                else
                {
                    onBLF.BackgroundImage = onBLFImage.Images[2];
                }
            }

        }
        #region Select/Deselect

        public void DisableRow()
        {
            EmailPanel.Enabled = false;
            PhonePanel.Enabled = false;
            CompanyPanel.Enabled = false;
            NamePanel.Enabled = false;
            PhotoPanel.Enabled = false;
            onBLF.Enabled = false;
            EmailPanel.BackColor = Color.Gray;
            PhonePanel.BackColor = Color.Gray;
            CompanyPanel.BackColor = Color.Gray;
            NamePanel.BackColor = Color.Gray;
            PhotoPanel.BackColor = Color.Gray;
            onBLF.BackColor = Color.Gray;
        }
        public void HideRow()
        {
            EmailBorder.Hide();
            PhoneBorder.Hide();
            ComapnyBorder.Hide();
            NameBorder.Hide();
            PhotoBorder.Hide();
            OnBLFBorder.Hide();
        }
        public void ShowRow()
        {
            EmailBorder.Show();
            PhoneBorder.Show();
            ComapnyBorder.Show();
            NameBorder.Show();
            PhotoBorder.Show();
            OnBLFBorder.Show();
        }
        public void EnableRow()
        {
            EmailPanel.Enabled = true;
            PhonePanel.Enabled = true;
            CompanyPanel.Enabled = true;
            NamePanel.Enabled = true;
            PhotoPanel.Enabled = true;
            onBLF.Enabled = true;
            EmailPanel.BackColor = Color.LightGray;
            PhonePanel.BackColor = Color.LightGray;
            CompanyPanel.BackColor = Color.LightGray;
            NamePanel.BackColor = Color.LightGray;
            PhotoPanel.BackColor = Color.LightGray;
            onBLF.BackColor = Color.LightGray;
        }
        public void Deselect()
        {

            Selected = !Selected;
            if (_Client.onBLF)
            {
                onBLF.BackgroundImage = onBLFImage.Images[0];
            }
            EmailPanel.BackColor = Color.LightGray;
            PhonePanel.BackColor = Color.LightGray;
            CompanyPanel.BackColor = Color.LightGray;
            NamePanel.BackColor = Color.LightGray;
            PhotoPanel.BackColor = Color.LightGray;
            onBLF.BackColor = Color.LightGray;
            CompanyNameLabel.BackColor = Color.FromArgb(153, 153, 153);
            CompanyContainer.BackColor = Color.FromArgb(153, 153, 153);
            FirstNumber.BackColor = Color.FromArgb(153, 153, 153);
            SecondNumber.BackColor = Color.FromArgb(153, 153, 153);
            EmailConntainer.BackgroundImage = Resources.mail_off;
            EmailLabel.BackColor = Color.FromArgb(153, 153, 153);
        }
        public void SelectRow()
        {
            if (_Client.onBLF)
            {
                onBLF.BackgroundImage = onBLFImage.Images[1];
            }

            CompanyNameLabel.BackColor = Color.FromArgb(102, 153, 255);
            CompanyContainer.BackColor = Color.FromArgb(102, 153, 255);
            FirstNumber.BackColor = Color.FromArgb(102, 153, 255);
            SecondNumber.BackColor = Color.FromArgb(102, 153, 255);
            EmailConntainer.BackgroundImage = Resources.mail_clicked;
            EmailPanel.BackColor = Color.FromArgb(204, 204, 255);
            PhonePanel.BackColor = Color.FromArgb(204, 204, 255);
            CompanyPanel.BackColor = Color.FromArgb(204, 204, 255);
            NamePanel.BackColor = Color.FromArgb(204, 204, 255);
            PhotoPanel.BackColor = Color.FromArgb(204, 204, 255);
            onBLF.BackColor = Color.FromArgb(204, 204, 255);
            EmailLabel.BackColor = Color.FromArgb(102, 153, 255);
            Selected = true;
        }
        #endregion
        #region ContextMenu

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToBook ATB = new AddToBook(_Client);
            ATB.added = true;
            bool match = true;
            while (ATB.added && match)
            {
                ATB.ShowDialog(this);
                match = false;
                ClientsData tempContact = new ClientsData();
                tempContact.ID = ATB.newClient.ID;
                if (ATB.newClient.Name != "")
                {
                    tempContact = ATB.newClient;
                    for (int i = 0; i < BLFPanel.BookOfContacts.Count; i++)
                    {
                        if (BLFPanel.BookOfContacts[i].Number.ToLower().Equals(tempContact.Number.ToLower()) && BLFPanel.BookOfContacts[i].Prefix.ToLower().Equals(tempContact.Prefix.ToLower()) && BLFPanel.BookOfContacts[i].ID != tempContact.ID)
                        {
                            match = true;
                            break;
                        }
                        else if (BLFPanel.BookOfContacts[i].SecondNumber.ToLower().Equals(tempContact.SecondNumber.ToLower()) && !string.IsNullOrEmpty(BLFPanel.BookOfContacts[i].SecondNumber) && BLFPanel.BookOfContacts[i].ID != tempContact.ID)
                        {
                            match = true;
                            break;

                        }
                    }
                    if (!match)
                    {
                        _Client = ATB.newClient;
                        UpdateData();
                    }
                    else
                    {
                        if (ATB.added)
                            BMessageBox.Show("Контакт с таким номером уже существует");
                        ATB.newClient = tempContact;
                    }
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult delete = BMessageBox.Show(this, "Вы действительно хотите удалить " + _Client.Name, "Удалить?", BMessageBoxButtons.YesNo);
            if (delete == DialogResult.Yes)
            {
                DeleteContact?.Invoke(this, e);
            }
        }

        private void call2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem i = sender as ToolStripMenuItem;
            string Number = i.Text.Replace("Позвонить на ", "");
            NumberClicked?.Invoke(this, new CustEventArgs(Number));
        }
        #endregion
    }
}
