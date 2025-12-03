namespace puzzle_select
{
    using UnityEngine;
    using UnityEngine.UI;

    public class PuzzleSelectSprite : MonoBehaviour
    {
        [SerializeField] private Puzzle.PuzzleName puzzleName;
        [SerializeField] private Sprite puzzleCompleteSprite;
        [SerializeField] private Sprite puzzleIncompleteSprite;

        //  update puzzle select sprites depending on puzzle completion status
        public void UpdateSprite()
        {
            if (GameManager.GetPuzzle(puzzleName).IsSolved())
            {
                this.GetComponent<Image>().sprite = puzzleCompleteSprite;
            }

            else
            {
                this.GetComponent<Image>().sprite = puzzleIncompleteSprite;
            }
        }
    }
}