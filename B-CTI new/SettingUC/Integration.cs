using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;
using System.Collections.Generic;
using BCTI.Helpers;

namespace BCTI.SettingUC
{
    public partial class Integration : UserControl
    {
        /// <summary>
        /// Ключи для Callto и TellTo
        /// </summary>
        //RegistryKey rkApp;
        //RegistryKey rkTel;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        /// <summary>
        /// Конструтор контрола интеграции
        /// </summary>
        public Integration()
        {
            InitializeComponent();
            Sipaddheader.Text = BLFPanel.Staticsettings.Integration.SIPADDHEADER;
            CallerIDlabel.Text = BLFPanel.Staticsettings.Integration.CallerID;

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            try
            {
                TraySettings.Text = Localization[TraySettings.Name][0];
            }
            catch (Exception ex)
            {
                TraySettings.Text = "Ассоциации файлов";
                EventLogs.WriteLog("Ошибка локализации", ex.StackTrace);
            }
            try
            {
                CallToCheckBox.Text = Localization[CallToCheckBox.Name][0] + "callto:";
            }
            catch (Exception ex)
            {
                CallToCheckBox.Text = "Ассоциациация с callto:";
                EventLogs.WriteLog("Ошибка локализации", ex.StackTrace);
            }
            CallToCheckBox.Checked_Changed += RegisterDefaultCallto_Checked_Changed;
            try
            {
                BasterToCheckBox.Text = Localization[CallToCheckBox.Name][0] + "basterto:";
            }
            catch (Exception ex)
            {
                BasterToCheckBox.Text = "Ассоциациация c basterto:";
                EventLogs.WriteLog("Ошибка локализации", ex.StackTrace);
            }
            BasterToCheckBox.Checked_Changed += BasterToCheckBox_Checked_Changed;
            try
            {
                TelCheckBox.Text = Localization[CallToCheckBox.Name][0] + "tel:";
            }
            catch (Exception ex)
            {
                TelCheckBox.Text = "Ассоциациация с tel:";
                EventLogs.WriteLog("Ошибка локализации", ex.StackTrace);
            }
            TelCheckBox.Checked_Changed += TelCheckBox_Checked_Changed;


            try
            {
                ///Сначала проверяем значение без попытки открытия на запись, затем с открытием
                CallToCheckBox.Checked = CheckReg("callto", false);
                CallToCheckBox.Checked = CheckReg("callto", true);
            }
            catch (System.Security.SecurityException ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
                try
                {
                    CallToCheckBox.Text = Localization[CallToCheckBox.Name][1];
                }
                catch
                {
                    CallToCheckBox.Text = "Ассоциациация с callto (Нет прав доступа)";
                    EventLogs.WriteLog("Ошибка локализации", ex.StackTrace);
                }
                CallToCheckBox.Enabled = false;
                CallToCheckBox.ForeColor = SystemColors.ButtonHighlight;
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }
            try
            {
                ///Сначала проверяем значение без попытки открытия на запись, затем с открытием
                TelCheckBox.Checked = CheckReg("tel", false);
                TelCheckBox.Checked = CheckReg("tel", true);
            }
            catch (System.Security.SecurityException ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
                try
                {
                    TelCheckBox.Text = Localization[TelCheckBox.Name][0];
                }
                catch
                {
                    TelCheckBox.Text = "Ассоциациация с tel (Нет прав доступа)";
                    EventLogs.WriteLog("Ошибка локализации", ex.StackTrace);
                }
                TelCheckBox.Enabled = false;
                TelCheckBox.ForeColor = SystemColors.ButtonHighlight;
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }
            try
            {
                ///Сначала проверяем значение без попытки открытия на запись, затем с открытием
                BasterToCheckBox.Checked = CheckReg("basterto", false);
                BasterToCheckBox.Checked = CheckReg("basterto", true);
            }
            catch (System.Security.SecurityException ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
                try
                {
                    BasterToCheckBox.Text = Localization[BasterToCheckBox.Name][0];
                }
                catch
                {
                    BasterToCheckBox.Text = "Ассоциациация с basterto (Нет прав доступа)";
                    EventLogs.WriteLog("Ошибка локализации", ex.StackTrace);
                }
                BasterToCheckBox.Enabled = false;
                BasterToCheckBox.ForeColor = SystemColors.ButtonHighlight;
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }

            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(TraySettings, FontStyle.Bold | FontStyle.Italic);
        }

