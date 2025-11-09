using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateCurrentPuzzle : MonoBehaviour
{
    //  THE ONCLICK WORKS YES
    //  get clicked game object
    public void OnButtonClick()
    {
        PuzzleManager.currentPuzzleButton = EventSystem.current.currentSelectedGameObject;
    }
}