using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleGroup> activePuzzles;
    public static PuzzleGroup currentPuzzleGroup;
    public static PuzzleManager Instance;

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefreshSprites();
    }

    public void RefreshSprites()
    {
        //  set each sprite as incomeplete
        foreach (PuzzleGroup group in activePuzzles)
        {
            //  set sprite at complete if solved
            if (group.GetPuzzle().IsSolved())
            {
                SetSpriteComplete(group);
            }

            else
            {
                //  set sprite as incomplete if not solved
                SetSpriteIncomplete(group);
            }
        }
    }

    //  set sprite as incomeplete
    public void SetSpriteIncomplete(PuzzleGroup group)
    {
        group.GetButtonImage().sprite = group.GetPuzzle().GetIncompleteSprite();
    }

    //  set sprite as complete
    public void SetSpriteComplete(PuzzleGroup group)
    {
        group.GetButtonImage().sprite = group.GetPuzzle().GetCompleteSprite();
    }

    public static bool IsCurrentPuzzleSolved()
    {
        return currentPuzzleGroup.GetPuzzle().IsSolved();
    }

    public static void SolveCurrentPuzzle()
    {
        currentPuzzleGroup.GetPuzzle().SolvePuzzle();
    }
}