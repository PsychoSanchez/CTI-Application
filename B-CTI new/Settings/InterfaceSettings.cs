using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCTI.Settings
{
    public class InterfaceSettings : ICloneable
    {
        private readonly IniSettings ini = new IniSettings();
        public string Language = "Russian";
        public string ThemeStyle = "Default";
        public bool CompatibleXP = false;

        public InterfaceSettings()
        {
            ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\UserSettings.ini";

            Language = ini.IniReadValue("Interface", "language");
            ThemeStyle = ini.IniReadValue("Interface", "ThemeStyle");
            try
            {
                CompatibleXP = bool.Parse(ini.IniReadValue("Interface", "UseXPRendering"));
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }
        }

        public void Save()
        {
            ini.IniWriteValue("Interface", "language", Language);
            ini.IniWriteValue("Interface", "ThemeStyle", ThemeStyle);
            ini.IniWriteValue("Interface", "UseXPRendering", CompatibleXP.ToString());
        }

        public object Clone()
        {
            return new InterfaceSettings { Language = this.Language, ThemeStyle = this.ThemeStyle, CompatibleXP = this.CompatibleXP };
        }
    }
}
