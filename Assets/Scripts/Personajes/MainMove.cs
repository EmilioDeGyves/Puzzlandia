using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainMove : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed = 3.0f;
    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
        isMoving = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetTargetPosition();
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            MoveCharacter();
        }
    }

    void SetTargetPosition()
    {
        Vector2 mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        targetPosition = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
        isMoving = true;
    }

    void MoveCharacter()
    {
        float step = moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, step));

        if ((Vector2)transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}
