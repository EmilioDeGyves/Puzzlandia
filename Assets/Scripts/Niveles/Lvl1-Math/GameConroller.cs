using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConroller : MonoBehaviour
{
    public Slot[] slots;
    private int targetCount;
    public GameObject Bush;
    public SeedBag Bag;
    private int firstRandomNumber, secondRandomNumber; // los dos números aleatorios

    private void Start()
    {
        
    }

    public bool CanSpawnSeed()
    {
        int currentSeedCount = GameObject.FindObjectsOfType<Seed>().Length;
        return currentSeedCount < slots.Length;
    }

    public void CheckWinCondition()
    {
        int totalSeedCount = 0;

        // Sumar todas las semillas en todos los slots
        foreach (Slot slot in slots)
        {
            totalSeedCount += slot.GetSeedCount();
        }

        // Comprobar si el número total de semillas es igual al objetivo
        if (totalSeedCount == targetCount)
        {
            Debug.Log("¡Ganaste!");
            Bag.DestroySeeds();
            ResetGame();
            Bush.SetActive(false);
        }
        else
        {
            Debug.Log("No es correcto, intente de nuevo.");
            Debug.Log(totalSeedCount);
        }
    }

    public void ResetGame()
    {
        // Destruye todas las semillas existentes
        Seed[] existingSeeds = GameObject.FindObjectsOfType<Seed>();
        foreach (Seed seed in existingSeeds)
        {
            Destroy(seed.gameObject);
        }

        // Genera un nuevo número objetivo de semillas
        firstRandomNumber = Random.Range(1, slots.Length - 1);
        secondRandomNumber = Random.Range(1, slots.Length - firstRandomNumber);

        targetCount = firstRandomNumber + secondRandomNumber;
        Debug.Log("Los números aleatorios son: " + firstRandomNumber + " y " + secondRandomNumber);
        Debug.Log("Número de semillas objetivo: " + targetCount);
    }

    public int GetNumber1()
    {
        return firstRandomNumber;
    }

    public int GetNumber2()
    {
        return secondRandomNumber;
    }
}
