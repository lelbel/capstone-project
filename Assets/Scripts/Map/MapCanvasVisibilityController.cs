using UnityEngine;
using UnityEngine.SceneManagement;

public class MapVisibilityManager : MonoBehaviour
{
    [SerializeField] private string mapSceneName;
    [SerializeField] private GameObject canvas;
    public static MapVisibilityManager Instance;

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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(string.Equals(SceneManager.GetActiveScene().name, mapSceneName, System.StringComparison.OrdinalIgnoreCase));
        if (string.Equals(SceneManager.GetActiveScene().name, mapSceneName, System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("activate");
            Debug.Log(SceneManager.GetActiveScene().name);
            Debug.Log(mapSceneName);
            canvas.SetActive(true);
        }

        else
        {
            Debug.Log("deactivate");
            Debug.Log(SceneManager.GetActiveScene().name);
            Debug.Log(mapSceneName);
            canvas.SetActive(false);
        }
    }
}