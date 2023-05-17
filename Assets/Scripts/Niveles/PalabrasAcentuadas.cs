using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PalabrasAcentuadas : MonoBehaviour
{
    public string acentuacionCorrecta;

    [HideInInspector] public Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D tri)
    {
        string triName = null; if (tri.gameObject.name != null) { triName = tri.gameObject.name; }
        string triTag = null; if (tri.gameObject.tag != null) { triTag = tri.gameObject.tag; }
        Rigidbody2D triRB = null; if (tri.transform.GetComponent<Rigidbody2D>() != null) { triRB = tri.transform.GetComponent<Rigidbody2D>(); }

        if (triName != acentuacionCorrecta)
        {
            if (triName == "Agudas" || triName == "Graves" || triName == "Esdrújulas")
            { transform.position = posicionInicial; }
        }
        else
        {
            GameObject.FindAnyObjectByType<PersonajeAcent>().GetComponent<PersonajeAcent>().SumarCorrectas();
            Destroy(this.gameObject);
        }
    }
}
