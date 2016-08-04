using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using AsteriskManager;
using BCTI.Properties;
using System.Collections.Generic;
using BCTI.Helpers;

namespace BCTI
{
    public partial class AddToBook : Form
    {
        private bool onBLF = false;
        public Image ava = null;
        private bool AvaExists = false;
        public ClientsData newClient { get; set; }
        public bool added = false;
        public bool editing = false;
        public int index = int.MaxValue;
        ImageCutter imcut = null;
        string avatar = string.Empty;
        event EventHandler<EventArgs> showImcut;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        private Dictionary<string, string[]> currLocalization = new Dictionary<string, string[]>();
        /// <summary>
        /// Конструктор для создания нового контакта
        /// </summary>
        public AddToBook()
        {
            newClient = new ClientsData();
            InitializeComponent();
            headLabel.Text = "Создать контакт";
            //ChangePhotoLabel.BackColor = Colors.WhiteTheme.ButtonHover;
            //ChangePhotoLabel.Visible = false;
            avatarBox.BackgroundImage = Resources.add_contact;
            ///Событие показа диалога для обрезки аватара
            showImcut += AddToBook_showImcut;

            ///Локализация
            Localization = Localizator.GetFormLocalization("AddToBook", BLFPanel.Staticsettings.Interface.Language);
            currLocalization = Localization;
            Localizator.MakeLocalization(this, Localization);

            ///Шрифты
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(headLabel, FontStyle.Bold);
        }
        /// <summary>
        /// Конструктор для редактирования существующего контакта
        /// </summary>
        /// <param name="editingContact">Редактируемый контакт</param>
        public AddToBook(ClientsData editingContact)
        {
            Owner = (Form)BLFPanel.mainBLF;
            newClient = editingContact;
            InitializeComponent();
            showImcut += AddToBook_showImcut;

            ///Заполнение данных контакта
            BLFPanel.ApplyLanguage += SettingsForm_ApplySettings;
            Localization = Localizator.GetFormLocalization("AddToBook", BLFPanel.Staticsettings.Interface.Language);
            currLocalization = Localization;
            Localizator.MakeLocalization(this, Localization);

            try
            {
                if (!string.IsNullOrEmpty(newClient.Name) && !string.IsNullOrEmpty(newClient.Number))
                {
                    editing = true;
                    headLabel.Text = Localization[headLabel.Name][1];
                }
                else
                    headLabel.Text = Localization[headLabel.Name][0];
            }
            catch
            {
                if (!string.IsNullOrEmpty(newClient.Name) && !string.IsNullOrEmpty(newClient.Number))
                {
                    editing = true;
                    headLabel.Text = "Редактировать контакт";
                }
                else
                    headLabel.Text = "Создать контакт";
            }

            try
            {
                if (newClient.Name == "") nameBox.Text = Localization[nameBox.Name][0];
                else nameBox.Text = newClient.Name;

            }
            catch
            {
                if (newClient.Name == "") nameBox.Text = "Имя";
                else nameBox.Text = newClient.Name;
            }

            try
            {

                if (newClient.note == "") notesBox.Text = Localization[notesBox.Name][0];
                else notesBox.Text = newClient.note;
            }
            catch
            {
                if (newClient.note == "") notesBox.Text = "Заметки";
                else notesBox.Text = newClient.note;
            }

            try
            {

                if (newClient.Number == "") numberBox.Text = Localization[numberBox.Name][0];
                else numberBox.Text = newClient.Number;
            }
            catch
            {
                if (newClient.Number == "") numberBox.Text = "Номер";
                else numberBox.Text = newClient.Number;
            }

            try
            {

                if (newClient.SecondNumber == "") secondNumberBox.Text = Localization[secondNumberBox.Name][0];
                else secondNumberBox.Text = newClient.SecondNumber;
            }
            catch
            {
                if (newClient.SecondNumber == "") secondNumberBox.Text = "Дополнительный номер";
                else secondNumberBox.Text = newClient.SecondNumber;
            }

            try
            {

                if (newClient.position == "") positionBox.Text = Localization[positionBox.Name][0];
                else positionBox.Text = newClient.position;
            }
            catch
            {
                if (newClient.position == "") positionBox.Text = "Должность";
                else positionBox.Text = newClient.position;
            }

            try
            {

                if (newClient.site == "") adressBox.Text = Localization[adressBox.Name][0];
                else adressBox.Text = newClient.site;
            }
            catch
            {
                if (newClient.site == "") adressBox.Text = "Адрес";
                else adressBox.Text = newClient.site;
            }

            try
            {

                if (newClient.organisation == "")
                    organisationBox.Text = Localization[organisationBox.Name][0];
                else
                    organisationBox.Text = newClient.organisation;
            }
            catch
            {
                if (newClient.organisation == "")
                    organisationBox.Text = "Организация";
                else
                    organisationBox.Text = newClient.organisation;
            }

            try
            {

                if (newClient.email == "")
                    emailBox.Text = Localization[emailBox.Name][0];
                else
                    emailBox.Text = newClient.email;
            }
            catch
            {
                if (newClient.email == "")
                    emailBox.Text = "Электронная почта";
                else
                    emailBox.Text = newClient.email;
            }

            try
            {

                if (string.IsNullOrEmpty(newClient.Prefix)) prefixBox.Text = Localization[prefixBox.Name][0];
                else
                    prefixBox.Text = newClient.Prefix;
            }
            catch
            {
                if (string.IsNullOrEmpty(newClient.Prefix)) prefixBox.Text = "Префикс";
                else
                    prefixBox.Text = newClient.Prefix;
            }

            onBLF = newClient.onBLF;
            if (newClient.birthday > birthdayBox.MaxDate || newClient.birthday < birthdayBox.MinDate)
            {
                birthdayBox.Value = birthdayBox.MaxDate;

            }
            else
            {
                birthdayBox.Value = newClient.birthday;
            }
            if (onBLF)
                onBLFCheckBox.BackColor = Colors.WhiteTheme.ButtonHover;
            else
                onBLFCheckBox.BackColor = SystemColors.ScrollBar;

            if (!string.IsNullOrEmpty(newClient.ID.ToString()))
            {
                ImageLoader img = new ImageLoader(newClient);
                if (img.IsImageExists())
                {
                    avatarBox.BackgroundImage = img.Load();
                    AvaExists = true;
                }
                else avatarBox.BackgroundImage = Resources.add_contact;
            }
            else
                avatarBox.BackgroundImage = avaListImage.Images[0];
            //}

            if (!string.IsNullOrEmpty(editingContact.ID.ToString()))
            {
                ImageLoader img = new ImageLoader(editingContact);
                if (img.IsImageExists())
                {
                    avatarBox.BackgroundImage = img.Load();
                    AvaExists = true;
                }
                else avatarBox.BackgroundImage = Resources.add_contact;
            }
            else
                avatarBox.BackgroundImage = avaListImage.Images[0];
            ///Лейбл кнопки для изменения картинки(Не реализован!)
            //ChangePhotoLabel.BackColor = Colors.WhiteTheme.ButtonHover;
            //ChangePhotoLabel.Visible = false;

            ///Шрифты
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(headLabel, FontStyle.Bold);
        }
        /// <summary>
        /// Открыть форму редактирования аватара
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToBook_showImcut(object sender, EventArgs e)
        {
            imcut = new ImageCutter(Image.FromFile(avatar));
            imcut.FormClosed += Imcut_FormClosed;
            imcut.ShowDialog(this);
        }
        #region Проверка правильности вводимых данных

