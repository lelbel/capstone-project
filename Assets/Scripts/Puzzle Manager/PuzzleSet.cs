using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleGroup : MonoBehaviour
{
    [SerializeField] private List<Puzzle> puzzleGroup;
    [SerializeField] private Button button;
    public static PuzzleGroup Instance;
    private bool isPuzzleGroupCompleted = false;

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
}
