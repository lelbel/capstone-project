using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateCurrentPuzzleManager : MonoBehaviour
{
    //  THE ONCLICK WORKS YES
    //  get clicked game object
    public void OnButtonClick()
    {
        if (EventSystem.current.currentSelectedGameObject.CompareTag("PuzzleButton"))
        {
            PuzzleManager.currentPuzzle = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
            Debug.Log(PuzzleManager.currentPuzzle);
        }

        else
        {
            Debug.Log("selected object does not have the correct tag");
        }
    }
}