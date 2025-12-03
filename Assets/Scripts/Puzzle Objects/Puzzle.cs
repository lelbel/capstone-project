using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[Serializable]
public class Puzzle
{
    public enum PuzzleName
    {
        ArrowPuzzle,
        BoatCodePuzzle,
        DangerCodePuzzle,
        LibbyCodePuzzle,
        FinalCodePuzzle,
        MapPuzzle,
    }
    
    [SerializeField] private PuzzleName puzzleName;
    [SerializeField] private LoadSceneManager.SceneName scene;
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;
    [SerializeField] private bool isSolved = false;
    [SerializeField] private PuzzleNote puzzleNote;
    private Button button;

    public PuzzleName GetName()
    {
        return puzzleName;
    }

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
    
    public LoadSceneManager.SceneName GetScene()
    {
        return scene;
    }

    public bool IsSolved()
    {
        return isSolved;
    }

    public void SolvePuzzle()
    {
        isSolved = true;
        puzzleNote.Visible();
    }

    public PuzzleNote GetNote()
    {
        return puzzleNote;
    }

    public void OnButtonClick()
    {
        LoadSceneManager.LoadScene(scene);
    }
}