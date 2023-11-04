using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Kiosk_UI
{

    public partial class select_item : UserControl
    {
        //디자인//
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
        //디자인//


        private int _count;
        public event EventHandler OnSelect = null;
        public event EventHandler plusbt = null;
        public event EventHandler minusbt = null;

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

        void plus_button_Click(object sender, EventArgs e)
        {
            Count += 1;
            plusbt?.Invoke(this, e);
        }

        private void minus_button_Click(object sender, EventArgs e)
        {
            if (Count > 1)
            {
                Count -= 1;
                minusbt?.Invoke(this, e);

            }
            else
            {
                OnSelect?.Invoke(this, e);
            }

        }


    }

}
