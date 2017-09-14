using EnvDTE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTempleteTransformer.GetterSetter;
using VSLangProj;
namespace TextTempleteTransformer.PackageTT
{
    [Serializable]
    public class TTPackage
    {

   
        public TTPackage(ProjectItem item)
        {
            GetError = new List<string>();
            Project = item;
         
            
        }
        public TTPackage()
        {
            GetError = new List<string>();
        }

        public void serilizettgeter()
        {
            try
            {
                if (Project == null)
                    Project = new TTGetter().GetTTs().FirstOrDefault(x => x.Name == Name).Project;
            }
            catch(Exception)
            {

            }
        }
        public string Path { get { return projectitem.Properties.Item("FullPath").Value.ToString(); } }
        public List<string> GetError { get; private set; }
        public string Toolname { get; set; }
        public string Name { get; set; }
        private ProjectItem projectitem { get; set; }
        private ProjectItem Project {
            get
            {
                return projectitem;
            }
            set
            {
                projectitem = value;
                svsproject = (VSProjectItem)projectitem.Object;
            }
        }
        private VSProjectItem svsproject { get; set; }
        public bool run()
        {
            serilizettgeter();
            
            svsproject.RunCustomTool();
            return Errorcontrol();

        }
        public bool Errorcontrol()
        {
            int errorcounter=0;
            ProjectItems items = projectitem.ProjectItems;
            if (items != null)  
                foreach (ProjectItem itemproject in items)
                {
                    if (DocumentErrorControl(itemproject))
                        errorcounter++; 
                    
                }
            Command.Outstring(messagewriter(errorcounter!=0, Name));
            return errorcounter != 0;
        }
        public bool DocumentErrorControl(ProjectItem itemproject)
        {
            Exception Ex = null;
            try
            {


                string path = itemproject.Properties.Item("FullPath").Value.ToString();
                string document = File.ReadAllText(path);
                return document.Contains("ErrorGeneratingOutput");
            }catch(Exception ex)
            {
                Ex = ex;
                return false;
            }
            

        }
        public string messagewriter(bool error, string name)
        {
     
            string message = "\n==>Transform: " + name + "......" + ((error) ? "Fail":"Succeed");
            return message;
        }
      
    }
    
}
