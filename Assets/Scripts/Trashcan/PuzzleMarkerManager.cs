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
    [SerializeField] private Button boatCodePuzzleBtn;
    [SerializeField] private Button dangerCodePuzzleBtn;
    [SerializeField] private Button libbyCodePuzzleBtn;
    [SerializeField] private Button finalCodePuzzleBtn;

    //  puzzle markers
    private PuzzleMarker arrowPuzzleMkr;
    private PuzzleMarker boatCodePuzzleMkr;
    private PuzzleMarker dangerCodePuzzleMkr;
    private PuzzleMarker libbyCodePuzzleMkr;
    private PuzzleMarker finalCodePuzzleMkr;


    void Start()
    {
        //  instantiate puzzle markers
        arrowPuzzleMkr = new(ArrowPuzzleManager.arrowPuzzleComplete, arrowPuzzleBtn);
        boatCodePuzzleMkr = new(CodePuzzleManager.boatCodePuzzleComplete, boatCodePuzzleBtn);
        dangerCodePuzzleMkr = new(CodePuzzleManager.dangerCodePuzzleComplete, dangerCodePuzzleBtn);
        libbyCodePuzzleMkr = new(CodePuzzleManager.libbyCodePuzzleComplete, libbyCodePuzzleBtn);
        finalCodePuzzleMkr = new(CodePuzzleManager.finalCodePuzzleComplete, finalCodePuzzleBtn);

        //instantiate and populate puzzle marker array with all markers
        puzzleMarkers = new PuzzleMarker[] { arrowPuzzleMkr, boatCodePuzzleMkr, dangerCodePuzzleMkr, libbyCodePuzzleMkr, finalCodePuzzleMkr};
        
        //  check if puzzle has been solved

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