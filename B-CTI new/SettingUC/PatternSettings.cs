using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BCTI.Helpers;
using System.IO;
using BCTI.CustomControls;
using BCTI.DialogBoxes;

namespace BCTI.SettingUC
{
    public partial class PatternSettings : UserControl
    {
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        public PatternSettings()
        {
            InitializeComponent();

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            UserInterfaceAPI.InitFonts(this);

            SettingsForm.ApplySettings += SettingsForm_ApplySettings;
            PatternPath.Text = SettingsForm.settings.Pattern.PatternFilePath;

            clearButton.Visible = (!string.IsNullOrEmpty(PatternPath.Text));

            if (!string.IsNullOrEmpty(BLFPanel.Staticsettings.Pattern.PatternFilePath))
            {
                if (File.Exists(BLFPanel.Staticsettings.Pattern.PatternFilePath))
                {
                    patternTableGroupBox.Show();
                    var patterns = File.ReadAllLines(BLFPanel.Staticsettings.Pattern.PatternFilePath, Encoding.GetEncoding(1251));
                    foreach (var pattern in patterns)
                    {
                        Pattern tempPattern = new Pattern(pattern);
                        BPatternRow curr = new BPatternRow(tempPattern);

                        curr.buttonDownClick += PatternRow_buttonDownClick;
                        curr.buttonUpClick += PatternRow_buttonUpClick;
                        curr.DeleteButtonClick += PatternRow_DeleteButtonClick;

                        patternTable.Controls.Add(curr);
                    }
                }
            }
            else
            {
                string pattern = "Prepend;Prefix;Match";
                patternTable.Controls.Add(new BPatternRow(new Pattern(pattern)));
            }
            PatternPathLabel.Location = new Point(patternTable.Padding.Horizontal / 2 + patternTable.Margin.Horizontal / 2 - patternTable.Location.X, PatternPathLabel.Location.Y);
        }

        private void PatternRow_DeleteButtonClick(object sender, EventArgs e)
        {
            patternTable.Controls.Remove(sender as Control);
        }

        private void PatternRow_buttonUpClick(object sender, EventArgs e)
        {
            BPatternRow temp = sender as BPatternRow;
            if (patternTable.Controls.IndexOf(temp) != 1)
            {
                string h = ((BPatternRow)patternTable.Controls[patternTable.Controls.IndexOf(temp) - 1]).currentPattern.ToString();
                ((BPatternRow)patternTable.Controls[patternTable.Controls.IndexOf(temp) - 1]).ChangePattern(new Pattern(temp.currentPattern.ToString()));
                temp.ChangePattern(new Pattern(h));
            }
        }

        private void PatternRow_buttonDownClick(object sender, EventArgs e)
        {
            BPatternRow temp = sender as BPatternRow;
            if (patternTable.Controls.IndexOf(temp) != patternTable.Controls.Count - 1)
            {
                string h = ((BPatternRow)patternTable.Controls[patternTable.Controls.IndexOf(temp) + 1]).currentPattern.ToString();
                ((BPatternRow)patternTable.Controls[patternTable.Controls.IndexOf(temp) + 1]).ChangePattern(new Pattern(temp.currentPattern.ToString()));
                temp.ChangePattern(new Pattern(h));
            }
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
        }

        private void SettingsForm_ApplySettings(object sender, EventArgs e)
        {
            List<string> newPattern = new List<string>();
            if (patternTableGroupBox.Visible)
            {
                foreach (Control row in patternTable.Controls)
                {
                    if (typeof(BPatternRow) == row.GetType())
                        newPattern.Add(((BPatternRow)row).currentPattern.ToString());
                }
            }
            if (!string.IsNullOrEmpty(SettingsForm.settings.Pattern.PatternFilePath))
                File.WriteAllLines(SettingsForm.settings.Pattern.PatternFilePath, newPattern.ToArray(), Encoding.GetEncoding(1251));
            else
            {
                File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\PatternFile.txt", newPattern.ToArray(), Encoding.GetEncoding(1251));
                SettingsForm.settings.Pattern.PatternFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\PatternFile.txt";
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PatternPath.Text))
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Текстовые файлы(*.txt)|*.txt";
                if (save.ShowDialog(this) == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(save.FileName))
                        SettingsForm.settings.Pattern.PatternFilePath = PatternPath.Text;
                    else SettingsForm.settings.Pattern.PatternFilePath = save.FileName;
                    PatternPath.Text = SettingsForm.settings.Pattern.PatternFilePath.Clone() as string;
                }
            }
            else
            {
                PatternPAthFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt";
                if (PatternPAthFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    clearButton.Visible = true;
                    if (string.IsNullOrEmpty(PatternPAthFileDialog.FileName))
                        SettingsForm.settings.Pattern.PatternFilePath = PatternPath.Text;
                    else SettingsForm.settings.Pattern.PatternFilePath = PatternPAthFileDialog.FileName;
                    PatternPath.Text = SettingsForm.settings.Pattern.PatternFilePath.Clone() as string;

                    patternTableGroupBox.Hide();
                    if (!string.IsNullOrEmpty(SettingsForm.settings.Pattern.PatternFilePath))
                        if (File.Exists(SettingsForm.settings.Pattern.PatternFilePath))
                        {
                            patternTableGroupBox.Show();
                            patternTable.Controls.Clear();
                            var patterns = File.ReadAllLines(SettingsForm.settings.Pattern.PatternFilePath, Encoding.GetEncoding(1251));
                            foreach (var pattern in patterns)
                            {
                                Pattern tempPattern = new Pattern(pattern);
                                BPatternRow curr = new BPatternRow(tempPattern);

                                curr.buttonDownClick += PatternRow_buttonDownClick;
                                curr.buttonUpClick += PatternRow_buttonUpClick;
                                curr.DeleteButtonClick += PatternRow_DeleteButtonClick;

                                patternTable.Controls.Add(curr);
                            }
                        }
                }
            }
        }

        private void addRow_Click(object sender, EventArgs e)
        {
            BPatternRow curr = new BPatternRow();
            patternTable.Controls.Add(curr);

            curr.buttonDownClick += PatternRow_buttonDownClick;
            curr.buttonUpClick += PatternRow_buttonUpClick;
            curr.DeleteButtonClick += PatternRow_DeleteButtonClick;
        }

        private void clearButton_MouseClick(object sender, MouseEventArgs e)
        {
            clearButton.Visible = false;
            patternTable.Controls.Clear();
            PatternPath.Text = string.Empty;
            SettingsForm.settings.Pattern.PatternFilePath = string.Empty;
            patternTable.Controls.Add(new BPatternRow(new Pattern("Prepend;Prefix;Match")));
        }
    }
}
