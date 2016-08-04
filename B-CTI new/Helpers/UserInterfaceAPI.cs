using System;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI
{
    public class UserInterfaceAPI
    {
        private static Fonts MainFont = new Fonts();
        public static void InitFonts(Control control)
        {
            control.Font = new Font(MainFont.Gothic.Families[0], control.Font.Size);
            foreach (Control c in control.Controls)
            {
                //c.Font = new Font(MainFont.Gothic.Families[0], c.Font.Size);
                InitFonts(c);
            }
        }
        public static void SetFontStyle(Control control, FontStyle style)
        {
            control.Font = new Font(control.Font, style);
        }
        /// <summary>
        /// Метод для изменения размера шрифта относительно отрисовки
        /// </summary>
        public static void AutoSizeFont(Control control)
        {
            try
            {
                while (control.Width < TextRenderer.MeasureText(control.Text, new Font(control.Font.FontFamily, control.Font.Size, control.Font.Style)).Width)
                {
                    control.Font = new Font(control.Font.FontFamily, control.Font.Size - 0.5f, control.Font.Style);
                }
            }
            catch
            {

            }
        }
        public void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button temp = (Button)sender;
                temp.BackColor = Colors.WhiteTheme.ButtonHover;
            }
            else if (sender is Label)
            {
                Label temp = (Label)sender;
                temp.BackColor = Colors.WhiteTheme.ButtonHover;
            }
        }

        public void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button temp = (Button)sender;
                temp.BackColor = Colors.WhiteTheme.ButtonMainColor;
            }
            else if (sender is Label)
            {
                Label temp = (Label)sender;
                temp.BackColor = Colors.WhiteTheme.ButtonMainColor;
            }
        }
    }
}
