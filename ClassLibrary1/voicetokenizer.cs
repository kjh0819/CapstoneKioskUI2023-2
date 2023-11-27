using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TTSLib;
using System.Linq;

public class Tokenizer
{
    const string speechKey = "e947dbc053864f8780d47813eeae6fc1"; //고정값 유출하지 말것
    const string speechRegion = "koreacentral";
    const string url = "http://capstonekiosk.koreacentral.cloudapp.azure.com:5757/bareun/api/v1/analyze"; //유출금지
    const string apiKey = "koba-2WZSTOQ-MSXU3TA-WLNVRHY-ZIIMQJY"; //유출금지


    public static async Task<string> TextTokenizer(string inputString)
    {
        string responseText = string.Empty;
        string data = $"{{\"document\": {{\"content\": \"{inputString}\",\"language\": \"ko-KR\"}}, \"encoding_type\": \"UTF8\", \"custom_domain\": \"cafe\"}}";
        Console.WriteLine("data : " + data);

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            try
            {
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(5));
                var responseTask = client.PostAsync(url, content);

                var completedTask = await Task.WhenAny(responseTask, timeoutTask);
                if (completedTask == timeoutTask)
                {
                    // Timeout occurred
                    Console.WriteLine("Request timed out after 3 seconds.");
                    return "Request timed out.";
                }

                var response = await responseTask;
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
        var speechRecognizer = new Microsoft.CognitiveServices.Speech.SpeechRecognizer(speechConfig, audioConfig);

        var phraseList = PhraseListGrammar.FromRecognizer(speechRecognizer);

        for (int i = 0; i < 10; i++)
        {
            phraseList.AddPhrase($"{i}잔");
        }
        for (int i = 0; i < 10000; i += 100)
            phraseList.AddPhrase($"{i}");
        phraseList.AddPhrase($"초코");
        phraseList.AddPhrase($"카페라떼");
        phraseList.AddPhrase($"우유");
        phraseList.AddPhrase($"녹차");
        phraseList.AddPhrase($"마카롱");
        phraseList.AddPhrase($"쿠키");
        phraseList.AddPhrase($"빵");
        phraseList.AddPhrase("주문");
        

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