using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static List<Puzzle> currentPuzzleGroup;
    public static Puzzle currentPuzzle;
    public static List<PuzzleGroup> puzzleGroups;
    public static GameManager Instance;
    public List<PuzzleGroup> createPuzzleGroups;

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

        //  if the static list has not been populated yet, populate it
        if (puzzleGroups == null)
        {
            puzzleGroups = new();
            foreach (PuzzleGroup group in createPuzzleGroups)
            {
                puzzleGroups.Add(group);
                Debug.Log(group);
            }
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
