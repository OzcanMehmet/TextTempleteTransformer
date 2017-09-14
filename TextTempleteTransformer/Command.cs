//------------------------------------------------------------------------------
// <copyright file="Command.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using EnvDTE;
using TextTempleteTransformer.GetterSetter;
using TextTempleteTransformer.PackageTT;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace TextTempleteTransformer
{
    /// <summary>
    /// Command handler
    /// </summary>
    public sealed class Command
    {
        /// <summary>
        /// Command ID.
        /// </summary>

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("c4535166-f621-42b0-88a8-08d39ad8523a");

        static IVsOutputWindowPane pane;
        static IVsStatusbar statusBar;
        static uint Cookie;
        static List<OleMenuCommand> splitlist;
        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;
        static OleMenuCommandService commandService;
        TTcontainer container;
        static List<string> name;
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private Command(Package package)
        {

            splitlist = new List<OleMenuCommand>();
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;
            serviceProvider = (IServiceProvider)package;

            commandService = Command.serviceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            statusBar = (IVsStatusbar)Command.serviceProvider.GetService(typeof(SVsStatusbar));
            Progresbarflush();
            Cookie = 0;
         
            if (commandService != null)
            {
                SetMenu(Config, 0x0002);
                SetMenu(Default, 0x0001);
                SetMenu(Default, 0x1030).Visible=true;
               
                for (int i=0;i<1;i++)
                {
                    splitlist.Add(SetMenu(0x1000 + i));
                }

            }
            createwindowpane();
            container=new TTcontainer();
            name = container.GetListName();

        }
        public static List<string> Getlistname()
        {
            return name;
        }
        private void clear()
        {
            foreach(MenuCommand command in splitlist)
            {
                command.Visible = false;
            }
        }
        public void menusetter(List<string> names)
        {
            clear();
            int counter=names.Count;
            foreach (OleMenuCommand command in splitlist)
            {
                if (counter-- != 0)
                {
                    command.Visible = true;
                    command.Text = names[counter];
                }
            }
        }
        public OleMenuCommand SetMenu(int id)
        {
            var menuCommandID = new CommandID(CommandSet, id);
            OleMenuCommand menuItem = new OleMenuCommand(Get, menuCommandID);
            
            menuItem.Visible = false; 
            commandService.AddCommand(menuItem);
            return menuItem;
        }
        private MenuCommand SetMenu(EventHandler handler, int id)
        {
            var menuCommandID = new CommandID(CommandSet, id);
            var menuItem = new MenuCommand(handler, menuCommandID);
            commandService.AddCommand(menuItem);
            return menuItem;
        }
        private void menu(object sender, EventArgs e)
        {

        }
        private  void Get(object sender, EventArgs e)
        {
            try
            {
                OleMenuCommand s = (OleMenuCommand)sender;
                if (s != null && s.Text != null && s.Enabled)
                    container.Runall(s.Text);
            }
            catch(Exception)
            {

            }
            
        }
        public static void Progresbarflush()
        {
            Cookie = 0;
            statusBar.Progress(ref Cookie, 1, "", 0, 0);
        }
        public static void ProgressBar(string label,uint current,uint total)
        {
            
            statusBar.Progress(ref Cookie, 1, label, current, total);
        }
        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static Command Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
         internal static  IServiceProvider serviceProvider;
      
        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static Command Initialize(Package package)
        {
            return Instance = new Command(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Config(object sender, EventArgs e)
        {
           
          
            try
            {
                new TextTempleteTransform(this,container).ShowDialog();

            }
            catch(ExceptionTextTemplete ex)
            {
                VsShellUtilities.ShowMessageBox(
                              serviceProvider,
                              ex.Message,
                              "Error",
                              OLEMSGICON.OLEMSGICON_INFO,
                              OLEMSGBUTTON.OLEMSGBUTTON_OK,
                              OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            }
            catch(Exception ex)
            {

            }
                


         
          
        }
        private void Default(object sender, EventArgs e)
        {
            try
            {
               container.RunDefault();
            }
            catch (ExceptionTextTemplete ex)
            {
                VsShellUtilities.ShowMessageBox(
                              serviceProvider,
                              ex.Message,
                              "Error",
                              OLEMSGICON.OLEMSGICON_INFO,
                              OLEMSGBUTTON.OLEMSGBUTTON_OK,
                              OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            }
            catch (Exception ex)
            {

            }
        }
        public void createwindowpane()
        {
            pane = (IVsOutputWindowPane)Command.serviceProvider.GetService(typeof(SVsGeneralOutputWindowPane));
            pane.SetName("BTSoft T4 Templete Transform");
        }
        public static void paneflush()
        {
            pane.Clear();
        }
        public static void Outstring(string outstring)
        {
            pane.OutputString(outstring);    
        }
    
      
       
      
    }
}
