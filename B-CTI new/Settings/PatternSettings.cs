using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCTI.Settings
{
    public class PatternSettings : ICloneable
    {
        private readonly IniSettings ini = new IniSettings();
        public string PatternFilePath = string.Empty;

        public PatternSettings()
        {
            ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\UserSettings.ini";

            if (!string.IsNullOrEmpty(ini.IniReadValue("PatternSettings", "PatternFilePath")))
                PatternFilePath = ini.IniReadValue("PatternSettings", "PatternFilePath");
            else
                try
                {
                    PatternFilePath = Environment.CurrentDirectory + "\\DefaultPattern.txt";
                }
                catch
                {
                    PatternFilePath = "";
                }
        }

        public void Save()
        {
            ini.IniWriteValue("PatternSettings", "PatternFilePath", PatternFilePath);
        }

        public object Clone()
        {
            return new PatternSettings { PatternFilePath = (string)this.PatternFilePath.Clone() };
        }
    }
}
