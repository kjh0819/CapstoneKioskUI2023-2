using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Kiosk_UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void AddItem(string name, int cost, categories category, string icon)
        {
            MenuPanel.Controls.Add(new item()
            {
                Title = name,
                Cost = cost,
                Category = category,
                Icon = Image.FromFile("icons/" + icon),
                

            });
            
        }
        class Search
        {
            
            
        }
        class CsvParser
        {
            public static string parser(string csv)
            {
                var test = File.ReadAllText(csv);

                return "0";
            }
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            CsvParser.parser("Resources/menu.csv");
        //음료
        AddItem("아메리카노", 2000, categories.drink, "americano.png");
            AddItem("에스프레소", 2000, categories.drink, "espresso.png");
            AddItem("카푸치노", 3000, categories.drink, "cappuccino.png");
            AddItem("녹차라떼", 3500, categories.drink, "greentealatte.png");
            AddItem("아이스초코", 2500, categories.drink, "icedchocolate.png");
            AddItem("카페라떼", 2500, categories.drink, "cafelatte.png");
            AddItem("카라멜 마끼아또", 2500, categories.drink, "caramelmacchiato.png");
            AddItem("커피 플렛치노", 2500, categories.drink, "coffeeflatccino.png");
            AddItem("아이스티", 2500, categories.drink, "icedtea.png");
            AddItem("밀크티", 2500, categories.drink, "milktea.png");
            AddItem("요거트 플렛치노", 2500, categories.drink, "yogurtflatccino.png");
            AddItem("민트초코", 2500, categories.drink, "mintchocolate.png");
            AddItem("아인슈페너", 2500, categories.drink, "einspenner.png");
            AddItem("레몬그라스차", 2500, categories.drink, "lemongrasstea.png");
            AddItem("페퍼민트차", 2500, categories.drink, "pepperminttea.png");
            AddItem("로즈마리차", 2500, categories.drink, "rosemarytea.png");
            AddItem("캐모마일차", 2500, categories.drink, "chamomiletea.png");

            //디저트
            AddItem("베이글", 1500, categories.dessert, "bagel.png");
            AddItem("블루베리 베이글", 1500, categories.dessert, "blueberrybagel.png");
            AddItem("조각 치즈케이크", 1500, categories.dessert, "cheesecake.png");
            AddItem("조각 초콜릿케이크", 1500, categories.dessert, "chocolatecake.png");
            AddItem("조각 딸기케이크", 1500, categories.dessert, "strawberrycake.png");
            AddItem("초코칩쿠키", 1500, categories.dessert, "cookie.png");
            AddItem("더블초코칩 쿠키", 1500, categories.dessert, "doublecookie.png");
            AddItem("녹차 쿠키", 1500, categories.dessert, "greenteacookie.png");
            AddItem("허니브레드", 1500, categories.dessert, "honeybread.png");
            AddItem("딸기마카롱", 1500, categories.dessert, "strawberrymacaron.png");
            AddItem("초코마카롱", 1500, categories.dessert, "chocomacaron.png");
            AddItem("녹차마카롱", 1500, categories.dessert, "greenteamacaron.png");
            

        }

        private void AllmenuButton_Click(object sender, EventArgs e)
        {
            foreach (var type in MenuPanel.Controls)
            { var itm = (item)type; itm.Visible = true; }
        }

        private void DrinkButton_Click(object sender, EventArgs e)
        {
            foreach (var type in MenuPanel.Controls)
            {
                var itm = (item)type;
                if (itm.Tag.ToString() == "dessert")
                {
                    itm.Visible = false;
                }
                else { itm.Visible = true; }
            }
        }

        private void DessertButton_Click(object sender, EventArgs e)
        {
            foreach (var type in MenuPanel.Controls)
            {
                var itm = (item)type;
                if (itm.Tag.ToString() == "dessert")
                {
                    itm.Visible = true;
                }
                else { itm.Visible = false; }
            }
        }


        private void textBox1_Enter(object sender, EventArgs e)
        {
            foreach (var type in MenuPanel.Controls)
            {
                var itm = (item)type;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
