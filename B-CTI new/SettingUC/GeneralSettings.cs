using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using BCTI.Helpers;
using System.Collections.Generic;

namespace BCTI.SettingUC
{
    public partial class GeneralSettings : UserControl
    {
        //Ключ в реестре
        RegistryKey rkApp;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        /// <summary>
        /// Конструктор
        /// </summary>
        public GeneralSettings()
        {
            InitializeComponent();

            try
            {
                LanguageComboBox.Text = SettingsForm.settings.Interface.Language;
                LanguageComboBox.Items.AddRange(Localizator.GetLanguages().ToArray());
            }
            catch
            {
                LanguageComboBox.Items.Add(BLFPanel.Staticsettings.Interface.Language);
            }

            DoNotDisturb.Checked = SettingsForm.settings.CommonSettings.bDoNotDisturb;
            //SettingsForm.ApplySettings += SettingsForm_ApplySettings;
            BLFPanel.ApplyLanguage += SettingsForm_ApplySettings;
            DoNotDisturb.Text = "Режим не беспокоить";
            StartWithWindows.Text = "Запуск вметсе с Windows";
            DoNotDisturb.Checked_Changed += DoNotDisturb_CheckedChanged;
            CurrentVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            LastVersion.Text = "Неизвестно";

            if (LanguageComboBox.Items.Count > 0)
            {
                if (!string.IsNullOrEmpty(BLFPanel.Staticsettings.Interface.Language))
                    if (LanguageComboBox.Items.IndexOf(BLFPanel.Staticsettings.Interface.Language) < 0)
                        LanguageComboBox.SelectedItem = LanguageComboBox.Items[0];
                    else LanguageComboBox.SelectedIndex = LanguageComboBox.Items.IndexOf(BLFPanel.Staticsettings.Interface.Language);
                else LanguageComboBox.SelectedItem = LanguageComboBox.Items[0];
            }
            //Шрифты
            UserInterfaceAPI.InitFonts(this);
            //UserInterfaceAPI.InitFonts(CommonSettings);


            //Проверка наличия ключа автозапуска в реестре
            try
            {
                rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (rkApp.GetValue("BCTI") == null)
                {
                    // The value doesn't exist, the application is not set to run at startup
                    StartWithWindows.Checked = false;
                }
                else
                {
                    // The value exists, the application is set to run at startup
                    StartWithWindows.Checked = true;
                }
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }

            Localization = Localizator.GetFormLocalization("GeneralSettings", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);

            try
            {

                DoNotDisturb.SetText(Localization[DoNotDisturb.Name][0]);
            }
            catch
            {
                DoNotDisturb.SetText("Не беспокоить");
            }

            try
            {
                StartWithWindows.SetText(Localization[StartWithWindows.Name][0]);
            }
            catch
            {
                StartWithWindows.SetText("Запускать вместе с Windows");
            }

        }
        /// <summary>
        /// Применить настройки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_ApplySettings(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization("GeneralSettings", SettingsForm.settings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            try
            {
                DoNotDisturb.SetText(Localization[DoNotDisturb.Name][0]);
            }
            catch
            {
                DoNotDisturb.SetText("Не беспокоить");
            }

            try
            {
                StartWithWindows.SetText(Localization[StartWithWindows.Name][0]);
            }
            catch
            {
                StartWithWindows.SetText("Запускать вместе с Windows");
            }

            //Сохранение настроек автозапуска
            try
            {

                if (StartWithWindows.Checked)
                {
                    // Add the value in the registry so that the application runs at startup
                    rkApp.SetValue("BCTI", Application.ExecutablePath.ToString());
                }
                else
                {
                    // Remove the value from the registry so that the application doesn't start
                    rkApp.DeleteValue("BCTI", false);
                }
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }
        }


        #region Handlers
        private void DoNotDisturb_CheckedChanged(object sender, EventArgs e)
        {
            SettingsForm.settings.CommonSettings.bDoNotDisturb = DoNotDisturb.Checked;
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LanguageComboBox.SelectedItem != null)
            {
                string newLanguage = LanguageComboBox.SelectedItem.ToString();
                if (newLanguage != SettingsForm.settings.Interface.Language)
                {
                    SettingsForm.settings.Interface.Language = newLanguage;
                }
            }
        }

        private void CheckForUpdates_Click(object sender, EventArgs e)
        {

        }

        private void CheckForUpdates_MouseEnter(object sender, EventArgs e)
        {
            CheckForUpdates.BackColor = Colors.WhiteTheme.ButtonHover;
        }

        private void CheckForUpdates_MouseLeave(object sender, EventArgs e)
        {
            CheckForUpdates.BackColor = Colors.WhiteTheme.ButtonMainColor;
        }
        #endregion

        private void GeneralSettings_Load(object sender, EventArgs e)
        {
            UserInterfaceAPI.SetFontStyle(LastVersion, FontStyle.Italic);
            UserInterfaceAPI.SetFontStyle(CurrentVersion, FontStyle.Italic);
            UserInterfaceAPI.SetFontStyle(groupBox1, FontStyle.Bold | FontStyle.Italic);
            UserInterfaceAPI.SetFontStyle(CommonSettings, FontStyle.Bold | FontStyle.Italic);
        }

        private void StartWithWindows_Checked_Changed(object sender, EventArgs e)
        {
            SettingsForm.settings.SysSettings.bOnWindowsStartup = StartWithWindows.Checked;
        }
    }
}
