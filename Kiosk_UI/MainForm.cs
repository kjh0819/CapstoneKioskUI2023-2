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
using System.Timers;
using TTSLib;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Microsoft.Speech.Recognition;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


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
        private SpeechRecognitionEngine recognizer;
        bool arsMode = false;
        private async Task CallingKeywordJobs()
        {
            StartInputTimer();
            tts.StopSpeak();
            tts.Speak("무엇을 도와드릴까요?");
            await Task.Delay(TimeSpan.FromSeconds(1));
            string token = await Tokenizer.VoiceTokenizer();
            Console.WriteLine(token);
            if (token.Contains("error NOMATCH: Speech could not be recognized."))
            {
                tts.Speak("잘 알아듣지 못했습니다.");
            }
            else if (token.Contains("error Request timed out."))
            {
                tts.Speak("음성 분석 서버가 응답하지 않습니다.");
            }
            else if (token.Contains("검색"))
                VoiceButton.PerformClick();
            else if (token.Contains("올리/VV")||token.Contains("높이/VV+어/EC"))
            {
                MotorControl mtr = new MotorControl();
                mtr.MenualControl("1", "1500");
            }
            else if (token.Contains("내리/VV")||token.Contains("낮추/VV"))
            {
                MotorControl mtr = new MotorControl();
                mtr.MenualControl("2", "1000");
            }
            else if (token.Contains("높/VA+이/NR") && token.Contains("조절/NNG"))
            {
                MotorControl mtr = new MotorControl();
                mtr.faceReconMotorControl();

            }
            else if (token.Contains("주문"))
            {
                //오류발생 왠지 몰?루
                //if (Search(token.Split('/')[0], true).Count == 1)
                //{
                //    List<string> searchedMenu = Search(token, true);
                //    foreach (var type in MenuPanel.Controls)
                //    {
                //        var itm = (item)type;
                //        if (itm.Title.ToString() == searchedMenu[0])
                //        {
                //            //itm.txtImg_Click(itm, e); //메뉴를 장바구니에 담는 코드
                //            tts.Speak(itm.Title + "추가됨");
                //        }
                //    }

                //}
                key_flag = 0;
                key_flag2 = 0;
                back_flag = 0;
                var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad1);
                arsMode = true;
                this.ARS(keyEvent);
            }
            else if (token.Contains("무엇") && token.Contains("하/VV+ㄹ/ETM"))
            {
                tts.Speak("음성검색,화면올려줘,화면내려줘,주문할게 와 같이 말씀해주세요");
            }
            else
            {
                tts.Speak("죄송합니다. 음성검색,화면올려줘,화면내려줘,주문할게 와 같이 말씀해주세요");
            }
            StartInputTimer();
            CallingKeyword();
        }
        private async Task CallingKeyword()
        {
            recognizer = new SpeechRecognitionEngine();
                bool calledFlag=false;
                // 음성 인식 이벤트 핸들러 등록
                recognizer.SpeechRecognized += async (s, e) =>
                {
                    StartInputTimer();
                    recognizer.RecognizeAsyncStop();
                    Console.WriteLine($"Recognized: {e.Result.Text}");

                    // 여기에서 특정 키워드를 감지하고 원하는 동작 수행
                    if (e.Result.Text.Contains("음성검색"))
                    {
                        VoiceButton.PerformClick();
                        CallingKeyword();
                    }
                    else if (e.Result.Text.Contains("설명서"))
                    {
                        Console.WriteLine("설명서 감지됨");
                        CallingKeywordJobs();
                    }
                    else if (e.Result.Text.Contains("영번") && arsMode)
                    {
                        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad0);
                        this.ARS(keyEvent);
                        CallingKeyword();
                    }
                    else if (e.Result.Text.Contains("일번") && arsMode)
                    {
                        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad1);
                        this.ARS(keyEvent);
                        CallingKeyword();
                    }
                    else if (e.Result.Text.Contains("이번") && arsMode)
                    {
                        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad2);
                        this.ARS(keyEvent);
                        CallingKeyword();
                    }
                    else if (e.Result.Text.Contains("삼번") && arsMode)
                    {
                        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad3);
                        this.ARS(keyEvent);
                        CallingKeyword();
                    }
                    else if (e.Result.Text.Contains("사번") && arsMode)
                    {
                        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad4);
                        this.ARS(keyEvent);
                        CallingKeyword();
                    }
                    else if (e.Result.Text.Contains("오번") && arsMode)
                    {
                        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad5);
                        this.ARS(keyEvent);
                        CallingKeyword();
                    }
                    else if (e.Result.Text.Contains("육번") && arsMode)
                    {
                        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad6);
                        this.ARS(keyEvent);
                        CallingKeyword();
                    }
                    else if (e.Result.Text.Contains("칠번") && arsMode)
                    {
                        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad7);
                        this.ARS(keyEvent);
                        CallingKeyword();
                    }
                    else if (e.Result.Text.Contains("팔번") && arsMode)
                    {
                        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad8);
                        this.ARS(keyEvent);
                        CallingKeyword();
                    }
                    else if (e.Result.Text.Contains("구번") && arsMode)
                    {
                        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad9);
                        this.ARS(keyEvent);
                        CallingKeyword();
                    }
                    else if (e.Result.Text.Contains("확인") && arsMode)
                    {
                        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.Enter);
                        this.ARS(keyEvent);
                        CallingKeyword();
                    }
                    else if (e.Result.Text.Contains("주문") && arsMode)
                    {
                        key_flag = 0;
                        key_flag2 = 0;
                        back_flag = 0;
                        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad7);
                        this.ARS(keyEvent);
                        CallingKeyword();
                    }
                    else
                        CallingKeyword();
                };

                // Grammar 생성 및 로드
                var grammar = new Microsoft.Speech.Recognition.Grammar(new Choices("설명서", "음성검색", "영번", "일번", "이번","삼번","사번","오번","육번","칠번","팔번","구번","확인","주문"));
                if (grammar != null)
                {
                    recognizer.LoadGrammar(grammar);
                }
                var choices = new Choices("설명서");
                Console.WriteLine(choices);
                // 음성 인식 시작
                recognizer.SetInputToDefaultAudioDevice();
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            
        }
        private System.Timers.Timer aTimer;
        public MainForm()
        {
            InitializeComponent();

            SetTimer();
            CallingKeyword(); 

            this.FormClosing += MainForm_FormClosing;
            new Touch(MenuPanel);
        }

        private void SetTimer()
        {
            if (aTimer == null)
            {
                aTimer = new System.Timers.Timer(30000);
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
            }
            else
            {
                aTimer.Interval = 30000;
            }
        }

        private void StartInputTimer()
        {
            SetTimer();
        }
        private void OnTimedEvent(object sender, EventArgs e)
        {
            Console.WriteLine("비동작 감지됨");
            key_flag = 0;
            key_flag2 = 0;
            back_flag = 0;
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnTimedEvent(sender, e)));
                return;
            }

            //tts.SpeakSynchronous("사용이 종료되었습니다.");
            checkPanel.Controls.Clear();
            AllmenuButton.PerformClick();
            try
            {
                MotorControl mtr = new MotorControl();
                //mtr.MenualControl("2", "4000");
                mtr.Finished();
            }
            catch
            {
                tts.Speak("아두이노가 없습니다.");
            }//모터 초기화 예외처리, 아두이노 미연결시 스킵
            if (ActiveForm != null)
            {
                //tts.SpeakSynchronous(ActiveForm.Name + "종료");
                switch (ActiveForm.Name)
                {
                    case "PayCheck":
                        ActiveForm.Close(); break;
                    case "TakeoutForm":
                        ActiveForm.Close(); break;
                    case "FinishForm":
                        ActiveForm.Close(); break;
                    case "MainForm":
                        checkPanel.Controls.Clear();//장바구니 전체 삭제
                        final_cost = 0;
                        cost_lbl.Text = final_cost.ToString() + "원";
                        AllmenuButton.PerformClick();
                        break;
                    default: break;
                }
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MotorControl mtr = new MotorControl();
            mtr.MenualControl("2", "4000");
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
        }
        private void TxtImg_Click(object sender, EventArgs e)
        {
            item itm = new item();
            itm.txtImg_Click (sender, e);
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
            StartInputTimer();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            StartInputTimer();
            arsMode = false;
            //try
            //{
            //    FinishForm finishForm = new FinishForm();

            //    finishForm.ShowDialog();
            //}
            //catch { }
            checkPanel.Controls.Clear();//장바구니 전체 삭제
            final_cost = 0;
            cost_lbl.Text = final_cost.ToString() + "원";
            MotorControl mtr = new MotorControl();
            mtr.Finished();
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

            menuUpdateCounter = 0;
            while (!flagForNewFile)
            {
                menuUpdateCounter++;
                if (menuUpdateCounter < 0)
                {
                    tts.Speak("서버가 응답하지 않습니다. 메뉴업데이트를 중단합니다.");
                    flagForNewFile = true;
                }
            }
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
                tts.SpeakSynchronous("메뉴 업데이트를 시작합니다.");
                client.Publish("Menu/Update", Encoding.UTF8.GetBytes(""), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                menuUpdateCounter=0;
                do
                {
                    updateItem();
                    menuUpdateCounter++;
                    if (menuUpdateCounter > 100000000)
                    {
                        flagForNewFile = true;
                        tts.Speak("업데이트에 실패하였습니다.");
                    }
                } while (!flagForNewFile);
                menuUpdateCounter = 0;
            }

            actbutton(sender);
            foreach (var type in MenuPanel.Controls)
            {
                var itm = (item)type;
                itm.Visible = true;
            }
            StartInputTimer();

        }

        private void DrinkButton_Click(object sender, EventArgs e)
        {
            //MotorControl mtr = new MotorControl();
            //mtr.faceReconMotorControl();
            tts.StopSpeak();
            menuUpdateCounter = 0;
            actbutton(sender);
            foreach (var type in MenuPanel.Controls)
            {
                var itm = (item)type;
                if (itm.Category.ToString() == "drink")
                {
                    itm.Visible = true;
                }
                else { itm.Visible = false; }
            }
            StartInputTimer();

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
            StartInputTimer();

        }


        private async void VoiceButton_Click(object sender, EventArgs e)
        {
            tts.StopSpeak();
            menuUpdateCounter = 0;
            programExitCounter++;
            if (programExitCounter == 10)
            {
                tts.SpeakSynchronous("프로그램을 종료합니다.");
                System.Environment.Exit(0);
            }
            actbutton(sender);
            //모든 메뉴 가리기
            foreach (var type in MenuPanel.Controls)
            {
                var itm = (item)type;
                itm.Visible = false;
            }
            tts.Speak("음성 검색을 시작합니다");
            await Task.Delay(TimeSpan.FromSeconds(1));
            string token = await Tokenizer.VoiceTokenizer();
            StartInputTimer();

            Console.WriteLine(token);
            if (token.Contains("error"))
            {
                if (token==("error NOMATCH: Speech could not be recognized."))
                {
                    tts.SpeakSynchronous("잘 알아듣지 못했습니다.");
                    AllmenuButton.PerformClick();
                    return;
                }
                else if(token== "error Request timed out.")
                {
                    tts.SpeakSynchronous("서버가 응답하지 않습니다.");
                    AllmenuButton.PerformClick();
                    return;
                }
                tts.SpeakSynchronous("에러가 발생하였습니다.");
                AllmenuButton.PerformClick();
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
                    if(searchResults.Count==0||searchResults==null)
                        flagForSearch= false;
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

            if(searchResults.Count == 0) 
                foreach (var text in texts)
                {
                    string[] morps = text.Split('/');
                    List<string> Result = Search(morps[0], true);
                    if ((morps.Length >= 2 && (morps[1] == "NNP" || morps[1] == "NNG")))
                    {
                        foreach(var r in Result)
                            searchResults.Add(r);
                    }
                }
            //검색 결과 출력
            if (searchResults.Count == 0)
            {
                tts.StopSpeak(); 
                AllmenuButton.PerformClick();
                tts.Speak("죄송합니다 메뉴를 찾을수 없었습니다.");
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
            StartInputTimer();
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
        public static int interrupt = 0;
        public static bool min_flag = false;
        public List<int> numbers = new List<int>();
        public List<string> names = new List<string>();
        public class _result
        {
            public Dictionary<string, string> CollectionDic { get; set; }
            public _result()
            {
                CollectionDic = new Dictionary<string, string>();
            }
        }
        public void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            ARS(e);
        }

        int ArsAutoDemoCounter = 0;
        public void ARS( KeyEventArgs e)
        {
            StartInputTimer();
            //ars 자동 데모
            if (e.KeyCode == Keys.NumPad0 && ArsAutoDemoCounter < 3)
            {
                ArsAutoDemoCounter++;
            }
            else if (ArsAutoDemoCounter == 3)
            {
                tts.StopSpeak();
                tts.SpeakSynchronous("에이알에스 데모를 시작합니다.");
                ArsAutoDemoCounter = 0;
                //음료
                var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad1);
                this.ARS(keyEvent);

                System.Threading.Thread.Sleep(15000);
                //커피가 아닌 음료
                keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad2);
                this.ARS(keyEvent);
                System.Threading.Thread.Sleep(8000);
                //우유가 안들어간 음료
                keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad2);
                this.ARS(keyEvent);
                System.Threading.Thread.Sleep(10000);
                //캐모마일 추가
                keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad4);
                this.ARS(keyEvent);
                System.Threading.Thread.Sleep(2000);
                //주문하기
                keyEvent =new KeyEventArgs(Keys.Enter);
                this.ARS(keyEvent);
                System.Threading.Thread.Sleep(5000);


                keyEvent = new KeyEventArgs(Keys.Enter);
                this.ARS(keyEvent);
                System.Threading.Thread.Sleep(5000);
            }
            //엔터키로 주문 하기
            if(e.KeyCode == Keys.Enter) 
                custom_button1.PerformClick();

            //ars_ver1
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
                key_flag2 = 0;
                back_flag = 1;
                interrupt = 0;
                min_flag = false;
            }
            else if ((e.KeyCode == Keys.NumPad1 && key_flag == 3 && key_flag2 == 0 && back_flag == 1)||(e.KeyCode == Keys.NumPad8 && key_flag == 3 && key_flag2 == 0 && interrupt == 1)) //빵류
            {
                //빵류
                tts.StopSpeak();
                string[] numberMap = { "영", "일", "이", "삼", "사", "오", "육", "칠", "팔", "구" };
                names.Clear();
                numbers.Clear();

                string TextResult = "";

                var result = Search("빵", true);
                result = result.Intersect(Search("쿠키", false)).ToList();
                List<string> dessert = new List<string>();
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    if (itm.Category.ToString() == "dessert")
                    {
                        dessert.Add(itm.Title);
                        itm.Visible = false;
                    }
                }
                result = result.Intersect(dessert).ToList();
                for (int i = 0; i < result.Count && i < 8; i++)
                {
                    TextResult += $"{result[i]} {numberMap[i]}번, ";
                    names.Add(result[i]);
                    numbers.Add(i);
                }

                foreach (var item in MenuPanel.Controls)
                {
                    var control = (item)item;
                    if (control != null)
                    {
                        foreach (var text in result)
                        {
                            if (text == control.Title)
                                control.Visible = true;
                        }
                    }
                }
                tts.Speak(TextResult + "가 있습니다. 다시듣기는 팔번, 돌아가기는 구번, 주문 완료는 확인을 눌러주세요.");
                Console.WriteLine(TextResult);

                back_flag = 2;
                interrupt = 1;

            }
            else if (e.KeyCode == Keys.Subtract && key_flag == 3 && key_flag2 == 0 && interrupt == 1)
            {
                tts.StopSpeak();
                if (min_flag == false)
                {
                    tts.Speak("빼기모드");
                    min_flag = true;
                }
                else if (min_flag == true)
                {
                    tts.Speak("빼기모드 취소됨");
                    min_flag = false;
                }
            }
            else if (96 <= e.KeyValue && e.KeyValue <= 95 + names.Count && key_flag == 3 && key_flag2 == 0 && interrupt == 1)
            { //빵류 장바구니
                tts.StopSpeak();
                if (min_flag == false)
                {
                    foreach (var type in MenuPanel.Controls)
                    {
                        var itm = (item)type;
                        if (itm.Title.ToString() == names[e.KeyValue - 96])
                        {
                            itm.txtImg_Click(itm, e);
                            tts.Speak(itm.Title + "추가됨");
                        }
                    }
                }
                else
                {
                    foreach (var type in checkPanel.Controls)
                    {
                        var slt = (select_item)type;
                        if (slt.Title2.ToString() == names[e.KeyValue - 96])
                        {
                            slt.minus_button_Click(slt, e);
                            tts.Speak(slt.Title2 + "빼기");
                        }
                    }
                }
            }




            else if ((e.KeyCode == Keys.NumPad2 && key_flag == 3 && key_flag2 == 0 && back_flag == 1)||(e.KeyCode == Keys.NumPad8 && key_flag == 3 && key_flag2 == 0 && interrupt == 2))
            {
                //과자류
                tts.StopSpeak();
                string[] numberMap = { "영", "일", "이", "삼", "사", "오", "육", "칠", "팔", "구" };
                names.Clear();
                numbers.Clear();
                tts.StopSpeak();

                string TextResult = "";

                var result = Search("빵", false);
                result = result.Intersect(Search("쿠키", true)).ToList();
                List<string> dessert = new List<string>();
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    if (itm.Category.ToString() == "dessert")
                    {
                        dessert.Add(itm.Title);
                        itm.Visible = false;
                    }
                }
                result = result.Intersect(dessert).ToList();
                for (int i = 0; i < result.Count && i < 8; i++)
                {
                    TextResult += $"{result[i]} {numberMap[i]}번,  ";
                    names.Add(result[i]);
                    numbers.Add(i);
                }
                foreach (var item in MenuPanel.Controls)
                {
                    var control = (item)item;
                    if (control != null)
                    {
                        foreach (var text in result)
                        {
                            if (text == control.Title)
                                control.Visible = true;
                        }
                    }
                }
                tts.Speak(TextResult + "가 있습니다. 다시듣기는 팔번, 돌아가기는 구번, 주문 완료는 확인을 눌러주세요.");
                Console.WriteLine(TextResult);
                back_flag = 2;
                interrupt = 2;
            }
            else if(e.KeyCode == Keys.Subtract && key_flag == 3 && key_flag2 == 0 && interrupt == 2)
            {
                tts.StopSpeak();
                if (min_flag == false)
                {
                    tts.Speak("빼기모드");
                    min_flag = true;
                }
                else if (min_flag == true)
                {
                    tts.Speak("빼기모드 취소됨");
                    min_flag = false;
                }
            }
            else if (96 <= e.KeyValue && e.KeyValue <= 95 + names.Count && key_flag == 3 && key_flag2 == 0 && interrupt == 2)
            {
                tts.StopSpeak();
                if (min_flag == false)
                {
                    foreach (var type in MenuPanel.Controls)
                    {
                        var itm = (item)type;
                        if (itm.Title.ToString() == names[e.KeyValue - 96])
                        {
                            itm.txtImg_Click(itm, e);
                            tts.Speak(itm.Title + "추가됨");
                        }
                    }
                }
                else
                {
                    foreach (var type in checkPanel.Controls)
                    {
                        var slt = (select_item)type;
                        if (slt.Title2.ToString() == names[e.KeyValue - 96])
                        {
                            slt.minus_button_Click(slt, e);
                            tts.Speak(slt.Title2 + "빼기");
                        }
                    }
                }
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
                interrupt = 0;
                min_flag = false;
            }
            else if (e.KeyCode == Keys.NumPad2 && key_flag == 2 || e.KeyCode == Keys.NumPad9 && back_flag == 5) //1-2번
            {
                tts.StopSpeak();
                tts.Speak("우유가 들어간 음료를 원하시면 일번을, 아닌 음료는 이번을 눌러주세요. 돌아가기는 구번을 눌러주세요.");
                key_flag = 3;
                key_flag2 = 2;
                back_flag = 3;
                interrupt = 0;
                min_flag = false;
            }

            else if ((e.KeyCode == Keys.NumPad1 && key_flag == 3 && key_flag2 == 1 && back_flag != 4)||(e.KeyCode == Keys.NumPad8 && key_flag == 3 && key_flag2 == 1 && interrupt == 3))
            {
                string[] numberMap = { "영", "일", "이", "삼", "사", "오", "육", "칠", "팔", "구" };
                //우유가 들어간 커피
                tts.StopSpeak();

                names.Clear();
                numbers.Clear();
                var result = Search("우유", true);
                result = result.Intersect(Search("커피", true)).ToList();
                string TextResult = "";
                for (int i = 0; i < result.Count && i < 8; i++)
                {
                    TextResult += $"{result[i]} {numberMap[i]}번,  ";
                    names.Add(result[i]);
                    numbers.Add(i);
                }
                foreach (var item in MenuPanel.Controls)
                {
                    var control = (item)item;
                    control.Visible = false;
                }
                foreach (var item in MenuPanel.Controls)
                {
                    var control = (item)item;
                    if (control != null)
                    {
                        foreach (var text in result)
                        {
                            if (text == control.Title)
                                control.Visible = true;
                        }
                    }
                }
                tts.Speak(TextResult + "가 있습니다. 다시듣기는 팔번, 돌아가기는 구번, 주문 완료는 확인을 눌러주세요.");
                Console.WriteLine(TextResult);
                back_flag = 4;
                interrupt = 3;
            }
            else if(e.KeyCode == Keys.Subtract && key_flag == 3 && key_flag2 == 1 && interrupt == 3)
            {
                tts.StopSpeak();
                if (min_flag == false)
                {
                    tts.Speak("빼기모드");
                    min_flag = true;
                }
                else if (min_flag == true)
                {
                    tts.Speak("빼기모드 취소됨");
                    min_flag = false;
                }
            }
            else if (96 <= e.KeyValue && e.KeyValue <= 95 + names.Count && key_flag == 3 && key_flag2 == 1 && interrupt == 3)
            {
                //우유가 들어간 커피 장바구니
                tts.StopSpeak();
                if (min_flag == false)
                {
                    foreach (var type in MenuPanel.Controls)
                    {
                        var itm = (item)type;
                        if (itm.Title.ToString() == names[e.KeyValue - 96])
                        {
                            itm.txtImg_Click(itm, e);
                            tts.Speak(itm.Title + "추가됨");
                        }
                    }
                }
                else
                {
                    foreach (var type in checkPanel.Controls)
                    {
                        var slt = (select_item)type;
                        if (slt.Title2.ToString() == names[e.KeyValue - 96])
                        {
                            slt.minus_button_Click(slt, e);
                            tts.Speak(slt.Title2 + "빼기");
                        }
                    }
                }
            }
            else if ((e.KeyCode == Keys.NumPad2 && key_flag == 3 && key_flag2 == 1 && interrupt != 4)||(e.KeyCode == Keys.NumPad8 && key_flag == 3 && key_flag2 == 1 && interrupt == 4))
            {
                string[] numberMap = { "영", "일", "이", "삼", "사", "오", "육", "칠", "팔", "구" };
                //우유가 안들어간 커피
                tts.StopSpeak();

                names.Clear();
                numbers.Clear();

                var result = Search("커피", true);
                result = result.Intersect(Search("우유", false)).ToList();
                string TextResult = "";

                for (int i = 0; i < result.Count && i < 8; i++)
                {
                    TextResult += $"{result[i]} {numberMap[i]}번,  ";
                    names.Add(result[i]);
                    numbers.Add(i);
                }
                foreach (var item in MenuPanel.Controls)
                {
                    var control = (item)item;
                    control.Visible = false;
                }
                foreach (var item in MenuPanel.Controls)
                {
                    var control = (item)item;
                    if (control != null)
                    {
                        foreach (var text in result)
                        {
                            if (text == control.Title)
                                control.Visible = true;
                        }
                    }
                }
                tts.Speak(TextResult + "가 있습니다. 다시듣기는 팔번, 돌아가기는 구번, 주문 완료는 확인을 눌러주세요.");
                Console.WriteLine(TextResult);
                back_flag = 4;
                interrupt = 4;
            }

            else if (e.KeyCode == Keys.Subtract && key_flag == 3 && key_flag2 == 1 && interrupt == 4)
            {
                tts.StopSpeak();
                if (min_flag == false)
                {
                    tts.Speak("빼기모드");
                    min_flag = true;
                }
                else if (min_flag == true)
                {
                    tts.Speak("빼기모드 취소됨");
                    min_flag = false;
                }
            }
            else if (96 <= e.KeyValue && e.KeyValue <= 95 + names.Count && key_flag == 3 && key_flag2 == 1 && interrupt == 4)
            {
                //우유가 안들어간 커피 장바구니
                tts.StopSpeak();
                if (min_flag == false)
                {
                    foreach (var type in MenuPanel.Controls)
                    {
                        var itm = (item)type;
                        if (itm.Title.ToString() == names[e.KeyValue - 96])
                        {
                            itm.txtImg_Click(itm, e);
                            tts.Speak(itm.Title + "추가됨");
                        }
                    }
                }
                else
                {
                    foreach (var type in checkPanel.Controls)
                    {
                        var slt = (select_item)type;
                        if (slt.Title2.ToString() == names[e.KeyValue - 96])
                        {
                            slt.minus_button_Click(slt, e);
                            tts.Speak(slt.Title2 + "빼기");
                        }
                    }
                }
            }
            else if ((e.KeyCode == Keys.NumPad1 && key_flag == 3 && key_flag2 == 2 && back_flag == 3)||(e.KeyCode == Keys.NumPad8 && key_flag == 3 && key_flag2 == 2 && interrupt == 5))
            {
                //우유가 들어간 음료
                string[] numberMap = { "영", "일", "이", "삼", "사", "오", "육", "칠", "팔", "구" };
                tts.StopSpeak();

                names.Clear();
                numbers.Clear();

                var result = Search("우유", true);
                result = result.Intersect(Search("커피", false)).ToList();

                string TextResult = "";
                List<string> drinks = new List<string>();
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    if (itm.Category.ToString() == "drink")
                    {
                        drinks.Add(itm.Title);
                        itm.Visible = false;
                    }
                }
                result = result.Intersect(drinks).ToList();
                for (int i = 0; i < result.Count && i < 8; i++)
                {
                    TextResult += $"{result[i]} {numberMap[i]}번,  ";
                    names.Add(result[i]);
                    numbers.Add(i);
                }
                foreach (var item in MenuPanel.Controls)
                {
                    var control = (item)item;
                    control.Visible = false;
                }
                foreach (var item in MenuPanel.Controls)
                {
                    var control = (item)item;
                    if (control != null)
                    {
                        foreach (var text in result)
                        {
                            if (text == control.Title)
                                control.Visible = true;
                        }
                    }
                }
                tts.Speak(TextResult + "가 있습니다. 다시듣기는 팔번, 돌아가기는 구번, 주문 완료는 확인을 눌러주세요.");
                Console.WriteLine(TextResult);
                back_flag = 5;
                interrupt = 5;
            }
            else if (e.KeyCode == Keys.Subtract && key_flag == 3 && key_flag2 == 2 && interrupt == 5)
            {
                tts.StopSpeak();
                if (min_flag == false)
                {
                    tts.Speak("빼기모드");
                    min_flag = true;
                }
                else if (min_flag == true)
                {
                    tts.Speak("빼기모드 취소됨");
                    min_flag = false;
                }
            }
            else if (96 <= e.KeyValue && e.KeyValue <= 95 + names.Count && key_flag == 3 && key_flag2 == 2 && interrupt == 5)
            {
                //우유가 들어간 음료 장바구니
                tts.StopSpeak();
                if (min_flag == false)
                {
                    foreach (var type in MenuPanel.Controls)
                    {
                        var itm = (item)type;
                        if (itm.Title.ToString() == names[e.KeyValue - 96])
                        {
                            itm.txtImg_Click(itm, e);
                            tts.Speak(itm.Title + "추가됨");
                        }
                    }
                }
                else
                {
                    foreach (var type in checkPanel.Controls)
                    {
                        var slt = (select_item)type;
                        if (slt.Title2.ToString() == names[e.KeyValue - 96])
                        {
                            slt.minus_button_Click(slt, e);
                            tts.Speak(slt.Title2 + "빼기");
                        }
                    }
                }

            }
            else if ((e.KeyCode == Keys.NumPad2 && key_flag == 3 && key_flag2 == 2 && back_flag == 3)||(e.KeyCode == Keys.NumPad8 && key_flag == 3 && key_flag2 == 2 && interrupt == 6))
            {
                //우유가 안들어간 음료
                string[] numberMap = { "영", "일", "이", "삼", "사", "오", "육", "칠", "팔", "구" };
                tts.StopSpeak();

                names.Clear();
                numbers.Clear();

                var result = Search("우유", false);
                result = result.Intersect(Search("커피", false)).ToList();

                string TextResult = "";
                List<string> drinks = new List<string>();
                foreach (var type in MenuPanel.Controls)
                {
                    var itm = (item)type;
                    if (itm.Category.ToString() == "drink")
                    {
                        drinks.Add(itm.Title);
                        itm.Visible = false;
                    }
                }
                result = result.Intersect(drinks).ToList();
                for (int i = 0; i < result.Count && i < 8; i++)
                {
                    TextResult += $"{result[i]} {numberMap[i]}번,  ";
                    names.Add(result[i]);
                    numbers.Add(i);
                }
                foreach (var item in MenuPanel.Controls)
                {
                    var control = (item)item;
                    control.Visible = false;
                }
                foreach (var item in MenuPanel.Controls)
                {
                    var control = (item)item;
                    if (control != null)
                    {
                        foreach (var text in result)
                        {
                            if (text == control.Title)
                                control.Visible = true;
                        }
                    }
                }
                tts.Speak(TextResult + "가 있습니다. 다시듣기는 팔번, 돌아가기는 구번, 주문 완료는 확인을 눌러주세요.");
                Console.WriteLine(TextResult);
                back_flag = 5;
                interrupt = 6;
            }
            else if (e.KeyCode == Keys.Subtract && key_flag == 3 && key_flag2 == 2 && interrupt == 6)
            {
                tts.StopSpeak();
                if (min_flag == false)
                {
                    tts.Speak("빼기모드");
                    min_flag = true;
                }
                else if (min_flag == true)
                {
                    tts.Speak("빼기모드 취소됨");
                    min_flag = false;
                }
            }
            else if (96 <= e.KeyValue && e.KeyValue <= 95 + names.Count && key_flag == 3 && key_flag2 == 2 && interrupt == 6)
            {
                //우유가 안들어간 음료 장바구니
                tts.StopSpeak();
                if (min_flag == false)
                {
                    foreach (var type in MenuPanel.Controls)
                    {
                        var itm = (item)type;
                        if (itm.Title.ToString() == names[e.KeyValue - 96])
                        {
                            itm.txtImg_Click(itm, e);
                            tts.Speak(itm.Title + "추가됨");
                        }
                    }
                }
                else
                {
                    foreach (var type in checkPanel.Controls)
                    {
                        var slt = (select_item)type;
                        if (slt.Title2.ToString() == names[e.KeyValue - 96])
                        {
                            slt.minus_button_Click(slt, e);
                            tts.Speak(slt.Title2 + "빼기");
                        }
                    }
                }
            }

        }

        private async void custom_button1_Click(object sender, EventArgs e)
        {
            if (cost_lbl.Text == "0원")
            {
                Form modalbackground = new Form();
                using (warning modal = new warning())
                {
                    tts.Speak("메뉴를 선택해주세요.");
                    modal.ShowDialog();
                    modalbackground.Dispose();

                    this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                        (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                }
            }
            else
            {
                //결제하기 버튼 누르면 ars 초기화
                key_flag = 0;
                key_flag2 = 0;
                back_flag = 0;
                arsMode = false;

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
            StartInputTimer();
        }

    }
}