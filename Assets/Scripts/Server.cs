using WebSocketSharp;
using UnityEngine;
using UnityEngine.UI;

public class Server : MonoBehaviour
{
    class AuthMessage
    {
        public string Header = "auth";
        public string Fingerprint;
    }

    class DefaultMessage
    {
        public string Header = "message";
        public string Sender;
        public string Recipient;
        public string Message;
    }

    public string Adress;
    public Text Text;
    public InputField FPout, FPto, Message;

    WebSocket ws;
    bool authFlag = false;

    public void Start() {
        ws = new WebSocket(Adress);
        ws.OnMessage += Ws_OnMessage;
    }

    private void Ws_OnMessage(object sender, MessageEventArgs e) {
        Text.text = JsonUtility.FromJson<DefaultMessage>(e.Data).Message;
    }

    [ContextMenu("test")]
    public void SendMessage() {
        if (!authFlag) {
            ws.Connect(); var auth = new AuthMessage();
            auth.Fingerprint = FPout.text;
            ws.Send(JsonUtility.ToJson(auth));
            authFlag = true;
        }
        var message = new DefaultMessage();
        message.Message = Message.text;
        message.Recipient = FPto.text;
        message.Sender = FPout.text;

        ws.Send(JsonUtility.ToJson(message));
    }
}
