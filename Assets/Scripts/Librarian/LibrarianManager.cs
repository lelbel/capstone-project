using UnityEngine;
using UnityEngine.UI;

public class LibrarianManager : MonoBehaviour
{
    [SerializeField] private Image librarian;
    [SerializeField] private Sprite defaultSprite;

    public void UpdateSprite(Sentence.SpriteState state)
    {
        librarian.enabled = true;

        switch (state)

        {
            case Sentence.SpriteState.DEFAULT:
                librarian.GetComponent<Image>().sprite = defaultSprite;
                //ebug.Log("librarian default");
                break;

            case Sentence.SpriteState.INVISIBLE:
                librarian.enabled = false;
                //Debug.Log("librarian invis");
                break;

            default:
                //Debug.Log("switch default");
                librarian.GetComponent<Image>().sprite = defaultSprite;
                break;
        }
    }
}