        private void TelCheckBox_Checked_Changed(object sender, EventArgs e)
        {
            if (TelCheckBox.Checked)
            {
                ///Код для скрипта в инсталятор
                RegisterCapatibilities();
                try
                {
                    CreateRegRoot("tel", filepath);
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                    TelCheckBox.Checked = false;
                }
            }
            else
            {
                try
                {
                    //\"C:\\Program Files (x86)\\Skype\\Phone\\Skype.exe\" \"/uri: %l\"
                    CreateRegRoot("tel", "");
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                    TelCheckBox.Checked = true;
                }
            }
        }

        string filepath = "\"" + Assembly.GetExecutingAssembly().Location + "\"" + " \"bcti:%1\"";
        private void BasterToCheckBox_Checked_Changed(object sender, EventArgs e)
        {
            if (BasterToCheckBox.Checked)
            {
                ///Код для скрипта в инсталятор
                RegisterCapatibilities();
                try
                {
                    CreateRegRoot("basterto", filepath);
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                    BasterToCheckBox.Checked = false;
                }
            }
            else
            {
                try
                {
                    CreateRegRoot("basterto", "");
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                    BasterToCheckBox.Checked = true;
                }
            }
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Dictionary<string, string[]> curr = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            try
            {
                TraySettings.Text = curr[TraySettings.Name][0];
            }
            catch
            {
                TraySettings.Text = "Ассоциации файлов";
            }

            string register = string.Empty;
            try
            {
                register = Localization[CallToCheckBox.Name][1];
            }
            catch
            {
                register = "Ассоциациация с callto (Нет прав доступа)";
            }

            if (CallToCheckBox.Text == register)
                try
                {
                    CallToCheckBox.SetText(curr[CallToCheckBox.Name][1]);
                }
                catch
                {
                    CallToCheckBox.SetText("Ассоциациация с callto (Нет прав доступа)");
                }
            else
                try
                {
                    CallToCheckBox.SetText(curr[CallToCheckBox.Name][0] + "callto:, tel:, basterto:");
                }
                catch
                {
                    CallToCheckBox.SetText("Ассоциация с callto:, tel:, basterto:");
                }
            Localization = curr;
        }
        /// <summary>
        /// Регистрация в реестре приложений для запуска приложения по умолчанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterDefaultCallto_Checked_Changed(object sender, EventArgs e)
        {
            if (CallToCheckBox.Checked)
            {
                ///Код для скрипта в инсталятор
                RegisterCapatibilities();
                try
                {
                    CreateRegRoot("callto", filepath);
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                    CallToCheckBox.Checked = false;
                }
            }
            else
            {
                try
                {
                    CreateRegRoot("callto", "");
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                    CallToCheckBox.Checked = true;
                }
            }
        }
        private void RegisterCapatibilities()
        {
            RegistryKey key;
            try
            {
                key = Registry.LocalMachine.OpenSubKey("Software", true);
                key.CreateSubKey("BAsterisk");
                key = key.OpenSubKey("BAsterisk", true);
                key.CreateSubKey("B-CTI");
                key = key.OpenSubKey("B-CTI", true);
                key.SetValue("", "B-CTI");
                key.CreateSubKey("Capabilities");
                key = key.OpenSubKey("Capabilities", true);
                key.SetValue("ApplicationDescription ", "B-CTI Application");
                key.SetValue("ApplicationName ", "B-CTI");
                key.CreateSubKey("URLAssociations");
                key = key.OpenSubKey("URLAssociations", true);
                key.SetValue("callto ", "B-CTI");
                key.SetValue("tel", "B-CTI");
                key.SetValue("basterto", "B-CTI");
                key.Close();
                key = Registry.LocalMachine.OpenSubKey("Software", true);
                key = key.OpenSubKey("RegisteredApplications", true);
                key.SetValue("B-CTI ", "SOFTWARE\\BAsterisk\\B-CTI\\Capabilities");
                key.Close();
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }
            try
            {
                key = Registry.LocalMachine.OpenSubKey("Software", true);
                key.OpenSubKey("WOW6432Node", true);
                key.CreateSubKey("BAsterisk");
                key = key.OpenSubKey("BAsterisk", true);
                key.CreateSubKey("B-CTI");
                key = key.OpenSubKey("B-CTI", true);
                key.SetValue("", "B-CTI");
                key.CreateSubKey("Capabilities");
                key = key.OpenSubKey("Capabilities", true);
                key.SetValue("ApplicationDescription ", "B-CTI Application");
                key.SetValue("ApplicationName ", "B-CTI");
                key.CreateSubKey("URLAssociations");
                key = key.OpenSubKey("URLAssociations", true);
                key.SetValue("callto ", "B-CTI");
                key.SetValue("tel", "B-CTI");
                key.SetValue("basterto", "B-CTI");
                key.Close();
                key = Registry.LocalMachine.OpenSubKey("Software", true);
                key = key.OpenSubKey("RegisteredApplications", true);
                key.SetValue("B-CTI ", "SOFTWARE\\BAsterisk\\B-CTI\\Capabilities");
                key.Close();
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }
        }
        /// <summary>
        /// Функция для проверки наличия записи в реестре
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        private bool CheckReg(string Key, bool HasRights)
        {
            RegistryKey reg = Registry.ClassesRoot.OpenSubKey(Key + "\\shell\\Open\\command", HasRights);
            var filepath = Assembly.GetExecutingAssembly().Location;
            filepath = "\"" + filepath + "\"" + " \"bcti:%1\"";
            return (string)reg.GetValue("") == filepath;
        }
        /// <summary>
        /// Создает ветку в случае ее полного отсутствия в реестре или ее частей
        /// </summary>
        private void CreateRegRoot(string Key, string Value)
        {
            RegistryKey reg;
            if (Registry.ClassesRoot.OpenSubKey(Key) == null)
            {
                Registry.ClassesRoot.CreateSubKey(Key);
                reg = Registry.ClassesRoot.OpenSubKey(Key, true);
                reg.SetValue("URL Protocol", "");
                reg.SetValue("", "URL : callto protocol handler");
                reg.Close();
                Registry.ClassesRoot.CreateSubKey(Key + "\\shell");
                Registry.ClassesRoot.CreateSubKey(Key + "\\shell\\Open");
                Registry.ClassesRoot.CreateSubKey(Key + "\\shell\\Open\\command");
                reg = Registry.ClassesRoot.OpenSubKey(Key + "\\shell\\Open\\command", true);
                reg.SetValue("", Value);
                reg.Close();
            }
            else if (Registry.ClassesRoot.OpenSubKey(Key + "\\shell") == null)
            {
                Registry.ClassesRoot.CreateSubKey(Key + "\\shell");
                Registry.ClassesRoot.CreateSubKey(Key + "\\shell\\Open");
                Registry.ClassesRoot.CreateSubKey(Key + "\\shell\\Open\\command");
                reg = Registry.ClassesRoot.OpenSubKey(Key + "\\shell\\Open\\command", true);
                reg.SetValue("", Value);
                reg.Close();
            }
            else if (Registry.ClassesRoot.OpenSubKey(Key + "\\shell\\Open") == null)
            {
                Registry.ClassesRoot.CreateSubKey(Key + "\\shell\\Open");
                Registry.ClassesRoot.CreateSubKey(Key + "\\shell\\Open\\command");
                reg = Registry.ClassesRoot.OpenSubKey(Key + "\\shell\\Open\\command", true);
                reg.SetValue("", Value);
                reg.Close();
            }
            else if (Registry.ClassesRoot.OpenSubKey(Key + "\\shell\\Open\\command") == null)
            {
                Registry.ClassesRoot.CreateSubKey(Key + "\\shell\\Open\\command");
                reg = Registry.ClassesRoot.OpenSubKey(Key + "\\shell\\Open\\command", true);
                reg.SetValue("", Value);
                reg.Close();
            }
            else
            {
                reg = Registry.ClassesRoot.OpenSubKey(Key + "\\shell\\Open\\command", true);
                reg.SetValue("", Value);
                reg.Close();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SettingsForm.settings.Integration.SIPADDHEADER = Sipaddheader.Text;
        }

        private void CallerIDlabel_TextChanged(object sender, EventArgs e)
        {
            SettingsForm.settings.Integration.CallerID = CallerIDlabel.Text;
        }
    }
}
