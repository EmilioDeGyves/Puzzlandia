using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapEvent : MonoBehaviour
{
    public string eventName;
    public bool isCompleted = false;
    public LayerMask playerLayer;
    public string scene;
    private bool colide = false;
    public void CompleteEvent()
    {
        isCompleted = true;
        // Cambia la apariencia del evento completado (por ejemplo, cambiar el color, hacerlo transparente, etc.).
        // Puedes personalizar esto según tus necesidades.
    }
    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.gameObject)
        {
           
            colide = true;
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject)
        {

            colide = false;

        }
    }
    private void OnMouseDown()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, 0.1f, playerLayer);

        if (playerCollider != null && !isCompleted && colide)
        {
            // Lanza el combate o evento aquí
            SceneManager.LoadScene(scene);

            CompleteEvent();
        }
    }
}
