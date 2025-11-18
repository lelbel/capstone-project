using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<Puzzle> activePuzzles;
    public static Puzzle currentPuzzle;
    public static PuzzleManager Instance;

    [SerializeField] private Canvas canvas;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DebugCheck();
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
        //activePuzzles = PuzzleSelectManager.currentPuzzleGroup.GetPuzzleList();
        foreach (Puzzle puzzle in activePuzzles)
        {
            Button button =  new GameObject("MapButton").AddComponent<Button>();
            button.AddComponent<RectTransform>();
            button.AddComponent<Image>();
            button.transform.SetParent(canvas.transform, false);
            puzzle.SetButton(button);
            puzzle.UpdateButtonPosition();
        }

        RefreshSprites();
    }

    public void RefreshSprites()
    {
        //  set each sprite as incomeplete
        foreach (Puzzle puzzle in activePuzzles)
        {
            //  set sprite at complete if solved
            if (puzzle.IsSolved())
            {
                SetSpriteComplete(puzzle);
            }

            else
            {
                //  set sprite as incomplete if not solved
                SetSpriteIncomplete(puzzle);
            }
        }
    }

    //  set sprite as incomeplete
    public void SetSpriteIncomplete(Puzzle puzzle)
    {
        puzzle.GetButtonImage().sprite = puzzle.GetIncompleteSprite();
    }

    //  set sprite as complete
    public void SetSpriteComplete(Puzzle puzzle)
    {
        puzzle.GetButtonImage().sprite = puzzle.GetCompleteSprite();
    }

    public static bool IsCurrentPuzzleSolved()
    {
        return currentPuzzle.IsSolved();
    }

    public static void SolveCurrentPuzzle()
    {
        currentPuzzle.SolvePuzzle();
    }

    public void DebugCheck()
    {
        if (activePuzzles.Count == 0)
        {
            Debug.Log("activePuzzles list is empty");
        }
    }
}