using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public class Puzzle: MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] Button button;
    [SerializeField] private Sprite incompleteSprite;
    [SerializeField] private Sprite completeSprite;
    [SerializeField] private bool isSolved = false;
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;

    public Button GetButton()
    {
        return button;
    }

    public void SetButton(Button btn)
    {
        button = btn;
    }

    public Image GetButtonImage()
    {
        return button.GetComponent<Image>();
    }
    
    public string GetSceneName()
    {
        return sceneName;
    }

    public bool IsSolved()
    {
        return isSolved;
    }

    public void SolvePuzzle()
    {
        isSolved = true;
    }

    public Sprite GetCompleteSprite()
    {
        return completeSprite;
    }

    public Sprite GetIncompleteSprite()
    {
        return incompleteSprite;
    }

    public void UpdateButtonPosition()
    {
        if(button != null)
        {
            button.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);
        }
    }

    public void LoadScene()
    {
        if (string.IsNullOrWhiteSpace(sceneName))
        {
            Debug.Log("sceneName string argument is blank");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }
}

/*
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGroup : MonoBehaviour
{
    public Puzzle puzzle;
    public Button button;

    public Puzzle GetPuzzle()
    {
        return puzzle;
    }

    public Button GetButton()
    {
        return button;
    }

    public Image GetButtonImage()
    {
        return button.GetComponent<Image>();
    }
}
*/