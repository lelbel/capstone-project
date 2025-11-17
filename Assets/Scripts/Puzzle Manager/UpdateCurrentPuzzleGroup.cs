using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateCurrentPuzzleGroup : MonoBehaviour
{
    public void OnButtonClick()
    {
        //  set currentPuzzleGroup as the parent of the clicked button
        GamePuzzleManager.currentPuzzleGroup = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.GetComponent<PuzzleGroup>();

        Debug.Log($"current puzzle set: {GamePuzzleManager.currentPuzzleGroup}");
    }
}
