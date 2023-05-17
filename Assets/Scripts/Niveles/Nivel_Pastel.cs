using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Nivel_Pastel : MonoBehaviour
{
    public float[] valuesUp, valuesDown, correctPercentage;
    public float[] playerPercentage;
    public GameObject doorLock;
    public Image[] cakesUp, cakesDown;
    public RectTransform[] cakesUpRT, cakesDownRT;
    public Vector3[] setCakeUpRT, setCakeDownRT;
    public TextMeshProUGUI[] correctPercentageText;

    void Start()
    {
        valuesUp = new float[4];
        valuesDown = new float[4];

        int orden = Random.Range(1, 3+1);
        int ordenNew1 = orden;


        int i = 3;
        while(i > 0)
        {
            if (ordenNew1 > 0)
            {
                valuesUp[i] = ((float)Random.Range(1, 6)) / 6f;

                ordenNew1 -= 1;
            }
            else
            {
                valuesUp[i] = ((float)Random.Range(1, 5)) / 5f;
            }

            i -= 1;
        }

        int ordenNew2 = orden;
        i = 3;

        while (i > 0)
        {
            if (ordenNew2 > 0)
            {
                valuesDown[i] = ((float)Random.Range(1, 5)) / 5f;

                ordenNew2 -= 1;
            }
            else
            {
                valuesDown[i] = ((float)Random.Range(1, 6)) / 6f;
            }

            i -= 1;
        }

        correctPercentage[1] = valuesUp[1] + valuesUp[2] + valuesUp[3];
        correctPercentage[2] = valuesDown[1] + valuesDown[2] + valuesDown[3];

        correctPercentageText[1].text = "=" + correctPercentage[1] + "%";
        correctPercentageText[2].text = "=" + correctPercentage[2] + "%";

        setCakeUpRT[1] = cakesUpRT[1].position; setCakeUpRT[2] = cakesUpRT[2].position; setCakeUpRT[3] = cakesUpRT[3].position;
        setCakeDownRT[1] = cakesDownRT[1].position; setCakeDownRT[2] = cakesDownRT[2].position; setCakeDownRT[3] = cakesDownRT[3].position;
    }

    void Update()
    {
        if (playerPercentage[1] == correctPercentage[1] && playerPercentage[2] == correctPercentage[2])
        {
            Destroy(doorLock);
        }
    }

    public void SliceCake(Image cakeImg)
    {
        if (cakeImg.fillAmount <= 0 || cakeImg.fillAmount > 1)
        { cakeImg.fillAmount = 1; }

        string[] typeOfCake = cakeImg.name.Split('_');

        if (typeOfCake[0] == "BigCake")
        { cakeImg.fillAmount -= (1f / 6f); }
        if (typeOfCake[0] == "SmallCake")
        {
            if(cakeImg.fillAmount > 0.2f)
            { cakeImg.fillAmount -= (1f / 5f); }
            if(cakeImg.fillAmount <= 0.2f)
            { cakeImg.fillAmount = 1f; }
        }

        if (cakeImg.fillAmount <= 0 || cakeImg.fillAmount > 1)
        { cakeImg.fillAmount = 1; }

        playerPercentage[1] = cakesUp[1].fillAmount + cakesUp[2].fillAmount + cakesUp[3].fillAmount;
        playerPercentage[2] = cakesDown[1].fillAmount + cakesDown[2].fillAmount + cakesDown[3].fillAmount;


        if (playerPercentage[1] == correctPercentage[1])
        {
            Destroy(doorLock);
        }
    }

    public void SwapCakeUpDown(int ind)
    {
        Image tempCakeUp = cakesUp[ind];
        Image tempCakeDown = cakesDown[ind];

        if (cakesUpRT[ind].position == setCakeUpRT[ind])
        { cakesUpRT[ind].position = setCakeDownRT[ind]; }
        else if (cakesUpRT[ind].position == setCakeDownRT[ind])
        { cakesUpRT[ind].position = setCakeUpRT[ind]; }

        if (cakesDownRT[ind].position == setCakeUpRT[ind])
        { cakesDownRT[ind].position = setCakeDownRT[ind]; }
        else if (cakesDownRT[ind].position == setCakeDownRT[ind])
        { cakesDownRT[ind].position = setCakeUpRT[ind]; }



        cakesUp[ind] = tempCakeDown;
        cakesDown[ind] = tempCakeUp;
    }
}
