using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCTI.Settings
{
    public class IntegrationSettings : ICloneable
    {
        private readonly IniSettings ini = new IniSettings();
        public string CallerID = "";
        public string SIPADDHEADER = "=\"Call-Info:\\;answer-after=0\"";

        public IntegrationSettings()
        {
            ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\UserSettings.ini";

            CallerID = ini.IniReadValue("Integtarion", "CallerID");
            if (!string.IsNullOrEmpty(ini.IniReadValue("ServerSettings", "SIPADDHEADER")))
                SIPADDHEADER = ini.IniReadValue("ServerSettings", "SIPADDHEADER");
        }

        public void Save()
        {
            ini.IniWriteValue("Integtarion", "CallerID", CallerID);
            ini.IniWriteValue("ServerSettings", "SIPADDHEADER", SIPADDHEADER);
        }

        public object Clone()
        {
            return new IntegrationSettings { CallerID = this.CallerID, SIPADDHEADER = this.SIPADDHEADER };
        }
    }
}
