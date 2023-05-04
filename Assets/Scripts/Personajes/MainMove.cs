using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainMove : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed = 3.0f;
    public Sprite[] playerSprites;
    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private bool isMoving, isAnimating;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        isAnimating = false;
        Vector2 mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        targetPosition = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
        isMoving = true;
    }

    void MoveCharacter()
    {
        float step = moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, step));

        int indx = 0;
        Vector2 dir = (rb.position - targetPosition) * -1;

        if(isAnimating == false)
        {
            if (Mathf.Abs(dir.y) > Mathf.Abs(dir.x) && dir.y > 0) { indx = 0; }
            if (Mathf.Abs(dir.y) > Mathf.Abs(dir.x) && dir.y < 0) { indx = 1; }
            if (Mathf.Abs(dir.y) < Mathf.Abs(dir.x) && dir.x > 0) { indx = 2; }
            if (Mathf.Abs(dir.y) < Mathf.Abs(dir.x) && dir.x < 0) { indx = 3; }
            GetComponent<SpriteRenderer>().sprite = playerSprites[indx];
            isAnimating = true;
        }
        animator.SetBool("isMoving", true);

        if ((Vector2)transform.position == targetPosition)
        {
            isMoving = false; isAnimating = false;
            animator.SetBool("isMoving", false);
        }
    }
}
