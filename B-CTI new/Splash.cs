using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using AsteriskManager;
using System.Collections.Generic;
using BCTI.Helpers;

namespace BCTI
{
    public partial class Splash : Form
    {
        public ClientsData client = new ClientsData();
        public CallType ringType;
        public bool calling = false;
        public bool holding = false;
        public DialData dialInfo = null;
        public bool fromApp = false;
        TimeSpan callTImer = new TimeSpan(0, 0, 0, 0, 0);
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();

        CallManager Manager;

        public Splash(CallManager call)
        {
            Manager = call;
            this.ringType = Manager.Type;
            InitializeComponent();

            Localization = Localizator.GetFormLocalization("Splash", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            try
            {

                timeLabel.Text = Localization[timeLabel.Name][0] +
                                 (Manager.callStart.Hour % 10 == Manager.callStart.Hour
                                     ? "0" + Manager.callStart.Hour.ToString()
                                     : Manager.callStart.Hour.ToString()) + ":" +
                                 (Manager.callStart.Minute % 10 == Manager.callStart.Minute
                                     ? "0" + Manager.callStart.Minute.ToString()
                                     : Manager.callStart.Minute.ToString()) + ":" +
                                 (Manager.callStart.Second % 10 == Manager.callStart.Second
                                     ? "0" + Manager.callStart.Second.ToString()
                                     : Manager.callStart.Second.ToString());
            }
            catch (Exception)
            {
                timeLabel.Text = "Время: " +
           (Manager.callStart.Hour % 10 == Manager.callStart.Hour ? "0" + Manager.callStart.Hour.ToString() : Manager.callStart.Hour.ToString()) + ":" +
           (Manager.callStart.Minute % 10 == Manager.callStart.Minute ? "0" + Manager.callStart.Minute.ToString() : Manager.callStart.Minute.ToString()) + ":" +
           (Manager.callStart.Second % 10 == Manager.callStart.Second ? "0" + Manager.callStart.Second.ToString() : Manager.callStart.Second.ToString());
            }

            InitFonts();

            closeButton.BackgroundImage = closeButtonImage.Images[0];
        }

        private void InitFonts()
        {
            UserInterfaceAPI.InitFonts(this);
            infoLabel.Font = new Font(infoLabel.Font, FontStyle.Bold);
            timeLabel.Font = new Font(timeLabel.Font, FontStyle.Bold);
            numberLabel.Font = new Font(numberLabel.Font, FontStyle.Bold);
            CmdLabel.Font = new Font(CmdLabel.Font, FontStyle.Bold);
            HoldLabel.Font = new Font(HoldLabel.Font, FontStyle.Bold);
            ConferenceLabel.Font = new Font(ConferenceLabel.Font, FontStyle.Bold);
            BlindTransferLabel.Font = new Font(BlindTransferLabel.Font, FontStyle.Bold);
            TransferLabel.Font = new Font(TransferLabel.Font, FontStyle.Bold);
            HangupLabel.Font = new Font(HangupLabel.Font, FontStyle.Bold);
        }

        public void TimerTick(int _seconds)
        {
            TimeSpan duration = new TimeSpan(0, 0, _seconds);
            durationLabel.Text = duration.ToString();
        }

        public void InitClient()
        {
            nameLabel.Text = Manager.Number;
            if (!string.IsNullOrEmpty(Manager.Number))
                if (!Disposing && !IsDisposed)
                {
                    HangupPanel.BackgroundImage = Images.Images[11];
                }

            try
            {
                if (ringType == CallType.OutcomingCall)
                    numberLabel.Text = Localization[numberLabel.Name][0];
                else if (ringType == CallType.IncomingCall) numberLabel.Text = Localization[numberLabel.Name][1];

            }
            catch (Exception)
            {
                if (ringType == CallType.OutcomingCall)
                    numberLabel.Text = "Исходящий вызов";
                else if (ringType == CallType.IncomingCall) numberLabel.Text = "Входящий вызов";
            }

            if (string.IsNullOrEmpty(client.Name))
            {
                if (!Disposing && !IsDisposed)
                {
                    avatarBox.BackgroundImage = Images.Images[19];
                }

            }
            else
                if (!Disposing && !IsDisposed)
            {
                avatarBox.BackgroundImage = Images.Images[19];
            }

            try
            {
                if (string.IsNullOrEmpty(client.Name))
                {
                    CreateContactLabel.Text = Localization[CreateContactLabel.Name][0];
                }
                else CreateContactLabel.Text = Localization[CreateContactLabel.Name][1];
            }
            catch (Exception)
            {
                if (string.IsNullOrEmpty(client.Name))
                {
                    CreateContactLabel.Text = "Создать контакт";
                }
                else CreateContactLabel.Text = "Изменить контакт";
            }

            if (!string.IsNullOrEmpty(client.organisation))
                organisationLabel.Text = client.organisation;
            try
            {

                if (!string.IsNullOrEmpty(client.Name))
                    infoLabel.Text = client.Name;
                else infoLabel.Text = Localization[infoLabel.Name][0];
            }
            catch (Exception)
            {
                if (!string.IsNullOrEmpty(client.Name))
                    infoLabel.Text = client.Name;
                else infoLabel.Text = "Неизвестный абонент";
            }

            ImageLoader img = new ImageLoader(client);
            if (img.IsImageExists())
            {
                avatarBox.BackgroundImage = img.Load();
            }
            for (int i = 0; i < BLFPanel.BookOfContacts.Count; i++)
            {
                if (BLFPanel.BookOfContacts[i].ID != client.ID)
                {
                    ToolStripMenuItem subItem1 = new ToolStripMenuItem(BLFPanel.BookOfContacts[i].Number);
                    subItem1.Font = toolStripTextBox1.Font;
                    subItem1.Click += SubItem1_Click;
                    ToolStripMenuItem temp;
                    if (!string.IsNullOrEmpty(BLFPanel.BookOfContacts[i].SecondNumber))
                    {
                        ToolStripMenuItem subItem2 = new ToolStripMenuItem(BLFPanel.BookOfContacts[i].SecondNumber);
                        subItem2.Click += SubItem1_Click;
                        subItem2.Font = toolStripTextBox1.Font;
                        temp = new ToolStripMenuItem(BLFPanel.BookOfContacts[i].Name, null, new ToolStripItem[] { subItem1, subItem2 });
                        temp.Font = toolStripTextBox1.Font;
                    }
                    else
                    {
                        temp = new ToolStripMenuItem(BLFPanel.BookOfContacts[i].Name, null, subItem1);
                        temp.Font = toolStripTextBox1.Font;
                    }
                    ImageLoader img2 = new ImageLoader(BLFPanel.BookOfContacts[i]);
                    temp.BackgroundImageLayout = ImageLayout.Zoom;

                    if (img2.IsImageExists())
                    {
                        temp.Image = img2.Load();
                    }
                    else temp.Image = BCTI.Properties.Resources.no_photo;
                    RedirectMenuStrip.Items.Insert(1, temp);

                    ToolStripMenuItem subItem3 = new ToolStripMenuItem(BLFPanel.BookOfContacts[i].Number);
                    subItem3.Font = toolStripTextBox1.Font;
                    subItem3.Click += SubItem3_Click;
                    ToolStripMenuItem temp2;
                    if (!string.IsNullOrEmpty(BLFPanel.BookOfContacts[i].SecondNumber))
                    {
                        ToolStripMenuItem subItem4 = new ToolStripMenuItem(BLFPanel.BookOfContacts[i].SecondNumber);
                        subItem4.Click += SubItem3_Click;
                        subItem4.Font = toolStripTextBox1.Font;
                        temp2 = new ToolStripMenuItem(BLFPanel.BookOfContacts[i].Name, null, new ToolStripItem[] { subItem3, subItem4 });
                        temp2.Font = toolStripTextBox1.Font;
                    }
                    else
                    {
                        temp2 = new ToolStripMenuItem(BLFPanel.BookOfContacts[i].Name, null, subItem3);
                        temp2.Font = toolStripTextBox1.Font;
                    }
                    ImageLoader img3 = new ImageLoader(BLFPanel.BookOfContacts[i]);
                    temp2.BackgroundImageLayout = ImageLayout.Zoom;

                    if (img3.IsImageExists())
                    {
                        temp2.Image = img3.Load();
                    }
                    else temp2.Image = BCTI.Properties.Resources.no_photo;
                    NotBlindRedirectMenuStrip.Items.Insert(1, temp2);
                }
                toolStripTextBox2.KeyDown += ToolStripTextBox2_KeyDown;
                toolStripTextBox2.Click += toolStripTextBox1_Click;
                toolStripTextBox2.MouseEnter += toolStripTextBox1_MouseEnter;
                toolStripTextBox2.MouseLeave += toolStripTextBox1_MouseLeave;
            }
        }

        private void ToolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (toolStripTextBox2.Text == "" && prevFilter == "Номер" ||
    toolStripTextBox2.Text == "Номер" && prevFilter == "")
            {
                prevFilter = toolStripTextBox2.Text;
                return;
            }
            if (e.KeyData == Keys.Enter)
            {
                string TransferingNumber = toolStripTextBox2.Text;
                Manager.NotBlindRedirect(nameLabel.Text, TransferingNumber);
                //Manager.AMI.Redirect(client.Number, TransferingNumber);
            }
        }

