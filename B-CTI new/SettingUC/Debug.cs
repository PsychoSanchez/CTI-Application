using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using BCTI.Helpers;
using System.Collections.Generic;

namespace BCTI.SettingUC
{
    public partial class Debug : UserControl
    {
        /// <summary>
        /// Форма логгера
        /// </summary>
        EventLogsForm logi;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        /// <summary>
        /// Конструктор формы отладки
        /// </summary>
        public Debug()
        {
            InitializeComponent();
            EventLog.Text = "Запись логов событий";
            AmiLog.Text = "Запись логов Asterisk";

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            AmiLog.Checked = SettingsForm.settings.Logs.bAmiLogEnabled;
            EventLog.Checked = SettingsForm.settings.Logs.bEventLogEnabled;
            AmiLog.Checked_Changed += AmiLog_Checked_Changed;
            EventLog.Checked_Changed += EventLog_Checked_Changed;
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(DebuggingBox, FontStyle.Bold | FontStyle.Italic);
            UserInterfaceAPI.SetFontStyle(TraySettings, FontStyle.Bold | FontStyle.Italic);
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
        }
        #region ControlEventsHandlers
        private void EventLog_Checked_Changed(object sender, EventArgs e)
        {
            SettingsForm.settings.Logs.bEventLogEnabled = EventLog.Checked;
        }

        private void AmiLog_Checked_Changed(object sender, EventArgs e)
        {
            SettingsForm.settings.Logs.bAmiLogEnabled = AmiLog.Checked;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            Label l = sender as Label;
            l.BackColor = Colors.WhiteTheme.ButtonHover;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            Label l = sender as Label;
            l.BackColor = Colors.WhiteTheme.ButtonMainColor;
        }
        /// <summary>
        /// Открыть папку с логами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@SettingsForm.settings.Logs.AmiLogFolder);
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog("Exception", ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        /// <summary>
        /// Удалить папку с логами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAmiLogsButton_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(SettingsForm.settings.Logs.AmiLogFolder);
                foreach (DirectoryInfo folder in di.GetDirectories())
                {
                    foreach (FileInfo file in folder.GetFiles())
                    {
                        if (file.Name.ToLower().Contains("ami"))
                            file.Delete();
                    }
                    //folder.Delete();
                }

            }
            catch (Exception ex)
            {
                EventLogs.WriteLog("Exception", ex.Message + "\r\n" + ex.StackTrace);
            }

        }
        /// <summary>
        /// Открыть форму журнала событий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenLogMagazine_Click(object sender, EventArgs e)
        {
            if (logi == null)
                logi = new EventLogsForm();
            if (!logi.Visible)
                if (logi.IsDisposed)
                {
                    logi = new EventLogsForm();
                    logi.Show(BLFPanel.mainBLF);
                }
                else
                {
                    logi.Show(BLFPanel.mainBLF);
                }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteEventLog_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(SettingsForm.settings.Logs.EventLogFolder);
                foreach (DirectoryInfo folder in di.GetDirectories())
                {
                    foreach (FileInfo file in folder.GetFiles())
                    {
                        if (file.Name == "EventLog.log")
                            file.Delete();
                    }
                }

            }
            catch (Exception ex)
            {
                EventLogs.WriteLog("Exception", ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        /// <summary>
        /// Открыть ивент лог в текстовом редакторе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenEventLog_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("notepad.exe", @SettingsForm.settings.Logs.EventLogFolder + "\\EventLog.log");
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog("Exception", ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        #endregion
    }
}
