using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    //  add text boxes for sentences in editor
    //[TextArea(3, 10)]
    public Sentence[] sentences;
}