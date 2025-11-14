using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateCurrentPuzzleGroup : MonoBehaviour
{    
    //  THE ONCLICK WORKS YES
    //  get clicked game object
    public void OnButtonClick()
    {
        //  set currentPuzzleGroup as the parent of the clicked button
        ActivePuzzleGroupManager.currentPuzzleGroup = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<PuzzleGroup>();
    }
}