using UnityEngine;

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
        LoadSceneManager.LoadScene(GameManager.currentPuzzle.GetScene());
    }
}