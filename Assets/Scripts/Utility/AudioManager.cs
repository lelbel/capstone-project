using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource createAudioSource;
    private static AudioSource AudioSource;
    private static AudioManager _instance;
    
    private void Awake()
    {   
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        
        AudioSource = createAudioSource;
    }

    public static void PlayPageTurn()
    {
        if (AudioSource != null)
        {
            AudioSource.Play();
        }
    }
}