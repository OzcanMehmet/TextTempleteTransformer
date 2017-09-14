
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TextTempleteTransformer.GetterSetter;
using TextTempleteTransformer.PackageTT;
namespace TextTempleteTransformer
{
    public partial class TextTempleteTransform : Form
    {
        Command commad { get; set; }
        TTcontainer TTContainer { get; set; }
        List<TTPackage> packages { get; set; }
        private string selectedname { get; set; }
        public TextTempleteTransform(Command cmmd, TTcontainer container)
        {
            InitializeComponent();
            Config.Enabled = false;
            btndelete.Enabled = false;
            TTContainer = container;
            TTContainer.Refresh();
            commad = cmmd;
            fillerlistname();
            runcontroller();
            //filler();
            //TTContainer.runall();

        }
       
        public void fillerlistname()
        {
            ttlistname.Items.Clear();
            foreach (string name in TTContainer.GetListName())
                ttlistname.Items.Add(name);
        }
        public void fillerlist(string listname)
        {
            ttlister.Items.Clear();
            foreach (TTPackage package in TTContainer.GetContainer(selectedname).Package)
                ttlister.Items.Add(package.Name);
                
            
            
        }

        private void TextTempleteTransform_Load(object sender, EventArgs e)
        {

        }

        private void ttlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedname = (string)ttlistname.SelectedItem;
            if(selectedname!=null)
            fillerlist(selectedname);
            if (ttlistname.SelectedIndex > -1)
            {
                if (selectedname != Model.DefaultList)
                    btndelete.Enabled = true;
                else
                    btndelete.Enabled = false;
                    Config.Enabled = true;
                

            }
            else
                Config.Enabled = false;
            runcontroller();
        }
        public void runcontroller()
        {
            if (ttlister.Items.Count == 0)
                btnRun.Enabled = false;
            else
                btnRun.Enabled = true;
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            
            TTContainer.Runall(selectedname);
            this.Close();
            
        }

        private void addlist_Click(object sender, EventArgs e)
        {
            new Addlist(TTContainer).ShowDialog();
            TTContainer.Refresh();
            TTContainer.Save();
            fillerlistname();
            ttlister.Items.Clear();
            runcontroller();
        }

        private void Config_Click(object sender, EventArgs e)
        {
           
            new Addlist(TTContainer, TTContainer.GetContainer(selectedname)).ShowDialog();
            fillerlistname();
            ttlister.Items.Clear();
            runcontroller();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(selectedname!=null)
            {
                TTContainer.container.Remove(TTContainer.GetContainer(selectedname));
                TTContainer.Save();
            }
            TTContainer.Refresh();
            fillerlistname();
        }

       
    }
}
