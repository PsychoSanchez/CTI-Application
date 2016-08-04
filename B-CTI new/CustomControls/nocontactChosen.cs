using System;
using System.Windows.Forms;

namespace BCTI
{
    public partial class nocontactChosen : UserControl
    {
        public event EventHandler<CustEventArgs> buttonClicked;
        public nocontactChosen()
        {
            InitializeComponent();
            UserInterfaceAPI.InitFonts(this);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            buttonClicked(sender, new CustEventArgs(temp.Text));
        }
    }
}
