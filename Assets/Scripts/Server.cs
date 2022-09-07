using WebSocketSharp;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

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
        StartCoroutine(GetMessages());
    }

    IEnumerator GetMessages() {
        var req = UnityWebRequest.Get("http://89.208.229.139:5051/getMyMessages/");
        req.SetRequestHeader("Authorization", "");
        yield return req.SendWebRequest();

        Debug.LogError(req.downloadHandler.text);
    }

    private void Ws_OnMessage(object sender, MessageEventArgs e) {
        var data = JsonUtility.FromJson<DefaultMessage>(e.Data);
        if (data.Header == "message") {
            var message = Instantiate(MessageTemplate);
            message.transform.SetParent(MessageTemplate.transform.parent);
            message.gameObject.SetActive(true);
            message.Setup(data.Message);
        }
        else if (data.Header == "error") {
            Debug.LogError(data.Message);
        }
        else {

        }
    }

    [ContextMenu("Send")]
    public void Send() {
        SendMessage("test", "test");
    }

    public void SendMessage(string text, string recipient) {
        var message = new DefaultMessage();
        message.Message = text;
        message.Recipient = recipient;
        message.Sender = SystemInfo.deviceUniqueIdentifier;

        ws.Send(JsonUtility.ToJson(message));
    }
}
