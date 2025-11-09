using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sentence
{
    public string text;
    public LibrarianManager.LibrarianState librarianState = LibrarianManager.LibrarianState.INVISIBLE;

    public string GetText()
    {
        return text;
    }

    public void ChangeState(LibrarianManager.LibrarianState state)
    {
        LibrarianManager.currentState = state;
    }
}
