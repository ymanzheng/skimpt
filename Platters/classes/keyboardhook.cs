#region "License Agreement"
/* Skimpt, an open source screenshot utility.
      Copyright (C) <year>  <name of author>

      This program is free software: you can redistribute it and/or modify
      it under the terms of the GNU General Public License as published by
      the Free Software Foundation, either version 3 of the License, or
      (at your option) any later version.

      this program is distributed in the hope that it will be useful,
      but WITHOUT ANY WARRANTY; without even the implied warranty of
      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      GNU General Public License for more details.

      You should have received a copy of the GNU General Public License
      along with this program.  If not, see <http://www.gnu.org/licenses/>. */
#endregion
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;


public delegate void KeyboardHookCaptureHandler(KeyboardHookEventArgs keyboardEvents);

public class KeyboardHookEventArgs : EventArgs
{
    private Keys _pressedKey;
    private int _pressedKeyCode;
    public Keys PressedKey
    {        
        get
        {
            return _pressedKey;
        }
    }

    public int PressedKeyCode
    {
        get
        {
            return _pressedKeyCode;
        }
    }
    public KeyboardHookEventArgs(int vkCode)
    {
        _pressedKey = (Keys)vkCode;
        _pressedKeyCode = vkCode;
    }
}

public class KeyboardHook
{
    public event KeyboardHookCaptureHandler KeyIntercepted;

    private delegate IntPtr LowLevelKeyboardProc(
        int nCode, IntPtr wParam, IntPtr lParam);
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private LowLevelKeyboardProc _proc;
    private IntPtr _hookID = IntPtr.Zero;

    public KeyboardHook()
    {
         _proc = HookCallback;
         _hookID = SetHook(_proc);
    }
    public bool UnHookKey()
    {
        return UnhookWindowsHookEx(_hookID);
    }

    private IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                GetModuleHandle(curModule.ModuleName), 0);
        }
    }

  

    private IntPtr HookCallback(
        int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            //Console.WriteLine((Keys)vkCode);
            KeyboardHookEventArgs keyHook = new KeyboardHookEventArgs(vkCode);
            KeyIntercepted(keyHook);                        
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
        IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
}
