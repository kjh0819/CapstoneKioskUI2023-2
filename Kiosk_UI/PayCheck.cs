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
    public partial class PayCheck : Form
    {
        public PayCheck()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Yesbutton_Click(object sender, EventArgs e)
        {
            MainForm Obj = new MainForm();
            Obj.Show();
            this.Hide();
        }
    }
}
