using System;
using System.Drawing;
using System.Windows.Forms;
using BCTI.SettingUC;
using System.IO;
using System.Collections.Generic;
using BCTI.Helpers;

namespace BCTI
{
    public partial class SettingsForm : Form
    {
        public static UserSettings settings;
        public static event EventHandler ApplySettings;
        public static event EventHandler Reconnect;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();

        public SettingsForm()
        {
            InitializeComponent();
            closeButton.BackgroundImage = closeButtonImage.Images[0];
            settings = new UserSettings();
            Initialize();
            SettingsTree.ExpandAll();
            leftResizer.BackColor = Colors.WhiteTheme.MainColor;

            Localization = Localizator.GetFormLocalization("SettingsForm", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            Localizator.MakeLocalizationNodes(SettingsTree.Nodes, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(CancellButton, FontStyle.Bold);
            //UserInterfaceAPI.SetFontStyle(AccButton, FontStyle.Bold);
            //UserInterfaceAPI.SetFontStyle(Defaults, FontStyle.Bold);
            headLabel.Font = new Font(headLabel.Font, FontStyle.Bold);
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization("SettingsForm", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            if (!Disposing && !IsDisposed)
                Localizator.MakeLocalizationNodes(SettingsTree.Nodes, Localization);
        }

        TreeNode Connection;

        public SettingsForm(string filepath)
        {
            InitializeComponent();
            this.Hide();
        }
        public void Initialize()
        {
            TreeNode Interface = new TreeNode("Внешний вид");
            Interface.Tag = new Interface();
            Interface.Name = "InterfaceNode";
            TreeNode Sound = new TreeNode("Звук");
            Sound.Tag = new Sound();
            Sound.Name = "SoundNode";
            TreeNode Hotkeys = new TreeNode("Горячие клавиши");
            Hotkeys.Tag = new Hotkeys();
            Hotkeys.Name = "HotkeysNode";

            TreeNode[] GeneralTrenodes = { Interface, Sound, Hotkeys };
            TreeNode General = new TreeNode("Общие", GeneralTrenodes);
            General.Tag = new GeneralSettings();
            General.Name = "GeneralNode";
            SettingsTree.Nodes.Add(General);

            TreeNode Logs = new TreeNode("Логи");
            Logs.Tag = new Debug();
            Logs.Name = "LogsNode";
            TreeNode Integration = new TreeNode("Интеграция");
            Integration.Tag = new Integration();
            Integration.Name = "IntegrationNode";
            TreeNode[] SavedDataTreeNodes = { Logs, Integration };
            TreeNode SavedData = new TreeNode("Данные", SavedDataTreeNodes);
            SavedData.Tag = new SavedData();
            SavedData.Name = "SavedDataNode";
            SettingsTree.Nodes.Add(SavedData);

            Connection = new TreeNode("Подключение");
            Connection.Tag = new ConnectionSettingsForm();
            Connection.Name = "ConnectionNode";
            SettingsTree.Nodes.Add(Connection);

            TreeNode Script = new TreeNode("Настройки скрипта");
            Script.Tag = new ScriptSettingsControl();
            Script.Name = "ScriptNode";
            SettingsTree.Nodes.Add(Script);

            TreeNode Pattern = new TreeNode("Шаблоны");
            Pattern.Name = "PatternNode";
            Pattern.Tag = new PatternSettings();
            SettingsTree.Nodes.Add(Pattern);

            SettingsTree.SelectedNode = SettingsTree.Nodes[0];
            SettingTab.Text = SettingsTree.SelectedNode.Text;
            var UC = (UserControl)SettingsTree.SelectedNode.Tag;
            UC.Dock = DockStyle.Fill;
            SettingTab.Controls.Add(UC);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            settings = null;
            Close();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackgroundImage = closeButtonImage.Images[1];
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            if (!this.IsDisposed && !this.Disposing)
                closeButton.BackgroundImage = closeButtonImage.Images[0];
        }

        private Point lastCursor;
        private Point lastForm;
        private bool isDragging = false;

        private void headPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;

            lastCursor = Cursor.Position;
            lastForm = this.Location;
        }

        private void headPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location =
                    Point.Add(lastForm, new Size(Point.Subtract(Cursor.Position, new Size(lastCursor))));
            }
        }

