using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CNCLauncher
{
    public partial class form_lang : Form
    {
        public form_lang()
        {
            InitializeComponent();
        }

        public form_lang(int i)
        {
            
            lang_current = i;
            InitializeComponent();
           
            
        }


        private void language_Load(object sender, EventArgs e)
        {

            //???
            this.Width = 300;
            this.Height = 200;

            foreach (string str in loc.inf)
            {

                combo_lang.Items.Add(str);

            }

            combo_lang.SelectedIndex = lang_current;

            refreshLang(lang_current);


        }

        private int lang_current = 0;
        private bool not_choose = true;

        private void combo_lang_SelectedIndexChanged(object sender, EventArgs e)
        {

            int i = combo_lang.SelectedIndex;
            



            refreshLang(i);







        }

        private void refreshLang(int i)
        {

            this.Text = loc.lang_label_title[i];

            btn_ok.Text = loc.lang_label_button[i];

            text_description.Text = loc.lang_label_text[i] + loc.lang_label_text_author[i];

            lang_current = i;
        }

        private void form_lang_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (not_choose) { 

            MessageBox.Show(loc.lang_label_message_description[lang_current],loc.lang_label_message_title[lang_current], MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void form_lang_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (not_choose) {

                System.Environment.Exit(0);

            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show(loc.inf[lang_current], loc.set_lang_title[lang_current], MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                loc.current = lang_current;
                not_choose = false;
                this.Close();
            }

        }
    }
}
