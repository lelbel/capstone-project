using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigate : MonoBehaviour
{
    [SerializeField] private string scene;

    public void ChangeScene()
    {
        Debug.Log($"opening puzzle {scene}");

        //  check that the scene string is populated
        if (string.IsNullOrWhiteSpace(scene))
        {
            Debug.Log("puzzleScene string argument is blank");
            return;
        }

        Debug.Log("loading puzzle");
        SceneManager.LoadScene(scene);
    }
}