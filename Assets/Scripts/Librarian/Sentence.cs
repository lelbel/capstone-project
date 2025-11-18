using System;

[Serializable]
public class Sentence
{
    public string text;

    public enum SpriteState
    {
        DEFAULT,
        INVISIBLE,
        VISIBLE,
    }

    public SpriteState currentState = SpriteState.INVISIBLE;

    public string GetText()
    {
        return text;
    }

    public SpriteState GetState()
    {
        return currentState;
    }
}