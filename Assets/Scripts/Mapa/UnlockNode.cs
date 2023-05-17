using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNode : MonoBehaviour
{
    public int levelNumber;

    public bool isUnlocked;

    void Start()
    {
        // Verificar si el nivel está desbloqueado
        if (levelNumber == 0)
        {
            isUnlocked = true;
        }
        else
        {
            isUnlocked = PlayerPrefs.GetInt("Level" + levelNumber + "Unlocked") == 1;
        }
        
    }

}
