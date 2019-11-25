using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Ra3_Mod_Manager
{
    static class Game
    {
        public static String timeStamp = DateTime.Now.ToString("yyyymmddhhmmss");
        private static StreamWriter memSW;
        private static FileStream memFS;
        private static System.Timers.Timer memT;
        private static int memN = 0;
        private static StreamReader pesr;
        private static StreamWriter pisw;
        private static StreamReader posr;


        public static void doGameAction()
        {
            
            //Config.gameProcess.WaitForInputIdle();

            if (Config.dat_bfs) {
                noBorder();
            }



            if (Config.isDebug)
            {



                writeMemoryInformation();
                /*
                StringDictionary sd = Config.gameProcess.StartInfo.EnvironmentVariables;
                Console.WriteLine("Environment Data:"+sd.Count);
                
                foreach(DictionaryEntry i in sd)
                {
                    Console.WriteLine("Key:" + i.Key+" Value:"+i.Value);

                }

                Environment.SetEnvironmentVariable("appdata",Environment.GetEnvironmentVariable("appdata")+";"+ Application.StartupPath);
            }

            if (Config.isDevloper) { waitGameClose(); }

                */


            }


            //Extra.doExtra(); 
            if (Config.dat_bfs && (Config.dat_mouse_locked || Config.dat_mouse_dynamic))
            {
                Extra.doExtra();

            }
            else
            {
                Console.WriteLine("Pass Extra!");
            }


            if (Config.isDevloper) {


                try
                {
                    waitGameClose();
                    
                    foreach(System.Timers.Timer t in inj.TimerGroup)
                    {
                        t.Stop();
                    }

                    inj.TimerGroup = new List<System.Timers.Timer>();
                    Console.WriteLine("[Inject]:Clean Timer Group");
                    GC.Collect();

                }
                catch(Exception e)
                {

                    Console.WriteLine("Excpetion Waiting game close:" + e.ToString());

                }



            }



        }

        private static void noBorder()
        {

            Console.WriteLine("Get Game Process:" + Config.gameProcess.ProcessName);
            while (Config.gameProcess.MainWindowHandle == IntPtr.Zero)
            {
                Config.gameProcess.Refresh();
                Thread.Sleep(1000);
                Console.WriteLine("Waiting Game Create Window:" + Config.gameProcess.MainWindowHandle);
            }
            IntPtr win = Config.gameProcess.MainWindowHandle;
            var style = Win32.GetWindowLong(win, -16);
            var estyle = Win32.GetWindowLong(win, -20);


            var styleN = style & ~(0x00800000 | 0x00400000 | 0x00040000 | 0x00080000 | 0x00020000 | 0x00010000);
            var estyleN = estyle & ~(0x00000001 | 0x02000000 | 0x00000100 | 0x00000200 | 0x00080000 | 0x00020000 | 0x00000080 | 0x00040000);
            Win32.SetWindowLong(win, -16, styleN);
            Win32.SetWindowLong(win, -20, estyleN);



            Console.WriteLine("Desktop Width:" + System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width);
            Console.WriteLine("Desktop Height:" + System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);



            Win32.MoveWindow(win, 0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height, true);

            Win32.ShowWindow(win, 5);
            Win32.SetForegroundWindow(win);




        }

        private static void waitGameClose()
        {




            try { 

            Config.gameProcess.WaitForExit();

           
            





            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Waiting Game Process Or Extra:" + e.ToString());
            }
            finally
            {
                Extra.timer.Change(-1, 0);
                Extra.timer = null;

                if (Config.mainController.WindowState == FormWindowState.Minimized)
                {
                    Config.mainController.WindowState = FormWindowState.Normal;
                    Console.WriteLine("Make Controller Form to Normal.");
                }
                else
                {
                    Console.WriteLine("Controller Form was Normal.");
                }
                /*
                if (!Config.mainController.Visible)
                {
                    Config.mainController.Visible = true;
                    Console.WriteLine("Change Controller Form Visible.");
                }
                else
                {
                    Console.WriteLine("Not Change Controller Form Visible.");
                }
                */

            }


            try
            {

                memSW.Close();
                memT.Stop();
                
                memT.Close();
                memT.Dispose();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception Stream:" + e.ToString());
            }

            Config.timeStamp = DateTime.Now.ToString("yyyymmddhhmmss");
            timeStamp = DateTime.Now.ToString("yyyymmddhhmmss");

            Console.WriteLine("New TimeStamp:" + timeStamp);

            Config.mainController.WindowState = System.Windows.Forms.FormWindowState.Normal;

            Config.mainController.refreshResource();

        }





        private static void writeMemoryInformation()
        {

         pesr = Config.gameProcess.StandardError;
         pisw =Config.gameProcess.StandardInput;
         posr =Config.gameProcess.StandardOutput;


        Directory.CreateDirectory(Application.StartupPath + "\\Ra3_Mod_Manager.Debug\\" + timeStamp);
            Directory.CreateDirectory(Application.StartupPath + "\\Ra3_Mod_Manager.Debug\\" + timeStamp+ "\\Snapshot");
            memFS = new FileStream(Application.StartupPath + "\\Ra3_Mod_Manager.Debug\\" + timeStamp + "\\Memory.csv", FileMode.Create);
            memSW = new StreamWriter(memFS);
            Console.WriteLine("Create New Memory CSV:" + Application.StartupPath + "\\Ra3_Mod_Manager." + timeStamp + ".csv");
            /*
            StringBuilder sb = new StringBuilder();
            
            sb.Append("BasePriportiy,");
            sb.Append(Config.gameProcess.BasePriority);
            */

            String str = "Id,TotalProcessorTime,PrivateMemorySize64,PagedSystemMemorySize64,NonpagedSystemMemorySize64,PagedMemorySize64,PeakPagedMemorySize64,VirtualMemorySize64,PeakVirtualMemorySize64,WorkingSet64,PeakWorkingSet64";
            Console.WriteLine("[CSV]" + str);
            memSW.BaseStream.Seek(0, SeekOrigin.End);
            memSW.WriteLine(str);
            memSW.Flush();

            /*
            StringBuilder sb = new StringBuilder();
            Process p = Config.gameProcess;
            sb.Append(memN);
            sb.Append(',');
            sb.Append(p.TotalProcessorTime);
            sb.Append(',');
            sb.Append(p.PrivateMemorySize64);
            sb.Append(',');
            sb.Append(p.PagedSystemMemorySize64);
            sb.Append(',');
            sb.Append(p.NonpagedSystemMemorySize64);
            sb.Append(',');
            sb.Append(p.PagedMemorySize64);
            sb.Append(',');
            sb.Append(p.PeakPagedMemorySize64);
            sb.Append(',');
            sb.Append(p.VirtualMemorySize64);
            sb.Append(',');
            sb.Append(p.PeakVirtualMemorySize64);
            sb.Append(',');
            sb.Append(p.WorkingSet64);
            sb.Append(',');
            sb.Append(p.PeakWorkingSet64);
            sb.Append(',');
            Console.WriteLine("[CSV]" + sb.ToString());
            memSW.WriteLine(sb.ToString());
            memSW.Flush();
            */
            memT = new System.Timers.Timer();

            memT.Enabled = true;
            memT.Interval = 1000 * 30;

            memT.Elapsed += new System.Timers.ElapsedEventHandler(writeMemoryInformationData);
            writeMemoryInformationData(null, null);
            memT.Start();

            

        }


        private static void writeMemoryInformationData(object source,ElapsedEventArgs e)
        {
            //Console.WriteLine("Writing Debug Information...");

           new Thread(delegate(){
            
                //Console.WriteLine("Start New Debug Information Thread.");


                try
                {


                    Process p = Config.gameProcess;
                    p.Refresh();


                    StringBuilder sb = new StringBuilder();

                    sb.Append(memN);
                    sb.Append(',');
                    sb.Append(p.TotalProcessorTime);
                    sb.Append(',');
                    sb.Append(p.PrivateMemorySize64);
                    sb.Append(',');
                    sb.Append(p.PagedSystemMemorySize64);
                    sb.Append(',');
                    sb.Append(p.NonpagedSystemMemorySize64);
                    sb.Append(',');
                    sb.Append(p.PagedMemorySize64);
                    sb.Append(',');
                    sb.Append(p.PeakPagedMemorySize64);
                    sb.Append(',');
                    sb.Append(p.VirtualMemorySize64);
                    sb.Append(',');
                    sb.Append(p.PeakVirtualMemorySize64);
                    sb.Append(',');
                    sb.Append(p.WorkingSet64);
                    sb.Append(',');
                    sb.Append(p.PeakWorkingSet64);
                    sb.Append(',');


                    


                    Image image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    Graphics g = Graphics.FromImage(image);
                    g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.PrimaryScreen.Bounds.Size);
                    g.Dispose();

                    


                    
                    Console.WriteLine("[CSV]" + sb.ToString());
                    memSW.WriteLine(sb.ToString());
                    memSW.Flush();
                    image.Save(Application.StartupPath + "\\Ra3_Mod_Manager.Debug\\" + timeStamp + "\\Snapshot\\" + memN + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    image.Dispose();



                }
                catch (Exception exc) { Console.WriteLine("Exception CSV Thread Loop:"+exc); /*MessageBox.Show(exc.ToString(), loc.in_execption[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)*/; }
                finally
                {

                    memN++;




                }



            }).Start();

            /*
            new Thread(delegate ()
            {
                try
                {
                    FileStream fs = new FileStream(Application.StartupPath + "\\Ra3_Mod_Manager.Debug\\" + timeStamp + "\\output.log", FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);

                    String s;

                    s = posr.ReadToEnd();

                    memSW.WriteLine(s);
                    memSW.Flush();

                    sw.Dispose();
                    sw.Close();
                    fs.Dispose();
                    fs.Close();

                    s = pesr.ReadToEnd();

                    fs = new FileStream(Application.StartupPath + "\\Ra3_Mod_Manager.Debug\\" + timeStamp + "\\error.log", FileMode.Append);
                    sw = new StreamWriter(fs);



                    memSW.WriteLine(s);
                    memSW.Flush();



                    sw.Dispose();
                    sw.Close();
                    fs.Dispose();
                    fs.Close();

                }catch(Exception exc)
                {
                    { Console.WriteLine("Exception Exe Log Thread Loop:" + exc); MessageBox.Show(exc.ToString(), loc.in_execption[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); }

                }

            }).Start();
            */


        }


    }



}
