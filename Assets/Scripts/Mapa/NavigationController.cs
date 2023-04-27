using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public NavigationNode currentNode;
    public GameObject player;
    public int velocidad;
    private void Update()
    {
        // Mover el jugador hacia el nodo actual
        player.transform.position = Vector3.MoveTowards(player.transform.position, currentNode.transform.position, velocidad*Time.deltaTime);

        // Verificar si el jugador llegó al nodo actual
        if (Vector3.Distance(player.transform.position, currentNode.transform.position) < 0.1f)
        {
            // Comprobar si se presiona alguna tecla de dirección (por ejemplo, flechas o WASD)
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                MoveToNode(Direction.Up);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                MoveToNode(Direction.Down);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                MoveToNode(Direction.Left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                MoveToNode(Direction.Right);
            }
        }
    }

    public void MoveToNode(Direction direction)
    {
        if (currentNode != null)
        {
            NavigationNode nextNode = currentNode.GetConnectedNode(direction);

            if (nextNode != null && nextNode.isUnlocked.isUnlocked)
            {
                
                    currentNode = nextNode;


            }
        }
    }

}
