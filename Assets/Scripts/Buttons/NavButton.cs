using UnityEngine;
public class NavButton : MonoBehaviour
{
    [SerializeField] private LoadSceneManager.SceneName scene;

    //  navigate to specified scene
    public void ButtonOnClick()
    {
        LoadSceneManager.LoadScene(scene);
    }
}