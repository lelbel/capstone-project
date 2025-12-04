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
        Tutorial,
        Back,
        ArrowPuzzle,
        BoatCodePuzzle,
        DangerCodePuzzle,
        LibbyCodePuzzle,
        FinalCodePuzzle,
        MapPuzzle,
        Win,
        End,
        FinalPuzzle
    }

    //  set to mainMenu for debugging
    public static SceneName CurrentScene;
    public static SceneName LastScene = SceneName.MainMenu;

    public static void LoadScene(SceneName sceneName)
    {
        if (sceneName == SceneName.Back)
        {
            //  set current scene as the last scene and set the last scene as the current scene
            (CurrentScene, LastScene) = (LastScene, CurrentScene);
        }
        
        else
        {
            if (sceneName == SceneName.Tutorial)
            {
                //  set tutorial state as active
                GameManager.TutorialActive = true;
                GameManager.HasEnteredTutorial = true;
            }
            
            LastScene = CurrentScene;
            CurrentScene = sceneName;
        }
        
        SceneManager.LoadScene(CurrentScene.ToString());
    }
}
