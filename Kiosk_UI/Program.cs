using AutoMotorControl;
using System;
using System.IO;
using System.Windows.Forms;

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
            try
            {
                MotorControl motorControl = new AutoMotorControl.MotorControl();
                motorControl.AutoControl();
                motorControl.init();
            }
            catch (Exception ex)
            {
                Console.WriteLine("모터 제어 오류 Main");
                Console.WriteLine(ex.Message);
            }

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
