using System;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace BCTI
{
    public class Fonts
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        public PrivateFontCollection Gothic = new PrivateFontCollection();
        public PrivateFontCollection GothicBold = new PrivateFontCollection();
        public PrivateFontCollection GothicBoldItalic = new PrivateFontCollection();
        public PrivateFontCollection GothicItalic = new PrivateFontCollection();
        public Fonts()
        {
            int fontLength = Properties.Resources.GOTHIC.Length;
            byte[] fontdata = Properties.Resources.GOTHIC;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            // We HAVE to do this to register the font to the system (Weird .NET bug !)
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontLength, IntPtr.Zero, ref cFonts);
            Gothic.AddMemoryFont(data, fontLength);
            Marshal.FreeCoTaskMem(data);

            fontLength = Properties.Resources.GOTHICB.Length;
            fontdata = Properties.Resources.GOTHICB;
            data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            // We HAVE to do this to register the font to the system (Weird .NET bug !)
            cFonts = 1;
            AddFontMemResourceEx(data, (uint)fontLength, IntPtr.Zero, ref cFonts);
            GothicBold.AddMemoryFont(data, fontLength);
            Marshal.FreeCoTaskMem(data);

            fontLength = Properties.Resources.GOTHICBI.Length;
            fontdata = Properties.Resources.GOTHICBI;
            data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            // We HAVE to do this to register the font to the system (Weird .NET bug !)
            cFonts = 2;
            AddFontMemResourceEx(data, (uint)fontLength, IntPtr.Zero, ref cFonts);
            GothicBoldItalic.AddMemoryFont(data, fontLength);
            Marshal.FreeCoTaskMem(data);

            fontLength = Properties.Resources.GOTHICI.Length;
            fontdata = Properties.Resources.GOTHICI;
            data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            // We HAVE to do this to register the font to the system (Weird .NET bug !)
            cFonts = 3;
            AddFontMemResourceEx(data, (uint)fontLength, IntPtr.Zero, ref cFonts);
            GothicItalic.AddMemoryFont(data, fontLength);
            Marshal.FreeCoTaskMem(data);
        }
    }
}
