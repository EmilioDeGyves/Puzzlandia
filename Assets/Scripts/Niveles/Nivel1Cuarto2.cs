using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nivel1Cuarto2 : MonoBehaviour
{
    [Header("mainLevelCode")]
    public int[] playerAnswers;
    public int[] correctAnswers;
    public TextMeshProUGUI[] answers;
    public TextMeshProUGUI[] results;
    public GameObject doorLock;

    [Header("playerCode")]
    public int selectedSlot;
    public GameObject[] answerSlots;

    void Start()
    {
        answerSlots = GameObject.FindGameObjectsWithTag("NumberSlots");

        correctAnswers[4] = Random.Range(1, 3 + 1);
        correctAnswers[3] = correctAnswers[4] + Random.Range(1, 5 + 1);
        correctAnswers[1] = Random.Range(1, 6 + 1);
        correctAnswers[2] = Random.Range(1, 6 + 1);

        results[1].text = "=" + (correctAnswers[1] + correctAnswers[2]);
        results[2].text = "=" + (correctAnswers[3] - correctAnswers[4]);
        results[3].text = "" + (correctAnswers[1] + correctAnswers[3]);
        results[4].text = "" + (correctAnswers[2] + correctAnswers[4]);

    }

    void FixedUpdate()
    {
        selectedSlot = getClosesNumberSlot();
    }

    public void NumberButton(int amount)
    {
        if((playerAnswers[selectedSlot] > 0 && amount == -1) || amount == 1)
        {
            playerAnswers[selectedSlot] += amount;
            answers[selectedSlot].text = "" + playerAnswers[selectedSlot];

            if(playerAnswers[1] == correctAnswers[1] &&
                playerAnswers[2] == correctAnswers[2] &&
                playerAnswers[3] == correctAnswers[3] &&
                playerAnswers[4] == correctAnswers[4])
            {
                Destroy(doorLock);
            }
        }
    }

    public int getClosesNumberSlot()
    {
        float closestDistance = Mathf.Infinity;
        GameObject trans = null;

        foreach (GameObject nS in answerSlots)
        {
            float currentDistance;
            currentDistance = Vector2.Distance(transform.position, nS.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = nS;
            }
        }

        int closestNumberSlot = 0;
        if (trans.name == "Slot_1") { closestNumberSlot = 1; }
        if (trans.name == "Slot_2") { closestNumberSlot = 2; }
        if (trans.name == "Slot_3") { closestNumberSlot = 3; }
        if (trans.name == "Slot_4") { closestNumberSlot = 4; }

        return closestNumberSlot;
    }
}
