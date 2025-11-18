using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string MapSceneName = "Map";

    public static GameManager Instance;

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

    public static void LoadScene(string scene)
    {
        //Debug.Log($"Loading Scene: {scene}");

        //  check that the scene string is populated
        if (string.IsNullOrWhiteSpace(scene))
        {
            Debug.Log("sceneName string argument is blank");
            return;
        }

        SceneManager.LoadScene(scene);
    }
}
