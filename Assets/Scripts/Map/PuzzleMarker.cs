using UnityEngine;
using UnityEngine.UI;

public class PuzzleMarker
{
    private readonly bool isSolved;
    [SerializeField] private Button button;

    public PuzzleMarker(bool globalPuzzleCompletionVar, Button btn)
    {
        isSolved = globalPuzzleCompletionVar;
        button = btn;
    }

    public bool IsSolved()
    {
        return isSolved;
    }

    public Button GetButton()
    {
        return button;
    }
}