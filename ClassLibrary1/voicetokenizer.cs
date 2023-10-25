using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;
using System.Xml.Linq;
using TTSLib;

public class Tokenizer
{
    const string speechKey = "e947dbc053864f8780d47813eeae6fc1"; //고정값 유출하지 말것
    const string speechRegion = "koreacentral";
    const string url = "http://capstonekiosk.koreacentral.cloudapp.azure.com:5757/bareun/api/v1/analyze"; //유출금지
    const string apiKey = "koba-2WZSTOQ-MSXU3TA-WLNVRHY-ZIIMQJY"; //유출금지


    public static async Task<string> TextTokenizer(string String)
    {
        string responseText = string.Empty;

        string data = $"{{\"document\": {{\"content\": \"{String}\",\"language\": \"ko-KR\"}}, \"encoding_type\": \"UTF8\", \"custom_domain\": \"cafe\"}}";

        Console.WriteLine("data : " + data);

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);

            var content = new StringContent(data, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                responseText = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"An error occurred while sending the request: {e.Message}");
                return e.Message;
            }
        }

        return responseText;
    }



    async static Task<string> OutputSpeechRecognitionResult(SpeechRecognitionResult speechRecognitionResult)
    {
        switch (speechRecognitionResult.Reason)
        {
            case ResultReason.RecognizedSpeech:
                Console.WriteLine($"RECOGNIZED: Text={speechRecognitionResult.Text}");
                for (int i = 0; i < 3; i++)
                {
                    string tokenizedText = await TextTokenizer(speechRecognitionResult.Text);
                    //Console.WriteLine(tokenizedText);

                    if (tokenizedText.Length > 5) //분석된 json최소길이가 5자 이상이였음
                        return tokenizedText;
                }
                break;
            case ResultReason.NoMatch:
                return ($"NOMATCH: Speech could not be recognized.");

            case ResultReason.Canceled:
                var cancellation = CancellationDetails.FromResult(speechRecognitionResult);

                if (cancellation.Reason == CancellationReason.Error)

                    return ($"CANCELED: Reason={cancellation.Reason} ErrorCode={cancellation.ErrorCode} ErrorDetails={cancellation.ErrorDetails}");
                else
                    return ($"CANCELED: Reason={cancellation.Reason}");
        }
        return speechRecognitionResult.Text;
    }

    public async static Task<string> VoiceTokenizer()
    {

        var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
        speechConfig.SpeechRecognitionLanguage = "ko-KR";

        var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
        var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);

        var phraseList = PhraseListGrammar.FromRecognizer(speechRecognizer);

        for (int i = 0; i < 10; i++)
        {
            phraseList.AddPhrase($"{i}잔");
        }
        for (int i = 0; i < 20000; i += 100)
        {
            phraseList.AddPhrase($"{i}원");
        }
        phraseList.AddPhrase($"카페라떼");
        phraseList.AddPhrase($"우유");
        phraseList.AddPhrase($"녹차마카롱");
        phraseList.AddPhrase($"녹차뚱카롱");

        var tts = new TextToSpeechConverter();
        tts.Speak("음성인식을 시작합니다");
        var speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();
        string result = await OutputSpeechRecognitionResult(speechRecognitionResult);
        try
        {
            dynamic jsonData = JObject.Parse(result);
            try
            {
                string taggedVoice = "";
                foreach (var token in jsonData.sentences[0].tokens)
                {
                    //string cafeLatteToken = token.text.content;
                    string cafeLatteToken = token.tagged;
                    taggedVoice += (cafeLatteToken);
                    taggedVoice += ' ';
                }
                //Console.Write(taggedVoice);
                return taggedVoice;
            }
            catch
            {
                //Console.Write("error");
                return "error";
            }
        }
        catch
        {
            //Console.WriteLine(result);
            return "error " + result;
        }

    }
}