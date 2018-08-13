using System.Diagnostics;
using System.Drawing;

namespace Ra3_Mod_Manager
{
    partial class Controller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controller));
            this.btn_StartGame = new System.Windows.Forms.Button();
            this.tb_Xres = new System.Windows.Forms.TextBox();
            this.tb_Yres = new System.Windows.Forms.TextBox();
            this.lc_Game = new System.Windows.Forms.ComboBox();
            this.lc_Version = new System.Windows.Forms.ComboBox();
            this.lb_Width = new System.Windows.Forms.Label();
            this.lb_Height = new System.Windows.Forms.Label();
            this.cb_Windowed = new System.Windows.Forms.CheckBox();
            this.cb_CustomResolution = new System.Windows.Forms.CheckBox();
            this.lb_Game = new System.Windows.Forms.Label();
            this.lb_Version = new System.Windows.Forms.Label();
            this.btn_RA3UI = new System.Windows.Forms.Button();
            this.btn_Information = new System.Windows.Forms.Button();
            this.btn_SaveOption = new System.Windows.Forms.Button();
            this.lc_GameLanguage = new System.Windows.Forms.ComboBox();
            this.btn_website = new System.Windows.Forms.Button();
            this.cb_Media = new System.Windows.Forms.CheckBox();
            this.btn_ModFolder = new System.Windows.Forms.Button();
            this.lc_loc = new System.Windows.Forms.ComboBox();
            this.media_video = new AxWMPLib.AxWindowsMediaPlayer();
            this.cb_bfs = new System.Windows.Forms.CheckBox();
            this.btn_map = new System.Windows.Forms.Button();
            this.btn_document = new System.Windows.Forms.Button();
            this.btn_short = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.media_video)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_StartGame
            // 
            this.btn_StartGame.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_StartGame, "btn_StartGame");
            this.btn_StartGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_StartGame.FlatAppearance.BorderSize = 0;
            this.btn_StartGame.ForeColor = System.Drawing.Color.Black;
            this.btn_StartGame.Name = "btn_StartGame";
            this.btn_StartGame.UseVisualStyleBackColor = false;
            this.btn_StartGame.Click += new System.EventHandler(this.btn_StartGame_Click);
            // 
            // tb_Xres
            // 
            this.tb_Xres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tb_Xres, "tb_Xres");
            this.tb_Xres.Name = "tb_Xres";
            this.tb_Xres.TextChanged += new System.EventHandler(this.tb_Xres_TextChanged);
            this.tb_Xres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberOnly_KeyPress);
            // 
            // tb_Yres
            // 
            this.tb_Yres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tb_Yres, "tb_Yres");
            this.tb_Yres.Name = "tb_Yres";
            this.tb_Yres.TextChanged += new System.EventHandler(this.tb_Yres_TextChanged);
            this.tb_Yres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberOnly_KeyPress);
            // 
            // lc_Game
            // 
            this.lc_Game.BackColor = System.Drawing.SystemColors.Window;
            this.lc_Game.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lc_Game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lc_Game.FormattingEnabled = true;
            resources.ApplyResources(this.lc_Game, "lc_Game");
            this.lc_Game.Name = "lc_Game";
            this.lc_Game.SelectedIndexChanged += new System.EventHandler(this.lc_Game_SelectedIndexChanged);
            // 
            // lc_Version
            // 
            this.lc_Version.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lc_Version.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lc_Version.FormattingEnabled = true;
            resources.ApplyResources(this.lc_Version, "lc_Version");
            this.lc_Version.Name = "lc_Version";
            this.lc_Version.SelectedIndexChanged += new System.EventHandler(this.lc_Version_SelectedIndexChanged);
            // 
            // lb_Width
            // 
            resources.ApplyResources(this.lb_Width, "lb_Width");
            this.lb_Width.BackColor = System.Drawing.Color.Transparent;
            this.lb_Width.ForeColor = System.Drawing.Color.White;
            this.lb_Width.Name = "lb_Width";
            // 
            // lb_Height
            // 
            resources.ApplyResources(this.lb_Height, "lb_Height");
            this.lb_Height.BackColor = System.Drawing.Color.Transparent;
            this.lb_Height.ForeColor = System.Drawing.Color.White;
            this.lb_Height.Name = "lb_Height";
            // 
            // cb_Windowed
            // 
            resources.ApplyResources(this.cb_Windowed, "cb_Windowed");
            this.cb_Windowed.BackColor = System.Drawing.Color.Transparent;
            this.cb_Windowed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Windowed.FlatAppearance.BorderSize = 0;
            this.cb_Windowed.ForeColor = System.Drawing.Color.White;
            this.cb_Windowed.Name = "cb_Windowed";
            this.cb_Windowed.UseVisualStyleBackColor = false;
            this.cb_Windowed.CheckedChanged += new System.EventHandler(this.cb_Windowed_CheckedChanged);
            // 
            // cb_CustomResolution
            // 
            resources.ApplyResources(this.cb_CustomResolution, "cb_CustomResolution");
            this.cb_CustomResolution.BackColor = System.Drawing.Color.Transparent;
            this.cb_CustomResolution.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_CustomResolution.FlatAppearance.BorderSize = 0;
            this.cb_CustomResolution.ForeColor = System.Drawing.Color.White;
            this.cb_CustomResolution.Name = "cb_CustomResolution";
            this.cb_CustomResolution.UseVisualStyleBackColor = false;
            this.cb_CustomResolution.CheckedChanged += new System.EventHandler(this.cb_CustomResolution_CheckedChanged);
            // 
            // lb_Game
            // 
            resources.ApplyResources(this.lb_Game, "lb_Game");
            this.lb_Game.BackColor = System.Drawing.Color.Transparent;
            this.lb_Game.ForeColor = System.Drawing.Color.White;
            this.lb_Game.Name = "lb_Game";
            // 
            // lb_Version
            // 
            resources.ApplyResources(this.lb_Version, "lb_Version");
            this.lb_Version.BackColor = System.Drawing.Color.Transparent;
            this.lb_Version.ForeColor = System.Drawing.Color.White;
            this.lb_Version.Name = "lb_Version";
            // 
            // btn_RA3UI
            // 
            this.btn_RA3UI.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_RA3UI, "btn_RA3UI");
            this.btn_RA3UI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RA3UI.FlatAppearance.BorderSize = 0;
            this.btn_RA3UI.ForeColor = System.Drawing.Color.Black;
            this.btn_RA3UI.Name = "btn_RA3UI";
            this.btn_RA3UI.UseVisualStyleBackColor = false;
            this.btn_RA3UI.Click += new System.EventHandler(this.btn_RA3UI_Click);
            // 
            // btn_Information
            // 
            this.btn_Information.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_Information, "btn_Information");
            this.btn_Information.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Information.FlatAppearance.BorderSize = 0;
            this.btn_Information.ForeColor = System.Drawing.Color.Black;
            this.btn_Information.Name = "btn_Information";
            this.btn_Information.UseVisualStyleBackColor = false;
            this.btn_Information.Click += new System.EventHandler(this.btn_Information_Click);
            // 
            // btn_SaveOption
            // 
            this.btn_SaveOption.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_SaveOption, "btn_SaveOption");
            this.btn_SaveOption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveOption.FlatAppearance.BorderSize = 0;
            this.btn_SaveOption.ForeColor = System.Drawing.Color.Black;
            this.btn_SaveOption.Name = "btn_SaveOption";
            this.btn_SaveOption.UseVisualStyleBackColor = false;
            this.btn_SaveOption.Click += new System.EventHandler(this.btn_SaveOption_Click);
            // 
            // lc_GameLanguage
            // 
            this.lc_GameLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lc_GameLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lc_GameLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.lc_GameLanguage, "lc_GameLanguage");
            this.lc_GameLanguage.Name = "lc_GameLanguage";
            this.lc_GameLanguage.SelectedIndexChanged += new System.EventHandler(this.lb_GameLanguage_SelectedIndexChanged);
            // 
            // btn_website
            // 
            this.btn_website.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_website, "btn_website");
            this.btn_website.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_website.FlatAppearance.BorderSize = 0;
            this.btn_website.ForeColor = System.Drawing.Color.Black;
            this.btn_website.Name = "btn_website";
            this.btn_website.UseVisualStyleBackColor = false;
            this.btn_website.Click += new System.EventHandler(this.btn_website_Click);
            // 
            // cb_Media
            // 
            resources.ApplyResources(this.cb_Media, "cb_Media");
            this.cb_Media.BackColor = System.Drawing.Color.Transparent;
            this.cb_Media.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Media.FlatAppearance.BorderSize = 0;
            this.cb_Media.ForeColor = System.Drawing.Color.White;
            this.cb_Media.Name = "cb_Media";
            this.cb_Media.UseVisualStyleBackColor = false;
            this.cb_Media.CheckedChanged += new System.EventHandler(this.cb_Media_CheckedChanged);
            // 
            // btn_ModFolder
            // 
            this.btn_ModFolder.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_ModFolder, "btn_ModFolder");
            this.btn_ModFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ModFolder.FlatAppearance.BorderSize = 0;
            this.btn_ModFolder.ForeColor = System.Drawing.Color.Black;
            this.btn_ModFolder.Name = "btn_ModFolder";
            this.btn_ModFolder.UseVisualStyleBackColor = false;
            this.btn_ModFolder.Click += new System.EventHandler(this.btn_ModFolder_Click);
            // 
            // lc_loc
            // 
            this.lc_loc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lc_loc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lc_loc.FormattingEnabled = true;
            resources.ApplyResources(this.lc_loc, "lc_loc");
            this.lc_loc.Name = "lc_loc";
            this.lc_loc.SelectedIndexChanged += new System.EventHandler(this.lc_loc_SelectedIndexChanged);
            // 
            // media_video
            // 
            resources.ApplyResources(this.media_video, "media_video");
            this.media_video.Name = "media_video";
            this.media_video.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("media_video.OcxState")));
            this.media_video.TabStop = false;
            // 
            // cb_bfs
            // 
            resources.ApplyResources(this.cb_bfs, "cb_bfs");
            this.cb_bfs.BackColor = System.Drawing.Color.Transparent;
            this.cb_bfs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_bfs.ForeColor = System.Drawing.Color.White;
            this.cb_bfs.Name = "cb_bfs";
            this.cb_bfs.UseVisualStyleBackColor = false;
            this.cb_bfs.CheckedChanged += new System.EventHandler(this.cb_bfs_CheckedChanged);
            // 
            // btn_map
            // 
            this.btn_map.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_map, "btn_map");
            this.btn_map.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_map.FlatAppearance.BorderSize = 0;
            this.btn_map.ForeColor = System.Drawing.Color.Black;
            this.btn_map.Name = "btn_map";
            this.btn_map.UseVisualStyleBackColor = false;
            this.btn_map.Click += new System.EventHandler(this.btn_map_Click);
            // 
            // btn_document
            // 
            this.btn_document.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_document, "btn_document");
            this.btn_document.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_document.FlatAppearance.BorderSize = 0;
            this.btn_document.ForeColor = System.Drawing.Color.Black;
            this.btn_document.Name = "btn_document";
            this.btn_document.UseVisualStyleBackColor = false;
            this.btn_document.Click += new System.EventHandler(this.btn_document_Click);
            // 
            // btn_short
            // 
            this.btn_short.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_short, "btn_short");
            this.btn_short.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_short.FlatAppearance.BorderSize = 0;
            this.btn_short.ForeColor = System.Drawing.Color.Black;
            this.btn_short.Name = "btn_short";
            this.btn_short.UseVisualStyleBackColor = false;
            this.btn_short.Click += new System.EventHandler(this.btn_short_Click);
            // 
            // Controller
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.btn_short);
            this.Controls.Add(this.btn_document);
            this.Controls.Add(this.btn_map);
            this.Controls.Add(this.cb_bfs);
            this.Controls.Add(this.media_video);
            this.Controls.Add(this.lc_loc);
            this.Controls.Add(this.btn_ModFolder);
            this.Controls.Add(this.cb_Media);
            this.Controls.Add(this.btn_website);
            this.Controls.Add(this.lc_GameLanguage);
            this.Controls.Add(this.btn_SaveOption);
            this.Controls.Add(this.btn_Information);
            this.Controls.Add(this.btn_RA3UI);
            this.Controls.Add(this.lb_Version);
            this.Controls.Add(this.lb_Game);
            this.Controls.Add(this.cb_CustomResolution);
            this.Controls.Add(this.cb_Windowed);
            this.Controls.Add(this.lb_Height);
            this.Controls.Add(this.lb_Width);
            this.Controls.Add(this.lc_Version);
            this.Controls.Add(this.lc_Game);
            this.Controls.Add(this.tb_Yres);
            this.Controls.Add(this.tb_Xres);
            this.Controls.Add(this.btn_StartGame);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Controller";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Controller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.media_video)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_StartGame;
        private System.Windows.Forms.TextBox tb_Xres;
        private System.Windows.Forms.TextBox tb_Yres;
        private System.Windows.Forms.ComboBox lc_Game;
        private System.Windows.Forms.ComboBox lc_Version;
        private System.Windows.Forms.Label lb_Width;
        private System.Windows.Forms.Label lb_Height;
        private System.Windows.Forms.CheckBox cb_Windowed;
        private System.Windows.Forms.CheckBox cb_CustomResolution;
        private System.Windows.Forms.Label lb_Game;
        private System.Windows.Forms.Label lb_Version;
        private System.Windows.Forms.Button btn_RA3UI;
        private System.Windows.Forms.Button btn_Information;
        private System.Windows.Forms.Button btn_SaveOption;
        private System.Windows.Forms.ComboBox lc_GameLanguage;
        private System.Windows.Forms.Button btn_website;
        private System.Windows.Forms.CheckBox cb_Media;
        private System.Windows.Forms.Button btn_ModFolder;
        private System.Windows.Forms.ComboBox lc_loc;
        private AxWMPLib.AxWindowsMediaPlayer media_video;
        private System.Windows.Forms.CheckBox cb_bfs;
        private System.Windows.Forms.Button btn_map;
        private System.Windows.Forms.Button btn_document;
        private System.Windows.Forms.Button btn_short;
    }
}