        private void SubItem3_Click(object sender, EventArgs e)
        {
            var temp = sender as ToolStripMenuItem;
            Manager.NotBlindRedirect(numberLabel.Text, temp.Text);
        }

        public void LastCall(string date)
        {
            try
            {
                whenBox.Text = Localization[whenBox.Name][1] + date;
            }
            catch (Exception)
            {
                whenBox.Text = "Последний вызов " + date;
            }
        }

        public void SetLocation(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        public void change_client(ClientsData client)
        {
            if (!Disposing && !IsDisposed)
                Invoke((MethodInvoker)(() =>
            {
                this.client = client;
                infoLabel.Text = client.Name;
                if (!string.IsNullOrEmpty(client.Number))
                    if (!Disposing && !IsDisposed)
                    {
                        HangupPanel.BackgroundImage = Images.Images[11];
                    }
                if (string.IsNullOrEmpty(client.Name))
                {
                    if (!Disposing && !IsDisposed)
                    {
                        avatarBox.BackgroundImage = Images.Images[19];
                    }
                }
                else
                    if (!Disposing && !IsDisposed)
                {
                    avatarBox.BackgroundImage = Images.Images[19];
                }

                try
                {
                    CreateContactLabel.Text = Localization[CreateContactLabel.Name][1];
                }
                catch (Exception)
                {
                    CreateContactLabel.Text = "Изменить контакт";
                }

                if (!string.IsNullOrEmpty(client.organisation))
                    organisationLabel.Text = client.organisation;

                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\avatars\\" + client.ID.ToString() + ".jpeg"))
                {
                    avatarBox.BackgroundImage = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\avatars\\" + client.ID.ToString() + ".jpeg");
                }

            }));
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackgroundImage = closeButtonImage.Images[1];
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            if (!this.IsDisposed && !this.Disposing)
                closeButton.BackgroundImage = closeButtonImage.Images[0];
        }
        private void Splash_Load(object sender, EventArgs e)
        {
            InitClient();
        }

        /// <summary>
        /// В случае если мы звоним на контакт с переводом будем подменять номера
        /// </summary>
        public void SetSplashNumber()
        {
            this.Invoke((MethodInvoker)(() => nameLabel.Text = Manager.Number));
        }
        public void CallEnd()
        {
            if (this.IsHandleCreated && !this.IsDisposed)
                try
                {

                    this.BeginInvoke((MethodInvoker)(() =>
                    {
                        try
                        {
                            numberLabel.Text = Localization[numberLabel.Name][2];
                        }
                        catch (KeyNotFoundException)
                        {
                            numberLabel.Text = "Вызов завершён";
                        }
                    }));
                }
                catch (InvalidOperationException message)
                {
                    EventLogs.WriteLog(message.Message, message.StackTrace);
                }
        }
        private void Splash_Shown(object sender, EventArgs e)
        {
        }

        private void hangupButton_Click(object sender, EventArgs e)
        {
            Manager.Hangup();
        }

        private Point lastCursor;
        private Point lastForm;
        private bool isDragging = false;

        private void headPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;

            lastCursor = Cursor.Position;
            lastForm = this.Location;
        }

