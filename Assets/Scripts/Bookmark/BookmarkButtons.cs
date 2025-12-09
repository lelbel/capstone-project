using UnityEngine;
using UnityEngine.UI;

public class BookmarkButtons : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button mapButton;
    [SerializeField] private Button noteButton;

    [SerializeField] private GameObject map;
    [SerializeField] private GameObject note;

    private void Start()
    {
        backButton.onClick.AddListener(Back);
        mapButton.onClick.AddListener(OpenMap);
        noteButton.onClick.AddListener(OpenNotes);

        //  set map to show by default
        map.SetActive(true);
        note.SetActive(false);

        if (GameManager.TutorialActive)
        {
            backButton.enabled = false;
            mapButton.enabled = false;
            noteButton.enabled = false;
        }

        if (GameManager.CurrentPuzzle.GetNote() == null)
        {
            noteButton.gameObject.SetActive(false);
        }
    }

    public void OpenMap()
    {
        map.SetActive(true);
        note.SetActive(false);
    }

    public void OpenNotes()
    {
        map.SetActive(false);
        note.SetActive(true);
    }

    public void Back()
    {
        Destroy(gameObject);
    }
}