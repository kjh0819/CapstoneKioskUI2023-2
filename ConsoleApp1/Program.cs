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
        static void Main(string[] args)
        {
            var face= new FaceRecognition.FaceRecognition();
            
            while(true) {
                var faceLocate = face.Recognition().Result;
                Console.WriteLine(faceLocate);
            }
        }
    }
}
