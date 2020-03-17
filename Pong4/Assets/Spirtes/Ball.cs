using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private Transform ballStartPosition;

    private Rigidbody2D rb;
    private bool isMoving = false
;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isMoving)
        {
            StartBall();
        }
    }
    private void StartBall()
    {
        isMoving = true;
        Vector2 startDirection = GetRandomDirection();
        rb.velocity = moveSpeed * startDirection;
    }

    private void StopBall()
    {
        isMoving = false;
        rb.velocity = Vector2.zero;
    }
    public void ResetBall()
    {
        transform.position = ballStartPosition.position;
        StopBall();
    }
    public Vector2 GetRandomDirection()
    {
        int xDir = Random.Range(0, 2);
        xDir = xDir == 0 ? -1 : 1;
        float yDir = Random.Range(-1f, 1f);
        return new Vector2(xDir, yDir).normalized;
    }
}
