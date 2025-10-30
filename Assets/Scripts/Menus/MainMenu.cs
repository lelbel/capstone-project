using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //  name of the game's starting scene
    [SerializeField] private string startScene;
    [SerializeField] private string howToPlayScene;
    [SerializeField] private string creditsScene;
    [SerializeField] private string mainMenuScene;

    //  fix this later!!!
    //void Start()
    //{
    //    Screen.fullScreen = true;
    //}

    //  navigate player to the starting scene
    public void PlayGame()
    {
        //  check that the scene string is populated
        if (!string.IsNullOrWhiteSpace(startScene))
        {
            SceneManager.LoadScene(startScene);
        }

        else
        {
            Debug.Log("startScene string argument is blank");
        }
    }

    //  navigate player to the how to play menu
    public void OpenHowToPlay()
    {
        //  check that the scene string is populated
        if (!string.IsNullOrWhiteSpace(howToPlayScene))
        {
            SceneManager.LoadScene(howToPlayScene);
        }

        else
        {
            Debug.Log("howToPlayScene string argument is blank");
        }
    }

    //  navigate player to the credits
    public void OpenCredits()
    {
        //  check that the scene string is populated
        if (!string.IsNullOrWhiteSpace(creditsScene))
        {
            SceneManager.LoadScene(creditsScene);
        }

        else
        {
            Debug.Log("creditsScene string argument is blank");
        }
    }

    //  navigate to the main menu
    public void OpenMainMenu()
    {
        //  check that the scene string is populated
        if (!string.IsNullOrWhiteSpace(mainMenuScene))
        {
            Debug.Log("going to menu now");

            SceneManager.LoadScene(mainMenuScene);
        }

        else
        {
            Debug.Log("mainMenuScene string argument is blank");
        }
    }

    /*
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    */
}