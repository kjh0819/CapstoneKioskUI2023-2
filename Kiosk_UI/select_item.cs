using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Kiosk_UI
{
    public partial class select_item : UserControl
    {
        private int _count;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // width of ellipse
          int nHeightEllipse // height of ellipse
      );



        public string Title2 { get => lblTxt.Text; set => lblTxt.Text = value; }
        public int Count { get => _count; set { _count = value; item_count.Text = Convert.ToString(_count); } }
        public int Cost2 { get; set; }
        public Image Icon2 { get => txtImg2.Image; set => txtImg2.Image = value; }
        public select_item()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            
        }

        private void plus_button_Click(object sender, EventArgs e)
        {

        }

        private void minus_button_Click(object sender, EventArgs e)
        {

        }
    }

}
