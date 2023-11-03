using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceRecognition;
namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var face= new FaceRecognition.FaceRecognition();
            
            while(true) {
                var faceLocate = await face.Recognition();
                Console.WriteLine(faceLocate);
                if (Int32.TryParse(faceLocate, out var result))
                {
                    if (result > 400)
                        Console.WriteLine("HighDistance");
                    else if (result > 300)
                        Console.WriteLine("1 4000");
                    else if (result > 200)
                        Console.WriteLine("1 3000");
                    else if (result > 100)
                        Console.WriteLine("1 2000");
                    else
                        Console.WriteLine("1 1000");
                }
            }
        }
    }
}
