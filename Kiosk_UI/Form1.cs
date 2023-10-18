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
using Kiosk_UI.Properties;
using TTSLib;
using System.Collections;

namespace Kiosk_UI
{    
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        /*
        public categories Category { get => _category; set => _category = value; }
        public Image Icon { get => txtImg.Image; set => txtImg.Image = value; }
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public int Cost { get => _cost; set { _cost = value; lblCost.Text =Convert.ToString(_cost)+"원"; } }
        public bool Caffein { get; set; }
        public bool Milk { get; set; }
        public bool Sweet { get; set; }
        //Tag는 Object클래스 이름으로 사용됨 => Detial로 변경
        public string[] Detail { get; set; }
        */

        //public void AddItem(string name, int cost, categories category, string icon)
        public void AddItem(string name, int cost, categories category, string icon, string[] detail)
        {
            MenuPanel.Controls.Add(new item()
            {
                Title = name,
                Cost = cost,
                Category = category,
                Icon = Image.FromFile("icons/" + icon),
                Detail=detail

            });
            
        }
        public List<string> Search(string searchString,bool include)
        {
            List<string> result = new List<string>();
            if (include)
                foreach (var item in MenuPanel.Controls)
                {
                    {
                        var itm = (item)item;
                        if (itm.Title == searchString || itm.Detail.Contains(searchString))
                        {
                            result.Add(itm.Title);
                        }
                    }
                }
            else
                foreach (var item in MenuPanel.Controls)
                {                  
                    {
                        var itm = (item)item;
                        if (!(itm.Title == searchString || itm.Detail.Contains(searchString)))
                        {
                            result.Add(itm.Title);
                        }
                    }
                }
            return result;
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            var csv = "../../resources/menu.csv";
            {
                var lines = File.ReadAllText(csv);

                foreach (string line in lines.Split('\n'))
                {
                    string[] result = line.Split(',');
                    if (result[2] == "categories.drink")
                    {
                        AddItem(result[0], Convert.ToInt32(result[1]), categories.drink, result[3], result[4].Split('/'));
                        //AddItem(result[0], Convert.ToInt32(result[1]), categories.drink, result[3]);
                    }
                    else if(result[2] == "categories.dessert")
                    {
                        AddItem(result[0], Convert.ToInt32(result[1]), categories.dessert, result[3], result[4].Split('/'));
                        //AddItem(result[0], Convert.ToInt32(result[1]), categories.dessert, result[3]);
                    }
                }
            }
            Search("우유",true);
        ////음료
        //AddItem("아메리카노", 2000, categories.drink, "americano.png",detail:new string[]{ "커피","카페인"});
        //AddItem("에스프레소", 2000, categories.drink, "espresso.png");
        //AddItem("카푸치노", 3000, categories.drink, "cappuccino.png");
        //AddItem("녹차라떼", 3500, categories.drink, "greentealatte.png");
        //AddItem("아이스초코", 2500, categories.drink, "icedchocolate.png");
        //AddItem("카페라떼", 2500, categories.drink, "cafelatte.png");
        //AddItem("카라멜 마끼아또", 2500, categories.drink, "caramelmacchiato.png");
        //AddItem("커피 플렛치노", 2500, categories.drink, "coffeeflatccino.png");
        //AddItem("아이스티", 2500, categories.drink, "icedtea.png");
        //AddItem("밀크티", 2500, categories.drink, "milktea.png");
        //AddItem("요거트 플렛치노", 2500, categories.drink, "yogurtflatccino.png");
        //AddItem("민트초코", 2500, categories.drink, "mintchocolate.png");
        //AddItem("아인슈페너", 2500, categories.drink, "einspenner.png");
        //AddItem("레몬그라스차", 2500, categories.drink, "lemongrasstea.png");
        //AddItem("페퍼민트차", 2500, categories.drink, "pepperminttea.png");
        //AddItem("로즈마리차", 2500, categories.drink, "rosemarytea.png");
        //AddItem("캐모마일차", 2500, categories.drink, "chamomiletea.png");

            ////디저트
            //AddItem("베이글", 1500, categories.dessert, "bagel.png");
            //AddItem("블루베리 베이글", 1500, categories.dessert, "blueberrybagel.png");
            //AddItem("조각 치즈케이크", 1500, categories.dessert, "cheesecake.png");
            //AddItem("조각 초콜릿케이크", 1500, categories.dessert, "chocolatecake.png");
            //AddItem("조각 딸기케이크", 1500, categories.dessert, "strawberrycake.png");
            //AddItem("초코칩쿠키", 1500, categories.dessert, "cookie.png");
            //AddItem("더블초코칩 쿠키", 1500, categories.dessert, "doublecookie.png");
            //AddItem("녹차 쿠키", 1500, categories.dessert, "greenteacookie.png");
            //AddItem("허니브레드", 1500, categories.dessert, "honeybread.png");
            //AddItem("딸기마카롱", 1500, categories.dessert, "strawberrymacaron.png");
            //AddItem("초코마카롱", 1500, categories.dessert, "chocomacaron.png");
            //AddItem("녹차마카롱", 1500, categories.dessert, "greenteamacaron.png");


        }

        private void AllmenuButton_Click(object sender, EventArgs e)
        {
            foreach (var type in MenuPanel.Controls)
            { 
                var itm = (item)type; 
                itm.Visible = true; 
            }
        }

        private void DrinkButton_Click(object sender, EventArgs e)
        {
            foreach (var type in MenuPanel.Controls)
            {
                var itm = (item)type;
                if (itm.Category.ToString() == "dessert")
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
                if (itm.Category.ToString() == "dessert")
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

        private async void VoiceButton_Click(object sender, EventArgs e)
        {
            //모든 메뉴 가리기
            foreach (var item in MenuPanel.Controls)
            {
                var control = (item)item;
                if (control != null)
                {
                    control.Visible = false;
                }
            }

            var tts = new TextToSpeechConverter();
            tts.Speak("음성인식을 시작합니다");
            Console.WriteLine("음성인식 시작");

            string token = await Tokenizer.VoiceTokenizer();
            Console.WriteLine(token);


            List<string> searchResults = new List<string>();
            token=token.Replace('+', ' ');
            string[] texts = token.Split(' ');
            bool flagForSearch = false; // 검색 결과 초기화를 위한 플래그
            if (texts.Contains("들어가/VV"))
                foreach (var text in texts)
                {
                    string[] morps = text.Split('/');
                    List<string> Result = Search(morps[0], true);
                    if ((morps[1] == "NNP" || morps[1] == "NNG"))
                    {
                        if (flagForSearch)
                        {
                            // 이미 결과가 존재하면 결과와 교차(intersect)시키기
                            searchResults = searchResults.Intersect(Result).ToList();
                        }
                        else
                        {
                            // 처음 검색 결과를 설정
                            searchResults = Result;
                            flagForSearch = true;
                        }
                        foreach (var tmp in searchResults)
                        {
                            Console.WriteLine($"{tmp}");
                        }
                    }

                }
            else
                foreach (var text in texts)
                {
                    string[] morps = text.Split('/');
                    List<string> Result = Search(morps[0], true);
                    if ((morps.Length >= 2 && (morps[1] == "NNP" || morps[1] == "NNG")))
                    {
                        searchResults = Result;
                    }
                }
            foreach (var item in MenuPanel.Controls)
            {
                var control = (item)item;
                if (control != null)
                {
                    foreach(var text in searchResults) 
                    {
                        if (text == control.Title)
                            control.Visible = true;
                    }
                }
            }
        }

    }

}