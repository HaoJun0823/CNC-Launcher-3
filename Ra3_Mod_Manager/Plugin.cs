using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CNCLauncher
{
    public partial class Plugin : Form
    {

        List<String> ListTxt;
        List<String> ListDll;

        public Plugin()
        {
            InitializeComponent();


            this.btn_txt_download.Text = loc.plugin_download[loc.current];
            this.btn_txt_delete.Text = loc.plugin_del[loc.current];
            this.label_txt.Text = loc.plugin_txt[loc.current];
            this.label_dll.Text = loc.plugin_dll[loc.current];
            this.btn_txt_switch.Text = loc.plugin_choose[loc.current];
            this.btn_dll_switch.Text = loc.plugin_choose[loc.current];
            this.Text = loc.plugin_title[loc.current];
            this.btn_dll_download.Text = loc.plugin_download[loc.current];
            this.btn_dll_delete.Text = loc.plugin_del[loc.current];

            doGetList();

        }

        private void Plugin_Load(object sender, EventArgs e)
        {







        }

        private void doGetList()
        {

            ListTxt = new List<string>(getAllFile(Config.workPath+"\\Plugins\\Memory","*.txt"));
            ListDll = new List<string>(getAllFile(Config.workPath + "\\Plugins\\Library", "*.dll"));


            this.listbox_dll.Items.Clear();
            this.listbox_txt.Items.Clear();

            this.listbox_txt.ClearSelected();
            this.listbox_dll.ClearSelected();
            this.btn_dll_delete.Enabled = false;
            this.btn_txt_delete.Enabled = false;

            this.btn_dll_switch.Enabled = false;
            this.btn_txt_switch.Enabled = false;
            this.btn_txt_switch.Text = loc.plugin_choose[loc.current];
            this.btn_dll_switch.Text = loc.plugin_choose[loc.current];
            this.btn_folder.Text = loc.btn_modfolder[loc.current];

            foreach (string str in ListTxt){

                string name = Path.GetFileName(str);

                this.listbox_txt.Items.Add(name);

            }

            foreach (string str in ListDll)
            {
                string name = Path.GetFileName(str);

                this.listbox_dll.Items.Add(name);

            }
            /*

            if (ListTxt.Count > 0)
            {
                //this.listbox_txt.SelectedIndex = 0;


            }
            if (ListDll.Count > 0)
            {
                //this.listbox_dll.SelectedIndex = 0;
            }
            */



        }

        private String[] getAllFile(String path,String file)
        {

            return Directory.GetFiles(path,file);
        }

        private void listbox_txt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listbox_txt.SelectedIndex;

            if (index < 0)
            {
                return;
            }

            string path = ListTxt[index];


            if (isEnabled(path,".e.txt")){
                this.btn_txt_switch.Text = loc.plugin_deactivate[loc.current];
            }
            else
            {
                this.btn_txt_switch.Text = loc.plugin_activate[loc.current];
            }

            this.btn_txt_delete.Enabled = true;

            this.btn_txt_switch.Enabled = true;
            textbox_txt.Text = File.ReadAllText(path);

        }



        private void listbox_dll_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listbox_dll.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            string path = ListDll[index];


            if (isEnabled(path, ".e.dll"))
            {
                this.btn_dll_switch.Text = loc.plugin_deactivate[loc.current];
            }
            else
            {
                
                this.btn_dll_switch.Text = loc.plugin_activate[loc.current];
            }
            this.btn_dll_delete.Enabled = true;

            this.btn_dll_switch.Enabled = true;
            if (File.Exists(getIni(path))) { 
            textbox_dll.Text = File.ReadAllText(getIni(path));
            }
            else
            {
                this.textbox_dll.Text = null;
            }
        }

        private string getIni(String path)
        {
            return path.Substring(0, path.Length - 6)+".ini";
        }

        private void btn_txt_delete_Click(object sender, EventArgs e)
        {
            int index = this.listbox_txt.SelectedIndex;
            string path = this.ListTxt[index];

            bool flag = confirm(Path.GetFileNameWithoutExtension(path));

            if (flag)
            {

                this.btn_txt_switch.Enabled = false;
                this.btn_txt_switch.Text = loc.plugin_choose[loc.current];
                FileInfo fi = new FileInfo(path);
                fi.Delete();

                doGetList();
            }


        }

        public bool isEnabled(String path, String checkStr)
        {
            string status = path.Substring(path.Length - checkStr.Length, checkStr.Length);
            return status.ToLower() == checkStr.ToLower();

        }

        private bool confirm(String path)
        {
            DialogResult dr = MessageBox.Show(path+"\n"+loc.plugin_delete_confirm[loc.current],loc.plugin_title[loc.current],MessageBoxButtons.YesNo);
            return dr == DialogResult.Yes ? true : false;
        }

        private void btn_txt_switch_Click(object sender, EventArgs e)
        {
            int index = this.listbox_txt.SelectedIndex;
            int index2 = this.listbox_dll.SelectedIndex;
            string path = ListTxt[index];

            FileInfo fi = new FileInfo(path);
            if (isEnabled(path, ".e.txt"))
            {
                fi.MoveTo(path.Substring(0,path.Length-6)+".d.txt");
            }
            else
            {
                fi.MoveTo(path.Substring(0, path.Length - 6) + ".e.txt");
            }

            doGetList();
            this.listbox_txt.SelectedIndex = index;
            this.listbox_dll.SelectedIndex = index2;

        }

        private void btn_dll_switch_Click(object sender, EventArgs e)
        {
            int index = this.listbox_dll.SelectedIndex;
            int index2 = this.listbox_txt.SelectedIndex;

            string path = ListDll[index];

            FileInfo fi = new FileInfo(path);
            if (isEnabled(path, ".e.dll"))
            {
                fi.MoveTo(path.Substring(0, path.Length - 6) + ".d.dll");
            }
            else
            {
                fi.MoveTo(path.Substring(0, path.Length - 6) + ".e.dll");
            }

            doGetList();
            this.listbox_dll.SelectedIndex = index;
            this.listbox_txt.SelectedIndex = index2;
        }

        private void btn_dll_delete_Click(object sender, EventArgs e)
        {

            int index = this.listbox_dll.SelectedIndex;
            string path = ListDll[index];

            bool flag = confirm(Path.GetFileNameWithoutExtension(path));

            if (flag)
            {

                this.btn_dll_switch.Enabled = false;
                this.btn_dll_switch.Text = loc.plugin_choose[loc.current];
                FileInfo fi = new FileInfo(path);
                fi.Delete();

                if (File.Exists(getIni(path)))
                {
                    FileInfo inifi = new FileInfo(getIni(path));
                    inifi.Delete();
                }

                doGetList();
            }

        }

        private void btn_txt_download_Click(object sender, EventArgs e)
        {
            String address = "https://github.com/HaoJun0823/CNC-Launcher-3-Plugins/tree/master/Memory";

            if (MessageBox.Show(loc.open_page[loc.current] + "\n" + address, address, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Process.Start(address);
            };
        }

        private void btn_dll_download_Click(object sender, EventArgs e)
        {
            String address = "https://github.com/HaoJun0823/CNC-Launcher-3-Plugins/tree/master/Library";

            if (MessageBox.Show(loc.open_page[loc.current] + "\n" + address, address, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Process.Start(address);
            };
        }

        private void btn_folder_Click(object sender, EventArgs e)
        {
            Process.Start(Config.workPath+"\\Plugins");
        }
    }
}
