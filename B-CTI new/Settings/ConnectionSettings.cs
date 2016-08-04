using AsteriskManager;
using System;
using BCTI.Settings;
using BCTI.Helpers;
using System.IO;
using System.Windows.Forms;

namespace BCTI
{
    /// <summary>
    /// Класс с настройками подключения
    /// </summary>
    public class ConnectionSettings
    {
        public string Username = string.Empty;
        public string Password = string.Empty;
        public string IP = string.Empty;
        public string Port = string.Empty;
        public string Number = string.Empty;
        public bool Autoconnect = false;
        public bool MD5 = true;
        private bool IsNoDefaults = false;

        private string autoconnstring = string.Empty;
        private string _AutoConnect
        {
            set
            {
                if (value.ToLower().Contains("true"))
                {
                    Autoconnect = true;
                }
                else if (value.ToLower().Contains("false"))
                {
                    Autoconnect = false;
                }
                autoconnstring = value;
            }
            get { return autoconnstring; }
        }
        private string _MD5
        {
            set
            {
                if (value.ToLower().Contains("true"))
                {
                    MD5 = true;
                }
                else if (value.ToLower().Contains("false"))
                {
                    MD5 = false;
                }
            }
        }

        public IniSettings ini = new IniSettings();
        public ConnectionSettings()
        {
            EventLogs.WriteLog("Loading settings");
            ini.path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\B-CtiSys.ini";
            Number = ini.IniReadValue(Helper.MachineID, "Number");
            if (string.IsNullOrEmpty(ini.IniReadValue(Helper.MachineID, "AMILogin")) ||
                   string.IsNullOrEmpty(ini.IniReadValue(Helper.MachineID, "AMIPassword")) ||
                   string.IsNullOrEmpty(ini.IniReadValue(Helper.MachineID, "IP")) ||
                   string.IsNullOrEmpty(ini.IniReadValue(Helper.MachineID, "Port")))
            {
                if (string.IsNullOrEmpty(ini.IniReadValue("All", "AMILogin")) ||
                  string.IsNullOrEmpty(ini.IniReadValue("All", "AMIPassword")) ||
                  string.IsNullOrEmpty(ini.IniReadValue("All", "IP")) ||
                  string.IsNullOrEmpty(ini.IniReadValue("All", "Port")))
                {
                    EventLogs.WriteLog("No defaults settings");
                    IsNoDefaults = true;
                }
                EventLogs.WriteLog("Loading defaults settings");
                Username = ini.IniReadValue("All", "AMILogin");
                Password = Encrypter.Decrypt(ini.IniReadValue("All", "AMIPassword"),
                    "BasteriskSuccededEncrypt");
                IP = ini.IniReadValue("All", "IP").Replace(",", ".").Replace(" ", "");
                Port = ini.IniReadValue("All", "Port");
                _MD5 = ini.IniReadValue("All", "MD5");
            }
            else
            {
                EventLogs.WriteLog("Loading " + Helper.MachineID + "settings");
                Username = ini.IniReadValue(Helper.MachineID, "AMILogin");
                Password = Encrypter.Decrypt(ini.IniReadValue(Helper.MachineID, "AMIPassword"),
                    "BasteriskSuccededEncrypt");
                IP = ini.IniReadValue(Helper.MachineID, "IP").Replace(",", ".").Replace(" ", "");
                Port = ini.IniReadValue(Helper.MachineID, "Port");
                _MD5 = ini.IniReadValue(Helper.MachineID, "MD5");
            }
            if (string.IsNullOrEmpty(Port))
            {
                Port = "5038";
            }
            ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/B-Cti/UserSettings.ini";
            if (string.IsNullOrEmpty(Number))
            {
                EventLogs.WriteLog("Loading number from UserSettings");
                Number = ini.IniReadValue("Connection", "Number");
            }
            _AutoConnect = ini.IniReadValue("Connection", "Autoconnect");
        }
        public bool SaveSettings()
        {
            try
            {
                EventLogs.WriteLog("Сохраняем настройки подключения");
                ini.path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\B-CtiSys.ini";
                if (IsNoDefaults)
                {
                    ini.IniWriteValue("All", "AMILogin", Username);
                    ini.IniWriteValue("All", "AMIPassword", Encrypter.Encrypt(Password, "BasteriskSuccededEncrypt"));
                    ini.IniWriteValue("All", "IP", IP);
                    ini.IniWriteValue("All", "Port", Port);
                    ini.IniWriteValue("All", "MD5", MD5.ToString());
                    ini.IniWriteValue(Helper.MachineID, "AMILogin", Username);
                    ini.IniWriteValue(Helper.MachineID, "AMIPassword", Encrypter.Encrypt(Password, "BasteriskSuccededEncrypt"));
                    ini.IniWriteValue(Helper.MachineID, "IP", IP);
                    ini.IniWriteValue(Helper.MachineID, "Port", Port);
                    ini.IniWriteValue(Helper.MachineID, "MD5", MD5.ToString());
                    ini.IniWriteValue(Helper.MachineID, "Number", Number);
                    ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/B-Cti/UserSettings.ini";
                    ini.IniWriteValue("Connection", "Autoconnect", Autoconnect.ToString());
                    //ini.IniWriteValue(Helper.MachineID, "Autoconnect", Autoconnect.ToString());
                }
                else
                {
                    if (RightsChecker.IsUserAdministrator())
                    {
                        ini.IniWriteValue(Helper.MachineID, "AMILogin", Username);
                        ini.IniWriteValue(Helper.MachineID, "AMIPassword", Encrypter.Encrypt(Password, "BasteriskSuccededEncrypt"));
                        ini.IniWriteValue(Helper.MachineID, "IP", IP);
                        ini.IniWriteValue(Helper.MachineID, "Port", Port);
                        ini.IniWriteValue(Helper.MachineID, "MD5", MD5.ToString());
                        ini.IniWriteValue(Helper.MachineID, "Number", Number);
                        //ini.IniWriteValue(Helper.MachineID, "Autoconnect", Autoconnect.ToString());
                    }
                    else
                    {
                        ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/B-Cti/UserSettings.ini";
                        ini.IniWriteValue("Connection", "Number", Number);
                    }
                    ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/B-Cti/UserSettings.ini";
                    ini.IniWriteValue("Connection", "Autoconnect", Autoconnect.ToString());
                }
                return true;
            }
            catch (Exception ex)
            {

                ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/B-Cti/UserSettings.ini";
                ini.IniWriteValue("Connection", "Number", Number);
                ini.IniWriteValue("Connection", "Autoconnect", Autoconnect.ToString());
                EventLogs.WriteLog(ex.Message, "Не удалось сохранить настройки подключения");
                return false;
            }
        }

    }
}
