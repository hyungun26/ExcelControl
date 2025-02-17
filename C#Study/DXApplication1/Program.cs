using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraSpreadsheet;
using DevExpress.SpreadsheetSource;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DXApplication1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ExcelTest ex = new ExcelTest();
            Application.Run(new Form1());
            ex.ExcelControlExit();
            Task.Delay(1000);
        }
    }
}
