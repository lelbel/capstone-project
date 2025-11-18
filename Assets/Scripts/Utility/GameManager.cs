using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static List<Puzzle> currentPuzzleGroup;
    public static Puzzle currentPuzzle;

    public static bool IsCurrentPuzzleSolved()
    {
        return currentPuzzle.IsSolved();
    }

    public static void SolveCurrentPuzzle()
    {
        currentPuzzle.SolvePuzzle();
    }
}
