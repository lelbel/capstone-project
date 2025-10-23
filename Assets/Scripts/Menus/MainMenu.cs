using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //  name of the game's starting scene
    [SerializeField] private string startScene;
    [SerializeField] private string settingsScene;
    [SerializeField] private string creditsScene;
    [SerializeField] private string mainMenuScene;

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

    //  navigate player to the settings menu
    public void OpenSettings()
    {
        //  check that the scene string is populated
        if (!string.IsNullOrWhiteSpace(settingsScene))
        {
            SceneManager.LoadScene(settingsScene);
        }

        else
        {
            Debug.Log("settingsScene string argument is blank");
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
}