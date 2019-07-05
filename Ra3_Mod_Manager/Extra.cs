using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Ra3_Mod_Manager
{
    public class Extra
    {
        public static System.Threading.Timer timer;
        public static int padding = 50;
        //static MouseHook mh;




            /*
        static void mh_MouseMoveEvent(object sender, MouseEventArgs e)

        {

            int x = e.Location.X;

            int y = e.Location.Y;

            Console.WriteLine(string.Format("当前鼠标位置为：（{0}，{1}）", x, y));
           

        }
        */


        public static void doExtra()
        {
            

            Console.WriteLine("Do Extra!");

            /*

            try { 

            mh = new MouseHook();

            mh.SetHook();

            mh.MouseMoveEvent += mh_MouseMoveEvent;
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, loc.con_title[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
            
            （/










            /*
        hProc = new Win32.HookProc(MouseHookProc);

        hHook = Win32.SetWindowsHookEx(WH_MOUSE_LL, WH_MOUSE, IntPtr.Zero, 0);

        MouseMoveEvent += mh_MouseMoveEvent;
        */

            
            Console.WriteLine("Starting Game Timer!");

            
            timer = new System.Threading.Timer(delegate
            {
                IntPtr currentPtr = Win32.GetForegroundWindow();
               // Console.WriteLine("currentPtr:" + currentPtr);
                if (currentPtr == Config.gameProcess.MainWindowHandle)
                {
                  Win32.POINT p = new Win32.POINT();
                  Win32.RECT rect = new Win32.RECT();
        
                  //Console.WriteLine("Get Point:");
                  Win32.GetCursorPos(out p);
                  Win32.GetClientRect(currentPtr,out rect);
                  Console.WriteLine("Mouse Point:"+p.ToString());
                  Console.WriteLine("Game Rect:" + rect.ToString());

                    if (p.X < rect.Left || p.Y < rect.Top || p.X>rect.Right || p.Y > rect.Bottom)
                    {
                    Console.WriteLine("Mouse out window!" + p.ToString() + "|"+rect.ToString());
                    }
                    else
                    {
                        /*
                        Win32.Input[] input= new Win32.Input[1];
                        input[0] = new Win32.Input();
                        input[0].type = 1;
                        input[0].ki.dwFlags = 0x0002;
                        input[0].ki.wVk = 0x26;
                        */


                        Console.Write("Press VK_KEY:");
                        if (p.X - padding <= rect.Left) { ; Console.Write("LEFT:"+ Win32.PostMessage(currentPtr, 256, Keys.Left, 10)+" "); /*Win32.SendInput(1, input, Marshal.SizeOf(input));*/ SendKeys.SendWait("{LEFT}"); }
                        if (p.X + padding >= rect.Right) { ; Console.Write("RIGHT:" + Win32.PostMessage(currentPtr, 256, Keys.Right, 10) + " "); SendKeys.SendWait("{RIGHT}"); }
                        if (p.Y - padding <= rect.Top) { ; Console.Write("UP:" + Win32.PostMessage(currentPtr, 256, Keys.Up, 10) + " "); SendKeys.SendWait("{UP}"); }
                        if (p.Y + padding >= rect.Bottom) { ; Console.Write("DOWN:" + Win32.PostMessage(currentPtr, 256, Keys.Down, 10) + " "); SendKeys.SendWait("{DOWN}"); }
                        Console.Write("\n");
                    }


                }
                else
                {
                    Console.WriteLine("Not In Game!");
                }



            }, null, 0, 100);

        

        }
    }
    /*
    void mh_MouseMoveEvent(object sender, MouseEventArgs e)

    {

        int x = e.Location.X;

        int y = e.Location.Y;

       Console.WriteLine(string.Format("当前鼠标位置为：（{0}，{1}）", x, y));

    }


    private static int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {

            Win32.MouseHookStruct MyMouseHookStruct = (Win32.MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(Win32.MouseHookStruct));

            if (nCode < 0)

            {

                return Win32.CallNextHookEx(hHook, nCode, wParam, lParam);

            }

            else

            {

                point = new Win32.POINT(MyMouseHookStruct.pt.X, MyMouseHookStruct.pt.Y);

                return Win32.CallNextHookEx(hHook, nCode, wParam, lParam);

            }

        }





}

*/
/*
    public class MouseHook

    {

        public delegate void MouseMoveHandler(object sender, MouseEventArgs e);

        public event MouseMoveHandler MouseMoveEvent;



        private Point point;

        private Point Point

        {

            get { return point; }

            set

            {

                if (point != value)

                {

                    point = value;

                    if (MouseMoveEvent != null)

                    {

                        var e = new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0);

                        MouseMoveEvent(this, e);

                    }

                }

            }

        }

        private int hHook;

        public const int WH_MOUSE_LL = 14;

        public Win32.HookProc hProc;

        public MouseHook() { this.Point = new Point(); }

        public int SetHook()

        {

            hProc = new Win32.HookProc(MouseHookProc);

            hHook = Win32.SetWindowsHookEx(WH_MOUSE_LL, hProc, IntPtr.Zero, 0);

            return hHook;

        }

        public void UnHook()

        {

            Win32.UnhookWindowsHookEx(hHook);

        }

        private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)

        {

            Win32.MouseHookStruct MyMouseHookStruct = (Win32.MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(Win32.MouseHookStruct));

            if (nCode < 0)

            {

                return Win32.CallNextHookEx(hHook, nCode, wParam, lParam);

            }

            else

            {

                this.Point = new Point(MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y);

                return Win32.CallNextHookEx(hHook, nCode, wParam, lParam);

            }

        }

        

    }
    */

}
