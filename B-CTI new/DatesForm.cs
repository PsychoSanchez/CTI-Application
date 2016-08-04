using BCTI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace BCTI
{
    /// <summary>
    /// Форма выбора даты
    /// </summary>
    public partial class DatesForm : Form
    {
        public DateTime first;
        public DateTime second;
        public bool Accept = false;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();

        public DatesForm(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();

            Localization = Localizator.GetFormLocalization("DatesForm", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            fromDateBox.Value = fromDate;
            toDateBox.Value = toDate;
            first = fromDate;
            second = toDate;
            closeButton.BackgroundImage = closeButtonImage.Images[0];
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization("DatesForm", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
        }
        private void acceptDate_Click(object sender, EventArgs e)
        {
            first = fromDateBox.Value.Date;
            second = toDateBox.Value.Date;
            if (first > second)
            {
                DateTime temp;
                temp = first;
                first = second;
                second = temp;
            }
            if (first == second)
                first = first.AddDays(-1);
            Accept = true;
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private bool isDragging = false;

        private Point lastCursor;
        private Point lastForm;

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
