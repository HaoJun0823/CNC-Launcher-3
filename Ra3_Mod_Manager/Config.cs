﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CNCLauncher
{
    public static class Config

    {
        public static String customDat = null;
        public static bool canSkip = false;
        public static String configFile = Environment.UserName+"-CNCLauncher.dat";
        public static String extraTitle = "";
        public static bool isFirstTime = false;
        public static bool isDebug = false;
        public static String gameName = "";
        public static String gameRAName = "Red Alert 3";
        public static String gameDLCName = "Uprising";
        public static String gameCNCName = "Tiberium Wars";
        public static String gameKWName = "Kane's Wrath";
        public static bool isUprising = false;
        public static bool isRA = false;
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
        public static bool isCNC = false;
        public static bool isKW = false;
        public static String workPath = Application.StartupPath;

        //public static bool isCustomImageMode = false;
        public static String exeVersion = Application.ProductVersion.ToString();

        public static string commandmodname = null;
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
        public static bool canInj = true;
        public static bool canHook = true;
        public static String md5;
        public static String webPath = "";
        public static bool extraFirst = true;
        public static List<string> versionList = new List<string>();

        public static bool dat_mouse_locked = false;
        public static bool dat_mouse_dynamic = false;
        public static string wbPath = "";

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
                Config.isDevloper = true;
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
                //File.Delete(Config.workPath + "\\Ra3_Manager.dat");
                try
                {
                    File.Move(Config.workPath + "\\"+Config.configFile, Config.workPath + "\\" + Config.configFile+".error" + DateTime.Now.ToFileTime().ToString());
                }
                catch (Exception)
                {
                    try
                    {
                        File.Move(Config.workPath + "\\" + Config.configFile, Config.workPath + "\\" + Config.configFile + ".error" + DateTime.Now.ToFileTime().ToString());
                    }
                    catch (Exception)
                    {
                        try
                        {
                            File.Delete(Config.workPath + "\\" + Config.configFile);
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                MessageBox.Show("Wrong or old '"+Config.configFile+"' file,restore!\n" + e.Message, "Exception:", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            dat_win = win;
            dat_cr = cr;
            dat_xres = xres;
            dat_yres = yres;
            dat_game = game;
            dat_version = version;
            dat_language = language;
            dat_modpath = modPath;
            dat_media = media;
            dat_loc = loc;
            dat_bfs = bfs;
            dat_mouse_locked = mouselock;
            dat_mouse_dynamic = mousedynamic;

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
            Console.WriteLine("Start search mod skudef（"+modPath+"）,length:" + skudef.Length);
            for (int i = 0; i < skudef.Length; i++)
            {


                Console.WriteLine(i+".Found Mod SkuDef:" + skudef[i]);




                skudef[i] = Path.GetFileNameWithoutExtension(skudef[i]);

            }

            return skudef;

        }

        public static String[] searchGameSkudef(String modPath)
        {
            String[] skudef = Directory.GetFiles(modPath, "*.skudef", SearchOption.TopDirectoryOnly);
            Console.WriteLine("Start search game skudef（" + modPath + "）,length:" + skudef.Length);
            List<string> strList = new List<string>();


            for (int i = 0; i < skudef.Length; i++)
            {
                strList.Add(skudef[i]);
            }
            Console.WriteLine("Finsihed convert game skudef,length:" + strList.Count);

            for (int i = 0; i < strList.Count; i++)
            {



                //ra3 ra3ep1 cnc3ep1 cnc3
                //^(ra3|ra3ep1|cnc3|cnc3ep1)+_[a-zA-z_]+_[0-9.]+.skudef$

                Console.WriteLine(i+".Found Game SkuDef:" + strList[i]);

                string pattern = @"^(ra3|ra3ep1|cnc3|cnc3ep1)+_[a-z_]+_[0-9.]+.skudef$";



                string filename = Path.GetFileName(strList[i]).ToLower();
                if (!System.Text.RegularExpressions.Regex.IsMatch(filename, pattern))
                {
                    Console.WriteLine("Not Match SkuDef:" + filename + "|Pattern:" + pattern);
                    Console.WriteLine("Remove Index:"+i+",Reduce List!");
                    strList.RemoveAt(i);
                    i--;
                    continue;
                }



                strList[i] = Path.GetFileNameWithoutExtension(strList[i]);

            }

            return strList.ToArray();

        }

        public static void searchLanguage()
        {
            String[] skudef = Directory.GetFiles(Config.workPath, "*.skudef", SearchOption.TopDirectoryOnly);
            List<String> availiable = new List<String>();
            for (int i = 0; i < skudef.Length; i++)
            {


                string pattern = @"^(ra3|ra3ep1|cnc3|cnc3ep1)+_[a-z_]+_[0-9.]+.skudef$";



                string filename = Path.GetFileName(skudef[i]).ToLower();
                if (!System.Text.RegularExpressions.Regex.IsMatch(filename, pattern))
                {
                    Console.WriteLine("Not Match Language SkuDef:" + filename + "|Pattern:" + pattern);
                    Console.WriteLine("Remove Index:" + i);
                    continue;
                }



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
            String str = "";

            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                str = sr.ReadLine();
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
