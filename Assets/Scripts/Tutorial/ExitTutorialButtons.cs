using UnityEngine;

namespace Utility
{
    public class ExitTutorialButtons : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.tutorialActive = false;
            LoadSceneManager.LoadScene(LoadSceneManager.SceneName.MainMenu);
            Destroy(gameObject);
        }

        public void NoButton()
        {
            Destroy(gameObject);
        }
    }
}