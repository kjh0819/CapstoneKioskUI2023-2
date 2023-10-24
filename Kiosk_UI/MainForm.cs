﻿using System;
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
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Kiosk_UI
{

    public partial class MainForm : Form
    {
        private MqttClient client = new MqttClient("kjh0819.duckdns.org");
        const string csv = "../../resources/menu.csv";
        bool flagForNewFile=false;

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
            try
            {
                MenuPanel.Controls.Add(new item()
                {
                    Title = name,
                    Cost = cost,
                    Category = category,
                    Icon = Image.FromFile("icons/" + icon),
                    Detail = detail

                });
            }
            catch {
                MenuPanel.Controls.Add(new item()
                {
                    Title = name,
                    Cost = cost,
                    Category = category,
                    Icon = Image.FromFile("icons/" + "americano.png"),
                    Detail = detail

                });
            }
            
        }
        public void RemoveItem(string name)
        {
            foreach (var control in MenuPanel.Controls)
            {
                if (control is item menuItem && menuItem.Title == name)
                {
                    // 메뉴 항목을 MenuPanel.Controls에서 제거
                    MenuPanel.Controls.Remove(menuItem);
                    break;
                }
            }
        }
        public void RemoveItemAll()
        {
            foreach (var control in MenuPanel.Controls)
            {
                if (control is item menuItem)
                {
                    // 메뉴 항목을 MenuPanel.Controls에서 제거
                    MenuPanel.Controls.Clear();
                }
            }
        }

        public void updateItem()
        {
            RemoveItemAll();
            foreach (var item in MenuPanel.Controls)
            {
                var control = (item)item;
                if (control != null)
                {
                    control.Visible = false;
                }
            }

            var lines = File.ReadAllText(csv);

            foreach (string line in lines.Split('\n'))
            {
                string[] result = line.Split(',');
                string[] details = result[4].Split('/');
                details[details.Length - 1] = details[details.Length - 1].Replace('\n', ' ').Trim();
                if (result[2] == "categories.drink")
                {
                    AddItem(result[0], Convert.ToInt32(result[1]), categories.drink, result[3], details);
                    //AddItem(result[0], Convert.ToInt32(result[1]), categories.drink, result[3]);
                }
                else if (result[2] == "categories.dessert")
                {
                    AddItem(result[0], Convert.ToInt32(result[1]), categories.dessert, result[3], result[4].Split('/'));
                    //AddItem(result[0], Convert.ToInt32(result[1]), categories.dessert, result[3]);
                }
            }

            foreach (var item in MenuPanel.Controls)
            {
                var control = (item)item;
                if (control != null)
                {
                    control.Visible = true;
                }
            }
        }

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

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // e.Topic : 토픽 이름
            // e.Message : 메시지 내용 (바이트 배열)
            // e.DupFlag : 중복 플래그
            // e.QosLevel : QoS 레벨
            // e.Retain : retain 플래그
            string m = Encoding.UTF8.GetString(e.Message);
            string t = e.Topic;

            switch (t)
            {
                case "Menu/exist":
                    Console.WriteLine(m);
                    break;
                case "Menu/request":
                    string message = File.ReadAllText(csv);
                    string topic = "Menu/exist";
                    Console.Write(message);
                    client.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                    break;
                case "Menu/NewImage":
                    Console.WriteLine(m);

                    File.WriteAllBytes("../../../test.png", e.Message);
                    break;
                case "Menu/NewFile":
                    Console.WriteLine(m);
                    File.WriteAllText(csv, m);
                    flagForNewFile = true;
                    break;
                case "Menu/Update":
                    updateItem();
                    break;
            }
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            string clientId = Guid.NewGuid().ToString();
            string username = "IndukKioskB";
            string password = "08190919";
            byte code = client.Connect(clientId, username, password);
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; // 메시지 수신 이벤트 핸들러 등록
            client.Subscribe(new string[] { "Menu/NewImage", "Menu/exist", "Menu/request", "Menu/NewFile" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE }); // test/topic 토픽을 QoS 1로 구독
            client.Publish("Menu/Update", Encoding.UTF8.GetBytes(""), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
            do { } while (!flagForNewFile);
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
                flagForNewFile=false;
            }



        }

        private void AllmenuButton_Click(object sender, EventArgs e)
        {
            updateItem();
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