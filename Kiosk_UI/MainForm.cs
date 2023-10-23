using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public void AddItem2(string name2, int cost2, int count, string icon2)
        {
            checkPanel.Controls.Add(new select_item()
            {
                Title2 = name2,
                Cost2 = cost2,
                Count = count,
                Icon2 = Image.FromFile("icons/" + icon2)
            });
        }

        public void AddItem(string name, int cost, categories category, string icon, string[] detail)
        {
            var i = new item()
            {
                Title = name,
                Cost = cost,
                Category = category,
                Icon = Image.FromFile("icons/" + icon),
                Detail=detail

            };
            MenuPanel.Controls.Add(i);

            i.OnSelect += (ss, ee) =>
            {
                int a = 1;
                foreach (var sl in checkPanel.Controls)
                 {
                      var sl_itm = (select_item)sl;
                    if (sl_itm.Title2 == name.ToString()) 
                      {
                        a = +1;
                      }
                }
                AddItem2(name, cost, a, icon);


                /*foreach (DataGridViewRow rows in dataGridView1.Rows)
                {
                    if (rows.Cells[0].Value.ToString() == itm.Title)
                    {
                        rows.Cells[1].Value = int.Parse(rows.Cells[1].Value.ToString()) + 1;
                        rows.Cells[2].Value = (int.Parse(rows.Cells[2].Value.ToString())) + int.Parse(rows.Cells[2].Value.ToString());
                        Calculate();
                        return;
                    }
                }
                dataGridView1.Rows.Add(new object[] { itm.Title, 1, itm.Cost});
                Calculate();*/
            };
        }

       /* void Calculate()
        {
            int W = 0;
            foreach (DataGridViewRow rows in dataGridView1.Rows)
            {
                W += int.Parse(rows.Cells[2].Value.ToString().Replace("원", ""));
            }
            //lblW.Text = txt.Tostring()
        }*/
        public List<string> Search(string searchString,bool include)
        {
            List<string> result = new List<string>();
            if (include)
                foreach (var item in MenuPanel.Controls)
                {
                    {
                        var itm = (item)item;
                        if (itm.Title == searchString)
                        {
                            result.Add(itm.Title);
                        }
                        else
                            foreach(var d in itm.Detail)
                            {
                                if (d == searchString)
                                {
                                    result.Add(itm.Title);
                                }
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

            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(1, 1, AllmenuButton.Width - 1, AllmenuButton.Height - 1);
            AllmenuButton.Region = new Region(p);

            var csv = "../../resources/menu.csv";
            {
                var lines = File.ReadAllText(csv);
                
                foreach (string line in lines.Split('\n'))
                {
                    string[] result = line.Split(',');
                    string[] details=result[4].Split('/');
                    details[details.Length - 1] = details[details.Length - 1].Replace('\n', ' ').Trim();
                    if (result[2] == "categories.drink")
                    {
                        AddItem(result[0], Convert.ToInt32(result[1]), categories.drink, result[3], details);
                        //AddItem(result[0], Convert.ToInt32(result[1]), categories.drink, result[3]);
                    }
                    else if(result[2] == "categories.dessert")
                    {
                        AddItem(result[0], Convert.ToInt32(result[1]), categories.dessert, result[3], result[4].Split('/'));
                        //AddItem(result[0], Convert.ToInt32(result[1]), categories.dessert, result[3]);
                    }
                }
            }
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
            var tts = new TextToSpeechConverter();
            //모든 메뉴 가리기
            foreach (var item in MenuPanel.Controls)
            {
                var control = (item)item;
                if (control != null)
                {
                    control.Visible = false;
                }
            }


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
                    if (morps.Length >= 2 && (morps[1] == "NNP" || morps[1] == "NNG"))
                    {
                        foreach (var r in Result)
                            Console.WriteLine(r);
                        if (flagForSearch && Result.Count > 0)
                        {
                            // 이미 결과가 존재하면 결과와 교차(intersect)시키기
                                searchResults = searchResults.Intersect(Result).ToList();
                        }
                        else if(Result.Count>0)
                        {
                            // 처음 검색 결과를 설정
                            searchResults = Result;
                            flagForSearch = true;
                        }
                    }
                }
            else if (texts.Contains("없/VA"))
                foreach (var text in texts)
                {
                    string[] morps = text.Split('/');
                    List<string> Result = Search(morps[0], true);
                    if (morps.Length >= 2 && (morps[1] == "NNP" || morps[1] == "NNG"))
                    {
                        if (flagForSearch && Result.Count > 0)
                        {
                            // 이미 결과가 존재하면 결과와 교차(intersect)시키기
                            searchResults = searchResults.Intersect(Result).ToList();
                        }
                        else if (!flagForSearch&&Result.Count > 0)
                        {
                            Result = Search(morps[0], false);
                            // 처음 검색 결과를 설정
                            searchResults = Result;
                            flagForSearch = true;
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
            foreach (var text in searchResults)
            {
                tts.Speak(text);
            }
            if (searchResults.Count == 0)
            {
                tts.Speak("죄송합니다 메뉴를 찾을수 없었습니다.");
            }
        }

        

        private void custom_button1_Click(object sender, EventArgs e)
        {
            PayCheck Obj = new PayCheck();
            Obj.Show();
            this.Hide();
        }
    }

}