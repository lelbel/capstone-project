using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    private List<GameObject> mapButtons = new();
    [SerializeField] private GameObject canvas;
    [SerializeField] private Sprite incompleteSprite;
    [SerializeField] private Sprite completeSprite;

    void Start()
    {
        ResetPuzzleButtons();

        //  create a button for each active puzzle
        foreach (Puzzle puzzle in GameManager.currentPuzzleGroup)
        {
            CreateMapButton(puzzle);
        }

        RefreshSprites();
    }

    public void CreateMapButton(Puzzle puzzle)
    {
        //  create button
            GameObject button = new("MapButton");

            //  add button to button list
            mapButtons.Add(button);

            //  add all the components to the button
            button.AddComponent<Button>();
            button.AddComponent<RectTransform>();
            button.AddComponent<Image>();
            button.AddComponent<MapButton>();

            //  set the mapButton and puzzle objects to reference each other
            button.GetComponent<MapButton>().SetPuzzle(puzzle);

            puzzle.SetButton(button.GetComponent<Button>());

            //  add listener for function that updates the current puzzle
            button.GetComponent<Button>().onClick.AddListener(button.GetComponent<MapButton>().OnButtonClick);

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
        //foreach (Puzzle puzzle in GameManager.currentPuzzleGroup)
        foreach (GameObject button in mapButtons)
        {
            //  set sprite at complete if solved
            if (button.GetComponent<MapButton>().GetPuzzle().IsSolved())
            {
                button.GetComponent<MapButton>().GetPuzzle().GetButtonImage().sprite = completeSprite;
            }

            else
            {
                //  set sprite as incomplete if not solved
                button.GetComponent<MapButton>().GetPuzzle().GetButtonImage().sprite = incompleteSprite;
            }
        }
    }

    public void DebugCheck()
    {
        if (GameManager.currentPuzzleGroup.Count == 0)
        {
            Debug.Log("activePuzzles list is empty");
        }
    }
}