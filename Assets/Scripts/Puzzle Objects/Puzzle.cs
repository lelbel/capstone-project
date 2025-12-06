using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[Serializable]
public class Puzzle
{
    public enum PuzzleName
    {
        ArrowPuzzleDVD,
        BoatCodePuzzle,
        DangerCodePuzzle,
        LibbyCodePuzzle,
        LibraryCodePuzzle,
        MapPuzzle,
        WizardPuzzle
    }
    
    [SerializeField] private PuzzleName puzzleName;
    [SerializeField] private LoadSceneManager.SceneName scene;
    [SerializeField] private bool isSolved = false;
    [SerializeField] private PuzzleNote puzzleNote;
    [SerializeField] private MapMarker mapMarker;
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

    public MapMarker GetMapMarker()
    {
        return mapMarker;
    }

    public void OnButtonClick()
    {
        LoadSceneManager.LoadScene(scene);
    }
}