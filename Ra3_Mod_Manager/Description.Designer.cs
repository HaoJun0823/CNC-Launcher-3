namespace Ra3_Mod_Manager
{
    partial class Description
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Description));
            this.panel = new System.Windows.Forms.Panel();
            this.btn_ok = new System.Windows.Forms.Button();
            this.cb_dont = new System.Windows.Forms.CheckBox();
            this.web_browser = new System.Windows.Forms.WebBrowser();
            this.textarea = new System.Windows.Forms.RichTextBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.textarea);
            this.panel.Controls.Add(this.web_browser);
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1240, 700);
            this.panel.TabIndex = 0;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(1152, 718);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(100, 33);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // cb_dont
            // 
            this.cb_dont.AutoSize = true;
            this.cb_dont.Location = new System.Drawing.Point(12, 727);
            this.cb_dont.Name = "cb_dont";
            this.cb_dont.Size = new System.Drawing.Size(150, 16);
            this.cb_dont.TabIndex = 2;
            this.cb_dont.Text = "Don\'t show this panel";
            this.cb_dont.UseVisualStyleBackColor = true;
            // 
            // web_browser
            // 
            this.web_browser.AllowNavigation = false;
            this.web_browser.AllowWebBrowserDrop = false;
            this.web_browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web_browser.IsWebBrowserContextMenuEnabled = false;
            this.web_browser.Location = new System.Drawing.Point(0, 0);
            this.web_browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.web_browser.Name = "web_browser";
            this.web_browser.Size = new System.Drawing.Size(1240, 700);
            this.web_browser.TabIndex = 0;
            this.web_browser.WebBrowserShortcutsEnabled = false;
            // 
            // textarea
            // 
            this.textarea.Enabled = false;
            this.textarea.Location = new System.Drawing.Point(0, 0);
            this.textarea.Name = "textarea";
            this.textarea.ReadOnly = true;
            this.textarea.Size = new System.Drawing.Size(1237, 700);
            this.textarea.TabIndex = 1;
            this.textarea.Text = "";
            this.textarea.Visible = false;
            // 
            // Description
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.cb_dont);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.panel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Description";
            this.Text = "Description";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Description_FormClosed);
            this.Load += new System.EventHandler(this.Description_Load);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.CheckBox cb_dont;
        private System.Windows.Forms.WebBrowser web_browser;
        private System.Windows.Forms.RichTextBox textarea;
    }
}