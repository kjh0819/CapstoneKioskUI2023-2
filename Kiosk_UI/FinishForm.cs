using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_UI
{
    public partial class FinishForm : Form
    {
        private System.Windows.Forms.Timer tmr;

        public FinishForm()
        {
            InitializeComponent();

            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += delegate
            {
                MainForm frm = new MainForm();

                tmr.Stop();
                this.Close();
                
            };
            tmr.Interval = (int)TimeSpan.FromSeconds(3).TotalMilliseconds;
            tmr.Start();
        }

    }
}
