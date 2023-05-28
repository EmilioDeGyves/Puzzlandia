using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public GameConroller gameController;

    private void OnMouseDown()
    {
        gameController.CheckWinCondition();
    }
}
