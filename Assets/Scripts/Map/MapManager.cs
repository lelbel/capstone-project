using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject mapMarkerPrefab;

    private void Start()
    {
        if (GameManager.CurrentPuzzle == null)
        {
            Debug.Log("no current puzzle");
            return;
        }

        //  check that current puzzle has a map marker
        if (GameManager.CurrentPuzzle.GetMapMarker().HasMapMarker())
        {
            //  create marker
            GameObject marker = Instantiate(mapMarkerPrefab, Vector3.zero, Quaternion.identity);
            
            //  set position
            marker.GetComponent<RectTransform>().anchoredPosition = new Vector2(GameManager.CurrentPuzzle.GetMapMarker().GetX(), GameManager.CurrentPuzzle.GetMapMarker().GetY());
            
            //  set button parent as canvas so it shows up
            marker.transform.SetParent(this.transform, false);
        }
    }
}

/*
 *
 * using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Sprite completeSprite;
    [SerializeField] private Sprite incompleteSprite;
    private List<GameObject> mapButtons = new();

    private void Start()
    {
        //  update puzzle notes
        GameManager.UpdatePuzzleNotes();

        //  remove old map buttons
        ResetPuzzleButtons();

        //  create a button for each active puzzle
        foreach (Puzzle puzzle in GameManager.CurrentPuzzleGroup)
        {
            CreateMapButton(puzzle);
        }

        RefreshSprites();
    }

    private void CreateMapButton(Puzzle puzzle)
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

    private void RefreshSprites()
    {
        //  set each sprite as incomplete
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
}
 */