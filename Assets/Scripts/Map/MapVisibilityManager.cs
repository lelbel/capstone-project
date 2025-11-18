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

    //  enable map canvas if player is in the map scene
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (string.Equals(SceneManager.GetActiveScene().name, mapSceneName, System.StringComparison.OrdinalIgnoreCase) && Instance != null)
        {
            canvas.SetActive(true);
            PuzzleManager.mapEnabled = true;
        }

        else
        {
            canvas.SetActive(false);
            PuzzleManager.mapEnabled = false;
        }
    }

    
}