using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CNCLauncher
{
    class run
    {
        /*
        private void startGameByProcess()
        {
            //Process p = new Process();

            String targetMod = lc_Game.Text;
            String targetSkudef = lc_Version.Text + ".skudef";
            String targetVersion = lc_Version.Text;
            StringBuilder command = new StringBuilder("");

            Console.WriteLine("Confirm Game:" + targetMod);
            Console.WriteLine("Confirm Version:" + targetVersion);

            if (cb_Windowed.Checked || cb_bfs.Checked)
            {
                command.Append(" -win");
            }


            if (cb_CustomResolution.Checked || cb_bfs.Checked)
            {

                String xres = tb_Xres.Text.Trim();
                String yres = tb_Yres.Text.Trim();

                if (cb_bfs.Checked)
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


            String game = "ra3_1.0.game";
            if (Config.isUprising)
            {
                game = "ra3ep1_1.0.game";
            }
            String customGame = "";
            if (targetMod.Equals(Config.gameName))
            {

                if (!Config.isUprising)
                {
                    targetSkudef = "ra3_" + lc_GameLanguage.Text + "_" + targetVersion + ".skudef";
                    game = "ra3_" + targetVersion + ".game";
                }
                else
                {
                    targetSkudef = "ra3ep1_" + lc_GameLanguage.Text + "_" + targetVersion + ".skudef";
                    game = "ra3ep1_" + targetVersion + ".game";
                }




                command.Append(" -config \"" + Config.workPath + "\\" + targetSkudef + "\"");
            }
            else
            {

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
                    targetSkudef = "ra3_" + lc_GameLanguage.Text + "_" + modGame + ".skudef";
                    game = "ra3_" + modGame + ".game";
                    command.Append(" -config \"" + Config.workPath + "\\" + targetSkudef + "\"");

                }
                else
                {
                    modGame = modGame.Substring(modGame.LastIndexOf("mod-game") + 8).Trim();
                    customGame = modGame;
                    Console.WriteLine("Mod Game Start Version:" + modGame);
                    String targetModSkudef = "ra3_" + lc_GameLanguage.Text + "_" + modGame + ".skudef";
                    game = "ra3_" + modGame + ".game";
                    command.Append(" -config \"" + Config.workPath + "\\" + targetModSkudef + "\"");
                    command.Append(" -modConfig \"" + Config.modPath + "\\" + targetSkudef + "\"");
                }



            }

            Console.WriteLine("Start Game:" + Config.workPath + "\\data\\" + game + command);

            Process main = new Process();
            Config.gameProcess = main;
            main.StartInfo.UseShellExecute = false;
            main.StartInfo.WorkingDirectory = Config.workPath + "\\data\\";

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

                    String[] fg = Directory.GetFiles(Config.workPath + "\\Data\\Data\\Cursors", "*.ani", SearchOption.TopDirectoryOnly);

                    foreach (var i in fg)
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
            //main.StartInfo.CreateNoWindow = true;
            Config.mainController.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            //Config.mainController.Visible = false;

            Program.popDesc();
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
        */


    public static void startGameByProcessQuickly()
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

        String game = "ra3_1.0.game";
        if (Config.isUprising)
        {
            game = "ra3ep1_1.0.game";
        }
        String customGame = "";
            Program.checkGameImageExists();
            if (targetMod.Equals(Config.gameName))
        {
            Console.WriteLine("Not Mod.");
           
            if (Config.isKW)
            {
                    targetSkudef = "cnc3ep1_" + Config.dat_language + "_" + targetVersion + ".skudef";
                    game = targetVersion + "\\cnc3ep1.dat";
                } 
            else if (Config.isCNC)
            {
                    targetSkudef = "cnc3_" + Config.dat_language + "_" + targetVersion + ".skudef";
                    game = targetVersion+"\\cnc3game.dat";
                } else
            if (Config.isRA)
            {
                targetSkudef = "ra3_" + Config.dat_language + "_" + targetVersion + ".skudef";
                game = "ra3_" + targetVersion + ".game";
            }
            else if(Config.isUprising)
            {
                targetSkudef = "ra3ep1_" + Config.dat_language + "_" + targetVersion + ".skudef";
                game = "ra3ep1_" + targetVersion + ".game";
            }




            command.Append(" -config \"" + Config.workPath + "\\" + targetSkudef + "\"");
        }
        else
        {
                Console.WriteLine("Is Mod.");
                if (String.IsNullOrEmpty(Config.modPath))
                {
                    Console.WriteLine("Set dat data to modpath "+Config.dat_modpath);
                    Config.modPath = Config.dat_modpath;
                        
                }

                Program.checkModImageExists();
            String modGame = Config.readFirstLine(Config.modPath + "\\" + targetSkudef);

                Console.WriteLine("Get Mod Skudef:" + modGame);
            String customGamePath = Config.modPath + "\\launcher\\game.txt";

            Console.WriteLine("Read Main Game File Information:" + customGamePath);
            if (File.Exists(customGamePath))
            {
                customGame = Config.readFirstLine(customGamePath);

            }

            if (modGame.Length <= 0 || modGame.IndexOf("mod-game") == -1)
            {
                    modGame = "1.0";
                    if (Config.isCNC)
                    {
                        modGame = "1.9";
                        targetSkudef = "cnc3_" + Config.dat_language + "_" + modGame + ".skudef";
                        game = modGame + "\\cnc3game.dat";
                    }
                    else if (Config.isKW)
                    {
                        modGame = "1.2";
                        targetSkudef = "cnc3ep1_" + Config.dat_language + "_" + modGame + ".skudef";
                        game = modGame + "\\cnc3ep1.dat";
                    }
                    else if (Config.isUprising)
                    {
                        modGame = "1.0";
                        targetSkudef = "ra3ep1_" + Config.dat_language + "_" + modGame + ".skudef";
                        game = "ra3ep1_" + modGame + ".game";
                    }
                    else if (Config.isRA)
                    {
                        modGame = "1.12";
                        targetSkudef = "ra3_" + Config.dat_language + "_" + modGame + ".skudef";
                        game = "ra3_" + modGame + ".game";
                    }
                Console.WriteLine("Unknown Mod Game Start Version:Set to" + modGame);

                command.Append(" -config \"" + Config.workPath + "\\" + targetSkudef + "\"");

            }
            else
            {
                modGame = modGame.Substring(modGame.LastIndexOf("mod-game") + 8).Trim();
                customGame = modGame;
                Console.WriteLine("Mod Game Start Version:" + modGame);
                String targetModSkudef = "";
                    if (Config.isCNC)
                    {
                        targetModSkudef = "cnc3_" + Config.dat_language + "_" + modGame + ".skudef";
                        game = modGame + "\\cnc3game.dat";
                    }
                    else if (Config.isKW)
                    {
                        targetModSkudef = "cnc3ep1_" + Config.dat_language + "_" + modGame + ".skudef";
                        game = modGame + "\\cnc3ep1.dat";
                    }
                    else if (Config.isUprising)
                    {
                        targetModSkudef = "ra3ep1_" + Config.dat_language + "_" + modGame + ".skudef";
                        game = "ra3ep1_" + modGame + ".game";
                    }
                    else if (Config.isRA)
                    {
                        targetModSkudef = "ra3_" + Config.dat_language + "_" + modGame + ".skudef";
                        game = "ra3_" + modGame + ".game";
                    }

                command.Append(" -modConfig \"" + Config.modPath + "\\" + targetSkudef + "\"");
                command.Append(" -config \"" + Config.workPath + "\\" + targetModSkudef + "\"");
            }



        }
            if (Config.isKW || Config.isCNC)
            {
                Console.WriteLine("Start Game:" + Config.workPath + "\\RetailExe\\" + game + command);
            }
            else if (Config.isRA || Config.isUprising)
            {
                Console.WriteLine("Start Game:" + Config.workPath + "\\data\\" + game + command);
            }


            if (Config.mainController != null)
            {
                Config.mainController.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }

            Program.popDesc();
            Process main = new Process();
        Config.gameProcess = main;
        main.StartInfo.UseShellExecute = false;
            if (Config.isKW || Config.isCNC)
            {
                main.StartInfo.WorkingDirectory = Config.workPath + "\\RetailExe\\"+game.Substring(0,game.IndexOf('\\'));
            }
            else if(Config.isRA || Config.isUprising) { 
        main.StartInfo.WorkingDirectory = Config.workPath + "\\data\\";
            }
            Console.WriteLine("Work Directory:"+main.StartInfo.WorkingDirectory);
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

            if (!Directory.Exists(Config.modPath + "\\Data\\Cursors")&&!(Config.isKW || Config.isCNC))
            {
                Directory.CreateDirectory(Config.modPath + "\\Data\\Cursors");

                String[] fg = Directory.GetFiles(Config.workPath + "\\Data\\Data\\Cursors", "*.ani", SearchOption.TopDirectoryOnly);

                foreach (var i in fg)
                {

                    File.Copy(i, Config.modPath + "\\Data\\Cursors\\" + Path.GetFileName(i));

                }

            }

        }
        else
        {
                if (Config.isKW || Config.isCNC)
                {
                    main.StartInfo.FileName = "RetailExe\\" + game;
                }
                else if (Config.isRA || Config.isUprising)
                {
                    main.StartInfo.FileName = "data\\" + game;
                }
               
            Console.WriteLine("Orignial Game File: " + main.StartInfo.FileName);
        }

        Config.md5 = Config.getMd5(main.StartInfo.FileName);

        main.StartInfo.Arguments = command.ToString();
            Console.WriteLine("Process Information-Exe:" + main.StartInfo.FileName+"|Arguments:"+main.StartInfo.Arguments+"|Result:\n"+main.StartInfo.FileName+main.StartInfo.Arguments);

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