using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<Puzzle> createPuzzles;
    public static List<Puzzle> PuzzleList;
    public static Puzzle CurrentPuzzle;
    public static List<PuzzleNote> CurrentPuzzleNotes;
    public static bool TutorialActive = false;
    public static bool HasEnteredTutorial = false;
    private static GameManager _instance;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

        //  if the static list has not been populated yet, populate it
        if (PuzzleList == null)
        {
            PuzzleList = new();
            foreach (Puzzle puzzle in createPuzzles)
            {
                PuzzleList.Add(puzzle);
            }
        }
        
        CurrentPuzzleNotes = new();
    }

    public static Puzzle GetPuzzle(Puzzle.PuzzleName puzzleName)
    {
        foreach (Puzzle puzzle in PuzzleList)
        {
            if (puzzle.GetName() == puzzleName)
            {
                return puzzle;
            }
        }

        Debug.Log("no puzzle found");
        return null;
    }

    public static void UpdateCurrentPuzzle(Puzzle.PuzzleName puzzleName)
    {
        foreach (Puzzle puzzle in PuzzleList)
        {
            if (puzzle.GetName() == puzzleName)
            {
                CurrentPuzzle = puzzle;
                LoadSceneManager.LoadScene(CurrentPuzzle.GetScene());
                return;
            }
        }
    }

    public static bool IsCurrentPuzzleSolved()
    {
        return CurrentPuzzle.IsSolved();
    }

    public static void SolveCurrentPuzzle()
    {
        CurrentPuzzle.SolvePuzzle();
    }

    public static void UpdatePuzzleNotes()
    {
        CurrentPuzzleNotes.Clear();

        foreach (Puzzle puzzle in PuzzleList)
        {
            if (puzzle.GetNote() != null && puzzle.GetNote().IsVisible())
            {
                CurrentPuzzleNotes.Add(puzzle.GetNote());
            }
        }
    }

    
}