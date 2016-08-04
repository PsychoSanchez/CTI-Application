using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using AsteriskManager;

namespace BCTI
{
    public partial class HistoryCard : UserControl
    {
        RingInfo ring = new RingInfo();
        ClientsData client = new ClientsData();
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/avatar/";
        public event EventHandler<NewClientArgs> newContactAdded;
        public HistoryCard()
        {
            InitializeComponent();
        }
        public HistoryCard(RingInfo newRing)
        {
            InitializeComponent();
            ring = newRing;
            switch (ring.type)
            {
                case CallType.IncomingCall:
                    {
                        typePicture.BackgroundImage = typeImages.Images[0];
                        break;
                    }
                case CallType.OutcomingCall:
                    {
                        typePicture.BackgroundImage = typeImages.Images[1];
                        break;
                    }
                case CallType.Unanswered:
                    {
                        typePicture.BackgroundImage = typeImages.Images[2];
                        break;
                    }
            }
            if (!string.IsNullOrEmpty(ring.momentOfRing.ToString()))
                label2.Text = ring.momentOfRing.ToString();
        }
        public void changeRing(RingInfo newRing, ClientsData currClient)
        {
            panel1.BackColor = SystemColors.Control;
            ring = newRing;
            typePicture.BackColor = Color.FromArgb(240, 240, 240);
            label1.BackColor = Color.FromArgb(240, 240, 240);
            label2.BackColor = Color.FromArgb(240, 240, 240);
            client = currClient;
            if (!string.IsNullOrEmpty(client.Name))
                addButton.Hide();
            client.Number = ring.number;
            if (string.IsNullOrEmpty(client.Name))
                label1.Text = ring.number + " (Неизвестно)";
            else label1.Text = ring.number + " (" + client.Name + ")";
            switch (ring.type)
            {
                case CallType.IncomingCall:
                    {
                        typePicture.BackgroundImage = typeImages.Images[0];
                        break;
                    }
                case CallType.OutcomingCall:
                    {
                        typePicture.BackgroundImage = typeImages.Images[1];
                        break;
                    }
                case CallType.Unanswered:
                    {
                        typePicture.BackgroundImage = typeImages.Images[2];
                        break;
                    }
            }
            if (File.Exists(path + client.ID.ToString()))
                avatar.Image = Image.FromFile(path + client.ID.ToString());
            if (!string.IsNullOrEmpty(ring.momentOfRing.ToString()))
                label2.Text = ring.momentOfRing.ToString();
        }
        public HistoryCard(RingInfo newRing, ClientsData currClient)
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(240, 240, 240);
            ring = newRing;
            typePicture.BackColor = Color.FromArgb(240, 240, 240);
            label1.BackColor = Color.FromArgb(240, 240, 240);
            label2.BackColor = Color.FromArgb(240, 240, 240);
            client = currClient;
            if (string.IsNullOrEmpty(client.Name))
                label1.Text = ring.number + " (Неизвестно)";
            else label1.Text = ring.number + " (" + client.Name + ")";
            switch (ring.type)
            {
                case CallType.IncomingCall:
                    {
                        typePicture.BackgroundImage = typeImages.Images[0];
                        break;
                    }
                case CallType.OutcomingCall:
                    {
                        typePicture.BackgroundImage = typeImages.Images[1];
                        break;
                    }
                case CallType.Unanswered:
                    {
                        typePicture.BackgroundImage = typeImages.Images[2];
                        break;
                    }
            }
            if (File.Exists(path + client.ID.ToString() + ".jpeg"))
                avatar.Image = Image.FromFile(path + client.ID.ToString() + ".jpeg");
            if (!string.IsNullOrEmpty(ring.momentOfRing.ToString()))
                label2.Text = ring.momentOfRing.ToString();
        }

        private void playButton_MouseEnter(object sender, EventArgs e)
        {
            playButton.BackColor = SystemColors.ActiveCaption;
        }

        private void playButton_MouseLeave(object sender, EventArgs e)
        {
            playButton.BackColor = Colors.WhiteTheme.ButtonMainColor;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(client.Name))
            {
                AddToBook atb = new AddToBook(client);
                atb.ShowDialog(this);
                if (atb.added)
                {
                    client = atb.newClient;
                    newContactAdded(this, new NewClientArgs(client));
                }
            }
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            Details details = new Details(ring, client);
            details.Show(this);
        }

        private void detailsButton_MouseEnter(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            temp.BackColor = SystemColors.ActiveCaption;
        }

        private void detailsButton_MouseLeave(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            temp.BackColor = Colors.WhiteTheme.ButtonMainColor;
        }
    }
}
