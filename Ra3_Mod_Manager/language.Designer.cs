namespace Ra3_Mod_Manager
{
    partial class form_lang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_lang));
            this.combo_lang = new System.Windows.Forms.ComboBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.text_description = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // combo_lang
            // 
            this.combo_lang.FormattingEnabled = true;
            this.combo_lang.Location = new System.Drawing.Point(12, 12);
            this.combo_lang.Name = "combo_lang";
            this.combo_lang.Size = new System.Drawing.Size(184, 20);
            this.combo_lang.TabIndex = 0;
            this.combo_lang.SelectedIndexChanged += new System.EventHandler(this.combo_lang_SelectedIndexChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(202, 12);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(70, 20);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "Gocha!";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // text_description
            // 
            this.text_description.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.text_description.Location = new System.Drawing.Point(12, 38);
            this.text_description.Name = "text_description";
            this.text_description.ReadOnly = true;
            this.text_description.Size = new System.Drawing.Size(260, 111);
            this.text_description.TabIndex = 3;
            this.text_description.Text = "";
            // 
            // form_lang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.text_description);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.combo_lang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_lang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose your language:";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_lang_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_lang_FormClosed);
            this.Load += new System.EventHandler(this.language_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_lang;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.RichTextBox text_description;
    }
}