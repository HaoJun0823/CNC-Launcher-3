namespace CNCLauncher
{
    partial class Plugin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plugin));
            this.panel_txt = new System.Windows.Forms.Panel();
            this.btn_txt_download = new System.Windows.Forms.Button();
            this.btn_txt_delete = new System.Windows.Forms.Button();
            this.label_txt = new System.Windows.Forms.Label();
            this.btn_txt_switch = new System.Windows.Forms.Button();
            this.textbox_txt = new System.Windows.Forms.RichTextBox();
            this.listbox_txt = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_dll_download = new System.Windows.Forms.Button();
            this.btn_dll_delete = new System.Windows.Forms.Button();
            this.label_dll = new System.Windows.Forms.Label();
            this.btn_dll_switch = new System.Windows.Forms.Button();
            this.textbox_dll = new System.Windows.Forms.RichTextBox();
            this.listbox_dll = new System.Windows.Forms.ListBox();
            this.btn_folder = new System.Windows.Forms.Button();
            this.panel_txt.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_txt
            // 
            this.panel_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_txt.Controls.Add(this.btn_txt_download);
            this.panel_txt.Controls.Add(this.btn_txt_delete);
            this.panel_txt.Controls.Add(this.label_txt);
            this.panel_txt.Controls.Add(this.btn_txt_switch);
            this.panel_txt.Controls.Add(this.textbox_txt);
            this.panel_txt.Controls.Add(this.listbox_txt);
            this.panel_txt.Location = new System.Drawing.Point(12, 12);
            this.panel_txt.Name = "panel_txt";
            this.panel_txt.Size = new System.Drawing.Size(750, 150);
            this.panel_txt.TabIndex = 0;
            // 
            // btn_txt_download
            // 
            this.btn_txt_download.Location = new System.Drawing.Point(159, 105);
            this.btn_txt_download.Name = "btn_txt_download";
            this.btn_txt_download.Size = new System.Drawing.Size(232, 35);
            this.btn_txt_download.TabIndex = 6;
            this.btn_txt_download.Text = "Download";
            this.btn_txt_download.UseVisualStyleBackColor = true;
            this.btn_txt_download.Click += new System.EventHandler(this.btn_txt_download_Click);
            // 
            // btn_txt_delete
            // 
            this.btn_txt_delete.Location = new System.Drawing.Point(159, 64);
            this.btn_txt_delete.Name = "btn_txt_delete";
            this.btn_txt_delete.Size = new System.Drawing.Size(232, 35);
            this.btn_txt_delete.TabIndex = 5;
            this.btn_txt_delete.Text = "Delete";
            this.btn_txt_delete.UseVisualStyleBackColor = true;
            this.btn_txt_delete.Click += new System.EventHandler(this.btn_txt_delete_Click);
            // 
            // label_txt
            // 
            this.label_txt.AutoSize = true;
            this.label_txt.Location = new System.Drawing.Point(6, 6);
            this.label_txt.Name = "label_txt";
            this.label_txt.Size = new System.Drawing.Size(161, 12);
            this.label_txt.TabIndex = 4;
            this.label_txt.Text = "Dynamic Memory Data Inject";
            // 
            // btn_txt_switch
            // 
            this.btn_txt_switch.Enabled = false;
            this.btn_txt_switch.Location = new System.Drawing.Point(159, 23);
            this.btn_txt_switch.Name = "btn_txt_switch";
            this.btn_txt_switch.Size = new System.Drawing.Size(232, 35);
            this.btn_txt_switch.TabIndex = 2;
            this.btn_txt_switch.Text = "Switch";
            this.btn_txt_switch.UseVisualStyleBackColor = true;
            this.btn_txt_switch.Click += new System.EventHandler(this.btn_txt_switch_Click);
            // 
            // textbox_txt
            // 
            this.textbox_txt.BackColor = System.Drawing.SystemColors.Menu;
            this.textbox_txt.Location = new System.Drawing.Point(397, 23);
            this.textbox_txt.Name = "textbox_txt";
            this.textbox_txt.ReadOnly = true;
            this.textbox_txt.Size = new System.Drawing.Size(350, 124);
            this.textbox_txt.TabIndex = 1;
            this.textbox_txt.Text = "";
            // 
            // listbox_txt
            // 
            this.listbox_txt.FormattingEnabled = true;
            this.listbox_txt.HorizontalScrollbar = true;
            this.listbox_txt.ItemHeight = 12;
            this.listbox_txt.Location = new System.Drawing.Point(3, 23);
            this.listbox_txt.Name = "listbox_txt";
            this.listbox_txt.ScrollAlwaysVisible = true;
            this.listbox_txt.Size = new System.Drawing.Size(150, 124);
            this.listbox_txt.TabIndex = 0;
            this.listbox_txt.SelectedIndexChanged += new System.EventHandler(this.listbox_txt_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_dll_download);
            this.panel1.Controls.Add(this.btn_dll_delete);
            this.panel1.Controls.Add(this.label_dll);
            this.panel1.Controls.Add(this.btn_dll_switch);
            this.panel1.Controls.Add(this.textbox_dll);
            this.panel1.Controls.Add(this.listbox_dll);
            this.panel1.Location = new System.Drawing.Point(12, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 150);
            this.panel1.TabIndex = 1;
            // 
            // btn_dll_download
            // 
            this.btn_dll_download.Location = new System.Drawing.Point(159, 105);
            this.btn_dll_download.Name = "btn_dll_download";
            this.btn_dll_download.Size = new System.Drawing.Size(232, 35);
            this.btn_dll_download.TabIndex = 6;
            this.btn_dll_download.Text = "Download";
            this.btn_dll_download.UseVisualStyleBackColor = true;
            this.btn_dll_download.Click += new System.EventHandler(this.btn_dll_download_Click);
            // 
            // btn_dll_delete
            // 
            this.btn_dll_delete.Location = new System.Drawing.Point(159, 64);
            this.btn_dll_delete.Name = "btn_dll_delete";
            this.btn_dll_delete.Size = new System.Drawing.Size(232, 35);
            this.btn_dll_delete.TabIndex = 5;
            this.btn_dll_delete.Text = "Delete";
            this.btn_dll_delete.UseVisualStyleBackColor = true;
            this.btn_dll_delete.Click += new System.EventHandler(this.btn_dll_delete_Click);
            // 
            // label_dll
            // 
            this.label_dll.AutoSize = true;
            this.label_dll.Location = new System.Drawing.Point(6, 6);
            this.label_dll.Name = "label_dll";
            this.label_dll.Size = new System.Drawing.Size(155, 12);
            this.label_dll.TabIndex = 4;
            this.label_dll.Text = "Dynamic Link Library Hook";
            // 
            // btn_dll_switch
            // 
            this.btn_dll_switch.Enabled = false;
            this.btn_dll_switch.Location = new System.Drawing.Point(159, 23);
            this.btn_dll_switch.Name = "btn_dll_switch";
            this.btn_dll_switch.Size = new System.Drawing.Size(232, 35);
            this.btn_dll_switch.TabIndex = 2;
            this.btn_dll_switch.Text = "Switch";
            this.btn_dll_switch.UseVisualStyleBackColor = true;
            this.btn_dll_switch.Click += new System.EventHandler(this.btn_dll_switch_Click);
            // 
            // textbox_dll
            // 
            this.textbox_dll.BackColor = System.Drawing.SystemColors.Menu;
            this.textbox_dll.Location = new System.Drawing.Point(397, 23);
            this.textbox_dll.Name = "textbox_dll";
            this.textbox_dll.ReadOnly = true;
            this.textbox_dll.Size = new System.Drawing.Size(350, 124);
            this.textbox_dll.TabIndex = 1;
            this.textbox_dll.Text = "";
            // 
            // listbox_dll
            // 
            this.listbox_dll.FormattingEnabled = true;
            this.listbox_dll.HorizontalScrollbar = true;
            this.listbox_dll.ItemHeight = 12;
            this.listbox_dll.Location = new System.Drawing.Point(3, 23);
            this.listbox_dll.Name = "listbox_dll";
            this.listbox_dll.ScrollAlwaysVisible = true;
            this.listbox_dll.Size = new System.Drawing.Size(150, 124);
            this.listbox_dll.TabIndex = 0;
            this.listbox_dll.SelectedIndexChanged += new System.EventHandler(this.listbox_dll_SelectedIndexChanged);
            // 
            // btn_folder
            // 
            this.btn_folder.Location = new System.Drawing.Point(12, 324);
            this.btn_folder.Name = "btn_folder";
            this.btn_folder.Size = new System.Drawing.Size(750, 25);
            this.btn_folder.TabIndex = 2;
            this.btn_folder.Text = "Folder";
            this.btn_folder.UseVisualStyleBackColor = true;
            this.btn_folder.Click += new System.EventHandler(this.btn_folder_Click);
            // 
            // Plugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.btn_folder);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Plugin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plugins";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Plugin_Load);
            this.panel_txt.ResumeLayout(false);
            this.panel_txt.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_txt;
        private System.Windows.Forms.Button btn_txt_download;
        private System.Windows.Forms.Button btn_txt_delete;
        private System.Windows.Forms.Label label_txt;
        private System.Windows.Forms.Button btn_txt_switch;
        private System.Windows.Forms.RichTextBox textbox_txt;
        private System.Windows.Forms.ListBox listbox_txt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_dll_download;
        private System.Windows.Forms.Button btn_dll_delete;
        private System.Windows.Forms.Label label_dll;
        private System.Windows.Forms.Button btn_dll_switch;
        private System.Windows.Forms.RichTextBox textbox_dll;
        private System.Windows.Forms.ListBox listbox_dll;
        private System.Windows.Forms.Button btn_folder;
    }
}