using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Ra3_Mod_Manager
{
    public partial class Description : Form
    {

        public bool needChecked = false;
        public String address ="";
        public bool isText = false;
        public String deleteFilename = "";

        public Description()
        {
            InitializeComponent();
        }

        private void Description_Load(object sender, EventArgs e)
        {


            String iconPath = Config.modPath + "\\launcher\\icon.ico";

            if (File.Exists(iconPath))
            {
                this.Icon = new Icon(iconPath);
            }

            if (isText) {

                web_browser.Visible = false;
                textarea.Enabled = true;
                textarea.Visible = true;

                try { 

                StreamReader sr = new StreamReader(address,Encoding.Default);
                textarea.Text = sr.ReadToEnd();
                sr.Close();
                this.Text =address;
                }catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                    this.Close();
                }
            } else { 

            web_browser.Url = new Uri(address);
                this.Text = loc.open_extra_page_title[loc.current];
            }
            if (!needChecked)
            {
                this.cb_dont.Visible = false;
            }



            this.cb_dont.Text = loc.open_extra_page_btn[loc.current];
            
            this.btn_ok.Text = loc.open_extra_page_cb[loc.current];


        }

        private void Description_FormClosed(object sender, FormClosedEventArgs e)
        {
            doDel();
        }

        

        private void doDel()
        {
            String cbFile = Config.webPath + "\\always.txt";

            if (cb_dont.Checked)
            {

                if (isText)
                {
                    Debug.WriteLine("Need Delete text files:" + deleteFilename);
                    if (File.Exists(deleteFilename))
                    {
                        File.Delete(deleteFilename);
                        Debug.WriteLine("Delete text files success:" + deleteFilename);
                    }
                }

                Debug.WriteLine("Need Delete always files:" + cbFile);
                if (File.Exists(cbFile))
                {
                    File.Delete(cbFile);
                    Debug.WriteLine("Delete always files success:" + cbFile);
                }
            }

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            doDel();
            this.Close();
        }
    }
}
