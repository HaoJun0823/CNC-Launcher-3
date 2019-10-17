using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Ra3_Mod_Manager
{
    public static class Win32
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

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemoryBytes(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

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

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public override string ToString()
            {
                return ("X:" + X + ", Y:" + Y);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public uint Left;
            public uint Top;
            public uint Right;
            public uint Bottom;
            public override string ToString()
            {
                return ("Left:" + Left + ", Top:" + Top + ", Right:" + Right + ", Bottom:" + Bottom);
            }
        }

        [DllImport("user32")]
        public static extern bool GetClientRect(
        IntPtr hwnd,
        out RECT lpRect
        );
        /*
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);


        public class MouseHookStruct

        {

            public POINT pt;

            public int hwnd;

            public int wHitTestCode;

            public int dwExtraInfo;

        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        */
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, uint wParam, uint lParam);

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern int PostMessage(IntPtr hWnd, int Msg, Keys wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern UInt32 SendInput(UInt32 nInputs, Input[] pInputs, int cbSize);

        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(

         byte bVk,    

         byte bScan,

         int dwFlags,  

         int dwExtraInfo  

     );

        [StructLayout(LayoutKind.Explicit)]



        public struct Input
        {
            [FieldOffset(0)] public Int32 type;
            [FieldOffset(4)] public MouseInput mi;
            [FieldOffset(4)] public tagKEYBDINPUT ki;
            [FieldOffset(4)] public tagHARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public Int32 dx;
            public Int32 dy;
            public Int32 Mousedata;
            public Int32 dwFlag;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }



        [StructLayout(LayoutKind.Sequential)]
        public struct tagKEYBDINPUT
        {
            public Int16 wVk;
            public Int16 wScan;
            public Int32 dwFlags;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct tagHARDWAREINPUT
        {
            public Int32 uMsg;
            public Int16 wParamL;
            public Int16 wParamH;
        }

        [DllImport("kernel32.dll")]
        public static extern int VirtualAllocEx(IntPtr hwnd, Int32 lpaddress, int size, int type, Int32 tect);
        [DllImport("kernel32.dll")]
        public static extern Boolean WriteProcessMemory(IntPtr hwnd, int baseaddress, string buffer, int nsize, int filewriten);
        [DllImport("kernel32.dll")]
        public static extern int GetProcAddress(int hwnd, string lpname);
        [DllImport("kernel32.dll")]
        public static extern int GetProcAddress(IntPtr hwnd, string lpname);
        [DllImport("kernel32.dll")]
        public static extern int GetModuleHandleA(string name);
        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateRemoteThread(IntPtr hwnd, int attrib, int size, int address, int par, int flags, int threadid);
        [DllImport("kernel32.dll")]
        public static extern Int32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);
        [DllImport("kernel32.dll")]
        public static extern Boolean VirtualFree(IntPtr lpAddress, Int32 dwSize, Int32 dwFreeType);

    }
}
