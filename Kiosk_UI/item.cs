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
    public enum categories { drink, dessert }
    public partial class item : UserControl
    {
        private categories _category;
        private int _cost;

        public event EventHandler OnSelect = null;


        public categories Category { get => _category; set => _category = value; }
        public Image Icon { get => txtImg.Image; set => txtImg.Image = value; }
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public int Cost { get => _cost; set { _cost = value; lblCost.Text =Convert.ToString(_cost)+"원"; } }
        public bool Caffein { get; set; }
        public bool Milk { get; set; }
        public bool Sweet { get; set; }
        //Tag는 Object클래스 이름으로 사용됨 => Detial로 변경
        public string[] Detail { get; set; }
        public item()
        {
            InitializeComponent();
        }

        private void txtImg_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }
    }
}
