using WebSocketSharp;
using UnityEngine;
using TMPro;

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
    public TMP_Text Fingerprint;
    public TMP_InputField Message, RecipientID;
    public Message MessageTemplate;

    WebSocket ws;

    public void Start() {
        ws = new WebSocket(Adress);
        ws.Connect(); 
        var auth = new AuthMessage();
        auth.Fingerprint = SystemInfo.deviceUniqueIdentifier;
        ws.Send(JsonUtility.ToJson(auth));
        ws.OnMessage += Ws_OnMessage;
        Fingerprint.text = SystemInfo.deviceUniqueIdentifier;
    }

    private void Ws_OnMessage(object sender, MessageEventArgs e) {
        var message = Instantiate(MessageTemplate);
        message.transform.SetParent(MessageTemplate.transform.parent);
        message.gameObject.SetActive(true);
        var data = JsonUtility.FromJson<DefaultMessage>(e.Data);
        message.Setup(data.Message, data.Sender);
    }

    [ContextMenu("test")]
    public void SendMessage() {
        var message = new DefaultMessage();
        message.Message = Message.text;
        message.Recipient = RecipientID.text;
        message.Sender = SystemInfo.deviceUniqueIdentifier;

        ws.Send(JsonUtility.ToJson(message));
    }
}
