using UnityEngine;
using System.Collections.Generic;

public class LabelSpot : MonoBehaviour
{
    public static float dropDistance = 100f;
    
    [SerializeField] private Label correctLabel;
    
    private Label currentLabel;
    private bool isCorrect = false;

    public Label GetCurrentLabel()
    {
        return currentLabel;
    }

    public void SetCurrentLabel(Label label)
    {
        currentLabel = label;

        if (currentLabel == correctLabel)
        {
            isCorrect = true;
            //Debug.Log("correct label spot");
        }
    }

    public Label GetCorrectLabel()
    {
        return correctLabel;
    }

    public bool IsCorrect()
    {
        return isCorrect;
    }
}