        private void headPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void SettingsTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //SettingTab.Controls.Clear();
            //if (e.Node.Tag != null)
            //{
            //    SettingTab.Text = e.Node.Text;
            //    var UC = (UserControl)e.Node.Tag;
            //    UC.Dock = DockStyle.Fill;
            //    UC.AutoScroll = true;
            //    UC.Padding = new Padding(0, 0, 1, 0);
            //    SettingTab.Controls.Add(UC);
            //}
            //else
            //{
            //    SettingTab.Text = "В разработке";
            //}
        }

        private void ApplySettings_Click(object sender, EventArgs e)
        {

            if (ApplySettings != null)
                ApplySettings.Invoke(this, null);
            var Conn = (ConnectionSettingsForm)Connection.Tag;

            if (Conn.ConnectSettingsChanged)
            {
                Reconnect?.Invoke(this, null);
            }
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            File.Delete(settings.SaveFilePath);
            SettingsTree.Nodes.Clear();
            settings = new UserSettings();
            SettingTab.Controls.Clear();
            Initialize();
            SettingsTree.ExpandAll();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (ApplySettings != null)
                ApplySettings.Invoke(this, null);
            var Conn = (ConnectionSettingsForm)Connection.Tag;

            if (Conn.ConnectSettingsChanged)
            {
                Reconnect?.Invoke(this, null);
            }
            Close();
        }
        private void rightSizer_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeWE;
        }

        private void rightSizer_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void downResizer_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeNS;
        }

        //bool resizing = false;
        Point oldPosition = new Point();

        private void rightSizer_MouseUp(object sender, MouseEventArgs e)
        {
            //resizing = false;
        }

        private void rightSizer_MouseDown(object sender, MouseEventArgs e)
        {
            //resizing = true;
            oldPosition = PointToScreen(Cursor.Position);
        }

        private void rightSizer_MouseMove(object sender, MouseEventArgs e)
        {
            //Point newPosition = PointToScreen(Cursor.Position);
            //if (resizing)
            //    this.Width += (newPosition.X - oldPosition.X);
            //oldPosition = newPosition;
        }

        private void leftSizer_MouseMove(object sender, MouseEventArgs e)
        {
            //Point newPosition = Cursor.Position;
            //if (resizing)
            //{
            //    this.Width += -(newPosition.X - this.Location.X);
            //    this.Location = new Point(newPosition.X, this.Location.Y);
            //}
            //oldPosition = newPosition;
        }

        private void topSizer_MouseMove(object sender, MouseEventArgs e)
        {
            //Point newPosition = Cursor.Position;
            //if (resizing)
            //{
            //    this.Height += -(newPosition.Y - this.Location.Y);
            //    this.Location = new Point(this.Location.X, newPosition.Y);
            //}
            //oldPosition = newPosition;
        }

        private void downResizer_MouseMove(object sender, MouseEventArgs e)
        {
            //Point newPosition = PointToScreen(Cursor.Position);
            //if (resizing)
            //    this.Height += (newPosition.Y - oldPosition.Y);
            //oldPosition = newPosition;
        }

        private void Defaults_MouseLeave(object sender, EventArgs e)
        {
            Label b = sender as Label;
            b.BackColor = Color.FromArgb(160, 160, 160);
        }

        private void Defaults_MouseEnter(object sender, EventArgs e)
        {
            Label b = sender as Label;
            b.BackColor = Color.FromArgb(102, 153, 255);
        }

        private void AcceptButton_MouseLeave(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.BackColor = Color.FromArgb(160, 160, 160);
        }

        private void AcceptButton_MouseEnter(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.BackColor = Color.FromArgb(102, 153, 255);
        }

        private void SettingsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SettingTab.Controls.Clear();
            if (e.Node.Tag != null)
            {
                SettingTab.Text = e.Node.Text;
                var UC = (UserControl)e.Node.Tag;
                UC.Dock = DockStyle.Fill;
                UC.AutoScroll = true;
                UC.Padding = new Padding(0, 0, 1, 0);
                SettingTab.Controls.Add(UC);
            }
            else
            {
                SettingTab.Text = "В разработке";
            }
        }
    }
}
