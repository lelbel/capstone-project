namespace puzzle_select
{
    using UnityEngine;
    using System.Collections.Generic;

    public class PuzzleSelectManager : MonoBehaviour
    {
        [SerializeField] private GameObject dialogueManager;
        [SerializeField] private List<PuzzleSelectSprite> puzzleSelectSprites;

        void Start()
        {
            //  update puzzle select sprites
            foreach (PuzzleSelectSprite sprite in puzzleSelectSprites)
            {
                sprite.UpdateSprite();
            }

            //  activate dialogue manager if tutorial is active
            if (GameManager.TutorialActive)
            {
                dialogueManager.SetActive(true);
            }
        }
    }
}

/*
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class PuzzleGroupSelectManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject dialogueManager;
    private List<GameObject> groupButtons = new();

    void Start()
    {
        ResetPuzzleButtons();

        //  create a button for each active puzzle
        foreach (PuzzleGroup group in GameManager.puzzleGroups)
        {
            CreatePuzzleSelectButton(group);
        }

        if (GameManager.tutorialActive)
        {
            dialogueManager.SetActive(true);
            Tutorial();
        }
    }

    public void CreatePuzzleSelectButton(PuzzleGroup group)
    {
        //  create instance of button prefab
            GameObject button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity);

            //  add button to button list
            groupButtons.Add(button);

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
        foreach (GameObject button in groupButtons)
        {
            Destroy(button);
        }

        groupButtons.Clear();
    }

    // Only enable first puzzle in group
    public void Tutorial()
    {
        if (groupButtons.Count > 1)
        {
            int i = 1;
            while (i < groupButtons.Count)
            { 
                groupButtons[i].GetComponent<Button>().enabled = false;
                i++;
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
*/