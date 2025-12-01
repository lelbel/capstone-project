using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;

public class GameManager : MonoBehaviour
{
    public static List<Puzzle> currentPuzzleGroup;
    public static Puzzle currentPuzzle;
    public static List<PuzzleNote> currentPuzzleNotes = new();
    public static List<PuzzleGroup> puzzleGroups;
    public static GameManager Instance;
    public static bool tutorialActive = false;
    public static bool hasEnteredTutorial = false;
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

    public static void UpdatePuzzleNotes()
    {
        currentPuzzleNotes.Clear();

        foreach (Puzzle puzzle in currentPuzzleGroup)
        {
            if (puzzle.GetNote() != null && puzzle.GetNote().IsVisible())
            {
                currentPuzzleNotes.Add(puzzle.GetNote());
            }
        }
    }
}