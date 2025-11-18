using UnityEngine;
public class MenuButton : MonoBehaviour
{
    [SerializeField] private LoadSceneManager.SceneName scene;

    public void ButtonOnClick()
    {
        LoadSceneManager.LoadScene(scene);
    }
}