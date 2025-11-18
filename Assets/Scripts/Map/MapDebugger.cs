using UnityEngine;

public class MapDebugger : MonoBehaviour
{
    [SerializeField] PuzzleGroup puzzleGroup;

    public static MapDebugger Instance;

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

        if (GameManager.currentPuzzleGroup == null)
        {
            GameManager.currentPuzzleGroup = puzzleGroup.GetPuzzleGroup();
        }
    }
}
