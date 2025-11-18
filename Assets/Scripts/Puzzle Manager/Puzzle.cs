using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public class Puzzle: MonoBehaviour
{
    [Header("General")]
    [SerializeField] private string sceneName;
    private bool isSolved = false;

    [Header("Sprites")]
    [SerializeField] private Sprite incompleteSprite;
    [SerializeField] private Sprite completeSprite;

    [Header("Map Button")]
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;
    private Button button;

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

    public void UpdateButtonPosition()
    {
        if(button != null)
        {
            button.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);
        }
    }

    public void OnButtonClick()
    {
        GameManager.LoadScene(sceneName);
    }
}