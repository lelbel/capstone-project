using UnityEngine;
using UnityEngine.UI;

public class PuzzleSelectManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueManager;

    private void Start()
    {
        //  activate dialogue manager if tutorial is active
        if (GameManager.TutorialActive)
        {
            dialogueManager.SetActive(true);
        }
    }
}