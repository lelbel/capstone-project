using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateCurrentPuzzleManager : MonoBehaviour
{
    public UpdateCurrentPuzzleManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /*
        DontDestroyOnLoad(gameObject);
        if (instance == null || instance != this)
        {
            instance = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
         */
    }

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