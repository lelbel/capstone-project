using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public string Name;
    public bool IsSolved;

    //  constructor for puzzle object
    public Puzzle(string name)
    {
        this.name = name;
        this.IsSolved = false;
    }

    //  set puzzle status as complete
    public void CompletePuzzle()
    {
        this.IsSolved = true;
    }

    //  get puzzle name
    public string GetName()
    {
        return this.Name;
    }

    //  set puzzle name
    public void SetName(string name)
    {
        this.Name = name;
    }

    //  return the solved status of the puzzle
    public bool PuzzleStatus()
    {
        return this.IsSolved;
    }
}