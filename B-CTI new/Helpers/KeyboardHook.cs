using BCTI.Settings;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BCTI
{
    public sealed class KeyboardHook : IDisposable
    {


        /// <summary>
        /// Represents the window that is used internally to get the messages.
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;

            public Window()
            {
                // create the handle for the window.
                this.CreateHandle(new CreateParams());
            }


            /// <summary>
            /// Overridden to get the notifications.
            /// </summary>
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                // check if we got a hot key pressed.

                if (m.Msg == WM_HOTKEY)
                {
                    //Hotkey
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifKeys modifier = (ModifKeys)((int)m.LParam & 0xFFFF);
                    KeyPressed?.Invoke(this, new KeyPressedEventArgs(modifier, key));
                    //// invoke the event to notify the parent.

                }
                else
                if (m.Msg == Program.WM_CALLTO)
                {
                    //CallTo
                    Program.COPYDATASTRUCT CD = (Program.COPYDATASTRUCT)m.GetLParam(typeof(Program.COPYDATASTRUCT));
                    byte[] B = new byte[CD.cbData];
                    IntPtr lpData = CD.lpData;
                    Marshal.Copy(lpData, B, 0, CD.cbData);
                    string strData = Encoding.Default.GetString(B);
                    CalltoEvent?.Invoke(this, new CustEventArgs(strData));
                }
                else
                {
                    base.WndProc(ref m);
                }
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;
            public event EventHandler<CustEventArgs> CalltoEvent;
            #region IDisposable Members

            public void Dispose()
            {
                this.DestroyHandle();
            }

            #endregion
        }

        private Window _window = new Window();
        private int _currentId;
        private static HotkeyMessageProcessor hkc = new HotkeyMessageProcessor();
        private bool m_enabled;
        private HotkeyDefinition m_hotkeydefinition;
        private int m_id;

        public event EventHandler<KeyPressedEventArgs> KeyPressed;
        public event EventHandler<CustEventArgs> CalltoEvent;
        public event HotkeyPressedEventHandler HotkeyPressed;
        #region Конструкторы
        public KeyboardHook()
        {
            _window.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                KeyPressed?.Invoke(this, args);
            };
            _window.CalltoEvent += delegate (object sender, CustEventArgs args)
            {
                CalltoEvent?.Invoke(this, args);
            };
        }
        public KeyboardHook(string UniqueDescription)
        {
            this.m_id = 0;
            this.m_enabled = true;
            string lpString = Thread.CurrentThread.ManagedThreadId.ToString("X8") + UniqueDescription;
            this.m_id = Kernel32.GlobalAddAtom(lpString);
            if (this.m_id == 0)
            {
                throw new Exception("Unable to generate unique hotkey ID. Error code: " + Marshal.GetLastWin32Error().ToString());
            }
            hkc.addHotkeyListener(this);
            _window.CalltoEvent += delegate (object sender, CustEventArgs args)
            {
                CalltoEvent?.Invoke(this, args);
            };
        }
        #endregion
        /// <summary>
        /// HotkeyPressed
        /// </summary>
        private void FireHotkeyPressedEvent()
        {
            HotkeyPressed?.Invoke();
        }

        /// <summary>
        /// Отправляем запрос на отпускание клавиш и ожидаем пока событие сработает
        /// </summary>
        public void PreReleaseHotkeyKeys()
        {
            User32.keybd_event((byte)this.m_hotkeydefinition.key, 0, 2, 0);
            if (this.m_hotkeydefinition.ModifierShift)
            {
                User32.keybd_event(0x10, 0, 2, 0);
            }
            if (this.m_hotkeydefinition.ModifierAlt)
            {
                User32.keybd_event(0x12, 0, 2, 0);
            }
            if (this.m_hotkeydefinition.ModifierControl)
            {
                User32.keybd_event(0x11, 0, 2, 0);
            }
            if (this.m_hotkeydefinition.ModifierAlt)
            {
                while (User32.GetAsyncKeyState((int)this.m_hotkeydefinition.key) > 0)
                {
                    Thread.Sleep(5);
                }
            }
            int num = 0;
            if (this.m_hotkeydefinition.ModifierShift)
            {
                num = 0;
                while (User32.GetAsyncKeyState(0x10) > 0)
                {
                    Thread.Sleep(5);
                    num++;
                    if (num == 200)
                    {
                        throw new Exception("Error while releasing hotkey-key (timeout while waiting for key-up)");
                    }
                }
            }
            if (this.m_hotkeydefinition.ModifierAlt)
            {
                num = 0;
                while (User32.GetAsyncKeyState(0x12) > 0)
                {
                    Thread.Sleep(5);
                    num++;
                    if (num == 200)
                    {
                        throw new Exception("Error while releasing hotkey-key (timeout while waiting for key-up)");
                    }
                }
            }
            if (this.m_hotkeydefinition.ModifierControl)
            {
                num = 0;
                while (User32.GetAsyncKeyState(0x11) > 0)
                {
                    Thread.Sleep(5);
                    num++;
                    if (num == 200)
                    {
                        throw new Exception("Error while releasing hotkey-key (timeout while waiting for key-up)");
                    }
                }
            }
        }
        /// <summary>
        /// Регистрация горячей клавиши на обработчик сообщений
        /// </summary>
        //public void Register()
        //{
        //    this.Register(_window.Handle);
        //}
        ///// <summary>
        ///// Регистрация горячей клавиши на обработчик сообщений
        ///// </summary>
        //public void Register(IntPtr handle)
        //{
        //    if (!this.m_hotkeydefinition.isValid)
        //    {
        //        throw new Exception("Hotkey is not valid, could not register!");
        //    }
        //    UnregisterHotKey(handle, this.ID);
        //    RegisterHotKey(handle, this.ID, this.m_hotkeydefinition.getModifierCode(), (uint)this.m_hotkeydefinition.key);
        //    this.m_registered = true;
        //}
        /// <summary>
        /// Регистрация горячей клавиши на обработчик сообщений
        /// </summary>
        //public void Unregister()
        //{
        //    this.Unregister(_window.Handle);
        //}
        /// <summary>
        /// Регистрация горячей клавиши на обработчик сообщений
        /// </summary>
        /// <param name="handle"></param>
        //public void Unregister(IntPtr handle)
        //{
        //    User32.UnregisterHotKey(handle, this.ID);
        //    this.m_registered = false;
        //}

        public int ID => this.m_id;

        private class HotkeyMessageProcessor : IMessageFilter
        {
            private Dictionary<string, KeyboardHook> hotkeylist = new Dictionary<string, BCTI.KeyboardHook>();

            public void addHotkeyListener(KeyboardHook hk)
            {
                this.hotkeylist.Add("1", hk);
                if (this.hotkeylist.Count == 1)
                {
                    Application.AddMessageFilter(this);
                }
            }
            /// <summary>
            /// Обработчик сообщений окна
            /// </summary>
            /// <param name="m"></param>
            /// <returns></returns>
            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == 0x312L)
                {
                    //int wParam = (int)m.WParam;
                    //Console.WriteLine(wParam.ToString());
                    //if (this.hotkeylist.ContainsKey(wParam.ToString()))
                    //{
                    KeyboardHook hotkey = null;
                    //wParam = (int)m.WParam;
                    hotkey = (KeyboardHook)this.hotkeylist["1"];
                    //if (hotkey.Enabled)
                    //{
                    hotkey.FireHotkeyPressedEvent();
                    return true;
                    //}
                    //}
                }
                return false;
            }

            public void removeHotkeyListener(KeyboardHook hk)
            {
                this.hotkeylist.Remove(hk.ID.ToString());
                if (this.hotkeylist.Count == 0)
                {
                    Application.RemoveMessageFilter(this);
                }
            }
        }

        public delegate void HotkeyPressedEventHandler();





        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        public void RegisterHotKey(ModifKeys modifier, Keys key)
        {
            // increment the counter.
            _currentId = _currentId + 1;
            m_hotkeydefinition = new HotkeyDefinition(key, modifier == ModifKeys.Control, modifier == ModifKeys.Alt, modifier == ModifKeys.Shift);
            // register the hot key.
            if (!RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
                throw new InvalidOperationException("Couldn’t register the hot key.");
        }
        public void UnregisterHotkey()
        {
            for (int i = _currentId; i > 0; i--)
            {
                UnregisterHotKey(_window.Handle, i);
            }
        }

        /// <summary>
        /// A hot key has been pressed.
        /// </summary>
        #region IDisposable Members

        public void Dispose()
        {
            // unregister all the registered hot keys.
            for (int i = _currentId; i > 0; i--)
            {
                UnregisterHotKey(_window.Handle, i);
            }
            if (this.m_id != 0)
            {
                hkc.removeHotkeyListener(this);
                Kernel32.GlobalDeleteAtom((ushort)this.m_id);
            }
            // dispose the inner native window.
            _window.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        private ModifKeys _modifier;
        private Keys _key;

        internal KeyPressedEventArgs(ModifKeys modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public ModifKeys Modifier
        {
            get { return _modifier; }
        }

        public Keys Key
        {
            get { return _key; }
        }
    }

    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    [Flags]
    public enum ModifKeys : uint
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }

    public class HotkeyDefinition
    {
        public Keys key;
        public bool ModifierAlt;
        public bool ModifierControl;
        public bool ModifierShift;

        public HotkeyDefinition()
        {
            this.ModifierAlt = false;
            this.ModifierShift = false;
            this.ModifierControl = false;
            this.key = Keys.None;
        }

        public HotkeyDefinition(Keys key, bool ModifiedCtrl = false, bool ModifiedAlt = false, bool ModifierShift = false)
        {
            this.ModifierAlt = false;
            this.ModifierShift = false;
            this.ModifierControl = false;
            this.key = Keys.None;
            this.key = key;
            this.ModifierControl = ModifiedCtrl;
            this.ModifierAlt = ModifiedAlt;
            this.ModifierShift = ModifierShift;
        }

        public string getHotkeyText(string invalidtext = " (invalid)")
        {
            string str3 = "";
            if (this.ModifierControl)
            {
                str3 = str3 + "CTRL + ";
            }
            if (this.ModifierAlt)
            {
                str3 = str3 + "ALT + ";
            }
            if (this.ModifierShift)
            {
                str3 = str3 + "SHIFT + ";
            }
            string expression = "";
            if ((this.key != Keys.None) & ((this.key < Keys.ShiftKey) | (this.key > Keys.Menu)))
            {
                expression = Enum.GetName(typeof(Keys), this.key);
                if ((expression.Length == 2) & (expression.Substring(0, 1) == "D"))
                {
                    expression = expression.Substring(1, 1);
                }
            }
            str3 = str3 + expression;
            if (!this.isValid)
            {
                str3 = str3 + invalidtext;
            }
            return str3;
        }

        public uint getModifierCode()
        {
            uint num2 = 0;
            if (this.ModifierAlt)
            {
                num2 |= 1;
            }
            if (this.ModifierControl)
            {
                num2 |= 2;
            }
            if (this.ModifierShift)
            {
                num2 |= 4;
            }
            return num2;
        }

        public void Reset()
        {
            this.ModifierAlt = false;
            this.ModifierShift = false;
            this.ModifierControl = false;
            this.key = Keys.None;
        }

        public override string ToString() =>
        this.getHotkeyText(" (invalid)");

        public bool isValid
        {
            get
            {
                if ((!this.ModifierAlt & !this.ModifierControl) & !this.ModifierShift)
                {
                    return false;
                }
                if ((this.key == Keys.None))
                {
                    return false;
                }
                if (!((this.key < Keys.ShiftKey) | (this.key > Keys.Menu)))
                {
                    return false;
                }
                return true;
            }
        }
    }

}



