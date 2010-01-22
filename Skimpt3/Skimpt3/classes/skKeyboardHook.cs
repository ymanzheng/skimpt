using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;


namespace Skimpt3.classes {
    public delegate void KeyboardEventHandler(KeyboardHookEventArgs keyboardEvents);

    public class skKeyboardHook {
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        public event KeyboardEventHandler KeyIntercepted;

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;

        public skKeyboardHook() {
            _proc = HookCallback;
            _hookID = SetHook(_proc);
        }
        public bool UnHookKey() {
            return UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc) {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule) {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN) {
                int vkCode = Marshal.ReadInt32(lParam);
                KeyboardHookEventArgs keyHookArgs = new KeyboardHookEventArgs(vkCode);
                KeyIntercepted(keyHookArgs);
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }

    public class KeyboardHookEventArgs : EventArgs {
        private Keys _pressedKey;
        private int _pressedKeyCode;

        public Keys PressedKey { get { return _pressedKey; } }
        public int PressedKeyCode { get { return _pressedKeyCode; } }

        public KeyboardHookEventArgs(int vkCode) {
            _pressedKey = (Keys)vkCode;
            _pressedKeyCode = vkCode;
        }
    }


    /// <summary> This class allows you to manage a hotkey </summary>
    public class GlobalHotkeys : IDisposable {
        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);
        [DllImport("user32", SetLastError = true)]
        public static extern int UnregisterHotKey(IntPtr hwnd, int id);
        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalAddAtom(string lpString);
        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalDeleteAtom(short nAtom);

        public const int MOD_ALT = 1;
        public const int MOD_CONTROL = 2;
        public const int MOD_SHIFT = 4;
        public const int MOD_WIN = 8;

        public const int WM_HOTKEY = 0x312;

        public GlobalHotkeys() {
            this.Handle = Process.GetCurrentProcess().Handle;
        }

        /// <summary> handle of the current process </summary>
        public IntPtr Handle;

        /// <summary> the ID for the hotkey </summary>
        public short HotkeyID {
            get;
            private set;
        }

        /// <summary> register the hotkey </summary>
        public void RegisterGlobalHotKey(int hotkey, int modifiers, IntPtr handle) {
            UnregisterGlobalHotKey();
            this.Handle = handle;
            RegisterGlobalHotKey(hotkey, modifiers);
        }

        /// <summary> register the hotkey </summary>
        public void RegisterGlobalHotKey(int hotkey, int modifiers) {
            UnregisterGlobalHotKey();

     
                string atomName = Thread.CurrentThread.ManagedThreadId.ToString("X8") + this.GetType().FullName;
                HotkeyID = GlobalAddAtom(atomName);
            
                   // register the hotkey, throw if any error
                if (!RegisterHotKey(this.Handle, HotkeyID, modifiers, (int)hotkey))
                    Console.WriteLine(Marshal.GetLastWin32Error().ToString());

         
        }

        /// <summary> unregister the hotkey </summary>
        public void UnregisterGlobalHotKey() {
            if (this.HotkeyID != 0) {
                UnregisterHotKey(this.Handle, HotkeyID);
                // clean up the atom list
                GlobalDeleteAtom(HotkeyID);
                HotkeyID = 0;
            }
        }

        public void Dispose() {
            UnregisterGlobalHotKey();
        }
    }


}
