using AutoMotorControl;
using Kiosk_UI.Custom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;
using TTSLib;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Kiosk_UI
{
    public partial class MainForm : Form
    {
        private Custom_button curbutton;
        TextToSpeechConverter tts = new TextToSpeechConverter();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }


        private MqttClient client = new MqttClient("kjh0819.duckdns.org");
        const string csv = "resources/menu.csv";
        bool flagForNewFile = false;
        int menuUpdateCounter = 0;
        int programExitCounter = 0;

        private void actbutton(object senderBtn)
        {

            if (senderBtn != null)
            {
                DisableButton();
                curbutton = (Custom_button)senderBtn;
                curbutton.BackColor = Color.FromArgb(109, 151, 115);
                curbutton.ForeColor = Color.White;
            }
        }
        private void DisableButton()
        {
            AllmenuButton.BackColor = Color.Moccasin;
            AllmenuButton.ForeColor = Color.FromArgb(68, 62, 45);
            if (curbutton != null)
            {
                curbutton.BackColor = Color.Moccasin;
                curbutton.ForeColor = Color.FromArgb(68, 62, 45);
            }
        }
        private void Reset()
        {
            DisableButton();
            AllmenuButton.BackColor = Color.FromArgb(100, 151, 115);
            AllmenuButton.ForeColor = Color.White;

        }
        private DispatcherTimer inputTimer;
        public MainForm()
        {
            InitializeComponent();
            inputTimer = new DispatcherTimer();
            inputTimer.Interval = TimeSpan.FromSeconds(60);
            inputTimer.Tick += InputTimer_Tick;
            PreviewKeyDown += ResetInputTimer;
            MouseDown += ResetInputTimer;
            StartInputTimer();

            this.FormClosing += MainForm_FormClosing;
            new Touch(MenuPanel);
        }
        private void ResetInputTimer(object sender, EventArgs e)
        {
            StartInputTimer();
        }
        private void StartInputTimer()
        {
            inputTimer.Stop();
            inputTimer.Start();
        }
        private void InputTimer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("비동작 감지됨");
            checkPanel.Controls.Clear();//장바구니 전체 삭제
            final_cost = 0;
            cost_lbl.Text = final_cost.ToString() + "원";
            AllmenuButton.PerformClick();
            tts.Speak("사용이 종료되었습니다.");
            
            

            try
            {
                MotorControl mtr = new MotorControl();
                mtr.Finished();
            }
            catch { }//모터 초기화 예외처리, 아두이노 미연결시 스킵
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
        public void AddItem2(string name2, int cost2, int count, string icon2)
        {
            try
            {
                var n = new select_item()
                {
                    Title2 = name2,
                    Cost2 = cost2,
                    Count = count,
                    Icon2 = Image.FromFile("icons/" + icon2)
                };
                checkPanel.Controls.Add(n);
                n.OnSelect += (ss, ee) =>
                {
                    checkPanel.Controls.Remove(n);
                    mycost -= cost2;
                };
                n.plusbt += (ss, ee) =>
                {
                    mycost += cost2;
                };
                n.minusbt += (ss, ee) =>
                {
                    mycost -= cost2;
                };

            }
            catch
            {
                var n = new select_item()
                {
                    Title2 = name2,
                    Cost2 = cost2,
                    Count = count,
                    Icon2 = Image.FromFile("icons/" + "americano.png")
                };
                checkPanel.Controls.Add(n);
                n.OnSelect += (ss, ee) =>
                {
                    checkPanel.Controls.Remove(n);
                };

            }
        }


        public void AddItem(string name, int cost, categories category, string icon, string[] detail)
        {
            try
            {
                var i = new item()
                {
                    Title = name,
                    Cost = cost,
                    Category = category,
                    Icon = Image.FromFile("icons/" + icon),
                    Detail = detail

                };
                MenuPanel.Controls.Add(i);

                i.OnSelect += (ss, ee) =>
                {

                    foreach (var sl in checkPanel.Controls)
                    {
                        var sl_itm = (select_item)sl;
                        if (name.ToString() == sl_itm.Title2) //아이템 클릭시 장바구니에 중복된 값이 있을때
                        {
                            sl_itm.Count += 1; //장바구니 카운트 추가
                            count_flag = sl_itm.Count;
                            mycost += sl_itm.Cost2; ;
                        }
                    }
                    if (count_flag == 1) //장바구니에 없는 항목 추가
                    {
                        AddItem2(name, cost, count_flag, icon); //장바구니에 추가
                        mycost += cost;
                    }
                    else
                    {
                        count_flag = 1;
                    }
                    //cost_lbl.Text = final_cost.ToString() + "원";
                };
            }
            catch
            {
                var i = new item()
                {
                    Title = name,
                    Cost = cost,
                    Category = category,
                    Icon = Image.FromFile("icons/" + "americano.png"),
                    Detail = detail

                };
                MenuPanel.Controls.Add(i);
                i.OnSelect += (ss, ee) =>
                {


                    foreach (var sl in checkPanel.Controls)
                    {
                        var sl_itm = (select_item)sl;
                        if (name.ToString() == sl_itm.Title2) //아이템 클릭시 장바구니에 중복된 값이 있을때
                        {
                            sl_itm.Count += 1; //장바구니 카운트 추가
                            count_flag = sl_itm.Count;
                            mycost += sl_itm.Cost2; ;
                        }
                    }
                    if (count_flag == 1) //장바구니에 없는 항목 추가
                    {
                        AddItem2(name, cost, count_flag, icon); //장바구니에 추가
                        mycost += cost;
                    }
                    else
                    {
                        count_flag = 1;
                    }
                    //cost_lbl.Text = final_cost.ToString() + "원";
                };
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {

            checkPanel.Controls.Clear();//장바구니 전체 삭제
            final_cost = 0;
            cost_lbl.Text = final_cost.ToString() + "원";
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
            MenuPanel.Controls.Clear();
        }

        public void updateItem()
        {
            if (flagForNewFile)
            {
                RemoveItemAll();
                var lines = File.ReadAllText(csv);
                if (lines.Length < 100) { return; }
                foreach (string line in lines.Split('*'))
                {
                    string[] result = line.Split(',');
                    string[] details = result[4].Split('/');
                    details[details.Length - 1] = details[details.Length - 1].Replace("*", "").Trim();
                    if (result[2] == "categories.drink")
                    {
                        AddItem(result[0], Convert.ToInt32(result[1]), categories.drink, result[3], details);
                    }
                    else if (result[2] == "categories.dessert")
                    {
                        AddItem(result[0], Convert.ToInt32(result[1]), categories.dessert, result[3], result[4].Split('/'));
                    }
                }
                flagForNewFile = true;
            }
        }

        public List<string> Search(string searchString, bool include)
        {
            List<string> result = new List<string>();
            if (include)
                foreach (var item in MenuPanel.Controls)
                {
                    {
                        var itm = (item)item;
                        //if (itm.Title.Contains( searchString))
                        if (itm.Title == searchString)
                        {
                            result.Add(itm.Title);
                        }
                        else
                            foreach (var d in itm.Detail)
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
                    break;
                case "Menu/request":
                    try
                    {
                        string message = File.ReadAllText(csv);
                        string topic = "Menu/exist";
                        Console.Write(message);
                        client.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                    }
                    catch
                    {
                        break;
                    }
                    break;
                case "Menu/NewImage":
                    File.WriteAllBytes("../../../test.png", e.Message);
                    break;
                case "Menu/NewFile":
                    try
                    {
                        File.WriteAllText(csv, m);
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                    flagForNewFile = true;
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
            client.Subscribe(new string[] { "Menu/NewImage", "Menu/exist", "Menu/request", "Menu/NewFile" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); // test/topic 토픽을 QoS 1로 구독
            client.Publish("Menu/Update", Encoding.UTF8.GetBytes(""), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

            while (!flagForNewFile)
                ;
            updateItem();

            flagForNewFile = false;
            foreach (var type in MenuPanel.Controls)
            {
                var itm = (item)type;
                itm.Visible = true;
            }
            cost_lbl.Text = final_cost.ToString() + "원";

            Reset();

        }

        private void AllmenuButton_Click(object sender, EventArgs e)
        {
            tts.StopSpeak();
            /*
            client.Publish("Menu/Update", Encoding.UTF8.GetBytes(""), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            do{
                updateItem();
            } while (!flagForNewFile);
            flagForNewFile = false;
            */
            menuUpdateCounter++;
            programExitCounter = 0;
            if (menuUpdateCounter == 10)
            {
                tts.StopSpeak();
                tts.Speak("메뉴 업데이트를 시작합니다.");
                client.Publish("Menu/Update", Encoding.UTF8.GetBytes(""), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                do
                {
                    updateItem();
                } while (!flagForNewFile);
                menuUpdateCounter = 0;
            }

            actbutton(sender);
            foreach (var type in MenuPanel.Controls)
            {
                var itm = (item)type;
                itm.Visible = true;
            }

        }

        private void DrinkButton_Click(object sender, EventArgs e)
        {
            tts.StopSpeak();
            menuUpdateCounter = 0;
            actbutton(sender);
            int a = 1;
            foreach (var type in MenuPanel.Controls)
            {
                var itm = (item)type;
                if (itm.Category.ToString() == "drink")
                {
                    itm.Visible = true;
                }
                else { itm.Visible = false; }
            }
            
        }
        private void DessertButton_Click(object sender, EventArgs e)
        {
            tts.StopSpeak();
            menuUpdateCounter = 0;
            programExitCounter = 0;
            actbutton(sender);
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


        private async void VoiceButton_Click(object sender, EventArgs e)
        {
            tts.StopSpeak();
            menuUpdateCounter = 0;
            programExitCounter++;
            if (programExitCounter == 10)
            {
                tts.Speak("프로그램을 종료합니다.");
                System.Environment.Exit(0);
            }
            actbutton(sender);
            //모든 메뉴 가리기
            foreach (var type in MenuPanel.Controls)
            {
                var itm = (item)type;
                itm.Visible = false;
            }
            tts.StopSpeak();
            string token = await Tokenizer.VoiceTokenizer();

            Console.WriteLine(token);
            if (token.Contains("error"))
            {
                if (token.Contains("error NOMATCH: Speech could not be recognized."))
                {
                    tts.Speak("잘 알아듣지 못했습니다.");
                    foreach (var type in MenuPanel.Controls)
                    {
                        var itm = (item)type;
                        itm.Visible = true;
                    }
                    return;

                }
                tts.Speak("에러가 발생하였습니다.");
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    itm.Visible = true;
                }
                return;
            }
            List<string> searchResults = new List<string>();
            token = token.Replace('+', ' ');
            string[] texts = token.Split(' ');

            bool flagForSearch = false; // 검색 결과 초기화를 위한 플래그



            string[][] words = new string[texts.Length][];
            for (int i = 0; i < texts.Length - 1; i++)
            {
                string[] word = texts[i].Split('/');
                words[i] = word;

            }
            bool foundNNGOrNNP = false;
            for (int i = 0; i < texts.Length - 1; i++)
            {
                Console.WriteLine(words[i][0] + words[i][1]);
                if (!foundNNGOrNNP && (words[i][1] == "NNG" || words[i][1] == "NNP"))
                {
                    foundNNGOrNNP = true;
                    continue;
                }
                else if (words[i][1] == "SP") { }
                else if (foundNNGOrNNP && (words[i][1] == "NNG" || words[i][1] == "NNP"))
                {
                    searchResults = Search(words[i - 1][0] + words[i][0], true);
                    if (searchResults.Count == 0)
                        try
                        {
                            searchResults = Search(words[i - 2][0] + words[i][0], true);
                            flagForSearch = true;
                        }
                        catch { }
                    else
                    {
                        flagForSearch = true;
                    }
                }
                else
                {
                    foundNNGOrNNP = false;
                }
            }
            if (texts.Contains("원/NNB") && texts.Contains("이상/NNG"))
            {
                for (int i = 0; i < texts.Length - 1; i++)
                {
                    if (texts[i] == "원/NNB")
                    {
                        int price = Int32.Parse(texts[i - 1].Split('/')[0]);
                        foreach (var item in MenuPanel.Controls)
                        {

                            var itm = (item)item;
                            //if (itm.Title.Contains( searchString))
                            if (itm.Cost >= price)
                            {
                                searchResults.Add(itm.Title);
                                flagForSearch = true;
                            }

                        }

                    }
                    foreach (var text in texts)
                    {
                        string[] morps = text.Split('/');
                        List<string> Result = Search(morps[0], true);
                        if (flagForSearch && Result.Count > 0)
                        {
                            // 이미 결과가 존재하면 결과와 교차(intersect)시키기
                            searchResults = searchResults.Intersect(Result).ToList();
                        }
                    }
                }
            }
            else if (texts.Contains("원/NNB") && texts.Contains("이하/NNG"))
            {
                for (int i = 0; i < texts.Length - 1; i++)
                {
                    if (texts[i] == "원/NNB")
                    {
                        try
                        {
                            int price = Int32.Parse(texts[i - 1].Split('/')[0]);
                            foreach (var item in MenuPanel.Controls)
                            {

                                var itm = (item)item;
                                //if (itm.Title.Contains( searchString))
                                if (itm.Cost <= price)
                                {
                                    searchResults.Add(itm.Title);
                                    flagForSearch = true;
                                }

                            }
                        }
                        catch { }

                    }
                    foreach (var text in texts)
                    {
                        string[] morps = text.Split('/');
                        List<string> Result = Search(morps[0], true);
                        if (flagForSearch && Result.Count > 0)
                        {
                            // 이미 결과가 존재하면 결과와 교차(intersect)시키기
                            searchResults = searchResults.Intersect(Result).ToList();
                        }
                    }
                }
            }

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
                        else if (Result.Count > 0)
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
                        else if (!flagForSearch && Result.Count > 0)
                        {
                            Result = Search(morps[0], false);
                            // 처음 검색 결과를 설정
                            searchResults = Result;
                            flagForSearch = true;
                        }
                    }

                }
            else if (searchResults.Count == 0)
                foreach (var text in texts)
                {
                    string[] morps = text.Split('/');
                    List<string> Result = Search(morps[0], true);
                    if ((morps.Length >= 2 && (morps[1] == "NNP" || morps[1] == "NNG")))
                    {
                        searchResults = Result;
                    }
                }


            //검색 결과 출력
            if (searchResults.Count == 0)
            {
                tts.StopSpeak();
                tts.Speak("죄송합니다 메뉴를 찾을수 없었습니다.");
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    itm.Visible = true;
                }
                return;
            }
            else
            {
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
                int count = 0;
                foreach (var text in searchResults)
                {
                    if (count == 3)
                        break;
                    tts.Speak(text);
                    count++;
                }
            }
        }
        int count_flag = 1;
        public int final_cost = 0;
        public int mycost
        {
            get { return final_cost; }
            set
            {
                final_cost = value;
                cost_lbl.Text = final_cost.ToString() + "원";
            }
        }
        public Action<DataTable> SendDataTable;

        public static int parentX, parentY;

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        public static int key_flag = 0;
        public static int key_flag2 = 0;
        public static int back_flag = 0;
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            ARS(e);
        }
        void ARS(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.NumPad9 && key_flag == 1)
            {
                key_flag = 0;
                key_flag2 = 0;
                back_flag = 0;
                tts.StopSpeak();
                tts.Speak("에이알에스가 종료되었습니다. 이용해주셔서 감사합니다.");
            }
            else if ((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 && key_flag == 0) || (e.KeyCode == Keys.NumPad9 && back_flag == 1))
            {
                tts.StopSpeak();
                tts.Speak("음료를 원하시면 일번을, 디저트를 원하시면 이번을, " +
                       "음성검색을 원하시면 삼번을 눌러주세요. 다시 듣고싶다면 영번, 장바구니는 팔번, 종료하고싶으시면 구번을 눌러주세요.");
                key_flag = 1;
                back_flag = 0;
            }
            else if ((e.KeyCode == Keys.NumPad1 && key_flag == 1 || e.KeyCode == Keys.NumPad9 && back_flag == 3)) //1번 누를시
            {
                DrinkButton.PerformClick();
                tts.StopSpeak();
                tts.Speak("커피를 원하시면 일번, 커피가 아닌 음료를 원하시면 이번을 눌러주세요. 다시듣고싶다면 팔번을, 돌아가기는 구번을 눌러주세요.");
                key_flag = 2;
                back_flag = 1;
            }
            else if (e.KeyCode == Keys.NumPad2 && key_flag == 1 || e.KeyCode == Keys.NumPad9 && back_flag == 2) //2번 누를시
            {
                DessertButton.PerformClick();
                tts.StopSpeak();
                tts.Speak("빵류를 원하시면 일번, 과자류를 원하시면 이번을 눌러주세요.다시듣고싶다면 팔번을, 돌아가기는 구번을 눌러주세요.");
                key_flag = 3;
                back_flag = 1;
            }
            else if (e.KeyCode == Keys.NumPad1 && key_flag == 3 && key_flag2 == 0) //빵류
            {
                //빵류
                tts.StopSpeak();
                string search = "빵";
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    {
                        if (itm.Detail.Contains(search) && itm.Visible == true)
                        {
                            tts.Speak(itm.Title.ToString()); }
                    }
                }
                back_flag = 2;

            }

            else if (e.KeyCode == Keys.NumPad2 && key_flag == 3 && key_flag2 == 0)//과자류
            {
                //과자류
                tts.StopSpeak();
                string search = "쿠키";
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    {
                        if (itm.Detail.Contains(search) && itm.Visible == true)
                        {
                            tts.Speak(itm.Title.ToString());
                        }
                    }
                }
                back_flag = 2;
            }

            else if (e.KeyCode == Keys.NumPad3 && key_flag == 1) //3번 누를시
            {
                VoiceButton.PerformClick();
                key_flag = 2;
                back_flag = 2;
            }
            else if (e.KeyCode == Keys.NumPad1 && key_flag == 2 || e.KeyCode == Keys.NumPad9 && back_flag == 4) //1-1번
            {
                DrinkButton.PerformClick();
                tts.StopSpeak();
                tts.Speak("우유가 들어간 커피를 원하시면 일번을, 아닌 커피는 이번을 눌러주세요. 돌아가기는 구번을 눌러주세요.");
                key_flag = 3;
                key_flag2 = 1;
                back_flag = 3;
                
            }
            else if (e.KeyCode == Keys.NumPad2 && key_flag == 2 || e.KeyCode == Keys.NumPad9 && back_flag == 5) //1-2번
            {
                tts.StopSpeak();
                tts.Speak("우유가 들어간 음료를 원하시면 일번을, 아닌 음료는 이번을 눌러주세요. 돌아가기는 구번을 눌러주세요.");
                key_flag = 3;
                key_flag2 = 2;
                back_flag = 3;
            }
            else if (e.KeyCode == Keys.NumPad1 && key_flag == 3 && key_flag2 == 1) 
            {
                //우유가 들어간 커피
                tts.StopSpeak();
                string search = "우유"; string search2 = "커피";
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    {
                        if (itm.Detail.Contains(search) && itm.Detail.Contains(search2) && itm.Visible == true)
                        {
                            tts.Speak(itm.Title.ToString());
                        }
                    }
                }
                tts.Speak("가 있습니다. 돌아가기는 구번을 눌러주세요.");
                back_flag = 4;
            }
            else if (e.KeyCode == Keys.NumPad2 && key_flag == 3 && key_flag2 == 1)
            {
                //우유가 안들어간 커피
                tts.StopSpeak();
                string search = "우유"; string search2 = "커피";
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    {
                        if (!itm.Detail.Contains(search) && itm.Detail.Contains(search2) && itm.Visible == true)
                        {
                            tts.Speak(itm.Title.ToString());
                        }
                    }
                }

                tts.Speak("가 있습니다. 돌아가기는 구번을 눌러주세요.");
                back_flag = 4;
            }
            else if (e.KeyCode == Keys.NumPad1 && key_flag == 3 && key_flag2 == 2)
            {
                //우유가 들어간 음료
                tts.StopSpeak();
                string search = "우유"; string search2 = "커피";
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    {
                        if (itm.Detail.Contains(search) && !itm.Detail.Contains(search2) && itm.Visible == true)
                        {
                            tts.Speak(itm.Title.ToString());
                        }
                    }
                }
                tts.Speak("가 있습니다. 돌아가기는 구번을 눌러주세요.");
                back_flag = 5;
            }
            else if (e.KeyCode == Keys.NumPad2 && key_flag == 3 && key_flag2 == 2)
            {
                //우유가 안들어간 음료
                tts.StopSpeak();
                string search = "우유"; string search2 = "커피";
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    {
                        if (!itm.Detail.Contains(search) && !itm.Detail.Contains(search2)&& itm.Visible == true)
                        {
                            tts.Speak(itm.Title.ToString());
                        }
                    }
                }
                tts.Speak("가 있습니다. 돌아가기는 구번을 눌러주세요.");
                back_flag = 5;
            }
            else if( e.KeyCode == Keys.NumPad8)
            {
                int a = 1;
                //장바구니
                tts.StopSpeak();
                foreach ( var type in checkPanel.Controls)
                {
                    var itm = (select_item)type;
                    tts.Speak(a + itm.Title2 +" "+ itm.Count+"개");
                    a++;
                }
                tts.Speak("를 선택하셨습니다 더하거나 빼시려면 메뉴에 상응하는 번호를 누르고 더하기 버튼이나 빼기 버튼을 눌러주세요.");
            }

        }

        private async void custom_button1_Click(object sender, EventArgs e)
        {
            if (cost_lbl.Text == "0원")
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
                DataTable dt = new DataTable();
                dt.Columns.Add(" ", typeof(Bitmap)); //사진
                dt.Columns.Add("이름", typeof(string));
                dt.Columns.Add("개수", typeof(int));
                dt.Columns.Add("가격", typeof(int));
                dt.Columns.Add("합계", typeof(int));
                foreach (var item in checkPanel.Controls)
                {
                    var itm = (select_item)item;
                    Bitmap original = (Bitmap)itm.Icon2;
                    Bitmap resized = new Bitmap(original, new Size(original.Width / 2, original.Height / 2));

                    dt.Rows.Add(resized, itm.Title2.ToString(), itm.Count, itm.Cost2, itm.Cost2 * itm.Count);
                }

                PayCheck newform = new PayCheck(dt);
                this.Hide();
                newform.labeltxt = this.cost_lbl.Text;
                DialogResult result1 = newform.ShowDialog();

                if (result1 == DialogResult.OK)
                {
                    this.Show();
                }
                else if (result1 == DialogResult.Cancel)
                {
                    checkPanel.Controls.Clear();//장바구니 전체 삭제
                    final_cost = 0;
                    cost_lbl.Text = final_cost.ToString() + "원";
                    this.Show();
                    AllmenuButton.PerformClick();
                }
            }
        }

    }
}