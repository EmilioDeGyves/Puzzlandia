using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBag : MonoBehaviour
{
    public GameObject seedPrefab;
    public Transform seedSpawnPoint;
    private GameConroller gameController;
    public GameObject seeds;

    private void Start()
    {
        gameController = FindObjectOfType<GameConroller>();
    }

    private void OnMouseDown()
    {
        // Comprobar si es posible generar una nueva semilla
        if (gameController.CanSpawnSeed())
        {
            // Crear una nueva semilla cuando se haga clic en la bolsa
            GameObject newSeed = Instantiate(seedPrefab, seedSpawnPoint.position, Quaternion.identity) as GameObject;
            newSeed.transform.parent = seeds.transform;
        }
    }

    public void DestroySeeds()
    {
        foreach (Transform child in seeds.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
