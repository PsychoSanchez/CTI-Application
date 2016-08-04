using BCTI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI
{
    public partial class UnunsweredForm : Form
    {
        public event EventHandler<EventArgs> openHistory;
        public int ununsweredCounter = 0;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        public UnunsweredForm()
        {
            InitializeComponent();

            infoLabel.Text = "У вас нет пропущенных";

            Localization = Localizator.GetFormLocalization("UnunsweredForm", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            TopMost = true;
            closeButton.BackgroundImage = closeButtonImage.Images[0];
            History.ununsweredChecked += History_ununsweredChecked;
            //Location = new Point(Screen.PrimaryScreen.WorkingArea.Size.Width - Width, Screen.PrimaryScreen.WorkingArea.Size.Height - Height);
            UserInterfaceAPI.InitFonts(this);
            headLabel.Font = new Font(headLabel.Font, FontStyle.Bold);
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization("UnunsweredForm", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);

            try
            {
                if (ununsweredCounter == 0)
                    infoLabel.Text = Localization[infoLabel.Name][0];
                else if (ununsweredCounter == 1)
                    infoLabel.Text = Localization[infoLabel.Name][1] + ununsweredCounter +
                                     Localization[infoLabel.Name][2];
                else
                    infoLabel.Text = Localization[infoLabel.Name][1] + ununsweredCounter +
                                     Localization[infoLabel.Name][3];
            }
            catch (Exception)
            {
                if (ununsweredCounter == 0)
                    infoLabel.Text = "У вас нет пропущенных";
                else if (ununsweredCounter == 1)
                    infoLabel.Text = "У вас " + ununsweredCounter +
                                     " пропущенный";
                else
                    infoLabel.Text = "У вас " + ununsweredCounter +
                                     " пропущенных";
            }
        }

        private void History_ununsweredChecked(object sender, EventArgs e)
        {
            ununsweredCounter = 0;
            Invoke((MethodInvoker)(() => Visible = false));
        }

        public void SetLocation(int x, int y)
        {
            Location = new Point(x, y);
        }

        public void IncreseUnunswered()
        {
            ununsweredCounter++;

            try
            {
                if (ununsweredCounter == 0)
                    infoLabel.Text = Localization[infoLabel.Name][0];
                else if (ununsweredCounter == 1)
                    infoLabel.Text = Localization[infoLabel.Name][1] + ununsweredCounter +
                                     Localization[infoLabel.Name][2];
                else
                    infoLabel.Text = Localization[infoLabel.Name][1] + ununsweredCounter +
                                     Localization[infoLabel.Name][3];
            }
            catch (Exception)
            {
                if (ununsweredCounter == 0)
                    infoLabel.Text = "У вас нет пропущенных";
                else if (ununsweredCounter == 1)
                    infoLabel.Text = "У вас " + ununsweredCounter +
                                     " пропущенный";
                else
                    infoLabel.Text = "У вас " + ununsweredCounter +
                                     " пропущенных";
            }
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void UnunsweredForm_Click(object sender, EventArgs e)
        {
            openHistory(this, null);
            ununsweredCounter = 0;
            Visible = false;
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackgroundImage = closeButtonImage.Images[1];
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Disposing && !IsDisposed)
                closeButton.BackgroundImage = closeButtonImage.Images[0];
        }
    }
}
