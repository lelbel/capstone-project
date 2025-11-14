using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleSet : MonoBehaviour
{
    [SerializeField] private List<PuzzleGroup> puzzleSet;
    [SerializeField] private Button button;

    public static PuzzleSet Instance;
    private bool isSetCompleted;

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

    public List<PuzzleGroup> GetPuzzleSet()
    {
        return puzzleSet;
    }

    public Button GetButton()
    {
        return button;
    }

    public Image GetButtonImage()
    {
        return button.GetComponent<Image>();
    }

    public bool IsPuzzleSetCompleted()
    {
        return isSetCompleted;
    }

    public void UpdateSetStatus()
    {
        bool allComplete = true;

        foreach (PuzzleGroup group in puzzleSet)
        {
            if (!group.GetPuzzle().IsSolved())
            {
                allComplete = false;
            }
        }

        if (allComplete)
        {
            isSetCompleted = true;
        }
    }
}
