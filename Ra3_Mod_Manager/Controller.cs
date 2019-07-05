
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


        public void SetCursor(Bitmap cursor, Point hotPoint)
        {
            int PX = hotPoint.X;
            int PY = hotPoint.Y;
            Bitmap myNewCursor = new Bitmap(cursor.Width * 2 - PX, cursor.Height * 2 - PY);
            Graphics g = Graphics.FromImage(myNewCursor);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.DrawImage(cursor, cursor.Width - PX, cursor.Height - PY, cursor.Width,
            cursor.Height);
            Cursor StyleCursor = new Cursor(myNewCursor.GetHicon());
            this.Cursor = StyleCursor;


            g.Dispose();
            myNewCursor.Dispose();
        }

        public void SetCursorForButton(Bitmap cursor, Point hotPoint)
        {
            int PX = hotPoint.X;
            int PY = hotPoint.Y;
            Bitmap myNewCursor = new Bitmap(cursor.Width * 2 - PX, cursor.Height * 2 - PY);
            Graphics g = Graphics.FromImage(myNewCursor);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.DrawImage(cursor, cursor.Width - PX, cursor.Height - PY, cursor.Width,
            cursor.Height);
            Cursor StyleCursor = new Cursor(myNewCursor.GetHicon());
            
            foreach(Control control in this.Controls)
            {

                if (control.Controls != null && (control is Button || control is CheckBox || control is ComboBox))
                {
                    control.Cursor = StyleCursor;
                }

            }


            g.Dispose();
            myNewCursor.Dispose();
        }

        public void SetCursorForText(Bitmap cursor, Point hotPoint)
        {
            int PX = hotPoint.X;
            int PY = hotPoint.Y;
            Bitmap myNewCursor = new Bitmap(cursor.Width * 2 - PX, cursor.Height * 2 - PY);
            Graphics g = Graphics.FromImage(myNewCursor);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.DrawImage(cursor, cursor.Width - PX, cursor.Height - PY, cursor.Width,
            cursor.Height);
            Cursor StyleCursor = new Cursor(myNewCursor.GetHicon());

            foreach (Control control in this.Controls)
            {

                if (control.Controls != null && control is TextBox)
                {
                    control.Cursor = StyleCursor;
                }

            }


            g.Dispose();
            myNewCursor.Dispose();
        }


        private void writeDAT()
        {
            Config.writeDAT(Application.StartupPath + "\\"+Config.configFile,cb_Windowed.Checked, cb_CustomResolution.Checked, tb_Xres.Text, tb_Yres.Text, lc_Game.Text, lc_Version.Text, lc_GameLanguage.Text, Config.modPath, cb_Media.Checked, loc.current,cb_bfs.Checked,Config.dat_mouse_locked,Config.dat_mouse_dynamic,loc.dat_desc[loc.current]);
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
            this.ExtraConfig.Text = loc.btn_extra[i];
            this.btn_author.Text = loc.btn_author[i];






        }


        public static void printText()
        {





            String firstOpenPath = Config.modPath + "\\Support\\first.txt";
            Console.WriteLine("Search First Time:" + firstOpenPath);
            if (File.Exists(firstOpenPath))
            {

                Console.WriteLine("First Time:" + firstOpenPath);
                //Process.Start(Config.modPath + "\\Support\\");
                //Process.Start("notepad.exe",Config.modPath + "\\Support\\readme_" +loc.inf[loc.current]);
                //File.Delete(firstOpenPath);

                Description form_desc = new Description();
                form_desc.isText = true;
                form_desc.needChecked = true;
                form_desc.address = Config.modPath + "\\Support\\readme_" + loc.inf[loc.current] + ".txt";
                form_desc.deleteFilename = firstOpenPath;
                form_desc.ShowDialog();


                //this.Cursor = Cursors.Default;
                //this.Cursor = Cursors.WaitCursor;
            }


            String UpdateOpenPath = Config.modPath + "\\Support\\new.txt";
            Console.WriteLine("Search Update:" + UpdateOpenPath);

            if (File.Exists(UpdateOpenPath))
            {

                Console.WriteLine("New Update:" + UpdateOpenPath);
                //Process.Start("notepad.exe", Config.modPath + "\\Support\\update_" + loc.inf[loc.current]);
                // File.Delete(UpdateOpenPath);
                Description form_desc = new Description();
                form_desc.isText = true;
                form_desc.needChecked = true;
                form_desc.address = Config.modPath + "\\Support\\update_" + loc.inf[loc.current] + ".txt";
                form_desc.deleteFilename = UpdateOpenPath;
                form_desc.ShowDialog();


                //this.Cursor = Cursors.Default;
                //this.Cursor = Cursors.WaitCursor;
            }
        }


        public void refreshResource()
        {
            Program.checkImageExists();

            player.Stop();
            this.media_video.Ctlcontrols.stop();
            media_video.Visible = false;


            printText();








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

            String[] fileArray = { Config.modPath + "\\launcher\\Controller", Config.modPath + "\\launcher\\Splash", Config.modPath + "\\launcher\\"+loc.infcode[loc.current]+"_Controller", Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_Splash" };
            String[] fileNameExtension = { ".png", ".jpg", ".jpeg", ".bmp" , ".gif" };

            for (int i = 0; i < fileArray.Length; i++)
            {
                for (int x = 0; x < fileNameExtension.Length; x++)
                {
                    String path = fileArray[i] + fileNameExtension[x];

                    if (File.Exists(path))
                    {
                        Config.currentImage[i %2] = new Bitmap(path);
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

            String titlePath = Config.modPath + "\\launcher\\Title.txt";
            String titleLangPath = Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_Title.txt";
            String iconPath = Config.modPath + "\\launcher\\icon.ico";
            String iconLangPath = Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_icon.ico";

            if (lc_Game.Text.Equals(Config.gameName))
            {
                Console.Write("Get Game Icon!");

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
                if (File.Exists(iconLangPath))
                {
                    iconPath = iconLangPath;
                }

                this.Icon = new Icon(iconPath);
            }
            else
            {
                this.Icon = Config.defaultIcon;
            }



            if (File.Exists(titlePath))
            {

                if (File.Exists(titleLangPath))
                {
                    titlePath = titleLangPath;
                }


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


            String btnImagePath = Config.modPath + "\\launcher\\button.png";
            String fontColorPath = Config.modPath + "\\launcher\\font.color.txt";

            String btnLangImagePath = Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_button.png";
            String fontLangColorPath = Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_font.color.txt";

            //String componentColorPath = Config.modPath + "\\component.color.txt";
            Color fontColor = Color.White;
            Color componentColor = Color.White;
            Config.btnImage = null;
            if (File.Exists(btnImagePath))
            {

                if (File.Exists(btnLangImagePath))
                {
                    btnImagePath = btnLangImagePath;
                }

                Config.btnImage = new Bitmap(btnImagePath);

                if (File.Exists(Config.modPath + "\\launcher\\button.enter.png"))
                {
                    if(File.Exists(Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_button.enter.png"))
                    {
                        Config.btnImageMove = new Bitmap(Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_button.enter.png");
                    }
                    else
                    {

                    
                    

                    Config.btnImageMove = new Bitmap(Config.modPath + "\\launcher\\button.enter.png");

                    }

                }
                else
                {
                    Config.btnImageMove = Config.btnImage;
                }
                if (File.Exists(Config.modPath + "\\launcher\\button.click.png"))
                {

                    if (File.Exists(Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_button.click.png"))
                    {
                        Config.btnImageClick = new Bitmap(Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_button.click.png");
                    }
                    else
                    {

                    



                    Config.btnImageClick = new Bitmap(Config.modPath + "\\launcher\\button.click.png");

                    }
                }
                else
                {
                    Config.btnImageClick = Config.btnImage;
                }

                if (File.Exists(Config.modPath + "\\launcher\\button.click.wav"))
                {


                    if (File.Exists(Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_button.click.wav"))
                    {
                        Config.btnAudioClick = Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_button.click.wav";
                    }
                    else
                    {

                    

                    Config.btnAudioClick = Config.modPath + "\\launcher\\button.click.wav";
                    }
                    Console.WriteLine("Get Button Click Audio:" + Config.btnAudioClick);

                }
                else { Config.btnAudioClick = ""; }

                if (File.Exists(Config.modPath + "\\launcher\\button.enter.wav"))
                {



                    if (File.Exists(Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_button.enter.wav"))
                    {
                        Config.btnAudioMove = Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_button.enter.wav";
                    }
                    else
                    {

                    



                    Config.btnAudioMove = Config.modPath + "\\launcher\\button.enter.wav";
                    }
                    Console.WriteLine("Get Button Enter Audio:" + Config.btnAudioMove);
                }
                else { Config.btnAudioMove = ""; }


                if (File.Exists(fontColorPath))
                {

                    if (File.Exists(fontLangColorPath))
                    {
                        fontColorPath = fontLangColorPath;
                    }
                        

                    String get = Config.readFirstLine(fontColorPath);
                    String[] cg = get.Split(',');

                    if (cg.Length == 4)
                    {

                        int a = 0, r = 0, g = 0, b = 0;

                        a = int.Parse(cg[0]);
                        Console.WriteLine("Font Color Alpha:" + a);
                        r = int.Parse(cg[1]);
                        Console.WriteLine("Font Color Red:" + r);
                        g = int.Parse(cg[2]);
                        Console.WriteLine("Font Color Green:" + g);
                        b = int.Parse(cg[3]);
                        Console.WriteLine("Font Color Blue:" + b);

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
                            Console.WriteLine("Component Color Alpha:" + a);
                            r = int.Parse(cg[1]);
                            Console.WriteLine("Component Color Red:" + r);
                            g = int.Parse(cg[2]);
                            Console.WriteLine("Component Color Green:" + g);
                            b = int.Parse(cg[3]);
                            Console.WriteLine("Component Color Blue:" + b);

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




            String cursorPathDefault = Config.modPath + "\\Launcher\\cursor_default.png";
            String cursorPathPointer = Config.modPath + "\\Launcher\\cursor_pointer.png";
            String cursorPathText = Config.modPath + "\\Launcher\\cursor_text.png";

            String cursorLangPathDefault = Config.modPath + "\\Launcher\\"+loc.infcode[loc.current]+"_cursor_default.png";
            String cursorLangPathPointer = Config.modPath + "\\Launcher\\" + loc.infcode[loc.current] + "_cursor_pointer.png";
            String cursorLangPathText = Config.modPath + "\\Launcher\\" + loc.infcode[loc.current] + "_cursor_text.png";

            if (File.Exists(cursorPathDefault))
            {
                if (File.Exists(cursorLangPathDefault))
                {
                    cursorPathDefault = cursorLangPathDefault;
                }


                Config.cursorPath = cursorPathDefault;
                Console.WriteLine("Custom Cursor:" + Config.cursorPath);
                SetCursor((Bitmap)Bitmap.FromFile(Config.cursorPath), new Point(0, 0));
                //this.Cursor = Cursors.Default;
                //this.Cursor = Cursors.WaitCursor;
            }
            else
            {
                Config.cursorPath = "";
                Console.WriteLine("Normal Cursor:" + Config.cursorPath);
                this.Cursor = Cursors.Default;

            }

            if (File.Exists(cursorPathPointer))
            {

                if (File.Exists(cursorLangPathPointer))
                {
                    cursorPathPointer = cursorLangPathPointer;
                }

                Config.cursorPointerPath = cursorPathPointer;
                Console.WriteLine("Custom Pointer Cursor:" + Config.cursorPointerPath);
                SetCursorForButton((Bitmap)Bitmap.FromFile(Config.cursorPointerPath), new Point(0, 0));
                //this.Cursor = Cursors.Default;
                //this.Cursor = Cursors.WaitCursor;
            }
            else
            {
                Config.cursorPointerPath = "";
                Console.WriteLine("Normal Pointer Cursor:" + Config.cursorPointerPath);
                
                foreach(Control control in this.Controls)
                {
                    if(control.Controls != null && (control is Button || control is CheckBox || control is ComboBox))
                    {
                        control.Cursor = Cursors.Hand;
                    }
                }

            }


            if (File.Exists(cursorPathText))
            {
                if (File.Exists(cursorLangPathText))
                {
                    cursorPathText = cursorLangPathText;
                }

                Config.cursorTextPath = cursorPathText;
                Console.WriteLine("Custom Text Cursor:" + Config.cursorTextPath);
                SetCursorForText((Bitmap)Bitmap.FromFile(Config.cursorTextPath), new Point(0, 0));
                //this.Cursor = Cursors.Default;
                //this.Cursor = Cursors.WaitCursor;
            }
            else
            {
                Config.cursorTextPath = "";
                Console.WriteLine("Normal Text Cursor:" + Config.cursorTextPath);

                foreach (Control control in this.Controls)
                {
                    if (control.Controls != null && control is TextBox)
                    {
                        control.Cursor = Cursors.IBeam;
                    }
                }

            }


            String webPathX = Config.modPath + "\\web";
            String webLangPathX = Config.modPath + "\\web\\"+loc.infcode[loc.current];
            if (File.Exists(webPathX + "\\index.html"))
            {

                if (File.Exists(webLangPathX + "\\index.html"))
                {

                }

                Config.webPath = webPathX;
                Console.WriteLine("Get Website:" + Config.webPath);
                this.ExtraConfig.Visible = true;
                this.ExtraConfig.Enabled = true;
                Config.extraFirst=true;
            }
            else
            {
                Config.webPath = "";
                Console.WriteLine("No Website:" + Config.webPath);
                this.ExtraConfig.Visible = false;
                this.ExtraConfig.Enabled = false;
                //Config.extraFirst = false;
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



            String bgmPath = Config.modPath + "\\launcher\\bgm.wav";
            String bgmLangPath = Config.modPath + "\\launcher\\" + loc.infcode[loc.current] + "_bgm.wav";
            String videoPath = Config.modPath + "\\launcher\\video.wmv";
            String videoLangPath = Config.modPath + "\\launcher\\"+loc.infcode[loc.current]+"_video.wmv";


            String configPath = Config.modPath + "\\launcher\\loop.txt";
            String conf = "";
            if (cb_Media.Checked && File.Exists(configPath))
            {
                
                conf = Config.readFirstLine(configPath).ToLower();

            }


            if (File.Exists(videoPath))
            {

                if (File.Exists(videoLangPath))
                {
                    videoPath = videoLangPath;
                }

                media_video.URL = videoPath;
                media_video.Ctlcontrols.stop();

                if (cb_Media.Checked)
                {
                    media_video.Visible = true;

                    if (conf.IndexOf("video") != -1)
                    {

                        Console.WriteLine("Loop Video!");

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

                if (File.Exists(bgmLangPath))
                {
                    bgmPath = bgmLangPath;
                }

                player.SoundLocation = bgmPath;

                if (cb_Media.Checked)
                {

                    player.Load();

                    if (conf.IndexOf("audio") != -1)
                    {
                        Console.WriteLine("Loop Audio!");
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


                String customGamePath = Config.modPath + "\\launcher\\game.txt";

                Console.WriteLine("Read Main Game File Information:"+customGamePath);
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
                    command.Append(" -config \"" + Application.StartupPath + "\\" + targetSkudef + "\"");

                }
                else
                {
                    modGame = modGame.Substring(modGame.LastIndexOf("mod-game") + 8).Trim();
                    customGame = modGame;
                    Console.WriteLine("Mod Game Start Version:" + modGame);
                    String targetModSkudef = "ra3_" + lc_GameLanguage.Text + "_" + modGame + ".skudef";
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


            Console.WriteLine("Try to find:"+ Config.modPath + "\\" + customGame);
            if (File.Exists(Config.modPath + "\\" + customGame))
            {

                main.StartInfo.FileName = Config.modPath + "\\" + customGame ;
                Console.WriteLine("Custom Game File: " + main.StartInfo.FileName);


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
                Console.WriteLine("Orignial Game File: " + main.StartInfo.FileName);
            }
            Config.md5 = Config.getMd5(main.StartInfo.FileName);
            main.StartInfo.Arguments = command.ToString();
            //main.StartInfo.CreateNoWindow = true;
            Config.mainController.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            
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

            //Console.WriteLine("Old Mod Path:" + Config.modPath);
            if (lc_Game.Text.Equals(Config.gameName))
            {
                Config.dat_game = lc_Game.Text;
                Config.modPath = Application.StartupPath + "\\Theme";
                resetCom();
                
            }
            //Console.WriteLine("New Mod Path:" + Config.modPath);
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
                Console.WriteLine("Choose New Mod:" + Config.modPath);
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

                String txt = Config.modPath + "\\launcher\\information.txt";
                String txtLang = Config.modPath + "\\launcher\\information.txt";
                if (File.Exists(txt))
                {


                    if (File.Exists(txtLang))
                    {
                        txt = txtLang;
                    }

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
                String address = "http://www.ea.com/games/command-and-conquer";

                if (MessageBox.Show(loc.open_page[loc.current]+"\n"+address, address, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Process.Start(address);
                };

               

            }
            else
            {
                String href = Config.modPath + "\\launcher\\website.txt";
                String hrefLang = Config.modPath + "\\launcher\\website.txt";
                if (File.Exists(href))
                {
                    if (File.Exists(hrefLang))
                    {
                        href = hrefLang;
                    }

                    String address = Config.readFirstLine(href);


                    if (MessageBox.Show(loc.open_page[loc.current] + "\n" + address, address, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Process.Start(address);
                    };




                }
                else
                {
                    String address = "http://www.ea.com/games/command-and-conquer";

                    if (MessageBox.Show(loc.open_page[loc.current] + "\n" + address, address, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Process.Start(address);
                    };



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
                refreshResource();
            }
        }

        private void Controller_Load(object sender, EventArgs e)
        {

        }

        private void cb_bfs_CheckedChanged(object sender, EventArgs e)
        {

            Config.dat_bfs = cb_bfs.Checked;
            
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

            for (int x = 0; x < lc_GameLanguage.Text.Length; x++)
            {
                sum += ++i + lc_GameLanguage.Text[x];
            }
            desc.Append(' ');
            desc.Append(lc_GameLanguage.Text);

            name.Append(' ');
            name.Append(lc_GameLanguage.Text);

            if (cb_Windowed.Checked && !cb_bfs.Checked)
            {
                desc.Append(cb_Windowed.Text);
                desc.Append(' ');

                name.Append(cb_Windowed.Text);
                name.Append(' ');
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



                name.Append(tb_Xres.Text);
                name.Append('x');
                name.Append(tb_Yres.Text);



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

                name.Append(' ');
                name.Append(cb_bfs.Text);

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


            
            Config.writeDAT(Application.StartupPath + "\\Custom.dat\\" + sb.ToString(), cb_Windowed.Checked, cb_CustomResolution.Checked, tb_Xres.Text, tb_Yres.Text, lc_Game.Text, lc_Version.Text, lc_GameLanguage.Text, Config.modPath, cb_Media.Checked, loc.current, cb_bfs.Checked,Config.dat_mouse_locked,Config.dat_mouse_dynamic,loc.dat_desc[loc.current]);


            
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
            Console.WriteLine("Create Lnk:" + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"\\"+ name + ".lnk");
            shortcut.Arguments = command.ToString();
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.WindowStyle = 1;
            shortcut.Description = desc.ToString();



            String iconPath = Config.modPath + "\\launcher\\icon.ico";

            Console.WriteLine("Create a shortcut,check mod icon:" + iconPath);

            if (lc_Game.Text.Equals(Config.gameName))
            {
                Console.Write("Get Game Icon!");

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

        private void ExtraConfig_Click(object sender, EventArgs e)
        {
            Description form_desc = new Description();

            form_desc.needChecked = false;
            form_desc.address = Config.webPath + "\\index.html";

            if (Config.extraFirst) { 
            DialogResult dr = MessageBox.Show(loc.open_extra_page[loc.current]+"\n("+form_desc.address+")",loc.btn_extra[loc.current],MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

                if (dr == DialogResult.OK)
                {
                    Config.extraFirst = false;

                    form_desc.Show();


                }
            }
            else
            {
                form_desc.Show();
            }






            /*

            DialogResult dr;
            dr = MessageBox.Show(loc.cb_mouse_locked[loc.current], loc.cb_dynamic_mouse[loc.current], MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                Config.dat_mouse_locked = true;
            }
            else
            {
                Config.dat_mouse_locked = false;
            }
            dr = MessageBox.Show(loc.cb_dynamic_mouse[loc.current], loc.cb_dynamic_mouse[loc.current], MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Config.dat_mouse_dynamic = true;
            }
            else
            {
                Config.dat_mouse_dynamic = false;
            }

            */


        }

        private void btn_author_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(loc.open_page[loc.current], "blog.haojun0823.xyz/access/ra3", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK){
                System.Diagnostics.Process.Start("http://blog.haojun0823.xyz/access/ra3");
            };
            
        }

        private void media_video_Enter(object sender, EventArgs e)
        {

        }
    }

}
