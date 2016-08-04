using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using AsteriskManager;
using System.Diagnostics;
using BCTI.DialogBoxes;
using BCTI.Helpers;

namespace BCTI
{
    public partial class ringCard : UserControl
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        RingInfo ring = new RingInfo();
        ClientsData client = new ClientsData();
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/avatar/";
        public event EventHandler<NewClientArgs> newContactAdded;
        public event EventHandler<CustEventArgs> NumberClick;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        public ringCard()
        {
            InitializeComponent();
            UserInterfaceAPI.InitFonts(MainPabel);
            UserInterfaceAPI.SetFontStyle(ContactName, FontStyle.Bold);

            Localization = Localizator.GetFormLocalization("ringCard", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += GeneralSettings_Language_Changed;
        }

        private void GeneralSettings_Language_Changed(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization("ringCard", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            CallNumber.Text = ring.number;
            if (string.IsNullOrEmpty(client.Name))
                ContactName.Text = Localization[ContactName.Name][1];
            else ContactName.Text = client.Name;
        }

        public void changeRing(RingInfo newRing, ClientsData currClient)
        {
            MainPabel.BackColor = SystemColors.ControlLightLight;
            ring = newRing;
            typePicture.BackColor = SystemColors.ControlLightLight;
            ContactName.BackColor = Color.Transparent;
            Time.BackColor = Color.Transparent;
            client = currClient;
            client.Number = ring.number;
            CallNumber.Text = ring.number;
            try
            {
                if (string.IsNullOrEmpty(client.Name))
                {
                    ContactName.Text = Localization[ContactName.Name][1];
                }
                else
                {
                    AddButton.Hide();
                    ContactName.Text = client.Name;
                }
            }
            catch
            {

                if (string.IsNullOrEmpty(client.Name))
                {
                    ContactName.Text = " Неизвестный абонент";
                }
                else
                {
                    AddButton.Hide();
                    ContactName.Text = client.Name;
                }
            }
            switch (ring.type)
            {
                case CallType.IncomingCall:
                    {
                        typePicture.BackgroundImage = typeImages.Images[0];
                        break;
                    }
                case CallType.OutcomingCall:
                    {
                        typePicture.BackgroundImage = typeImages.Images[1];
                        break;
                    }
                case CallType.Unanswered:
                    {
                        typePicture.BackgroundImage = typeImages.Images[2];
                        break;
                    }
            }
            if (!string.IsNullOrEmpty(ring.momentOfRing.ToString()))
                Time.Text = ring.momentOfRing.ToString();
        }
        public ringCard(RingInfo newRing, ClientsData currClient)
        {
            InitializeComponent();
            MainPabel.BackColor = SystemColors.ControlLightLight;
            ring = newRing;
            typePicture.BackColor = SystemColors.ControlLightLight;
            ContactName.BackColor = Color.Transparent;
            Time.BackColor = Color.Transparent;
            client = currClient;
            if (string.IsNullOrEmpty(client.Name))
                ContactName.Text = ring.number + " (Неизвестно)";
            else ContactName.Text = ring.number + " (" + client.Name + ")";
            switch (ring.type)
            {
                case CallType.IncomingCall:
                    {
                        typePicture.BackgroundImage = typeImages.Images[0];
                        break;
                    }
                case CallType.OutcomingCall:
                    {
                        typePicture.BackgroundImage = typeImages.Images[1];
                        break;
                    }
                case CallType.Unanswered:
                    {
                        typePicture.BackgroundImage = typeImages.Images[2];
                        break;
                    }
            }
            if (!string.IsNullOrEmpty(ring.momentOfRing.ToString()))
                Time.Text = ring.momentOfRing.ToString();
        }

        private void playButton_MouseEnter(object sender, EventArgs e)
        {
            playButton.BackColor = SystemColors.ActiveCaption;

            Border.BackColor = SystemColors.ControlDarkDark; ;
            //MainPabel.BackColor = SystemColors.ControlLight;
            //typePicture.BackColor = SystemColors.ControlLight;
            ContactName.BackColor = Color.Transparent;
            Time.BackColor = Color.Transparent;
        }

        private void playButton_MouseLeave(object sender, EventArgs e)
        {
            playButton.BackColor = Colors.WhiteTheme.ButtonMainColor;

            Border.BackColor = SystemColors.ControlLight;
            //MainPabel.BackColor = SystemColors.ControlLightLight;
            //typePicture.BackColor = SystemColors.ControlLightLight;
            ContactName.BackColor = Color.Transparent;
            Time.BackColor = Color.Transparent;
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            Details details = new Details(ring, client);
            details.Show(this);
        }

        private void CallNumber_MouseEnter(object sender, EventArgs e)
        {
            CallNumber.ForeColor = Color.FromArgb(0, 45, 146);
            CallNumber.Font = new Font(CallNumber.Font, FontStyle.Italic | FontStyle.Bold);

            Border.BackColor = SystemColors.ControlDarkDark;
            //MainPabel.BackColor = SystemColors.ControlLight;
            //typePicture.BackColor = SystemColors.ControlLight;
            ContactName.BackColor = Color.Transparent;
            Time.BackColor = Color.Transparent;
        }

        private void CallNumber_MouseLeave(object sender, EventArgs e)
        {
            CallNumber.ForeColor = Colors.WhiteTheme.ButtonMainColor;
            CallNumber.Font = new Font(CallNumber.Font, FontStyle.Italic);

            Border.BackColor = SystemColors.ControlLight;
            //MainPabel.BackColor = SystemColors.ControlLightLight;
            //typePicture.BackColor = SystemColors.ControlLightLight;
            ContactName.BackColor = Color.Transparent;
            Time.BackColor = Color.Transparent;
        }

        private void Details_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button b = sender as Button;
                b.BackColor = Color.Green;
            }
            if (sender is Label)
            {
                Label l = sender as Label;
                l.BackColor = Color.Green;
            }
            Border.BackColor = SystemColors.ControlDarkDark; ;
            //MainPabel.BackColor = SystemColors.ControlLight;
            //typePicture.BackColor = SystemColors.ControlLight;
            ContactName.BackColor = Color.Transparent;
            Time.BackColor = Color.Transparent;
        }

