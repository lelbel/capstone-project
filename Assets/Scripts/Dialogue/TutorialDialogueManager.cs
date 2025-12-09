using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogueManager : MonoBehaviour
{
    public enum Actions
    {
        ShowName,
        HideName,
        HideSprite,
        SpriteDefault,
        LoadScene,
        AdvanceTutorial,
        EndTutorial,
        ShowBookmark
    }
    
    [SerializeField] private Image character;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private float typeDelay = 0.02f;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private LoadSceneManager.SceneName scene;
    [SerializeField] private GameObject bookmark;
    
    [SerializeField] private Dialogue dialogue;
    
    private Queue<Sentence> sentences;
    
    private void Awake()
    {
        sentences = new Queue<Sentence>();
    }
    
    private void Start()
    {
        //  start the dialogue
        StartDialogue(dialogue);
    }

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            DisplayNextSentence();
        }
    }
    */

    public void StartDialogue(Dialogue dialogue)
    {
        //  set name
        nameText.text = dialogue.GetName();

        //  clear sentence queue
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
        
        //  perform actions if there are any
        if (sentence.actions.Count != 0)
        {
            foreach (Actions action in sentence.actions)
            {
                PerformAction(action);
            }
        }

        //  stop animating current dialogue letters if player progresses through text fast
        StopAllCoroutines();

        //  start letter typing
        StartCoroutine(TypeSentence(sentence.text));
    }

    public void PerformAction(Actions action)
    {
        switch (action)
        {
            case Actions.ShowName:
                nameText.enabled = true;
                break;
            
            case Actions.HideName:
                nameText.enabled = false;
                break;
            
            case Actions.HideSprite:
                character.enabled = false;
                break;
            
            case Actions.SpriteDefault:
                character.enabled = true;
                character.GetComponent<Image>().sprite = defaultSprite;
                break;
            
            case Actions.LoadScene:
                LoadSceneManager.LoadScene(scene);
                break;
            
            case Actions.AdvanceTutorial:
                SwitchDialogueManager.AdvancedTutorial = true;
                LoadSceneManager.LoadScene(LoadSceneManager.SceneName.PuzzleSelect);
                break;
            
            case Actions.EndTutorial:
                GameManager.TutorialActive = false;
                LoadSceneManager.LoadScene(LoadSceneManager.SceneName.PuzzleSelect);
                break;
            
            case Actions.ShowBookmark:
                bookmark.SetActive(true);
                break;
        }
    }

    public void EndDialogue()
    {
    }

    //  print letters one by one
    IEnumerator TypeSentence(string text)
    {
        dialogueText.text = "";
        
        foreach (char letter in text)
        {
            //  append letter to end of the string
            dialogueText.text += letter;

            //  wait one frame in between each letter
            yield return new WaitForSeconds(typeDelay);
        }
    }
}