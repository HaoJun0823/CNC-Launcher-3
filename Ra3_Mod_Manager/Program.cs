using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Reflection;

namespace Ra3_Mod_Manager
{


    static class Program
    {

        public static Mutex mutex;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Banner.Print();


            Console.WriteLine("String Args Number:" + args.Length);
            

            for (int i = 0; i < args.Length; i++)
            {

                Console.WriteLine("String Args Content:" + args[i].ToString());
                Console.WriteLine("Running by:");

                if (args[i].Trim().ToLower().IndexOf("-help") != -1 || args[i].Trim().ToLower().IndexOf("/?") != -1)
                {
                    Console.WriteLine(" -help or /?");
                    //String data = "-help or /?:Message This Help.\n-ui:Open This Control Panel.\n-debug:Enable Debug Mode When Game Start.\n-script:Inject Data From \\Scripts.\n-skip:Skip Splash.\n-hook:Hook Dll From \\Hooks.\n-dat:Load Dat From \\Custom.dat.";
                    String data = "-help or /?:Message This Help.\n-ui:Open This Control Panel.\n-debug:Enable Debug Mode When Game Start.\n-skip:Skip Splash.\n-dat:Load Dat From \\Custom.dat.\n-mod:use -mod+{Directory Name} to load unique mod, must be in application's directory.\n-clean clean your current config(not contain custom dat).";
                    //Console.WriteLine(data);
                    MessageBox.Show(data, "Can Use:", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    System.Environment.Exit(0);
                    continue;
                }

                if (args[i].Trim().ToLower().IndexOf("-ui") != -1)
                {
                    Console.WriteLine(" -ui");
                    Config.isDevloper = true;
                    continue;
                }

                if (args[i].Trim().ToLower().IndexOf("-debug") != -1)
                {
                    Console.WriteLine(" -debug");
                    Config.isDebug = true;
                    Config.isDevloper = true;
                    Config.extraTitle += "DEBUG:";
                    continue;
                }



                //if (args[i].Trim().ToLower().IndexOf("-script") != -1)
                //{
                //    Console.WriteLine(" -script");
                //    Config.canInj = true;
                //    Config.extraTitle += "SCRIPT:";
                //    continue;
                //}

                if (args[i].Trim().ToLower().IndexOf("-skip") != -1)
                {
                    Console.WriteLine(" -skip");
                    Config.canSkip = true;
                    Config.extraTitle += "SKIP:";
                    continue;
                }

                if (args[i].Trim().ToLower().IndexOf("-clean") != -1)
                {
                    Console.WriteLine(" -clean");
                    if (File.Exists(Application.StartupPath + "\\" + "ra3_mod_manager.dat"))
                    {
                        Console.WriteLine("Clean:" + Application.StartupPath + "\\" + "ra3_mod_manager.dat");
                        File.Delete(Application.StartupPath + "\\" + "ra3_mod_manager.dat");
                    }
                    continue;
                }

                if (args[i].Trim().ToLower().IndexOf("-dat") != -1)
                {
                    String temp = args[i].Trim().ToLower();
                    Console.WriteLine(" -dat");
                    Config.customDat = temp.Substring(temp.IndexOf("-dat") + 4, 10);
                    //Config.extraTitle += "DAT:";
                    continue;
                }

                if (args[i].Trim().ToLower().IndexOf("-dat") != -1)
                {
                    String temp = args[i].Trim().ToLower();
                    Console.WriteLine(" -dat");
                    Config.customDat = temp.Substring(temp.IndexOf("-dat") + 4, 10);
                    //Config.extraTitle += "DAT:";
                    continue;
                }

                if (args[i].Trim().ToLower().IndexOf("-mod") != -1)
                {
                    String temp = args[i].Trim().ToLower();
                    Console.WriteLine(" -mod");
                    String[] str = temp.Split('+');
                    
                    if (string.IsNullOrEmpty(str[1]))
                    {
                        
                        
                        MessageBox.Show("?:"+temp,"?",MessageBoxButtons.OK,MessageBoxIcon.Error);

                    }
                    else {
                        String path = Application.StartupPath+"\\" + str[1];
                        if (!Directory.Exists(path))
                        {
                            MessageBox.Show("?:" + path, "?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else { 

                    Console.WriteLine("-mod:"+str[1]);
                    Config.commandmodname = str[1];
                        }
                    }
                    //Config.extraTitle += "DAT:";
                    continue;
                }


                //if (args[i].Trim().ToLower().IndexOf("-hook") != -1)
                //{
                // Console.WriteLine(" -hook");
                //     Config.canHook = true;
                //    Config.extraTitle += "HOOK:";
                //    continue;
                // }

                Console.WriteLine("");


            }

            bool isRunning;
            mutex = new Mutex(true, Process.GetCurrentProcess().ProcessName,out isRunning);
            Console.WriteLine("Check Same:" + Process.GetCurrentProcess().ProcessName);
            //if (!mutex.WaitOne(0,false))
              if (!isRunning)
            {
                MessageBox.Show(loc.in_running[loc.current], loc.con_title[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,MessageBoxOptions.ServiceNotification);
                Mutex.OpenExisting(Process.GetCurrentProcess().ProcessName);
                //Config.mainController.ShowDialog();

                if (Config.customDat ==null) {
                    Config.readDAT(Application.StartupPath + "\\" + Config.configFile);
                }
                else
                {
                    Config.readDAT(Application.StartupPath + "\\Custom.dat\\" + Config.customDat+".dat");
                }


                
                Environment.Exit(0);
            }


            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;


            Initialization();






            //if (Config.isDevloper) { 
            Console.WriteLine("Quickly Check:"+Config.modPath+"\\"+Config.dat_version+".skudef");
            if (!File.Exists(Config.modPath + "\\" + Config.dat_version + ".skudef") || Config.isFirstTime || Config.isDevloper || !File.Exists(Application.StartupPath + "\\"+Config.configFile) || !checkGameVaild()) {
                Config.mainController = new Controller();
                Application.Run(Config.mainController);
            }
            else
            {
                Controller.printText();

                startGameByProcessQuickly();
                if (!Config.canSkip) { 
                Application.Run(new Splash_Form());
                }
            }
        }

        public static bool checkGameVaild()
        {

            if(Config.dat_game == "Uprising")
            {
                return true;
            }

            if (Config.dat_game == "Red Alert 3")
            {
                return true;
            }

            if (!Directory.Exists(Config.dat_modpath))
            {

                MessageBox.Show(loc.check_vaild_description[loc.current]+"\n"+ Config.dat_modpath, loc.check_vaild_title[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
               


            return true;

        }

        public static void  popDesc()
        {

            if (Config.dat_game== "Uprising" || Config.dat_game == "Red Alert 3")
            {

                return ;
            }

            
            if (File.Exists(Config.modPath+"\\launcher\\web\\introduce.html") && File.Exists(Config.modPath+ "\\launcher\\web\\always.txt")) {
                Console.WriteLine("Always Extra Panel!");
                Description form_desc = new Description();
                form_desc.needChecked = true;

                if (File.Exists(Config.modPath + "\\launcher\\web\\"+loc.infcode[loc.current]+ "\\introduce.html"))
                {
                    form_desc.address = Config.modPath + "\\launcher\\web\\" + loc.infcode[loc.current] + "\\introduce.html";
                }

                form_desc.address = Config.modPath + "\\launcher\\web\\introduce.html";
                DialogResult dr = MessageBox.Show(loc.open_extra_page_always[loc.current] + "\n(" + form_desc.address + ")", loc.btn_extra[loc.current], MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {

                    form_desc.ShowDialog();
                }

            
            }


            
        }


        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string resourceName = "Ra3_Mod_Manager." + new AssemblyName(args.Name).Name + ".dll";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }

        public static void writeSteamAppId(String path,int id) {

            try { 

            if (!File.Exists(path))
            {
                //Directory.CreateDirectory(path);
                FileStream fs = new FileStream(path, FileMode.CreateNew);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(id);
                sw.Flush();
                sw.Close();
                fs.Close();
                Console.WriteLine("Steam appid has been created:" + path + ":" + id);
            }
            else
            {
                Console.WriteLine("Steam appid is exists:"+path+":" + id);
            }
            }
            catch (Exception e)
            {
                
            }

        }

        static void checkSteam()
        {

            if (File.Exists(Application.StartupPath + "\\RA3EP1.exe"))
            {

                writeSteamAppId(Application.StartupPath + "\\Steam_appid.txt", 24800);
                writeSteamAppId(Application.StartupPath + "\\Data\\Steam_appid.txt", 24800);

            }
            else
            {
                writeSteamAppId(Application.StartupPath + "\\Data\\Steam_appid.txt", 17480);
                writeSteamAppId(Application.StartupPath + "\\Steam_appid.txt", 17480);
            }

        }

        static void checkFileExists()
        {



            String[] fileArray = { "\\Ra3.exe", "\\Data\\WBData.big", "\\Data\\Apt.big" };

            for (int i = 0; i < fileArray.Length; i++)
            {



                if (!File.Exists(Application.StartupPath + fileArray[i]))
                {

                    if (i == 0)
                    {
                        if (File.Exists(Application.StartupPath + "\\RA3EP1.exe"))
                        {

                            writeSteamAppId(Application.StartupPath + "\\Steam_appid.txt",24800) ;
                            writeSteamAppId(Application.StartupPath + "\\Data\\Steam_appid.txt", 24800);
                            Config.isDLC = true;
                            Config.gameName = "Uprising";
                            Console.WriteLine("That is DLC:"+Config.gameName);
                            for (int b = 0; b < loc.inf.Length; b++)
                            {
                                loc.in_game[b] = loc.in_game[b] + " " + loc.in_game_dlc[b];
                            }

                            continue;
                        }
                        else
                        {
                            if (File.Exists(Application.StartupPath + "\\RA3.exe"))
                            {
                                writeSteamAppId(Application.StartupPath + "\\Data\\Steam_appid.txt", 17480);
                                writeSteamAppId(Application.StartupPath + "\\Steam_appid.txt", 17480);
                            }
                        }
                    }


                    try
                    {

                        CultureInfo ci = Thread.CurrentThread.CurrentCulture;

                        String inf = loc.in_notfound[loc.current] + Application.StartupPath + fileArray[i];
                        String title = loc.in_error[loc.current];

                        MessageBox.Show(inf, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine("Not Game Path:" + Application.StartupPath + fileArray[i]);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString(), loc.in_execption[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);


                    }
                    finally {
                        System.Environment.Exit(0);
                    }
                }
            }





        }



        static void Initialization()
        {
            firstTimeRun();
            checkFileExists();

            checkImageExists();
            Config.searchLanguage();
            //checkCustomerImageExists();
            checkSteam();

            if (!Directory.Exists(Application.StartupPath + "\\Plugins\\Memory"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Plugins\\Memory");
            }

            if (!Directory.Exists(Application.StartupPath + "\\Plugins\\Library"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Plugins\\Library");
            }


            if (Config.customDat == null)
            {
                Config.readDAT(Application.StartupPath + "\\" + Config.configFile);
            }
            else
            {
                Config.readDAT(Application.StartupPath + "\\Custom.dat\\" + Config.customDat + ".dat");
            }
            if (!checkMainModExists(Config.commandmodname))
            {
                Config.runMode = 0;
                Config.gameList.Add(Config.gameName);
                Config.skudefList.Insert(0, Config.searchSkudef(Application.StartupPath));
                Config.modPathList.Insert(0, null);
                //Config.modPath = null;

                if (!Config.isDLC) {
                    Directory.CreateDirectory(Application.StartupPath + "\\Mods");
                    searchModFromDirectory(Application.StartupPath + "\\Mods");

                    Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Red Alert 3\\Mods");
                    searchModFromDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Red Alert 3\\Mods");
                    /*
                    Console.WriteLine("Search advanced mod...");
                    Console.WriteLine("Count modPath:"+Config.modPathList.Count);
                    foreach (string str in Config.modPathList)
                    {
                        if (string.IsNullOrEmpty(str))
                        {
                            Console.WriteLine("Pass Empty:"+str);
                            continue;
                        }

                        Console.WriteLine("Check mod:"+str);
                        if(str.Substring(str.Length-4,4).ToLower() == ".mod")
                        {
                            Config.modPath = str;
                            Config.dat_game = str.Substring(str.Length - 4, 4);
                            Console.WriteLine("Search first skudef:" + str);
                            String[] skudef = Config.searchSkudef(str);

                            foreach(string skudef_str in skudef)
                            {

                            

                            if (String.IsNullOrEmpty(skudef_str))
                            {

                                    Console.WriteLine("Pass Empty:" + skudef_str);
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("Get:" + skudef_str);
                                    Config.dat_version = skudef_str;
                                    break;
                                }

                            }
                            
                            Console.WriteLine("Select advanced mod:"+str);
                            Console.WriteLine("Select advanced mod's skudef:" + Config.dat_version);


                            break;
                        }
                    }
                    */
                }
            }


        }

        static void firstTimeRun()
        {

            if (!File.Exists(Application.StartupPath + "\\"+Config.configFile))
            {
                Config.isFirstTime = true;
                Console.WriteLine("First Time Run!");
            }
            else
            {
                return;
            }


            

            String str = Config.systemLanguage.Parent.EnglishName.ToLower();
            Console.WriteLine("Guess Language:" + str);


            int i = 0;

            if (str.IndexOf("chinese") != -1)
            {

                if (str.IndexOf("simplified") != -1)
                {
                    i = 1;
                }
                else
                {
                    i = 2;
                }

            }

            if (Config.isDevloper) { 
            new form_lang(i).ShowDialog();
            }
            else
            {

                loc.current = i;

            }



            /*
            int l = 0;
            if (str.IndexOf("chinese")!=-1)
            {

                if (str.IndexOf("simpl") != -1)
                {
                    l = 1;
                }
                else
                {
                    l = 2;
                }

            }

            String t = loc.inf[l] + "?";


            if (l != 0) { 
            DialogResult dr = MessageBox.Show(t,loc.set_lang_title[l],MessageBoxButtons.YesNo,MessageBoxIcon.Question);
           
            if (dr == DialogResult.Yes)
            {
                loc.current = l;

            }
            else
            {


              

                loc.current = 0 ;
            }
            }
            else
            {
                loc.current = 0;
            }
            //MessageBox.Show(loc.inf[loc.current], loc.inf[loc.current], MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            */

        }


        static void searchModFromDirectory(String path)
        {
            Console.WriteLine("Search Mod Directory:" + path);

            String[] dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);




            for (int i = 0; i < dirs.Length; i++)
            {
                /*
               String[] bigdir = Directory.GetDirectories(dirs[i],"game",SearchOption.TopDirectoryOnly);

               if (bigdir.Length > 0)
               {

                   Config.gameList.Add(Path.GetFileNameWithoutExtension(bigdir[0]));
                   Config.skudefList.Add(Config.searchSkudef(bigdir[0]));
                   Config.modPathList.Add(bigdir[0]);
                   Console.WriteLine("This Mod In Game:"+bigdir);
                   continue;

               }
               */

                Console.WriteLine("Search Skudef to List:" + dirs[i]);
                string[] skudefList = Config.searchSkudef(dirs[i]);

                if (skudefList.Length > 0) { 

                Console.WriteLine("Add Game to List:" + Path.GetFileNameWithoutExtension(dirs[i]));
                Config.gameList.Add(Path.GetFileNameWithoutExtension(dirs[i]));
                Console.WriteLine("Add Skudef to List:" + dirs[i]);
                Config.skudefList.Add(skudefList);
                Console.WriteLine("Add modPath to List:"+dirs[i]);
                Config.modPathList.Add(dirs[i]);
                }
                else
                {
                    Console.WriteLine("Faild Game:" + Path.GetFileNameWithoutExtension(dirs[i]));
                }
            }

        }





        /*
        static void checkCustomerImageExists()
        {
            String[] fileArray = { "\\Launcher\\MyTitle", "\\Launcher\\MySplash" };
            String[] fileNameExtension = { ".png", ".jpg", ".jpeg", ".bmp" };

            for (int i = 0; i < fileArray.Length; i++)
            {
                for (int x = 0; x < fileNameExtension.Length; x++)
                {
                    String path = Application.StartupPath + fileArray[i] + fileNameExtension[x];

                    if (File.Exists(path))
                    {
                        Config.isCustomImageMode = true;
                        Config.customerImage[i] = new Bitmap(path);
                        Config.currentImage[i] = Config.customerImage[i];
                        break;
                    }
                }
            }

        */
        static void checkGameImageExists()
        {
            String[] fileArray = { "\\Controller", "\\Splash", loc.infcode[loc.current] + "_Controller", loc.infcode[loc.current] + "_Splash" };
            String[] fileNameExtension = { ".png", ".jpg", ".jpeg", ".bmp" ,".gif" };

            for (int i = 0; i < fileArray.Length; i++)
            {
                for (int x = 0; x < fileNameExtension.Length; x++)
                {
                    String path = Application.StartupPath + "\\launcher"+ fileArray[i] + fileNameExtension[x];



                    //Console.WriteLine("Check " + path);

                    if (File.Exists(path))
                    {


                        Config.currentImage[i % 2] = new Bitmap(path);
                        break;
                    }
                }


            }





        }

        static void checkModImageExists()
        {
            String[] fileArray = { "\\Controller", "\\Splash", loc.infcode[loc.current] + "_Controller", loc.infcode[loc.current] + "_Splash" };
            String[] fileNameExtension = { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };

            for (int i = 0; i < fileArray.Length; i++)
            {
                for (int x = 0; x < fileNameExtension.Length; x++)
                {
                    String path = Config.modPath + "\\launcher" + fileArray[i] + fileNameExtension[x];



                    //Console.WriteLine("Check " + path);

                    if (File.Exists(path))
                    {


                        Config.currentImage[i % 2] = new Bitmap(path);
                        break;
                    }
                }


            }





        }



        static bool checkMainModExists(string name)
        {
            if (name == null)
            {

                return false;
            }
            Console.WriteLine("Load Main Mod...");
            String[] dirs = Directory.GetDirectories(Application.StartupPath, name, SearchOption.TopDirectoryOnly);
            if (dirs.Length != 0)
            {
                String dir = dirs[0];
                //Config.isCustomImageMode = false;
                Config.runMode = 1;
                Config.modPath = dir;
                Config.modPathList.Insert(0,dir);
                Console.WriteLine("Main Mod Path:" + dir.ToString());
                Config.gameList.Add(Path.GetFileNameWithoutExtension(dir));
                Config.skudefList.Insert(0, Config.searchSkudef(dir));
                String[] fileArray = { "\\Controller", "\\Splash", loc.infcode[loc.current] + "_Controller", loc.infcode[loc.current] + "_Splash" };
                String[] fileNameExtension = { ".png", ".jpg", ".jpeg", ".bmp" ,".gif" };

                for (int i = 0; i < fileArray.Length; i++)
                {
                    for (int x = 0; x < fileNameExtension.Length; x++)
                    {
                        String path = dir + fileArray[i] + fileNameExtension[x];

                        if (File.Exists(path))
                        {

                            Config.modImage[i % 2] = new Bitmap(path);
                            Config.currentImage[i % 2] = Config.modImage[i];
                            break;
                        }
                    }
                }






            }
            else
            {
                return false;
            }

            return true;

        }


        public static void checkImageExists()
        {
            Bitmap t, s;
            String tp = Application.StartupPath + "\\Launcher\\cnc.bmp", sp = Application.StartupPath + "\\Launcher\\splash.bmp";



            if (File.Exists(tp))
            {
                t = new Bitmap(tp);
                Console.WriteLine("Original Image Found:" + tp);
            }
            else
            {
                t = null;
            }

            if (File.Exists(tp))
            {
                s = new Bitmap(sp);
                Console.WriteLine("Original Image Found:" + sp);
            }
            else
            {
                s = null;
            }



            Config.originalImage[0] = t;
            
 
            Config.originalImage[1] = s;


            checkLanguageImageExists();


        }

        static void checkLanguageImageExists()
        {
            Bitmap t, s;
            String tp = Application.StartupPath + "\\Launcher\\"+loc.infcode[loc.current]+"_cnc.bmp", sp = Application.StartupPath + "\\Launcher\\" + loc.infcode[loc.current] + "_splash.bmp";



            if (File.Exists(tp))
            {
                t = new Bitmap(tp);
                Console.WriteLine("Original Language Image Found:" + tp);
            }
            else
            {
                t = null;
            }

            if (File.Exists(tp))
            {
                s = new Bitmap(sp);
                Console.WriteLine("Original Language Image Found:" + sp);
            }
            else
            {
                s = null;
            }


            if (t != null)
            {
                Config.originalImage[0] = t;
            }
            if (s != null)
            {
                Config.originalImage[1] = s;
            }





        }


        private static void startGameByProcessQuickly()
        {
            //Process p = new Process();

            String targetMod = Config.dat_game;
            String targetSkudef = Config.dat_version + ".skudef";
            String targetVersion = Config.dat_version;
            StringBuilder command = new StringBuilder("");

            Console.WriteLine("Confirm Game:" + targetMod);
            Console.WriteLine("Confirm Version:" + targetVersion);

            if (Config.dat_win || Config.dat_bfs)
            {
                command.Append(" -win");
            }

            if (Config.dat_cr || Config.dat_bfs)
            {
                
                String xres = Config.dat_xres;
                String yres = Config.dat_yres;

                if (Config.dat_bfs)
                {
                    xres = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString();
                    yres = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString();

                    Console.WriteLine("Need Use Desktop Resolution");

                }

                if (xres.Length > 0 && yres.Length > 0)
                {
                    command.Append(" -xres " + xres + " -yres " + yres);
                }
            }
            /*
            String game = "ra3_1.0.game";
            if (Config.isDLC)
            {
                game = "ra3ep1_1.0.game";
            }
            String customGame = "";

            

            if (targetMod.Equals(Config.gameName))
            {
                checkGameImageExists();
                targetSkudef = "ra3_" + Config.dat_language + "_" + targetVersion + ".skudef";

                game = "ra3_" + targetVersion + ".game";
                command.Append(" -config \"" + Application.StartupPath + "\\" + targetSkudef + "\"");
            }
            else
            {
                Config.modPath = Config.dat_modpath;
                checkModImageExists();
                Console.WriteLine("Mod Game Found:" + Config.modPath + "\\" + targetSkudef);
                String modGame = Config.readFirstLine(Config.modPath + "\\" + targetSkudef);

                

                
                String customGamePath = Config.modPath + "\\launcher\\game.txt";

                Console.WriteLine("Read Main Game File Information:" + customGamePath);
                if (File.Exists(customGamePath))
                {
                    customGame = Config.readFirstLine(customGamePath);

                }
                

                if (modGame.Length <= 0 || modGame.IndexOf("mod-game") == -1)
                {
                    modGame = "1.12";
                    Console.WriteLine("Unknown Mod Game Start Version:Set to" + modGame);
                    targetSkudef = "ra3_" + Config.dat_language + "_" + modGame + ".skudef";
                    game = "ra3_" + modGame + ".game";
                    command.Append(" -config \"" + Application.StartupPath + "\\" + targetSkudef + "\"");

                }
                else
                {
                    modGame = modGame.Substring(modGame.LastIndexOf("mod-game") + 8).Trim();
                    Console.WriteLine("Mod Game Start Version:" + modGame);
                    String targetModSkudef = "ra3_" + Config.dat_language + "_" + modGame + ".skudef";
                    game = "ra3_" + modGame + ".game";
                    command.Append(" -config \"" + Application.StartupPath + "\\" + targetModSkudef + "\"");
                    command.Append(" -modConfig \"" + Config.modPath + "\\" + targetSkudef + "\"");
                }



            }

    */
            String game = "ra3_1.0.game";
            if (Config.isDLC)
            {
                game = "ra3ep1_1.0.game";
            }
            String customGame = "";
            if (targetMod.Equals(Config.gameName))
            {
                checkGameImageExists();
                if (!Config.isDLC)
                {
                    targetSkudef = "ra3_" + Config.dat_language + "_" + targetVersion + ".skudef";
                    game = "ra3_" + targetVersion + ".game";
                }
                else
                {
                    targetSkudef = "ra3ep1_" + Config.dat_language + "_" + targetVersion + ".skudef";
                    game = "ra3ep1_" + targetVersion + ".game";
                }




                command.Append(" -config \"" + Application.StartupPath + "\\" + targetSkudef + "\"");
            }
            else
            {
                checkModImageExists();
                String modGame = Config.readFirstLine(Config.modPath + "\\" + targetSkudef);


                String customGamePath = Config.modPath + "\\launcher\\game.txt";

                Console.WriteLine("Read Main Game File Information:" + customGamePath);
                if (File.Exists(customGamePath))
                {
                    customGame = Config.readFirstLine(customGamePath);

                }


                if (modGame.Length <= 0 || modGame.IndexOf("mod-game") == -1)
                {
                    modGame = "1.12";
                    Console.WriteLine("Unknown Mod Game Start Version:Set to" + modGame);
                    targetSkudef = "ra3_" + Config.dat_language + "_" + modGame + ".skudef";
                    game = "ra3_" + modGame + ".game";
                    command.Append(" -config \"" + Application.StartupPath + "\\" + targetSkudef + "\"");

                }
                else
                {
                    modGame = modGame.Substring(modGame.LastIndexOf("mod-game") + 8).Trim();
                    customGame = modGame;
                    Console.WriteLine("Mod Game Start Version:" + modGame);
                    String targetModSkudef = "ra3_" + Config.dat_language + "_" + modGame + ".skudef";
                    game = "ra3_" + modGame + ".game";
                    command.Append(" -config \"" + Application.StartupPath + "\\" + targetModSkudef + "\"");
                    command.Append(" -modConfig \"" + Config.modPath + "\\" + targetSkudef + "\"");
                }



            }



            Console.WriteLine("Start Game:" + Application.StartupPath + "\\data\\" + game + command);

            Process main = new Process();
            Config.gameProcess = main;
            main.StartInfo.UseShellExecute = false;
            main.StartInfo.WorkingDirectory = Application.StartupPath + "\\data\\";

            if (Config.isDebug)
            {
                main.StartInfo.RedirectStandardError = true;
                main.StartInfo.RedirectStandardInput = true;
                main.StartInfo.RedirectStandardOutput = true;
            }
            Console.WriteLine("Try to find:" + Config.modPath + "\\" + customGame);
            if (File.Exists(Config.modPath + "\\" + customGame))
            {

                main.StartInfo.FileName = Config.modPath + "\\" + customGame;
                Console.WriteLine("Custom Game File: " + main.StartInfo.FileName);
                
                if (!Directory.Exists(Config.modPath + "\\Data\\Cursors"))
                {
                    Directory.CreateDirectory(Config.modPath + "\\Data\\Cursors");

                    String[] fg = Directory.GetFiles(Application.StartupPath + "\\Data\\Data\\Cursors", "*.ani", SearchOption.TopDirectoryOnly);

                    foreach(var i in fg)
                    {

                        File.Copy(i, Config.modPath + "\\Data\\Cursors\\" + Path.GetFileName(i));

                    }

                }

            }
            else
            {

                main.StartInfo.FileName = "data\\" + game;
                Console.WriteLine("Orignial Game File: " + main.StartInfo.FileName);
            }

            Config.md5 = Config.getMd5(main.StartInfo.FileName);

            main.StartInfo.Arguments = command.ToString();
           
            popDesc();
            main.Start();
            if (Config.canInj)
            {

                inj.doinj();
            }


            if (Config.canHook)
            {
                inj.dohook();
            }

            Game.doGameAction();
        }



    }



 








}
