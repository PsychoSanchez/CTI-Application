using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AsteriskManager;
using System.Threading;
using BCTI.Settings;
using BCTI.Helpers;
using System.Runtime.InteropServices;

namespace BCTI
{
    public partial class History : Form
    {
        public string filter = string.Empty;
        public List<RingInfo> ringList = new List<RingInfo>();
        public List<ClientsData> BookOfContacts = new List<ClientsData>();
        List<Button> dayButtons = new List<Button>();
        Color offFocus = Colors.WhiteTheme.ButtonMainColor;
        Color onFocus = Color.FromArgb(255, 0, 173, 56);
        Color onFocusOutcom = Color.FromArgb(255, 0, 51, 153);
        Color onFocusUnUnsw = Color.FromArgb(255, 255, 126, 126);
        public DateTime beginDate = DateTime.Today;
        public DateTime endDate = DateTime.Now;
        bool singleContact = false;
        ClientsData singleClient = new ClientsData();
        public static event EventHandler<EventArgs> ununsweredChecked;
        BackgroundWorker LoadHistory = new BackgroundWorker();
        private ManualResetEvent wait = new ManualResetEvent(true);
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();

        /// <summary>
        /// Список истории загружен
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistoryLoaded(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (RingsTable.Controls.Count < 1)
                {
                    try
                    {
                        Loading.Text = Localization[Loading.Name][1];
                    }
                    catch (Exception)
                    {
                        Loading.Text = "Нет истории звонков за данный промежуток времени";
                    }
                }
                else
                {
                    Loading.Hide();
                }
            });
        }
        /// <summary>
        /// Перезагрузка истории звонков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reload(object sender, DoWorkEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    Loading.Text = Localization[Loading.Name][0];
                }
                catch (Exception)
                {
                    Loading.Text = "Загрузка истории звонков...";
                }
                Loading.Show();
            });
            Thread.Sleep(150);
            List<RingInfo> RingsTableonForm = new List<RingInfo>();
            for (int i = 0; i < ringList.Count; i++)
            {
                try
                {
                    if ((ringList[i].number.ToLower().Contains(filter.ToLower()) || filter == "") &&
                        (incomingButton.BackColor == onFocus && ringList[i].type == CallType.IncomingCall ||
                        outcomingButton.BackColor == onFocusOutcom && ringList[i].type == CallType.OutcomingCall ||
                        unUnsweredButton.BackColor == onFocusUnUnsw && ringList[i].type == CallType.Unanswered))
                        if (ringList[i].momentOfRing >= beginDate && ringList[i].momentOfRing <= endDate)
                            RingsTableonForm.Add(ringList[i]);
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                }
            }
            int displayRingsTable = RingsTableonForm.Count;
            int controlsCount = RingsTable.Controls.Count;

            if (controlsCount > displayRingsTable)
            {
                for (int i = controlsCount - 1; i >= displayRingsTable; i--)
                    this.Invoke((MethodInvoker)delegate
                    {
                        RingsTable.Controls[i].Dispose();
                        RingsTable.RowStyles.Clear();
                    });
            }
            else
                for (int i = controlsCount; i < displayRingsTable; i++)
                    this.Invoke((MethodInvoker)delegate
                   {
                       RingsTable.Controls.Add(new ringCard());
                       var RingCard = (ringCard)RingsTable.Controls[i];
                       RingCard.NumberClick += RingCard_NumberClick;
                   });
            ClientsData temp = new ClientsData();
            for (int i = 0; i < displayRingsTable; i++)
            {
                for (int j = 0; j < BookOfContacts.Count; j++)
                {
                    if (RingsTableonForm[i].number == BookOfContacts[j].Number ||
                        RingsTableonForm[i].number == BookOfContacts[j].SecondNumber)
                    {
                        temp = (ClientsData)BookOfContacts[j].Clone();
                        break;
                    }
                }
                this.Invoke((MethodInvoker)delegate
                {
                    ringCard curr = (ringCard)RingsTable.Controls[i];
                    curr.newContactAdded += Curr_newContactAdded;
                    curr.changeRing(RingsTableonForm[i], temp);
                    temp = new ClientsData();
                });
            }
        }

        /// <summary>
        /// Звонок на номер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RingCard_NumberClick(object sender, CustEventArgs e)
        {
            BLFPanel Own = (BLFPanel)this.Owner;
            if (!Owner.IsDisposed)
            {
                Own.RaiseCall(e.message);
            }
        }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="_ringList"></param>
        /// <param name="BookOfContacts"></param>
        public History(List<RingInfo> _ringList, List<ClientsData> BookOfContacts)
        {
            ringList = _ringList;
            this.BookOfContacts = BookOfContacts;
            InitializeComponent();
            MaximumSize = new Size(this.Width, Screen.PrimaryScreen.WorkingArea.Height);
            closeButton.BackgroundImage = closeButtonImage.Images[0];
            todayButton.BackColor = Color.FromArgb(255, 0, 173, 56);
            incomingButton.BackColor = onFocus;
            outcomingButton.BackColor = onFocusOutcom;
            unUnsweredButton.BackColor = onFocusUnUnsw;
            dayButtons.Add(todayButton);
            dayButtons.Add(day2Button);
            dayButtons.Add(day3Button);
            dayButtons.Add(day7Button);
            dayButtons.Add(arrowButton);
            LoadHistory = new BackgroundWorker();
            LoadHistory.DoWork += Reload;
            LoadHistory.RunWorkerCompleted += HistoryLoaded;

            ///Локализация
            Localization = Localizator.GetFormLocalization("History", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += GeneralSettings_Language_Changed;

            ///Шрифты
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(headLabel, FontStyle.Bold);
        }

        private void GeneralSettings_Language_Changed(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization("History", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
        }

        public void OnlyUnunswered()
        {
            unUnsweredButton.BackColor = onFocusUnUnsw;
            incomingButton.BackColor = offFocus;
            outcomingButton.BackColor = offFocus;
        }

        public void changeFilter(string a)
        {
            filter = a;
            SearchBox.Text = a;
            if (LoadHistory.IsBusy == false)
                LoadHistory.RunWorkerAsync();
        }

        /// <summary>
        /// Добавление нового контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Curr_newContactAdded(object sender, NewClientArgs e)
        {
            if (!BookOfContacts.Contains(e.client))
            {
                BookOfContacts.Add(e.client);
                XMLReadWriter.WriteContacts(BookOfContacts);

                if (LoadHistory.IsBusy == false)
                    LoadHistory.RunWorkerAsync();
            }
        }
        /// <summary>
        /// История контактов загружена, отметка пропущенных звонков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void History_Shown(object sender, EventArgs e)
        {
            RingsTable.Controls.Clear();
            RingsTable.RowStyles.Clear();

            Localization = Localizator.GetFormLocalization("History", BLFPanel.Staticsettings.Interface.Language);
            ununsweredChecked?.Invoke(this, null);
            if (LoadHistory.IsBusy == false)
            {
                LoadHistory.RunWorkerAsync();
            }
        }
        #region DefaultHandlers

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
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

        #endregion
        /// <summary>
        /// Фильтр по дням
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void arrowButton_Click(object sender, EventArgs e)
        {
            beginDate = DateTime.Now;
            endDate = DateTime.Now;
            Button curr = (Button)sender;
            string currtext = string.Empty;
            try
            {
                currtext = Localization[todayButton.Name][0];
            }
            catch (Exception)
            {
                currtext = "Сегодня";
            }
            if (curr.Text == currtext)
            {
                beginDate = DateTime.Today;
            }
            else
                switch (curr.Text)
                {
                    case "-2":
                        {
                            beginDate = beginDate.AddDays(-2);
                            break;
                        }
                    case "-3":
                        {
                            beginDate = beginDate.AddDays(-3);
                            break;
                        }
                    case "-7":
                        {
                            beginDate = beginDate.AddDays(-7);
                            break;
                        }
                    case "<->":
                        {
                            DatesForm dt = new DatesForm(beginDate, endDate);
                            dt.ShowDialog();
                            if (dt.Accept)
                            {
                                beginDate = dt.first;
                                endDate = dt.second;
                                for (int i = 0; i < dayButtons.Count; i++)
                                {
                                    if (dayButtons[i].Text != curr.Text)
                                        dayButtons[i].BackColor = offFocus;
                                    else
                                        dayButtons[i].BackColor = onFocus;
                                }
                                if (LoadHistory.IsBusy == false)
                                    LoadHistory.RunWorkerAsync();
                            }
                            break;
                        }
                }
            if (curr.Text != "<->")
            {
                for (int i = 0; i < dayButtons.Count; i++)
                {
                    if (dayButtons[i].Text != curr.Text)
                        dayButtons[i].BackColor = offFocus;
                    else
                        dayButtons[i].BackColor = onFocus;
                }
                if (LoadHistory.IsBusy == false)
                    LoadHistory.RunWorkerAsync();
            }
        }
        /// <summary>
        /// только входящие
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void incomingButton_Click(object sender, EventArgs e)
        {
            if (incomingButton.BackColor == offFocus)
                incomingButton.BackColor = onFocus;
            else
                incomingButton.BackColor = offFocus;
            if (LoadHistory.IsBusy == false)
                LoadHistory.RunWorkerAsync();
        }
        /// <summary>
        /// исходящие
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outcomingButton_Click(object sender, EventArgs e)
        {
            if (outcomingButton.BackColor == offFocus)
                outcomingButton.BackColor = onFocusOutcom;
            else
                outcomingButton.BackColor = offFocus;
            if (LoadHistory.IsBusy == false)
                LoadHistory.RunWorkerAsync();
        }
        /// <summary>
        /// пропущенные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unUnsweredButton_Click(object sender, EventArgs e)
        {
            if (unUnsweredButton.BackColor == offFocus)
                unUnsweredButton.BackColor = onFocusUnUnsw;
            else
                unUnsweredButton.BackColor = offFocus;
            if (LoadHistory.IsBusy == false)
                LoadHistory.RunWorkerAsync();
        }
        /// <summary>
        /// Обновление списка относительно фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            if (!FilterLocked)
            {
                try
                {
                    if (SearchBox.Text == Localization[SearchBox.Name][0])
                        filter = string.Empty;
                    else
                        filter = SearchBox.Text;
                    if (LoadHistory.IsBusy == false)
                        LoadHistory.RunWorkerAsync();
                }
                catch (Exception)
                {
                    if (SearchBox.Text == "Введите номер или имя")
                        filter = string.Empty;
                    else
                        filter = SearchBox.Text;
                    if (LoadHistory.IsBusy == false)
                        LoadHistory.RunWorkerAsync();
                }
            }
        }
        #region Resizer

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
        #endregion
        #region Search

        bool FilterLocked = false;
        private void SearchBox_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (SearchBox.Text == Localization[SearchBox.Name][0])
                {
                    FilterLocked = true;
                    SearchBox.Text = "";
                    SearchBox.ForeColor = SystemColors.WindowText;
                }
            }
            catch (Exception)
            {
                if (SearchBox.Text == "Введите номер или имя")
                {

                    FilterLocked = true;
                    SearchBox.Text = "";
                    SearchBox.ForeColor = SystemColors.WindowText;
                }
            }
        }



        private void SearchBox_MouseLeave(object sender, EventArgs e)
        {
            if (!SearchBox.Focused)
            {
                if (SearchBox.Text.Length == 0)
                {
                    FilterLocked = true;
                    try
                    {
                        SearchBox.Text = Localization[SearchBox.Name][0];
                    }
                    catch (Exception)
                    {
                        SearchBox.Text = "Введите номер или имя";
                    }
                    SearchBox.ForeColor = SystemColors.GrayText;
                }
                if (FilterLocked)
                    searchPictureBox.Focus();
            }
        }

        private void SearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            FilterLocked = false;
        }

        private void SearchBox_Leave(object sender, EventArgs e)
        {
            FilterLocked = false;
            if (SearchBox.Text.Length == 0)
            {
                FilterLocked = true;
                try
                {
                    SearchBox.Text = Localization[SearchBox.Name][0];
                }
                catch (Exception)
                {
                    SearchBox.Text = "Введите номер или имя";
                }
                SearchBox.ForeColor = SystemColors.GrayText;
            }
        }
        #endregion
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
        private enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }
        private void RingsTable_Resize(object sender, EventArgs e)
        {


            if (RingsTable.HorizontalScroll.Visible)
            {
                ShowScrollBar(RingsTable.Handle, (int)ScrollBarDirection.SB_HORZ, false);
            }
        }
    }
}
