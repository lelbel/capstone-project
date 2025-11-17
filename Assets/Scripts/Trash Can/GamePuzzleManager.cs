using UnityEngine;
using System.Collections.Generic;

public class GamePuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleGroup> puzzleGroups;
    public static PuzzleGroup currentPuzzleGroup;
    public static GamePuzzleManager Instance;

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