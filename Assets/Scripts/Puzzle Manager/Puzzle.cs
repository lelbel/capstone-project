using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puzzle: MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private Button mapButton;
    [SerializeField] private bool isSolved;
    [SerializeField] private Sprite incompleteSprite;
    [SerializeField] private Sprite completeSprite;

    public string GetSceneName()
    {
        return sceneName;
    }

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

    public void UpdateSprite(Sprite spr)
    {
        mapButton.GetComponent<Image>().sprite = spr;
    }

    public void LoadScene()
    {
        Debug.Log($"Loading Scene: {sceneName}");

        //  check that the scene string is populated
        if (string.IsNullOrWhiteSpace(sceneName))
        {
            Debug.Log("sceneName string argument is blank");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }

    public Sprite GetCompleteSprite()
    {
        return completeSprite;
    }

    public Sprite GetIncompleteSprite()
    {
        return incompleteSprite;
    }
}
