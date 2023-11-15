using System;
using System.IO.Ports;
using TTSLib;

namespace AutoMotorControl
{

    public class MotorControl
    {
        private static SerialPort port1 = new SerialPort("COM5");

        public void Finished()
        {
            port1.WriteLine("3");
            //키오스크 사용 완료를 알림
        }
        public void MenualControl(string vector, string miliSeconds)
        {
            port1.WriteLine(vector + " " + miliSeconds);
        }
        public void init()
        {
            port1.WriteLine("4");
        }
        public async void AutoControl()
        {
            port1.DataReceived += (sender, e) =>
            {
                SerialPort port = (SerialPort)sender;
                string data = port.ReadLine();
                Console.WriteLine(data);
                switch (data)
                {
                    case ("in\r"):
                        TextToSpeechConverter tts = new TextToSpeechConverter();
                        tts.Speak("안녕하세요. 음성안내를 이용하시려면 키패드의 아무 버튼을 눌러주세요.");
                        var face = new FaceRecognition.FaceRecognition();
                        string faceLocate = "";
                        for (int i = 0; i < 5; i++)
                        {
                            faceLocate = face.Recognition().Result;
                            Console.WriteLine(faceLocate);

                            if (faceLocate == "error")
                            {
                                Console.WriteLine("error");
                                break;
                            }
                            else if (Int32.TryParse(faceLocate, out var res))
                            {
                                break;
                            }
                        }
                        if (Int32.TryParse(faceLocate, out var result))
                        {
                            Console.WriteLine(result);
                            if (result > 400)
                            {

                                port1.WriteLine("1 0000");

                            }
                            else
                            {
                                port1.WriteLine("1 " + (10 * (400 - result)));
                            }
                        }
                        break;
                    case ("out\r"):
                        port1.WriteLine("2 5000");
                        break;
                    default:
                        break;
                }
            };
            port1.BaudRate = 9600;
            port1.DataBits = 8;
            port1.StopBits = StopBits.One;
            port1.Parity = Parity.None;
            port1.ReadTimeout = 1000;
            try
            {
                port1.Open();
                port1.WriteLine("2 5000");
            }
            catch
            {
                Console.WriteLine("시리얼 포트 개방 실패");
                TextToSpeechConverter tts = new TextToSpeechConverter();
                tts.Speak("아두이노와 시리얼 통신을 실패하였습니다.");

            }
        }
    }
}