using UnityEngine;
using UnityEngine.UI;

public class WizardPuzzleButton : MonoBehaviour
{
    [SerializeField] private Sprite inactiveSprite;
    [SerializeField] private Sprite activeSprite;
    
    void Start()
    {
        //  check if final puzzle is ready
        if (GameManager.FinalPuzzleCheck())
        {
            this.enabled = true;
            this.GetComponent<Image>().sprite =  activeSprite;
        }

        else
        {
            this.enabled = false;
            this.GetComponent<Image>().sprite =  inactiveSprite;
        }
    }

    void ButtonOnClick()
    {
        if (this.enabled)
        {
            LoadSceneManager.LoadScene(LoadSceneManager.SceneName.WizardPuzzle);
        }
    }
}
