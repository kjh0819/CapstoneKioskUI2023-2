using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceRecognition;
using static System.Net.Mime.MediaTypeNames;

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
        public void MenualControl(string vector,string miliSeconds) 
        {
            port1.WriteLine(vector + " " + miliSeconds);
        }
        public void AutoControl()
        {
            port1.DataReceived += (sender, e) =>
            {
                SerialPort port = (SerialPort)sender;
                string data = port.ReadLine();
                Console.WriteLine(data);
                switch (data)
                {
                    case ("in\r"):

                        var face = new FaceRecognition.FaceRecognition();
                        string faceLocate = "";
                        for (int i = 0; i < 3; i++)
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
            port1.Open();
            port1.WriteLine("2 5000");
        }
    }
}