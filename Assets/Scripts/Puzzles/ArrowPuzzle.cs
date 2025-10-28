using System.Runtime.CompilerServices;
using UnityEngine;

public class ArrowPuzzle : MonoBehaviour
{
    private int[] arrows;
    private int i = 0;
    private int puzzleLength = 5;

    void Start()
    {
        arrows = new int[puzzleLength];
    }

    // for arrow directions, 0 is no value, 1 left and 2 is right
    public void EnterArrow(int arr)
    {
        Debug.Log($"Arg received: {arr}");
        //  argument is not a 0 or 1
        if (arr != 1 && arr != 2)
        {
            Debug.Log("Incorrect argument for EnterArrow(). Please enter a 1 or a 2");
            //Debug.Log($"Arg value: {arr}");
            //Debug.Log($"Arg type: {arr.GetType()}");
            return;
        }

        //  enter left arrow
        if (arr == 1)
        {
            EnterLeftArrow();
        }

        //  enter right arrow
        else if (arr == 2)
        {
            EnterRightArrow();
        }

        //  check at the end of arrow entry if final arrow has been placed
        if (i == puzzleLength)
        {
            Debug.Log("Entry full");
            EntryFull();
        }

    }

    //  add left arrow to the array
    public void EnterLeftArrow()
    {
        arrows[i] = 1;
        PrintArrowList();
        i++;
    }

    //  add right arrow to the array
    public void EnterRightArrow()
    {
        arrows[i] = 2;
        PrintArrowList();
        i++;
    }

    //  return the arrow value at a specified index
    public int GetArrow(int index)
    {
        return arrows[index];
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
        i = 0;
    }

    public void PrintArrowList()
    {
        int len = 0;
        Debug.Log("Current List");
        foreach (int arr in arrows)
        {
            Debug.Log(arr);
            len++;
        }
        Debug.Log($"Length: {len}");
    }
}
