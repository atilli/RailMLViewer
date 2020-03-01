using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailMLViewer
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            InfraReader infra = new InfraReader();

            infra.InitFromFile("Infra.xml");

            Form1 mainForm = new Form1();
            
            mainForm.SetIntialNetwork(infra);

            Application.Run(mainForm);
        }
    }
}
