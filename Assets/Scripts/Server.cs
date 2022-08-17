using WebSocketSharp;
using UnityEngine;
using TMPro;

public class Server : MonoSingleton<Server>
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
    public Message MessageTemplate;

    WebSocket ws;

    public void Start() {
        ws = new WebSocket(Adress);
        ws.Connect(); 
        var auth = new AuthMessage();
        auth.Fingerprint = SystemInfo.deviceUniqueIdentifier;
        ws.Send(JsonUtility.ToJson(auth));
        ws.OnMessage += Ws_OnMessage;
    }

    [ContextMenu("test")]
    public void Test() {
        var message = MessageTemplate.InstantiateTemplate();
        message.Setup("test");
    }
    private void Ws_OnMessage(object sender, MessageEventArgs e) {
        var message = Instantiate(MessageTemplate);
        message.transform.SetParent(MessageTemplate.transform.parent);
        message.gameObject.SetActive(true);
        var data = JsonUtility.FromJson<DefaultMessage>(e.Data);
        message.Setup(data.Message);
    }

    public void SendMessage(string text, string recipient) {
        var message = new DefaultMessage();
        message.Message = text;
        message.Recipient = recipient;
        message.Sender = SystemInfo.deviceUniqueIdentifier;

        ws.Send(JsonUtility.ToJson(message));
    }
}
