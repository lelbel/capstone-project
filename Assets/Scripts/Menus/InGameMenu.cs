using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private string continueScene;
    [SerializeField] private string settingsScene;
    [SerializeField] private string mainMenuScene;


    //  navigate player back to the map
    public void Continue()
    {
        //  check that the scene string is populated
        if (!string.IsNullOrWhiteSpace(continueScene))
        {
            SceneManager.LoadScene(continueScene);
        }

        else
        {
            Debug.Log("continueScene string argument is blank");
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
