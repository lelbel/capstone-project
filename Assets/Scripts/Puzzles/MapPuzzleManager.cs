using UnityEngine;

public class MapPuzzleManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.SolveCurrentPuzzle();
    }
}