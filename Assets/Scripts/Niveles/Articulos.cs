using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Articulos : MonoBehaviour
{
    public GameObject doorLock;
    public float articuloSpeed;
    public float minDistance;
    public GameObject[] articulos;
    private Vector2[] articulosPos;
    private Rigidbody2D articuloRB;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        articulosPos = new Vector2[articulos.Length];
        int i = 0;
        foreach(GameObject articulo in articulos)
        {
            articulosPos[i] = articulo.transform.position;
            i += 1;
        }
    }


    void FixedUpdate()
    {
        if(articuloRB != null)
        {
            if (Vector2.Distance(articuloRB.position, rb.position) > minDistance)
            { articuloRB.MovePosition(Vector2.MoveTowards(articuloRB.position, rb.position, articuloSpeed)); }
            
        }
    }

    public void RestartArticulos()
    {
        articuloRB = null;
        foreach (GameObject indObjeto in GameObject.FindGameObjectsWithTag("ArticuloObjeto"))
        {
            indObjeto.GetComponent<ArticuloObjeto>().chosenArticulo = null;
        }
        int i = 0;
        foreach (GameObject articulo in articulos)
        {
            articulo.transform.position = articulosPos[i];
            i += 1;
        }
    }


    private void OnTriggerEnter2D(Collider2D tri)
    {
        string triName = null; if (tri.gameObject.name != null) { triName = tri.gameObject.name; }
        string triTag = null; if (tri.gameObject.tag != null) { triTag = tri.gameObject.tag; }
        Rigidbody2D triRB = null; if (tri.transform.GetComponent<Rigidbody2D>() != null) { triRB = tri.transform.GetComponent<Rigidbody2D>(); }

        if (triTag == "ArticuloPalabra"/* && articuloRB == null*/)
        {
            foreach(GameObject indObjeto in GameObject.FindGameObjectsWithTag("ArticuloObjeto"))
            {
                ArticuloObjeto indObjScr = indObjeto.GetComponent<ArticuloObjeto>();
                if(indObjScr != null && indObjScr.chosenArticulo == triRB)
                { indObjScr.chosenArticulo = null; }
            }
            articuloRB = triRB;
        }
        if (triTag == "ArticuloObjeto" && articuloRB != null)
        {
            ArticuloObjeto objScr = null;

            if (tri.gameObject.GetComponent<ArticuloObjeto>() != null)
            {
                objScr = tri.gameObject.GetComponent<ArticuloObjeto>();
                articuloRB.position = objScr.answerCapsule.position;
                Rigidbody2D savedArticuloRB = articuloRB;
                if (objScr.chosenArticulo != null)
                {
                    objScr.chosenArticulo.GetComponent<BoxCollider2D>().enabled = true;
                    articuloRB = objScr.chosenArticulo;
                }
                else { articuloRB = null; }
                objScr.chosenArticulo = savedArticuloRB;
                objScr.chosenArticulo.GetComponent<BoxCollider2D>().enabled = false;

                objScr.ChecarSiCorresponde();
                CheckToOpenDoor();
            }
        }
    }

    public void CheckToOpenDoor()
    {
        int cuantosArtObj = GameObject.FindGameObjectsWithTag("ArticuloObjeto").Length;
        int cuantosCorrectos = 0;

        foreach (GameObject indObjeto in GameObject.FindGameObjectsWithTag("ArticuloObjeto"))
        {
            ArticuloObjeto indObjScr = indObjeto.GetComponent<ArticuloObjeto>();
            if (indObjScr.isCorrect == true)
            { cuantosCorrectos += 1; }
        }

        if (cuantosCorrectos == cuantosArtObj)
        { doorLock.SetActive(false); }
    }
}
