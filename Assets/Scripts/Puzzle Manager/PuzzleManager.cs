using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<Puzzle> activePuzzles;
    public static List<GameObject> mapButtons = new();
    public static Puzzle currentPuzzle;
    public static bool mapEnabled;
    [SerializeField] private GameObject canvas;
    
    /*
    public static PuzzleManager Instance;

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
    */
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //public void OpenMap()

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (mapEnabled)
        {
            ResetPuzzleButtons();

            //  create a button for each active puzzle
            foreach (Puzzle puzzle in activePuzzles)
            {
                //  create button
                GameObject button =  new("MapButton");

                //  add button to button list
                mapButtons.Add(button);

                //  add all the components to the button
                button.AddComponent<Button>();
                button.AddComponent<RectTransform>();
                button.AddComponent<Image>();
                button.AddComponent<MapButton>();

                //  set the mapButton and puzzle objects to reference each other
                button.GetComponent<MapButton>().SetPuzzle(puzzle);

                Debug.Log(button.GetComponent<MapButton>().GetPuzzle());

                puzzle.SetButton(button.GetComponent<Button>());

                //  add listener for function that stores the current button
                button.GetComponent<Button>().onClick.AddListener(button.GetComponent<MapButton>().OnButtonClick);

                //  set button parent as canvas so it shows up
                button.transform.SetParent(canvas.transform, false);

                //  move the buttons to the position specified in the puzzle coordinates argument
                puzzle.UpdateButtonPosition();
            }

            RefreshSprites();
        }
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

    public static void ResetPuzzleButtons()
    {
        foreach (GameObject button in mapButtons)
        {
            Destroy(button);
        }

        mapButtons.Clear();
    }

    public void DebugCheck()
    {
        if (activePuzzles.Count == 0)
        {
            Debug.Log("activePuzzles list is empty");
        }
    }
}