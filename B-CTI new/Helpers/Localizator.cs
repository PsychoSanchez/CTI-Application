using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BCTI.CustomControls;

namespace BCTI.Helpers
{
    class Localizator
    {
        public static List<string> GetLanguages()
        {
            List<string> Languages = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + "/Languages/");
            try
            {
                foreach (FileInfo file in dir.GetFiles())
                {
                    Languages.Add(file.Name.Replace(".blcl", ""));
                }
            }
            catch
            {
                Languages.Add("Russian");
                //if (!string.IsNullOrEmpty(BLFPanel.Staticsettings.Interface.Language))
                //    Languages.Add(BLFPanel.Staticsettings.Interface.Language);
            }
            return Languages;
        }
        public static Dictionary<string, string[]> GetFormLocalization(string FormName, string Language)
        {
            Dictionary<string, string[]> Localozation = new Dictionary<string, string[]>();
            bool FormFound = false;
            try
            {

                var Lines = File.ReadAllLines(Environment.CurrentDirectory + "/Languages/" + Language + ".blcl", System.Text.Encoding.GetEncoding(1251));
                foreach (var line in Lines)
                {
                    if (line == "[" + FormName + "]")
                    {
                        FormFound = true;
                        continue;
                    }
                    if (FormFound)
                    {
                        if (line != "[~" + FormName + "]")
                        {
                            int i = line.IndexOf("=");
                            if (i > 0)
                            {
                                string key = line.Substring(0, i);
                                string value = line.Substring(i + 1);
                                Localozation.Add(key, value.Split('/'));
                            }
                        }
                        else break;
                    }
                }
            }
            catch
            {

            }
            return Localozation;
        }

        public static void MakeLocalization(Control ctrl, Dictionary<string, string[]> Localization)
        {
            if (ctrl.Controls.Count > 0)
                foreach (Control subctrl in ctrl.Controls)
                {
                    MakeLocalization(subctrl, Localization);
                }
            if (!string.IsNullOrEmpty(ctrl.Name))
                if (Localization.ContainsKey(ctrl.Name))
                {
                    if (typeof(BCheckbox) == ctrl.GetType())
                    {
                        ((BCheckbox)ctrl).SetText(Localization[ctrl.Name][0]);
                    }
                    else if (!string.IsNullOrEmpty(ctrl.Text) || typeof(BCheckbox) == ctrl.GetType())
                        if (ctrl.Name != "BlfStatusLabel" && ctrl.Name != "BlfNumberLabel")
                            ctrl.Text = Localization[ctrl.Name][0];
                    if (ctrl.Name != "BlfStatusLabel" && ctrl.Name != "BlfNumberLabel")
                    {
                        if (!string.IsNullOrEmpty(Localization[ctrl.Name][0]) && Localization[ctrl.Name][0] != " ")
                        {
                            ToolTip tt = new ToolTip();
                            tt.SetToolTip(ctrl, null);
                        }

                    }
                }

        }

        public static void WriteAllContextMenu(ToolStrip ctrl)
        {
            foreach (var substrl in ((ContextMenuStrip)ctrl).Items)
            {
                if (typeof(ToolStripSeparator) != substrl.GetType())
                    WriteContextMenu((ToolStripMenuItem)substrl);
            }
            if (typeof(ToolStripSeparator) != ctrl.GetType())
            {
                StreamWriter sw = File.AppendText("names.txt");
                sw.WriteLine(ctrl.Name);
                sw.Flush();
                sw.Close();
            }
        }

        public static void MakeLocalizationAllContextMenu(ToolStrip ctrl, Dictionary<string, string[]> Localization)
        {
            if (typeof(ToolStripSeparator) == ctrl.GetType()) return;
            foreach (var substrl in ctrl.Items)
            {
                if (typeof(ToolStripSeparator) != substrl.GetType())
                    MakeLocalizationContextMenu((ToolStripMenuItem)substrl, Localization);
            }
            if (typeof(ToolStripSeparator) != ctrl.GetType())
            {
                if (!string.IsNullOrEmpty(ctrl.Name))
                    if (Localization.ContainsKey(ctrl.Name))
                    {
                        ctrl.Text = Localization[ctrl.Name][0];
                    }
            }
        }

        public static void MakeLocalizationNodes(TreeNodeCollection nodes, Dictionary<string, string[]> Localization)
        {
            foreach (TreeNode node in nodes)
            {
                MakeLocalizationNode(node, Localization);
            }
        }

        private static void MakeLocalizationNode(TreeNode node, Dictionary<string, string[]> Localization)
        {
            foreach (TreeNode subNode in node.Nodes)
            {
                MakeLocalizationNode(subNode, Localization);
            }
            if (!string.IsNullOrEmpty(node.Name))
                if (Localization.ContainsKey(node.Name))
                {
                    node.Text = Localization[node.Name][0];
                }
        }

        public static void MakeLocalizationContextMenu(ToolStripMenuItem ctrl, Dictionary<string, string[]> Localization)
        {
            if (typeof(ToolStripSeparator) == ctrl.GetType()) return;
            foreach (var substrl in ctrl.DropDownItems)
            {
                if (typeof(ToolStripSeparator) != substrl.GetType() && typeof(ToolStripTextBox) != substrl.GetType())
                    MakeLocalizationContextMenu((ToolStripMenuItem)substrl, Localization);
            }
            if (typeof(ToolStripSeparator) != ctrl.GetType())
            {
                if (!string.IsNullOrEmpty(ctrl.Name))
                    if (Localization.ContainsKey(ctrl.Name))
                    {
                        ctrl.Text = Localization[ctrl.Name][0];
                    }
            }
        }
        public static void WriteContextMenu(ToolStripMenuItem ctrl)
        {
            if (typeof(ToolStripSeparator) == ctrl.GetType()) return;
            foreach (var substrl in ctrl.DropDownItems)
            {
                if (typeof(ToolStripSeparator) != substrl.GetType())
                    WriteContextMenu((ToolStripMenuItem)substrl);
            }
            if (typeof(ToolStripSeparator) != ctrl.GetType())
            {
                StreamWriter sw = File.AppendText("names.txt");
                sw.WriteLine(ctrl.Name);
                sw.Flush();
                sw.Close();
            }
        }
        public static void WriteAllNames(Control ctrl)
        {
            StreamWriter sw = File.AppendText("names.txt");
            sw.WriteLine("[" + ctrl.Name + "]");
            sw.WriteLine("Russian");
            sw.Flush();
            sw.Close();
            WriteNames(ctrl);
            sw = File.AppendText("names.txt");
            sw.WriteLine("~Russian");
            sw.WriteLine("[~" + ctrl.Name + "]");
            sw.Flush();
            sw.Close();
        }

        public static void WriteNames(Control ctrl)
        {
            foreach (var substrl in ctrl.Controls)
            {
                WriteNames((Control)substrl);
            }
            if (typeof(Panel) != ctrl.GetType())
            {
                StreamWriter sw = File.AppendText("names.txt");
                sw.WriteLine(ctrl.Name);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
