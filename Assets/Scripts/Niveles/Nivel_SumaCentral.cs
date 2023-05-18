using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Nivel_SumaCentral : MonoBehaviour
{
    public GameObject doorLock;
    private int[] intAll_12 = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    private int[] izqsdsdIntAll = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

    public GameObject numberSlot1, numberSlot2;
    public Vector3 setPos1, setPos2;

    void Start()
    {
        
    }

    public void dsds()
    {
        int output = 0;
        if (int.TryParse("sdsd", out output))
        {
            int lives = output;
        }
    }

    void FixedUpdate()
    {
        if((intAll_12[1] + intAll_12[2] + intAll_12[3]) == (intAll_12[3] + intAll_12[4] + intAll_12[5]) &&
            (intAll_12[1] + intAll_12[2] + intAll_12[3]) == (intAll_12[5] + intAll_12[6] + intAll_12[7]) &&
            (intAll_12[1] + intAll_12[2] + intAll_12[3]) == (intAll_12[7] + intAll_12[8] + intAll_12[1]))
        {
            Destroy(doorLock);
        }
    }

    public void switchNumbers(GameObject _numberSlot)
    {
        if (numberSlot1 == null) { numberSlot1 = _numberSlot; setPos1 = _numberSlot.GetComponent<RectTransform>().position; }
        else
        {
            numberSlot2 = _numberSlot; setPos2 = _numberSlot.GetComponent<RectTransform>().position;


            int i = 0, i1 = 0, i2 = 0;
            while(i < 9)
            {
                if (intAll_12[i] == int.Parse(numberSlot1.name))
                { i1 = i; }
                if (intAll_12[i] == int.Parse(numberSlot2.name))
                { i2 = i; }
                i += 1;
            }
            intAll_12[i1] = int.Parse(numberSlot2.name);
            intAll_12[i2] = int.Parse(numberSlot1.name);

            _numberSlot.GetComponent<RectTransform>().position = setPos1;
            numberSlot1.GetComponent<RectTransform>().position = setPos2;

            numberSlot1 = null; numberSlot2 = null; setPos1 = Vector3.zero; setPos2 = Vector3.zero;
        }
    }
}
