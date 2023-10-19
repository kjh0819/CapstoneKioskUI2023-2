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
        static bool flag1 = !flag2 && flag3 && flag4;
        static bool flag2 = !flag1 && flag3 && flag4;
        static bool flag3 = !flag1 && flag2 && flag4;
        static bool flag4 = !flag1 && flag2 && flag3;

        static int max_width;
        static int min_width;
        private int wid;
        public MainForm()
        {
            InitializeComponent();
        }

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
            max_width = VoiceButton.Width;
            min_width = max_width / 2;

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

        private void button_tick(object sender, EventArgs e)
        {
            
        }

        private void menu_radio_CheckedChanged(object sender, EventArgs e)
        {
            if(menu_radio.Checked)
            {
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    itm.Visible = true;

                }
            }
            else if(drink_radio.Checked)
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
            else if(dessert_radio.Checked)
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
            /*else if(voice_radio.Checked)
            {

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
                    token = token.Replace('+', ' ');
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
                            foreach (var text in searchResults)
                            {
                                if (text == control.Title)
                                    control.Visible = true;
                            }
                        }
                    }
                }
            }*/

        }
    }

}