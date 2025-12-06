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
    private void UpdateSprite()
    {
        //  debug - puzzle not created in game manager but reference to the enum is in a select buton
        if (GameManager.GetPuzzle(puzzleName) == null)
        {
            return;
        }
        
        if (GameManager.GetPuzzle(puzzleName).IsSolved())
        {
            this.GetComponent<Image>().sprite = puzzleCompleteSprite;
        }

        else
        {
            this.GetComponent<Image>().sprite = puzzleIncompleteSprite;
        }

        if (GameManager.TutorialActive)
        {
            this.GetComponent<Button>().enabled = false;
        }
    }
        
    //  update current puzzle when puzzle is selected
    public void ButtonOnClick()
    {
        GameManager.UpdateCurrentPuzzle(puzzleName);
    }
}