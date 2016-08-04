using System;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI
{
    public partial class contactChosen : UserControl
    {
        public event EventHandler<CustEventArgs> buttonClicked;
        public contactChosen()
        {
            InitializeComponent();
            UserInterfaceAPI.InitFonts(this);
        }

        public void changeColor(bool contactChosen)
        {
            if (contactChosen)
            {
                button1.BackColor = Color.FromArgb(67,154,255);
                button2.BackColor = Color.FromArgb(67, 154, 255);
                button3.BackColor = Color.FromArgb(67, 154, 255);
                button4.BackColor = Color.FromArgb(67, 154, 255);
            }
            else
            {
                button1.BackColor = Colors.WhiteTheme.ButtonMainColor;
                button2.BackColor = Colors.WhiteTheme.ButtonMainColor;
                button3.BackColor = Colors.WhiteTheme.ButtonMainColor;
                button4.BackColor = Colors.WhiteTheme.ButtonMainColor;
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            buttonClicked(sender, new CustEventArgs(temp.Text));
        }
    }
}
