using BCTI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI.CustomControls
{
    public partial class QuickSearchCard : UserControl
    {
        public string SearchText = string.Empty;
        private string number = string.Empty;
        private PopupSearchPanel parent = null;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        public QuickSearchCard(string _searchtext, PopupSearchPanel _parent)
        {
            InitializeComponent();
            FilterText.BackColor = SystemColors.ControlLightLight;
            FilterText.ForeColor = Colors.WhiteTheme.ButtonMainColor;
            SearchText = _searchtext;
            FilterText.Text = _searchtext;
            parent = _parent;
            UserInterfaceAPI.InitFonts(this);
        }
        public QuickSearchCard(string _searchtext, string _number, PopupSearchPanel _parent)
        {
            InitializeComponent();
            FilterText.BackColor = SystemColors.ControlLightLight;
            FilterText.ForeColor = Colors.WhiteTheme.ButtonMainColor;

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            FilterText.Text = Localization[FilterText.Name][0];

            SearchText = _searchtext;
            number = _number;
            FilterText.Text = _searchtext + " (" + number +  ")";
            parent = _parent;
            UserInterfaceAPI.InitFonts(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (parent != null)
                parent.RaiseOnClickedEvent(SearchText);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            FilterText.BackColor = Colors.WhiteTheme.ButtonHover;
            FilterText.ForeColor = SystemColors.ControlLightLight;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            FilterText.BackColor = SystemColors.ControlLightLight;
            FilterText.ForeColor = Colors.WhiteTheme.ButtonMainColor;
        }
    }
}
