
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ra3_Mod_Manager
{
    public partial class Controller : Form
    {



        public SoundPlayer player = new SoundPlayer();



        public Controller()
        {



            InitializeComponent();
            Config.btn_mb = btn_StartGame.FlatAppearance.MouseOverBackColor;
            Config.btn_db = btn_StartGame.FlatAppearance.MouseDownBackColor;

            buildLanguage(loc.current);

            refreshLanguage(loc.current);
            Config.defaultIcon = this.Icon;

            media_video.settings.autoStart = false;
            media_video.fullScreen = false;
            media_video.Enabled = false;

            //this.media_video.stretchToFit = true;
            this.media_video.uiMode = "none";
            this.media_video.enableContextMenu = false;
            this.media_video.windowlessVideo = true;


            if (Config.dat_xres.Length > 0 && Config.dat_yres.Length > 0)
            {
                tb_Xres.Text = Config.dat_xres;
                tb_Yres.Text = Config.dat_yres;
            }

            cb_CustomResolution.Checked = Config.dat_cr;
            cb_Windowed.Checked = Config.dat_win;
            cb_Media.Checked = Config.dat_media;
            cb_bfs.Checked = Config.dat_bfs;


            bool haveData = false;
            for (int i = 0; i < Config.gameList.Count; i++)
            {
                this.lc_Game.Items.Insert(i, Config.gameList[i]);
                if (Config.gameList[i].Equals(Config.dat_game))
                {
                    haveData = true;
                    this.lc_Game.SelectedIndex = i;
                    this.lc_Game.SelectedText = Config.gameList[i];
                }


            }
            if (!haveData)
            {
                this.lc_Game.SelectedIndex = 0;
                this.lc_Game.SelectedText = Config.gameList[0];
            }
            haveData = false;

            for (int i = 0; i < Config.languageList.Count; i++)
            {
                this.lc_GameLanguage.Items.Insert(i, Config.languageList[i]);
                if (Config.languageList[i].Equals(Config.dat_language))
                {
                    haveData = true;
                    this.lc_GameLanguage.SelectedIndex = i;
                    this.lc_GameLanguage.SelectedText = Config.languageList[i];
                }

            }
            if (!haveData)
            {
                this.lc_GameLanguage.SelectedIndex = 0;
                this.lc_GameLanguage.SelectedText = Config.languageList[0];
            }

            haveData = false;

            //refreshResource();
            resetSkudefList(lc_Game.SelectedIndex);
            if (Config.isFirstTime)
            {
                writeDAT();
            }

           



        }

        private void writeDAT()
        {
            Config.writeDAT(Application.StartupPath + "\\"+Config.configFile,cb_Windowed.Checked, cb_CustomResolution.Checked, tb_Xres.Text, tb_Yres.Text, lc_Game.Text, lc_Version.Text, lc_GameLanguage.Text, Config.modPath, cb_Media.Checked, loc.current,cb_bfs.Checked);
        }

        private void buildLanguage(int i)
        {
            lc_loc.Items.Clear();

            for (int x = 0; x < loc.inf.Length; x++)
            {

                lc_loc.Items.Add(loc.inf[x]);

            }

            lc_loc.SelectedIndex = i;
            lc_loc.SelectedText = loc.inf[i];


        }

        private void refreshLanguage(int i)
        {
            if (lc_Game.Text.Equals(Config.gameName))
            {
                this.Text = Config.extraTitle + loc.con_title[i];
            }
            this.btn_Information.Text = loc.btn_information[i];
            this.btn_ModFolder.Text = loc.btn_modfolder[i];
            this.btn_RA3UI.Text = loc.btn_ra3ui[i];
            this.btn_SaveOption.Text = loc.btn_saveoption[i];
            this.btn_StartGame.Text = loc.btn_startgame[i];
            this.btn_website.Text = loc.btn_website[i];
            this.cb_CustomResolution.Text = loc.cb_customresolution[i];
            this.cb_Windowed.Text = loc.cb_windowed[i];
            this.cb_Media.Text = loc.cb_media[i];
            this.lb_Game.Text = loc.lb_game[i];
            this.lb_Version.Text = loc.lb_version[i];
            this.lb_Width.Text = loc.lb_width[i];
            this.lb_Height.Text = loc.lb_height[i];
            this.cb_bfs.Text = loc.cb_bfs[i];
            this.btn_document.Text = loc.btn_document[i];
            this.btn_map.Text = loc.btn_map[i];
            this.btn_short.Text = loc.btn_shortcut[i];




        }

        public void refreshResource()
        {
            player.Stop();
            this.media_video.Ctlcontrols.stop();
            media_video.Visible = false;




            if (lc_Game.Text.Equals(Config.gameName))
            {

                //if (!Config.isCustomImageMode) { 
                Config.currentImage[0] = Config.originalImage[0];
                Config.currentImage[1] = Config.originalImage[1];
                //}

                this.BackgroundImage = Config.currentImage[0];
                this.Text = Config.extraTitle + loc.in_game[loc.current];

                this.Icon = Config.defaultIcon;


            }

            //if (!Config.isCustomImageMode)
            //{
            refreshMedia();

            Config.currentImage[0] = Config.originalImage[0];
            Config.currentImage[1] = Config.originalImage[1];

            String[] fileArray = { Config.modPath + "\\Controller", Config.modPath + "\\Splash" };
            String[] fileNameExtension = { ".png", ".jpg", ".jpeg", ".bmp" };

            for (int i = 0; i < fileArray.Length; i++)
            {
                for (int x = 0; x < fileNameExtension.Length; x++)
                {
                    String path = fileArray[i] + fileNameExtension[x];

                    if (File.Exists(path))
                    {
                        Config.currentImage[i] = new Bitmap(path);
                        break;
                    }
                }
            }
            // }


            try
            {

                this.BackgroundImage = Config.currentImage[0];
            }
            catch (System.Exception e)
            {


                MessageBox.Show(e.ToString(), loc.in_execption[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                this.BackgroundImage = null;
            }

            String titlePath = Config.modPath + "\\Title.txt";
            String iconPath = Config.modPath + "\\icon.ico";

            if (lc_Game.Text.Equals(Config.gameName))
            {
                Debug.Write("Get Game Icon!");

                if (Config.isDLC)
                {
                    iconPath = Application.StartupPath + "\\ra3ep1.ico";
                }
                else
                {
                    iconPath = Application.StartupPath + "\\ra3.ico";
                }
            }



            if (File.Exists(iconPath))
            {
                this.Icon = new Icon(iconPath);
            }
            else
            {
                this.Icon = Config.defaultIcon;
            }



            if (File.Exists(titlePath))
            {
                String titleStr = Config.readFirstLine(titlePath);
                this.Text = Config.extraTitle + titleStr;

            }
            else
            {
                if (lc_Game.Text == Config.gameName)
                {
                    this.Text = Config.extraTitle + loc.in_game[loc.current];
                }
                else
                {

                    this.Text = Config.extraTitle + lc_Game.Text;
                }
            }


            String btnImagePath = Config.modPath + "\\button.png";
            String fontColorPath = Config.modPath + "\\font.color.txt";
            //String componentColorPath = Config.modPath + "\\component.color.txt";
            Color fontColor = Color.White;
            Color componentColor = Color.White;
            Config.btnImage = null;
            if (File.Exists(btnImagePath))
            {
                Config.btnImage = new Bitmap(btnImagePath);

                if (File.Exists(Config.modPath + "\\button.enter.png"))
                {
                    Config.btnImageMove = new Bitmap(Config.modPath + "\\button.enter.png");
                }
                else
                {
                    Config.btnImageMove = Config.btnImage;
                }
                if (File.Exists(Config.modPath + "\\button.click.png"))
                {
                    Config.btnImageClick = new Bitmap(Config.modPath + "\\button.click.png");
                }
                else
                {
                    Config.btnImageClick = Config.btnImage;
                }

                if (File.Exists(Config.modPath + "\\button.click.wav"))
                {
                    Config.btnAudioClick = Config.modPath + "\\button.click.wav";
                    Debug.WriteLine("Get Button Click Audio:" + Config.btnAudioClick);

                }
                else { Config.btnAudioClick = ""; }

                if (File.Exists(Config.modPath + "\\button.enter.wav"))
                {
                    Config.btnAudioMove = Config.modPath + "\\button.enter.wav";
                    Debug.WriteLine("Get Button Enter Audio:" + Config.btnAudioMove);
                }
                else { Config.btnAudioMove = ""; }


                if (File.Exists(fontColorPath))
                {
                    String get = Config.readFirstLine(fontColorPath);
                    String[] cg = get.Split(',');

                    if (cg.Length == 4)
                    {

                        int a = 0, r = 0, g = 0, b = 0;

                        a = int.Parse(cg[0]);
                        Debug.WriteLine("Font Color Alpha:" + a);
                        r = int.Parse(cg[1]);
                        Debug.WriteLine("Font Color Red:" + r);
                        g = int.Parse(cg[2]);
                        Debug.WriteLine("Font Color Green:" + g);
                        b = int.Parse(cg[3]);
                        Debug.WriteLine("Font Color Blue:" + b);

                        fontColor = Color.FromArgb(a, r, g, b);
                    }
                }
                /*
                if (File.Exists(componentColorPath))
                {
                    String get = Config.readFirstLine(componentColorPath);
                    String[] cg = get.Split(',');

                    if (cg.Length == 4)
                    {

                        int a = 0, r = 0, g = 0, b = 0;

                        a = int.Parse(cg[0]);
                        Debug.WriteLine("Component Color Alpha:" + a);
                        r = int.Parse(cg[1]);
                        Debug.WriteLine("Component Color Red:" + r);
                        g = int.Parse(cg[2]);
                        Debug.WriteLine("Component Color Green:" + g);
                        b = int.Parse(cg[3]);
                        Debug.WriteLine("Component Color Blue:" + b);

                        componentColor = Color.FromArgb(a, r, g, b);
                    }
                }
                */


            }
            else
            {
                resetCom();

            }



            if (Config.btnImage != null)
            {



                foreach (var control in this.Controls)
                {
                    if (control.GetType().Name.Equals("Button"))
                    {
                        Button i = control as Button;

                        i.BackgroundImage = Config.btnImage;
                        i.ForeColor = fontColor;
                        i.FlatStyle = FlatStyle.Flat;

                        i.FlatAppearance.MouseOverBackColor = Color.Transparent;
                        i.FlatAppearance.MouseDownBackColor = Color.Transparent;

                        i.MouseEnter += btn_Image_MouseEnter;
                        i.MouseLeave += btn_Image_MouseLeave;
                        i.MouseDown += btn_Image_MouseDown;
                        i.MouseUp += btn_Image_MouseUp;


                    }
                    else if (control.GetType().Name.Equals("ComboBox"))
                    {
                        ComboBox i = control as ComboBox;




                    }
                    else if (control.GetType().Name.Equals("CheckBox"))
                    {
                        CheckBox i = control as CheckBox;
                        i.ForeColor = fontColor;


                    }
                    else if (control.GetType().Name.Equals("TextBox"))
                    {
                        TextBox i = control as TextBox;



                    }
                    else if (control.GetType().Name.Equals("Label"))
                    {
                        Label i = control as Label;

                        i.ForeColor = fontColor;

                    }


                }

            }
        }





        private void resetCom()
        {

            foreach (var control in this.Controls)
            {
                if (control.GetType().Name.Equals("Button"))
                {
                    Button i = control as Button;

                    i.BackgroundImage = null;
                    i.ForeColor = Color.Black;
                    i.FlatStyle = FlatStyle.Standard;

                    i.FlatAppearance.MouseOverBackColor = Config.btn_mb;
                    i.FlatAppearance.MouseDownBackColor = Config.btn_db;

                    i.MouseEnter -= btn_Image_MouseEnter;
                    i.MouseLeave -= btn_Image_MouseLeave;
                    i.MouseDown -= btn_Image_MouseDown;
                    i.MouseUp -= btn_Image_MouseUp;


                }
                else if (control.GetType().Name.Equals("ComboBox"))
                {
                    ComboBox i = control as ComboBox;


                }
                else if (control.GetType().Name.Equals("CheckBox"))
                {
                    CheckBox i = control as CheckBox;

                    i.ForeColor = Color.White;
                }
                else if (control.GetType().Name.Equals("TextBox"))
                {
                    TextBox i = control as TextBox;
                }
                else if (control.GetType().Name.Equals("Label"))
                {
                    Label i = control as Label;

                    i.ForeColor = Color.White;
                }

            }
        }
        private void refreshMedia()
        {



            String bgmPath = Config.modPath + "\\bgm.wav";
            String videoPath = Config.modPath + "\\video.wmv";
            String configPath = Config.modPath + "\\loop.txt";
            String conf = "";
            if (cb_Media.Checked && File.Exists(configPath))
            {
                
                conf = Config.readFirstLine(configPath).ToLower();

            }


            if (File.Exists(videoPath))
            {
                media_video.URL = videoPath;
                media_video.Ctlcontrols.stop();

                if (cb_Media.Checked)
                {
                    media_video.Visible = true;

                    if (conf.IndexOf("video") != -1)
                    {

                        Debug.WriteLine("Loop Video!");

                        media_video.settings.setMode("loop", true);
                    }
                    else
                    {
                        media_video.settings.setMode("loop", false);

                    }
                    media_video.Ctlcontrols.play();

                }
                else
                {
                    media_video.Visible = false;
                    media_video.Ctlcontrols.stop();
                }

            }
            else
            {
                media_video.Visible = false;
            }


            if (File.Exists(bgmPath))
            {
                player.SoundLocation = bgmPath;

                if (cb_Media.Checked)
                {

                    player.Load();

                    if (conf.IndexOf("audio") != -1)
                    {
                        Debug.WriteLine("Loop Audio!");
                        player.PlayLooping();
                    }
                    else
                    {

                        player.Play();
                    }



                }
                else
                {
                    player.Stop();
                }

            }








        }



        private void btn_StartGame_Click(object sender, EventArgs e)
        {

            player.Stop();
            media_video.Ctlcontrols.stop();

            if (!Config.canSkip) { 
            new Thread((ThreadStart)delegate
            {
                Application.Run(new Splash_Form());
            }


        ).Start();
            }

            startGameByProcess();

            writeDAT();




            //this.Close();
        }




        private void startGameByProcess()
        {
            //Process p = new Process();

            String targetMod = lc_Game.Text;
            String targetSkudef = lc_Version.Text + ".skudef";
            String targetVersion = lc_Version.Text;
            StringBuilder command = new StringBuilder("");

            Debug.WriteLine("Confirm Game:" + targetMod);
            Debug.WriteLine("Confirm Version:" + targetVersion);

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

                    Debug.WriteLine("Need Use Desktop Resolution");

                }

                if (xres.Length > 0 && yres.Length > 0)
                {
                    command.Append(" -xres " + xres + " -yres " + yres);
                }
            }


            String game = "ra3_1.0.game";
            if (Config.isDLC)
            {
                game = "ra3ep1_1.0.game";
            }
            String customGame = "";
            if (targetMod.Equals(Config.gameName))
            {

                if (!Config.isDLC)
                {
                    targetSkudef = "ra3_" + lc_GameLanguage.Text + "_" + targetVersion + ".skudef";
                    game = "ra3_" + targetVersion + ".game";
                }
                else
                {
                    targetSkudef = "ra3ep1_" + lc_GameLanguage.Text + "_" + targetVersion + ".skudef";
                    game = "ra3ep1_" + targetVersion + ".game";
                }




                command.Append(" -config \"" + Application.StartupPath + "\\" + targetSkudef + "\"");
            }
            else
            {

                String modGame = Config.readFirstLine(Config.modPath + "\\" + targetSkudef);

                /*
                String customGamePath = Config.modPath + "\\game.txt";

                if (File.Exists(customGamePath))
                {
                    customGame = Config.readFirstLine(customGamePath);

                }
                */

                if (modGame.Length <= 0 || modGame.IndexOf("mod-game") == -1)
                {
                    modGame = "1.12";
                    Debug.WriteLine("Unknown Mod Game Start Version:Set to" + modGame);
                    targetSkudef = "ra3_" + lc_GameLanguage.Text + "_" + modGame + ".skudef";
                    game = "ra3_" + modGame + ".game";
                    command.Append(" -config \"" + Application.StartupPath + "\\" + targetSkudef + "\"");

                }
                else
                {
                    modGame = modGame.Substring(modGame.LastIndexOf("mod-game") + 8).Trim();
                    customGame = modGame;
                    Debug.WriteLine("Mod Game Start Version:" + modGame);
                    String targetModSkudef = "ra3_" + lc_GameLanguage.Text + "_" + modGame + ".skudef";
                    game = "ra3_" + modGame + ".game";
                    command.Append(" -config \"" + Application.StartupPath + "\\" + targetModSkudef + "\"");
                    command.Append(" -modConfig \"" + Config.modPath + "\\" + targetSkudef + "\"");
                }



            }

            Debug.WriteLine("Start Game:" + Application.StartupPath + "\\data\\" + game + command);

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



            if (File.Exists(Config.modPath + "\\" + "ra3_" + customGame + ".game"))
            {

                main.StartInfo.FileName = Config.modPath + "\\" + "ra3_" + customGame + ".game";
                Debug.WriteLine("Custom Game File: " + main.StartInfo.FileName);

                if (!Directory.Exists(Config.modPath + "\\Data\\Cursors"))
                {
                    Directory.CreateDirectory(Config.modPath + "\\Data\\Cursors");

                    String[] fg = Directory.GetFiles(Application.StartupPath + "\\Data\\Data\\Cursors", "*.ani", SearchOption.TopDirectoryOnly);

                    foreach (var i in fg)
                    {

                        File.Copy(i, Config.modPath + "\\Data\\Cursors\\" + Path.GetFileName(i));

                    }

                }


            }
            else
            {

                main.StartInfo.FileName = "data\\" + game;
                Debug.WriteLine("Orignial Game File: " + main.StartInfo.FileName);
            }
            Config.md5 = Config.getMd5(main.StartInfo.FileName);
            main.StartInfo.Arguments = command.ToString();
            //main.StartInfo.CreateNoWindow = true;


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


        private void numberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }



        private void cb_CustomResolution_CheckedChanged(object sender, EventArgs e)
        {

            Config.dat_cr = cb_CustomResolution.Checked;

            if (!cb_CustomResolution.Checked)
            {
                tb_Xres.Enabled = false;
                tb_Yres.Enabled = false;
            }
            else
            {
                tb_Xres.Enabled = true;
                tb_Yres.Enabled = true;
            }

        }

        private void lc_Game_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetSkudefList(lc_Game.SelectedIndex);

            if (lc_Game.Text.Equals(Config.gameName))
            {
                Config.dat_game = lc_Game.Text;
                Config.modPath = Application.StartupPath + "\\Launcher" + "\\Custom";
                resetCom();
            }

            refreshResource();

        }

        private void btn_RA3UI_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            if (!Config.isDLC)
            {
                p.StartInfo.FileName = "Ra3.exe";
            }
            else
            {
                p.StartInfo.FileName = "RA3EP1.exe";
            }
            p.StartInfo.Arguments = "-ui";
            p.Start();
        }


        private void resetSkudefList(int index)
        {
            lc_Version.Items.Clear();

            List<String> availiable = new List<String>();
            List<String> notSortedList = new List<String>();
            for (int i = 0; i < Config.skudefList[index].Length; i++)
            {
                bool isAlive = false;
                String temp = Config.skudefList[index][i];

                if (lc_Game.Text.Equals(Config.gameName))
                {
                    temp = temp.Substring(temp.LastIndexOf('_') + 1);

                }


                for (int x = 0; x < availiable.Count; x++)
                {
                    if (availiable[x].Equals(temp))
                    {
                        isAlive = true;
                        break;
                    }

                }

                if (!isAlive)
                {

                    notSortedList.Add(temp);
                    availiable.Add(temp);
                }
            }

            notSortedList.Sort(skudefSort);

            bool haveDAT = false;
            for (int i = 0; i < notSortedList.Count; i++)
            {

                this.lc_Version.Items.Insert(i, notSortedList[i]);

                if (notSortedList[i].Equals(Config.dat_version))
                {
                    this.lc_Version.SelectedIndex = i;
                    this.lc_Version.SelectedText = notSortedList[i];
                    haveDAT = true;
                }


            }

            if (!haveDAT)
            {

                this.lc_Version.SelectedIndex = 0;
                this.lc_Version.SelectedText = Config.gameList[0];
            }
        }


        private int skudefSort(String a, String b)
        {
            int al = 0;
            int bl = 0;
            char[] ac = a.ToCharArray();
            char[] bc = b.ToCharArray();
            for (int i = 0; i < ac.Length; i++)
            {
                al += ac[i];
            }
            for (int i = 0; i < bc.Length; i++)
            {
                bl += bc[i];
            }



            return al > bl ? -1 : al < bl ? 1 : 0;

        }

        private void lc_Version_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lc_Game.Text.Equals(Config.gameName) && Config.runMode == 0)
            {
                Config.dat_version = lc_Version.Text;
                Config.modPath = Config.modPathList[lc_Game.SelectedIndex];
                Debug.WriteLine("Choose New Mod:" + Config.modPath);
            }
        }

        private void lb_GameLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.dat_language = lc_GameLanguage.Text;
        }



        private void btn_Information_Click(object sender, EventArgs e)
        {

            if (lc_Game.Text.Equals(Config.gameName))
            {
                MessageBox.Show(loc.in_author[loc.current], loc.in_information[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Process informationTXT = new Process();

                String txt = Config.modPath + "\\information.txt";
                if (File.Exists(txt))
                {

                    informationTXT.StartInfo.FileName = txt;
                    informationTXT.Start();
                }
                else
                {
                    MessageBox.Show(loc.in_noinf[loc.current], loc.in_information[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }

        }

        private void btn_website_Click(object sender, EventArgs e)
        {
            if (lc_Game.Equals(Config.gameName))
            {
                Process.Start("https://www.ea.com/zh-cn/games/command-and-conquer");

            }
            else
            {
                String href = Config.modPath + "\\website.txt";
                if (File.Exists(href))
                {
                    Process.Start(Config.readFirstLine(href));

                }
                else
                {
                    Process.Start("https://www.ea.com/zh-cn/games/command-and-conquer");
                }
            }
        }

        private void btn_SaveOption_Click(object sender, EventArgs e)
        {
            writeDAT();

        }

        private void cb_Media_CheckedChanged(object sender, EventArgs e)
        {

            Config.dat_media = cb_Media.Checked;

            refreshMedia();

        }

        private void btn_ModFolder_Click(object sender, EventArgs e)
        {

            if (lc_Game.Text.Equals(Config.gameName))
            {
                Process.Start("explorer.exe", Application.StartupPath);
            }
            else
            {

                Process.Start("explorer.exe", Config.modPathList[lc_Game.SelectedIndex]);
            }

        }






        private void btn_Image_MouseDown(object sender, EventArgs e)
        {
            var i = sender as Button;

            i.BackgroundImage = Config.btnImageClick;


            if (!cb_Media.Checked && Config.btnAudioClick.Length > 0)
            {

                player.SoundLocation = Config.btnAudioClick;
                player.Load();
                player.Play();

            }

        }

        private void btn_Image_MouseUp(object sender, EventArgs e)
        {
            var i = sender as Button;

            i.BackgroundImage = Config.btnImage;




        }


        private void btn_Image_MouseEnter(object sender, EventArgs e)
        {
            var i = sender as Button;

            i.BackgroundImage = Config.btnImageMove;


            if (!cb_Media.Checked && Config.btnAudioMove.Length > 0)
            {
                player.SoundLocation = Config.btnAudioMove;
                player.Load();
                player.Play();

            }

        }

        private void btn_Image_MouseLeave(object sender, EventArgs e)
        {

            var i = sender as Button;

            i.BackgroundImage = Config.btnImage;


        }

        private void lc_loc_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lc_loc.SelectedIndex != loc.current)
            {

                loc.current = lc_loc.SelectedIndex;
                Config.dat_loc = loc.current;

                refreshLanguage(loc.current);
            }
        }

        private void Controller_Load(object sender, EventArgs e)
        {

        }

        private void cb_bfs_CheckedChanged(object sender, EventArgs e)
        {

            Config.dat_bfs = cb_bfs.Checked;
            /*
            if (cb_bfs.Checked)
            {
                
                cb_CustomResolution.Checked = false;
                cb_Windowed.Checked = true;
                
                cb_Windowed.Enabled = false;
                cb_CustomResolution.Enabled = false;

            }
            else
            {
                cb_Windowed.Enabled = true;
                cb_CustomResolution.Enabled = true;
            }
            */
        }

        private void cb_Windowed_CheckedChanged(object sender, EventArgs e)
        {
            Config.dat_win = cb_Windowed.Checked;
        }

        private void tb_Xres_TextChanged(object sender, EventArgs e)
        {
            Config.dat_xres = tb_Xres.Text;
        }

        private void tb_Yres_TextChanged(object sender, EventArgs e)
        {
            Config.dat_yres = tb_Yres.Text;
        }

        private void btn_document_Click(object sender, EventArgs e)
        {

            String dir;
            if (Config.gameName.Equals("Uprising"))
            {
                dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Red Alert 3 Uprising\\";
            }
            else
            {
                dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Red Alert 3\\";

            }

            if (Directory.Exists(dir))
            {
                Process.Start("explorer.exe", dir);
            }
            else
            {
                MessageBox.Show(loc.in_notDir[loc.current] + dir, loc.in_error[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_map_Click(object sender, EventArgs e)
        {
            String dir;
            if (Config.gameName.Equals("Uprising"))
            {
                dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Red Alert 3 Uprising\\";
            }
            else
            {
                dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Red Alert 3\\";
                
            }

            if (Directory.Exists(dir))
            {
                Process.Start("explorer.exe", dir);
            }
            else
            {
                MessageBox.Show(loc.in_notDir[loc.current] + dir, loc.in_error[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            


        }

        private void btn_short_Click(object sender, EventArgs e)
        {

            Directory.CreateDirectory(Application.StartupPath + "\\Custom.dat");

            int i = 0;
            int sum = 0;
            StringBuilder command = new StringBuilder();
            StringBuilder desc = new StringBuilder();
            StringBuilder name = new StringBuilder();

            name.Append(lc_Game.Text);
            name.Append(' ');
            name.Append(lc_Version.Text);
            //name.Append(' ');
            //name.Append(lc_GameLanguage.Text);

            sum += i + (cb_Windowed.Checked?1:0);

            if (cb_Windowed.Checked && !cb_bfs.Checked)
            {
                desc.Append(cb_Windowed.Text);
                desc.Append(' ');
            }

            sum += ++i + (cb_CustomResolution.Checked ? 1 : 0);

            if (cb_CustomResolution.Checked && !cb_bfs.Checked)
            {
                desc.Append(cb_CustomResolution.Text);
                desc.Append(' ');
                desc.Append(lb_Width.Text);
                desc.Append(tb_Xres.Text);
                desc.Append(' ');
                desc.Append(lb_Height.Text);
                desc.Append(tb_Yres.Text);

            }

            sum += ++i + Convert.ToInt32(tb_Xres.Text);
            sum += ++i + Convert.ToInt32(tb_Yres.Text);
           for(int x = 0; x < lc_Game.Text.Length; x++)
            {
                sum += ++i + lc_Game.Text[x];
            }
            desc.Append(' ');
            desc.Append(lb_Game.Text);
            desc.Append(lc_Game.Text);
            for (int x = 0; x < lc_Version.Text.Length; x++)
            {
                sum += ++i + lc_Version.Text[x];
            }
            desc.Append(' ');
            desc.Append(lb_Version.Text);

            desc.Append(lc_Version.Text);
            for (int x = 0; x < lc_GameLanguage.Text.Length; x++)
            {
                sum += ++i + lc_GameLanguage.Text[x];
            }
            desc.Append(' ');
            desc.Append(lc_GameLanguage.Text);
            for (int x = 0; x < Config.modPath.Length; x++)
            {
                sum += ++i + Config.modPath[x];
            }
            sum += ++i + (cb_Media.Checked ? 1 : 0);

            if (cb_Media.Checked)
            {
                desc.Append(' ');
                desc.Append(cb_Media.Text);
            }


            sum += ++i + loc.current;
            sum += ++i + (cb_bfs.Checked ? 1 : 0);

            if (cb_bfs.Checked)
            {
                desc.Append(' ');
                desc.Append(cb_bfs.Text);
            }


            String xname = Convert.ToString(sum);
            StringBuilder sb = new StringBuilder();
            for (int x =  xname.Length; x < 10; x++)
            {
                sb.Append('0');

            }
            sb.Append(xname);

            command.Append(" -dat");
            command.Append(sb.ToString());

            sb.Append(".dat");


            
            Config.writeDAT(Application.StartupPath + "\\Custom.dat\\" + sb.ToString(), cb_Windowed.Checked, cb_CustomResolution.Checked, tb_Xres.Text, tb_Yres.Text, lc_Game.Text, lc_Version.Text, lc_GameLanguage.Text, Config.modPath, cb_Media.Checked, loc.current, cb_bfs.Checked);


            
            if (Config.canInj) {
                command.Append(" -script");
            }
            if (Config.canHook)
            {
                command.Append(" -hook");
            }
            if (Config.canSkip)
            {
                command.Append(" -skip");
            }
            desc.Append(command.ToString());
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\"+name+".lnk");
            Debug.WriteLine("Create Lnk:" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"\\"+ name + ".lnk");
            shortcut.Arguments = command.ToString();
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.WindowStyle = 1;
            shortcut.Description = desc.ToString();



            String iconPath = Config.modPath + "\\icon.ico";

            if (lc_Game.Text.Equals(Config.gameName))
            {
                Debug.Write("Get Game Icon!");

                if (Config.isDLC)
                {
                    iconPath = Application.StartupPath + "\\ra3ep1.ico";
                }
                else
                {
                    iconPath = Application.StartupPath + "\\ra3.ico";
                }
            }



            if (File.Exists(iconPath))
            {
                
            }
            else
            {
                iconPath = Application.StartupPath + "\\ra3ep1.ico";
                if (File.Exists(iconPath))
                {

                }
                else
                {
                    iconPath = Application.StartupPath + "\\ra3.ico";
                    if (File.Exists(iconPath))
                    {

                    }
                    else
                    {
                        iconPath = Application.ExecutablePath;
                    }
                }

            }





            shortcut.IconLocation = iconPath;
            shortcut.Save();

        }


    }

}
