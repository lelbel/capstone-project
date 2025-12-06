using UnityEngine;

//  REVIEW (implementation has changed now that the map is not the puzzle select screen)
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

    //  set currentPuzzleGroup
    public void OnButtonClick()
    {
        GameManager.CurrentPuzzle = puzzle;
        LoadSceneManager.LoadScene(GameManager.CurrentPuzzle.GetScene());
    }
}