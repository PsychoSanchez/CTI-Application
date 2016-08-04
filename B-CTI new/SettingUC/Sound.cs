using BCTI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI.SettingUC
{
    /// <summary>
    /// Дорабатывается (!)
    /// </summary>
    public partial class Sound : UserControl
    {
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        public Sound()
        {
            InitializeComponent();
            SoundSplash.Text = "Включить звук для уведомлений";

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            Ringtone.SelectedItem = Ringtone.Items[0];
            ///Шрифты
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(groupBox1, FontStyle.Bold | FontStyle.Italic);
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Play_Click(object sender, EventArgs e)
        {
        }

        private void Sound_Load(object sender, EventArgs e)
        {
        }
    }
}
