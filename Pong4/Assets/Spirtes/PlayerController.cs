using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum Player { Player1, Player2}
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Player player;

    private float verticalValue;
    private float horizontalValue;

    private Rigidbody2D ridgidbody;

    private string vertical;
    private string horizontal;

    // Start is called before the first frame update
    void Awake()
    {
        ridgidbody = GetComponent<Rigidbody2D>();
        if (player == Player.Player1)
        {
            vertical = "Vertical";
            horizontal = "Horizontal";
        }else if (player == Player.Player2)
        {
            vertical = "VerticalP2";
            horizontal = "HorizontalP2";
        }
    }

    // Update is called once per frame
    void Update()
    {
        verticalValue = Input.GetAxis(vertical);
        horizontalValue = Input.GetAxis(horizontal);
    }

    private void FixedUpdate()
    {
        ridgidbody.velocity = new Vector2(ridgidbody.velocity.x, verticalValue * moveSpeed);
    }
}
