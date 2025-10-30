using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class CodePuzzleManager : MonoBehaviour
{
    //  global
    public static bool boatCodePuzzleComplete = false;
    public static bool dangerCodePuzzleComplete = false;
    public static bool libbyCodePuzzleComplete = false;
    public static bool finalCodePuzzleComplete = false;

    [SerializeField] private TMP_InputField userInput;
    [SerializeField] private Button submitButton;
    [SerializeField] private string solution;
    [SerializeField] private int solutionLength;
    

    void Start()
    {
        //  set character limit
        userInput.characterLimit = solutionLength;

        // set carat as invisible
        Color caretColor = userInput.caretColor;
        caretColor.a = 0f;
        userInput.caretColor = caretColor;
        userInput.caretPosition = 0;
    }

    //  function that triggers when the submit button is entered
    public void CheckAnswer()
    {
        if (string.IsNullOrWhiteSpace(solution))
        {
            Debug.Log("Solution string is blank");
            return;
        }
        
        if (string.Equals(userInput.text, solution, System.StringComparison.OrdinalIgnoreCase) == true)
        {
            Debug.Log("correct");

            if (string.Equals(userInput.text, "boat", System.StringComparison.OrdinalIgnoreCase) == true)
            {
                boatCodePuzzleComplete = true;
            }

            else if (string.Equals(userInput.text, "danger", System.StringComparison.OrdinalIgnoreCase) == true)
            {
                dangerCodePuzzleComplete = true;
            }

            else if (string.Equals(userInput.text, "libby", System.StringComparison.OrdinalIgnoreCase) == true)
            {
                libbyCodePuzzleComplete = true;
            }

            else if (string.Equals(userInput.text, "library", System.StringComparison.OrdinalIgnoreCase) == true)
            {
                finalCodePuzzleComplete = true;
            }

            else
            {
                Debug.Log("correct answer does not match any of the predetermined cases");
            }
            
            FoundSolution();
        }

        else
        {
            StartCoroutine(Incorrect());
        }
    }

    public void FoundSolution()
    {
        userInput.textComponent.color = Color.green;
        userInput.interactable = false;
        submitButton.interactable = false;
    }

    //  add delay
    public IEnumerator Incorrect()
    {
        Debug.Log("incorrect");
        userInput.textComponent.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        userInput.textComponent.color = Color.black;
        yield return new WaitForSeconds(0.15f);
        userInput.textComponent.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        userInput.textComponent.color = Color.black;

        //  reset string
        userInput.text = string.Empty;
    }
}
