using UnityEngine;
using UnityEngine.UI;

public class LibrarianManager : MonoBehaviour
{
    [SerializeField] private Image librarian;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private LoadSceneManager.SceneName scene;

    public void UpdateSprite(Dialogue.SpriteState state)
    {

        switch (state)

        {
            case Dialogue.SpriteState.DEFAULT:
                librarian.GetComponent<Image>().sprite = defaultSprite;
                librarian.enabled = true;
                break;

            case Dialogue.SpriteState.INVISIBLE:
                librarian.enabled = false;
                break;

            default:
                librarian.GetComponent<Image>().sprite = defaultSprite;
                librarian.enabled = true;
                break;
        }
    }
}