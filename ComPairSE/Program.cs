using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ComPairSEBack
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IDataManager dataManager;

            if (args.Contains("-demo")) dataManager = new DemoDataManager();
            else dataManager = new DataManager();

            //dataManager.LoadData();

            if (args.Contains("-v2")) Application.Run(new MainForm2(dataManager));
            else Application.Run(new MainForm());
        }
    }
}
