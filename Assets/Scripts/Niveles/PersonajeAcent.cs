using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PersonajeAcent : MonoBehaviour
{
    public GameObject DoorLock;

    public int respuestasTotales;
    [HideInInspector] public int cuantasCorrectas;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SumarCorrectas()
    {
        cuantasCorrectas += 1;
        if (cuantasCorrectas == respuestasTotales)
        { Destroy(DoorLock); }
    }
}
