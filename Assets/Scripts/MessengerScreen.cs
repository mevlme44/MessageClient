using UnityEngine;

public class MessengerScreen : MonoBehaviour
{
    public ChatScreen ChatScreen;

    public void OnClickUser(UserTile tile) {
        ChatScreen.gameObject.SetActive(true);
        ChatScreen.Setup(tile.Name.text, tile.AvatarImage.color, tile.Avatar.text);
    }
}
