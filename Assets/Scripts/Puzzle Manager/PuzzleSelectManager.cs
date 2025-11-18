using UnityEngine;

public class PuzzleSelectManager : MonoBehaviour
{
    public static PuzzleGroup currentPuzzleGroup;
    public static PuzzleSelectManager Instance;

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
}
