using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinMoreNSnap
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var appSingleton = new System.Threading.Mutex(false, "SingleInstance WinMoreNSnap");
            if (appSingleton.WaitOne(0, false))
                Application.Run(new TrayApp());
            appSingleton.Close();
        }
    }
}
