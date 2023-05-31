using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SinsAnts : MonoBehaviour
{
    public GameObject DoorLock;
    public TextMeshProUGUI[] palabrasTextos;
    public GameObject[] cuartos;

    public GameObject[] palabrasObj;
    private int cuartoNum;

    void Start()
    {
        cuartoNum = 1;
    }

    public void RestartSinsAnts()
    {
        cuartoNum += 1;
        foreach (GameObject cuarto in cuartos)
        {
            if(cuarto != null)
            {
                if (cuarto != cuartos[cuartoNum])
                { cuarto.SetActive(false); }
                else { cuarto.SetActive(true); }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D tri)
    {
        string triName = null; if (tri.gameObject.name != null) { triName = tri.gameObject.name; }
        string triTag = null; if (tri.gameObject.tag != null) { triTag = tri.gameObject.tag; }
        Rigidbody2D triRB = null; if (tri.transform.GetComponent<Rigidbody2D>() != null) { triRB = tri.transform.GetComponent<Rigidbody2D>(); }

        if (triName == "SlotWord0") { ChangeSinonimo(0); }
        if (triName == "SlotWord1") { ChangeSinonimo(1); }
        if (triName == "SlotWord2") { ChangeSinonimo(2); }
        if (triName == "SlotWord3") { ChangeSinonimo(3); }
        if (triName == "SlotWord4") { ChangeSinonimo(4); }
        if (triName == "SlotWord5") { ChangeSinonimo(5); }
        if (triName == "SlotWord6") { ChangeSinonimo(6); }
        if (triName == "SlotWord7") { ChangeSinonimo(7); }
    }

    public void ChangeSinonimo(int numero)
    {
        if (palabrasTextos[numero].text == "Feliz") { palabrasTextos[numero].text = "Alegre"; }
        else if (palabrasTextos[numero].text == "Alegre") { palabrasTextos[numero].text = "Triste"; }
        else if (palabrasTextos[numero].text == "Triste") { palabrasTextos[numero].text = "Contento"; }
        else if (palabrasTextos[numero].text == "Contento") { palabrasTextos[numero].text = "Feliz"; }

        if (palabrasTextos[numero].text == "Colosal") { palabrasTextos[numero].text = "Gigante"; }
        else if (palabrasTextos[numero].text == "Gigante") { palabrasTextos[numero].text = "Grande"; }
        else if (palabrasTextos[numero].text == "Grande") { palabrasTextos[numero].text = "Pequeño"; }
        else if (palabrasTextos[numero].text == "Pequeño") { palabrasTextos[numero].text = "Enorme"; }
        else if (palabrasTextos[numero].text == "Enorme") { palabrasTextos[numero].text = "Colosal"; }

        if (palabrasTextos[numero].text == "Lento") { palabrasTextos[numero].text = "Ligero"; }
        else if (palabrasTextos[numero].text == "Ligero") { palabrasTextos[numero].text = "Expedito"; }
        else if (palabrasTextos[numero].text == "Expedito") { palabrasTextos[numero].text = "Ágil"; }
        else if (palabrasTextos[numero].text == "Ágil") { palabrasTextos[numero].text = "Veloz"; }
        else if (palabrasTextos[numero].text == "Veloz") { palabrasTextos[numero].text = "Rápido"; }
        else if (palabrasTextos[numero].text == "Rápido") { palabrasTextos[numero].text = "Lento"; }

        if (palabrasTextos[numero].text == "Lindo") { palabrasTextos[numero].text = "Feo"; }
        else if (palabrasTextos[numero].text == "Feo") { palabrasTextos[numero].text = "Hermoso"; }
        else if (palabrasTextos[numero].text == "Hermoso") { palabrasTextos[numero].text = "Bello"; }
        else if (palabrasTextos[numero].text == "Bello") { palabrasTextos[numero].text = "Bonito"; }
        else if (palabrasTextos[numero].text == "Bonito") { palabrasTextos[numero].text = "Precioso"; }
        else if (palabrasTextos[numero].text == "Precioso") { palabrasTextos[numero].text = "Encantador"; }
        else if (palabrasTextos[numero].text == "Encantador") { palabrasTextos[numero].text = "Lindo"; }

        if (palabrasTextos[numero].text == "Tranquilo") { palabrasTextos[numero].text = "Calmado"; }
        else if (palabrasTextos[numero].text == "Calmado") { palabrasTextos[numero].text = "Hermoso"; }
        else if (palabrasTextos[numero].text == "Hermoso") { palabrasTextos[numero].text = "Sereno"; }
        else if (palabrasTextos[numero].text == "Sereno") { palabrasTextos[numero].text = "Nervioso"; }
        else if (palabrasTextos[numero].text == "Nervioso") { palabrasTextos[numero].text = "Sosegado"; }
        else if (palabrasTextos[numero].text == "Sosegado") { palabrasTextos[numero].text = "Precioso"; }
        else if (palabrasTextos[numero].text == "Precioso") { palabrasTextos[numero].text = "Quieto"; }
        else if (palabrasTextos[numero].text == "Quieto") { palabrasTextos[numero].text = "Tranquilo"; }

        if (palabrasTextos[numero].text == "Valiente") { palabrasTextos[numero].text = "Audaz"; }
        else if (palabrasTextos[numero].text == "Audaz") { palabrasTextos[numero].text = "Arriesgado"; }
        else if (palabrasTextos[numero].text == "Arriesgado") { palabrasTextos[numero].text = "Osado"; }
        else if (palabrasTextos[numero].text == "Osado") { palabrasTextos[numero].text = "Intrépido"; }
        else if (palabrasTextos[numero].text == "Intrépido") { palabrasTextos[numero].text = "Decidido"; }
        else if (palabrasTextos[numero].text == "Decidido") { palabrasTextos[numero].text = "Corajudo"; }
        else if (palabrasTextos[numero].text == "Corajudo") { palabrasTextos[numero].text = "Cobarde"; }
        else if (palabrasTextos[numero].text == "Cobarde") { palabrasTextos[numero].text = "Valiente"; }

        if (palabrasTextos[numero].text == "Inteligente") { palabrasTextos[numero].text = "Listo"; }
        else if (palabrasTextos[numero].text == "Listo") { palabrasTextos[numero].text = "Astuto"; }
        else if (palabrasTextos[numero].text == "Astuto") { palabrasTextos[numero].text = "Brillante"; }
        else if (palabrasTextos[numero].text == "Brillante") { palabrasTextos[numero].text = "Perspicaz"; }
        else if (palabrasTextos[numero].text == "Perspicaz") { palabrasTextos[numero].text = "Tonto"; }
        else if (palabrasTextos[numero].text == "Tonto") { palabrasTextos[numero].text = "Sagaz"; }
        else if (palabrasTextos[numero].text == "Sagaz") { palabrasTextos[numero].text = "Lúcido"; }
        else if (palabrasTextos[numero].text == "Lúcido") { palabrasTextos[numero].text = "Inteligente"; }

        if (palabrasTextos[numero].text == "Fuerte") { palabrasTextos[numero].text = "Robusto"; }
        else if (palabrasTextos[numero].text == "Robusto") { palabrasTextos[numero].text = "Resistente"; }
        else if (palabrasTextos[numero].text == "Resistente") { palabrasTextos[numero].text = "Vigoroso"; }
        else if (palabrasTextos[numero].text == "Vigoroso") { palabrasTextos[numero].text = "Sólido"; }
        else if (palabrasTextos[numero].text == "Sólido") { palabrasTextos[numero].text = "Potente"; }
        else if (palabrasTextos[numero].text == "Potente") { palabrasTextos[numero].text = "Débil"; }
        else if (palabrasTextos[numero].text == "Débil") { palabrasTextos[numero].text = "Duro"; }
        else if (palabrasTextos[numero].text == "Duro") { palabrasTextos[numero].text = "Fuerte"; }

        int cuantosBien = 0;
        if(cuartoNum == 1)
        {
            if (palabrasTextos[0].text == "Triste") { cuantosBien += 1; }
            if (palabrasTextos[1].text == "Pequeño") { cuantosBien += 1; }
            if (palabrasTextos[2].text == "Lento") { cuantosBien += 1; }
            if (palabrasTextos[3].text == "Feo") { cuantosBien += 1; }
            if (palabrasTextos[4].text == "Nervioso") { cuantosBien += 1; }
            if (palabrasTextos[5].text == "Cobarde") { cuantosBien += 1; }
            if (palabrasTextos[6].text == "Tonto") { cuantosBien += 1; }
            if (palabrasTextos[7].text == "Débil") { cuantosBien += 1; }
        }

        if (cuantosBien == 4)
        {
            foreach(GameObject palabra in palabrasObj)
            {
                palabra.SetActive(true);
            }
        }

        if (cuantosBien == 8)
        {
            DoorLock.SetActive(false);
        }
    }
}
