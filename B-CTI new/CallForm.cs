using System;
using System.Windows.Forms;
using AsteriskManager;

namespace B_CTI_new
{
    public partial class CallForm : Form
    {
        public string incomingNumber { get; set; }
        public AMIManager incomAMI { private get; set; }
        public CallForm(AMIManager _ami)
        {
            incomAMI = _ami;

            InitializeComponent();
            this.Text = "Вызов от " + incomingNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // incomAMI.HangupAiringCalls(incomAMI.UserData.Number);
        }
    }
}
