using AsteriskManager;
using BCTI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI
{
    public partial class Preview : Form
    {
        ClientsData newClient;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        public Preview()
        {
            InitializeComponent();
            UserInterfaceAPI.InitFonts(this);
            numberLabel2.Font = new Font(numberLabel2.Font, FontStyle.Bold);
            secondNumberLabel.Font = new Font(secondNumberLabel.Font, FontStyle.Bold);
        }
        public Preview(ClientsData editingContact)
        {
            Owner = (Form)BLFPanel.mainBLF;
            newClient = editingContact;
            InitializeComponent();

            Localization = Localizator.GetFormLocalization("Preview", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);

            infoLabel.Text = editingContact.Name;

            try
            {
                if (editingContact.Number == "") numberLabel2.Text = Localization[numberLabel2.Name][0];
                else numberLabel2.Text = editingContact.Prefix + editingContact.Number;

            }
            catch (Exception)
            {
                if (editingContact.Number == "") numberLabel2.Text = "Номер";
                else numberLabel2.Text = editingContact.Prefix + editingContact.Number;
            }

            try
            {
                if (editingContact.SecondNumber == "") secondNumberLabel.Text = Localization[secondNumberLabel.Name][0];
                else secondNumberLabel.Text = editingContact.SecondNumber;

            }
            catch (Exception)
            {
                if (editingContact.SecondNumber == "") secondNumberLabel.Text = "Неизвестно";
                else secondNumberLabel.Text = editingContact.SecondNumber;
            }

            try
            {

                if (editingContact.organisation == "")
                    organisationLabel.Text = Localization[organisationLabel.Name][0];
                else
                    organisationLabel.Text = editingContact.organisation;
            }
            catch (Exception)
            {
                if (editingContact.organisation == "")
                    organisationLabel.Text = "Нет организации";
                else
                    organisationLabel.Text = editingContact.organisation;
            }

            try
            {
                if (editingContact.email == "")
                    emailLabel.Text = Localization[emailLabel.Name][0];
                else
                    emailLabel.Text = editingContact.email;

            }
            catch (Exception)
            {
                if (editingContact.email == "")
                    emailLabel.Text = "Нет почты";
                else
                    emailLabel.Text = editingContact.email;
            }

            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            ImageLoader img = new ImageLoader(editingContact);
            if (img.IsImageExists())
            {
                avaBox.BackgroundImage = img.Load();
            }
            //ChangePhotoLabel.BackColor = Colors.WhiteTheme.ButtonHover;
            //ChangePhotoLabel.Visible = false;

            UserInterfaceAPI.InitFonts(this);
            numberLabel2.Font = new Font(numberLabel2.Font, FontStyle.Bold);
            secondNumberLabel.Font = new Font(secondNumberLabel.Font, FontStyle.Bold);
            while (numberLabel2.Width < System.Windows.Forms.TextRenderer.MeasureText(numberLabel2.Text, new Font(numberLabel2.Font.FontFamily, numberLabel2.Font.Size, numberLabel2.Font.Style)).Width)
            {
                numberLabel2.Font = new Font(numberLabel2.Font.FontFamily, numberLabel2.Font.Size - 0.5f, numberLabel2.Font.Style);
            }
            while (secondNumberLabel.Width < System.Windows.Forms.TextRenderer.MeasureText(secondNumberLabel.Text, new Font(secondNumberLabel.Font.FontFamily, secondNumberLabel.Font.Size, secondNumberLabel.Font.Style)).Width)
            {
                secondNumberLabel.Font = new Font(secondNumberLabel.Font.FontFamily, secondNumberLabel.Font.Size - 0.5f, secondNumberLabel.Font.Style);
            }
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization("Preview", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            infoLabel.Text = newClient.Name;
            try
            {
                if (newClient.Number == "") numberLabel2.Text = Localization[numberLabel2.Name][0];
                else numberLabel2.Text = newClient.Prefix + newClient.Number;

            }
            catch (Exception)
            {
                if (newClient.Number == "") numberLabel2.Text = "Номер";
                else numberLabel2.Text = newClient.Prefix + newClient.Number;
            }

            try
            {
                if (newClient.SecondNumber == "") secondNumberLabel.Text = Localization[secondNumberLabel.Name][0];
                else secondNumberLabel.Text = newClient.SecondNumber;

            }
            catch (Exception)
            {
                if (newClient.SecondNumber == "") secondNumberLabel.Text = "Неизвестно";
                else secondNumberLabel.Text = newClient.SecondNumber;
            }

            try
            {

                if (newClient.organisation == "")
                    organisationLabel.Text = Localization[organisationLabel.Name][0];
                else
                    organisationLabel.Text = newClient.organisation;
            }
            catch (Exception)
            {
                if (newClient.organisation == "")
                    organisationLabel.Text = "Нет организации";
                else
                    organisationLabel.Text = newClient.organisation;
            }

            try
            {
                if (newClient.email == "")
                    emailLabel.Text = Localization[emailLabel.Name][0];
                else
                    emailLabel.Text = newClient.email;

            }
            catch (Exception)
            {
                if (newClient.email == "")
                    emailLabel.Text = "Нет почты";
                else
                    emailLabel.Text = newClient.email;
            }
        }

        private void Preview_MouseEnter(object sender, EventArgs e)
        {
            Close();
        }
    }
}