        private void prefixBox_TextChanged(object sender, EventArgs e)
        {
            long res;
            try
            {
                if (prefixBox.Text != Localization[prefixBox.Name][0] && prefixBox.Text != currLocalization[prefixBox.Name][0])
                {
                    if (!Int64.TryParse(prefixBox.Text.Replace("*", ""), out res) && prefixBox.Text.Replace("+", "") != "")
                    {
                        prefixBox.BackColor = Colors.WhiteTheme.Red;
                        prefixBox.ForeColor = Color.Black;
                        return;
                    }
                    else
                    {
                        prefixBox.BackColor = Color.White;
                        prefixBox.ForeColor = Color.Black;
                    }
                }
                else
                {
                    prefixBox.BackColor = Color.White;
                    prefixBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
            catch (Exception)
            {
                if (prefixBox.Text != "Префикс")
                {
                    if (!Int64.TryParse(prefixBox.Text.Replace("*", ""), out res) && prefixBox.Text.Replace("+", "") != "")
                    {
                        prefixBox.BackColor = Colors.WhiteTheme.Red;
                        prefixBox.ForeColor = Color.Black;
                        return;
                    }
                    else
                    {
                        prefixBox.BackColor = Color.White;
                        prefixBox.ForeColor = Color.Black;
                    }
                }
                else
                {
                    prefixBox.BackColor = Color.White;
                    prefixBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
        }

        private void prefixBox_Leave(object sender, EventArgs e)
        {
            try
            {
                var text = prefixBox.Text.Replace(" ", "");
                if (text == "")
                {
                    prefixBox.Text = Localization[prefixBox.Name][0];
                    prefixBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
            catch (Exception)
            {
                var text = prefixBox.Text.Replace(" ", "");
                if (text == "")
                {
                    prefixBox.Text = "Префикс";
                    prefixBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
        }
        private void numberBox_TextChanged(object sender, EventArgs e)
        {
            ///(!!!)
            try
            {
                long res;
                if (numberBox.Text != Localization[numberBox.Name][0] && numberBox.Text != currLocalization[numberBox.Name][0])
                {
                    if (!Int64.TryParse(numberBox.Text.Replace("*", ""), out res) && numberBox.Text.Replace("*", "") != "")
                    {
                        numberBox.BackColor = Colors.WhiteTheme.Red;
                        numberBox.ForeColor = Color.Black;
                        return;
                    }
                    else
                    {
                        numberBox.BackColor = Color.White;
                        numberBox.ForeColor = Color.Black;
                    }
                }
                else
                {
                    numberBox.BackColor = Color.White;
                    numberBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
            catch
            {
                long res;
                if (numberBox.Text != "Номер")
                {
                    if (!Int64.TryParse(numberBox.Text.Replace("*", ""), out res) && numberBox.Text.Replace("*", "") != "")
                    {
                        numberBox.BackColor = Colors.WhiteTheme.Red;
                        numberBox.ForeColor = Color.Black;
                        return;
                    }
                    else
                    {
                        numberBox.BackColor = Color.White;
                        numberBox.ForeColor = Color.Black;
                    }
                }
                else
                {
                    numberBox.BackColor = Color.White;
                    numberBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
        }

        private void secondNumberBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long res;
                if (secondNumberBox.Text != Localization[secondNumberBox.Name][0] && secondNumberBox.Text != currLocalization[secondNumberBox.Name][0])
                {
                    if (!Int64.TryParse(secondNumberBox.Text.Replace("+", "").Replace("*", ""), out res) && secondNumberBox.Text.Replace("+", "").Replace("*", "") != "")
                    {
                        secondNumberBox.BackColor = Colors.WhiteTheme.Red;
                        secondNumberBox.ForeColor = Color.Black;
                        return;
                    }
                    else
                    {
                        secondNumberBox.BackColor = Color.White;
                        secondNumberBox.ForeColor = Color.Black;
                    }
                }
                else
                {
                    secondNumberBox.BackColor = Color.White;
                    secondNumberBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
            catch (Exception)
            {
                long res;
                if (secondNumberBox.Text != "Дополнительный номер")
                {
                    if (!Int64.TryParse(secondNumberBox.Text.Replace("+", "").Replace("*", ""), out res) && secondNumberBox.Text.Replace("+", "").Replace("*", "") != "")
                    {
                        secondNumberBox.BackColor = Colors.WhiteTheme.Red;
                        secondNumberBox.ForeColor = Color.Black;
                        return;
                    }
                    else
                    {
                        secondNumberBox.BackColor = Color.White;
                        secondNumberBox.ForeColor = Color.Black;
                    }
                }
                else
                {
                    secondNumberBox.BackColor = Color.White;
                    secondNumberBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox temp = (TextBox)sender;
                temp.BackColor = Color.White;
                if (temp.Text != Localization[temp.Name][0] && temp.Text != "")
                    temp.ForeColor = Color.Black;
            }
            catch
            {
                TextBox temp = (TextBox)sender;
                temp.BackColor = Color.White;
                temp.ForeColor = Color.Black;
            }
        }

        #endregion
        #region DefaultHandlers

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Label l = sender as Label;
            l.BackColor = Colors.WhiteTheme.ButtonHover;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Label l = sender as Label;
            l.BackColor = Colors.WhiteTheme.ButtonMainColor;
        }

        private void avatarBox_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                avatarBox.BorderStyle = BorderStyle.None;
                //if (!AvaExists)
                //    avatarBox.BackgroundImage = Resources.add_contact_on;
            }
            catch
            { }
        }

        private void avatarBox_MouseLeave(object sender, EventArgs e)
        {
            avatarBox.BorderStyle = BorderStyle.FixedSingle;
            //if (!AvaExists)
            //    avatarBox.BackgroundImage = Resources.add_contact;
        }
        private void nameBox_Leave(object sender, EventArgs e)
        {
            try
            {
                var text = nameBox.Text.Replace(" ", "");
                if (text == "")
                {
                    nameBox.Text = Localization[nameBox.Name][0];
                    nameBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
            catch (Exception)
            {
                var text = nameBox.Text.Replace(" ", "");
                if (text == "")
                {
                    nameBox.Text = "Имя";
                    nameBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
        }

        private void positionBox_Leave(object sender, EventArgs e)
        {
            try
            {
                var text = positionBox.Text.Replace(" ", "");
                if (text == "")
                {
                    positionBox.Text = Localization[positionBox.Name][0];
                    positionBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
            catch (Exception)
            {
                var text = positionBox.Text.Replace(" ", "");
                if (text == "")
                {
                    positionBox.Text = "Должность";
                    positionBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
        }

        private void organisationBox_Leave(object sender, EventArgs e)
        {
            try
            {
                var text = organisationBox.Text.Replace(" ", "");
                if (text == "")
                {
                    organisationBox.Text = Localization[organisationBox.Name][0];
                    organisationBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }

            }
            catch (Exception)
            {
                var text = organisationBox.Text.Replace(" ", "");
                if (text == "")
                {
                    organisationBox.Text = "Организация";
                    organisationBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
        }

        private void adressBox_Leave(object sender, EventArgs e)
        {
            try
            {
                var text = adressBox.Text.Replace(" ", "");
                if (text == "")
                {
                    adressBox.Text = Localization[adressBox.Name][0];
                    adressBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }

            }
            catch (Exception)
            {
                var text = adressBox.Text.Replace(" ", "");
                if (text == "")
                {
                    adressBox.Text = "Адрес";
                    adressBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
        }

        private void emailBox_Leave(object sender, EventArgs e)
        {
            try
            {

                var text = emailBox.Text.Replace(" ", "");
                if (text == "")
                {
                    emailBox.Text = Localization[emailBox.Name][0];
                    emailBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
            catch (Exception)
            {
                var text = emailBox.Text.Replace(" ", "");
                if (text == "")
                {
                    emailBox.Text = "Электронная почта";
                    emailBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
        }

        private void numberBox_Leave(object sender, EventArgs e)
        {
            try
            {

                var text = numberBox.Text.Replace(" ", "");
                if (text == "")
                {
                    numberBox.Text = Localization[numberBox.Name][0];
                    numberBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
            catch
            {
                var text = numberBox.Text.Replace(" ", "");
                if (text == "")
                {
                    numberBox.Text = "Номер";
                    numberBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
        }

        private void secondNumberBox_Leave(object sender, EventArgs e)
        {
            try
            {
                var text = secondNumberBox.Text.Replace(" ", "");
                if (text == "")
                {
                    secondNumberBox.Text = Localization[secondNumberBox.Name][0];
                    secondNumberBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }

            }
            catch (Exception)
            {

                var text = secondNumberBox.Text.Replace(" ", "");
                if (text == "")
                {
                    secondNumberBox.Text = "Дополнительный номер";
                    secondNumberBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
        }

        private void notesBox_Leave(object sender, EventArgs e)
        {
            try
            {
                var text = notesBox.Text.Replace(" ", "");
                if (text == "")
                {
                    notesBox.Text = Localization[notesBox.Name][0];
                    notesBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }

            }
            catch (Exception)
            {
                var text = notesBox.Text.Replace(" ", "");
                if (text == "")
                {
                    notesBox.Text = "Заметки";
                    notesBox.ForeColor = Colors.WhiteTheme.ButtonMainColor;
                }
            }
        }

        private void onBLFCheckBox_MouseEnter(object sender, EventArgs e)
        {
            if (onBLF)
            {

            }
            else
            {
                onBLFCheckBox.BackColor = Colors.WhiteTheme.MainColor;
            }
        }

        private void onBLFCheckBox_MouseLeave(object sender, EventArgs e)
        {
            if (onBLF)
            {

            }
            else
            {
                onBLFCheckBox.BackColor = SystemColors.ScrollBar;
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            added = false;
            Close();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            added = false;
            Close();
        }

        private void AddToBook_Load(object sender, EventArgs e)
        {
            closeButton.BackgroundImage = closeButtonImage.Images[0];
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            if (!Disposing && !IsDisposed)
                closeButton.BackgroundImage = closeButtonImage.Images[1];
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Disposing && !IsDisposed)
                closeButton.BackgroundImage = closeButtonImage.Images[0];
        }

        private void nameBox_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (temp.ForeColor == Color.FromArgb(160, 160, 160))
                temp.Text = "";
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
        private void avatarBox_Click(object sender, EventArgs e)
        {
            avatarDialog.ShowDialog(this);
        }

        private void avatarDialog_FileOk(object sender, CancelEventArgs e)
        {
            avatar = avatarDialog.FileName;
            showImcut?.Invoke(this, null);
        }

        private void SettingsForm_ApplySettings(object sender, EventArgs e)
        {
            currLocalization = new Dictionary<string, string[]>();
            currLocalization = Localizator.GetFormLocalization("AddToBook", BLFPanel.Staticsettings.Interface.Language);
            if (!string.IsNullOrEmpty(newClient.Name) && !string.IsNullOrEmpty(newClient.Number))
            {
                editing = true;
                try
                {
                    headLabel.Text = currLocalization[headLabel.Name][1];
                }
                catch
                {
                    headLabel.Text = "Редактировать контакт";
                }
            }
            else
                try
                {
                    headLabel.Text = currLocalization[headLabel.Name][0];
                }
                catch
                {
                    headLabel.Text = "Создать контакт";
                }

            make_change_language(nameBox, "Имя");
            make_change_language(notesBox, "Заметки");
            make_change_language(numberBox, "Номер");
            make_change_language(secondNumberBox, "Дополнительный номер");
            make_change_language(positionBox, "Должность");
            make_change_language(adressBox, "Адрес");
            make_change_language(organisationBox, "Организация");
            make_change_language(emailBox, "Электронная почта");
            make_change_language(prefixBox, "Префикс");

            //if (nameBox.Text == "" || nameBox.Text == Localization[nameBox.Name][0]) nameBox.Text = currLocalization[nameBox.Name][0];
            //if (notesBox.Text == "" || notesBox.Text == Localization[notesBox.Name][0]) notesBox.Text = currLocalization[notesBox.Name][0];
            //if (numberBox.Text == "" || numberBox.Text == Localization[numberBox.Name][0]) numberBox.Text = currLocalization[numberBox.Name][0];
            //if (secondNumberBox.Text == "" || secondNumberBox.Text == Localization[secondNumberBox.Name][0]) secondNumberBox.Text = currLocalization[secondNumberBox.Name][0];
            //if (positionBox.Text == "" || positionBox.Text == Localization[positionBox.Name][0]) positionBox.Text = currLocalization[positionBox.Name][0];
            //if (adressBox.Text == "" || adressBox.Text == Localization[adressBox.Name][0]) adressBox.Text = currLocalization[adressBox.Name][0];
            //if (organisationBox.Text == "" || organisationBox.Text == Localization[organisationBox.Name][0])
            //    organisationBox.Text = currLocalization[organisationBox.Name][0];
            //if (emailBox.Text == "" || emailBox.Text == Localization[emailBox.Name][0])
            //    emailBox.Text = currLocalization[emailBox.Name][0];
            //if (prefixBox.Text == "" || prefixBox.Text == Localization[prefixBox.Name][0]) prefixBox.Text = currLocalization[prefixBox.Name][0];

            //try
            //{

            //DateLabel.Text = currLocalization[DateLabel.Name][0];
            //}
            //catch
            //{

            //}

            //try
            //{

            //SaveButton.Text = currLocalization[SaveButton.Name][0];
            //}
            //catch
            //{
            //    SaveButton.Text = "Сохранить"; 
            //}

            //try
            //{

            //CancButton.Text = currLocalization[CancButton.Name][0];
            //}
            //catch
            //{

            //}
            //onBLFlab.Text = currLocalization[onBLFlab.Name][0];
            Localization = currLocalization;
        }

        private void make_change_language(TextBox temp, string defaultValue)
        {
            string tempString = string.Empty;
            try
            {
                tempString = Localization[temp.Name][0];
            }
            catch
            {
                tempString = "Имя";
            }

            string curr = string.Empty;
            try
            {
                curr = currLocalization[temp.Name][0];
            }
            catch
            {
                curr = "Имя";
            }
            if (temp.Text == "" || temp.Text == tempString) temp.Text = curr;
        }

        private void Imcut_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (imcut.added)
            {
                ava = (Image)imcut.result.Clone();
                avatarBox.BackgroundImage = ava;
                Update();
                AvaExists = true;
            }
        }


        private void AddToBook_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        /// <summary>
        /// Отображение контакта на блф
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onBlf_MouseClick(object sender, MouseEventArgs e)
        {
            if (onBLF)
            {
                onBLF = false;
                onBLFCheckBox.BackColor = SystemColors.ScrollBar;
                return;
            }
            else
            {
                onBLF = true;
                onBLFCheckBox.BackColor = Colors.WhiteTheme.ButtonHover;
                return;
            }
        }

        /// <summary>
        /// Сохранение пользовательских данных контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            try
            {

                if (nameBox.Text == "" || nameBox.Text == Localization[nameBox.Name][0])
                {
                    nameBox.BackColor = Colors.WhiteTheme.Red;
                    nameBox.ForeColor = Color.Black;
                    return;
                }
                else
                {
                    newClient.Name = nameBox.Text;
                    nameBox.BackColor = Color.White;
                }
            }
            catch (Exception)
            {
                if (nameBox.Text == "" || nameBox.Text == "Имя")
                {
                    nameBox.BackColor = Colors.WhiteTheme.Red;
                    nameBox.ForeColor = Color.Black;
                    return;
                }
                else
                {
                    newClient.Name = nameBox.Text;
                    nameBox.BackColor = Color.White;
                }
            }

            try
            {

                if (numberBox.Text == "" || numberBox.Text == Localization[numberBox.Name][0])
                {
                    numberBox.BackColor = Colors.WhiteTheme.Red;
                    numberBox.ForeColor = Color.Black;
                    return;
                }
                else
                {
                    ///(!!!) Номер пользователя может быть текстом
                    Double res;
                    if (!Double.TryParse(numberBox.Text.Replace("*", ""), out res))
                    {
                        numberBox.BackColor = Colors.WhiteTheme.Red;
                        numberBox.ForeColor = Color.Black;
                        return;
                    }

                    newClient.Number = numberBox.Text;
                    numberBox.BackColor = Color.White;
                }
            }
            catch (Exception)
            {
                if (numberBox.Text == "" || numberBox.Text == "Номер")
                {
                    numberBox.BackColor = Colors.WhiteTheme.Red;
                    numberBox.ForeColor = Color.Black;
                    return;
                }
                else
                {
                    ///(!!!) Номер пользователя может быть текстом
                    Double res;
                    if (!Double.TryParse(numberBox.Text.Replace("*", ""), out res))
                    {
                        numberBox.BackColor = Colors.WhiteTheme.Red;
                        numberBox.ForeColor = Color.Black;
                        return;
                    }

                    newClient.Number = numberBox.Text;
                    numberBox.BackColor = Color.White;
                }
            }

            try
            {

                if (secondNumberBox.Text == Localization[secondNumberBox.Name][0])
                    newClient.SecondNumber = "";
                else
                {
                    ///(!!!) Номер пользователя может быть текстом
                    Double res;
                    if (!Double.TryParse(secondNumberBox.Text.Replace("+", "").Replace("*", ""), out res) &&
                        !string.IsNullOrEmpty(secondNumberBox.Text))
                    {
                        secondNumberBox.BackColor = Colors.WhiteTheme.Red;
                        secondNumberBox.ForeColor = Color.Black;
                        return;
                    }
                    newClient.SecondNumber = secondNumberBox.Text;
                }
            }
            catch (Exception)
            {
                if (secondNumberBox.Text == "Дополнительный номер")
                    newClient.SecondNumber = "";
                else
                {
                    ///(!!!) Номер пользователя может быть текстом
                    Double res;
                    if (!Double.TryParse(secondNumberBox.Text.Replace("+", "").Replace("*", ""), out res) && !string.IsNullOrEmpty(secondNumberBox.Text))
                    {
                        secondNumberBox.BackColor = Colors.WhiteTheme.Red;
                        secondNumberBox.ForeColor = Color.Black;
                        return;
                    }
                    newClient.SecondNumber = secondNumberBox.Text;
                }
            }

            try
            {

                if (organisationBox.Text == Localization[organisationBox.Name][0])
                    newClient.organisation = "";
                else
                    newClient.organisation = organisationBox.Text;
            }
            catch (Exception)
            {
                if (organisationBox.Text == "Организация")
                    newClient.organisation = "";
                else
                    newClient.organisation = organisationBox.Text;
            }

            try
            {

                if (prefixBox.Text == Localization[prefixBox.Name][0])
                    newClient.Prefix = "";
                else
                {
                    int res;
                    if (!int.TryParse(prefixBox.Text.Replace("+", "").Replace("*", ""), out res) &&
                        !string.IsNullOrEmpty(prefixBox.Text))
                    {
                        prefixBox.BackColor = Colors.WhiteTheme.Red;
                        prefixBox.ForeColor = Color.Black;
                        return;
                    }
                    newClient.Prefix = prefixBox.Text;
                }
            }
            catch (Exception)
            {
                if (prefixBox.Text == "Префикс")
                    newClient.Prefix = "";
                else
                {
                    int res;
                    if (!int.TryParse(prefixBox.Text.Replace("+", "").Replace("*", ""), out res) && !string.IsNullOrEmpty(prefixBox.Text))
                    {
                        prefixBox.BackColor = Colors.WhiteTheme.Red;
                        prefixBox.ForeColor = Color.Black;
                        return;
                    }
                    newClient.Prefix = prefixBox.Text;
                }
            }

            try
            {

                if (positionBox.Text == Localization[positionBox.Name][0])
                    newClient.position = "";
                else
                    newClient.position = positionBox.Text;
            }
            catch (Exception)
            {
                if (positionBox.Text == "Должность")
                    newClient.position = "";
                else
                    newClient.position = positionBox.Text;
            }

            try
            {

                if (adressBox.Text == Localization[adressBox.Name][0])
                    newClient.site = "";
                else
                    newClient.site = adressBox.Text;
            }
            catch
            {
                if (adressBox.Text == "Адрес")
                    newClient.site = "";
                else
                    newClient.site = adressBox.Text;
            }

            try
            {

                if (emailBox.Text == Localization[emailBox.Name][0])
                    newClient.email = "";
                else
                {
                    if (!emailBox.Text.Contains("@"))
                    {
                        return;
                    }
                    newClient.email = emailBox.Text;
                }
            }
            catch (Exception)
            {
                if (emailBox.Text == "Электронная почта")
                    newClient.email = "";
                else
                {
                    if (!emailBox.Text.Contains("@"))
                    {
                        return;
                    }
                    newClient.email = emailBox.Text;
                }
            }

            try
            {
                if (notesBox.Text == Localization[positionBox.Name][0])
                    newClient.note = "";
                else
                    newClient.note = notesBox.Text;
            }
            catch (Exception)
            {
                if (notesBox.Text == "Заметки")
                    newClient.note = "";
                else
                    newClient.note = notesBox.Text;
            }
            newClient.onBLF = onBLF;
            newClient.birthday = birthdayBox.Value;

            ///Сохраняем новый аватар
            if (imcut != null && imcut.added)
            {
                if (ava != null)
                {
                    if (!Directory.Exists(path + "/B-Cti/avatars/")) Directory.CreateDirectory(path + "/B-Cti/avatars/");
                    if (File.Exists(path + "/B-Cti/avatars/" + newClient.ID.ToString() + ".jpeg"))
                    {
                        File.Delete(path + "/B-Cti/avatars/" + newClient.ID.ToString() + ".jpeg");
                    }
                    FileStream fs = new FileStream(path + "/B-Cti/avatars/" + newClient.ID.ToString() + ".jpeg", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    ava.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                    fs.Close();
                }
            }
            added = true;
            this.Close();
        }
    }
}
