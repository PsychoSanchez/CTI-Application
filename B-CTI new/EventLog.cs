#define LOG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace BCTI
{
    /// <summary>
    /// Форма журнала событий
    /// </summary>
    public partial class EventLogsForm : Form
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public EventLogsForm()
        {
            InitializeComponent();
            EventLogs.StreamWriteEvent += EventLog_StreamWriteEvent;
            LogTextBox.Text += DateTime.Now + "\r\nWelcome to Event Log!\r\nI hope it won't throw Exceptions :D";
        }
        /// <summary>
        /// Событие записи в лог
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventLog_StreamWriteEvent(object sender, EventLogs.EventLogArgs e)
        {
            try
            {
                if (!this.IsDisposed && !this.Disposing)
                    this.Invoke((MethodInvoker)delegate
                    {
                        LogTextBox.Text += "\r\n" + DateTime.Now.ToShortTimeString() + "\r\n" + e.EventName + "\r\n" + e.AdditionalInfo;
                    });
            }
            catch (InvalidOperationException)
            {

            }
        }
        #region DefaultHandlers
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
        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackgroundImage = closeButtonImage.Images[1];
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            if (!this.IsDisposed && !this.Disposing)
                closeButton.BackgroundImage = closeButtonImage.Images[0];
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            EventLogs.StreamWriteEvent -= EventLog_StreamWriteEvent;
            this.Close();
        }
        private void SaveButton_MouseEnter(object sender, EventArgs e)
        {
            SaveButton.BackColor = Colors.WhiteTheme.ButtonHover;
        }

        private void SaveButton_MouseLeave(object sender, EventArgs e)
        {
            SaveButton.BackColor = Colors.WhiteTheme.ButtonMainColor;
        }
        #endregion

        /// <summary>
        /// открытие файла с логами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenLogFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                UserSettings set = new UserSettings();
                Process.Start(@set.Logs.EventLogFolder + "\\" + DateTime.Today.ToShortDateString() + "\\EventLog.log");
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog("Exception", ex.Message + "\r\n" + ex.StackTrace);
            }
        }
    }
}
