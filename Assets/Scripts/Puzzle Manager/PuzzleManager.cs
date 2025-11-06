using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> puzzleList;
    public static bool currentPuzzleSolved = false;
    public static GameObject currentPuzzle;
    
    void Start()
    {
        //Debug.Log(currentPuzzle);

        //  update currrent puzzle
        UpdateCurrentPuzzle();

        //  set each sprite as incomeplete
        foreach (GameObject puzzle in puzzleList)
        {
            //  set sprite at complete if solved
            if (puzzle.GetComponent<Puzzle>().IsSolved())
            {
                SetSpriteComplete(puzzle);
            }

            else
            {
                //  set sprite as incomplete if not solved
                SetSpriteIncomplete(puzzle);
            }
        }
    }

    //  set sprite as incomeplete
    public void SetSpriteIncomplete(GameObject puzzle)
    {
        puzzle.GetComponent<Puzzle>().GetMapButton().GetComponent<Image>().sprite = puzzle.GetComponent<Puzzle>().GetIncompleteSprite();
    }

    //  set sprite as complete
    public void SetSpriteComplete(GameObject puzzle)
    {
        puzzle.GetComponent<Puzzle>().GetMapButton().GetComponent<Image>().sprite = puzzle.GetComponent<Puzzle>().GetCompleteSprite();
    }

    //  update the current puzzle if correct conditions are met
    public void UpdateCurrentPuzzle()
    {
        //Debug.Log("updating current puzzle...");
        //  check if currentPuzzle is populated AND is not solved AND that the puzzle was solved
        if (currentPuzzle != null && !currentPuzzle.GetComponent<Puzzle>().IsSolved() && currentPuzzleSolved == true)
        {
            currentPuzzle.GetComponent<Puzzle>().SolvePuzzle();
            currentPuzzleSolved = false;

            Debug.Log("current puzzle updated");
        }
    }
}