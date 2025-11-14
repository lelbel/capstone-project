using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateCurrentPuzzleSet : MonoBehaviour
{
    public void OnButtonClick()
    {
        //  set currentPuzzleGroup as the parent of the clicked button
        GamePuzzleManager.currentPuzzleSet = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<PuzzleSet>();

        Debug.Log($"current puzzle set: {GamePuzzleManager.currentPuzzleSet}");
    }
}
