using BCTI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI
{
    public partial class About : Form
    {
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        public About()
        {
            InitializeComponent();

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);

            try
            {
                AppInfo.Text = Localization[AppInfo.Name][0] +
                               System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                AppInfo.Text += "\r\n" + Localization[AppInfo.Name][1] + "0.3.0.0";
            }
            catch
            {
                AppInfo.Text = "Версия приложения " +
                               System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                AppInfo.Text += "\r\n" + "Версия библиотеки " + "0.3.0.0";
            }

            UserInterfaceAPI.InitFonts(this);
        }
        #region DefaultHandlers

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            exitButton.BackgroundImage = closeButtonImage.Images[1];
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Disposing && !IsDisposed)
                exitButton.BackgroundImage = closeButtonImage.Images[0];
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
    } 
    #endregion
}
