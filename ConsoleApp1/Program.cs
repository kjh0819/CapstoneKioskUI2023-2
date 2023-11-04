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
    public class SerialFromArduino
    {
        public void Main() 
        {
            SerialPort port1;
            string receivedData = "";
            port1 = new SerialPort("COM5");

            port1.DataReceived += (sender, e) =>
            {
                SerialPort port = (SerialPort)sender;
                string data = port.ReadTo("\n");
                switch(data)
                {
                    case ("on"):
                        var face = new FaceRecognition.FaceRecognition();
                        string faceLocate="";
                        for(int i = 0; i<20;i++)
                        {
                            faceLocate = face.Recognition().Result;
                            Console.WriteLine(faceLocate);

                            if (faceLocate != "error")
                                break;
                        }
                        if (Int32.TryParse(faceLocate, out var result))
                        {
                            if (result > 400)
                                port1.WriteLine("1 4000");
                            else if (result > 300)
                                port1.WriteLine("1 3000");
                            else if (result > 200)
                                port1.WriteLine("1 2000");
                            else if (result > 100)
                                port1.WriteLine("1 1000");
                        }
                        break;
                    case ("off"):
                        port1.WriteLine("2 5000");
                        break;
                    default: 
                        break;
                }
                Console.WriteLine(data);
            };
            port1.BaudRate = 9600;
            port1.DataBits = 8;
            port1.StopBits = StopBits.One;
            port1.Parity = Parity.None;
            port1.ReadTimeout = 1000;
            port1.Open();

            Console.WriteLine("Press Enter to quit");
            Console.ReadLine();
        }
    }
    
}
