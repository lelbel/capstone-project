using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleMarkers : MonoBehaviour
{
    [SerializeField] private string puzzleScene;

    public void OpenPuzzle()
    {
        Debug.Log($"opening puzzle {puzzleScene}");
        
        //  check that the scene string is populated
        if (!string.IsNullOrWhiteSpace(puzzleScene))
        {
            Debug.Log("loading puzzle");
            SceneManager.LoadScene(puzzleScene);
        }

        else
        {
            Debug.Log("puzzleScene string argument is blank");
        }
    }
}
