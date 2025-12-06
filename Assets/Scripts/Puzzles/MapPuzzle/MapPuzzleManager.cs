using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapPuzzleManager : MonoBehaviour
{
    //public static List<GameObject> LabelSpots;
    public static Button CheckButton;
    
    //[SerializeField] private List<GameObject> createLabelSpots;
    [SerializeField] private Button createCheckButton;

    private void Awake()
    {
        CheckButton = createCheckButton;
        CheckButton.enabled = false;
    }

    public static List<Vector3> GetLabelSpotPositions()
    {
        List<Vector3> positions = new List<Vector3>();
        
        foreach (var label in LabelSpot.LabelSpots)
        {
            positions.Add(label.transform.position);
        }
        
        return positions;
    }

    public static GameObject GetClosestLabelSpot(GameObject labelPosition)
    {
        GameObject closest = LabelSpot.LabelSpots[0];
        {
            foreach (var labelSpot in LabelSpot.LabelSpots)
            {
                float closestDistance = Vector3.Distance(labelPosition.transform.position, closest.transform.position);
                float currentDistance = Vector3.Distance(labelPosition.transform.position, labelSpot.transform.position);

                if (currentDistance < closestDistance)
                {
                    closest = labelSpot;
                }
            }
        }
        
        return closest;
    }

    //  check that all label spots have a label before enabling the check button
    public static void CanPuzzleBeSolved()
    {
        foreach (var labelSpot in LabelSpot.LabelSpots)
        {
            if (labelSpot.GetComponent<LabelSpot>().GetCurrentLabel() == null)
            {
                return;
            }
        }
        CheckButton.enabled = true;
    }

    public void CheckAnswer()
    {
        //Debug.Log("checking answer");
        foreach (var labelSpot in LabelSpot.LabelSpots)
        {
            if (!labelSpot.GetComponent<LabelSpot>().IsCorrect())
            {
                Incorrect();
                return;
            }
        }

        SolvePuzzle();
    }

    private void Incorrect()
    {
        Debug.Log("incorrect");
    }

    private void SolvePuzzle()
    {
        if (GameManager.CurrentPuzzle == null)
        {
            Debug.Log("no current puzzle selected");
            return;
        }

        GameManager.SolveCurrentPuzzle();
    }

}