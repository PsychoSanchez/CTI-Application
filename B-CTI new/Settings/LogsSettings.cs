using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCTI.Settings
{
    public class LogsSettings : ICloneable
    {
        private readonly IniSettings ini = new IniSettings();
        public bool bAmiLogEnabled = true;
        public bool bEventLogEnabled = true;
        public string EventLogFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\";
        public string AmiLogFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\";
        public LogsSettings()
        {
            ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\UserSettings.ini";

            string temp;

            temp = ini.IniReadValue("Data", "AmiLogEnabled");
            if (temp.ToLower().Contains("true"))
                bAmiLogEnabled = true;
            else if (temp.ToLower().Contains("false"))
                bAmiLogEnabled = false;
            temp = ini.IniReadValue("Data", "EventLogEnabled");
            if (temp.ToLower().Contains("true"))
                bEventLogEnabled = true;
            else if (temp.ToLower().Contains("false"))
                bEventLogEnabled = false;
            if (!string.IsNullOrEmpty(ini.IniReadValue("Directories", "EventLogFolder")))
                EventLogFolder = ini.IniReadValue("Directories", "EventLogFolder");
            if (!string.IsNullOrEmpty(ini.IniReadValue("Directories", "AmiLogFolder")))
                AmiLogFolder = ini.IniReadValue("Directories", "AmiLogFolder");
        }

        public void Save()
        {
            ini.IniWriteValue("Data", "AmiLogEnabled", bAmiLogEnabled.ToString());
            ini.IniWriteValue("Data", "EventLogEnabled", bEventLogEnabled.ToString());
            ini.IniWriteValue("Directories", "EventLogFolder", EventLogFolder);
            ini.IniWriteValue("Directories", "AmiLogFolder", AmiLogFolder);
        }

        public object Clone()
        {
            return new LogsSettings { bAmiLogEnabled = this.bAmiLogEnabled, bEventLogEnabled = this.bEventLogEnabled, AmiLogFolder = this.AmiLogFolder, EventLogFolder = this.EventLogFolder };
        }
    }
}
