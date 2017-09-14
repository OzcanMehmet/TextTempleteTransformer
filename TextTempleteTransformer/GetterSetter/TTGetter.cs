using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextTempleteTransformer.PackageTT;
using VSLangProj;

namespace TextTempleteTransformer.GetterSetter
{
    public  class TTGetter
    {
        public  const string TextTemplatingFileGenerator= "TextTemplatingFileGenerator";
        public List<TTPackage> GetTTs()
        {

            List<Project> projects = new ProjectGetter().GetProjectList();
            List<TTPackage> tt = new List<TTPackage>();
            foreach(Project proj in projects)
            {
                string ttpackage =proj.Name;
                foreach(ProjectItem item in proj.ProjectItems)
                    if(item!=null) 
                    ttfinder(item,tt,ttpackage);
            }
            return tt;
        }
        public ProjectItems getitems()
        {
            return new ProjectGetter().GetProjectList().FirstOrDefault().ProjectItems;
        }
        private static object GetPropertyValue(ProjectItem item, object index)
        {
           try
           {
               var prop = item.Properties.Item(index);
               if (prop != null)
                   return prop.Value;
           }
           catch (Exception) { }
           return null;
        }
        private bool itemcontrol(ProjectItem item, List<TTPackage> list,string package)
        {
            if (item.Name.Contains(".tt"))
            {

                string customTool = GetPropertyValue(item, "CustomTool") as string;
                if ("TextTemplatingFileGenerator" == customTool)
                {
                    
                    list.Add(new TTPackage(item) { Name = package , Toolname = customTool});

                }
                return true;
            }
            else
                return false;
        }
        
        private void ttfinder(ProjectItem projitem, List<TTPackage> list,string package)
        {

            string pac = package + "/" + projitem.Name;
                itemcontrol(projitem,list, pac);
            if (projitem.ProjectItems != null)
                foreach (ProjectItem item in projitem.ProjectItems)
                {
                    string pace = pac + "/" + item.Name;
                    if (!itemcontrol(item, list, pace))
                    ttfinder(item, list, pace);
                }

        }
    }
}
