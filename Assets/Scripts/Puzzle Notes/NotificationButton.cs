using UnityEngine;
using UnityEngine.UI;

public class NotificationButton : MonoBehaviour
{
    [SerializeField] private Button returnButton;

    void Start()
    {
        if (GameManager.TutorialActive)
        {
            returnButton.enabled = false;
        }
    }
    
    public void ButtonOnClick()
    {
        Destroy(gameObject);
    }
}