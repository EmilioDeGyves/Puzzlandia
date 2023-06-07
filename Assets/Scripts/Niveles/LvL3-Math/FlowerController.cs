using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
    public Row[] rows;
    public GameObject DoorLock;
    public void checkButton()
    {
        int contador = 0;
        foreach (Row row in rows)
        {
            if (row.checkRow())
            {
                contador += 1;
            }
            
        }
        if(contador == rows.Length)
        {
            DoorLock.SetActive(false);
        }
    }
     
    public void ResetGame()
    {
        foreach (Row row in rows)
        {
            row.resetRow();
        }
    }
}
