using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    private Puzzle puzzle;

    public void SetPuzzle(Puzzle pzl)
    {
        puzzle = pzl;
    }

    public Puzzle GetPuzzle()
    {
        return puzzle;
    }

    public void OnButtonClick()
    {
        //  set currentPuzzleGroup as the parent of the clicked button
        PuzzleManager.currentPuzzle = puzzle;
        
        Debug.Log($"currentPuzzle: {PuzzleManager.currentPuzzle}");

        //  change scene
        if (string.IsNullOrWhiteSpace(PuzzleManager.currentPuzzle.GetSceneName()))
        {
            Debug.Log("sceneName string argument is blank");
            return;
        }

        SceneManager.LoadScene(PuzzleManager.currentPuzzle.GetSceneName());
    }
}
