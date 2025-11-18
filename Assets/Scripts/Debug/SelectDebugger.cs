using UnityEngine;

public class SelectDebugger : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"current PuzzleGroups: {PuzzleGroup.puzzleGroups}");
    }
}
