using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapPuzzleManager : MonoBehaviour
{    
    [SerializeField] private List<GameObject> labelSpots;
    [SerializeField] private Button checkButton;

    private void Awake()
    {
        checkButton.enabled = false;
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

    public List<Vector3> GetLabelSpotPositions()
    {
        List<Vector3> positions = new List<Vector3>();
        
        foreach (var label in labelSpots)
        {
            positions.Add(label.transform.position);
        }
        
        return positions;
    }

    public GameObject GetClosestLabelSpot(GameObject labelPosition)
    {
        GameObject closest = labelSpots[0];
        {
            foreach (var labelSpot in labelSpots)
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
    public void CanPuzzleBeSolved()
    {
        foreach (var labelSpot in labelSpots)
        {
            if (labelSpot.GetComponent<LabelSpot>().GetCurrentLabel() == null)
            {
                return;
            }
        }
        
        checkButton.enabled = true;
    }

    public void CheckAnswer()
    {
        AudioManager.PlayPageTurn();

        foreach (var labelSpot in labelSpots)
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
        foreach (var labelSpot in labelSpots)
        {
            labelSpot.GetComponent<LabelSpot>().GetCurrentLabel().InitialPosition();
            labelSpot.GetComponent<LabelSpot>().SetCurrentLabel(null);
        }

        checkButton.enabled = false;
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

        foreach (var labelSpot in labelSpots)
        {
            var correctLabel = labelSpot.GetComponent<LabelSpot>().GetCorrectLabel();
            
            correctLabel.CompleteLabel();
            correctLabel.LockLabel();
            correctLabel.GoToPosition(labelSpot.transform.position);
        }

        checkButton.enabled = false;
    }
}