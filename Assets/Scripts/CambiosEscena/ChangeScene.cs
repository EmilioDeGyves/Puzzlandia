using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string targetScene;
    public string playerTag = "Player";
    public string spawnPointTag = "SpawnPoint";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            SceneManager.LoadScene(targetScene);
            SceneManager.sceneLoaded += OnSceneLoaded;
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