using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<Puzzle> activePuzzles;
    public static Puzzle currentPuzzle;
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefreshSprites();
    }

    public void RefreshSprites()
    {
        //  set each sprite as incomeplete
        foreach (Puzzle puzzle in activePuzzles)
        {
            //  set sprite at complete if solved
            if (puzzle.IsSolved())
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
    public void SetSpriteIncomplete(Puzzle puzzle)
    {
        puzzle.GetButtonImage().sprite = puzzle.GetIncompleteSprite();
    }

    //  set sprite as complete
    public void SetSpriteComplete(Puzzle puzzle)
    {
        puzzle.GetButtonImage().sprite = puzzle.GetCompleteSprite();
    }

    public static bool IsCurrentPuzzleSolved()
    {
        return currentPuzzle.IsSolved();
    }

    public static void SolveCurrentPuzzle()
    {
        currentPuzzle.SolvePuzzle();
    }
}