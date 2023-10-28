using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Kiosk_UI
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var csv = "resources/menu.csv";

            if (!Directory.Exists("resources"))
                Directory.CreateDirectory("resources");
            if (!File.Exists(csv))
            {
                File.WriteAllText(csv, string.Empty);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
