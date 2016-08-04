using System;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI.CustomControls
{
    public partial class BCheckbox : UserControl
    {
        #region Variables
        public bool Checked = false;
        public event EventHandler Checked_Changed;
        public new string Text = string.Empty;
        #endregion
        #region Конструкторы
        public BCheckbox()
        {
            InitializeComponent();
            UserInterfaceAPI.InitFonts(this);
        }
        public BCheckbox(bool IsChecked, string _Text)
        {
            this.EnabledChanged += BCheckbox_EnabledChanged;
            Checked = IsChecked;
            if (Checked)
            {
                CheckBoxPanel.BackColor = Color.FromArgb(102, 153, 255);
            }
            else
            {
                CheckBoxPanel.BackColor = SystemColors.ButtonHighlight;
            }
            InitializeComponent();
            CheckBoxText.Text = _Text;
            UserInterfaceAPI.InitFonts(this);
        }
        #endregion
        #region Handlers

        private void BCheckbox_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                if (Checked)
                {
                    CheckBoxPanel.BackColor = Color.FromArgb(102, 153, 255);
                    CheckBoxText.ForeColor = SystemColors.ControlText;
                }
                else
                {
                    CheckBoxPanel.BackColor = SystemColors.ButtonHighlight;
                    CheckBoxText.ForeColor = SystemColors.ControlText;
                }
            }
            else
            {
                if (Checked)
                {
                    CheckBoxPanel.BackColor = Color.FromArgb(200, 217, 255);
                    CheckBoxText.ForeColor = Colors.WhiteTheme.MainColor;
                }
                else
                {
                    CheckBoxPanel.BackColor = Colors.WhiteTheme.MainColor;
                    CheckBoxText.ForeColor = Colors.WhiteTheme.MainColor;
                }
            }
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            if (Checked)
            {
                CheckBoxPanel.BackColor = SystemColors.ButtonHighlight;
            }
            else
            {
                CheckBoxPanel.BackColor = Color.FromArgb(102, 153, 255);
            }
            Checked = !Checked;
            Checked_Changed?.Invoke(this, null);
        }

        private void BCheckbox_Load(object sender, EventArgs e)
        {
            this.CheckBoxText.Text = Text;
            if (Checked)
            {
                CheckBoxPanel.BackColor = Color.FromArgb(102, 153, 255);
            }
            else
            {
                CheckBoxPanel.BackColor = SystemColors.ButtonHighlight;
            }
            while (CheckBoxText.Width < System.Windows.Forms.TextRenderer.MeasureText(CheckBoxText.Text, new Font(CheckBoxText.Font.FontFamily, CheckBoxText.Font.Size, CheckBoxText.Font.Style)).Width)
            {
                CheckBoxText.Font = new Font(CheckBoxText.Font.FontFamily, CheckBoxText.Font.Size - 0.5f, CheckBoxText.Font.Style);
            }
        }

        private void CheckBoxPanel_MouseEnter(object sender, EventArgs e)
        {
            if (!Checked)
            {
                CheckBoxPanel.BackColor = SystemColors.GradientActiveCaption;
            }
            else
            {
                CheckBoxPanel.BackColor = Color.FromArgb(60, 123, 255);
            }
        }

        private void CheckBoxPanel_MouseLeave(object sender, EventArgs e)
        {
            if (!Checked)
            {
                CheckBoxPanel.BackColor = SystemColors.Window;
            }
            else
            {
                CheckBoxPanel.BackColor = Color.FromArgb(102, 153, 255);
            }
        }
        #endregion

        public void SetText(string _Text)
        {
            this.CheckBoxText.Text = _Text;
            Text = _Text;
        }
    }
}
