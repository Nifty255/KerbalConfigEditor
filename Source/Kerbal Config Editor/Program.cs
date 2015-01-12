using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KerbalConfigEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Validate correct install.
#if (!DEBUG)
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\KSP.exe"))
            {
                System.Windows.Forms.MessageBox.Show("Error: This program must be installed in your KSP install directory.", "Error 404: KSP Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
#endif

            // Create Autosave folder if it doesn't exist.
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\KCE_Data\\Autosave"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\KCE_Data\\Autosave");
            }

            // Set the Assembly Handler.
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);

            // Start the application.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProgramForm());
        }

        private static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            // This handler is called only when the common language runtime tries to bind to the assembly and fails.

            // Retrieve the list of referenced assemblies in an array of AssemblyName.
            Assembly MyAssembly, objExecutingAssemblies;
            string strTempAssmbPath = "";

            objExecutingAssemblies = Assembly.GetExecutingAssembly();
            AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

            // Loop through the array of referenced assembly names.
            foreach (AssemblyName strAssmbName in arrReferencedAssmbNames)
            {
                //Check for the assembly names that have raised the "AssemblyResolve" event.
                if (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(",")))
                {
                    // Build the path of the assembly from where it has to be loaded.				
                    strTempAssmbPath = Directory.GetCurrentDirectory() + "\\KSP_Data\\Managed\\" + args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
                    break;
                }

            }
            // Load the assembly from the specified path. 					
            MyAssembly = Assembly.LoadFrom(strTempAssmbPath);

            // Return the loaded assembly.
            return MyAssembly;
        }
    }
}