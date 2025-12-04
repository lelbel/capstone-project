using UnityEngine;

public class SwitchDialogueManager : MonoBehaviour
{
    public static bool EndingTutorial = false;
    [SerializeField] private GameObject startDialogue;
    [SerializeField] private GameObject endDialogue;

    private void Awake()
    {
        startDialogue.SetActive(false);
        endDialogue.SetActive(false);
    }

    private void Start()
    {
        if (EndingTutorial)
        {
            endDialogue.SetActive(true);
        }

        else
        {
            startDialogue.SetActive(true);
        }
    }
}