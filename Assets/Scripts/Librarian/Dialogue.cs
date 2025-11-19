using System;

[Serializable]
public class Dialogue
{
    public enum SpriteState
    {
        DEFAULT,
        INVISIBLE,
        VISIBLE,
    }

    public enum Name
    {
        Librarian,
        None
    }

    public Name name;
    public SpriteState currentState;
    public Sentence[] sentences;

    public SpriteState GetState()
    {
        return currentState;
    }

    public Name GetName()
    {
        return name;
    }
}