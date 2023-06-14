using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConjSlots : MonoBehaviour
{
    public string conjCorrecta;
    public Rigidbody2D answerCapsule;
    public string[] conjugacionesPosibles;

    [Header("Palabras")]
    public TextMeshProUGUI wordText;

    [Header("Se asigna solo, no mover")]
    public Rigidbody2D chosenConj;
    public bool isCorrect;

    public int conjIndx;

    void Start()
    {
        
    }

    public void ChangeConj(bool canChange)
    {
        ConjSlots ccScr = chosenConj.gameObject.GetComponent<ConjSlots>();

        if (canChange == true)
        {
            Debug.Log("Se conjugó");
            ccScr.conjIndx += 1;
            if (ccScr.conjIndx >= ccScr.conjugacionesPosibles.Length) { ccScr.conjIndx = 0; }
            if (ccScr.conjIndx <= -1) { ccScr.conjIndx = ccScr.conjugacionesPosibles.Length - 1; }
            ccScr.wordText.text = ccScr.conjugacionesPosibles[ccScr.conjIndx];
        }


        if (ccScr.wordText.text == conjCorrecta || gameObject.name == "CButton") { isCorrect = true; }
        else { isCorrect = false; }


        int cuantosCorrectos = 0;

        foreach (GameObject indObjeto in GameObject.FindGameObjectsWithTag("ArticuloObjeto"))
        {
            ConjSlots indObjScr = indObjeto.GetComponent<ConjSlots>();
            if (indObjScr.isCorrect == true)
            { cuantosCorrectos += 1; }
        }

        Debug.Log("CuantosCorrectos: " + cuantosCorrectos);
    }
}
