using System;
using System.Drawing;
using System.Windows.Forms;
using AsteriskManager;
using System.Collections.Generic;
using BCTI.Helpers;

namespace BCTI.CustomControls
{
    public partial class HiddenSplash : UserControl
    {
        CallManager Manager;
        ClientsData client;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        /// <summary>
        /// Конструктор свернутого сплеша
        /// </summary>
        /// <param name="_manager">Информация о звонке</param>
        /// <param name="contact">Информация о клиенте</param>
        /// <param name="callduration">Текущее время звонка</param>
        public HiddenSplash(CallManager _manager, ClientsData contact, int callduration)
        {
            Manager = _manager;
            client = contact;
            InitializeComponent();
            InitFonts();

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            Localizator.MakeLocalizationAllContextMenu(contextMenuStrip1, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            InitClient();
            TimeSpan duration = new TimeSpan(0, 0, callduration);
            Time.Text = duration.ToString();
            if (Manager.Type == CallType.OutcomingCall)
            {
                Avatar.BackgroundImage = Properties.Resources.outgoing;
            }
            else if (Manager.Type == CallType.IncomingCall)
            {
                Avatar.BackgroundImage = Properties.Resources.incoming;
            }
            for (int i = 0; i < BLFPanel.BookOfContacts.Count; i++)
            {
                if (BLFPanel.BookOfContacts[i].ID != client.ID)
                {
                    ToolStripMenuItem subItem1 = new ToolStripMenuItem(BLFPanel.BookOfContacts[i].Number);
                    subItem1.Font = toolStripTextBox1.Font;
                    subItem1.Click += SubItem1_Click;
                    ((ToolStripDropDownMenu)subItem1.DropDown).ShowImageMargin = false;
                    ToolStripMenuItem temp;
                    if (!string.IsNullOrEmpty(BLFPanel.BookOfContacts[i].SecondNumber))
                    {
                        ToolStripMenuItem subItem2 = new ToolStripMenuItem(BLFPanel.BookOfContacts[i].SecondNumber);
                        subItem2.Click += SubItem1_Click;
                        subItem2.Font = toolStripTextBox1.Font;
                        ((ToolStripDropDownMenu)subItem2.DropDown).ShowImageMargin = false;
                        temp = new ToolStripMenuItem(BLFPanel.BookOfContacts[i].Name, null, new ToolStripItem[] { subItem1, subItem2 });
                        temp.Font = toolStripTextBox1.Font;
                        ImageLoader img = new ImageLoader(BLFPanel.BookOfContacts[i]);
                        temp.ImageAlign = ContentAlignment.MiddleCenter;
                        if (img.IsImageExists())
                        {
                            temp.Image = img.Load();
                        }
                        else temp.Image = BCTI.Properties.Resources.no_photo;
                    }
                    else
                    {
                        temp = new ToolStripMenuItem(BLFPanel.BookOfContacts[i].Name, null, subItem1);
                        temp.Font = toolStripTextBox1.Font;
                        ImageLoader img = new ImageLoader(BLFPanel.BookOfContacts[i]);
                        temp.BackgroundImageLayout = ImageLayout.Zoom;

                        if (img.IsImageExists())
                        {
                            temp.Image = img.Load();
                        }
                        else temp.Image = BCTI.Properties.Resources.no_photo;
                    }
                    переводToolStripMenuItem.DropDownItems.Insert(0, temp);
                }
            }
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            Localizator.MakeLocalizationAllContextMenu(contextMenuStrip1, Localization);
        }

        private void InitFonts()
        {
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.InitFonts(UserName);
            UserInterfaceAPI.SetFontStyle(UserName, FontStyle.Italic);
        }
        public void InitClient()
        {
            UserName.Text = Manager.Number + " (" + client.Name + ")";
        }
        public void TimerTick(int _seconds)
        {
            TimeSpan duration = new TimeSpan(0, 0, _seconds);
            Time.Text = duration.ToString();
        }
        private void Hangup_Click(object sender, EventArgs e)
        {
            Manager.Hangup();
        }

        private void Hangup_MouseEnter(object sender, EventArgs e)
        {
            Hangup.BackColor = Colors.WhiteTheme.Red;
            Hangup.ForeColor = SystemColors.ControlDarkDark;
            this.BackColor = SystemColors.ControlLight;
        }

        private void Hangup_MouseLeave(object sender, EventArgs e)
        {
            Hangup.BackColor = Color.White;
            Hangup.ForeColor = Colors.WhiteTheme.MainColor;
            this.BackColor = SystemColors.ControlLightLight;
        }

        private void SubItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem temp = (ToolStripMenuItem)sender;
            string TransferingNumber = temp.Text;
            Manager.AMI.Redirect(client.Number, TransferingNumber);
        }
        private void Time_MouseEnter(object sender, EventArgs e)
        {
            Hangup.BackColor = Colors.WhiteTheme.Red;
            Hangup.ForeColor = Color.White;
            this.BackColor = SystemColors.ControlLight;
        }

        private void Time_MouseLeave(object sender, EventArgs e)
        {
            Hangup.BackColor = Color.White;
            Hangup.ForeColor = Colors.WhiteTheme.MainColor;
            this.BackColor = SystemColors.ControlLightLight;
        }

        private void Time_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
            }
            else
            {
                Manager.ShowSplash();
            }
        }

        private void скриптToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manager.Script();
        }
    }
}
