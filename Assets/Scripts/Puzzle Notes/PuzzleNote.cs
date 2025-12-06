using UnityEngine;
using System;

[Serializable]
public class PuzzleNote
{
    [SerializeField] private bool hasPuzzleNote = false;
    [SerializeField] private Sprite sprite;
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;
    private bool isVisible;

    public Sprite GetSprite()
    {
        return sprite;
    }

    public float GetXPos()
    {
        return xPos;
    }

    public float GetYPos()
    {
        return yPos;
    }

    public bool IsVisible()
    {
        return isVisible;
    }

    public void Visible()
    {
        isVisible = true;
    }

    public void Invisible()
    {
        isVisible = false;
    }

    public bool HasPuzzleNote()
    {
        return hasPuzzleNote;
    }
}
