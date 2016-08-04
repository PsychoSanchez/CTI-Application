using BCTI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI.SettingUC
{
    public partial class Hotkeys : UserControl
    {
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public Hotkeys()
        {
            InitializeComponent();

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            DialHotkey.Text = SettingsForm.settings.Hotkey.Modifiers.Replace("+None", "") + "+" + SettingsForm.settings.Hotkey.Key;
            numericUpDown1.Value = SettingsForm.settings.Hotkey.DelayBeforeCall;
            ///Проверка, стоял ли звонок по горячей клавише или ввод номера в поиск на блф панели
            if (SettingsForm.settings.Hotkey.bHotkeyInstantCall)
            {
                InstantCall.Checked = true;
                OpenBLfBeforeCall.Checked = false;
            }
            else
            {
                InstantCall.Checked = false;
                OpenBLfBeforeCall.Checked = true;
            }
            ///Шрифты
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(DialHotkeyBox, FontStyle.Bold | FontStyle.Italic);
            SettingsForm.ApplySettings += SettingsForm_ApplySettings;
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
        }

        private void SettingsForm_ApplySettings(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Изменение состояний радио кнопок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (InstantCall.Checked)
            {
                InstantCall.Checked = true;
                SettingsForm.settings.Hotkey.bHotkeyInstantCall = true;
            }
            else
            {
                SettingsForm.settings.Hotkey.bHotkeyInstantCall = false;
                OpenBLfBeforeCall.Checked = true;
            }
        }

        /// <summary>
        /// Изменение состояний радио кнопок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (OpenBLfBeforeCall.Checked)
            {
                OpenBLfBeforeCall.Checked = true;
                SettingsForm.settings.Hotkey.bHotkeyInstantCall = false;
            }
            else
            {
                SettingsForm.settings.Hotkey.bHotkeyInstantCall = true;
                InstantCall.Checked = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SettingsForm.settings.Hotkey.DelayBeforeCall = (int)numericUpDown1.Value;
        }
        private void DialHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter key = new KeysConverter();
            if (DialHotkey.Text != key.ConvertToString(e.Modifiers).Replace("+None", "") + "+" + key.ConvertToString(e.KeyCode).Replace("+None", ""))
            {
                SettingsForm.settings.Hotkey.Modifiers = key.ConvertToString(e.Modifiers);
                SettingsForm.settings.Hotkey.Key = key.ConvertToString(e.KeyCode);
                DialHotkey.Text = key.ConvertToString(e.Modifiers).Replace("+None", "") + "+" + key.ConvertToString(e.KeyCode).Replace("+None", "");
            }
        }
    }
}
