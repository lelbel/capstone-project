using UnityEngine;
public class NavButton : MonoBehaviour
{
    [SerializeField] private LoadSceneManager.SceneName scene;

    public void ButtonOnClick()
    {
        LoadSceneManager.LoadScene(scene);
    }
}