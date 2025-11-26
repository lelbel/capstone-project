using System;
using System.Collections.Generic;

[Serializable]
public class Dialogue
{
    public string name;
    public List<Sentence> sentences;
    
    public string GetName()
    {
        return name;
    }

    public List<Sentence> GetSentences()
    {
        return sentences;
    }
}