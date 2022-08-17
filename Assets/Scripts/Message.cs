using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public TMP_Text Data;
    public RawImage Background;
    public bool Own;

    public void Setup(string data) {
        Background.color = Own ? ColorsGiver.Instance.OwnMessageColor : ColorsGiver.Instance.DefaultMessageColor;
        Data.text = data;
    }
}
