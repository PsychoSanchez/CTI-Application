using AsteriskManager;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace BCTI
{
    public class ImageLoader
    {
        private ClientsData client;
        public ImageLoader(ClientsData _client)
        {
            client = _client;
        }
        /// <summary>
        /// Проверка на существование аватара клиента
        /// </summary>
        /// <returns></returns>
        public bool IsImageExists()
        {
            return File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/B-Cti/avatars/" + client.ID.ToString() + ".jpeg");
        }
        Image curr;
        /// <summary>
        /// Загрузка обычного аватара
        /// </summary>
        /// <returns></returns>
        public Image Load()
        {
            curr = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/B-Cti/avatars/" + client.ID.ToString() + ".jpeg");
            ImageConverter ic = new ImageConverter();
            byte[] data = (byte[])ic.ConvertTo(curr, typeof(byte[]));
            MemoryStream ms = new MemoryStream(data);
            curr.Dispose();
            Image img = Image.FromStream(ms, true, true);
            ms.Close();
            return img;
        }
        /// <summary>
        /// Метод для получения кргулой картинки из автара клиента
        /// </summary>
        /// <param name="BackgroundColor"></param>
        /// <returns></returns>
        public Image CircleImage(Color BackgroundColor)
        {
            curr = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/B-Cti/avatars/" + client.ID.ToString() + ".jpeg");
            Bitmap RoundedImage = new Bitmap(curr.Width, curr.Height);
            Graphics g = Graphics.FromImage(RoundedImage);
            g.Clear(BackgroundColor);
            g.SmoothingMode = SmoothingMode.HighQuality;
            Brush brush = new TextureBrush(curr);
            GraphicsPath gp = new GraphicsPath();
            if (curr.Width < curr.Height)
                gp.AddEllipse(0, 0, curr.Width, curr.Height);
            else
                gp.AddEllipse(0, 0, curr.Width - (curr.Width / 30), curr.Height - (curr.Height / 30));
            g.FillPath(brush, gp);
            curr.Dispose();
            return RoundedImage;
        }
        /// <summary>
        /// Метод для получения кргулой картинки
        /// </summary>
        /// <param name="sharedImage"></param>
        /// <param name="BackgroundColor"></param>
        /// <returns></returns>
        public Image CircleImage(Image sharedImage, Color BackgroundColor)
        {
            curr = sharedImage;
            //CornerRadius *= 2;
            Bitmap RoundedImage = new Bitmap(curr.Width, curr.Height);
            Graphics g = Graphics.FromImage(RoundedImage);
            g.Clear(BackgroundColor);
            g.SmoothingMode = SmoothingMode.HighQuality;
            Brush brush = new TextureBrush(curr);
            GraphicsPath gp = new GraphicsPath();
            if (curr.Width < curr.Height)
                gp.AddEllipse(0, 0, curr.Width, curr.Height);
            else
                gp.AddEllipse(0, 0, curr.Width - (curr.Width / 30), curr.Height - (curr.Height / 30));
            g.FillPath(brush, gp);
            curr.Dispose();
            return RoundedImage;
        }
        /// <summary>
        /// Метод для получения скругленной картинки
        /// </summary>
        /// <param name="CornerRadius"></param>
        /// <param name="BackgroundColor"></param>
        /// <returns></returns>
        public Image RoundCorners(int CornerRadius, Color BackgroundColor)
        {
            curr = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/B-Cti/avatars/" + client.ID.ToString() + ".jpeg");
            CornerRadius *= 2;
            Bitmap RoundedImage = new Bitmap(curr.Width, curr.Height);
            Graphics g = Graphics.FromImage(RoundedImage);
            g.Clear(BackgroundColor);
            g.SmoothingMode = SmoothingMode.HighQuality;
            Brush brush = new TextureBrush(curr);
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
            gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
            gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            gp.AddArc(0, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            g.FillPath(brush, gp);
            return RoundedImage;
        }
    }
}
