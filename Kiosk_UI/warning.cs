using System.Windows.Forms;

namespace Kiosk_UI
{
    public partial class warning : Form
    {
        public warning()
        {
            InitializeComponent();
        }

        private void warning_Load(object sender, System.EventArgs e)
        {
            this.Location = new System.Drawing.Point(
                this.Location.X+this.Width, this.Location.Y+this.Height);
        }

        private void custom_button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
