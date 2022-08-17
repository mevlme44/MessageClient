using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserTile : MonoBehaviour
{
    public MessengerScreen MessengerScreen;

    public TMP_Text Avatar, Name;
    public RawImage AvatarImage;

    Button button;

    void Awake() {
        button = GetComponent<Button>();
    }

    public void Setup(string name) {
        Avatar.text = name[Random.Range(0, name.Length)].ToString();
        Name.text = name;
        AvatarImage.color = ColorsGiver.Instance.RandomColor;
        button.onClick.AddListener(() => MessengerScreen.OnClickUser(this));
    }
}
