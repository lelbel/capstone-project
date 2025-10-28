using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public List<Puzzle> puzzleList;

    public PuzzleManager()
    {
        List<Puzzle> puzzleList = new List<Puzzle>();
    }

    public void AddPuzzle(Puzzle p)
    {
        puzzleList.Add(p);
    }

    public void PrintPuzzleList()
    {
        foreach (var p in puzzleList)
        {
            Debug.Log($"Puzzle Name: {p.GetName()} \n Puzzle Status: {p.PuzzleStatus()}\n");
        }
    }

}