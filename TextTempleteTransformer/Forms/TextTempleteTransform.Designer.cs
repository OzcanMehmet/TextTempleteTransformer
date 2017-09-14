namespace TextTempleteTransformer
{
    partial class TextTempleteTransform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextTempleteTransform));
            this.ttlistname = new System.Windows.Forms.ListBox();
            this.ttlister = new System.Windows.Forms.ListBox();
            this.addlist = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.Config = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ttlistname
            // 
            this.ttlistname.FormattingEnabled = true;
            this.ttlistname.Location = new System.Drawing.Point(93, 12);
            this.ttlistname.Name = "ttlistname";
            this.ttlistname.Size = new System.Drawing.Size(176, 290);
            this.ttlistname.TabIndex = 0;
            this.ttlistname.SelectedIndexChanged += new System.EventHandler(this.ttlist_SelectedIndexChanged);
            // 
            // ttlister
            // 
            this.ttlister.FormattingEnabled = true;
            this.ttlister.Location = new System.Drawing.Point(275, 12);
            this.ttlister.Name = "ttlister";
            this.ttlister.Size = new System.Drawing.Size(745, 251);
            this.ttlister.TabIndex = 1;
            // 
            // addlist
            // 
            this.addlist.Location = new System.Drawing.Point(12, 79);
            this.addlist.Name = "addlist";
            this.addlist.Size = new System.Drawing.Size(75, 23);
            this.addlist.TabIndex = 2;
            this.addlist.Text = "Add";
            this.addlist.UseVisualStyleBackColor = true;
            this.addlist.Click += new System.EventHandler(this.addlist_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(945, 272);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Transform";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // Config
            // 
            this.Config.Location = new System.Drawing.Point(12, 137);
            this.Config.Name = "Config";
            this.Config.Size = new System.Drawing.Size(75, 23);
            this.Config.TabIndex = 4;
            this.Config.Text = "Config";
            this.Config.UseVisualStyleBackColor = true;
            this.Config.Click += new System.EventHandler(this.Config_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(12, 108);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 5;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // TextTempleteTransform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 307);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.Config);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.addlist);
            this.Controls.Add(this.ttlister);
            this.Controls.Add(this.ttlistname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextTempleteTransform";
            this.Text = "Text Templete Transform";
            this.Load += new System.EventHandler(this.TextTempleteTransform_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ttlistname;
        private System.Windows.Forms.ListBox ttlister;
        private System.Windows.Forms.Button addlist;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button Config;
        private System.Windows.Forms.Button btndelete;
    }
}