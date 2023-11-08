using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Threading;

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
        public void StopSpeak()
        {
            speechSynthesizer.SpeakAsyncCancelAll();
        }
        public async void Speak(string text, string voiceName)
        {
            // CancellationTokenSource를 사용하여 CancellationToken 생성
            var cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            // 나머지 코드에서 cancellationToken 사용
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

                try
                {
                    await Task.Run(() =>
                    {
                        try
                        {
                            speechSynthesizer.Speak(text);
                        }
                        catch (OperationCanceledException)
                        {
                            // Handle the cancellation or cleanup as needed
                            // For example:
                            Console.WriteLine("음성 합성이 취소되었습니다.");
                        }
                    }, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    // Handle the cancellation or cleanup as needed
                    // For example:
                    Console.WriteLine("음성 합성이 취소되었습니다.");
                }
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
