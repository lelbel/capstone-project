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
        TutorialLibrarian,
        LibbyCodePuzzle,
        MainMenu,
        Map,
        PuzzleNotes,
        PuzzleSelect,
        SettingsMenu
    }

    public static void LoadScene(SceneName sceneName)
    {
        if (sceneName != SceneName.None)
        {
            SceneManager.LoadScene(sceneName.ToString());
        }

        else
        {
            Debug.Log("No scene selected");
        }
    }
}
