using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public enum SceneName
    {
        None,
        Back,
        ArrowPuzzle,
        BoatCodePuzzle,
        Credits,
        DangerCodePuzzle,
        FinalCodePuzzle,
        HowToPlay,
        InGameMenu,
        TutorialLibrarian,
        LibbyCodePuzzle,
        MainMenu,
        Map,
        PuzzleNotes,
        PuzzleSelect,
        SettingsMenu
    }

    public static SceneName currentScene = SceneName.MainMenu;
    public static SceneName lastScene;

    public static void LoadScene(SceneName sceneName)
    {
        if (sceneName == SceneName.Back)
        {
            SceneName last = lastScene;
            lastScene = currentScene;
            currentScene = last;
            SceneManager.LoadScene(last.ToString());
        }
        
        else if (sceneName != SceneName.None)
        {
            lastScene = currentScene;
            currentScene = sceneName;
            SceneManager.LoadScene(sceneName.ToString());
        }

        else
        {
            Debug.Log("No scene selected");
        }
    }
}
