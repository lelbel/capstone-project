using UnityEngine;
using UnityEngine.UI;

public class NotificationButtons : MonoBehaviour
{
    [SerializeField] private Button returnButton;

    void Start()
    {
        if (GameManager.tutorialActive)
        {
            returnButton.enabled = false;
        }
    }
    
    public void ButtonOnClick()
    {
        Destroy(gameObject);
    }
}