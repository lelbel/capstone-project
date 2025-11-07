using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateCurrentPuzzle : MonoBehaviour
{
    //  THE ONCLICK WORKS YES
    //  get clicked game object
    public void OnButtonClick()
    {
        PuzzleManager.currentPuzzleButton = EventSystem.current.currentSelectedGameObject;
        Debug.Log(PuzzleManager.currentPuzzleButton);
        
        /*
        if (EventSystem.current.currentSelectedGameObject.CompareTag("PuzzleButton"))
        {
            PuzzleManager.currentPuzzleButton = EventSystem.current.currentSelectedGameObject;
            Debug.Log(PuzzleManager.currentPuzzleButton);
        }

        else
        {
            Debug.Log("selected object does not have the correct tag");
        }
        */
    }
}