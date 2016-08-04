using BCTI.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI.DialogBoxes
{
    /// <summary>
    /// Кнопки, доступные на BMessageBox
    /// </summary>
    public enum BMessageBoxButtons
    {
        /// <summary>
        /// Кнопки "Прервать", "Повторить", "Пропустить"
        /// </summary>
        AbortRetryIgnore,
        /// <summary>
        /// Кнопка "ОК"
        /// </summary>
        OK,
        /// <summary>
        /// Кнопки "ОК", "Отмена"
        /// </summary>
        OKCancel,
        /// <summary>
        /// Кнопки "Повторить", "Отмена"
        /// </summary>
        RetryCancel,
        /// <summary>
        /// Кнопки "Да", "Нет"
        /// </summary>
        YesNo,
        /// <summary>
        /// Кнопки "Да", "Нет" "Отмена"
        /// </summary>
        YesNoCancel
    }
    public enum BMessageBoxIcon
    {
        /// <summary>
        /// Буква i в нижнем регистре в кружке
        /// </summary>
        Asterisk,
        /// <summary>
        /// Значок Х
        /// </summary>
        Error,
        /// <summary>
        /// Значок восклицательного знака
        /// </summary>
        Exclamation,
        /// <summary>
        /// Значок Х
        /// </summary>
        Hand,
        /// <summary>
        /// Буква i в нижнем регистре в кружке
        /// </summary>
        Information,
        /// <summary>
        /// Отсутствие значка
        /// </summary>
        None,
        /// <summary>
        /// Значок вопросительного знака
        /// </summary>
        Question,
        /// <summary>
        /// Значок Х
        /// </summary>
        Stop,
        /// <summary>
        /// Значок восклицательного знака
        /// </summary>
        Warning
    }
    /// <summary>
    /// The form internally used by <see cref="CustomMessageBox"/> class.
    /// </summary>
    internal partial class BMessageForm : Form
    {
        /// <summary>
        /// This constructor is required for designer support.
        /// </summary>
        public DialogResult Result;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();

        public BMessageForm(string title, string description)
        {
            InitializeComponent();
            closeButton.BackgroundImage = closeButtonImage.Images[0];
            this.titleLabel.Text = title;
            this.descriptionLabel.Text = description;
            AbortRetryIgnorePanel.Hide();
            OKpanel.Show();
            OKCancelPanel.Hide();
            RetryCancelPanel.Hide();
            YesNoPanel.Hide();
            YesNoCancelPanel.Hide();
            TopMost = true;

            if (BLFPanel.Staticsettings != null)
            {
                Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
                Localizator.MakeLocalization(this, Localization);
            }
        }

        public BMessageForm(string title, string description, BMessageBoxButtons buttons)
        {
            InitializeComponent();
            Location = new Point(0, 0);
            AbortRetryIgnorePanel.Hide();
            OKpanel.Hide();
            OKCancelPanel.Hide();
            RetryCancelPanel.Hide();
            YesNoPanel.Hide();
            YesNoCancelPanel.Hide();
            closeButton.BackgroundImage = closeButtonImage.Images[0];
            this.titleLabel.Text = title;
            this.descriptionLabel.Text = description;
            TopMost = true;
            switch (buttons)
            {
                case BMessageBoxButtons.AbortRetryIgnore:
                    {
                        AbortRetryIgnorePanel.Show();
                        break;
                    }
                case BMessageBoxButtons.OK:
                    {
                        OKpanel.Show();
                        break;
                    }
                case BMessageBoxButtons.OKCancel:
                    {
                        OKCancelPanel.Show();
                        break;
                    }
                case BMessageBoxButtons.RetryCancel:
                    {
                        RetryCancelPanel.Show();
                        break;
                    }
                case BMessageBoxButtons.YesNo:
                    {
                        YesNoPanel.Show();
                        break;
                    }
                case BMessageBoxButtons.YesNoCancel:
                    {
                        YesNoCancelPanel.Show();
                        break;
                    }
                default: break;
            }

            if (BLFPanel.Staticsettings != null)
            {
                Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
                Localizator.MakeLocalization(this, Localization);
            }
        }

        public void ChangeIcon(BMessageBoxIcon icon)
        {
            switch (icon)
            {
                case BMessageBoxIcon.Asterisk:
                    {
                        iconBox.BackgroundImage = iconsList.Images[1];
                        break;
                    }
                case BMessageBoxIcon.Error:
                    {
                        iconBox.BackgroundImage = iconsList.Images[0];
                        break;
                    }
                case BMessageBoxIcon.Exclamation:
                    {
                        iconBox.BackgroundImage = iconsList.Images[2];
                        break;
                    }
                case BMessageBoxIcon.Hand:
                    {
                        iconBox.BackgroundImage = iconsList.Images[0];
                        break;
                    }
                case BMessageBoxIcon.Information:
                    {
                        iconBox.BackgroundImage = iconsList.Images[1];
                        break;
                    }
                case BMessageBoxIcon.None:
                    {
                        iconBox.Hide();
                        break;
                    }
                case BMessageBoxIcon.Question:
                    {
                        iconBox.BackgroundImage = iconsList.Images[3];
                        break;
                    }
                case BMessageBoxIcon.Stop:
                    {
                        iconBox.BackgroundImage = iconsList.Images[0];
                        break;
                    }
                case BMessageBoxIcon.Warning:
                    {
                        iconBox.BackgroundImage = iconsList.Images[2];
                        break;
                    }
            }
        }

        #region CloseButton
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
        #endregion

        private void OKbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
        #region dragging

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

        private void OKbutton_MouseClick(object sender, MouseEventArgs e)
        {
            Result = DialogResult.OK;
            Close();
        }

        private void YesYNButton_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Yes;
            Close();
        }

        private void NoYNButton_Click(object sender, EventArgs e)
        {
            Result = DialogResult.No;
            Close();
        }

        private void RetryRCButton_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Retry;
            Close();
        }

        private void CancelRCButton_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Cancel;
            Close();
        }

        private void IgnoreButton_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Ignore;
            Close();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Abort;
            Close();
        }

        private void ChooseFileButton_MouseEnter(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            temp.BackColor = Colors.WhiteTheme.ButtonHover;
            Cursor = Cursors.Hand;
        }

        private void ChooseFileButton_MouseLeave(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            temp.BackColor = Colors.WhiteTheme.ButtonMainColor;
            Cursor = Cursors.Default;
        }
    }

    /// <summary>
    /// Your custom message box helper.
    /// </summary>
    public static class BMessageBox
    {
        public static DialogResult Show(string description)
        {
            string title = "Ошибка!";
            // using construct ensures the resources are freed when form is closed
            using (var form = new BMessageForm(title, description))
            {
                form.ShowDialog();
                return form.Result;
            }
        }

        public static DialogResult Show(IWin32Window owner, string description)
        {
            string title = "Ошибка!";
            // using construct ensures the resources are freed when form is closed
            using (var form = new BMessageForm(title, description))
            {
                form.ShowDialog(owner);
                return form.Result;
            }
        }

        public static DialogResult Show(IWin32Window owner, string description, BMessageBoxButtons buttons)
        {
            string title = "Ошибка!";
            // using construct ensures the resources are freed when form is closed
            using (var form = new BMessageForm(title, description, buttons))
            {
                form.ShowDialog(owner);
                return form.Result;
            }
        }

        public static DialogResult Show(string description, BMessageBoxButtons buttons)
        {
            string title = "Ошибка!";
            // using construct ensures the resources are freed when form is closed
            using (var form = new BMessageForm(title, description, buttons))
            {
                form.ShowDialog();
                return form.Result;
            }
        }

        public static DialogResult Show(string description, BMessageBoxButtons buttons, BMessageBoxIcon icon)
        {
            string title = "Ошибка!";
            // using construct ensures the resources are freed when form is closed
            using (var form = new BMessageForm(title, description, buttons))
            {
                form.ChangeIcon(icon);
                form.ShowDialog();
                return form.Result;
            }
        }

        public static DialogResult Show(IWin32Window owner, string description, BMessageBoxButtons buttons, BMessageBoxIcon icon)
        {
            string title = "Ошибка!";
            // using construct ensures the resources are freed when form is closed
            using (var form = new BMessageForm(title, description, buttons))
            {
                form.ChangeIcon(icon);
                form.ShowDialog(owner);
                return form.Result;
            }
        }

        public static DialogResult Show(string description, string _title)
        {
            string title = _title;
            // using construct ensures the resources are freed when form is closed
            using (var form = new BMessageForm(title, description))
            {
                form.ShowDialog();
                return form.Result;
            }
        }

        public static DialogResult Show(IWin32Window owner, string description, string _title)
        {
            string title = _title;
            // using construct ensures the resources are freed when form is closed
            using (var form = new BMessageForm(title, description))
            {
                form.ShowDialog(owner);
                return form.Result;
            }
        }

        public static DialogResult Show(string description, string _title, BMessageBoxButtons buttons)
        {
            string title = _title;
            // using construct ensures the resources are freed when form is closed
            using (var form = new BMessageForm(title, description, buttons))
            {
                form.ShowDialog();
                return form.Result;
            }
        }

        public static DialogResult Show(string description, string _title, BMessageBoxButtons buttons, BMessageBoxIcon icon)
        {
            string title = _title;
            // using construct ensures the resources are freed when form is closed
            using (var form = new BMessageForm(title, description, buttons))
            {
                form.ChangeIcon(icon);
                form.ShowDialog();
                return form.Result;
            }
        }

        public static DialogResult Show(IWin32Window owner, string description, string _title, BMessageBoxButtons buttons)
        {
            string title = _title;
            // using construct ensures the resources are freed when form is closed
            using (var form = new BMessageForm(title, description, buttons))
            {
                form.ShowDialog(owner);
                return form.Result;
            }
        }

        public static DialogResult Show(IWin32Window owner, string description, string title, BMessageBoxButtons buttons, BMessageBoxIcon icon)
        {
            // using construct ensures the resources are freed when form is closed
            using (var form = new BMessageForm(title, description, buttons))
            {
                form.ChangeIcon(icon);
                form.ShowDialog(owner);
                return form.Result;
            }
        }
    }
}
