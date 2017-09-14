using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE80;
namespace TextTempleteTransformer.GetterSetter
{
    public class ProjectGetter
    {
        public List<Project> GetProjectList()
        {

            Solution currentsolution = new SolutionGetter().CurrentSolution;
            if (currentsolution == null)
                throw new ExceptionTextTemplete("Solution or project not found");
            List<Project> projects = new List<Project>();
            for (int i = 1; i <= currentsolution.Count; i++)
            {
                SolutionSplitProject(currentsolution.Item(i),projects);
            }
           
            return projects;
        }
        private List<Project> SolutionSplitProject(Project project, List<Project> list)
        {
            Project currentproject = project;
            if (currentproject != null && currentproject.Kind != null)
                if (currentproject.Kind != ProjectKinds.vsProjectKindSolutionFolder)
                    list.Add(currentproject);
                else
                {

                    ProjectItems pr= currentproject.ProjectItems;
                    for (int i = 1; i <= pr.Count; i++)
                    {
                        string ss =pr.Item(i).Name;
                        SolutionSplitProject(pr.Item(i).SubProject, list);
                    }
                }
            return list;
        }



    }

}

