using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BCTI.CustomControls;
using BCTI.DialogBoxes;
using BCTI.Helpers;

namespace BCTI.SettingUC
{
    public partial class ScriptSettingsControl : UserControl
    {
        public List<string> paramNames = new List<string>();
        public string ScriptPath = string.Empty;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ScriptSettingsControl()
        {
            InitializeComponent();

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            ///Шрифты
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(groupBox1, FontStyle.Bold | FontStyle.Italic);
            UserInterfaceAPI.SetFontStyle(ParamsGroupBox, FontStyle.Bold | FontStyle.Italic);
            SettingsForm.ApplySettings += SettingsForm_ApplySettings;
            ///загружаем сохраненные настройки скрипта
            textBox1.Text = (string.IsNullOrEmpty(SettingsForm.settings.Script.BatFilePath) ? "" : SettingsForm.settings.Script.BatFilePath + " ") + SettingsForm.settings.Script.ParamString;
            CallerIDNumCheckBox.Text = "CallerIDNum";
            CallerIDNameCheckBox.Text = "CallerIDName";
            ConnectedLineNumCheckBox.Text = "ConnectedLineNum";
            ConnectedLineNameCheckBox.Text = "ConnectedLineName";
            ChannelCheckBox.Text = "Channel";
            DestinationCheckBox.Text = "Destination";
            CurrentStatusCheckBox.Text = "CurrentStatus";
            DialStatusCheckBox.Text = "DialStatus";
            UniqueidCheckBox.Text = "Uniqueid";
            Uniqueid2CheckBox.Text = "Uniqueid2";
            if (!string.IsNullOrEmpty(SettingsForm.settings.Script.ParamString))
            {
                if (SettingsForm.settings.Script.ParamString.Contains("CallerIDNum"))
                {
                    CallerIDNumCheckBox.Checked = true;
                    paramNames.Add("CallerIDNum");
                }
                if (SettingsForm.settings.Script.ParamString.Contains("CallerIDName"))
                {
                    CallerIDNameCheckBox.Checked = true;
                    paramNames.Add("CallerIDName");
                }
                if (SettingsForm.settings.Script.ParamString.Contains("ConnectedLineNum"))
                {
                    ConnectedLineNumCheckBox.Checked = true;
                    paramNames.Add("ConnectedLineNum");
                }
                if (SettingsForm.settings.Script.ParamString.Contains("ConnectedLineName"))
                {
                    ConnectedLineNameCheckBox.Checked = true;
                    paramNames.Add("ConnectedLineName");
                }
                if (SettingsForm.settings.Script.ParamString.Contains("Channel"))
                {
                    ChannelCheckBox.Checked = true;
                    paramNames.Add("Channel");
                }
                if (SettingsForm.settings.Script.ParamString.Contains("Destination"))
                {
                    DestinationCheckBox.Checked = true;
                    paramNames.Add("Destination");
                }
                if (SettingsForm.settings.Script.ParamString.Contains("CurrentStatus"))
                {
                    CurrentStatusCheckBox.Checked = true;
                    paramNames.Add("CurrentStatus");
                }
                if (SettingsForm.settings.Script.ParamString.Contains("DialStatus"))
                {
                    DialStatusCheckBox.Checked = true;
                    paramNames.Add("DialStatus");
                }
                if (SettingsForm.settings.Script.ParamString.Contains("Uniqueid"))
                {
                    UniqueidCheckBox.Checked = true;
                    paramNames.Add("Uniqueid");
                }
                if (SettingsForm.settings.Script.ParamString.Contains("Uniqueid2"))
                {
                    Uniqueid2CheckBox.Checked = true;
                    paramNames.Add("Uniqueid2");
                }

            }
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
        }

        private void SettingsForm_ApplySettings(object sender, EventArgs e)
        {
            SettingsForm.settings.Script.BatFilePath= ScriptPath;
            for (int i = 0; i < this.paramNames.Count; i++)
            {
                SettingsForm.settings.Script.ParamString += (!string.IsNullOrEmpty(paramNames[i]) ? paramNames[i] + " " : "");
            }
        }

        /// <summary>
        /// Диалог выбора файла скрипта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = FileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ScriptPath = FileDialog.FileName;
                ChangeParams();
            }
        }
        /// <summary>
        /// Обработчик выбора параметорв
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UniqueidCheckBox_Checked_Changed(object sender, EventArgs e)
        {
            BCheckbox temp = (BCheckbox)sender;
            if (!temp.Checked)
            {
                paramNames.Remove(temp.Text);
                ChangeParams();
            }
            else
            {
                if (paramNames.Count + 1 > 9)
                {
                    BMessageBox.Show(this, "Нельзя добавить больше 9 параметром");
                    temp.Checked = false;
                    temp.Update();
                    return;
                }
                paramNames.Add(temp.Text);
                ChangeParams();
            }
        }
        /// <summary>
        /// Изменение строки аргументов вызова файла скрипта
        /// </summary>
        private void ChangeParams()
        {
            textBox1.Text = ScriptPath;
            if (paramNames.Contains("CallerIDNum"))
                textBox1.Text += " CallerIDNum";
            if (paramNames.Contains("CallerIDName"))
                textBox1.Text += " CallerIDName";
            if (paramNames.Contains("ConnectedLineNum"))
                textBox1.Text += " ConnectedLineNum";
            if (paramNames.Contains("ConnectedLineName"))
                textBox1.Text += " ConnectedLineName";
            if (paramNames.Contains("Channel"))
                textBox1.Text += " Channel";
            if (paramNames.Contains("Destination"))
                textBox1.Text += " Destination";
            if (paramNames.Contains("CurrentStatus"))
                textBox1.Text += " CurrentStatus";
            if (paramNames.Contains("DialStatus"))
                textBox1.Text += " DialStatus";
            if (paramNames.Contains("Uniqueid"))
                textBox1.Text += " Uniqueid";
            if (paramNames.Contains("Uniqueid2"))
                textBox1.Text += " Uniqueid2";
        }
    }
}
