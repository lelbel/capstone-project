using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapPuzzleManager : MonoBehaviour
{
    private static List<GameObject> _labelSpots;
    private static Button _checkButton;
    
    [SerializeField] private List<GameObject> createLabelSpots;
    [SerializeField] private Button createCheckButton;

    private void Awake()
    {
        _checkButton = createCheckButton;
        _checkButton.enabled = false;

        _labelSpots = new List<GameObject>();

        foreach (var labelSpot in createLabelSpots)
        {
            _labelSpots.Add(labelSpot);
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
        
        foreach (var label in _labelSpots)
        {
            positions.Add(label.transform.position);
        }
        
        return positions;
    }

    public static GameObject GetClosestLabelSpot(GameObject labelPosition)
    {
        GameObject closest = _labelSpots[0];
        {
            foreach (var labelSpot in _labelSpots)
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
        foreach (var labelSpot in _labelSpots)
        {
            if (labelSpot.GetComponent<LabelSpot>().GetCurrentLabel() == null)
            {
                return;
            }
        }
        
        _checkButton.enabled = true;
    }

    public void CheckAnswer()
    {
        AudioManager.PlayPageTurn();

        foreach (var labelSpot in _labelSpots)
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
        foreach (var labelSpot in _labelSpots)
        {
            labelSpot.GetComponent<LabelSpot>().GetCurrentLabel().InitialPosition();
            labelSpot.GetComponent<LabelSpot>().SetCurrentLabel(null);
        }
    }

    private static void SolvePuzzle()
    {
        Debug.Log("correct");
        if (GameManager.CurrentPuzzle == null)
        {
            Debug.Log("no current puzzle selected");
            return;
        }
        
        GameManager.SolveCurrentPuzzle();

        foreach (var labelSpot in _labelSpots)
        {
            var correctLabel = labelSpot.GetComponent<LabelSpot>().GetCorrectLabel();
            
            correctLabel.CompleteLabel();
            correctLabel.LockLabel();
            correctLabel.GoToPosition(labelSpot.transform.position);
        }
    }
}