        private void headPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location =
                    Point.Add(lastForm, new Size(Point.Subtract(Cursor.Position, new Size(lastCursor))));
            }
        }

        private void headPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }



        private void redirectButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (ENABLED)
                RedirectMenuStrip.Show(MousePosition);
        }

        private void SubItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem temp = (ToolStripMenuItem)sender;
            string TransferingNumber = temp.Text;
            //Manager.AMI.Redirect(client.Number, TransferingNumber);
            Manager.Redirect(TransferingNumber);
        }

        private void ToolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (toolStripTextBox1.Text == "" && prevFilter == "Номер" ||
                toolStripTextBox1.Text == "Номер" && prevFilter == "")
            {
                prevFilter = toolStripTextBox1.Text;
                return;
            }
            if (e.KeyData == Keys.Enter)
            {
                string TransferingNumber = toolStripTextBox1.Text;
                Manager.Redirect(TransferingNumber);
                //Manager.AMI.Redirect(client.Number, TransferingNumber);
            }
        }

        private void ToolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripTextBox1.ForeColor = SystemColors.ControlText;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            ToolStripTextBox temp = sender as ToolStripTextBox;
            temp.ForeColor = SystemColors.ControlText;
        }

        private void toolStripTextBox1_MouseEnter(object sender, EventArgs e)
        {
            ToolStripTextBox temp = sender as ToolStripTextBox;
            temp.Text = "";
        }

        private void toolStripTextBox1_MouseLeave(object sender, EventArgs e)
        {
            ToolStripTextBox temp = sender as ToolStripTextBox;
            if (string.IsNullOrEmpty(temp.Text))
                temp.Text = "Номер";
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            toolStripTextBox1.ForeColor = Color.FromArgb(160, 160, 160);
            toolStripTextBox1.Text = "Номер";
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            Manager.blf.OpenHistory(client.Number);
        }

        private void contactButton_Click(object sender, EventArgs e)
        {
            Manager.blf.AddToBook(client);
            this.BeginInvoke((MethodInvoker)(() =>
            {
                try
                {
                    CreateContactLabel.Text = Localization[CreateContactLabel.Name][1];
                }
                catch
                {
                    CreateContactLabel.Text = "Изменить контакт";
                }
            }));
        }

        private void mailButton_MouseEnter(object sender, EventArgs e)
        {
            if (!Disposing && !IsDisposed)
            {
                mailButton.BackgroundImage = Images.Images[25];
            }

        }

        private void mailButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Disposing && !IsDisposed)
                mailButton.BackgroundImage = Images.Images[24];
        }

        private void mailButton_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(copyToClipboard);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = string.Format("mailto:" + client.email + "?subject=" + "&body=Created with B-CTI");
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.RedirectStandardOutput = false;
            proc.Start();
        }
        private void copyToClipboard()
        {
            Clipboard.SetText(client.Name + "\r\n" + client.Number + "\r\n" + client.organisation + "\r\n" + client.note);
        }

        private void hangupButton_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(client.Number))
                if (!Disposing && !IsDisposed)
                    HangupPanel.BackgroundImage = Images.Images[13];
        }

        private void hangupButton_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(client.Number))
            {
                if (!IsDisposed && !Disposing)
                    HangupPanel.BackgroundImage = Images.Images[11];
            }
        }

        private void holdButton_Click(object sender, EventArgs e)
        {
            try
            {
                string curr = string.Empty;
                try
                {
                    curr = Localization[HoldLabel.Name][0];
                }
                catch (Exception)
                {
                    curr = "Удержание";
                }
                if (HoldLabel.Text == curr)
                {
                    if (Manager.Park())
                    {
                        try
                        {
                            HoldLabel.Text = Localization[HoldLabel.Name][1];
                        }
                        catch (Exception)
                        {
                            HoldLabel.Text = "Продолжить";
                        }
                    }
                    //EventManager.ConversationEnd -= EventManager_ConversationEnd;

                    //holding = true;
                }
                else
                {
                    if (Manager.UnPark())
                    {
                        try
                        {
                            HoldLabel.Text = Localization[HoldLabel.Name][0];
                        }
                        catch (Exception)
                        {
                            HoldLabel.Text = "Удержание";
                        }
                    }
                    //EventManager.ConversationEnd += EventManager_ConversationEnd;

                    //AMI.Redirect(client.Number, AMI.UserData.Number);

                }
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog("Park Exception " + ex.Message);
            }
        }

        private void Splash_FormClosing(object sender, FormClosingEventArgs e)
        {
            //EventManager.ConversationEnd -= EventManager_ConversationEnd;
        }

        private void contactButton_MouseEnter(object sender, EventArgs e)
        {
            if (!Disposing && !IsDisposed)
                CreateContactPanel.BackgroundImage = Images.Images[10];
            CreateContactLabel.BackColor = Color.Transparent;
        }

        private void contactButton_MouseLeave(object sender, EventArgs e)
        {
            if (!IsDisposed && !Disposing)
            {
                CreateContactPanel.BackgroundImage = Images.Images[9];
                CreateContactLabel.BackColor = Color.Transparent;
            }
        }

        private void historyButton_MouseEnter(object sender, EventArgs e)
        {
            if (!Disposing && !IsDisposed)
                HistoryPanel.BackgroundImage = Images.Images[15];
            HistoryLabel.BackColor = Color.Transparent;
        }

        private void historyButton_MouseLeave(object sender, EventArgs e)
        {
            if (!IsDisposed && !Disposing)
            {
                HistoryPanel.BackgroundImage = Images.Images[14];
                HistoryLabel.BackColor = Color.Transparent;
            }
        }

        private void avatarBox_MouseEnter(object sender, EventArgs e)
        {

        }

        private void avatarBox_MouseLeave(object sender, EventArgs e)
        {

        }

        private void avatarBox_Click(object sender, EventArgs e)
        {

        }

        private void ScriptButton_Click(object sender, EventArgs e)
        {
            if (ENABLED)
            {
                Manager.Script();
            }
        }

        bool ENABLED = false;

        private void ScriptButton_MouseEnter(object sender, EventArgs e)
        {
            if (ENABLED)
            {
                if (!Disposing && !IsDisposed)
                    CmdPanel.BackgroundImage = Images.Images[5];
                CmdLabel.BackColor = Color.Transparent;
            }
        }


        private void ScriptButton_MouseLeave(object sender, EventArgs e)
        {
            if (ENABLED)
            {
                if (!Disposing && !IsDisposed)
                {

                    CmdPanel.BackgroundImage = Images.Images[3];
                    CmdLabel.BackColor = Color.Transparent;
                }
            }
        }

        private void redirectButton_Click(object sender, EventArgs e)
        {
            //AMI.Redirect(nameLabel.Text, "103");
        }

        private void HoldLabel_MouseEnter(object sender, EventArgs e)
        {
            if (ENABLED)
            {
                if (!Disposing && !IsDisposed)
                    HoldPanel.BackgroundImage = Images.Images[18];
                HoldLabel.BackColor = Color.Transparent;
            }
        }
        private void HoldLabel_MouseLeave(object sender, EventArgs e)
        {
            if (ENABLED)
                if (!IsDisposed && !Disposing)
                {
                    HoldPanel.BackgroundImage = Images.Images[16];
                    HoldLabel.BackColor = Color.Transparent;
                }
        }

        private void BlindTransferPanel_MouseEnter(object sender, EventArgs e)
        {
            if (ENABLED)
            {
                if (!Disposing && !IsDisposed)
                    BlindTransferPanel.BackgroundImage = Images.Images[2];
                BlindTransferLabel.BackColor = Color.Transparent;
            }

        }

        private void BlindTransferPanel_MouseLeave(object sender, EventArgs e)
        {
            if (ENABLED)
                if (!IsDisposed && !Disposing)
                {
                    BlindTransferPanel.BackgroundImage = Images.Images[0];
                    BlindTransferLabel.BackColor = Color.Transparent;
                }

        }

        private void TransferPanel_MouseEnter(object sender, EventArgs e)
        {
            //if (ENABLED)
            //{
            //    if (!Disposing && !IsDisposed)
            //        TransferPanel.BackgroundImage = Images.Images[23];
            //    TransferLabel.BackColor = Color.Transparent;
            //}
        }

        private void TransferPanel_MouseLeave(object sender, EventArgs e)
        {
            //if (ENABLED)
            //    if (!IsDisposed && !Disposing)
            //    {
            //        TransferPanel.BackgroundImage = Images.Images[21];
            //        TransferLabel.BackColor = Color.Transparent;
            //    }
        }

        private void ConferencePanel_MouseEnter(object sender, EventArgs e)
        {
            //if (ENABLED)
            //{
            //    if (!Disposing && !IsDisposed)
            //        ConferencePanel.BackgroundImage = Images.Images[8];
            //    ConferenceLabel.BackColor = Color.Transparent;
            //}


        }

        private void ConferencePanel_MouseLeave(object sender, EventArgs e)
        {
            //if (ENABLED)
            //    if (!IsDisposed && !Disposing)
            //    {
            //        ConferencePanel.BackgroundImage = Images.Images[6];
            //        ConferenceLabel.BackColor = Color.Transparent;
            //    }
        }
        string prevFilter = "Номер";
        private void numberToolStripMenuItem_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "" && prevFilter == "Номер" ||
                toolStripTextBox1.Text == "Номер" && prevFilter == "")
            {
                prevFilter = toolStripTextBox1.Text;
                return;
            }
            if (toolStripTextBox1.Text[toolStripTextBox1.Text.Length - 1] == '\n')
            {
                string TransferingNumber = toolStripTextBox1.Text.Substring(0, toolStripTextBox1.Text[toolStripTextBox1.Text.Length] - 2);
                Manager.AMI.Redirect(client.Number, TransferingNumber);
            }
        }
        public void EnableButtons()
        {
            if (this.InvokeRequired)
            {

                if (!Disposing && !IsDisposed)
                {
                    BeginInvoke((MethodInvoker)(() =>
                {
                    try
                    {
                        //TransferPanel.BackgroundImage = Images.Images[21];
                        //TransferLabel.BackColor = Color.Transparent;
                        BlindTransferPanel.BackgroundImage = Images.Images[0];
                        BlindTransferLabel.BackColor = Color.Transparent;
                        CmdPanel.BackgroundImage = Images.Images[3];
                        CmdLabel.BackColor = Color.Transparent;
                        HoldPanel.BackgroundImage = Images.Images[16];
                        HoldLabel.BackColor = Color.Transparent;
                        Answer.Hide();
                        ENABLED = true;
                    }
                    catch (Exception ex)
                    {
                        EventLogs.WriteLog(ex.Message, ex.StackTrace);
                    }

                }));
                }
            }
            else
            {
                try
                {
                    //TransferPanel.BackgroundImage = Images.Images[21];
                    //TransferLabel.BackColor = Color.Transparent;
                    BlindTransferPanel.BackgroundImage = Images.Images[0];
                    BlindTransferLabel.BackColor = Color.Transparent;
                    CmdPanel.BackgroundImage = Images.Images[3];
                    CmdLabel.BackColor = Color.Transparent;
                    HoldPanel.BackgroundImage = Images.Images[16];
                    HoldLabel.BackColor = Color.Transparent;
                    Answer.Hide();
                    ENABLED = true;
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                }
            }

        }
        public void DisableButtons()
        {
            if (this.InvokeRequired)
            {
                if (!Disposing && !IsDisposed)
                {
                    this.BeginInvoke((MethodInvoker)(() =>
                    {
                        if (!Disposing && !IsDisposed)
                        {
                            try
                            {
                                ConferencePanel.BackgroundImage = Images.Images[7];
                                ConferenceLabel.BackColor = Color.Transparent;
                                //TransferPanel.BackgroundImage = Images.Images[22];
                                //TransferLabel.BackColor = Color.Transparent;
                                BlindTransferPanel.BackgroundImage = Images.Images[1];
                                BlindTransferLabel.BackColor = Color.Transparent;
                                CmdPanel.BackgroundImage = Images.Images[4];
                                CmdLabel.BackColor = Color.Transparent;
                                HoldPanel.BackgroundImage = Images.Images[17];
                                HoldLabel.BackColor = Color.Transparent;
                                ENABLED = false;
                            }
                            catch (Exception ex)
                            {
                                EventLogs.WriteLog(ex.Message, ex.StackTrace);
                            }
                        }
                    }));
                }
            }
            else
            {
                try
                {
                    ConferencePanel.BackgroundImage = Images.Images[7];
                    ConferenceLabel.BackColor = Color.Transparent;
                    //TransferPanel.BackgroundImage = Images.Images[22];
                    //TransferLabel.BackColor = Color.Transparent;
                    BlindTransferPanel.BackgroundImage = Images.Images[1];
                    BlindTransferLabel.BackColor = Color.Transparent;
                    CmdPanel.BackgroundImage = Images.Images[4];
                    CmdLabel.BackColor = Color.Transparent;
                    HoldPanel.BackgroundImage = Images.Images[17];
                    HoldLabel.BackColor = Color.Transparent;
                    ENABLED = false;
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                }
            }
        }


        public void SwitchDisplayMode()
        {
            this.BeginInvoke((MethodInvoker)(() =>
            {
                if (UserInfoPanel.Visible)
                {
                    UserInfoPanel.Visible = false;
                    UnionSplashPanel.Visible = true;
                    try
                    {
                        numberLabel.Text = Localization[numberLabel.Name][3];
                    }
                    catch
                    {
                        numberLabel.Text = "Сопровождаемый перевод";
                    }
                    ImageLoader img = new ImageLoader(client);
                    if (img.IsImageExists())
                    {
                        ToTransferAvatarPanel.BackgroundImage = img.Load();
                    }
                    ImageLoader img1 = new ImageLoader(client);
                    if (img1.IsImageExists())
                    {
                        TransferToAvatarPanel.BackgroundImage = img1.Load();
                    }
                    if (ringType == CallType.IncomingCall)
                        ToTransferNameLabel.Text = dialInfo.CallerIDNum;
                    else
                        ToTransferNameLabel.Text = dialInfo.ConnectedLineNum;
                    TransferToNameLabel.Text = Manager.NotBlindNumberTransferTo;
                }
                else
                {
                    UserInfoPanel.Visible = true;
                    UnionSplashPanel.Visible = true;
                }
            }));
        }
        private void Answer_Click(object sender, EventArgs e)
        {
            this.Manager.AMI.Answer(Manager.Number);
            Answer.Hide();
        }

        private void Answer_MouseEnter(object sender, EventArgs e)
        {
            Answer.BackColor = Colors.WhiteTheme.ButtonHover;
        }

        private void Answer_MouseLeave(object sender, EventArgs e)
        {
            Answer.BackColor = Colors.WhiteTheme.ButtonMainColor;
        }

        private void TransferPanel_MouseClick(object sender, MouseEventArgs e)
        {
            //if (ENABLED)
            //    NotBlindRedirectMenuStrip.Show(MousePosition);
        }

        private void NotBlindRedirectMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            toolStripTextBox2.ForeColor = Color.FromArgb(160, 160, 160);
            toolStripTextBox2.Text = "Номер";
        }
    }
}
