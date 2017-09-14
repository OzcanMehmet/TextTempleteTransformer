using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextTempleteTransformer
{
    public class SolutionGetter
    {
        public Solution CurrentSolution { get; private set; }
        public SolutionGetter()
        {
            CurrentSolution = currentSolution();
        }
        private Solution currentSolution()
        {
            DTE dte = Package.GetGlobalService(typeof(DTE)) as DTE;
  
            if (dte.Solution.Count!=0)
            return dte.Solution;
            return null;
        }

        public SolutionEvents geteventhandler()
        {
            DTE dte = Package.GetGlobalService(typeof(DTE)) as DTE;

            return dte.Events.SolutionEvents;
        }

        public string SolutionName()
        {
            Solution solution = CurrentSolution;
            if (solution != null)
            {
                string name = solution.FileName;
                string[] split = name.Split('\\');
                string context = split[split.Count() - 1];
                return context.Substring(0, context.Length - 4);
            }
            return null;
        }
    }
}
