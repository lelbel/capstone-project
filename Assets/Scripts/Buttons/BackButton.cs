using UnityEngine;

namespace Utility
{
    public class BackButton : MonoBehaviour
    {
        [SerializeField] private GameObject exitNotificationPrefab;
        [SerializeField] private LoadSceneManager.SceneName scene;
        
        private GameObject notification;
        
        //  create instance of the tutorial exit notification if tutorial is active
        public void ButtonOnClick()
        {
            if (GameManager.TutorialActive)
            {
                if (this.transform.parent != null)
                {
                    GameObject canvas = this.transform.parent.transform.gameObject;
                    notification = Instantiate(exitNotificationPrefab, Vector3.zero, Quaternion.identity);
                    notification.transform.SetParent(canvas.transform, false);
                    return;
                }

                Debug.Log("tutorial exit but no canvas selected");
            }
            
            else
            {
                LoadSceneManager.LoadScene(scene);
            }
        }
    }
}