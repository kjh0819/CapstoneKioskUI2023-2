using System.Buffers.Text;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

// 클라이언트 객체 생성
MqttClient client = new MqttClient("kjh0819.duckdns.org");

// 연결 옵션 설정
string clientId = Guid.NewGuid().ToString();
string username = "IndukKioskB";
string password = "08190919";
byte code = client.Connect(clientId, username, password);
const string menuCsv = "../../../Resources/menu.csv";

// 토픽 구독
client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; // 메시지 수신 이벤트 핸들러 등록
client.Subscribe(new string[] { "Menu/NewImage","Menu/exist","Menu/request", "Menu/NewFile" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE }); // test/topic 토픽을 QoS 1로 구독

// 메시지 수신 이벤트 핸들러
void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
{
    // e.Topic : 토픽 이름
    // e.Message : 메시지 내용 (바이트 배열)
    // e.DupFlag : 중복 플래그
    // e.QosLevel : QoS 레벨
    // e.Retain : retain 플래그
    string m = Encoding.UTF8.GetString(e.Message);
    string t = e.Topic;

    switch (t)
    {
        case "Menu/exist":
            Console.WriteLine(m);
            break;
        case "Menu/request":
            string message = File.ReadAllText(menuCsv);
            string topic = "Menu/exist";
            Console.Write(message);
            client.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
            break;
        case "Menu/NewImage":
            Console.WriteLine(m);
            
            File.WriteAllBytes("../../../test.png", e.Message);
            break;
        case "Menu/NewFile":
            Console.WriteLine(m);
            File.WriteAllText(menuCsv, m);
            break;
    }
}


// 토픽 발행
string message = File.ReadAllText(menuCsv);
string topic = "Menu/exist";
Console.Write(message);
client.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false); // test/topic 토픽에 QoS 1, retain false로 메시지 발행
// 연결 종료

