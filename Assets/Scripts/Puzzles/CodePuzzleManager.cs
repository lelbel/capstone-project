using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

//  remove solution length as a field and set dynamically stupid
public class CodePuzzleManager : MonoBehaviour
{
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

        if (GameManager.IsCurrentPuzzleSolved())
        {
            userInput.text = solution;
            FoundSolution();
        }
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
            GameManager.SolveCurrentPuzzle();
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
    IEnumerator Incorrect()
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
