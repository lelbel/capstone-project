using UnityEngine;

public class SwitchDialogueManager : MonoBehaviour
{
    public static bool AdvancedTutorial = false;
    [SerializeField] private GameObject startDialogue;
    [SerializeField] private GameObject endDialogue;

    //  check if first half of the tutorial in the tutorial scene has been completed
    private void Start()
    {
        if (AdvancedTutorial)
        {
            startDialogue.SetActive(false);
            endDialogue.SetActive(true);
        }

        else
        {
            startDialogue.SetActive(true);
            endDialogue.SetActive(false);
        }
    }
}