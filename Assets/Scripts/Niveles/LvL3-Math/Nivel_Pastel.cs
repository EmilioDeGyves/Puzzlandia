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
    [HideInInspector] public Image[] initialCakes;
    public RectTransform[] cakesUpRT, cakesDownRT;
    [HideInInspector] public RectTransform[] initialRT;
    public Vector3[] setCakeUpRT, setCakeDownRT;
    public TextMeshProUGUI[] playerPercentageText, correctPercentageText;
    [HideInInspector] public bool played;

    void Start()
    {
        initialCakes = new Image[7];
        initialRT = new RectTransform[7];

        valuesUp = new float[4];
        valuesDown = new float[4];

        RestartCakes();
    }

    


    public void SliceCake(Image cakeImg)
    {
        if (cakeImg.fillAmount <= 0 || cakeImg.fillAmount > 1)
        { cakeImg.fillAmount = 1; }

        string[] typeOfCake = cakeImg.name.Split('_'); //R-RedFlower

        Debug.Log(cakeImg.name.Substring(2,3));

        if (typeOfCake[0] == "BigCake" || cakeImg.name.Substring(2,3) == "Red")
        { cakeImg.fillAmount -= (1f / 6f); }
        if (typeOfCake[0] == "SmallCake" || cakeImg.name.Substring(2,3) == "Blu")
        {
            if(cakeImg.fillAmount > 0.2f)
            { cakeImg.fillAmount -= (1f / 5f); }
            if(cakeImg.fillAmount <= 0.2f)
            { cakeImg.fillAmount = 1f; }
        }

        if (cakeImg.fillAmount <= 0 || cakeImg.fillAmount > 1)
        { cakeImg.fillAmount = 1; }

        CheckSlicedCakes();
    }

    public void CheckSlicedCakes()
    {
        playerPercentage[1] = cakesUp[1].fillAmount + cakesUp[2].fillAmount + cakesUp[3].fillAmount;
        playerPercentage[2] = cakesDown[1].fillAmount + cakesDown[2].fillAmount + cakesDown[3].fillAmount;

        UpdatePlayerPercentages();
    }

    public void UpdatePlayerPercentages()
    {
        string playerPercentage1Str = "" + playerPercentage[1];
        string playerPercentage2Str = "" + playerPercentage[2];
        string correctPercentage1Srt = "" + correctPercentage[1];
        string correctPercentage2Srt = "" + correctPercentage[2];

        playerPercentageText[1].text = "" + playerPercentage1Str.Substring(0, Mathf.Clamp(playerPercentage1Str.Length, 0, 5)) + "%";
        playerPercentageText[2].text = "" + playerPercentage2Str.Substring(0, Mathf.Clamp(playerPercentage2Str.Length, 0, 5)) + "%";

        if (playerPercentage1Str == correctPercentage1Srt && playerPercentage2Str == correctPercentage2Srt)
        {
            doorLock.SetActive(false);
        }
    }

    public void RestartCakes()
    {
        if(played == true)
        {
            foreach (Image cake in cakesUp) { if (cake != null) { cake.fillAmount = 1; } }
            foreach (Image cake in cakesDown) { if (cake != null) { cake.fillAmount = 1; } }
            cakesUp[1] = initialCakes[1]; cakesUp[2] = initialCakes[2]; cakesUp[3] = initialCakes[3];
            cakesDown[1] = initialCakes[4]; cakesDown[2] = initialCakes[5]; cakesDown[3] = initialCakes[6];
            cakesUpRT[1] = initialRT[1]; cakesUpRT[2] = initialRT[2]; cakesUpRT[3] = initialRT[3];
            cakesDownRT[1] = initialRT[4]; cakesDownRT[2] = initialRT[5]; cakesDownRT[3] = initialRT[6];
            cakesUpRT[1].position = setCakeUpRT[1]; cakesUpRT[2].position = setCakeUpRT[2]; cakesUpRT[3].position = setCakeUpRT[3];
            cakesDownRT[1].position = setCakeDownRT[1]; cakesDownRT[2].position = setCakeDownRT[2]; cakesDownRT[3].position = setCakeDownRT[3];
        }

        int orden = Random.Range(1, 3 + 1);
        int ordenNew1 = orden;


        int i = 3;
        while (i > 0)
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

        string showedPer1 = "" + correctPercentage[1];
        string showedPer2 = "" + correctPercentage[2];

        correctPercentageText[1].text = "= " + showedPer1.Substring(0, Mathf.Clamp(showedPer1.Length, 0, 5)) + "%";
        correctPercentageText[2].text = "= " + showedPer2.Substring(0, Mathf.Clamp(showedPer2.Length, 0, 5)) + "%";

        CheckSlicedCakes();
        UpdatePlayerPercentages();

        setCakeUpRT[1] = cakesUpRT[1].position; setCakeUpRT[2] = cakesUpRT[2].position; setCakeUpRT[3] = cakesUpRT[3].position;
        setCakeDownRT[1] = cakesDownRT[1].position; setCakeDownRT[2] = cakesDownRT[2].position; setCakeDownRT[3] = cakesDownRT[3].position;

        // Guardar

        if(played == false)
        {
            initialCakes[1] = cakesUp[1]; initialCakes[2] = cakesUp[2]; initialCakes[3] = cakesUp[3];
            initialCakes[4] = cakesDown[1]; initialCakes[5] = cakesDown[2]; initialCakes[6] = cakesDown[3];

            initialRT[1] = cakesUpRT[1]; initialRT[2] = cakesUpRT[2]; initialRT[3] = cakesUpRT[3];
            initialRT[4] = cakesDownRT[1]; initialRT[5] = cakesDownRT[2]; initialRT[6] = cakesDownRT[3];
        }

        played = true;
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

        CheckSlicedCakes();
    }
}
