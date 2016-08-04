using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BCTI.CustomControls
{
    public partial class PopupSearchPanel : UserControl
    {
        public event EventHandler<CustEventArgs> OnClicked;
        public void RaiseOnClickedEvent(string _message)
        {
            OnClicked?.Invoke(null, new CustEventArgs(_message));
        }
        public PopupSearchPanel()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод добавления клиента
        /// </summary>
        /// <param name="ClientName"></param>
        /// <param name="ClientNumber"></param>
        public void Add(string ClientName, string ClientNumber)
        {
            QuickSearchPanel.Controls.Add(new QuickSearchCard(ClientName , ClientNumber, this));
            ShowScrollBar(QuickSearchPanel.Handle, (int)ScrollBarDirection.SB_VERT, false);
            ShowScrollBar(QuickSearchPanel.Handle, (int)ScrollBarDirection.SB_HORZ, false);
        }
        /// <summary>
        /// Метод добавления организации
        /// </summary>
        /// <param name="Organisation"></param>
        public void Add(string Organisation)
        {
            for (int i = 0; i < QuickSearchPanel.Controls.Count; i++)
            {
                QuickSearchCard card = (QuickSearchCard)QuickSearchPanel.Controls[i];
                if (card.SearchText == Organisation)
                {
                    return;
                }
            }
            QuickSearchPanel.Controls.Add(new QuickSearchCard(Organisation, this));
            ShowScrollBar(QuickSearchPanel.Handle, (int)ScrollBarDirection.SB_VERT, false);
            ShowScrollBar(QuickSearchPanel.Handle, (int)ScrollBarDirection.SB_HORZ, false);
        }
        public void Clear()
        {
            QuickSearchPanel.Controls.Clear();
            QuickSearchPanel.RowStyles.Clear();
            ShowScrollBar(QuickSearchPanel.Handle, (int)ScrollBarDirection.SB_VERT, false);
        }
        public int Count
        {
            get
            {
                return QuickSearchPanel.Controls.Count;
            }
        }
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
        private void QuickSearchPanel_Resize(object sender, EventArgs e)
        {
            if (QuickSearchPanel.HorizontalScroll.Visible)
            {
                ShowScrollBar(QuickSearchPanel.Handle, (int)ScrollBarDirection.SB_HORZ, false);
            }
        }
    }
}
