using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> puzzleList;
    public static GameObject currentPuzzleButton;
    public static GameObject currentPuzzle;
    public static PuzzleManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if (currentPuzzleButton != null)
        {
            foreach (GameObject puzzle in puzzleList)
            {
                if (puzzle.CompareTag(currentPuzzleButton.tag))
                {
                    currentPuzzle = puzzle;
                }
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefreshSprites();
    }

    public void RefreshSprites()
    {
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

    public static bool IsCurrentPuzzleSolved()
    {
        return currentPuzzle.GetComponent<Puzzle>().IsSolved();
    }

    public static void SolveCurrentPuzzle()
    {   
        currentPuzzle.GetComponent<Puzzle>().SolvePuzzle();
    }
}