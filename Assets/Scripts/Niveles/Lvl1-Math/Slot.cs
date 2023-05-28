using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Seed currentSeed = null;
    public bool isActive = false;

    public void AddSeed(Seed seed)
    {
        if (currentSeed == null)
        {
            currentSeed = seed;
            isActive = true;
        }
    }

    public void RemoveSeed(Seed seed)
    {
        if (seed == currentSeed)
        {
            currentSeed = null;
            isActive = false;
        }
    }

    public int GetSeedCount()
    {
        return currentSeed != null ? 1 : 0;
    }

    
}
