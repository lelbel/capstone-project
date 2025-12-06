using UnityEngine;
using System.Collections.Generic;

public class LabelSpot : MonoBehaviour
{
    public static List<GameObject> LabelSpots = new List<GameObject>();
    public static float dropDistance = 100f;
    
    [SerializeField] private Label correctLabel;
    
    private Label currentLabel;
    private bool isCorrect = false;

    private void Awake()
    {
        LabelSpots.Add(gameObject);
    }

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

    public bool IsCorrect()
    {
        return isCorrect;
    }
}
