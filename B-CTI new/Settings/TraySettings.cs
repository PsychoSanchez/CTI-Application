using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCTI.Settings
{
    public class TraySettings : ICloneable
    {
        IniSettings ini = new IniSettings();
        public bool bMinimizedToTray = true;
        public bool bOneClickOpen = false;
        public bool bTrayEnabled = true;

        public TraySettings()
        {
            ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\UserSettings.ini";

            string temp;
            temp = ini.IniReadValue("Tray", "MinimizeToTray");
            if (temp.ToLower().Contains("true"))
                bMinimizedToTray = true;
            else if (temp.ToLower().Contains("false"))
                bMinimizedToTray = false;
            temp = ini.IniReadValue("Tray", "OneClickOpen");
            if (temp.ToLower().Contains("true"))
                bOneClickOpen = true;
            else if (temp.ToLower().Contains("false"))
                bOneClickOpen = false;
            temp = ini.IniReadValue("Tray", "TrayEnabled");
            if (temp.ToLower().Contains("true"))
                bTrayEnabled = true;
            else if (temp.ToLower().Contains("false"))
                bTrayEnabled = false;
        }

        public void Save()
        {
            ini.IniWriteValue("Tray", "MinimizeToTray", bMinimizedToTray.ToString());
            ini.IniWriteValue("Tray", "OneClickOpen", bOneClickOpen.ToString());
            ini.IniWriteValue("Tray", "TrayEnabled", bTrayEnabled.ToString());
        }

        public object Clone()
        {
            return new TraySettings { bMinimizedToTray = this.bMinimizedToTray, bOneClickOpen = this.bOneClickOpen, bTrayEnabled = this.bTrayEnabled };
        }
    }
}
