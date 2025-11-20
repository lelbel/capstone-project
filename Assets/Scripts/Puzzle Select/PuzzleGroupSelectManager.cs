using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class PuzzleGroupSelectManager : MonoBehaviour
{
    private List<GameObject> mapButtons = new();
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject buttonPrefab;

    void Start()
    {
        ResetPuzzleButtons();

        //  create a button for each active puzzle
        foreach (PuzzleGroup group in GameManager.puzzleGroups)
        {
            CreatePuzzleSelectButton(group);
        }
    }

    public void CreatePuzzleSelectButton(PuzzleGroup group)
    {
        //  create button
            GameObject button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity);

            //  add button to button list
            mapButtons.Add(button);

            //  add all the components to the button
            //button.AddComponent<Button>();
            //button.AddComponent<RectTransform>();
            //button.AddComponent<Image>();
            //button.AddComponent<PuzzleGroupSelectButton>();

            //  set the button and puzzleGroup objects to reference each other
            button.GetComponent<PuzzleGroupSelectButton>().SetPuzzleGroup(group);

            group.SetButton(button.GetComponent<Button>());
            
            //  set text
            button.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = group.GetButtonText();

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

    public void DebugCheck()
    {
        if (GameManager.currentPuzzleGroup.Count == 0)
        {
            Debug.Log("activePuzzles list is empty");
        }
    }
}