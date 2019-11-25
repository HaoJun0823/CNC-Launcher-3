using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace Ra3_Mod_Manager
{
    class reg
    {



        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static string selectGameFolder()
        {
            string path = "";
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = loc.plugin_choose_game[loc.current];

            dialog.Filter = "Red Alert 3|RA3.exe|Uprising|RA3EP1.exe|*.*|*.*";
            dialog.RestoreDirectory = false;
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                path = Path.GetFullPath(dialog.FileName);
            }


                return path;

        }

        public static void createRa3Key(string path,string gameName,string gameFullName,string uid)
        {

            RegistryKey Main = getMainKey();
            RegistryKey MainGame = Main.CreateSubKey(gameName);
            MainGame.SetValue("DisplayName", gameFullName, RegistryValueKind.String);
            RegistryKey SubMain = Main.CreateSubKey("Electronic Arts");
            RegistryKey SubMainGame = SubMain.CreateSubKey(gameName);





            SubMainGame.SetValue("CD Drive",path.Substring(0,path.IndexOf(':'))+":\\",RegistryValueKind.String);
            SubMainGame.SetValue("DisplayName", gameFullName, RegistryValueKind.String);
            SubMainGame.SetValue("InstallDir", path, RegistryValueKind.String);
            SubMainGame.SetValue("Installed From" , path.Substring(0, path.IndexOf(':')) + ":\\", RegistryValueKind.String);
            SubMainGame.SetValue("Patch URL", "http://www.ea.com/redalert", RegistryValueKind.String);
            SubMainGame.SetValue("Product GUID", uid, RegistryValueKind.String);
            SubMainGame.SetValue("ProductName", gameFullName, RegistryValueKind.String);
            SubMainGame.SetValue("ProfileFolderName", "Profiles", RegistryValueKind.String);
            SubMainGame.SetValue("Registration", @"Software\Electronic Arts\Electronic Arts\"+gameName+@"\ergc", RegistryValueKind.String);

            SubMainGame.SetValue("ReplayFolderName", "Replays", RegistryValueKind.String);
            SubMainGame.SetValue("SaveFolderName", "SaveGames", RegistryValueKind.String);
            SubMainGame.SetValue("ScreenshotsFolderName", "Screenshots", RegistryValueKind.String);
            SubMainGame.SetValue("Suppression Exe", "", RegistryValueKind.String);
            SubMainGame.SetValue("UseLocalUserMaps", 0, RegistryValueKind.DWord);
            SubMainGame.SetValue("UserDataLeafName", gameName, RegistryValueKind.String);

            RegistryKey version = SubMainGame.CreateSubKey("1.0");
            version.SetValue("DisplayName", gameName, RegistryValueKind.String);

            version.Close();
            SubMainGame.Close();
            SubMain.Close();
            MainGame.Close();
            Main.Close();

        }

        public static void changeCDKEY()
        {
            string game = Config.isUprising ? "Red Alert 3 Uprising" : "Red Alert 3";
            string key = reg.readCDKEY(game);
            string result = Microsoft.VisualBasic.Interaction.InputBox(loc.plugin_reg_cdkey_desc[loc.current] + key, loc.plugin_reg_cdkey_title[loc.current], "", -1, -1);

            if (String.IsNullOrEmpty(result))
            {
                MessageBox.Show(key + loc.plugin_reg_cdkey_desc_pass[loc.current], loc.plugin_reg_title[loc.current], MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }

            if (result.Length != 20)
            {
                if (MessageBox.Show(result+loc.plugin_reg_cdkey_desc_faild[loc.current], loc.check_vaild_title[loc.current],MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    changeCDKEY();
                }
            }
            else
            {
                writeCDKEY(game,result);
                MessageBox.Show(result + loc.plugin_reg_cdkey_desc_pass[loc.current], loc.plugin_reg_title[loc.current], MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }

        public static void changeLanguage(string game,string language,string locale,string readme,int languageCode)
        {
            RegistryKey Main = getMainKey();
            RegistryKey SubMain = Main.CreateSubKey("Electronic Arts");
            RegistryKey SubMainGame = SubMain.CreateSubKey(game);

            SubMainGame.SetValue("Language",language,RegistryValueKind.String);
            SubMainGame.SetValue("Locale", locale, RegistryValueKind.String);
            if (readme.Length > 0) { 
            SubMainGame.SetValue("Readme", readme, RegistryValueKind.String);
            }
            RegistryKey version = SubMainGame.CreateSubKey("1.0");
            version.SetValue("Language", languageCode, RegistryValueKind.DWord);
            version.SetValue("LanguageName", language, RegistryValueKind.String);

            version.Close();
            SubMainGame.Close();
            SubMain.Close();
            Main.Close();
            
        }

        public static string readCDKEY(string game)
        {
            RegistryKey Main = getMainKey();
            RegistryKey SubMain = Main.CreateSubKey("Electronic Arts");
            RegistryKey SubMainGame = SubMain.CreateSubKey(game);
            RegistryKey ergc = SubMainGame.CreateSubKey("ergc");
            string key = ergc.GetValue("","").ToString();
            ergc.Close();
            SubMainGame.Close();
            SubMain.Close();
            Main.Close();
            return key;



        }
        public static void writeCDKEY(string game,string key)
        {
            RegistryKey Main = getMainKey();
            RegistryKey SubMain = Main.CreateSubKey("Electronic Arts");
            RegistryKey SubMainGame = SubMain.CreateSubKey(game);
            RegistryKey ergc = SubMainGame.CreateSubKey("ergc");
            ergc.SetValue("", key, RegistryValueKind.String);
            Console.WriteLine("New CDKey For" + game + ":" + key);
            ergc.Close();
            SubMainGame.Close();
            SubMain.Close();
            Main.Close();
        }
        public static RegistryKey getMainKey()
        {
            RegistryKey Main = Registry.LocalMachine;
            Main = Main.OpenSubKey("SOFTWARE",true);
            /*
            string[] subSoftWareKeys = Main.GetSubKeyNames();
            foreach(string name in subSoftWareKeys)
            {
                Console.WriteLine("Check RegistryKey:" + name);
                if (name == "Wow6432Node")
                {
                    Main.OpenSubKey("Wow6432Node", true);
                    break;
                }
                
            }
            */

            RegistryKey SubMain = Main.CreateSubKey("Electronic Arts");
            SubMain.OpenSubKey("Electronic Arts",true);

            //Console.WriteLine("Get Main RegistryKey:"+SubMain.ToString());
            return SubMain;
        }

    }
}
