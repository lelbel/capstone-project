using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static List<Puzzle> currentPuzzleGroup;
    public static Puzzle currentPuzzle;
    public List<PuzzleGroup> puzzleGroups;
    public static GameManager Instance;

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

    public static bool IsCurrentPuzzleSolved()
    {
        return currentPuzzle.IsSolved();
    }

    public static void SolveCurrentPuzzle()
    {
        currentPuzzle.SolvePuzzle();
    }
}
