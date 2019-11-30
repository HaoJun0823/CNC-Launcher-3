using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CNCLauncher
{
    class inj
    {

        public static List<System.Timers.Timer> TimerGroup = new List<System.Timers.Timer>();

        public static void doinj()
        {

            
            Directory.CreateDirectory(Config.workPath+"\\Plugins\\Memory");
            inject(Config.workPath + "\\Plugins\\Memory");

            if (!Config.dat_modpath.Equals(Config.workPath + "\\Theme")) { 

            Directory.CreateDirectory(Config.dat_modpath + "\\Plugins\\Memory");
            }
            if (Config.dat_modpath != Config.workPath && !Config.dat_modpath.Equals(Config.workPath + "\\Theme"))
            {
                inject(Config.dat_modpath + "\\Plugins\\Memory");
            }
            
        }


        public static void dohook()
        {


            Directory.CreateDirectory(Config.workPath + "\\Plugins\\Library");
                dllHook(Config.workPath + "\\Plugins\\Library");

            Directory.CreateDirectory(Config.dat_modpath + "\\Plugins\\Library");
            if (Config.dat_modpath != Config.workPath)
            {
                dllHook(Config.dat_modpath + "\\Plugins\\Library");
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
                    try { 
                    injectText(i);
                    }catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

            }

        }


        public static void injectText(String path)
        {

            Console.WriteLine("[Inject]Path:"+path);
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            String str;
            int loop = 0;
            int line = 0;
            while((str = sr.ReadLine()) != null)
            {
                line++;
                Console.WriteLine("[Inject]Get Line "+line +":" + str);
                if (str.Length <= 0)
                {
                    Console.WriteLine("[Inject]Null Line On:" + line);
                    continue;
                }




                //Console.WriteLine("[Inject]Debug Line " + line + ":" + str);
                if (str[0] == ';')
                {
                    Console.WriteLine("[Inject]Information:" + str.Substring(1));
                    continue;
                }

                if (str[0] == 'T')
                {
                    String t = str.Substring(1);
                    Console.WriteLine("[Inject]Get Timer Value:" + t);
                    loop = Convert.ToInt32(t);
                    Console.WriteLine("[Inject]Loop Timer:" + loop);
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
                    
                    if (loop != 0)
                    {
                        string address = g[i];
                        string offset = g[i + 1];
                        Console.WriteLine("[Inject]Create Timer From " + path+" Do Loop "+loop+".");
                        /*
                        Thread t = new Thread(delegate() {

                            Console.WriteLine("[Inject]Timer:"+ " Write Address: " + address+ " Write Data: " + offset);
                            injectWrite(address,offset);
                            Thread.Sleep(loop * 1000);

                        });
                        t.Start();
                        



                        */


                        System.Timers.Timer t = new System.Timers.Timer();
                        t.Interval = loop * 1000;
                        t.AutoReset = true;
                        t.Enabled = true;
                        t.Elapsed += (o, a) => {

                            Console.WriteLine("[Inject]Timer:" + " Write Address: " + address + " Write Data: " + offset);
                            injectWrite(address, offset);

                        };
                        t.Start();
                        TimerGroup.Add(t);

                        i++;
                    }
                    else { 
                        injectWrite(g[i], g[++i]);
                    }
                }



            }
            Console.WriteLine("[Inject]End " + path + " Total line:"+ line);


        }

        public static int readMemory(int address,int length)
        {
            try
            {
                Console.WriteLine("[Inject]Read Memory:"+address);
                byte[] buffer = new byte[length];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); 
                IntPtr hProcess = Win32.OpenProcess(0x1F0FFF, false, Config.gameProcess.Id);
                if (Win32.ReadProcessMemory(hProcess, (IntPtr)address, byteAddress, 4, IntPtr.Zero)) {
                    
                        Console.WriteLine("[Inject]Read Success!");
                    }
            else
            {
                        Console.WriteLine("[Inject]Read Faild!");
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
                //a = readMemory(a,4);

                //Console.WriteLine("[Inject]Pointer Offset Get:" + a);
                for (int i = 1; i < pg.Length; i++)
                {
                    Console.WriteLine("[Inject]Read Memory Address Value:" + a);
                    a = readMemory(a, pg[0].Length/2);
                    int off = Convert.ToInt32(pg[i], 16);
                    
                    
                    Console.WriteLine("[Inject]Base Offset:" + a + "-->" + off + "|HEX:" + Convert.ToString(a,16) + "-->" + Convert.ToString(off,16));
                    a += off;

                    Console.WriteLine("[Inject]Read Offset Memory:" + a + "|HEX:" + Convert.ToString(a, 16));
                    //readMemory(a, 4);
                    //a = temp;
                }
                Console.WriteLine("[Inject]Find Address Done.");


            }
            else { 
             a = Convert.ToInt32(address,16);
            }

            Console.WriteLine("[Inject]Start Write Method:");
            int[] d = new int[data.Length / 2];

            for(int i = 0; i < d.Length; i++)
            {
                d[i] = Convert.ToInt32(data.Substring(i*2,2),16);
                Console.Write(i + "=DEC:" + d[i] + "-HEX:" + Convert.ToString(d[i], 16) + ",");
                
            }
            Console.WriteLine(" That's All");
            int decD = Convert.ToInt32(data,16);
            Console.WriteLine("[Inject]Get Write Data Decmial:" + decD);
            IntPtr hprocess = Win32.OpenProcess(0x1f0fff, false, Config.gameProcess.Id);

            Console.WriteLine("[Inject]Get Prepare Write Memory:"+ Convert.ToString(a, 16));
            int memData = readMemory(a,d.Length);
            Console.WriteLine("[Inject]Address:" + Convert.ToString(a, 16) + "|Data:" +memData+"|HEX:"+Convert.ToString(memData,16));
            Console.WriteLine("[Inject]Prepare Write:" + hprocess + "," + address + "," + data + "," + d.Length+","+IntPtr.Zero);
           
            //byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(data,10));
            byte[] bytes = new byte[] { (byte)decD};
            
            int outer = 0;
            int[] temp = { 114514 };
            //if (Win32.WriteProcessMemoryBytes(hprocess, (IntPtr)a, bytes, (UInt32)bytes.LongLength, out outer))
            //if (Win32.WriteProcessMemory(hprocess, (IntPtr)a,temp, d.Length, out outer))
            if (Win32.WriteProcessMemory(hprocess, (IntPtr)a, temp, d.Length, IntPtr.Zero))
            {
                Console.WriteLine("[Inject]Write Success!Outer:"+outer);
            }
            else
            {
                Console.WriteLine("[Inject]Write Faild!Outer:" + outer);
            }

            Win32.CloseHandle(hprocess);

        }

        /*
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
        */

        public static void dllHook(String path)
        {


            if (Config.canHook)
            {
                while (Config.gameProcess.MainWindowHandle == IntPtr.Zero)
                {
                    Config.gameProcess.Refresh();
                    Thread.Sleep(1000);
                    Console.WriteLine("Waiting Game Create Window:" + Config.gameProcess.MainWindowHandle);
                }


                //ProcessModuleCollection pmodule = Config.gameProcess.Modules;
                //foreach (ProcessModule processm in pmodule)
                //{
                 //   Console.WriteLine("Get dll Address:"+processm.FileName+"|"+processm.ModuleName);
                //}

                String[] files = Directory.GetFiles(path, "*.e.dll", SearchOption.TopDirectoryOnly);
                Console.WriteLine("[Hook]Target:" + path);
                Console.WriteLine("[Hook]Total Dll Files:" + files.Length);
                IntPtr hwnd = Win32.OpenProcess(0x1F0FFF, false, Config.gameProcess.Id);
                foreach (var i in files)
                {
                    Console.WriteLine("[Hook]Hook Dll:" + i);
                    //string dllname = Path.GetFileName(i);
                    string dllname = i;//dllname.Substring(0,dllname.Length-6);
                    Console.WriteLine("[Hook]Dll Name:" + dllname);

                   

                    //IntPtr hwnd = Config.gameProcess.MainWindowHandle;

                    String[] p = Path.GetFileName(i).Split('.');
                    
                    
                    Int32 AllocBaseAddress = Win32.VirtualAllocEx(hwnd, 0, dllname.Length + 1, 0x1000 + 0x2000, 0x40);

                    Console.WriteLine("[Hook]Virtual Alloc:" + AllocBaseAddress);
                    if (AllocBaseAddress == 0)
                    {
                        Console.WriteLine("[Hook]Virtual Alloc Faild!");
                        continue;
                    }



                    if(Win32.WriteProcessMemory(hwnd,AllocBaseAddress,dllname,dllname.Length +1, 0))
                    {
                        Console.WriteLine("[Hook]Write Address to Memory Success!");
                    }
                    else
                    {
                        Console.WriteLine("[Hook]Write Address to Memory Faild!");
                        continue;
                    }
                    
                    Int32 loadAddress = Win32.GetProcAddress(Win32.LoadLibrary("kernel32.dll"), "LoadLibraryA");
                    Console.WriteLine("[Hook]Load Address:" + loadAddress);

                    if (loadAddress == 0)
                    {
                        Console.WriteLine("[Hook]Process Address Faild!");
                        continue;
                    }



                    IntPtr ThreadHwnd = Win32.CreateRemoteThread(hwnd,0,0,loadAddress,AllocBaseAddress,0,0);

                    Console.WriteLine("[Hook]Thread Process:" + ThreadHwnd);

                    if (ThreadHwnd == IntPtr.Zero)
                    {
                        Console.WriteLine("[Hook]Thread Process Faild!");
                        continue;
                    }

                    Win32.WaitForSingleObject(ThreadHwnd, 0xFFFFFFFF);
                    Win32.VirtualFree(hwnd,0, 0x8000);
                    Console.WriteLine("[Hook]Done:"+dllname);

                }

                ProcessModuleCollection pmodule = Config.gameProcess.Modules;
                foreach (ProcessModule processm in pmodule)
               {
                   Console.WriteLine("Get dll Address:"+processm.FileName+"|"+processm.ModuleName);
               }

            }



        }



    }





}
