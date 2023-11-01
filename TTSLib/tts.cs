using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace TTSLib
{

    public class TextToSpeechConverter
    {
        private SpeechSynthesizer speechSynthesizer;

        public TextToSpeechConverter()
        {
            speechSynthesizer = new SpeechSynthesizer();
            SetDefaultVoice("Microsoft Heami Desktop");
        }

        private void SetDefaultVoice(string voiceName)
        {
            if (!string.IsNullOrEmpty(voiceName))
            {
                try
                {
                    speechSynthesizer.SelectVoice(voiceName);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid default voice name or voice not available.");
                }
            }
        }

        public async void Speak(string text, string voiceName)
        {
            if (speechSynthesizer != null)
            {
                if (!string.IsNullOrEmpty(voiceName))
                {
                    try
                    {
                        speechSynthesizer.SelectVoice(voiceName);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid voice name or voice not available.");
                        return;
                    }
                }

                await Task.Run(() => speechSynthesizer.Speak(text));
            }
        }

        public async void Speak(string text)
        {
            Speak(text, null); // Use the provided voice or the default voice
        }

        public void ListAvailableVoices()
        {
            var voices = speechSynthesizer.GetInstalledVoices();
            Console.WriteLine("Available Voices:");
            foreach (var voiceInfo in voices)
            {
                Console.WriteLine("Voice Name: " + voiceInfo.VoiceInfo.Name);
            }
        }
    }
}
