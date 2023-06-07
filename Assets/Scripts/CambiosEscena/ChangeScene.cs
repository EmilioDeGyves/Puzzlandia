using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string targetScene;
    public string playerTag = "Player";
    public string spawnPointTag = "SpawnPoint";
    public bool finalNivel;
    public string LevelUnlocked;
    public int maxEntry = 3;
    public Transform[] predefinedPositions; // Array de las 4 posiciones predefinidas
    public GameObject blocker; // Objeto que bloquea la salida
    private int entryCount = 0; // Contador de las veces que el jugador entra

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            entryCount++;
            if (entryCount == maxEntry - 1)
            {
                finalNivel = true;
            }
            if (entryCount < maxEntry) // Cambia de posición durante las primeras 3 entradas
            {
                if (GameObject.FindAnyObjectByType<Nivel1Cuarto2>() != null) { GameObject.FindAnyObjectByType<Nivel1Cuarto2>().ChangeStageValues(); }
                if (GameObject.FindAnyObjectByType<FlowerController>() != null) { GameObject.FindAnyObjectByType<FlowerController>().ResetGame(); }
                if (GameObject.FindAnyObjectByType<Articulos>() != null) { GameObject.FindAnyObjectByType<Articulos>().RestartArticulos(); }
                if (GameObject.FindAnyObjectByType<Conjugaciones>() != null) { GameObject.FindAnyObjectByType<Conjugaciones>().RestartArticulos(); }
                if (GameObject.FindAnyObjectByType<PersonajeAcent>() != null) { GameObject.FindAnyObjectByType<PersonajeAcent>().RestartAcents(); }
                if (GameObject.FindAnyObjectByType<SinsAnts>() != null) { GameObject.FindAnyObjectByType<SinsAnts>().RestartSinsAnts(); }


                int randomIndex = Random.Range(0, predefinedPositions.Length);
                transform.position = predefinedPositions[randomIndex].position;
                transform.rotation = predefinedPositions[randomIndex].rotation;
                blocker.transform.position = predefinedPositions[randomIndex].position;
                blocker.transform.rotation = predefinedPositions[randomIndex].rotation;
                blocker.SetActive(true);

                
            }
            else if (entryCount == maxEntry) // En la cuarta entrada, carga la escena y desbloquea el nivel
            {
                if (finalNivel)
                {
                    UnlockNode.UnlockLevel(int.Parse(LevelUnlocked));
                    Debug.Log("desbloqueado " + LevelUnlocked);
                }

                SceneManager.LoadScene(targetScene);
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetScene)
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag(spawnPointTag);
            if (spawnPoint != null)
            {
                GameObject player = GameObject.FindGameObjectWithTag(playerTag);
                if (player != null)
                {
                    player.transform.position = spawnPoint.transform.position;
                }
            }
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
