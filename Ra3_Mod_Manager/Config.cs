using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ra3_Mod_Manager
{
    public static class Config

    {
        public static String customDat = null;
        public static bool canSkip = false;
        public static String configFile = "Ra3_Mod_Manager.dat";
        public static String extraTitle = "";
        public static bool isFirstTime = false;
        public static bool isDebug = false;
        public static String gameName = "Red Alert 3";
        public static bool isDLC = false;
        public static bool isDevloper = false;
        public static Image[] originalImage = { null, null };
        //public static Image[] customerImage = new Bitmap[originalImage.Length];
        public static Image[] currentImage = { originalImage[0], originalImage[1] };
        public static Image[] modImage = new Bitmap[originalImage.Length];
        public static List<String> languageList = new List<String>();
        public static List<String[]> skudefList = new List<String[]>();
        public static List<String> gameList = new List<String>();
        public static List<String> modPathList = new List<String>();
        public static int runMode = 0; // 0 = normal;1 = unique;
        public static String modPath;
        public static Icon defaultIcon;
        public static CultureInfo systemLanguage = Thread.CurrentThread.CurrentUICulture;

        //public static bool isCustomImageMode = false;
        public static String exeVersion = Application.ProductVersion.ToString();


        public static bool dat_win = false;
        public static bool dat_cr = false;
        public static String dat_xres = "800";
        public static String dat_yres = "600";
        public static String dat_game = "";
        public static String dat_version = "";
        public static String dat_language = "";
        public static String dat_modpath = "";
        public static int dat_loc = 0;
        public static bool dat_bfs = false;
        public static bool dat_media = false;
        public static Color btn_mb;
        public static Color btn_db;
        public static Image btnImage;
        public static Image btnImageMove;
        public static Image btnImageClick;
        public static String btnAudioMove = "";
        public static String btnAudioClick = "";
        public static String cursorPath = "";
        public static String cursorPointerPath = "";
        public static String cursorTextPath = "";
        public static Process gameProcess;
        public static Controller mainController;
        public static String timeStamp = DateTime.Now.ToString("yyymmddhhmmss");
        public static bool canInj = false;
        public static bool canHook = false;
        public static String md5;
        public static String webPath = "";
        public static bool extraFirst = true;
        public static List<string> versionList = new List<string>();

        public static bool dat_mouse_locked = false;
        public static bool dat_mouse_dynamic = false;

        public static String getMd5(String path)
        {
            String smd5 = "";



            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                smd5 = sb.ToString();
            }
            catch (Exception)
            {

            }

            Console.WriteLine("Try Get File MD5:" + smd5);
            return smd5;
        }

        public static List<string> readEveryLine(string path)
        {

            List<string> list = new List<string>();

            Console.WriteLine("Read This File Every Line:" + path);
            /*
            using (StreamReader reader = new StreamReader(path)){

                string line = reader.ReadLine();

                while(line !="" && line != null)
                {


                    list.Add(line);
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }



            }

            */

            foreach (string str in System.IO.File.ReadAllLines(path, Encoding.Default))
            {
                Console.WriteLine(str);
                list.Add(str);
            }

            return list;

        }

        public static void readDAT(String filepath)
        {
            Console.WriteLine("Try Read Dat:" + filepath);
            if (Config.isFirstTime)
            {
                /*
                Ra3_Mod_Manager.Properties.Settings.Default.dat_loc = loc.current;
                Ra3_Mod_Manager.Properties.Settings.Default.Save();
                */

                Config.dat_loc = loc.current;
                //Config.writeDAT(false,false,"800","600","","","","",false,dat_loc);
                if (Config.isDevloper)
                {
                    MessageBox.Show(loc.info_first[loc.current]+"\n\n"+loc.first_time_run_title[loc.current] + "\n"+loc.first_time_run_description[loc.current], loc.btn_information[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return;

            }





            if (!File.Exists(filepath))
            {
                return;
            }



            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);


            StreamReader sr = new StreamReader(fs);

            String str = sr.ReadLine();
            String[] option = str.Split('|');

            Console.WriteLine("Read Dat:" + filepath);
            Console.WriteLine("Read Data:" + str);
            try
            {
                dat_win = Boolean.Parse(option[0]);
                dat_cr = Boolean.Parse(option[1]);
                dat_xres = option[2];
                dat_yres = option[3];
                dat_game = option[4];
                dat_version = option[5];
                dat_language = option[6];
                dat_modpath = option[7];
                dat_media = Boolean.Parse(option[8]);
                dat_loc = int.Parse(option[9]);
                dat_bfs = bool.Parse(option[10]);
                dat_mouse_locked = bool.Parse(option[11]);
                dat_mouse_dynamic = bool.Parse(option[12]);


                loc.current = dat_loc;
                sr.Close();

            }
            catch (Exception e)
            {
                //File.Delete(Application.StartupPath + "\\Ra3_Manager.dat");
                try
                {
                    File.Move(Application.StartupPath + "\\Ra3_Mod_Manager.dat", Application.StartupPath + "\\Ra3_Mod_Manager.dat.error" + DateTime.Now.ToFileTime().ToString());
                }
                catch (Exception)
                {
                    try
                    {
                        File.Move(Application.StartupPath + "\\Ra3_Mod_Manager.dat", Application.StartupPath + "\\Ra3_Mod_Manager.dat.error" + DateTime.Now.ToFileTime().ToString());
                    }
                    catch (Exception)
                    {
                        try
                        {
                            File.Delete(Application.StartupPath + "\\Ra3_Mod_Manager.dat");
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                MessageBox.Show("Wrong or old 'Ra3_Mod_Manager.dat' file,restore!\n" + e.Message, "Exception:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sr.Close();
                fs.Close();

            }




            /*

            dat_win = Ra3_Mod_Manager.Properties.Settings.Default.dat_win;
            dat_cr = Ra3_Mod_Manager.Properties.Settings.Default.dat_cr;
            dat_xres = Ra3_Mod_Manager.Properties.Settings.Default.dat_xres;
            dat_yres = Ra3_Mod_Manager.Properties.Settings.Default.dat_yres;
            dat_game = Ra3_Mod_Manager.Properties.Settings.Default.dat_game;
            dat_version = Ra3_Mod_Manager.Properties.Settings.Default.dat_version;
            dat_language = Ra3_Mod_Manager.Properties.Settings.Default.dat_language;
            dat_modpath = Ra3_Mod_Manager.Properties.Settings.Default.dat_modpath;
            dat_media = Ra3_Mod_Manager.Properties.Settings.Default.dat_media;
            dat_loc = Ra3_Mod_Manager.Properties.Settings.Default.dat_loc;

            loc.current = dat_loc;

            StringBuilder strBuild = new StringBuilder("");

            strBuild.Append(dat_win);
            strBuild.Append('|');
            strBuild.Append(dat_cr);
            strBuild.Append('|');
            strBuild.Append(dat_xres);
            strBuild.Append('|');
            strBuild.Append(dat_yres);
            strBuild.Append('|');
            strBuild.Append(dat_game);
            strBuild.Append('|'); ;
            strBuild.Append(dat_version);
            strBuild.Append('|');
            strBuild.Append(dat_language);
            strBuild.Append('|');
            strBuild.Append(dat_modpath);
            strBuild.Append('|');
            strBuild.Append(dat_media);
            strBuild.Append('|');
            strBuild.Append(dat_loc);


            Console.WriteLine("Read Data:" + strBuild.ToString());
            */

        }

        public static String writeDAT(String filepath, bool win, bool cr, String xres, String yres, String game, String version, String language, String modPath, bool media, int loc, bool bfs, bool mouselock, bool mousedynamic, String dat_desc)
        {

            FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            StringBuilder strBuild = new StringBuilder("");

            strBuild.Append(win);
            strBuild.Append('|');
            strBuild.Append(cr);
            strBuild.Append('|');
            strBuild.Append(xres);
            strBuild.Append('|');
            strBuild.Append(yres);
            strBuild.Append('|');
            strBuild.Append(game);
            strBuild.Append('|'); ;
            strBuild.Append(version);
            strBuild.Append('|');
            strBuild.Append(language);
            strBuild.Append('|');
            strBuild.Append(modPath);
            strBuild.Append('|');
            strBuild.Append(media);
            strBuild.Append('|');
            strBuild.Append(loc);
            strBuild.Append('|');
            strBuild.Append(bfs);
            strBuild.Append('|');
            strBuild.Append(mouselock);
            strBuild.Append('|');
            strBuild.Append(mousedynamic);
            strBuild.Append('|');
            strBuild.Append(dat_desc);

            Console.WriteLine("Write Data:" + strBuild.ToString());

            Console.WriteLine("Write Dat:" + filepath);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(strBuild.ToString());
            sw.Flush();

            sw.Close();

            return strBuild.ToString();

            //System Settings


            /*
            Ra3_Mod_Manager.Properties.Settings.Default.dat_win = win;
            Ra3_Mod_Manager.Properties.Settings.Default.dat_cr = cr;
            Ra3_Mod_Manager.Properties.Settings.Default.dat_xres = xres;
            Ra3_Mod_Manager.Properties.Settings.Default.dat_yres = yres;
            Ra3_Mod_Manager.Properties.Settings.Default.dat_game = game;
            Ra3_Mod_Manager.Properties.Settings.Default.dat_version = version;
            Ra3_Mod_Manager.Properties.Settings.Default.dat_language = language;
            Ra3_Mod_Manager.Properties.Settings.Default.dat_modpath = modPath;
            Ra3_Mod_Manager.Properties.Settings.Default.dat_media = media;
            Ra3_Mod_Manager.Properties.Settings.Default.dat_loc = loc;
            Ra3_Mod_Manager.Properties.Settings.Default.Save();

        */


        }

        public static String[] searchSkudef(String modPath)
        {
            String[] skudef = Directory.GetFiles(modPath, "*.skudef", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < skudef.Length; i++)
            {

                Console.WriteLine("Found SkuDef:" + skudef[i]);

                skudef[i] = Path.GetFileNameWithoutExtension(skudef[i]);

            }

            return skudef;

        }

        public static void searchLanguage()
        {
            String[] skudef = Directory.GetFiles(Application.StartupPath, "*.skudef", SearchOption.TopDirectoryOnly);
            List<String> availiable = new List<String>();
            for (int i = 0; i < skudef.Length; i++)
            {
                bool isAlive = false;
                int start = skudef[i].IndexOf('_') + 1;
                int end = skudef[i].LastIndexOf('_');

                skudef[i] = skudef[i].Substring(start, end - start);


                for (int x = 0; x < availiable.Count; x++)
                {
                    if (availiable[x].Equals(skudef[i]))
                    {
                        isAlive = true;

                        break;
                    }

                }

                if (!isAlive)
                {
                    languageList.Add(skudef[i]);
                    availiable.Add(skudef[i]);
                }
            }


        }



        public static String readFirstLine(String path)
        {

            Console.WriteLine("Read First Line From Path:" + path);
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            String str = sr.ReadLine();

            try
            {
                sr.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), loc.in_execption[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            return str;

        }









    }
}
