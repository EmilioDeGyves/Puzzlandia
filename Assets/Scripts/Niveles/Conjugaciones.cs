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
    public GameObject[] conjugaciones;

    public GameObject[] cuartosObjects;
    public GameObject[] canvasObjects;

    private Vector2[] conjsPos;
    private Rigidbody2D conjRB;

    private Rigidbody2D rb;
    private int cuarto;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        conjsPos = new Vector2[conjugaciones.Length];
        int i = 0;
        foreach (GameObject conj in conjugaciones)
        {
            conjsPos[i] = conj.transform.position;
            i += 1;
        }
        cuarto = 1;
    }

    public void RestartConjs()
    {
        conjRB = null;
        GameObject.Find("CButton").GetComponent<ConjSlots>().chosenConj = null;
        /*foreach (GameObject indObjeto in GameObject.FindGameObjectsWithTag("ArticuloObjeto"))
        {
            indObjeto.GetComponent<ConjSlots>().chosenConj = null;
        }
        int i = 0;
        foreach (GameObject conj in conjugaciones)
        {
            conj.transform.position = conjsPos[i];
            i += 1;
        }*/
        cuartosObjects[cuarto].SetActive(false);
        canvasObjects[cuarto].SetActive(false);
        cuarto += 1;
        cuartosObjects[cuarto].SetActive(true);
        canvasObjects[cuarto].SetActive(true);
    }

    void FixedUpdate()
    {
        if (conjRB != null)
        {
            if (Vector2.Distance(conjRB.position, rb.position) > minDistance)
            { conjRB.MovePosition(Vector2.MoveTowards(conjRB.position, rb.position, conjSpeed)); }

        }
    }

    public void Nonono()
    {
        foreach (GameObject indObjeto in GameObject.FindGameObjectsWithTag("ArticuloObjeto"))
        {
            indObjeto.GetComponent<ConjSlots>().chosenConj = null;
        }
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
        int cuantosCorrectos = 0;

        foreach (GameObject indObjeto in GameObject.FindGameObjectsWithTag("ArticuloObjeto"))
        {
            ConjSlots indObjScr = indObjeto.GetComponent<ConjSlots>();
            if (indObjScr.isCorrect == true)
            { cuantosCorrectos += 1; }
        }

        if (cuantosCorrectos == 4)
        { doorLock.SetActive(false); }
    }
}
