using UnityEngine;

public class MapDebugger : MonoBehaviour
{
    [SerializeField] PuzzleGroup puzzleGroup;

    void Awake()
    {
        if (PuzzleManager.currentPuzzleGroup == null)
        {
            PuzzleManager.currentPuzzleGroup = puzzleGroup.GetPuzzleGroup();
        }
    }
}
