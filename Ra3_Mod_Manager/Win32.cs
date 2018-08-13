using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ra3_Mod_Manager
{
    static class Win32
    {


        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll ", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

        [DllImportAttribute("kernel32.dll", EntryPoint = "ReadProcessMemory", SetLastError = true)]
        public static extern bool ReadProcessMemory
    (
        IntPtr hProcess,
        IntPtr lpBaseAddress,
        IntPtr lpBuffer,
        int nSize,
        IntPtr lpNumberOfBytesRead
    );

        [DllImportAttribute("kernel32.dll", EntryPoint = "WriteProcessMemory", SetLastError = true)]
        public static extern bool WriteProcessMemory
    (
        IntPtr hProcess,
        IntPtr lpBaseAddress,
        int[] lpBuffer,
        int nSize,
        IntPtr lpNumberOfBytesWritten
    );

        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess", SetLastError = true)]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void CloseHandle(IntPtr hObject);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetWindowsHookEx(
          int idHook,
          uint lpfn,
          IntPtr hInstance,
          int threadId
          );

        /*
        [DllImport("user32.dll") SetLastError = true]

        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);
        */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadLibrary(string lpFileName);






    } 
}
