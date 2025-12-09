using System;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuButton : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        continueButton.onClick.AddListener(Continue);
        tutorialButton.onClick.AddListener(Tutorial);
        quitButton.onClick.AddListener(Quit);
    }

    private void Continue()
    {
        AudioManager.PlayPageTurn();
        LoadSceneManager.LoadScene(LoadSceneManager.SceneName.PuzzleSelect);
    }

    private void Tutorial()
    {
        AudioManager.PlayPageTurn();
        LoadSceneManager.LoadScene(LoadSceneManager.SceneName.Tutorial);
    }

    private void Quit()
    {
        AudioManager.PlayPageTurn();
        Application.Quit();
    }
}
