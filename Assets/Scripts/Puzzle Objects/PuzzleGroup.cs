using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleGroup : MonoBehaviour
{
    [SerializeField] private List<Puzzle> puzzleGroup;
    [SerializeField] private Button button;
    [SerializeField] private LoadSceneManager.SceneName scene;
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
        Debug.Log("button clicked");
        GameManager.currentPuzzleGroup = puzzleGroup;
        LoadSceneManager.LoadScene(scene);
    }

    public void DebugCheck()
    {
        Debug.Log("current puzzles");
        
        foreach (Puzzle puzzle in GameManager.currentPuzzleGroup)
        {
            Debug.Log(puzzle);
        }
    }
}
