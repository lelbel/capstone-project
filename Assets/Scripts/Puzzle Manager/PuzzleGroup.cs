using UnityEngine;
using UnityEngine.UI;

public class PuzzleGroup : MonoBehaviour
{
    public Puzzle puzzle;
    public Button button;

    public Puzzle GetPuzzle()
    {
        return puzzle;
    }

    public Button GetButton()
    {
        return button;
    }

    public Image GetButtonImage()
    {
        return button.GetComponent<Image>();
    }
}
