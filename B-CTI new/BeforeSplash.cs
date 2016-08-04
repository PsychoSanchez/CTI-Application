using System;
using System.Drawing;
using System.Windows.Forms;
using AsteriskManager;

namespace BCTI
{
    /// <summary>
    /// !!!! УДАЛЕН ИЗ ПРОЕКТА !!!!
    /// </summary>
    public partial class BeforeSplash : Form
    {
        AMIManager ami;
        public string callingNumber = string.Empty;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        Point formLocation = new Point();
        public BeforeSplash(AMIManager _ami, ClientsData client, string ringType, int x, int y)
        {
            InitializeComponent();
            ami = _ami;
            formLocation.X = x;
            formLocation.Y = y;
            closeButton.BackgroundImage = closeButtonImage.Images[0];
            if (ringType == "  ->")
                headLabel.Text = "Исходящий звонок";//client.number;
            else headLabel.Text = "Входящий звонок";
            statusLabel.Text = client.Number + (!string.IsNullOrEmpty(client.Name) ? " (" + client.Name + ")" : "");
            callingNumber = client.Number;
            EventManager.ConversationBegin += EventManager_ConversationBegin;
            EventManager.ConversationEnd += EventManager_ConversationEnd;
        }

        private void EventManager_ConversationBegin(object sender, DialEventArgs e)
        {
        }

        private void EventManager_ConversationEnd(object sender, DialEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackgroundImage = closeButtonImage.Images[1];
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            if (!IsDisposed && !Disposing)
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ami.Hangup(callingNumber);
        }

        private void BeforeSplash_MouseDown(object sender, MouseEventArgs e)
        {
            //if ()
        }

        private void BeforeSplash_MouseMove(object sender, MouseEventArgs e)
        {
            //Point form = PointToScreen(this.Location);
            ////if ((Cursor.Position.X >= form.X + this.Height - 10 && Cursor.Position.X <= form.X + this.Height) ||
            ////    (Cursor.Position.X >= form.X && Cursor.Position.X <= form.X + 10) ||
            ////    (Cursor.Position.Y >= form.Y + this.Width - 10 && Cursor.Position.Y <= form.Y + this.Width) ||
            ////    (Cursor.Position.Y >= form.Y && Cursor.Position.Y <= form.Y + 10))
            //if ((Cursor.Position.Y >= form.Y + this.Height - 10 && Cursor.Position.Y <= form.Y + this.Height) ||
            //        (Cursor.Position.Y >= form.Y && Cursor.Position.Y <= form.Y + 10))
            //    Cursor = Cursors.SizeNS;
            //else Cursor = Cursors.Default;
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

        bool resizing = false;
        Point oldPosition = new Point();

        private void rightSizer_MouseUp(object sender, MouseEventArgs e)
        {
            resizing = false;
        }

        private void rightSizer_MouseDown(object sender, MouseEventArgs e)
        {
            resizing = true;
            oldPosition = PointToScreen(Cursor.Position);
        }

        private void rightSizer_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = PointToScreen(Cursor.Position);
            if (resizing)
                this.Width += (newPosition.X - oldPosition.X);
            oldPosition = newPosition;
        }

        private void leftSizer_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = Cursor.Position;
            if (resizing)
            {
                this.Width += -(newPosition.X - this.Location.X);
                this.Location = new Point(newPosition.X, this.Location.Y);
            }
            oldPosition = newPosition;
        }

        private void topSizer_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = Cursor.Position;
            if (resizing)
            {
                this.Height += -(newPosition.Y - this.Location.Y);
                this.Location = new Point(this.Location.X, newPosition.Y);
            }
            oldPosition = newPosition;
        }

        private void downResizer_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = PointToScreen(Cursor.Position);
            if (resizing)
                this.Height += (newPosition.Y - oldPosition.Y);
            oldPosition = newPosition;
        }

        private void BeforeSplash_Shown(object sender, EventArgs e)
        {
            this.Location = formLocation;// new Point(Screen.PrimaryScreen.WorkingArea.Size.Width - 212, Screen.PrimaryScreen.WorkingArea.Size.Height - 95);
        }
    }
}
