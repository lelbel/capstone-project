using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UpdateCurrentPuzzle : MonoBehaviour
{    
    //  get clicked game object
    public void OnButtonClick()
    {
        Debug.Log("button clicked");
        //  set currentPuzzleGroup as the parent of the clicked button
        PuzzleManager.currentPuzzle = EventSystem.current.currentSelectedGameObject.transform.gameObject.GetComponent<Puzzle>();
        
        Debug.Log($"currentPuzzle: {PuzzleManager.currentPuzzle}");

        //  change scene
        if (string.IsNullOrWhiteSpace(PuzzleManager.currentPuzzle.GetSceneName()))
        {
            Debug.Log("sceneName string argument is blank");
            return;
        }

        SceneManager.LoadScene(PuzzleManager.currentPuzzle.GetSceneName());
    }
}