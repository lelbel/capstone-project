using UnityEngine;
using UnityEngine.UI;

public class PuzzleSelectButton : MonoBehaviour
{
    [SerializeField] private Puzzle.PuzzleName puzzleName;
    [SerializeField] private Sprite puzzleCompleteSprite;
    [SerializeField] private Sprite puzzleIncompleteSprite;

    private void Start()
    {
        UpdateSprite();
    }

    //  update puzzle select sprites depending on puzzle completion status
    public void UpdateSprite()
    {
        if (GameManager.GetPuzzle(puzzleName).IsSolved())
        {
            this.GetComponent<Image>().sprite = puzzleCompleteSprite;
            this.GetComponent<Button>().enabled = false;
        }

        else
        {
            this.GetComponent<Image>().sprite = puzzleIncompleteSprite;
        }
    }
        
    //  update current puzzle when puzzle is selected
    public void ButtonOnClick()
    {
        GameManager.UpdateCurrentPuzzle(puzzleName);
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