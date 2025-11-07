using UnityEngine;

public class DontDestroyPuzzles : MonoBehaviour
{
    public static DontDestroyPuzzles Instance;

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
