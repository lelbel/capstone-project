using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private LibrarianManager librarianManager;
    [SerializeField] private float typeDelay = 0.02f;
    private Queue<Sentence> sentences;
    public Dialogue dialogue;


    void Awake()
    {
        sentences = new Queue<Sentence>();
    }

    void Start()
    {
        StartDialogue(dialogue);
    }

    //  start the dialogue
    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.GetName().ToString();

        //  clear queue
        sentences.Clear();

        //  add each sentence to the queue
        foreach (Sentence sentence in dialogue.sentences)
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

        Sentence sentence = sentences.Dequeue();

        //  stop animating current dialogue letters if player progresses through text fast
        StopAllCoroutines();

        //  start letter typing
        StartCoroutine(TypeSentence(sentence));
        //Debug.Log("reached");
    }

    public void EndDialogue()
    {

        //Debug.Log("dialogue ended");
    }

    //  print letters one by one
    IEnumerator TypeSentence(Sentence sentence)
    {
        //Debug.Log("co started");
        dialogueText.text = "";
        foreach (char letter in sentence.GetText().ToCharArray())
        {
            //  append letter to end of the string
            dialogueText.text += letter;

            //  wait one frame in between each letter
            yield return new WaitForSeconds(typeDelay);
        }
    }

}
