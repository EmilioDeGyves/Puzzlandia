using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PersonajeAcent : MonoBehaviour
{
    public GameObject DoorLock;

    public int respuestasTotales;
    public GameObject[] cuartos;
    [HideInInspector] public int cuantasCorrectas;
    private int cuartoNum;


    void Start()
    {
        cuartos[1].SetActive(true);
        cuartoNum = 1;
    }

    // Update is called once per frame
    public void RestartAcents()
    {
        cuantasCorrectas = 0;
        cuartoNum += 1;
        cuartos[cuartoNum].SetActive(true);
    }

    public void SumarCorrectas()
    {
        cuantasCorrectas += 1;
        if (cuantasCorrectas == respuestasTotales)
        { DoorLock.SetActive(false); }
    }
}
