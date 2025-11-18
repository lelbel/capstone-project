using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static List<Puzzle> currentPuzzleGroup;
    public static Puzzle currentPuzzle;
    public static string MapSceneName = "Map";

    /*
    public static GameManager Instance;

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
    */

    public static bool IsCurrentPuzzleSolved()
    {
        return currentPuzzle.IsSolved();
    }

    public static void SolveCurrentPuzzle()
    {
        currentPuzzle.SolvePuzzle();
    }

    public static void LoadScene(string scene)
    {
        //  check that the scene string is populated
        if (string.IsNullOrWhiteSpace(scene))
        {
            Debug.Log("sceneName string argument is blank");
            return;
        }

        SceneManager.LoadScene(scene);
    }
}
