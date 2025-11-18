using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class Puzzle: MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private Sprite incompleteSprite;
    [SerializeField] private Sprite completeSprite;
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;
    private bool isSolved = false;
    private Button button;

    public Button GetButton()
    {
        return button;
    }

    public void SetButton(Button btn)
    {
        button = btn;

        //  move button to specified x and y coords
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);
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

    public Sprite GetCompleteSprite()
    {
        return completeSprite;
    }

    public Sprite GetIncompleteSprite()
    {
        return incompleteSprite;
    }

    public void SolvePuzzle()
    {
        isSolved = true;
    }

    public void OnButtonClick()
    {
        GameManager.LoadScene(sceneName);
    }
}