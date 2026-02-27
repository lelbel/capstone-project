using TMPro;
using UnityEngine;

//  multiple labels can be dragged onto the same spot
public class Label : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private bool canMove = true;
    private Vector3 initialPosition;
    private MapPuzzleManager mapPuzzleManager;

    private void Start()
    {
        mapPuzzleManager = FindFirstObjectByType<MapPuzzleManager>();
        initialPosition = this.transform.position;
    }

    public void DragLabel()
    {
        if (canMove)
        {
            this.transform.position = Input.mousePosition;
        }
    }

    //  check if label is within the distance of any of the label spots
    public void DropLabel()
    {
        //  get closest label spot
        GameObject closestLabelSpot = mapPuzzleManager.GetClosestLabelSpot(this.gameObject);

        //  check that closest label spot is within snapping distance
        if (Vector3.Distance(this.transform.position, closestLabelSpot.transform.position) <= LabelSpot.dropDistance)
        {
            //  lock label, set label position to label spot position, set label spot's label
            //canMove = false;
            this.transform.position = closestLabelSpot.transform.position;
            closestLabelSpot.GetComponent<LabelSpot>().SetCurrentLabel(this.GetComponent<Label>());
            
            //  check if puzzle is able to be solved
            mapPuzzleManager.CanPuzzleBeSolved();
        }

        //  go back to original position
        else
        {
            this.transform.position = initialPosition;
        }
    }

    public void InitialPosition()
    {
        this.transform.position = initialPosition;
    }

    public void CompleteLabel()
    {
        text.color = Color.white;
    }

    public void GoToPosition(Vector3 position)
    {
        this.transform.position = position;
    }

    public void LockLabel()
    {
        canMove = false;
    }

}