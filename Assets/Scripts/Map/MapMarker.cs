using UnityEngine;
using System;

[Serializable]
public class MapMarker
{
    [SerializeField] private bool hasMapMarker = false;
    [SerializeField] private int x;
    [SerializeField] private int y;

    public bool HasMapMarker()
    {
        return hasMapMarker;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }
}
