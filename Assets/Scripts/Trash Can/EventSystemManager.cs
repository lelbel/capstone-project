using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EventSystemManager : MonoBehaviour
{
    public static EventSystemManager Instance;
    void Awake()
    {        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //  enable map canvas if player is in the map scene
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("event system manager start");
        if (FindAnyObjectByType<EventSystem>() == null)
        {
            Debug.Log("found no event system");
            GameObject eventSystem = new("EventSystem");
            eventSystem.AddComponent<EventSystem>();

            eventSystem.AddComponent<StandaloneInputModule>();
        }   
    }   
}