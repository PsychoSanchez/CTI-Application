using System;
using System.Runtime.InteropServices;

namespace BCTI.Settings
{
    public class Kernel32
    {
        // Fields 
        public const uint GMEM_DDESHARE = 0x2000;
        public const uint GMEM_MOVEABLE = 2;

        // Methods 
        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory")]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, int size);
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern ushort GlobalAddAtom(string lpString);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalAlloc(uint uFlags, UIntPtr dwBytes);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern ushort GlobalDeleteAtom(ushort nAtom);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalFree(IntPtr hMem);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalLock(IntPtr hMem);
        [DllImport("kernel32.dll")]
        public static extern UIntPtr GlobalSize(IntPtr hMem);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalUnlock(IntPtr hMem);
    }
}
