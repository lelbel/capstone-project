using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateCurrentPuzzle : MonoBehaviour
{    
    //  THE ONCLICK WORKS YES
    //  get clicked game object
    public void OnButtonClick()
    {
        //  set currentPuzzleGroup as the parent of the clicked button
        PuzzleManager.currentPuzzle = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<Puzzle>();
    }
}