using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CodePuzzleBoatManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField userInput;
    [SerializeField] private Button submitButton;
    private readonly string solution = "boat";

    void Start()
    {
        //  set character limit
        userInput.characterLimit = 4;

        // set carat as invisible
        Color caretColor = userInput.caretColor;
        caretColor.a = 0f;
        userInput.caretColor = caretColor;

        userInput.caretPosition = 0;

    }

    //  function that triggers when the submit button is entered
    public void CheckAnswer()
    {
        if (string.Equals(userInput.text, solution, System.StringComparison.OrdinalIgnoreCase) == true)
        {
            Debug.Log("correct");
            FoundSolution();
        }

        else
        {
            Debug.Log("incorrect");
        }
    }

    public void FoundSolution()
    {
        userInput.textComponent.color = Color.green;
        userInput.interactable = false;
        submitButton.interactable = false;
    }



}
