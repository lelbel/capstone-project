using UnityEngine;

namespace Utility
{
    public class ExitTutorialButtons : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.TutorialActive = false;
            SwitchDialogueManager.EndingTutorial = false;
            LoadSceneManager.LoadScene(LoadSceneManager.SceneName.PuzzleSelect);
            Destroy(gameObject);
        }

        public void NoButton()
        {
            Destroy(gameObject);
        }
    }
}