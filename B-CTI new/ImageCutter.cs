using BCTI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI
{
    public partial class ImageCutter : Form
    {
        double heightCoef;
        double widthCoef;
        public bool added = false;
        List<double[]> scales = new List<double[]>();
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        public ImageCutter(Image avatar)
        {
            this.avatar = avatar;

            InitializeComponent();

            closeButton.BackgroundImage = closeButtonImage.Images[0];

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            //double min = 1, max = 1;
            //if (avatar.Height > avatar.Width)
            //{
            //    min = avatar.Width;
            //    max = avatar.Height;
            //}
            //else if (avatar.Height < avatar.Width)
            //{
            //    min = avatar.Height;
            //    max = avatar.Width;
            //}
            //double scale = max / min;
            //double size = avatar.Height / avatar.Width;
            //if (scale >= 1 - 0.3 && scale <= 1 + 0.3)
            //{

            //Height = 325 + 28 + 30;
            //Width = 325;
            //avatarBox.Height = 325;
            //avatarBox.Width = 325;
            //cutButton.Width = 162;
            //cancelButton.Width = 162;
            //    //cancelButton.Location = new Point(162, cancelButton.Location.Y);
            //}
            //else if (avatar.Height > avatar.Width)
            //{
            //    //int height = Height;
            //    //Height = Width + 28 + 30;
            //    //Width = avatarBox.Height;
            //    //height = avatarBox.Height;
            //    //avatarBox.Height = avatarBox.Width;
            //    //avatarBox.Width = height;
            //    //cutButton.Width = 162;
            //    //cancelButton.Width = 162;
            //    //cancelButton.Location = new Point(162, cancelButton.Location.Y);
            //}

            TopMost = true;

        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
        }

        bool selecting;
        bool rd = false;
        Image avatar;
        public Image result = null; Rectangle selector;
        Point oldPosition = new Point();

        private void avatarBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Starting point of the selection:
            if (e.Button == MouseButtons.Left)
            {
                if (((e.X <= selector.X + selector.Width + 2) && (e.X >= selector.X + selector.Width - 2)) && ((e.Y <= selector.Y + selector.Height + 2) && (e.Y >= selector.Y + selector.Height - 2)))
                {
                    rd = true;
                    Cursor = Cursors.SizeNWSE;
                }
                if (e.X > selector.X && e.X < selector.X + selector.Width && e.Y > selector.Y && e.Y < selector.Y + selector.Height)
                {
                    selecting = true;
                    Cursor = Cursors.SizeAll;
                    //selector = new Rectangle(new Point(e.X, e.Y), new Size(selector.Width, selector.Height));
                    oldPosition = PointToClient(new Point(e.X, e.Y));
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                int newX = selector.X;
                int newWidth = selector.Width;
                if (selector.Width < 0)
                {
                    newX = selector.X + selector.Width;
                    newWidth = -newWidth;
                }
                int newY = selector.Y;
                int newHeight = selector.Height;
                if (selector.Height < 0)
                {
                    newY = selector.Y + selector.Height;
                    newHeight = -newHeight;
                }
                newX = (int)(newX * widthCoef);
                newY = (int)(newY * heightCoef);
                newHeight = (int)(newHeight * heightCoef);
                newWidth = (int)(newWidth * widthCoef);
                Bitmap bmp = (Bitmap)avatar.Clone();
                if (selector.Location.X < 0) newX = 0;
                if (selector.Location.Y < 0) newY = 0;
                if (selector.Width != 0 && selector.Height != 0)
                {
                    if (newWidth == 0 || newHeight == 0) return;
                    result = bmp.Clone(new Rectangle(newX, newY, newWidth, newHeight), bmp.PixelFormat);
                    avatar = (Image)result.Clone();
                    avatarBox.BackgroundImage = (Image)result.Clone();
                    //result.Dispose();
                    avatarBox.BackgroundImageLayout = ImageLayout.Stretch;
                    avatarBox.Update();
                    double height1 = avatar.Height;
                    double height2 = avatarBox.Height;
                    double width1 = avatar.Width;
                    double width2 = avatarBox.Width;
                    heightCoef = height1 / height2;
                    widthCoef = width1 / width2;
                }
            }
        }

        private void avatarBox_MouseMove(object sender, MouseEventArgs e)
        {

            if (rd)
            {
                int incrementWidth = selector.Width + (e.X - (selector.X + selector.Width));
                int incrementHeight = incrementWidth; // selector.Height + (e.Y - (selector.Y + selector.Height));
                if (incrementHeight < 25) return;
                if (selector.X + incrementWidth > avatarBox.Width || selector.Y + incrementHeight > avatarBox.Height)
                    return;
                selector = new Rectangle(selector.X, selector.Y, incrementWidth, incrementHeight);
                avatarBox.Refresh();
            }
            else if (selecting)
            {
                Point curr = PointToClient(new Point(e.X, e.Y));
                int newX = selector.X + (curr.X - oldPosition.X);
                int newY = selector.Y + (curr.Y - oldPosition.Y);
                Point location = new Point(avatarBox.Location.X, avatarBox.Location.Y);
                if (newX < location.X || newY < location.Y - 28 || newX > avatarBox.Width - selector.Width || newY > avatarBox.Height - selector.Height)
                    return;
                selector = new Rectangle(newX, newY, selector.Width, selector.Height);
                oldPosition = curr;
                avatarBox.Refresh();
            }
            else if (((e.X <= selector.X + selector.Width + 2) && (e.X >= selector.X + selector.Width - 2)) && ((e.Y <= selector.Y + selector.Height + 2) && (e.Y >= selector.Y + selector.Height - 2)))
            {
                Cursor = Cursors.SizeNWSE;
            }
            else Cursor = Cursors.Default;
        }

        private void avatarBox_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            avatarBox.Refresh();
            selecting = false;
            rd = false;
        }

        private void avatarBox_Paint(object sender, PaintEventArgs e)
        {
            //Pen pen = Pens.GreenYellow;
            //pen.Width = 3;
            Pen pen = new Pen(Color.LightGray, 3);
            e.Graphics.DrawRectangle(pen, selector.X, selector.Y, selector.Width, selector.Height);
            pen.Color = Color.DarkGray;
            e.Graphics.DrawRectangle(pen, selector.X + selector.Width - 1, selector.Y + selector.Height - 1, 2, 2);
        }

        private void ImageCutter_Load(object sender, EventArgs e)
        {
            //Console.WriteLine(Height + " " + Width);
            //Console.WriteLine(avatar.Height + " " + avatar.Width);
            //Console.WriteLine(avatar.Height / 440 + " " + avatar.Width / 440);
            int wid = (int)(this.Width * (avatar.Width / (double)avatarBox.Width));
            int hei = (int)(this.Height * (avatar.Height / (double)avatarBox.Height));
            if (hei > avatarBox.MaximumSize.Height)
            {
                wid = (int)(avatar.Width * (768 / (double)avatar.Height));
                hei = (int)(avatar.Height * (768 / (double)avatar.Height));
            }
            if (wid > avatarBox.MaximumSize.Width)
            {
                wid = (int)(avatar.Width * (1024 / (double)avatar.Width));
                hei = (int)(avatar.Height * (1024 / (double)avatar.Width));
            }
            Height = hei;
            Width = wid;
            //Console.WriteLine(Height + " " + Width);
            //double height1 = avatar.Height;
            //double height2 = avatarBox.Height;
            //double width1 = avatar.Width;
            //double width2 = avatarBox.Width;
            //heightCoef = height1 / height2;
            //widthCoef = width1 / width2;
            //double[] curr = new double[2];
            //curr[0] = heightCoef;
            //curr[1] = widthCoef;
            //scales.Add(curr);

            avatarBox.BackgroundImage = avatar;
            selector = new Rectangle(new Point(avatarBox.Location.X + avatarBox.Width / 2 - 100, avatarBox.Location.Y + avatarBox.Height / 2 - 100), new Size(150, 150));
            avatarBox.Refresh();
            //Location = new Poiun(MousePosition.X - 100, MousePosition.Y - 100);
        }

        private void cutButton_Click(object sender, EventArgs e)
        {
            if (result == null)
            {
                int newX = selector.X;
                int newWidth = selector.Width;
                if (selector.Width < 0)
                {
                    newX = selector.X + selector.Width;
                    newWidth = -newWidth;
                }
                int newY = selector.Y;
                int newHeight = selector.Height;
                if (selector.Height < 0)
                {
                    newY = selector.Y + selector.Height;
                    newHeight = -newHeight;
                }
                //newX = (int)(newX * widthCoef);
                //newY = (int)(newY * heightCoef);
                //newHeight = (int)(newHeight * heightCoef);
                //newWidth = (int)(newWidth * widthCoef);
                //Bitmap bmp = (Bitmap)avatar.Clone();
                Bitmap bmp = new Bitmap(avatarBox.ClientSize.Width, avatarBox.ClientSize.Height);
                avatarBox.DrawToBitmap(bmp, avatarBox.ClientRectangle);
                if (selector.Location.X < 0) newX = 0;
                if (selector.Location.Y < 0) newY = 0;
                if (selector.Width != 0 && selector.Height != 0)
                {
                    //if (newWidth == 0 || newHeight == 0) return;
                    result = bmp.Clone(new Rectangle(newX + 3, newY + 3, newWidth - 2, newHeight - 2), bmp.PixelFormat);
                    //avatar = (Image)result.Clone();
                    //avatarBox.BackgroundImage = (Image)result.Clone();
                    ////result.Dispose();
                    //avatarBox.BackgroundImageLayout = ImageLayout.Stretch;
                    //avatarBox.Update();
                    //double height1 = avatar.Height;
                    //double height2 = avatarBox.Height;
                    //double width1 = avatar.Width;
                    //double width2 = avatarBox.Width;
                    //heightCoef = height1 / height2;
                    //widthCoef = width1 / width2;
                }
            }
            added = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void headPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackgroundImage = closeButtonImage.Images[1];
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Disposing && !IsDisposed)
                closeButton.BackgroundImage = closeButtonImage.Images[0];
        }
    }
}
