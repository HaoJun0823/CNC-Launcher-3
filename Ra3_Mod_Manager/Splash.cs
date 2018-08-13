using System;

using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Ra3_Mod_Manager
{
    public partial class Splash_Form : Form
       {

      

        public Splash_Form()
        {
            InitializeComponent();


            try
            {
                this.BackgroundImage = Config.currentImage[1];
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.ToString(), loc.in_execption[loc.current], MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                this.BackgroundImage = null;
            }

            String iconPath = Config.modPath + "\\icon.ico";

            if (File.Exists(iconPath))
            {
                this.Icon = new Icon(iconPath);
            }

        }

        private void Splash_Form_Load(object sender, EventArgs e)
        {

        }


        private void Splash_Wait_Timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
