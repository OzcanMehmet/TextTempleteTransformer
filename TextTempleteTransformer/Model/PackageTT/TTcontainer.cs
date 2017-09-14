using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextTempleteTransformer.GetterSetter;
using TextTempleteTransformer.PackageTT;

namespace TextTempleteTransformer
{
    public class TTcontainer
    {
      
        readonly string filenamedefault ;
        Model model { get; set; }
        public List<StorageContainer> container { get;  set; }
        private string listname { get; set; }
        List<TTPackage> alltt { get; set; }
        List<StorageContainer> Remove { get; set; }
        public TTcontainer()
        {
            filenamedefault = (new SolutionGetter().SolutionName() + ".txt");
            model = new Model(filenamedefault);
            alltt = new TTGetter().GetTTs();
            listname = Model.DefaultList;
            setcontainer();
            StorageContainerController();
        }
        public void StorageContainerController()
        {
            Remove = new List<StorageContainer>();
            foreach (StorageContainer cont in container)
                if (!cont.Package.Any() && cont.ListName!=Model.DefaultList)
                    Remove.Add(cont);
            foreach (StorageContainer cont in Remove)
                container.Remove(cont);
            Save();
        }
        public bool Runall(string name)
        {
            try
            {
                listname = name;
                Command.paneflush();
                if (listname != null)
                    run();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public void Save()
        {
            model.write();
        }
        public List<string> GetListName()
        {
            removelistwriter();
            List<string> names = container.Select(x=>x.ListName).ToList();
            return names;
        }
        private void removelistwriter()
        {
            foreach (string list in Remove.Select(x => x.ListName))
            {
                Command.Outstring("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Command.Outstring("\nList Name:" + list+ " removed => Empty list");
                Command.Outstring("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
        }
        private void run()
        {
            int ErrorCounter = 0, successcounter = 0;
            Command.Outstring("\nList: "+listname+" \nTransform Text Templete");
            Command.Outstring("\n////////////////////////////////////////////");
            List<TTPackage> packages = container.FirstOrDefault(x => x.ListName == listname).Package;
            foreach (TTPackage package in packages)
            {
                if (package.run())
                    ErrorCounter++;
                else
                    successcounter++;
                Command.ProgressBar("BTSoft Text Templete Run        Total: "+ packages.Count.ToString()+ "  Completed: "+(ErrorCounter + successcounter).ToString(), (uint)(ErrorCounter+successcounter), (uint)packages.Count);
            }
            Command.Progresbarflush();
            Command.Outstring("\nResult==> Fail:" + ErrorCounter.ToString() + "\nResult==> Success:" + successcounter.ToString());
            Command.Outstring("\n////////////////////////////////////////////");
        }
        public void Refresh()
        {
            model.Refresh();
        }
        private void setcontainer()
        {
            container = model.Container;
           
            if(!container.Any())
            {
                model.write(new StorageContainer() { ListName = Model.DefaultList, Package = GetDefaultList() });
                container = model.Container; 
            }
            if (container != null)
            {
                StorageContainer def = container.FirstOrDefault(x => x.ListName == Model.DefaultList);
                alltt = new TTGetter().GetTTs();
                foreach (TTPackage pac in alltt)
                {
                    if (def.Package.FirstOrDefault(x => x.Name == pac.Name) == null)
                    {
                        def.Package.Add(pac);
                    }
                }
                Save();  
            }
        }
        public void RunDefault()
        {
            Runall(Model.DefaultList);
        }
        public List<TTPackage> GetTTlist()
        {
            return new TTGetter().GetTTs();
        }
        private List<TTPackage> getList(string name)
        {
            return  model.GetItems(name);
        }
        public StorageContainer GetContainer(string name)
        {
            return container.FirstOrDefault(x => x.ListName == name);
        }
        private List<TTPackage> GetDefaultList()
        {
            string def = Model.DefaultList;
            List<TTPackage> packages = model.GetItems(def);
            if (packages != null)
                return packages;
            else
            {
                List<TTPackage> pck = GetTTlist();
                model.write(new StorageContainer() { ListName = def, Package = pck });
                return pck;
            }
        }
    }
    
}
