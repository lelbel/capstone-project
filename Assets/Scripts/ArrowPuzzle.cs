using UnityEngine;

public class ArrowPuzzle : MonoBehaviour
{
    public int[] arrows;
    public int counter;
    public int puzzleLength = 3;

    void Start()
    {
        ResetArrowList();
    }

    void Update()
    {

    }

    // for arrow directions, 0 is left and 1 is right
    public void EnterArrow(int arr)
    {
        //  argument is not a 0 or 1
        if (arr != 0 || arr != 1)
        {
            Debug.Log("Incorrect argument for EnterArrow(). Please enter a 0 or a 1");
            return;
        }

        //  check if arrow entry has been exceeded
        if (counter > puzzleLength)
        {
            Debug.Log("Entry full");
            EntryFull();
        }

        //  enter left arrow
        if (arr == 0)
        {
            Debug.Log("Received left arrow");
            EnterLeftArrow();
        }

        //  enter right arrow
        else if (arr == 1)
        {
            Debug.Log("Received right arrow");
            EnterRightArrow();
        }

    }

    //  add left arrow to the array
    public void EnterLeftArrow()
    {
        Debug.Log("Entering left arrow");
        arrows[counter] = 0;
        counter++;
        Debug.Log($"Updated array: {arrows}");
    }

    //  add right arrow to the array
    public void EnterRightArrow()
    {
        Debug.Log("Entering right arrow");
        arrows[counter] = 0;
        counter++;
        Debug.Log($"Updated array: {arrows}");
    }

    //  player enters the final arrow space left and the combination is wrong
    //  should have some sort of visual effect then reset the arrow list
    public void EntryFull()
    {
        ResetArrowList();
    }

    //  reset array
    public void ResetArrowList()
    {
        arrows = new int[puzzleLength];
        counter = 0;
    }
}