        private void Details_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button b = sender as Button;
                b.BackColor = Colors.WhiteTheme.ButtonMainColor;
            }
            if (sender is Label)
            {
                Label l = sender as Label;
                l.BackColor = Colors.WhiteTheme.ButtonMainColor;
            }
            Border.BackColor = SystemColors.ControlLight;
            //MainPabel.BackColor = SystemColors.ControlLightLight;
            //typePicture.BackColor = SystemColors.ControlLightLight;
            ContactName.BackColor = Color.Transparent;
            Time.BackColor = Color.Transparent;
        }
        private void RingMouseLeave(object sender, EventArgs e)
        {
            Border.BackColor = SystemColors.ControlLight;
            //MainPabel.BackColor = SystemColors.ControlLightLight;
            //typePicture.BackColor = SystemColors.ControlLightLight;
            ContactName.BackColor = Color.Transparent;
            Time.BackColor = Color.Transparent;
        }
        private void RingMouseEnter(object sender, EventArgs e)
        {
            Border.BackColor = SystemColors.ControlDarkDark; ;
            //MainPabel.BackColor = SystemColors.ControlLight;
            //typePicture.BackColor = SystemColors.ControlLight;
            ContactName.BackColor = Color.Transparent;
            Time.BackColor = Color.Transparent;
        }


        private void MainPabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Details details = new Details(ring, client);
            details.Show(this);
        }

        private void CallNumber_MouseClick(object sender, MouseEventArgs e)
        {
            NumberClick?.Invoke(this, new CustEventArgs(CallNumber.Text));
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\Playback\\"))
            {

                List<string> SRingRecordsNames = (Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\Playback\\")).ToList();
                bool match = false;
                string SFilePath = string.Empty;
                try
                {
                    foreach (string file in SRingRecordsNames)
                    {
                        if (file.ToLower().Contains(ring.UniqueID))
                        {
                            match = true;
                            SFilePath = file;
                            break;
                        }
                    }
                }
                catch
                {
                    try
                    {
                        BMessageBox.Show(this, Localization[playButton.Name][4]);
                    }
                    catch
                    {
                        BMessageBox.Show("Не удалось воспроизвести запись разговора");
                    }
                }
                if (playButton.Image == BCTI.Properties.Resources.play_small)
                {
                    if (!string.IsNullOrEmpty(SFilePath))
                    {
                        if (File.Exists(SFilePath))
                        {
                            try
                            {
                                player.SoundLocation = SFilePath;
                                player.Play();
                                playButton.Image = BCTI.Properties.Resources.stop;
                            }
                            catch (InvalidOperationException)
                            {
                                Process.Start(@SFilePath);
                            }
                        }
                        else
                        {
                            try
                            {
                                BMessageBox.Show(Localization[playButton.Name][1], BMessageBoxButtons.OK, BMessageBoxIcon.Exclamation);
                            }
                            catch
                            {
                                BMessageBox.Show("Запись не найдена на локальном компьютере", BMessageBoxButtons.OK, BMessageBoxIcon.Exclamation);
                            }
                            EventLogs.WriteLog("Запись не найдена на локальном компьютере");
                        }
                    }
                    else
                    {
                        try
                        {
                            BMessageBox.Show(Localization[playButton.Name][2], BMessageBoxButtons.OK, BMessageBoxIcon.Exclamation);
                        }
                        catch
                        {
                            BMessageBox.Show("Не указан путь к файлу", BMessageBoxButtons.OK, BMessageBoxIcon.Exclamation);
                        }
                        EventLogs.WriteLog("Не указан путь к файлу " + ring.UniqueID);
                    }
                }
                else if (playButton.Image == BCTI.Properties.Resources.stop)
                {
                    player.Stop();
                    playButton.Image = BCTI.Properties.Resources.play_small;
                }
            }
            else
                try
                {
                    BMessageBox.Show(Localization[playButton.Name][3]);
                }
                catch
                {
                    BMessageBox.Show("У вас нет скаченных записей");
                }
        }

        private void AddButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(client.Name))
            {
                AddToBook atb = new AddToBook(client);
                atb.ShowDialog();
                if (atb.added)
                {
                    client = atb.newClient;
                    newContactAdded?.Invoke(this, new NewClientArgs(client));
                }
            }
        }

        private void AddButton_MouseEnter(object sender, EventArgs e)
        {
            AddButton.BackColor = Colors.WhiteTheme.ButtonHover;
        }

        private void AddButton_MouseLeave(object sender, EventArgs e)
        {
            AddButton.BackColor = Colors.WhiteTheme.ButtonMainColor;
        }
    }
}
