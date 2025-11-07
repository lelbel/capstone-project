using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMapCanvas : MonoBehaviour
{
    public static DontDestroyMapCanvas Instance;

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
}