using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;

public class MapPuzzleManager : MonoBehaviour
{
    public static List<GameObject> LabelSpots;
    public static Button CheckButton;
    
    [SerializeField] private List<GameObject> createLabelSpots;
    [SerializeField] private Button createCheckButton;

    private void Awake()
    {
        CheckButton = createCheckButton;
        CheckButton.enabled = false;

        LabelSpots = new List<GameObject>();

        foreach (var labelSpot in createLabelSpots)
        {
            LabelSpots.Add(labelSpot);
        }
    }

    private void Start()
    {
        if (GameManager.CurrentPuzzle == null)
        {
            Debug.Log("no active puzzle");
            return;
        }

        if (GameManager.CurrentPuzzle.IsSolved())
        {
            SolvePuzzle();
        }
    }

    public static List<Vector3> GetLabelSpotPositions()
    {
        List<Vector3> positions = new List<Vector3>();
        
        foreach (var label in LabelSpots)
        {
            positions.Add(label.transform.position);
        }
        
        return positions;
    }

    public static GameObject GetClosestLabelSpot(GameObject labelPosition)
    {
        GameObject closest = LabelSpots[0];
        {
            foreach (var labelSpot in LabelSpots)
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
        foreach (var labelSpot in LabelSpots)
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
        foreach (var labelSpot in LabelSpots)
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
        foreach (var labelSpot in LabelSpots)
        {
            labelSpot.GetComponent<LabelSpot>().GetCurrentLabel().InitialPosition();
            labelSpot.GetComponent<LabelSpot>().SetCurrentLabel(null);
        }

    }

    private void SolvePuzzle()
    {
        Debug.Log("correct");
        if (GameManager.CurrentPuzzle == null)
        {
            Debug.Log("no current puzzle selected");
            return;
        }
        
        GameManager.SolveCurrentPuzzle();

        foreach (var labelSpot in LabelSpots)
        {
            var correctLabel = labelSpot.GetComponent<LabelSpot>().GetCorrectLabel();
            
            correctLabel.CompleteLabel();
            correctLabel.LockLabel();
            correctLabel.GoToPosition(labelSpot.transform.position);
        }
        
        
    }

}