using UnityEngine;
using UnityEngine.UI;

public class PuzzleGroupSprite : MonoBehaviour
{
    [SerializeField] private PuzzleGroup.GroupName groupName;
    [SerializeField] private Sprite completeSprite;
    [SerializeField] private Sprite incompleteSprite;

    private void Start()
    {
        if (GameManager.GetPuzzleGroup(groupName).IsPuzzleGroupCompleted())
        {
            GetComponent<Image>().sprite = completeSprite;
        }

        else
        {
            GetComponent<Image>().sprite = incompleteSprite;
        }
    }
}