using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string scene;

    public void LoadScene()
    {
        //Debug.Log($"Loading Scene: {scene}");

        //  check that the scene string is populated
        if (string.IsNullOrWhiteSpace(scene))
        {
            Debug.Log("sceneName string argument is blank");
            return;
        }

        SceneManager.LoadScene(scene);
    }
}