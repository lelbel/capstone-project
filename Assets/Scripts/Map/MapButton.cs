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
        //  set currentPuzzleGroup
        GameManager.currentPuzzle = puzzle;
        GameManager.LoadScene(GameManager.currentPuzzle.GetSceneName());
    }
}
