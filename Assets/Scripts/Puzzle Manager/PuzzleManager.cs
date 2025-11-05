using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> puzzleList;
    
    void Start()
    {
        Debug.Log("script started");
        //puzzleList = new List<GameObject>();

        //  set each sprite as incomeplete
        foreach (GameObject puzzle in puzzleList)
        {
            Debug.Log($"IsSolved: {puzzle.GetComponent<Puzzle>().IsSolved()}");
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
        puzzle.GetComponentInChildren<Button>().GetComponent<Image>().sprite = puzzle.GetComponent<Puzzle>().GetIncompleteSprite();
    }

    //  set sprite as complete
    public void SetSpriteComplete(GameObject puzzle)
    {
        puzzle.GetComponentInChildren<Button>().GetComponent<Image>().sprite = puzzle.GetComponent<Puzzle>().GetCompleteSprite();
    }
}