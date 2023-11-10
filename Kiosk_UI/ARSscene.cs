using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSLib;
using System.Windows.Forms;

namespace Kiosk_UI
{
    internal class ARSscene
    {


        public static int key_flag = 0;
        public static int key_flag2 = 0;
        public static void ARS1(KeyEventArgs e)
        {
            TextToSpeechConverter tts = new TextToSpeechConverter();
            //1번 시나리오
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 && key_flag == 0)
            {
                tts.StopSpeak();
                tts.Speak("음료를 원하시면 일번을, 디저트를 원하시면 이번을, " +
                    "음성검색을 원하시면 삼번을 눌러주세요. 다시 듣고싶다면 영번, 종료하고싶으시면 구번을 눌러주세요.");
                key_flag = 1;
            }
            else if (e.KeyCode == Keys.NumPad1 && key_flag == 1)
            {
                tts.StopSpeak();
                ARSdrink();
                if(e.KeyCode == Keys.NumPad9)
                {
                    ARS1(e);
                }
            }
            else if (e.KeyCode == Keys.NumPad2 && key_flag == 1)
            { tts.StopSpeak();
                ARSdessert(); }
            
        }
        //2번 시나리오
        public static void ARSdrink()
        {
            TextToSpeechConverter tts = new TextToSpeechConverter();
            {
                tts.Speak("커피를 원하시면 일번, 커피가 아닌 음료를 원하시면 이번을 눌러주세요. 다시듣고싶다면 팔번을, 돌아가기는 구번을 눌러주세요.");
            }
        }
        public static void ARScoffee()
        {
            TextToSpeechConverter tts = new TextToSpeechConverter();
            {
                tts.Speak("우유가 들어간 커피를 원하시면 일번을, 아닌 커피는 이번을 눌러주세요.");
            }
        }
        public static void ARSnoncoffee()
        {
            var tts = new TextToSpeechConverter();
            {
                tts.Speak("우유가 들어간 음료는 일번을, 아닌 음료는 이번을 눌러주세요.");
            }
        }
        public static void ARSdessert()
        {
            var tts = new TextToSpeechConverter();
            {
                tts.Speak("빵류를 원하시면 일번, 과자류를 원하시면 이번을 눌러주세요.다시듣고싶다면 팔번을, 돌아가기는 구번을 눌러주세요.");
            }
        }

        public static void ARSvoice(KeyEventArgs e)
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

    

