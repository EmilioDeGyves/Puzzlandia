using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notas : MonoBehaviour
{
    public GameObject objectToShow;
    public string playerTag = "Player";

    private void Start()
    {
        if (objectToShow == null)
        {
            Debug.LogError("objectToShow no est� asignado en el componente ShowObjectOnOverlap.");
        }
        objectToShow.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
           
            objectToShow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            
            objectToShow.SetActive(false);
        }
    }
}
