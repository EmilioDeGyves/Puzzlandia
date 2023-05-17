using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConjSlots : MonoBehaviour
{
    public string conjCorrecta;
    public Rigidbody2D answerCapsule;

    [Header("Palabras")]
    public TextMeshProUGUI wordText;

    [Header("Se asigna solo, no mover")]
    public Rigidbody2D chosenConj;
    public bool isCorrect;

    void Start()
    {
        
    }

    public void ChangeConj(bool canChange)
    {
        ConjSlots ccScr = chosenConj.gameObject.GetComponent<ConjSlots>();

        if (canChange == true)
        {
            if (ccScr.wordText.text == "comerá") { chosenConj.name = "comió"; ccScr.wordText.text = "comió"; }
            else if (ccScr.wordText.text == "comió") { chosenConj.name = "comido"; ccScr.wordText.text = "comido"; }
            else if (ccScr.wordText.text == "comido") { chosenConj.name = "comerá"; ccScr.wordText.text = "comerá"; }
            else if (ccScr.wordText.text == "comerá") { chosenConj.name = "comerá"; ccScr.wordText.text = "comerá"; }

            else if (ccScr.wordText.text == "vencerá") { chosenConj.name = "venció"; ccScr.wordText.text = "venció"; }
            else if (ccScr.wordText.text == "venció") { chosenConj.name = "vencido"; ccScr.wordText.text = "vencido"; }
            else if (ccScr.wordText.text == "vencido") { chosenConj.name = "vencerá"; ccScr.wordText.text = "vencerá"; }
            else if (ccScr.wordText.text == "vencerá") { chosenConj.name = "vencer"; ccScr.wordText.text = "vencer"; }

            else if (ccScr.wordText.text == "escapó") { chosenConj.name = "escapará"; ccScr.wordText.text = "escapará"; }
            else if (ccScr.wordText.text == "escapará") { chosenConj.name = "escapado"; ccScr.wordText.text = "escapado"; }
            else if (ccScr.wordText.text == "escapado") { chosenConj.name = "escapar"; ccScr.wordText.text = "escapar"; }
            else if (ccScr.wordText.text == "escapar") { chosenConj.name = "escapó"; ccScr.wordText.text = "escapó"; }

            else if (ccScr.wordText.text == "tuvo") { chosenConj.name = "tendrá"; ccScr.wordText.text = "tendrá"; }
            else if (ccScr.wordText.text == "tendrá") { chosenConj.name = "tenía"; ccScr.wordText.text = "tenía"; }
            else if (ccScr.wordText.text == "tenía") { chosenConj.name = "tenido"; ccScr.wordText.text = "tenido"; }
            else if (ccScr.wordText.text == "tenido") { chosenConj.name = "tuvo"; ccScr.wordText.text = "tuvo"; }

            else if (ccScr.wordText.text == "olvidará") { chosenConj.name = "olvidó"; ccScr.wordText.text = "olvidó"; }
            else if (ccScr.wordText.text == "olvidó") { chosenConj.name = "olvidado"; ccScr.wordText.text = "olvidado"; }
            else if (ccScr.wordText.text == "olvidado") { chosenConj.name = "olvidaría"; ccScr.wordText.text = "olvidaría"; }
            else if (ccScr.wordText.text == "olvidaría") { chosenConj.name = "olvidará"; ccScr.wordText.text = "olvidará"; }
        }


        if (ccScr.wordText.text == conjCorrecta || gameObject.name == "CButton") { isCorrect = true; }
        else { isCorrect = false; }
    }
}
