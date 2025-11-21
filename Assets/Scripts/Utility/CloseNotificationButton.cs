using Unity.VisualScripting;
using UnityEngine;

public class CloseNotificationButton : MonoBehaviour
{
    [SerializeField] private GameObject notification;
    public void ButtonOnClick()
    {
        Destroy(notification);
    }
}