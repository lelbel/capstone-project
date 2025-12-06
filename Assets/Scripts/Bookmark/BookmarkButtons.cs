using UnityEngine;
using UnityEngine.UI;

public class BookmarkButtons : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button mapButton;
    [SerializeField] private Button noteButton;
    private void Start()
    {
        backButton.onClick.AddListener(Back);
        mapButton.onClick.AddListener(OpenMap);
        noteButton.onClick.AddListener(OpenNotes);
        
        if (!GameManager.CurrentPuzzle.GetMapMarker().HasMapMarker())
        {
            mapButton.enabled = false;
        }

        if (!GameManager.CurrentPuzzle.GetNote().HasPuzzleNote())
        {
            noteButton.enabled = false;
        }
    }

    public void OpenMap()
    {
        LoadSceneManager.LoadScene(LoadSceneManager.SceneName.Map);
    }
    
    public void OpenNotes()
    {
        LoadSceneManager.LoadScene(LoadSceneManager.SceneName.PuzzleNotes);
    }

    public void Back()
    {
        Destroy(gameObject);
    }
}
