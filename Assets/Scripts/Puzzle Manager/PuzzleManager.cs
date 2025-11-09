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

    void Start()
    {
        //Debug.Log(currentPuzzleButton);
        //Debug.Log(currentPuzzle);

        //RefreshSprites();
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

    public static void SolveCurrentPuzzle()
    {   
        currentPuzzle.GetComponent<Puzzle>().SolvePuzzle();
    }
}

/*
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
    */