using System;
using System.Data;
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
        }

        private void PayCheck_Shown(object sender, EventArgs e)
        {
            dataGridView1.DataSource = passedIndt;

        }
        public PayCheck(DataTable table)
        {
            InitializeComponent();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Console.WriteLine(table.Rows[i][0].ToString());
            }
            this.passedIndt = table;
            //table.Rows[0] = new Bitmap(SystemIcons.Exclamation.ToBitmap(), 8, 8);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

