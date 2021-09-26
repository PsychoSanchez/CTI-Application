using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using AsteriskManager;
using System.Threading;
using BCTI.DialogBoxes;
using BCTI.Settings;
using BCTI.Helpers;
using OfficeOpenXml.Core.ExcelPackage;

namespace BCTI
{
    public partial class Contacts : Form
    {
        public List<ContactRow> BookOfContacts = new List<ContactRow>();
        public event EventHandler<EventArgs> conBookEdited;
        public event EventHandler<EventArgs> contactsEdited;
        string filter = string.Empty;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        BackgroundWorker ReloadContacts = new BackgroundWorker();
        bool SlowSorting = true;
        bool Initialize = true;
        /// <summary>
        /// Конструктор от списка контактов
        /// </summary>
        /// <param name="CurrOfContacts"></param>
        public Contacts(List<ClientsData> CurrOfContacts)
        {
            ///Создаем строчки для каждого контакта и подписываемся на события
            for (int i = 0; i < CurrOfContacts.Count; i++)
            {
                BookOfContacts.Add(new ContactRow(CurrOfContacts[i], i + 1));
                BookOfContacts[i].RowSelected += Contacts_RowSelected;
                BookOfContacts[i].DeleteContact += Contacts_DeleteContact;
                BookOfContacts[i].NumberClicked += Contacts_NumberClicked;
            }
            InitializeComponent();

            BLFPanel.ApplyLanguage += GeneralSettings_Language_Changed;

            ReloadContacts.DoWork += ReloadContactPanel;
            ReloadContacts.RunWorkerCompleted += ReloadComplete;
            ///Если у нас нет контактов, то показываем лейбл с информацией об их отсутствии
            if (BookOfContacts.Count == 0)
            {
                NoContactsLabel.Show();
            }
            else
            {
                NoContactsLabel.Hide();
            }
            ClearFilter.Hide();
            ///Панель быстрого поиска
            QuickSearchPanel.Hide();
            QuickSearchPanel.OnClicked += QuickSearchPanel_OnClicked;
            closeButton.BackgroundImage = closeButtonImage.Images[0];
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(HeadLabel, FontStyle.Bold);
            UserInterfaceAPI.SetFontStyle(autoCallButton, FontStyle.Bold);
            UserInterfaceAPI.SetFontStyle(addButton, FontStyle.Bold);
            UserInterfaceAPI.SetFontStyle(ImportButton, FontStyle.Bold);
            UserInterfaceAPI.SetFontStyle(ExportButton, FontStyle.Bold);
            UserInterfaceAPI.SetFontStyle(PanelLabel3, FontStyle.Bold);
            UserInterfaceAPI.SetFontStyle(PanelLabel4, FontStyle.Bold);
            UserInterfaceAPI.SetFontStyle(PanelLabel5, FontStyle.Bold);
            UserInterfaceAPI.SetFontStyle(PanelLabel6, FontStyle.Bold);
            UserInterfaceAPI.SetFontStyle(emailLabel, FontStyle.Bold);
            UserInterfaceAPI.SetFontStyle(PanelLabel1, FontStyle.Bold);

        }

