using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceRecognition;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            SerialPort port1;
            string receivedData = "";
            port1 = new SerialPort("COM5");

            port1.DataReceived += (sender, e) =>
            {
                SerialPort port = (SerialPort)sender;
                string data = port.ReadLine();
                Console.WriteLine(data);
                switch (data)
                {
                    case ("in\r"):
                        var face = new FaceRecognition.FaceRecognition();
                        string faceLocate="";
                        for(int i = 0; i<3;i++)
                        {
                            faceLocate = face.Recognition().Result;
                            Console.WriteLine(faceLocate);

                            if (faceLocate == "error")
                            {
                                Console.WriteLine("error");
                                break;
                            }
                            else if(Int32.TryParse(faceLocate, out var res))
                            {
                                break;
                            }
                            else if (i == 2)
                            {
                                port1.WriteLine("3")
                            }
                        }
                        if (Int32.TryParse(faceLocate, out var result))
                        {
                            Console.WriteLine(result);
                            if (result > 400)
                            {
                                port1.WriteLine("1 0000");

                            }
                            else if (result > 300)
                            {
                                port1.WriteLine("1 1000");
                            }
                            else if (result > 200)
                                port1.WriteLine("1 2000");
                            else if (result > 100)
                                port1.WriteLine("1 3000");
                            else
                                port1.WriteLine("1 4000");
                            port1.WriteLine("3");
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

            Console.WriteLine("Press Enter to quit");
            Console.ReadLine();
        }
    }
    
}
