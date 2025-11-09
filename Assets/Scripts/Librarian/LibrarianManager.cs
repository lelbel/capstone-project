using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LibrarianManager : MonoBehaviour
{
    //  general
    [SerializeField] private Image librarian;

    //  sprites
    [SerializeField] private Sprite defaultSprite;

    public enum LibrarianState
    {
        DEFAULT,
        INVISIBLE,
        VISIBLE,
    }

    public static LibrarianState currentState = LibrarianState.DEFAULT;

    public void UpdateSprite()
    {
        switch (currentState)
        {
            case LibrarianState.DEFAULT:
                librarian.GetComponent<Image>().sprite = defaultSprite;
                break;

            case LibrarianState.INVISIBLE:
                librarian.GetComponent<Image>().sprite = null;
                break;
        }
    }
}
