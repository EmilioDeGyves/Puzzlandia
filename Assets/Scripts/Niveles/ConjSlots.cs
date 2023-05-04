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
            if (ccScr.wordText.text == "comer�") { chosenConj.name = "comi�"; ccScr.wordText.text = "comi�"; }
            else if (ccScr.wordText.text == "comi�") { chosenConj.name = "comido"; ccScr.wordText.text = "comido"; }
            else if (ccScr.wordText.text == "comido") { chosenConj.name = "comer�"; ccScr.wordText.text = "comer�"; }
            else if (ccScr.wordText.text == "comer�") { chosenConj.name = "comer�"; ccScr.wordText.text = "comer�"; }

            else if (ccScr.wordText.text == "vencer�") { chosenConj.name = "venci�"; ccScr.wordText.text = "venci�"; }
            else if (ccScr.wordText.text == "venci�") { chosenConj.name = "vencido"; ccScr.wordText.text = "vencido"; }
            else if (ccScr.wordText.text == "vencido") { chosenConj.name = "vencer�"; ccScr.wordText.text = "vencer�"; }
            else if (ccScr.wordText.text == "vencer�") { chosenConj.name = "vencer"; ccScr.wordText.text = "vencer"; }

            else if (ccScr.wordText.text == "escap�") { chosenConj.name = "escapar�"; ccScr.wordText.text = "escapar�"; }
            else if (ccScr.wordText.text == "escapar�") { chosenConj.name = "escapado"; ccScr.wordText.text = "escapado"; }
            else if (ccScr.wordText.text == "escapado") { chosenConj.name = "escapar"; ccScr.wordText.text = "escapar"; }
            else if (ccScr.wordText.text == "escapar") { chosenConj.name = "escap�"; ccScr.wordText.text = "escap�"; }

            else if (ccScr.wordText.text == "tuvo") { chosenConj.name = "tendr�"; ccScr.wordText.text = "tendr�"; }
            else if (ccScr.wordText.text == "tendr�") { chosenConj.name = "ten�a"; ccScr.wordText.text = "ten�a"; }
            else if (ccScr.wordText.text == "ten�a") { chosenConj.name = "tenido"; ccScr.wordText.text = "tenido"; }
            else if (ccScr.wordText.text == "tenido") { chosenConj.name = "tuvo"; ccScr.wordText.text = "tuvo"; }

            else if (ccScr.wordText.text == "olvidar�") { chosenConj.name = "olvid�"; ccScr.wordText.text = "olvid�"; }
            else if (ccScr.wordText.text == "olvid�") { chosenConj.name = "olvidado"; ccScr.wordText.text = "olvidado"; }
            else if (ccScr.wordText.text == "olvidado") { chosenConj.name = "olvidar�a"; ccScr.wordText.text = "olvidar�a"; }
            else if (ccScr.wordText.text == "olvidar�a") { chosenConj.name = "olvidar�"; ccScr.wordText.text = "olvidar�"; }
        }


        if (ccScr.wordText.text == conjCorrecta || gameObject.name == "CButton") { isCorrect = true; }
        else { isCorrect = false; }
    }
}
