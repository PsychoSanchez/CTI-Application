using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCTI.Settings
{
    public class SystemSettings : ICloneable
    {
        private readonly IniSettings ini = new IniSettings();
        public bool bOnWindowsStartup = false;

        public SystemSettings()
        {
            ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\UserSettings.ini";

            string temp = string.Empty;
            temp = ini.IniReadValue("SystemSettings", "OnWindowsStartUp");
            if (temp.ToLower().Contains("true"))
                bOnWindowsStartup = true;
            else if (temp.ToLower().Contains("false"))
                bOnWindowsStartup = false;
        }

        public void Save()
        {
            ini.IniWriteValue("SystemSettings", "OnWindowsStartUp", bOnWindowsStartup.ToString());
        }

        public object Clone()
        {
            return new SystemSettings { bOnWindowsStartup = this.bOnWindowsStartup };
        }
    }
}
