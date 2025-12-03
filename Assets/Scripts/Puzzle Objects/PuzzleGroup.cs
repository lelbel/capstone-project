using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class PuzzleGroup
{
    public enum GroupName
    {
        Arrow,
        Code,
        Map
    }
    
    [SerializeField] private GroupName groupName;
    [SerializeField] private List<Puzzle> puzzleList;

    public GroupName GetName()
    {
        return groupName;
    }

    public List<Puzzle> GetPuzzleList()
    {
        return puzzleList;
    }
    
    public bool IsPuzzleGroupCompleted()
    {
        foreach (Puzzle puzzle in puzzleList)
        {
            if (!puzzle.IsSolved())
            {
                return false;
            }
        }

        return true;
    }
}

/*
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

[Serializable]
public class PuzzleGroup
{
    [SerializeField] private List<Puzzle> puzzleGroup;
    [SerializeField] private LoadSceneManager.SceneName scene;
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;
    [SerializeField] private string buttonText;
    private Button button;
    private bool isPuzzleGroupCompleted = false;

    public List<Puzzle> GetPuzzleGroup()
    {
        return puzzleGroup;
    }

    public Button GetButton()
    {
        return button;
    }

    public void SetButton(Button btn)
    {
        button = btn;
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);
    }

    public Image GetButtonImage()
    {
        return button.GetComponent<Image>();
    }

    public LoadSceneManager.SceneName GetScene()
    {
        return scene;
    }

    public bool IsPuzzleGroupCompleted()
    {
        return isPuzzleGroupCompleted;
    }

    public void UpdatePuzzleGroupStatus()
    {
        bool allComplete = true;

        foreach (Puzzle puzzle in puzzleGroup)
        {
            if (!puzzle.IsSolved())
            {
                allComplete = false;
            }
        }

        if (allComplete)
        {
            isPuzzleGroupCompleted = true;
        }
    }
    
    public string GetButtonText()
    {
        return buttonText;
    }

    public void DebugCheck()
    {
        Debug.Log("current puzzles");
        
        foreach (Puzzle puzzle in GameManager.currentPuzzleGroup)
        {
            Debug.Log(puzzle);
        }
    }
}
*/