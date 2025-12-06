using UnityEngine;

public class Label : MonoBehaviour
{
    private bool canMove = true;
    private Vector3 initialPosition;

    private void Start()
    {
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
        GameObject closestLabelSpot = MapPuzzleManager.GetClosestLabelSpot(this.gameObject);

        //  check that closest label spot is within snapping distance
        if (Vector3.Distance(this.transform.position, closestLabelSpot.transform.position) <= LabelSpot.dropDistance)
        {
            //  lock label, set label position to label spot position, set label spot's label
            canMove = false;
            this.transform.position = closestLabelSpot.transform.position;
            closestLabelSpot.GetComponent<LabelSpot>().SetCurrentLabel(this.GetComponent<Label>());
            
            //  check if puzzle is able to be solved
            MapPuzzleManager.CanPuzzleBeSolved();
        }

        //  go back to original position
        else
        {
            this.transform.position = initialPosition;
        }
    }
    
    
}