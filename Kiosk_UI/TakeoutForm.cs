using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kiosk_UI
{
    public partial class TakeoutForm : Form
    {
        public int select_check = 0;
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

        public int _form_timer
        {
            get {  return form_timer; }
            set
            {
                form_timer = value;
                if(form_timer == 1)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    form_timer = 0;
                    Console.WriteLine("state");
                }
            }
        }
        public static int form_timer = 0;
        private void Nobutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void cafe_Click(object sender, EventArgs e)
        {
            select_check = 1;
            actbutton(sender);
        }

        private void takeout_Click(object sender, EventArgs e)
        {
            select_check = 1;
            actbutton(sender);
        }

        private void Yesbutton_Click(object sender, EventArgs e)
        {
            if (select_check < 1)
            {
                Form modalbackground = new Form();
                using (warning modal = new warning())
                {
                    modal.ShowDialog();
                    modalbackground.Dispose();

                    this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                        (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                }
            }
            else
            {
                FinishForm finishForm = new FinishForm();

                this.Hide();
                finishForm.ShowDialog();
            }
            /* using(var frm = new FinishForm())
             {
                 frm.ShowDialog();
             }*/
            
        }
    }
}
