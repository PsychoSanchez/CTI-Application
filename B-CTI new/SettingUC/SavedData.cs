using System;
using System.Windows.Forms;
using System.IO;
using BCTI.Settings;
using System.Drawing;
using BCTI.Helpers;
using System.Collections.Generic;

namespace BCTI.SettingUC
{
    public partial class SavedData : UserControl
    {
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SavedData()
        {
            InitializeComponent();

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            if (!XMLReadWriter.IsHistoryExists())
            {
                DeleteHistory.Enabled = false;
                try
                {
                    DeleteHistory.Text = Localization[DeleteHistory.Name][1];
                }
                catch
                {
                    DeleteHistory.Text = "Файл истории не найден";
                }
            }
            ReplayFolder.Text = SettingsForm.settings.Playback.PlaybackSaveFolder;
            LogFolder.Text = SettingsForm.settings.Logs.AmiLogFolder;
            PLayBackServFolder.Text = SettingsForm.settings.Playback.PlaybackServerFolder;

            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(groupBox1, FontStyle.Bold | FontStyle.Italic);
            UserInterfaceAPI.SetFontStyle(TraySettings, FontStyle.Bold | FontStyle.Italic);
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            if (!XMLReadWriter.IsHistoryExists())
            {
                DeleteHistory.Enabled = false;
                try
                {
                    DeleteHistory.Text = Localization[DeleteHistory.Name][1];
                }
                catch
                {
                    DeleteHistory.Text = "Файл истории не найден";
                }
            }
        }
        /// <summary>
        /// Удаление файла истории звонков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteHistory_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(XMLReadWriter.HistorOfRingsPath);
                if (!XMLReadWriter.IsHistoryExists())
                {
                    DeleteHistory.Enabled = false;
                    try
                    {
                        DeleteHistory.Text = Localization[DeleteHistory.Name][2];
                    }
                    catch
                    {
                        DeleteHistory.Text = "Данные удалены";
                    }
                }
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog("Exception", ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        /// <summary>
        /// Открытие диалога для выбора папки сохранения скачанных записей 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaybackDialog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            if (fl.ShowDialog() == DialogResult.OK)
            {
                ReplayFolder.Text = fl.SelectedPath;
            }
        }
        /// <summary>
        /// Выбор папки для сохранения логов астериск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AsteriskLogsDialog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            if (fl.ShowDialog() == DialogResult.OK)
            {
                LogFolder.Text = fl.SelectedPath;
            }
        }

        private void ReplayFolder_TextChanged(object sender, EventArgs e)
        {
            SettingsForm.settings.Playback.PlaybackSaveFolder = ReplayFolder.Text;
        }

        private void LogFolder_TextChanged(object sender, EventArgs e)
        {
            SettingsForm.settings.Logs.AmiLogFolder = LogFolder.Text;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Label l = sender as Label;
            l.BackColor = Colors.WhiteTheme.ButtonHover;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Label l = sender as Label;
            l.BackColor = Colors.WhiteTheme.ButtonMainColor;
        }
        private void PLayBackServFolder_Leave(object sender, EventArgs e)
        {
            SettingsForm.settings.Playback.PlaybackServerFolder = PLayBackServFolder.Text;
        }
    }
}
