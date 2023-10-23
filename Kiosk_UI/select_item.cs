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
    public partial class select_item : UserControl
    {
        private int _count;



        public string Title2 { get; set; }
        public int Count { get => _count; set { _count = value; item_count.Text = Convert.ToString(_count); } }
        public int Cost2 { get; set; }
        public Image Icon2 { get => txtImg2.Image; set => txtImg2.Image = value; }
        public select_item()
        {
            InitializeComponent();
        }

        private void plus_button_Click(object sender, EventArgs e)
        {

        }

        private void minus_button_Click(object sender, EventArgs e)
        {

        }
    }

}
