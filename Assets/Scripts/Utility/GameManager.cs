using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<PuzzleGroup> createPuzzleGroups;
    
    public static List<Puzzle> CurrentPuzzleGroup;
    public static Puzzle CurrentPuzzle;
    public static List<PuzzleNote> CurrentPuzzleNotes;
    public static bool TutorialActive = false;
    public static bool HasEnteredTutorial = false;
    
    private static List<PuzzleGroup> _puzzleGroups;
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
        if (_puzzleGroups == null)
        {
            _puzzleGroups = new();
            foreach (PuzzleGroup group in createPuzzleGroups)
            {
                _puzzleGroups.Add(group);
            }
        }

        CurrentPuzzleNotes = new();
    }
    
    public static Puzzle GetPuzzle(Puzzle.PuzzleName puzzleName)
    {
        foreach (PuzzleGroup group in _puzzleGroups)
        {
            foreach (Puzzle puzzle in group.GetPuzzleList())
            {
                if (puzzle.GetName() == puzzleName)
                {
                    return puzzle;
                }
            }
        }

        Debug.Log("no puzzle found");
        return null;
    }

    public static PuzzleGroup GetPuzzleGroup(PuzzleGroup.GroupName groupName)
    {
        foreach (PuzzleGroup group in _puzzleGroups)
        {
            if (group.GetName() == groupName)
            {
                return group;
            }
        }
        
        Debug.Log("no group found");
        return null;
    }

    public static void UpdateCurrentPuzzle(Puzzle.PuzzleName puzzleName)
    {
        foreach (PuzzleGroup group in _puzzleGroups)
        {
            foreach (Puzzle puzzle in group.GetPuzzleList())
            {
                if (puzzle.GetName() == puzzleName)
                {
                    CurrentPuzzle = puzzle;
                    CurrentPuzzleGroup = group.GetPuzzleList();
                    LoadSceneManager.LoadScene(CurrentPuzzle.GetScene());
                    return;
                }
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

        foreach (Puzzle puzzle in CurrentPuzzleGroup)
        {
            if (puzzle.GetNote() != null && puzzle.GetNote().IsVisible())
            {
                CurrentPuzzleNotes.Add(puzzle.GetNote());
            }
        }
    }

    public static bool FinalPuzzleCheck()
    {
        foreach (PuzzleGroup group in _puzzleGroups)
        {
            if (group.IsPuzzleGroupCompleted() == false)
            {
                return false;
            }
        }

        return true;
    }
}