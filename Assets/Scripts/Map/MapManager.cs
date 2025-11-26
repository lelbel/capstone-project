using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Sprite completeSprite;
    [SerializeField] private Sprite incompleteSprite;
    private List<GameObject> mapButtons = new();

    void Start()
    {
        //  update puzzle notes
        GameManager.UpdatePuzzleNotes();

        //  remove old map buttons
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
            GameObject button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity);

            //  add button to button list
            mapButtons.Add(button);

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

/*
    [SerializeField] private List<GameObject> tutorialArrows;
    private Queue<GameObject> tutorialArrowQueue;
    private GameObject currentTutorialArrow;
    
    if (GameManager.tutorialActive)
        {
            Tutorial();
        }
    
 public void Tutorial()
    {
        //  queue tutorial arrows to be displayed
        tutorialArrowQueue = new Queue<GameObject>();

        foreach (GameObject arrow in tutorialArrows)
        {
            arrow.SetActive(false);
            tutorialArrowQueue.Enqueue(arrow);
        }
    }
    
public void ShowNextArrow()
    {
        currentTutorialArrow = tutorialArrowQueue.Dequeue();
        currentTutorialArrow.SetActive(true);
    }

    public void HideCurrentArrow()
    {
        currentTutorialArrow.SetActive(false);
    }
*/