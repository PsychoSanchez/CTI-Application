using System;

namespace BCTI.SettingClasses
{
    public class ScriptSettings : ICloneable
    {
        private readonly IniSettings _ini = new IniSettings();
        public string ParamString;
        public string BatFilePath;

        public ScriptSettings()
        {
            ParamString = _ini.IniReadValue("ScriptSettings", "ScriptParams");
            BatFilePath = _ini.IniReadValue("Directories", "ScriptPath");
        }

        public void Save()
        {
            try
            {
                _ini.IniWriteValue("ScriptSettings", "ScriptParams", ParamString);
                _ini.IniWriteValue("Directories", "ScriptPath", BatFilePath);
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, "Не удалось сохранить настройки скрипта");
            }
        }
        
        public object Clone()
        {
            return new ScriptSettings { ParamString = this.ParamString, BatFilePath = this.BatFilePath };
        }
    }
}
