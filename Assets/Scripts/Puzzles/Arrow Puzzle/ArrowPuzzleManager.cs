using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class ArrowPuzzleManager : MonoBehaviour
{
    public enum ArrowDirection
    {
        None,
        Right,
        Left
    }

    [SerializeField] private GameObject dialogueManager;
    [SerializeField] private Image[] inputImages;
    
    [Header("Buttons")]
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    
    [Header("Sprites")]
    [SerializeField] private Sprite leftArrowSprite;
    [SerializeField] private Sprite rightArrowSprite;
    
    [SerializeField] private Sprite completeLeftArrowSprite;
    [SerializeField] private Sprite completeRightArrowSprite;
    
    [SerializeField] private Sprite incorrectLeftArrowSprite;
    [SerializeField] private Sprite incorrectRightArrowSprite;
    
    [SerializeField] private ArrowDirection[] solution = new ArrowDirection[5];
    
    private ArrowDirection[] playerInput;
    private int i = 0;

    private void Start()
    {
        if (GameManager.TutorialActive)
        {
            dialogueManager.SetActive(true);
            leftButton.enabled = false;
            rightButton.enabled = false;
        }

        //  instantiate input and solution array
        playerInput = new ArrowDirection[5] { ArrowDirection.None, ArrowDirection.None, ArrowDirection.None, ArrowDirection.None, ArrowDirection.None};

        if (solution == null)
        {
            Debug.Log("solution not set");
        }

        //  set i
        i = 0;
        
        //  reset player input
        ResetPlayerInput();
        
        if (GameManager.CurrentPuzzle != null)
        {
            //  check if current puzzle has been solved
            if (GameManager.CurrentPuzzle.IsSolved())
            {
                playerInput = solution;
                CompletePuzzle();
            }
        }
    }

    public void InputArrow(ArrowDirection dir)
    {
        playerInput[i] = dir;
        inputImages[i].enabled = true;
        
        UpdateSprite(leftArrowSprite, rightArrowSprite);

        i++;
        
        //  check solution if user input array is full
        if (i >= playerInput.Length)
        {
            CheckAnswer();
        }
    }
    
    public void CheckAnswer()
    {
        i = 0;

        bool correct = true;

        while (i < playerInput.Length)
        {
            // if player answer is wrong, call incorrect function
            if (playerInput[i] != solution[i])
            {
                correct = false;
            }

            i++;
        }

        if (correct)
        {
            //  player answer is correct, call complete function
            CompletePuzzle();
        }

        else
        {
            StartCoroutine(Incorrect());
        }
    }

    public void CompletePuzzle()
    {
        //  debug
        if (GameManager.CurrentPuzzle == null)
        {
            Debug.Log("no current puzzle");
            return;
        }

        //  solve the current puzzle
        GameManager.SolveCurrentPuzzle();

        //  show each arrow sprite as complete
        i = 0;

        while (i <  playerInput.Length)
        {
            inputImages[i].enabled = true;
            UpdateSprite(completeLeftArrowSprite, completeRightArrowSprite);
            
            //  increment counter
            i++;
        }
        
        i = 0;

        leftButton.interactable = false;
        rightButton.interactable = false;
    }
    
    public void ResetPlayerInput()
    {
        i = 0;
        
        while (i < playerInput.Length)
        {
            playerInput[i] = ArrowDirection.None;
            inputImages[i].enabled = false;
            i++;
        }

        i = 0;
    }

    public void UpdateSprite(Sprite left, Sprite right)
    {
        //  show each arrow as left sprite or right sprite
    
        //  left arrow
        if (playerInput[i] == ArrowDirection.Left)
        {
            inputImages[i].sprite = left;
        }

        //  right arrow
        else
        {
            inputImages[i].sprite = right;
        }
    }

    private void UpdateAllSprite(Sprite left, Sprite right)
    {
        i = 0;

        while (i < playerInput.Length)
        {
            UpdateSprite(left, right);
            i++;
        }

        i = 0;
    }

    //  incorrect answer indicator
    IEnumerator Incorrect()
    {
        leftButton.enabled = false;
        rightButton.enabled = false;
        
        i = 0;

        UpdateAllSprite(incorrectLeftArrowSprite, incorrectRightArrowSprite);
        yield return new WaitForSeconds(0.15f);
        UpdateAllSprite(leftArrowSprite, rightArrowSprite);
        yield return new WaitForSeconds(0.15f);
        UpdateAllSprite(incorrectLeftArrowSprite, incorrectRightArrowSprite);
        yield return new WaitForSeconds(0.15f);
        UpdateAllSprite(leftArrowSprite, rightArrowSprite);
        yield return new WaitForSeconds(0.15f);
        
        ResetPlayerInput();
        
        leftButton.enabled = true;
        rightButton.enabled = true;
    }
}