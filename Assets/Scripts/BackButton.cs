using UnityEngine;

public class BackButton : MonoBehaviour
{
    public string sceneName;

    public void ButtonOnClick()
    {
        GameManager.LoadScene(sceneName);
    }
}
