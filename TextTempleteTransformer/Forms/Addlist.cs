using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextTempleteTransformer.PackageTT;
using static System.Windows.Forms.ListBox;
using TextTempleteTransformer.GetterSetter;
namespace TextTempleteTransformer
{
    public partial class Addlist : Form
    {
        public TTcontainer ttconrainer { get; set; }
        private List<TTPackage> packages { get; set; }
        private bool IsNew { get; set; }
        public Addlist(TTcontainer container)
        {
            intial(container);
            IsNew = true;

        }
        public Addlist(TTcontainer container,StorageContainer str)
        {
            intial(container);
            ChangeConfig(container, str);
            IsNew = false;
        }
        public void ChangeConfig(TTcontainer container, StorageContainer str)
        {
            listname.Text = str.ListName;
            listname.Enabled = false;
            if (listname.Text == Model.DefaultList)
                btndelete.Enabled = false;
            listmytt.Items.AddRange(str.Package.Select(x => x.Name).ToArray());
            listTTreflesh();
        }
        public void intial(TTcontainer container)
        {
            InitializeComponent();
            ttconrainer = container;
            packages = ttconrainer.GetTTlist();
            fillerlist();
        }

      
       
        private void fillerlist()
        {
            lsttt.Items.Clear();
            foreach (TTPackage package in packages)
                lsttt.Items.Add(package.Name);
        }
        public void listTTreflesh()
        {
            for(int i=0;i<listmytt.Items.Count;i++)
            {
                if (lsttt.Items.Contains((string)listmytt.Items[i]))
                    lsttt.Items.Remove((string)listmytt.Items[i]);
            }
         
        }
        private void btntransfer_Click(object sender, EventArgs e)
        {
            
            foreach (int counter  in lsttt.SelectedIndices)
            {
                listmytt.Items.Add(lsttt.Items[counter]);
            }
            listTTreflesh();
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            up();
        }
        private void btndown_Click(object sender, EventArgs e)
        {
            down();
        }
        private void up()
        {
            int index = listmytt.SelectedIndex;
            if (index != -1)
            if (index > 0)
            {
                string buffer = (string)listmytt.Items[index - 1];
                listmytt.Items[index - 1] = listmytt.Items[index];
                listmytt.Items[index] = buffer;
                listmytt.SelectedIndex = index -1;
            }
        }
        private void down()
        {
            int index = listmytt.SelectedIndex;
            if(index!=-1)
            if (index < listmytt.Items.Count-1)
            {
                string buffer = (string)listmytt.Items[index + 1];
                listmytt.Items[index + 1] = listmytt.Items[index];
                listmytt.Items[index] = buffer;
                listmytt.SelectedIndex = index + 1;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string selected = (string)listmytt.SelectedItem;
          
            if (selected != null)
            {
                int selectedindex = listmytt.Items.IndexOf(selected);
                listmytt.Items.Remove(selected);
                lsttt.Items.Add(selected);
                if (listmytt.Items.Count != 0)
                    listmytt.SelectedIndex = ((selectedindex - 1) != -1) ? selectedindex-1 : 0;
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (listname.Text.Trim() != "" && listmytt.Items.Count != 0)
            {
                List<TTPackage> listpac = new List<PackageTT.TTPackage>();
                for (int i = 0; i < listmytt.Items.Count; i++)
                {
                    listpac.Add(packages.FirstOrDefault(x => x.Name == (string)listmytt.Items[i]));
                }
                
                if (IsNew)
                    if (ttconrainer.GetContainer(listname.Text) ==null)
                    ttconrainer.container.Add(new StorageContainer() { ListName = listname.Text, Package = listpac });
                    else
                        MessageBox.Show("Same list name");
                else
                {
                    ttconrainer.container.Remove(ttconrainer.container.FirstOrDefault(x => x.ListName == listname.Text));
                    ttconrainer.container.Add(new StorageContainer() { ListName = listname.Text, Package = listpac });
                }
                ttconrainer.Save();
                this.Close();
            }
            else
                MessageBox.Show("Invalid operation");
        }
    }
}
