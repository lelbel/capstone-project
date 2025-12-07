/*
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    void Start()
    {
        if (GameManager.CurrentPuzzle.GetNote() != null && !GameManager.CurrentPuzzle.GetNote().IsVisible())
        {
            gameObject.SetActive(true);
            GameManager.CurrentPuzzle.GetNote().Visible();
            GameManager.UpdatePuzzleNotes();
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}
*/