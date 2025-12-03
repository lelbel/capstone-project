using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleNoteManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject notePrefab;
    private List<GameObject> notes = new();

    void Start()
    {
        if (GameManager.CurrentPuzzleNotes != null)
        {
            ResetNotes();

            //  create a note for each puzzleNote object
            foreach (PuzzleNote note in GameManager.CurrentPuzzleNotes)
            {
                CreateNote(note);
            }
        }
    }

    public void CreateNote(PuzzleNote puzzleNote)
    {
        GameObject note = Instantiate(notePrefab, Vector3.zero, Quaternion.identity);
        
        //  add note to list
        notes.Add(note);

        //  set sprite
        note.GetComponent<Image>().sprite = puzzleNote.GetSprite();

        //  set note parent as canvas to it shows up
        note.transform.SetParent(canvas.transform, false);

        //  set note position
        note.GetComponent<RectTransform>().anchoredPosition = new Vector2(puzzleNote.GetXPos(), puzzleNote.GetYPos());
    }

    private void ResetNotes()
    {
        foreach (GameObject note in notes)
        {
            Destroy(note);
        }

        notes.Clear();
    }
}