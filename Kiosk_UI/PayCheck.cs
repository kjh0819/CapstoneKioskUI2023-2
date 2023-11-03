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
        DataTable passedIndt;
        public PayCheck()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Nobutton_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Hide();
            foreach (DataRow row in passedIndt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.WriteLine(item.ToString());
                }
            }

        }

        private void PayCheck_Shown(object sender, EventArgs e)
        {
            dataGridView1.DataSource = passedIndt;
        }
        public PayCheck(DataTable table)
        {
            InitializeComponent();

            this.passedIndt = table;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}

