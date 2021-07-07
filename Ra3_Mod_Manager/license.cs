using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CNCLauncher
{
    public partial class License : Form
    {
        public License()
        {
            InitializeComponent();
        }

        private void License_Load(object sender, EventArgs e)
        {
            String iconPath = Config.modPath + "\\launcher\\icon.ico";

            if (File.Exists(iconPath))
            {
                this.Icon = new Icon(iconPath);
            }

            this.rtb_text.Text = loc.rtb_license[loc.current];
            this.Text = loc.title_license[loc.current];
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
