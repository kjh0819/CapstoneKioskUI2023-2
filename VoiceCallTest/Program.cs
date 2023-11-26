using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using Microsoft.Speech.AudioFormat;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //using (SpeechSynthesizer synth = new SpeechSynthesizer())
            //{
            //    foreach (InstalledVoice voice in synth.GetInstalledVoices())
            //    {
            //        VoiceInfo info = voice.VoiceInfo;
            //        string AudioFormats = "";
            //        foreach (SpeechAudioFormatInfo fmt in info.SupportedAudioFormats)
            //        {
            //            AudioFormats += String.Format("{0}\n",
            //            fmt.EncodingFormat.ToString());
            //        }

            //        Console.WriteLine(" Name:          " + info.Name);
            //        Console.WriteLine(" Culture:       " + info.Culture);
            //        Console.WriteLine(" Age:           " + info.Age);
            //        Console.WriteLine(" Gender:        " + info.Gender);
            //        Console.WriteLine(" Description:   " + info.Description);
            //        Console.WriteLine(" ID:            " + info.Id);
            //        Console.WriteLine(" Enabled:       " + voice.Enabled);
            //        if (info.SupportedAudioFormats.Count != 0)
            //        {
            //            Console.WriteLine(" Audio formats: " + AudioFormats);
            //        }
            //        else
            //        {
            //            Console.WriteLine(" No supported audio formats found");
            //        }

            //        string AdditionalInfo = "";
            //        foreach (string key in info.AdditionalInfo.Keys)
            //        {
            //            AdditionalInfo += String.Format("  {0}: {1}\n", key, info.AdditionalInfo[key]);
            //        }

            //        Console.WriteLine(" Additional Info - " + AdditionalInfo);
            //        Console.WriteLine();
            //    }
            //}

            foreach (RecognizerInfo ri in SpeechRecognitionEngine.InstalledRecognizers())
            {
                Console.WriteLine(ri.Id + ": " + ri.Culture);
            }

            using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine("SR_MS_ko-KR_TELE_11.0"))
            {
                Grammar grammar = new Grammar("computer.xml");

                recognizer.LoadGrammar(grammar);

                recognizer.SetInputToDefaultAudioDevice();
                recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                while (true)
                {
                    Console.ReadLine();
                }
            }
        }

        static RecognitionState current = RecognitionState.None;

        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "컴퓨터, 최대 절전 모드로 들어가" &&
                current == RecognitionState.None)
            {
                current = RecognitionState.Question;

                SpeechSynthesizer tts = new SpeechSynthesizer();
                tts.SelectVoice("Microsoft Server Speech Text to Speech Voice (ko-KR, Heami)");
                tts.SetOutputToDefaultAudioDevice();
                tts.Speak("정말?");
                Console.WriteLine("정말?");
                return;
            }

            if (current == RecognitionState.Question)
            {
                current = RecognitionState.None;
                if (e.Result.Text == "응")
                {
                    Console.WriteLine("hibernating...");
                    DoHibernation();
                }
                else
                {
                    Console.WriteLine("Canceled.");
                }
            }
        }

        private static void DoHibernation()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.Arguments = "/h /f";
            psi.FileName = "c:\\windows\\system32\\shutdown.exe";
            Process.Start(psi);
        }
    }

    public enum RecognitionState
    {
        None,
        Question,
    }
}