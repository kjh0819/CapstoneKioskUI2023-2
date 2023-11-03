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

        public PayCheck(DataTable table)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Nobutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();

        }

        private void PayCheck_Shown(object sender, EventArgs e)
        {
        }
    }
}
