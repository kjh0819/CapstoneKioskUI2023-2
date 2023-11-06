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
        public string labeltxt
        {
            get { return this.costtxt.Text; }
            set { this.costtxt.Text = value; }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Yesbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            TakeoutForm takeout = new TakeoutForm();

            DialogResult result1 = takeout.ShowDialog();
            this.Hide();
            if (result1 == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }


            //this.Hide();
            //takeout.ShowDialog();
        }
    }
}

