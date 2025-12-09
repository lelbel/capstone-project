using UnityEngine;

public class ArrowPuzzleButton : MonoBehaviour
{
    [SerializeField] private ArrowPuzzleManager arrowPuzzleManager;
    [SerializeField] private ArrowPuzzleManager.ArrowDirection arrowDirection;

    public void ButtonOnClick()
    {
        AudioManager.PlayPageTurn();
        arrowPuzzleManager.InputArrow(arrowDirection);
    }
}