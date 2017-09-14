using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using TextTempleteTransformer.PackageTT;
using System.Xml.Serialization;

namespace TextTempleteTransformer.GetterSetter
{
    public class Model
    {
        public static string DefaultList { get { return "Default"; } }
        public string Filename { get; private set; }
        public string Path { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\IMS" + "\\"; } }
    
        public List<StorageContainer> Container { get;private set; }
        StorageContainer Default { get; set; }
        public List<TTPackage> AllTT { get { return new TTGetter().GetTTs(); } }
        private object locked = new object();

        public Model(string filename)
        {
            try
            {
                
                Filename = filename;
             
                Container = get();
                Exists();
            }
            catch(Exception ex)
            {
                throw new ExceptionTextTemplete("Solution or project item not found\nThat is loading or broken project item");
            }


        }
        public void Refresh()
        {
            Container = get();
        }
        public void Exists()
        {      
            List<TTPackage> removeobject = new List<TTPackage>();
            foreach (StorageContainer cont in Container)
                foreach (TTPackage pac in cont.Package)
                    if (AllTT.FirstOrDefault(x => x.Name == pac.Name) == null)
                        removeobject.Add(pac);
            List<TTPackage> buffer = new List<TTPackage>();
            if (removeobject.Any())
            {
                Command.Outstring("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                foreach (TTPackage package in removeobject)
                {
                     
                       StorageContainer pac = Container.FirstOrDefault(x => x.Package.Contains(package));
                    if (pac != null)
                    {
                        Container.FirstOrDefault(x => x.ListName == pac.ListName).Package.Remove(package);
                        if (buffer.FirstOrDefault(x=>x.Name==package.Name)==null) 
                        Removettoutwriter(package.Name);
                    }
                    buffer.Add(package);
                }
                Command.Outstring("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            write();
        }
        public void Removettoutwriter(string name)
        {
            Command.Outstring("\n" + name + " Removed => Can not found Solution");
        }
        public void write(StorageContainer package)
        {
           
            try
            {
                containerconfig(package);
                write();
            }
            catch (Exception ex)
            {
                throw new ExceptionTextTemplete("Write eror");
            }
           

        }
        public void write()
        {
            lock (locked)
            {
                if (!File.Exists(Path))
                    Directory.CreateDirectory(Path);
                File.Delete(Path + Filename);
                if (Container != null)
                    using (StreamWriter writer = new StreamWriter(Path + Filename, true))
                    {
                        writer.Flush();
                        Serilize(Container, writer);
                        writer.Close();
                    }
            }
        }
        private void containerconfig(StorageContainer package)
        {
            StorageContainer container = Container.FirstOrDefault(x => x.ListName == package.ListName);
            if (container != null)
                Container.Remove(container);

                Container.Add(package);
            

        }
        private List<StorageContainer> get()
        {
            lock (locked)
            {
                try
                {

                    using (StreamReader reader = new StreamReader(Path + Filename))
                    {

                        List<StorageContainer> buffer = Deserilize(reader);
                        reader.Close();
                        return buffer;
                    }

                }
                catch (Exception ex)
                {
                   
                    return new List<StorageContainer>();
                }
            }
            

        }
        public List<TTPackage> GetItems(string name)
        {
            StorageContainer container = Container.FirstOrDefault(x => x.ListName == name);
            if (container != null)
                return container.Package;
            else
                return null;
        }
        private void Serilize(List<StorageContainer> packages,StreamWriter writer)
        {
            XmlSerializer serilize = new XmlSerializer(typeof(List<StorageContainer>));  
             serilize.Serialize(writer, packages);
        }
        private List<StorageContainer> Deserilize(StreamReader packages)
        {
            XmlSerializer serilize = new XmlSerializer(typeof(List<StorageContainer>));
            return (List<StorageContainer>)serilize.Deserialize(packages);
        }
    }
}
