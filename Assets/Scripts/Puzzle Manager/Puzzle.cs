using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puzzle: MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private Button mapButton;
    [SerializeField] private Sprite incompleteSprite;
    [SerializeField] private Sprite completeSprite;
    [SerializeField] private bool isSolved = false;

    public Button GetMapButton()
    {
        return mapButton;
    }
    
    public bool IsSolved()
    {
        return isSolved;
    }

    public void SolvePuzzle()
    {
        isSolved = true;
    }

    public void ResetPuzzle()
    {
        isSolved = false;
    }

    public Sprite GetCompleteSprite()
    {
        return completeSprite;
    }

    public Sprite GetIncompleteSprite()
    {
        return incompleteSprite;
    }

    public void LoadScene()
    {
        //  check that the scene string is populated
        if (string.IsNullOrWhiteSpace(sceneName))
        {
            Debug.Log("sceneName string argument is blank");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }
}