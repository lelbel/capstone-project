using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;

    public Dialogue dialogue;

    void Start()
    {
        TriggerDialogue();
    }

    //  trigger the dialogue
    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }
}