        /// <summary>
        /// Звонок на номер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Contacts_NumberClicked(object sender, CustEventArgs e)
        {
            BLFPanel Own = (BLFPanel)this.Owner;
            if (!Owner.IsDisposed)
            {
                Own.RaiseCall(e.message);
            }
        }
        /// <summary>
        /// Быстрое применение фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickSearchPanel_OnClicked(object sender, CustEventArgs e)
        {
            searchBox.Text = e.message;
            QuickSearchPanel.Hide();
            //ContactsPanel.VerticalScroll.Maximum = BookOfContacts.Count;
            for (int i = 0; i < BookOfContacts.Count; i++)
            {
                if (BookOfContacts[i]._Client.Name.ToLower().Contains(e.message.ToLower()) | BookOfContacts[i]._Client.organisation.ToLower().Contains(e.message.ToLower()) | BookOfContacts[i]._Client.email.ToLower().Contains(e.message.ToLower()) && e.message != "")
                {
                    BookOfContacts[i].SelectRow();
                    ContactsPanel.VerticalScroll.Value = ContactsPanel.VerticalScroll.Maximum / BookOfContacts.Count * i;
                    return;
                    //AddToBook ATB = new AddToBook(BookOfContacts[i]._Client);
                    //  ATB.ShowDialog(this);
                    //  if (ATB.)
                }
            }
        }
        /// <summary>
        /// Загрузка контактов завершена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (BookOfContacts.Count <= 0) return;
            if (matches == 0)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        NoContactsLabel.Text = Localization[NoContactsLabel.Name][2] + filter;
                    }
                    catch (Exception)
                    {
                        NoContactsLabel.Text = "По запросу " + filter + " контактов не найдено";
                    }
                    NoContactsLabel.Show();
                    QuickSearchPanel.Hide();
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    NoContactsLabel.Hide();
                    if (QuickSearchPanel.Count > 1)
                        QuickSearchPanel.Show();
                });
            }
        }
        /// <summary>
        /// Перезагрузка списка контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadContactPanel(object sender, DoWorkEventArgs e)
        {
            if (BookOfContacts.Count <= 0) return;
            matches = 0;

            if (Initialize)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        NoContactsLabel.Text = Localization[NoContactsLabel.Name][1];
                    }
                    catch (Exception)
                    {
                        NoContactsLabel.Text = "Обновление списка контактов...";
                    }
                    NoContactsLabel.Show();
                });
                Thread.Sleep(150);
                for (int i = 0; i < BookOfContacts.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ContactsPanel.Controls.Add(BookOfContacts[i].OnBLFBorder, 0, i + 1);
                        ContactsPanel.Controls.Add(BookOfContacts[i].PhotoBorder, 1, i + 1);
                        ContactsPanel.Controls.Add(BookOfContacts[i].NameBorder, 2, i + 1);
                        ContactsPanel.Controls.Add(BookOfContacts[i].ComapnyBorder, 3, i + 1);
                        ContactsPanel.Controls.Add(BookOfContacts[i].PhoneBorder, 4, i + 1);
                        ContactsPanel.Controls.Add(BookOfContacts[i].EmailBorder, 5, i + 1);
                    });
                }
                matches = 1;
                Initialize = false;
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    QuickSearchPanel.Clear();
                });
                for (int i = 0; i < BookOfContacts.Count; i++)
                {
                    //if (BookOfContacts[i]._Client.Number.ToLower().Contains(filter.ToLower()) | BookOfContacts[i]._Client.SecondNumber.ToLower().Contains(filter.ToLower()) | BookOfContacts[i]._Client.Name.ToLower().Contains(filter.ToLower()) | BookOfContacts[i]._Client.organisation.ToLower().Contains(filter.ToLower()) | BookOfContacts[i]._Client.email.ToLower().Contains(filter.ToLower()) | filter == "")
                    //{
                    //    this.Invoke((MethodInvoker)delegate
                    //    {
                    //        BookOfContacts[i].ShowRow();
                    //    });
                    //    
                    //}
                    //else
                    //{
                    //    this.Invoke((MethodInvoker)delegate
                    //    {
                    //        BookOfContacts[i].HideRow();
                    //    });
                    //}
                    if (BookOfContacts[i]._Client.Number.ToLower().Contains(filter.ToLower()) | BookOfContacts[i]._Client.SecondNumber.ToLower().Contains(filter.ToLower()) | BookOfContacts[i]._Client.Name.ToLower().Contains(filter.ToLower()) | BookOfContacts[i]._Client.email.ToLower().Contains(filter.ToLower()))
                    {
                        if (searchBox.Text != string.Empty)
                            this.Invoke((MethodInvoker)delegate
                            {
                                QuickSearchPanel.Add(BookOfContacts[i]._Client.Name, BookOfContacts[i]._Client.Number);
                            });
                        matches++;
                    }
                    if (BookOfContacts[i]._Client.organisation.ToLower().Contains(filter.ToLower()))
                    {
                        if (searchBox.Text != string.Empty)
                            this.Invoke((MethodInvoker)delegate
                        {
                            QuickSearchPanel.Add(BookOfContacts[i]._Client.organisation);
                        });
                    }
                }
            }
        }
        int matches = 0;
        /// <summary>
        /// Удаление контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Contacts_DeleteContact(object sender, EventArgs e)
        {
            ContactRow cr = sender as ContactRow;

            for (int j = BookOfContacts.IndexOf(cr); j < BookOfContacts.Count - 1; j++)
            {
                BookOfContacts[j].SwapRow(BookOfContacts[j + 1]);
            }
            for (int i = 0; i < ContactsPanel.ColumnCount; i++)
            {
                Control c = ContactsPanel.GetControlFromPosition(i, BookOfContacts.Count);
                ContactsPanel.Controls.Remove(c);
                c.Dispose();
            }
            BookOfContacts.RemoveAt(BookOfContacts.Count - 1);
            if (cr._Client.onBLF)
                contactsEdited?.Invoke(this, null);
        }
        /// <summary>
        /// Событие выбора строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Contacts_RowSelected(object sender, EventArgs e)
        {
            for (int i = 0; i < BookOfContacts.Count; i++)
            {
                if (BookOfContacts[i].Selected)
                {
                    BookOfContacts[i].Deselect();
                }
            }
        }
        #region DefaultHandlers
        private void label9_MouseEnter(object sender, EventArgs e)
        {
            Label l = sender as Label;
            l.BackColor = Colors.WhiteTheme.ButtonHover;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            Label l = sender as Label;
            l.BackColor = Colors.WhiteTheme.ButtonMainColor;
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
        private void rightSizer_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeWE;
        }

        private void ClearFilter_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
            searchBox_MouseLeave(this, null);
        }


        private void NoContactsLabel_MouseEnter(object sender, EventArgs e)
        {
            QuickSearchPanel.Hide();
        }

        private void searchBox_MouseHover(object sender, EventArgs e)
        {
            if (searchBox.Text != string.Empty)
            {
                if (matches > 1)
                    QuickSearchPanel.Show();
            }
        }
        private void addButton_MouseEnter(object sender, EventArgs e)
        {
            addButton.Image = createImages.Images[1];
        }

        private void addButton_MouseLeave(object sender, EventArgs e)
        {
            addButton.Image = createImages.Images[0];
        }

        private void searchBox_MouseEnter(object sender, EventArgs e)
        {
            try
            {

                if (searchBox.Text == Localization[searchBox.Name][0])
                {
                    FilterLocked = true;
                    searchBox.Text = "";
                    searchBox.ForeColor = SystemColors.WindowText;
                }
            }
            catch (Exception)
            {
                if (searchBox.Text == "Введите номер или имя")
                {
                    FilterLocked = true;
                    searchBox.Text = "";
                    searchBox.ForeColor = SystemColors.WindowText;
                }
            }
        }

        private void searchBox_MouseLeave(object sender, EventArgs e)
        {
            if (!searchBox.Focused)
            {
                if (searchBox.Text.Length == 0)
                {
                    FilterLocked = true;
                    try
                    {

                        searchBox.Text = Localization[searchBox.Name][0];
                    }
                    catch (Exception)
                    {
                        searchBox.Text = "Введите номер или имя";
                    }
                    searchBox.ForeColor = SystemColors.GrayText;
                }
                if (FilterLocked)
                    searchPictureBox.Focus();
            }
        }
        bool FilterLocked = false;
        private void searchBox_MouseClick(object sender, MouseEventArgs e)
        {
            FilterLocked = false;
        }

        private void Contacts_Shown(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            Localizator.MakeLocalizationAllContextMenu(contextMenuStrip1, Localization);
            if (!ReloadContacts.IsBusy)
                ReloadContacts.RunWorkerAsync();
        }

        private void GeneralSettings_Language_Changed(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            Localizator.MakeLocalizationAllContextMenu(contextMenuStrip1, Localization);
            this.Refresh();
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text.Length == 0)
            {
                try
                {
                    searchBox.Text = Localization[searchBox.Name][0];
                }
                catch
                {
                    searchBox.Text = "Введите номер или имя";
                }
                searchBox.ForeColor = SystemColors.GrayText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BMessageBox.Show(this, "Функция находится в разработке", "In development");
            //ExcelFeature exclForm = new ExcelFeature((BLFPanel)this.Owner);
            //exclForm.Show(this);
        }

        private void autoCallButton_MouseEnter(object sender, EventArgs e)
        {
            autoCallButton.Image = Properties.Resources.auto_call_on;
        }

        private void autoCallButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Disposing && !IsDisposed)
                autoCallButton.Image = Properties.Resources.auto_call;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            ImportFile.Filter = "*.xls|*.xlsx";
            ImportFile.ShowDialog(this);
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            if (!ReloadContacts.IsBusy)
            {
                conBookEdited?.Invoke(this, null);
                Close();
            }
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

        private void headPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) WindowState = FormWindowState.Normal;
            else WindowState = FormWindowState.Maximized;
        }

        #endregion
        /// <summary>
        /// Изменение фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (!FilterLocked)
            {
                string curr = string.Empty;
                try
                {
                    curr = Localization[searchBox.Name][0];
                }
                catch (Exception)
                {
                    curr = "Введите номер или имя";
                }
                if (searchBox.Text == curr)
                {
                    if (filter == string.Empty)
                    {
                        ClearFilter.Hide();
                        QuickSearchPanel.Hide();
                        return;
                    }
                    else
                    {
                        filter = string.Empty;
                        ClearFilter.Hide();
                        QuickSearchPanel.Hide();

                    }
                }
                else if (searchBox.Text == string.Empty)
                {
                    ClearFilter.Hide();
                    QuickSearchPanel.Hide();
                    filter = string.Empty;
                }
                else
                {
                    filter = searchBox.Text;
                    ClearFilter.Show();
                }

                if (SlowSorting)
                {
                    if (!ReloadContacts.IsBusy)
                        ReloadContacts.RunWorkerAsync();
                }
            }
        }
        /// <summary>
        /// Сохраение книги контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            List<ClientsData> temp = new List<ClientsData>();
            foreach (ContactRow row in BookOfContacts)
            {
                temp.Add(row._Client);
            }
            XMLReadWriter.WriteContacts(temp);
        }
        /// <summary>
        /// Добавить новый контакт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            AddToBook ATB = new AddToBook();
            ATB.added = true;
            bool match = true;
            while (ATB.added && match)
            {
                ATB.ShowDialog(this);
                match = false;
                ClientsData tempContact = new ClientsData();
                if (ATB.newClient.Name != "")
                {
                    tempContact = ATB.newClient;
                    for (int i = 0; i < BookOfContacts.Count; i++)
                    {
                        if (BookOfContacts[i]._Client.Number.ToLower().Equals(tempContact.Number.ToLower()) && BookOfContacts[i]._Client.Prefix.ToLower().Equals(tempContact.Prefix.ToLower()))
                        {
                            match = true;
                            break;
                        }
                        else if (BookOfContacts[i]._Client.SecondNumber.ToLower().Equals(tempContact.SecondNumber.ToLower()) && !string.IsNullOrEmpty(BookOfContacts[i]._Client.SecondNumber))
                        {
                            match = true;
                            break;

                        }
                    }
                    if (!match)
                    {
                        try
                        {
                            NoContactsLabel.Text = Localization[NoContactsLabel.Name][1];
                        }
                        catch (Exception)
                        {
                            NoContactsLabel.Text = "Обновление списка контактов";
                        }
                        NoContactsLabel.Show();
                        Thread.Sleep(350);
                        BookOfContacts.Add(new ContactRow(tempContact, BookOfContacts.Count + 1));
                        BookOfContacts[BookOfContacts.Count - 1].RowSelected += Contacts_RowSelected;
                        BookOfContacts[BookOfContacts.Count - 1].DeleteContact += Contacts_DeleteContact;
                        BookOfContacts[BookOfContacts.Count - 1].NumberClicked += Contacts_NumberClicked;
                        ContactsPanel.Controls.Add(BookOfContacts.Last().OnBLFBorder, 0, BookOfContacts.Count);
                        ContactsPanel.Controls.Add(BookOfContacts.Last().PhotoBorder, 1, BookOfContacts.Count);
                        ContactsPanel.Controls.Add(BookOfContacts.Last().NameBorder, 2, BookOfContacts.Count);
                        ContactsPanel.Controls.Add(BookOfContacts.Last().ComapnyBorder, 3, BookOfContacts.Count);
                        ContactsPanel.Controls.Add(BookOfContacts.Last().PhoneBorder, 4, BookOfContacts.Count);
                        ContactsPanel.Controls.Add(BookOfContacts.Last().EmailBorder, 5, BookOfContacts.Count);
                        if (SlowSorting)
                        {
                            if (!ReloadContacts.IsBusy)
                                ReloadContacts.RunWorkerAsync();
                        }
                        if (tempContact.onBLF)
                            contactsEdited?.Invoke(this, null);
                        break;
                    }
                    else
                    {
                        if (ATB.added)
                            BMessageBox.Show("Контакт с таким номером уже существует");
                        ATB.newClient = tempContact;
                    }
                }
            }
        }
        /// <summary>
        /// Экспортирование в эксель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
            saveFileDialog.Filter = "*.xls|*.xlsx";
            try
            {

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                    {

                        using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(saveFileDialog.FileName)))
                        {
                            // get the first worksheet in the workbook
                            if (xlPackage.Workbook.Worksheets.Count <= 0)
                                xlPackage.Workbook.Worksheets.Add("Номера");
                            ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
                            var headers = new[] {
                                "Имя",
                                "Префикс",
                                "Номер",
                                "Второй номер (если есть)",
                                "Должность",
                                "Адрес",
                                "Организация",
                                "Адрес электронной почты",
                                "День рождения",
                                "Заметки"
                            };

                            for (int index = 0; index < headers.Length; index++)
                            {
                                var colInex = index + 1;
                                worksheet.Cell(1, colInex).Value = headers[index];
                            }

                            for (int i = 0; i < BookOfContacts.Count; i++)
                            {
                                var rowIndex = (i + 2);
                                worksheet.Cell(rowIndex, 1).Value = BookOfContacts[i]._Client.Name;
                                if (!string.IsNullOrEmpty(BookOfContacts[i]._Client.Prefix))
                                {
                                    worksheet.Cell(rowIndex, 2).Value = BookOfContacts[i]._Client.Prefix;
                                }
                                worksheet.Cell(rowIndex, 3).Value = BookOfContacts[i]._Client.Number;
                                if (!string.IsNullOrEmpty(BookOfContacts[i]._Client.SecondNumber)) worksheet.Cell(rowIndex, 4).Value = BookOfContacts[i]._Client.SecondNumber;
                                if (!string.IsNullOrEmpty(BookOfContacts[i]._Client.position)) worksheet.Cell(rowIndex, 5).Value = BookOfContacts[i]._Client.position;
                                if (!string.IsNullOrEmpty(BookOfContacts[i]._Client.site)) worksheet.Cell(rowIndex, 6).Value = BookOfContacts[i]._Client.site;
                                if (!string.IsNullOrEmpty(BookOfContacts[i]._Client.organisation)) worksheet.Cell(rowIndex, 7).Value = BookOfContacts[i]._Client.organisation;
                                if (!string.IsNullOrEmpty(BookOfContacts[i]._Client.email)) worksheet.Cell(rowIndex, 8).Value = BookOfContacts[i]._Client.email;
                                if (!string.IsNullOrEmpty(BookOfContacts[i]._Client.birthday.ToString()))
                                    worksheet.Cell(rowIndex, 9).Value = (BookOfContacts[i]._Client.birthday.Day % 10 == BookOfContacts[i]._Client.birthday.Day ? "0" + BookOfContacts[i]._Client.birthday.Day.ToString() : BookOfContacts[i]._Client.birthday.Day.ToString()) + "." +
                                        (BookOfContacts[i]._Client.birthday.Month % 10 == BookOfContacts[i]._Client.birthday.Month ? "0" + BookOfContacts[i]._Client.birthday.Month.ToString() : BookOfContacts[i]._Client.birthday.Month.ToString()) + "." +
                                        BookOfContacts[i]._Client.birthday.Year.ToString();
                                if (!string.IsNullOrEmpty(BookOfContacts[i]._Client.note)) worksheet.Cell(rowIndex, 10).Value = BookOfContacts[i]._Client.note;
                            }

                            xlPackage.Save();
                            xlPackage.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog("Failed to save to Excel", ex.Message);
                BMessageBox.Show("Не удалось сохранить файл");
            }
        }

        /// <summary>
        /// Импортирование из эксель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportFile_FileOk(object sender, CancelEventArgs e)
        {
            EventLogs.WriteLog(("Importing contacts from excel"));
            try
            {
                using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(ImportFile.FileName)))
                {
                    ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
                    int count = 2;
                    NoContactsLabel.Text = "Обновление списка контактов";
                    NoContactsLabel.Show();
                    while (worksheet.Cell(count, 1).Value != null)
                    {

                        ClientsData temp = new ClientsData();
                        temp.Name = worksheet.Cell(count, 1).Value.ToString();
                        if (worksheet.Cell(count, 2).Value != null) temp.Prefix = worksheet.Cell(count, 2).Value.ToString();
                        if (worksheet.Cell(count, 3).Value != null) temp.Number = worksheet.Cell(count, 3).Value.ToString();
                        else temp.Number = string.Empty;
                        if (worksheet.Cell(count, 4).Value != null) temp.SecondNumber = worksheet.Cell(count, 4).Value.ToString();
                        else temp.SecondNumber = string.Empty;
                        if (worksheet.Cell(count, 5).Value != null) temp.position = worksheet.Cell(count, 5).Value.ToString();
                        if (worksheet.Cell(count, 6).Value != null) temp.site = worksheet.Cell(count, 6).Value.ToString();
                        if (worksheet.Cell(count, 7).Value != null) temp.organisation = worksheet.Cell(count, 7).Value.ToString();
                        if (worksheet.Cell(count, 8).Value != null) temp.email = worksheet.Cell(count, 8).Value.ToString();
                        if (worksheet.Cell(count, 9).Value != null) temp.birthday = DateTime.Parse(worksheet.Cell(count, 9).Value.ToString());
                        if (worksheet.Cell(count, 10).Value != null) temp.note = worksheet.Cell(count, 10).Value.ToString();
                        bool match = false;
                        count++;
                        for (int i = 0; i < BookOfContacts.Count; i++)
                        {
                            if (BookOfContacts[i]._Client.Number.ToLower().Equals(temp.Number.ToLower()))
                            {
                                match = true;
                                break;
                            }
                            else if (BookOfContacts[i]._Client.SecondNumber.ToLower().Equals(temp.SecondNumber.ToLower()) && !string.IsNullOrEmpty(BookOfContacts[i]._Client.SecondNumber))
                            {
                                match = true;
                                break;
                            }
                        }
                        if (!match)
                        {
                            BookOfContacts.Add(new ContactRow(temp, BookOfContacts.Count + 1));
                            BookOfContacts[BookOfContacts.Count - 1].RowSelected += Contacts_RowSelected;
                            BookOfContacts[BookOfContacts.Count - 1].DeleteContact += Contacts_DeleteContact;
                            BookOfContacts[BookOfContacts.Count - 1].NumberClicked += Contacts_NumberClicked;
                            ContactsPanel.Controls.Add(BookOfContacts.Last().OnBLFBorder, 0, BookOfContacts.Count);
                            ContactsPanel.Controls.Add(BookOfContacts.Last().PhotoBorder, 1, BookOfContacts.Count);
                            ContactsPanel.Controls.Add(BookOfContacts.Last().NameBorder, 2, BookOfContacts.Count);
                            ContactsPanel.Controls.Add(BookOfContacts.Last().ComapnyBorder, 3, BookOfContacts.Count);
                            ContactsPanel.Controls.Add(BookOfContacts.Last().PhoneBorder, 4, BookOfContacts.Count);
                            ContactsPanel.Controls.Add(BookOfContacts.Last().EmailBorder, 5, BookOfContacts.Count);
                        }

                    }
                    if (!ReloadContacts.IsBusy)
                        ReloadContacts.RunWorkerAsync();
                }
            }
            catch (System.IO.IOException)
            {
                if (BMessageBox.Show(this, "Файл занят другим процессом, закройте его и повторите попытку.", BMessageBoxButtons.RetryCancel, BMessageBoxIcon.Exclamation) == DialogResult.Retry)
                {
                    ImportFile_FileOk(this, null);
                }
                else return;
            }
        }


    }
}
