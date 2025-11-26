using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject exitNotificationPrefab;
    private GameObject notification;
    
    public void ExitTutorialButton()
    {
        notification = Instantiate(exitNotificationPrefab, Vector3.zero, Quaternion.identity);
        notification.transform.SetParent(canvas.transform, false);
    }
}
