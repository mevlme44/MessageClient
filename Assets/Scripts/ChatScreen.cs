using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatScreen : MonoBehaviour
{
    public TMP_Text Avatar, Name;
    public RawImage AvatarImage;
    public Button SendButton;
    public TMP_InputField MessageField;

    public void Setup(string name, Color color, string shortName) {
        Avatar.text = shortName;
        Name.text = name;
        AvatarImage.color = color;

        //SendButton.onClick.AddListener(() => )
    }
}
