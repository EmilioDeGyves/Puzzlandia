using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class UnlockNode : MonoBehaviour
{
    public int levelNumber;
    public bool isUnlocked;

    // Esta lista estática se comparte entre todas las instancias de la clase
    public static List<int> unlockedLevels = new List<int>();

    void Start()
    {
        // Verificar si el nivel está desbloqueado
        if (levelNumber == 0 || unlockedLevels.Contains(levelNumber))
        {
            isUnlocked = true;
        }
        else
        {
            isUnlocked = false;
        }
    }

    // Método para desbloquear un nivel
    public static void UnlockLevel(int levelNumber)
    {
        if (!unlockedLevels.Contains(levelNumber))
        {
            unlockedLevels.Add(levelNumber);
        }
    }
}

