using AutoMotorControl;
using Kiosk_UI.Custom;
using System;
using System.Windows.Forms;

namespace Kiosk_UI
{
    public partial class FinishForm : Form
    {
        private System.Windows.Forms.Timer tmr;

        
        public FinishForm()
        {
            try
            {
                MotorControl motorControl = new MotorControl();
                motorControl.Finished();
            }
            catch (Exception ex)
            {
                Console.WriteLine("모터제어 오류 FinishForm");
                Console.WriteLine(ex.Message);
            }
            InitializeComponent();

            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += delegate
            {
                tmr.Stop();
                this.Close();

            };
            tmr.Interval = (int)TimeSpan.FromSeconds(3).TotalMilliseconds;
            tmr.Start();

        }

    }
}
