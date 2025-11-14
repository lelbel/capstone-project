using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class GamePuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSet> puzzleSets;
    public static PuzzleSet currentPuzzleSet;
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