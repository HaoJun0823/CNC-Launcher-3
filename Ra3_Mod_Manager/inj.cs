using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ra3_Mod_Manager
{
    class inj
    {



        public static void doinj()
        {

            
            Directory.CreateDirectory(Application.StartupPath+"\\Scripts");
            inject(Application.StartupPath + "\\Scripts");

            Directory.CreateDirectory(Config.dat_modpath + "\\Scripts");
            if (Config.dat_modpath != Application.StartupPath)
            {
                inject(Config.dat_modpath + "\\Scripts");
            }
            
        }


        public static void dohook()
        {


            Directory.CreateDirectory(Application.StartupPath + "\\Hooks\\");
                dllHook(Application.StartupPath + "\\Hooks\\");

            Directory.CreateDirectory(Config.dat_modpath + "\\Hooks\\");
            if (Config.dat_modpath != Application.StartupPath)
            {
                dllHook(Config.dat_modpath + "\\Hooks\\");
            }

        }



        public static void inject(String path)
        {

            if (Config.canInj)
            {




                String[] files = Directory.GetFiles(path, "*.e.txt",SearchOption.TopDirectoryOnly);
                Console.WriteLine("[Inject]Total Text Files:" + files.Length);

                foreach(var i in files)
                {
                    Console.WriteLine("[Inject]Inject Text:" + i);
                    injectText(i);
                }

            }

        }


        public static void injectText(String path)
        {

            Console.WriteLine("[Inject]Path:"+path);
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            String str;
            while((str = sr.ReadLine()) != null)
            {
                if (str.Length <= 0)
                {
                    continue;
                }

                if (str[0] == ';')
                {
                    Console.WriteLine("[Inject]Information:" + str.Substring(1));
                    continue;
                }

                String[] g = str.Split(',');

                if (g.Length % 2 != 1)
                {
                    Console.WriteLine("[Inject]Array can't be odd:" + g.Length);
                    continue;
                }

                if(!g[0].Equals("0") && !g[0].ToUpper().Equals(Config.md5.ToUpper()))
                {
                    Console.WriteLine("[Inject]Wrong MD5:" + g[0]);
                    continue;
                }


                for(int i = 1; i < g.Length; i++)
                {
                    Console.WriteLine("[Inject]Write Address:" + g[i]);
                    Console.WriteLine("[Inject]Write Data:" + g[i+1]);
                    injectWrite(g[i], g[++i]);
                }



            }


        }

        public static int readMemory(int address,int length)
        {
            try
            {
                Console.WriteLine("[Inject]Read Memory:"+address);
                byte[] buffer = new byte[length];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = Win32.OpenProcess(0x1F0FFF, false, Config.gameProcess.Id);
                if (Win32.ReadProcessMemory(hProcess, (IntPtr)address, byteAddress, 4, IntPtr.Zero)) {
                    
                        Console.WriteLine("[Inject]Success!");
                    }
            else
            {
                        Console.WriteLine("[Inject]Faild!");
                    }
                    Win32.CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }

           
        }


        public static void injectWrite(String address,String data)
        {
            int a = 0;
            if (address.IndexOf('+') != -1) {

                Console.WriteLine("[Inject]A Pointer:"+address);
                String[] pg = address.Split('+');
                a = Convert.ToInt32(pg[0], 16);
                Console.WriteLine("[Inject]Pointer Base:" + a);
                Console.WriteLine("[Inject]Pointer Offset Count:" + (pg.Length-1));
                a = readMemory(a,4);
                Console.WriteLine("[Inject]Pointer Offset Get:" + a);
                for (int i = 1; i < pg.Length; i++)
                {
                    int off = Convert.ToInt32(pg[i], 16);
                    
                    a += off;
                    Console.WriteLine("[Inject]Base Offset:" + a + "+" + off);


                    int temp = readMemory(a, 4);
                    Console.WriteLine("[Inject]Base Offset:" + a + "-->" + temp);
                    a = temp;
                }
                Console.Write("[Inject]Find Address Done.");


            }
            else { 
             a = Convert.ToInt32(address,16);
            }


            int[] d = new int[data.Length / 2];

            for(int i = 0; i < d.Length; i+=2)
            {
                d[i] = Convert.ToInt32(data.Substring(i,2),16);

            }

            IntPtr hprocess = Win32.OpenProcess(0x1f0fff, false, Config.gameProcess.Id);

            Console.WriteLine("[Inject]Prepare Write:" + hprocess + "," + address + "," + data + "," + d.Length+","+IntPtr.Zero);
            if (Win32.WriteProcessMemory(hprocess, (IntPtr)a, d, d.Length, IntPtr.Zero))
            {
                Console.WriteLine("[Inject]Success!");
            }
            else
            {
                Console.WriteLine("[Inject]Faild!");
            }

            Win32.CloseHandle(hprocess);

        }


        public static void dllHook(String path)
        {


            if (Config.canHook)
            {




                String[] files = Directory.GetFiles(path, "*.e.dll", SearchOption.TopDirectoryOnly);
                Console.WriteLine("[Hook]Target:" + path);
                Console.WriteLine("[Hook]Total Text Files:" + files.Length);

                foreach (var i in files)
                {
                    Console.WriteLine("[Hook]Hook Dll:" + i);




                    String[] p = Path.GetFileName(i).Split('.');

                    int max = p.Length - 2;
                    int lp = Convert.ToInt32(p[max - 1]);
                    uint id = Convert.ToUInt32(p[max - 2]);


                    Console.WriteLine("[Hook]Hook id:" + lp);
                    Console.WriteLine("[Hook]Loop back:" + id);


                    var lib = Win32.LoadLibrary(i);
                    
                    
                        Console.WriteLine("[Hook]LoadLibrary Return:" + lib);

                    if ((int)lib == 0) { 
                    Console.WriteLine("[Hook]Last Error:"+(Convert.ToInt32(Win32.GetLastError())));
                    }


                    while (Config.gameProcess.MainWindowHandle == IntPtr.Zero)
                    {
                        Config.gameProcess.Refresh();
                        Thread.Sleep(1000);
                        Console.WriteLine("Waiting Game Create Window:" + Config.gameProcess.MainWindowHandle);
                    }

                    int re = Win32.SetWindowsHookEx(lp, id, lib, (int)Config.gameProcess.MainWindowHandle);
                     Console.WriteLine("[Hook]SetWindowsHookEx Return:"+re);

                    if ((int)re == 0)
                    {
                        Console.WriteLine("[Hook]Last Error:" + (Convert.ToInt32(Win32.GetLastError())));
                    }


                    Console.WriteLine("[Hook]Hook:" +lp+","+id+","+lib+","+Config.gameProcess.MainWindowHandle );


                }

            }



        }


    }





}
