namespace puzzle_select
{
    using UnityEngine;

    public class PuzzleSelectButton : MonoBehaviour
    {
        [SerializeField] private Puzzle.PuzzleName puzzleName;
    
        //  update current puzzle when puzzle is selected
        public void ButtonOnClick()
        {
            GameManager.UpdateCurrentPuzzle(puzzleName);
        }
    }

}

/*
public class PuzzleGroupSelectButton : MonoBehaviour
{
    private PuzzleGroup puzzleGroup;

    public void SetPuzzleGroup(PuzzleGroup pzlgrp)
    {
        puzzleGroup = pzlgrp;
    }

    public void OnButtonClick()
    {
        GameManager.currentPuzzleGroup = puzzleGroup.GetPuzzleGroup();
        LoadSceneManager.LoadScene(puzzleGroup.GetScene());
    }
}
*/