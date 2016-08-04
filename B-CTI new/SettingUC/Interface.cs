using BCTI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI.SettingUC
{
    public partial class Interface : UserControl
    {
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        /// <summary>
        /// Default construct
        /// </summary>
        public Interface()
        {
            InitializeComponent();
            EnableTray.Checked = SettingsForm.settings.Tray.bTrayEnabled;
            OneClickIcon.Checked = SettingsForm.settings.Tray.bOneClickOpen;
            MinimizeTray.Checked = SettingsForm.settings.Tray.bMinimizedToTray;
            blfOnTop.Text = "Главная панель всегда сверху";
            EnableTray.Text = "Добавить иконку в трей";
            MinimizeTray.Text = "Сворачивать в трей";
            OneClickIcon.Text = "Разворачивать одним кликом";

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            try
            {
                foreach (var line in Localization[ThemeStyle.Name])
                    ThemeStyle.Items.Add(line);
            }
            catch
            {
                ThemeStyle.Items.Add("Светлая");
            }
            ThemeStyle.SelectedItem = ThemeStyle.Items[0];

            blfOnTop.Checked_Changed += BlfOnTop_Checked_Changed;
            EnableTray.Checked_Changed += EnableTrayIcon_CheckedChanged;
            MinimizeTray.Checked_Changed += MinimizeToTray_CheckedChanged;
            OneClickIcon.Checked_Changed += OneClickTray_CheckedChanged;
            EnableTrayIcon_CheckedChanged(null, null);
            ThemeStyle.SelectedItem = ThemeStyle.Items[0];
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(groupBox1, FontStyle.Bold | FontStyle.Italic);
            UserInterfaceAPI.SetFontStyle(TraySettings, FontStyle.Bold | FontStyle.Italic);
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            ThemeStyle.Items.Clear();
            try
            {
                foreach (var line in Localization[ThemeStyle.Name])
                    ThemeStyle.Items.Add(line);
                ThemeStyle.SelectedItem = ThemeStyle.Items[0];
            }
            catch
            {
                ThemeStyle.Items.Add("Светлая");
            }
        }

        /// <summary>
        /// Настройка: Блф-панель всегда сверху
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlfOnTop_Checked_Changed(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Настройка: Иконка в трее
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnableTrayIcon_CheckedChanged(object sender, EventArgs e)
        {
            SettingsForm.settings.Tray.bTrayEnabled = EnableTray.Checked;
            if (!EnableTray.Checked)
            {
                OneClickIcon.Enabled = false;
                MinimizeTray.Enabled = false;
                OneClickIcon.ForeColor = SystemColors.ButtonHighlight;
                MinimizeTray.ForeColor = SystemColors.ButtonHighlight;
            }
            else
            {
                OneClickIcon.Enabled = true;
                MinimizeTray.Enabled = true;
                OneClickIcon.ForeColor = SystemColors.ControlText;
                MinimizeTray.ForeColor = SystemColors.ControlText;
            }
        }
        /// <summary>
        /// Настройка: Сворачивать в трей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimizeToTray_CheckedChanged(object sender, EventArgs e)
        {
            SettingsForm.settings.Tray.bMinimizedToTray = MinimizeTray.Checked;
        }

        /// <summary>
        /// Настройка: Разворачивать одним кликом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OneClickTray_CheckedChanged(object sender, EventArgs e)
        {
            SettingsForm.settings.Tray.bOneClickOpen = OneClickIcon.Checked;
        }
        /// <summary>
        /// Смена цветовой схемы приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Theme_Click(object sender, EventArgs e)
        {

        }
    }
}
