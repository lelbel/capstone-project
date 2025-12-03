using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Sprite blankSprite;
    [SerializeField] private Sprite leftArrowSprite;
    [SerializeField] private Sprite rightArrowSprite;
    [SerializeField] private Sprite completedLeftArrowSprite;
    [SerializeField] private Sprite completedRightArrowSprite;
    
    private ArrowDirection[] userInput;
    private ArrowDirection[] solution;
    private int i = 0;

    private void Start()
    {
        if (GameManager.TutorialActive)
        {
            dialogueManager.SetActive(true);
        }
        
        //  reset player input
        ResetPlayerInput();

        //  instantiate solution array
        solution = new ArrowDirection[5] { ArrowDirection.Left , ArrowDirection.Right, ArrowDirection.Right , ArrowDirection.Left , ArrowDirection.Right };
    }

    public void InputArrow(ArrowDirection dir)
    {
        userInput[i] = dir;
            
        //  set left sprite
        if (dir == ArrowDirection.Left)
        {
            inputImages[i].sprite = leftArrowSprite;
        }

        //  set right sprite
        else
        {
            inputImages[i].sprite = rightArrowSprite;
        }

        i++;
        
        //  check solution if user input array is full
        if (i >= userInput.Length)
        {
            CheckAnswer();
        }
    }
    
    public void CheckAnswer()
    {
        i = 0;

        while (i < userInput.Length)
        {
            // if player answer is wrong, call incorrect function
            if (userInput[i] != solution[i])
            {
                IncorrectGuess();
                return;
            }

            i++;
        }

        //  player answer is correct, call complete function
        CompletePuzzle();
    }
    
    public void IncorrectGuess()
    {
        ResetPlayerInput();
    }

    public void CompletePuzzle()
    {
        //  solve the current puzzle
        GameManager.SolveCurrentPuzzle();

        //  show each arrow sprite as complete
        i = 0;

        while (i <  userInput.Length)
        {
            //  completed left arrow
            if (userInput[i] == ArrowDirection.Left)
            {
                inputImages[i].sprite = completedLeftArrowSprite;
            }

            //  completed right arrow
            else
            {
                inputImages[i].sprite = completedRightArrowSprite;
            }

            //  increment counter
            i++;
        }

        leftButton.interactable = false;
        rightButton.interactable = false;
    }
    
    public void ResetPlayerInput()
    {
        userInput = new ArrowDirection[5];
        
        i = 0;
        
        while (i < userInput.Length)
        {
            userInput[i] = ArrowDirection.None;
            inputImages[i].sprite = blankSprite;
            i++;
        }

        i = 0;
    }
}

/*
using UnityEngine;
using UnityEngine.UI;

//  redo this using enums at some point
//  add a finished state that displays if the current puzzle.IsSolved returns true
public class ArrowPuzzleManager : MonoBehaviour
{
    //  general
    [SerializeField] private GameObject dialogueManager;
    private Image[] arrowImages;    //  array that stores the image objects for the puzzle
    private int[] arrowDir;         //  array that tracks the player input for arrow entry
    private int[] solution;         //  array that has the solution input for the puzzle
    private int i = 0;              //  index tracker for array
    private int puzzleLength;       //  amount of arrow entries in the puzzle

    //  sprites
    [SerializeField] private Sprite blankSprite;
    [SerializeField] private Sprite leftArrowSprite;
    [SerializeField] private Sprite rightArrowSprite;
    [SerializeField] private Sprite completedLeftArrowSprite;
    [SerializeField] private Sprite completedRightArrowSprite;

    //  arrow images for the UI (display the current arrow state)
    [SerializeField] private Image arrowImg0;
    [SerializeField] private Image arrowImg1;
    [SerializeField] private Image arrowImg2;
    [SerializeField] private Image arrowImg3;
    [SerializeField] private Image arrowImg4;

    //  arrow buttons
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    void Start()
    {
        if (GameManager.TutorialActive)
        {
            dialogueManager.SetActive(true);
        }

        puzzleLength = 5;

        //  instantiate and populate array
        arrowImages = new Image[] { arrowImg0, arrowImg1, arrowImg2, arrowImg3, arrowImg4 };

        //  instantiate array that will hold arrow directions
        arrowDir = new int[5] { 0, 0, 0, 0, 0 };

        //  instantiate and populate solution
        solution = new int[5] { 1, 2, 2, 1, 2 };
    }

    // for arrow directions 1 left and 2 is right
    public void EnterArrow(int dir)
    {
        //  argument is not a 0 or 1
        if (dir != 1 && dir != 2)
        {
            Debug.Log("Incorrect argument for EnterArrow(). Please enter a 1 (left) or a 2 (right)");
            return;
        }

        //  update arrow object
        UpdateArrow(dir, i);

        //  increment counter
        i++;

        //  check at the end of arrow entry if final arrow has been placed
        //  check if correct pattern has been found
        if (i > (puzzleLength - 1))
        {
            //Debug.Log("Entry full");
            if (FoundSolution() == false)
            {
                ResetPuzzle();
            }

            else
            {
                CompletePuzzle();
            }
        }
    }

    //  update arrow object at correct index
    public void UpdateArrow(int dir, int i)
    {
        //  left arrow
        if (dir == 1)
        {
            arrowDir[i] = 1;
            arrowImages[i].GetComponent<Image>().sprite = leftArrowSprite;
        }

        //  right arrow
        if (dir == 2)
        {
            arrowDir[i] = 2;
            arrowImages[i].GetComponent<Image>().sprite = rightArrowSprite;
        }

        //  increment counter
        i++;
    }

    //  check player answer with solution
    public bool FoundSolution()
    {
        int counter = 0;

        while (counter < (puzzleLength - 1))
        {
            // if player answer is wrong, return false
            if (arrowDir[counter] != solution[counter])
            {
                return false;
            }

            counter++;
        }

        //  player answer is correct, return true
        return true;
    }

    //  reset puzzle
    public void ResetPuzzle()
    {
        //  change each image sprite to the blank sprite
        foreach (Image img in arrowImages)
        {
            img.GetComponent<Image>().sprite = blankSprite;
        }

        i = 0;
    }

    public void CompletePuzzle()
    {
        //  find the game manager object and solve the current puzzle
        GameManager.SolveCurrentPuzzle();

        //  show each arrow sprite as complete
        i = 0;

        foreach (int dir in arrowDir)
        {
            //  completed left arrow
            if (dir == 1)
            {
                arrowDir[i] = 1;
                arrowImages[i].GetComponent<Image>().sprite = completedLeftArrowSprite;
            }

            //  completed right arrow
            if (dir == 2)
            {
                arrowDir[i] = 2;
                arrowImages[i].GetComponent<Image>().sprite = completedRightArrowSprite;
            }

            //  increment counter
            i++;
        }

        leftButton.interactable = false;
        rightButton.interactable = false;

        //  navigate back to the menu
    }
} 
*/