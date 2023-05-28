using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Asegúrate de agregar esta línea para usar TextMeshPro

public class Notas : MonoBehaviour
{
    public GameObject objectToShow;
    public TextMeshProUGUI targetCountText; // Usa TextMeshProUGUI en lugar de Text
    public GameConroller gameController;

    public string playerTag = "Player";


    private void Start()
    {
        if (objectToShow == null)
        {
            Debug.LogError("objectToShow no está asignado en el componente ShowObjectOnOverlap.");
        }
        objectToShow.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            // Actualizar el text

            int firstNumber = gameController.GetNumber1();
            int secondNumber = gameController.GetNumber2();

            if(firstNumber == 0 || secondNumber == 0)
            {
                targetCountText.text = "Debes activar el minigame para obtener tu pista.";
            }
            else
            {
                targetCountText.text =  firstNumber + " + " + secondNumber;
                RectTransform rectTransform = targetCountText.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(-131, 96);
                targetCountText.fontSize = 150;

            }
            
                                   

            objectToShow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            targetCountText.text = " ";
            objectToShow.SetActive(false);

        }
    }

    
}

