using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleGroupSelectManager : MonoBehaviour
{
    private List<GameObject> mapButtons = new();
    [SerializeField] private GameObject canvas;

    void Start()
    {
        ResetPuzzleButtons();

        //  create a button for each active puzzle
        foreach (PuzzleGroup group in GameManager.puzzleGroups)
        {
            CreatePuzzleSelectButton(group);
        }

        RefreshSprites();
    }

    public void CreatePuzzleSelectButton(PuzzleGroup group)
    {
        //  create button
            GameObject button = new("SelectButton");

            //  add button to button list
            mapButtons.Add(button);

            //  add all the components to the button
            button.AddComponent<Button>();
            button.AddComponent<RectTransform>();
            button.AddComponent<Image>();
            button.AddComponent<PuzzleGroupSelectButton>();

            //  set the mapButton and puzzle objects to reference each other
            button.GetComponent<PuzzleGroupSelectButton>().SetPuzzleGroup(group);

            Debug.Log($"select button puzzle: {button.GetComponent<PuzzleGroupSelectButton>().GetPuzzleGroup()}");

            group.SetButton(button.GetComponent<Button>());

            //  add listener for function that updates the current puzzle
            button.GetComponent<Button>().onClick.AddListener(button.GetComponent<PuzzleGroupSelectButton>().OnButtonClick);

            //  set button parent as canvas so it shows up
            button.transform.SetParent(canvas.transform, false);
    }

    private void ResetPuzzleButtons()
    {
        foreach (GameObject button in mapButtons)
        {
            Destroy(button);
        }

        mapButtons.Clear();
    }

    public void RefreshSprites()
    {
        //  set each sprite as incomeplete
        foreach (Puzzle puzzle in GameManager.currentPuzzleGroup)
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

    public void DebugCheck()
    {
        if (GameManager.currentPuzzleGroup.Count == 0)
        {
            Debug.Log("activePuzzles list is empty");
        }
    }
}