using BCTI.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BCTI
{
    public class ClipboardHelper
    {
        private static Dictionary<string, List<ClipboardDataItem>> clipboardBackupData = new Dictionary<string, List<ClipboardDataItem>>();
        private static List<ClipboardDataItem> m_singlebackup;

        public static void Backup()
        {
            m_singlebackup = GetClipboard();
        }

        public static bool EmptyClipboard() =>
            User32.EmptyClipboard();
        public static List<ClipboardDataItem> GetClipboard()
        {
            List<ClipboardDataItem> list = new List<ClipboardDataItem>();
            int num = 0;
            while (!User32.OpenClipboard(IntPtr.Zero))
            {
                if (num > 5)
                {
                    throw new Exception("OpenClipboard FAILED!");
                }
                num++;
                Thread.Sleep((int)(num * 0x19));
            }
            uint target = 0;
            while (((ulong)InlineAssignHelper<uint>(ref target, User32.EnumClipboardFormats(target))) != 0L)
            {
                string formatName = "0";
                if (target > 14L)
                {
                    StringBuilder lpszFormatName = new StringBuilder();
                    if (User32.GetClipboardFormatName(target, lpszFormatName, 100) > 0)
                    {
                        formatName = lpszFormatName.ToString();
                    }
                }
                IntPtr clipboardData = User32.GetClipboardData(target);
                if (clipboardData != IntPtr.Zero)
                {
                    byte[] buffer;
                    UIntPtr ptr2 = Kernel32.GlobalSize(clipboardData);
                    IntPtr source = Kernel32.GlobalLock(clipboardData);
                    if (((int)((uint)ptr2)) > 0)
                    {
                        buffer = new byte[(((int)((uint)ptr2)) - 1) + 1];
                        int length = Convert.ToInt32(ptr2.ToString());
                        Marshal.Copy(source, buffer, 0, length);
                    }
                    else
                    {
                        buffer = new byte[0];
                    }
                    ClipboardDataItem item = new ClipboardDataItem(target, formatName, buffer)
                    {
                        FormatName = formatName
                    };
                    list.Add(item);
                }
            }
            User32.CloseClipboard();
            return list;
        }

        public string getClipboardStringdata()
        {
            IDataObject dataObject = Clipboard.GetDataObject();
            if (dataObject.GetDataPresent(typeof(string)))
            {
                return (string)dataObject.GetData(typeof(string));
            }
            return "";
        }

        public static string getGlobalSelectedText()
        {
            Application.DoEvents();
            string str3 = "";
            ClipboardHelper helper = new ClipboardHelper();
            str3 = "";
            Backup();
            string str2 = "";
            str2 = helper.getClipboardStringdata();
            SendCopy(User32.GetForegroundWindow());
            Application.DoEvents();
            str3 = helper.getClipboardStringdata();
            if (str2 == str3)
            {
                Thread.Sleep(100);
                SendCopy(User32.GetForegroundWindow());
                Application.DoEvents();
                str3 = helper.getClipboardStringdata();
                if (str2 == str3)
                {
                    Application.DoEvents();
                    Thread.Sleep(150);
                    SendCopy(User32.GetForegroundWindow());
                    str3 = helper.getClipboardStringdata();
                }
            }
            Restore();
            Application.DoEvents();
            return str3;
        }

        private static T InlineAssignHelper<T>(ref T target, T value)
        {
            target = value;
            return value;
        }

        private static List<ClipboardDataItem> ReadFromFile(string clipName)
        {
            List<ClipboardDataItem> list = new List<ClipboardDataItem>();
            if (Directory.Exists(clipName))
            {
                DirectoryInfo info = new DirectoryInfo(clipName);
                int num2 = info.GetFiles().GetLength(0) - 1;
                for (int i = 0; i <= num2; i++)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ClipboardDataItem));
                    FileInfo info2 = new FileInfo(info.FullName + @"\" + i.ToString() + ".cli");
                    using (FileStream stream = info2.Open(FileMode.Open))
                    {
                        list.Add((ClipboardDataItem)serializer.Deserialize(stream));
                        stream.Flush();
                        stream.Close();
                    }
                }
            }
            return list;
        }

        public static bool Restore() =>
            SetClipboard(m_singlebackup);

        public static void SendCopy()
        {
            User32.keybd_event(0x11, 0, 0, 0);
            User32.keybd_event(0x43, 0, 0, 0);
            Thread.Sleep(200);
            User32.keybd_event(0x43, 0, 2, 0);
            User32.keybd_event(0x11, 0, 2, 0);
        }

        public static void SendCopy(IntPtr WindowHandle)
        {
            IntPtr foregroundWindow = User32.GetForegroundWindow();
            User32.SetForegroundWindow(WindowHandle);
            SendCopy();
            User32.SetForegroundWindow(foregroundWindow);
        }
        public static bool SetClipboard(List<ClipboardDataItem> clipData)
        {
            int num = 0;
            while (!User32.OpenClipboard(IntPtr.Zero))
            {
                if (num > 5)
                {
                    throw new Exception("OpenClipboard FAILED!");
                }
                num++;
                Thread.Sleep((int)(num * 0x19));
            }
            EmptyClipboard();
            IEnumerator<ClipboardDataItem> enumerator = clipData.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ClipboardDataItem current = enumerator.Current;
                IntPtr hMem = Kernel32.GlobalAlloc(0x2002, current.Size);
                IntPtr destination = Kernel32.GlobalLock(hMem);
                if (((int)((uint)current.Size)) > 0)
                {
                    Marshal.Copy(current.Buffer, 0, destination, current.Buffer.GetLength(0));
                }
                Kernel32.GlobalUnlock(hMem);
                User32.SetClipboardData(current.Format, hMem);
            }
            User32.CloseClipboard();
            return true;
        }
        [Serializable]
        public class ClipboardDataItem
        {
            private byte[] m_buffer;
            private uint m_format;
            private string m_formatName;
            private int m_size;

            public ClipboardDataItem()
            {
            }

            public ClipboardDataItem(uint format, string formatName, byte[] buffer)
            {
                this.m_format = format;
                this.m_formatName = formatName;
                this.m_buffer = buffer;
                this.m_size = 0;
            }

            public byte[] Buffer
            {
                get
                {

                    return this.m_buffer;
                }
                set
                {
                    this.m_buffer = value;
                }
            }

            public uint Format
            {
                get
                {
                    return this.m_format;
                }
                set
                {
                    this.m_format = value;
                }
            }

            public string FormatName
            {
                get
                {
                    return this.m_formatName;
                }

                set
                {
                    this.m_formatName = value;
                }
            }

            public UIntPtr Size
            {
                get
                {
                    if (this.m_buffer != null)
                    {
                        return new UIntPtr(Convert.ToUInt32(this.m_buffer.GetLength(0)));
                    }
                    return new UIntPtr(Convert.ToUInt32(this.m_size));
                }
            }
        }
    }
}
