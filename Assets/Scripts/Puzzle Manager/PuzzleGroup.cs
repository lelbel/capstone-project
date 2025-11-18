using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleGroup : MonoBehaviour
{
    [SerializeField] private List<Puzzle> puzzleGroup;
    [SerializeField] private Button button; 
    private bool isPuzzleGroupCompleted = false;

    public List<Puzzle> GetPuzzleGroup()
    {
        return puzzleGroup;
    }

    public Button GetButton()
    {
        return button;
    }

    public Image GetButtonImage()
    {
        return button.GetComponent<Image>();
    }

    public bool IsPuzzleGroupCompleted()
    {
        return isPuzzleGroupCompleted;
    }

    public void UpdatePuzzleGroupStatus()
    {
        bool allComplete = true;

        foreach (Puzzle puzzle in puzzleGroup)
        {
            if (!puzzle.IsSolved())
            {
                allComplete = false;
            }
        }

        if (allComplete)
        {
            isPuzzleGroupCompleted = true;
        }
    }

    public void ButtonOnClick()
    {
        PuzzleManager.currentPuzzleGroup = puzzleGroup;
        GameManager.LoadScene(GameManager.MapSceneName);
    }

    public void DebugCheck()
    {
        Debug.Log("current puzzles");
        
        foreach (Puzzle puzzle in PuzzleManager.currentPuzzleGroup)
        {
            Debug.Log(puzzle);
        }
    }
}
