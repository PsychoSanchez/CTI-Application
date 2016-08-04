using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BCTI.Helpers;
using BCTI.Properties;

namespace BCTI.CustomControls
{
    public partial class BPatternRow : UserControl
    {
        public Pattern currentPattern = null;
        public event EventHandler<EventArgs> DeleteButtonClick;
        public event EventHandler<EventArgs> buttonUpClick;
        public event EventHandler<EventArgs> buttonDownClick;

        public BPatternRow()
        {
            InitializeComponent();
            currentPattern = new Pattern();
        }
        public BPatternRow(Pattern newPattern)
        {
            InitializeComponent();
            currentPattern = newPattern;
            prependTextBox.Text = currentPattern._prepend;
            prefixTextBox.Text = currentPattern._prefix;
            matchTextBox.Text = currentPattern._match;
            matchTextBox.Enabled = newPattern._match != "Match";
            prefixTextBox.Enabled = newPattern._prefix != "Prefix";
            prependTextBox.Enabled = newPattern._prepend != "Prepend";

            buttonDown.Visible = !(newPattern._match == "Match"
            && newPattern._prefix == "Prefix"
            && newPattern._prepend == "Prepend");

            buttonUp.Visible = !(newPattern._match == "Match"
            && newPattern._prefix == "Prefix"
            && newPattern._prepend == "Prepend");

            deleteButton.Visible = !(newPattern._match == "Match"
            && newPattern._prefix == "Prefix"
            && newPattern._prepend == "Prepend");
        }

        public void ChangePattern(Pattern newPattern)
        {
            currentPattern = newPattern;
            prependTextBox.Text = currentPattern._prepend;
            prefixTextBox.Text = currentPattern._prefix;
            matchTextBox.Text = currentPattern._match;
            Update();
        }

        private void buttonUp_MouseEnter(object sender, EventArgs e)
        {
            buttonUp.BackgroundImage = Resources.up_on;
        }

        private void buttonUp_MouseLeave(object sender, EventArgs e)
        {
            buttonUp.BackgroundImage = Resources.up;
        }

        private void buttonDown_MouseEnter(object sender, EventArgs e)
        {
            buttonDown.BackgroundImage = Resources.down_on;
        }

        private void buttonDown_MouseLeave(object sender, EventArgs e)
        {
            buttonDown.BackgroundImage = Resources.down;
        }

        private void buttonUp_MouseClick(object sender, MouseEventArgs e)
        {
            if (buttonUpClick != null)
                buttonUpClick(this, null);
        }

        private void buttonDown_MouseClick(object sender, MouseEventArgs e)
        {
            if (buttonDownClick != null)
                buttonDownClick(this, null);
        }

        private void deleteButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (DeleteButtonClick != null)
                DeleteButtonClick(this, null);
        }

        private void prependTextBox_TextChanged(object sender, EventArgs e)
        {
            currentPattern._prepend = prependTextBox.Text;
        }

        private void prefixTextBox_TextChanged(object sender, EventArgs e)
        {
            currentPattern._prefix = prefixTextBox.Text;
        }

        private void matchTextBox_TextChanged(object sender, EventArgs e)
        {
            currentPattern._match = matchTextBox.Text;
        }

        private void deleteButton_MouseEnter(object sender, EventArgs e)
        {
            Label temp = sender as Label;
            temp.ForeColor = Color.White;
        }

        private void deleteButton_MouseLeave(object sender, EventArgs e)
        {
            Label temp = sender as Label;
            temp.ForeColor = SystemColors.ControlText;
        }
    }
}
