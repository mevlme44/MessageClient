using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    public TMP_Text Data, Sender;

    public void Setup(string data, string sender) {
        Data.text = data;
        Sender.text = sender;
    }
}
