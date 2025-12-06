using System;
using System.Collections.Generic;

[Serializable]
public class Sentence
{
    public string text;
    public List<TutorialDialogueManager.Actions> actions;
}