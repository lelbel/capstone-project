using UnityEngine;
using UnityEngine.UI;

public class PuzzleMarkers : MonoBehaviour
{
    //  general fields
    private PuzzleMarker[] puzzleMarkers;   //  array holdiong all the puzzle markers

    //  sprites
    [SerializeField] private Sprite puzzleCompleteSprite;
    [SerializeField] private Sprite puzzleIncompleteSprite;

    //  buttons
    [SerializeField] private Button arrowPuzzleBtn;

    //  puzzle markers
    private PuzzleMarker arrowPuzzleMkr;


    void Start()
    {
        //  instantiate puzzle markers
        arrowPuzzleMkr = new(ArrowPuzzleManager.arrowPuzzleComplete, arrowPuzzleBtn);

        //instantiate and populate puzzle marker array with all markers
        puzzleMarkers = new PuzzleMarker[] {arrowPuzzleMkr};

        foreach (PuzzleMarker p in puzzleMarkers)
        {
            //  if puzzle is complete show complete puzzle sprite
            if (p.IsSolved())
            {
                p.GetButton().GetComponent<Image>().sprite = puzzleCompleteSprite;
            }

            //  if puzzle is incomplete show incomplete puzzle sprite
            else
            {
                p.GetButton().GetComponent<Image>().sprite = puzzleIncompleteSprite;
            }
                
        }
    }
}