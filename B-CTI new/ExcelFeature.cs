using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using AsteriskManager;
using OfficeOpenXml;
using BCTI.DialogBoxes;

namespace BCTI
{
    public partial class ExcelFeature : Form
    {
        //Ссылка на главную форму, для использования её методов
        BLFPanel BLF;
        ClientsData temp;
        string FilePath = string.Empty;
        //Начало считывания данных из экселя со второй строки (!)
        int i = 2;
        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="blf">Ссылка на главную форму</param>
        public ExcelFeature(BLFPanel blf)
        {
            InitializeComponent();
            this.BLF = blf;
            InfoLabel.Hide();
            closeButton.BackgroundImage = closeButtonImage.Images[0];
            FileDialog.Filter = "*.xls|*.xlsx";
            AutoCall.Text = "Включить автодозвон";
            AutoCall.Checked = false;
            AutoCall.Hide();
            NextButton.Hide();
            UserInterfaceAPI.InitFonts(this);
        }
        /// <summary>
        /// Начало обзвона списка контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoButton_Click(object sender, EventArgs e)
        {
            if (BLF.AMI == null || BLF.AMI.UserData == null)
            {
                if (BMessageBox.Show(this, "Отсутствует подключение к серверу", BMessageBoxButtons.RetryCancel, BMessageBoxIcon.Error) == DialogResult.Retry)
                {
                    GoButton_Click(this, null);
                }
                return;
            }
            if (!string.IsNullOrEmpty(FilePath))
            {
                this.Size = new Size(284, 197);
                using (ExcelPackage xlPackage = new ExcelPackage(new System.IO.FileInfo(FilePath)))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
                    if (worksheet.Cells["A1"].Value != null)
                    {
                        temp = new ClientsData();
                        temp.Name = worksheet.Cells["A1"].Value.ToString();
                        temp.Number = worksheet.Cells["B1"].Value.ToString();
                        temp.organisation = worksheet.Cells["C1"].Value.ToString();
                        if (BLF.AMI == null) return;
                        InfoLabel.Show();
                        AutoCall.Show();
                        NextButton.Show();
                        BLF.RaiseCall(temp, true);
                        i = 2;
                        if (worksheet.Cells["A2"].Value != null)
                        {
                            this.BeginInvoke((MethodInvoker)(() => InfoLabel.Text = "Следующий контакт\r\nИмя: " + worksheet.Cells["A2"].Value.ToString() + "\r\n" + "Номер: " + worksheet.Cells["B2"].Value.ToString() + "\r\n" +
                               "Организация: " + worksheet.Cells["C2"].Value.ToString()));
                        }
                        else InfoLabel.Hide();
                        EventManager.ConversationEnd += EventManager_ConversationEnd;
                    }
                }
            }
        }
        /// <summary>
        /// Окончание разговора и начало нового при выбранном автодозвоне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventManager_ConversationEnd(object sender, DialEventArgs e)
        {
            if ((e.dialinfo.CallerIDNum == BLF.AMI.UserData.Number && e.dialinfo.ConnectedLineNum == temp.Number) ||
                    (e.dialinfo.ConnectedLineNum == BLF.AMI.UserData.Number && e.dialinfo.CallerIDNum == temp.Number))
            {
                if (AutoCall.Checked)
                {
                    Thread.Sleep(3000);
                    using (ExcelPackage xlPackage = new ExcelPackage(new System.IO.FileInfo(FilePath)))
                    {
                        // get the first worksheet in the workbook
                        ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
                        if (worksheet.Cells["A" + i].Value != null)
                        {
                            temp = new ClientsData();
                            temp.Name = worksheet.Cells["A" + i].Value.ToString();
                            temp.Number = worksheet.Cells["B" + i].Value.ToString();
                            temp.organisation = worksheet.Cells["C" + i].Value.ToString();
                            if (BLF.AMI == null) return;
                            BLF.RaiseCall(temp, true);
                            if (worksheet.Cells["A" + (i + 1)].Value != null)
                            {
                                try
                                {

                                    InfoLabel.BeginInvoke((MethodInvoker)(() => InfoLabel.Text = "Следующий контакт\r\nИмя: " + worksheet.Cells["A" + (i + 1)].Value.ToString() + "\r\n" + "Номер: " + worksheet.Cells["B" + (i + 1)].Value.ToString() + "\r\n" +
                                        "Организация: " + worksheet.Cells["C" + (i + 1)].Value.ToString()));
                                }
                                catch (Exception ex)
                                {
                                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                                }
                            }
                            else
                            {
                                try
                                {
                                    InfoLabel.BeginInvoke((MethodInvoker)(() => InfoLabel.Hide()));
                                    AutoCall.BeginInvoke((MethodInvoker)(() => AutoCall.Hide()));
                                    NextButton.BeginInvoke((MethodInvoker)(() => NextButton.Hide()));
                                }
                                catch (Exception ex)
                                {
                                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                                }
                            }
                            i++;
                        }
                    }
                }
            }
        }
        #region Win handlers
        private void button1_Click(object sender, EventArgs e)
        {
            if (FileDialog.ShowDialog(this) == DialogResult.OK)
            {
                GoButton.Enabled = true;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            FilePath = FileDialog.FileName;
        }

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

        private void ChooseFileButton_MouseEnter(object sender, EventArgs e)
        {
            Label temp = (Label)sender;
            temp.BackColor = Colors.WhiteTheme.ButtonHover;
            Cursor = Cursors.Hand;
        }

        private void ChooseFileButton_MouseLeave(object sender, EventArgs e)
        {
            Label temp = (Label)sender;
            temp.BackColor = Colors.WhiteTheme.ButtonMainColor;
            Cursor = Cursors.Default;
        }
        #endregion
        /// <summary>
        /// Автодозвон следующему абоненту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoCall_Checked_Changed(object sender, EventArgs e)
        {
            NextButton.Visible = AutoCall.Checked;
        }
        /// <summary>
        /// Звонок следующему абоненту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (!AutoCall.Checked)
                using (ExcelPackage xlPackage = new ExcelPackage(new System.IO.FileInfo(FilePath)))
                {
                    // get the first worksheet in the workbook
                    ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
                    if (worksheet.Cells["A" + i].Value != null)
                    {
                        temp = new ClientsData();
                        temp.Name = worksheet.Cells["A" + i].Value.ToString();
                        temp.Number = worksheet.Cells["B" + i].Value.ToString();
                        temp.organisation = worksheet.Cells["C" + i].Value.ToString();
                        if (BLF.AMI == null) return;
                        BLF.RaiseCall(temp, true);
                        try
                        {

                            if (worksheet.Cells["A" + (i + 1)].Value != null)
                            {
                                InfoLabel.Invoke((MethodInvoker)(() => InfoLabel.Text = "Следующий контакт\r\nИмя: " + worksheet.Cells["A" + (i + 1)].Value.ToString() + "\r\n" + "Номер: " + worksheet.Cells["B" + (i + 1)].Value.ToString() + "\r\n" +
                                    "Организация: " + worksheet.Cells["C" + (i + 1)].Value.ToString()));
                            }
                            else InfoLabel.Invoke((MethodInvoker)(() => InfoLabel.Hide()));
                        }
                        catch (Exception ex)
                        {
                            EventLogs.WriteLog(ex.Message, ex.StackTrace);
                        }
                        i++;
                    }
                }
        }


    }
}
