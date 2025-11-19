using UnityEngine;
using UnityEngine.InputSystem;

public class Debugger : MonoBehaviour
{
    public static Debugger Instance;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach(PuzzleGroup group in GameManager.puzzleGroups)
            {
                Debug.Log($"static group: {group}");   
            }
            Debug.Log($"current puzzle group: {GameManager.currentPuzzleGroup}");
            Debug.Log($"current puzzle: {GameManager.currentPuzzle}");
        }
    }
}
