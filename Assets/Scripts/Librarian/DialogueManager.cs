using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    private Queue<string> sentences;    //  queue holding all the sentences

    void Start()
    {
        //  instantiate sentences
        sentences = new Queue<string>();
    }

    //  start the dialogue
    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        Debug.Log($"dialogue with {name}");
        //  clear queue
        sentences.Clear();

        //  add each sentence to the queue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //  check if there are any remaining sentences
        if (sentences.Count == 0)
        {
            //  end dialogue
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        //  stop animating current dialogue letters if player progresses through text fast
        StopAllCoroutines();

        //  start letter typing
        StartCoroutine(TypeSentence(sentence));
        Debug.Log("reached");
    }

    public void EndDialogue()
    {
        Debug.Log("dialogue ended");
    }

    //  print letters one by one
    IEnumerator TypeSentence(string sentence)
    {
        Debug.Log("co started");
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            //  append letter to end of the string
            dialogueText.text += letter;

            //  wait one frame in between each letter
            yield return new WaitForSeconds(0.02f);
        }
    }

}
