using System;
using System.Windows.Forms;
using TTSLib;

namespace Kiosk_UI
{

    internal class ARSscene
    {

        TextToSpeechConverter tts = new TextToSpeechConverter();
        public static int key_flag = 0;
        public static int key_flag2 = 0;
        public static void ARS1(KeyEventArgs e)
        {
            ARSscene ars = new ARSscene();
            //1번 시나리오
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 && key_flag == 0)
            {
                ars.ARSstart(); //ARS시작
                key_flag = 1;
            }
            else if (e.KeyCode == Keys.NumPad1 && key_flag == 1) //1번 누를시
            {
                ars.ARSdrink(); //커피 논커피선택
                key_flag = 2;
            }
            else if (e.KeyCode == Keys.NumPad9 && key_flag == 2) //9번 누를시
            {
                ars.ARSstart();  //처음으로
            }
            else if (e.KeyCode == Keys.NumPad1 && key_flag == 2) //1번 누를시
            {
                ars.ARScoffee(); //우유커피 선택
            }
            else if (e.KeyCode == Keys.NumPad2 && key_flag == 2) //2번 누를시
            {
                ars.ARSnoncoffee(); //우유논커피 선택
            }

            else if (e.KeyCode == Keys.NumPad2 && key_flag == 1)
            {
                ars.ARSdessert();  //디저트선택
                key_flag = 2;
                if (e.KeyCode == Keys.NumPad1 && key_flag == 2)
                {
                    Console.WriteLine("빵을 선택하셨습니다.");
                }
                else if (e.KeyCode == Keys.NumPad2 && key_flag == 2)
                {
                    Console.WriteLine("쿠키를 선택하셨습니다");
                }

            }


        }
        //2번 시나리오
        public void ARSstart()
        {
            tts.StopSpeak();
            tts.SpeakSynchronous("음료를 원하시면 일번을, 디저트를 원하시면 이번을, " +
                   "음성검색을 원하시면 삼번을 눌러주세요. 다시 듣고싶다면 영번, 종료하고싶으시면 구번을 눌러주세요.");
        }
        public void ARSdrink()
        {
            tts.StopSpeak();
            tts.SpeakSynchronous("커피를 원하시면 일번, 커피가 아닌 음료를 원하시면 이번을 눌러주세요. 다시듣고싶다면 팔번을, 돌아가기는 구번을 눌러주세요.");
        }
        public void ARScoffee()
        {
            tts.StopSpeak();
            tts.Speak("우유가 들어간 커피를 원하시면 일번을, 아닌 커피는 이번을 눌러주세요.");

        }
        public void ARSmilkcoffee()
        {
            {

            }
        }
        public void ARSnoncoffee()
        {
            {
                tts.Speak("우유가 들어간 음료는 일번을, 아닌 음료는 이번을 눌러주세요.");
            }
        }
        public void ARSdessert()
        {
            {
                tts.Speak("빵류를 원하시면 일번, 과자류를 원하시면 이번을 눌러주세요.다시듣고싶다면 팔번을, 돌아가기는 구번을 눌러주세요.");
            }
        }

        public void ARSvoice(KeyEventArgs e)
        {

        }
        /*else if (e.KeyCode == Keys.NumPad2 && key_flag == 1)
        {
            key_flag = 2; key_flag2 = 2;
            tts.StopSpeak(); //디저트
            tts.StopSpeak();
            tts.Speak("빵류를 원하시면 일번, 과자류를 원하시면 이번을 눌러주세요.");
        }
        else if (e.KeyCode == Keys.NumPad3 && key_flag == 1)
        {
            key_flag = 2; key_flag2 = 3; //음성인식
        }
        else if (e.KeyCode == Keys.NumPad0 && key_flag == 1)
        {
            key_flag = 0; tts.StopSpeak();

        }*/
    }
}



