using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    void Start()
    {
        if (GameManager.currentPuzzle.GetNote() != null && !GameManager.currentPuzzle.GetNote().IsVisible())
        {
            gameObject.SetActive(true);
            GameManager.currentPuzzle.GetNote().Visible();
            GameManager.UpdatePuzzleNotes();
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}