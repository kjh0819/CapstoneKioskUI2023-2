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
    public partial class TakeoutForm : Form
    {
        private PictureBox curbutton;
        private void actbutton(object senderBtn)
        {

            if (senderBtn != null)
            {
                DisableButton();
                curbutton = (PictureBox)senderBtn;
                curbutton.BackColor = Color.FromArgb(244, 211, 123);
            }
        }
        private void DisableButton()
        {
            if (curbutton != null)
            {
                curbutton.BackColor = Color.White;
            }
        }
        private void Reset()
        {
            DisableButton();
        }
        public TakeoutForm()
        {
            InitializeComponent();
        }

        private void Nobutton_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void cafe_Click(object sender, EventArgs e)
        {
            actbutton(sender);
        }

        private void takeout_Click(object sender, EventArgs e)
        {
            actbutton(sender);
        }

        private void Yesbutton_Click(object sender, EventArgs e)
        {
            FinishForm obj = new FinishForm();
            obj.Show();
            this.Hide();
        }
    }
}
