using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public enum SceneName
    {
        None,
        ArrowPuzzle,
        BoatCodePuzzle,
        Credits,
        DangerCodePuzzle,
        FinalCodePuzzle,
        HowToPlay,
        InGameMenu,
        IntroLibrarian,
        LibbyCodePuzzle,
        MainMenu,
        Map,
        PuzzleSelect,
        SettingsMenu
    }

    public static void LoadScene(SceneName sceneName)
    {
        if (sceneName == SceneName.None)
        {
            Debug.Log("No scene selected");
        }

        else
        {
            Debug.Log("Attempting to load scene");
            SceneManager.LoadScene(sceneName.ToString());
        }
    }
}
