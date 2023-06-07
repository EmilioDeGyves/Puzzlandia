using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Row : MonoBehaviour
{
    public Flower FlowerR;
    public Flower FlowerB;
    public TextMeshProUGUI goalText;
    
    private int Res;
    private int resIndx;
    int[] posArr = { 1, 2, 3, 4, 5, 6, 8, 10, 12, 15, 20, 30 };

    void Start()
    {
        resIndx = Random.Range(0, posArr.Length);
        Res = posArr[resIndx];
        goalText.text = Res.ToString();
    }
    public bool checkRow()
    {
        if (playerRes() == Res)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int playerRes()
    {
        return FlowerR.petalCount * FlowerB.petalCount;
    }
    

    public void resetRow()
    {
        resIndx = Random.Range(0, posArr.Length);
        Res = posArr[resIndx];
        goalText.text = Res.ToString();
    }

}
