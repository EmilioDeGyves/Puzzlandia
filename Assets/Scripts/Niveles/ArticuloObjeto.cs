using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticuloObjeto : MonoBehaviour
{
    public string articuloCorrecto;
    public Rigidbody2D answerCapsule;

    [Header("Se asigna solo, no mover")]
    public Rigidbody2D chosenArticulo;

    [HideInInspector] public bool isCorrect;

    public void ChecarSiCorresponde()
    {
        if(chosenArticulo.name == articuloCorrecto)
        { isCorrect = true; }
    }
}
