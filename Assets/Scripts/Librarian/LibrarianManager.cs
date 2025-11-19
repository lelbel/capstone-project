using UnityEngine;
using UnityEngine.UI;

public class LibrarianManager : MonoBehaviour
{
    [SerializeField] private Image librarian;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private LoadSceneManager.SceneName scene;

    public void UpdateSprite(Sentence.SpriteState state)
    {
        librarian.enabled = true;

        switch (state)

        {
            case Sentence.SpriteState.DEFAULT:
                librarian.GetComponent<Image>().sprite = defaultSprite;
                break;

            case Sentence.SpriteState.INVISIBLE:
                librarian.enabled = false;
                break;

            case Sentence.SpriteState.CHANGESCENE: 
                LoadSceneManager.LoadScene(scene);
                break;

            default:
                librarian.GetComponent<Image>().sprite = defaultSprite;
                break;
        }
    }
}