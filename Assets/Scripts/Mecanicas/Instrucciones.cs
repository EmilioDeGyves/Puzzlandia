using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instrucciones : MonoBehaviour
{
    public GameObject IntructionsMenu; //pantalla de pausa
    private bool instuctionsON = false; //booleano para determinar la pausa

    private void Start()
    {
        Paused();
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (instuctionsON)
            {
                Resume();
            }
            
        }
    }

    public void Resume()
    {
        IntructionsMenu.SetActive(false);
        Time.timeScale = 1f;
        instuctionsON = false;
    }

    public void Paused()
    {
        IntructionsMenu.SetActive(true);
        Time.timeScale = 0f;
        instuctionsON = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
