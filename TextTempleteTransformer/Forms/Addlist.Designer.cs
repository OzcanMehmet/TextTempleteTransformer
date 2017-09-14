namespace TextTempleteTransformer
{
    partial class Addlist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Addlist));
            this.listname = new System.Windows.Forms.TextBox();
            this.lsttt = new System.Windows.Forms.ListBox();
            this.listmytt = new System.Windows.Forms.ListBox();
            this.btnup = new System.Windows.Forms.Button();
            this.btndown = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.btntransfer = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listname
            // 
            this.listname.Location = new System.Drawing.Point(1097, 259);
            this.listname.Name = "listname";
            this.listname.Size = new System.Drawing.Size(100, 20);
            this.listname.TabIndex = 0;
            // 
            // lsttt
            // 
            this.lsttt.FormattingEnabled = true;
            this.lsttt.Location = new System.Drawing.Point(12, 12);
            this.lsttt.Name = "lsttt";
            this.lsttt.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsttt.Size = new System.Drawing.Size(492, 316);
            this.lsttt.TabIndex = 1;
            // 
            // listmytt
            // 
            this.listmytt.FormattingEnabled = true;
            this.listmytt.Location = new System.Drawing.Point(596, 12);
            this.listmytt.Name = "listmytt";
            this.listmytt.Size = new System.Drawing.Size(495, 316);
            this.listmytt.TabIndex = 2;
            // 
            // btnup
            // 
            this.btnup.Location = new System.Drawing.Point(1097, 74);
            this.btnup.Name = "btnup";
            this.btnup.Size = new System.Drawing.Size(95, 23);
            this.btnup.TabIndex = 3;
            this.btnup.Text = "up";
            this.btnup.UseVisualStyleBackColor = true;
            this.btnup.Click += new System.EventHandler(this.btnup_Click);
            // 
            // btndown
            // 
            this.btndown.Location = new System.Drawing.Point(1097, 103);
            this.btndown.Name = "btndown";
            this.btndown.Size = new System.Drawing.Size(95, 23);
            this.btndown.TabIndex = 4;
            this.btndown.Text = "down";
            this.btndown.UseVisualStyleBackColor = true;
            this.btndown.Click += new System.EventHandler(this.btndown_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(1097, 299);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(100, 23);
            this.btnok.TabIndex = 5;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btntransfer
            // 
            this.btntransfer.Location = new System.Drawing.Point(510, 155);
            this.btntransfer.Name = "btntransfer";
            this.btntransfer.Size = new System.Drawing.Size(80, 23);
            this.btntransfer.TabIndex = 6;
            this.btntransfer.Text = ">>>>>>";
            this.btntransfer.UseVisualStyleBackColor = true;
            this.btntransfer.Click += new System.EventHandler(this.btntransfer_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(1097, 132);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(95, 23);
            this.btndelete.TabIndex = 7;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // Addlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 334);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btntransfer);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.btndown);
            this.Controls.Add(this.btnup);
            this.Controls.Add(this.listmytt);
            this.Controls.Add(this.lsttt);
            this.Controls.Add(this.listname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Addlist";
            this.Text = "List Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox listname;
        private System.Windows.Forms.ListBox lsttt;
        private System.Windows.Forms.ListBox listmytt;
        private System.Windows.Forms.Button btnup;
        private System.Windows.Forms.Button btndown;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btntransfer;
        private System.Windows.Forms.Button btndelete;
    }
}