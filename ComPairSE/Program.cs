using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ComPairSE
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
            if (args.Length == 0)
                Application.Run(new MainForm());
            else if (args.Length == 1)
            {
                switch (args[0])
                {
                    case "-v2":
                        Application.Run(new MainForm2());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
