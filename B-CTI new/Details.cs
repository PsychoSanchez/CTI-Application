using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using AsteriskManager;
using BCTI.DialogBoxes;
using System.Diagnostics;
using BCTI.Helpers;

namespace BCTI
{
    /// <summary>
    /// Форма деталей звонка
    /// </summary>
    public partial class Details : Form
    {
        RingInfo ring = new RingInfo();
        ClientsData client = new ClientsData();
        string details = string.Empty;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string SFilePath = string.Empty;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();

        /// <summary>
        /// Конструтор по умолчанию
        /// </summary>
        /// <param name="ring">Информация о звонке</param>
        /// <param name="_client">Информация о контакте</param>
        public Details(RingInfo ring, ClientsData _client)
        {
            InitializeComponent();
            detalisLabel.Padding = new Padding(5, 3, 0, 0);
            this.ring = ring;
            this.client = (ClientsData)_client.Clone();
            numberLabel.Text += " " + ring.number;
            if (!string.IsNullOrEmpty(client.Name))
                infoLabel.Text = client.Name;
            ///Аватар
            ImageLoader img = new ImageLoader(client);
            if (img.IsImageExists())
            {
                avaBox.BackgroundImage = img.Load();
            }

            Localization = Localizator.GetFormLocalization("Details", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            if (!string.IsNullOrEmpty(client.organisation))
                organisationLabel.Text = client.organisation;
            if (!string.IsNullOrEmpty(client.email))
                emailLabel.Text = client.email;
            numberLabel2.Text = client.Number;
            if (!string.IsNullOrEmpty(client.SecondNumber))
                secondNumberLabel.Text = client.SecondNumber;

            ///Тип звонка
            try
            {

                switch (ring.type)
                {
                    case CallType.OutcomingCall:
                        {
                            details = Localization[detalisLabel.Name][0] + "\r\n";
                            break;
                        }
                    case CallType.IncomingCall:
                        {
                            details = Localization[detalisLabel.Name][1] + "\r\n";
                            break;
                        }
                    case CallType.Unanswered:
                        {
                            details = Localization[detalisLabel.Name][2] + "\r\n";
                            break;
                        }
                }
                details += Localization[detalisLabel.Name][3] + ring.number + "\r\n";
                details += Localization[detalisLabel.Name][4] + ring.momentOfRing.ToString() + "\r\n";
                details += Localization[detalisLabel.Name][5] + ring.Duration.Substring(0, 8) + "\r\n";
                details += Localization[detalisLabel.Name][6] + "\r\n";
                detalisLabel.Text = details;
            }
            catch (Exception)
            {
                switch (ring.type)
                {
                    case CallType.OutcomingCall:
                        {
                            details = "Исходящий звонок\r\n";
                            break;
                        }
                    case CallType.IncomingCall:
                        {
                            details = "Входящий звонок\r\n";
                            break;
                        }
                    case CallType.Unanswered:
                        {
                            details = "Пропущенный звонок\r\n";
                            break;
                        }
                }
                details += "Номер абонента: " + ring.number + "\r\n";
                details += "Вызов совершён: " + ring.momentOfRing.ToString() + "\r\n";
                details += "Длительность: " + ring.Duration.Substring(0, 8) + "\r\n";
                details += "Перевод: Нет" + "\r\n";
                detalisLabel.Text = details;
            }

            ///Шрифты
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(numberLabel, FontStyle.Bold);
            UserInterfaceAPI.SetFontStyle(numberLabel2, FontStyle.Bold);
            UserInterfaceAPI.SetFontStyle(secondNumberLabel, FontStyle.Bold);
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization("Details", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            details = string.Empty;
            try
            {

                switch (ring.type)
                {
                    case CallType.OutcomingCall:
                        {
                            details = Localization[detalisLabel.Name][0] + "\r\n";
                            break;
                        }
                    case CallType.IncomingCall:
                        {
                            details = Localization[detalisLabel.Name][1] + "\r\n";
                            break;
                        }
                    case CallType.Unanswered:
                        {
                            details = Localization[detalisLabel.Name][2] + "\r\n";
                            break;
                        }
                }
                details += Localization[detalisLabel.Name][3] + ring.number + "\r\n";
                details += Localization[detalisLabel.Name][4] + ring.momentOfRing.ToString() + "\r\n";
                details += Localization[detalisLabel.Name][5] + ring.Duration.Substring(0, 8) + "\r\n";
                details += Localization[detalisLabel.Name][6] + "\r\n";
                detalisLabel.Text = details;
            }
            catch (Exception)
            {
                switch (ring.type)
                {
                    case CallType.OutcomingCall:
                        {
                            details = "Исходящий звонок\r\n";
                            break;
                        }
                    case CallType.IncomingCall:
                        {
                            details = "Входящий звонок\r\n";
                            break;
                        }
                    case CallType.Unanswered:
                        {
                            details = "Пропущенный звонок\r\n";
                            break;
                        }
                }
                details += "Номер абонента: " + ring.number + "\r\n";
                details += "Вызов совершён: " + ring.momentOfRing.ToString() + "\r\n";
                details += "Длительность: " + ring.Duration.Substring(0, 8) + "\r\n";
                details += "Перевод: Нет" + "\r\n";
                detalisLabel.Text = details;
            }

            numberLabel.Text += " " + ring.number;
            if (!string.IsNullOrEmpty(client.Name))
                infoLabel.Text = client.Name;
            if (!string.IsNullOrEmpty(client.organisation))
                organisationLabel.Text = client.organisation;
            if (!string.IsNullOrEmpty(client.email))
                emailLabel.Text = client.email;
            numberLabel2.Text = client.Number;
            if (!string.IsNullOrEmpty(client.SecondNumber))
                secondNumberLabel.Text = client.SecondNumber;
        }

        #region DefaultHandlers

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackgroundImage = closeButtonImage.Images[1];
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Disposing && !IsDisposed)
                closeButton.BackgroundImage = closeButtonImage.Images[0];
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(details);
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

        #endregion
        /// <summary>
        /// Скачивание записи звонка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                string SPlayBackServerFolder = BLFPanel.PlaybackServerFolder + ring.momentOfRing.Year + "/" + ((ring.momentOfRing.Month < 10) ? "0" + ring.momentOfRing.Month.ToString() : ring.momentOfRing.Month.ToString()) + "/" + (ring.momentOfRing.Day < 10 ? "0" + ring.momentOfRing.Day.ToString() : ring.momentOfRing.Day.ToString()) + "/";
                if (!string.IsNullOrEmpty(SPlayBackServerFolder))
                {

                    ApacheFileDownloader download = new ApacheFileDownloader();
                    bool match = false;
                    List<string> SRingRecordsNames = download.GetFolderList(SPlayBackServerFolder);
                    if (SRingRecordsNames.Count > 0)
                    {
                        foreach (string file in SRingRecordsNames)
                        {
                            Console.WriteLine(file + " " + ring.UniqueID);
                            if (file.Contains(ring.UniqueID))
                            {
                                EventLogs.WriteLog(file);
                                SFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\Playback\\" + file;
                                download.DownloadFile(SPlayBackServerFolder, file);
                                match = true;
                                break;
                            }
                        }
                    }
                    else return;
                    if (match)
                    {
                        try
                        {
                            BMessageBox.Show("Успешно", Localization[downloadButton.Name][1], BMessageBoxButtons.OK, BMessageBoxIcon.Asterisk);
                        }
                        catch
                        {
                            BMessageBox.Show("Успешно", "Файл скачан успешно", BMessageBoxButtons.OK, BMessageBoxIcon.Asterisk);
                        }
                        EventLogs.WriteLog("Файл " + ring.UniqueID + " скачался");
                    }
                    else
                    {
                        try
                        {
                            BMessageBox.Show("Внимание", Localization[downloadButton.Name][3], BMessageBoxButtons.OK, BMessageBoxIcon.Exclamation);
                        }
                        catch
                        {
                            BMessageBox.Show("Ошибка", "Файл не найден на сервере", BMessageBoxButtons.OK, BMessageBoxIcon.Error);
                        }
                        EventLogs.WriteLog("Файл не найден на сервере");
                    }
                }
                else
                {
                    BMessageBox.Show("Внимание", "Не указан путь к записям на сервере", BMessageBoxButtons.OK, BMessageBoxIcon.Exclamation);
                    EventLogs.WriteLog("Не указан путь к записям на сервере");
                }
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, ex.HelpLink);
            }
        }

        /// <summary>
        /// Прослушивание записи звонка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listenButton_Click(object sender, EventArgs e)
        {
            string curr = string.Empty;
            try
            {
                curr = Localization[listenButton.Name][0];
            }
            catch (Exception)
            {
                curr = "Слушать";
            }
            if (listenButton.Text == curr)
            {
                if (!string.IsNullOrEmpty(SFilePath))
                {
                    if (File.Exists(SFilePath))
                    {
                        try
                        {
                            player.SoundLocation = SFilePath;
                            player.Play();
                            try
                            {
                                listenButton.Text = Localization[listenButton.Name][1];
                            }
                            catch (Exception)
                            {
                                listenButton.Text = "Стоп";
                            }
                            listenButton.Image = BCTI.Properties.Resources.stop;
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
                            BMessageBox.Show(Localization[listenButton.Name][2], BMessageBoxButtons.OK, BMessageBoxIcon.Exclamation);
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
                        BMessageBox.Show(Localization[listenButton.Name][3], BMessageBoxButtons.OK, BMessageBoxIcon.Exclamation);
                    }
                    catch
                    {
                        BMessageBox.Show("Не указан путь к файлу", BMessageBoxButtons.OK, BMessageBoxIcon.Exclamation);
                    }
                    EventLogs.WriteLog("Не указан путь к файлу " + ring.UniqueID);
                }
            }
            else
                try
                {
                    if (listenButton.Text == Localization[listenButton.Name][1])
                    {
                        player.Stop();
                        listenButton.Text = Localization[listenButton.Name][0];
                        listenButton.Image = BCTI.Properties.Resources.play_small;
                    }
                }
                catch (Exception)
                {
                    if (listenButton.Text == "Стоп")
                    {
                        player.Stop();
                        listenButton.Text = "Слушать";
                        listenButton.Image = BCTI.Properties.Resources.play_small;
                    }
                }
        }

        private void Details_FormClosing(object sender, FormClosingEventArgs e)
        {
            BLFPanel.ApplyLanguage -= BLFPanel_ApplyLanguage;
        }
    }
}
