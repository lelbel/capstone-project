using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public enum SceneName
    {
        MainMenu,
        Map,
        PuzzleSelect,
        PuzzleNotes,
        Credits,
        InGameMenu,
        SettingsMenu,
        TutorialLibrarian,
        Back,
        ArrowPuzzle,
        BoatCodePuzzle,
        DangerCodePuzzle,
        LibbyCodePuzzle,
        FinalCodePuzzle,
    }

    //  set to mainMenu for debugging
    public static SceneName currentScene;
    public static SceneName lastScene = SceneName.MainMenu;

    public static void LoadScene(SceneName sceneName)
    {
        if (sceneName == SceneName.Back)
        {
            //  set current scene as the last scene and set the last scene as the current scene
            (currentScene, lastScene) = (lastScene, currentScene);
        }
        
        else
        {
            if (sceneName == SceneName.TutorialLibrarian)
            {
                //  set tutorial state as active
                GameManager.tutorialActive = true;
                GameManager.hasEnteredTutorial = true;
            }
            
            lastScene = currentScene;
            currentScene = sceneName;
        }
        
        SceneManager.LoadScene(currentScene.ToString());
    }
}
