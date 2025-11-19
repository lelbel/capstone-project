using UnityEngine;

public class PuzzleGroupSelectButton : MonoBehaviour
{
    private PuzzleGroup puzzleGroup;

    public void SetPuzzleGroup(PuzzleGroup pzlgrp)
    {
        puzzleGroup = pzlgrp;
    }

    public void OnButtonClick()
    {
        GameManager.currentPuzzleGroup = puzzleGroup.GetPuzzleGroup();
        LoadSceneManager.LoadScene(puzzleGroup.GetScene());
    }
}