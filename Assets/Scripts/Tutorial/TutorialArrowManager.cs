using UnityEngine;
using System.Collections.Generic;


public class TutorialArrowManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> tutorialArrows;
    private Queue<GameObject> tutorialArrowQueue;
    private GameObject currentTutorialArrow;

    void Start()
    {
        gameObject.SetActive(false);
        
        if (GameManager.tutorialActive)
        {
            Tutorial();
        }
    }

    public void Tutorial()
    {
        gameObject.SetActive(true);
        
        //  queue tutorial arrows to be displayed
        tutorialArrowQueue = new Queue<GameObject>();

        foreach (GameObject arrow in tutorialArrows)
        {
            arrow.SetActive(false);
            tutorialArrowQueue.Enqueue(arrow);
        }
    }
    
    public void NextArrow()
    {
        if (currentTutorialArrow != null)
        {
            currentTutorialArrow.SetActive(false);
        }

        if (tutorialArrowQueue.Count > 0)
        {
            currentTutorialArrow = tutorialArrowQueue.Dequeue();
            currentTutorialArrow.SetActive(true);
        }
    }

    public Queue<GameObject> GetArrowQueue()
    {
        return tutorialArrowQueue;
    }
}
    
