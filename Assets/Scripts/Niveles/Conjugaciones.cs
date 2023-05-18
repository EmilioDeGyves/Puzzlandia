using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Conjugaciones : MonoBehaviour
{
    public GameObject doorLock;

    public float conjSpeed;
    public float minDistance;
    private Rigidbody2D conjRB;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (conjRB != null)
        {
            if (Vector2.Distance(conjRB.position, rb.position) > minDistance)
            { conjRB.MovePosition(Vector2.MoveTowards(conjRB.position, rb.position, conjSpeed)); }

        }
    }

    public void Boton()
    {
        //respuestas[0];
    }

    private void OnTriggerEnter2D(Collider2D tri)
    {
        string triName = null; if (tri.gameObject.name != null) { triName = tri.gameObject.name; }
        string triTag = null; if (tri.gameObject.tag != null) { triTag = tri.gameObject.tag; }
        Rigidbody2D triRB = null; if (tri.transform.GetComponent<Rigidbody2D>() != null) { triRB = tri.transform.GetComponent<Rigidbody2D>(); }

        if (triTag == "ArticuloPalabra")
        {
            foreach (GameObject indObjeto in GameObject.FindGameObjectsWithTag("ArticuloObjeto"))
            {
                ConjSlots indObjScr = indObjeto.GetComponent<ConjSlots>();
                if (indObjScr != null && indObjScr.chosenConj == triRB)
                { indObjScr.chosenConj = null; }
            }
            conjRB = triRB;
        }
        if (triTag == "ArticuloObjeto" && conjRB != null)
        {
            ConjSlots objScr = null;

            if (tri.gameObject.GetComponent<ConjSlots>() != null)
            {
                objScr = tri.gameObject.GetComponent<ConjSlots>();
                conjRB.position = objScr.answerCapsule.position;
                Rigidbody2D savedArticuloRB = conjRB;
                if (objScr.chosenConj != null)
                {
                    objScr.chosenConj.GetComponent<BoxCollider2D>().enabled = true;
                    conjRB = objScr.chosenConj;
                }
                else { conjRB = null; }
                objScr.chosenConj = savedArticuloRB;
                objScr.chosenConj.GetComponent<BoxCollider2D>().enabled = false;


                objScr.ChangeConj(false);
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
            ConjSlots indObjScr = indObjeto.GetComponent<ConjSlots>();
            if (indObjScr.isCorrect == true)
            { cuantosCorrectos += 1; }
        }

        if (cuantosCorrectos == cuantosArtObj)
        { Destroy(doorLock); }
    }
}
