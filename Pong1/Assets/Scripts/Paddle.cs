using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float speed;
    float hight;

    string input;
    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        hight = transform.localScale.y;
        //speed = 5f;
    }
    public void InIt(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;
      if (isRightPaddle)
        {
            //Place on the right side
            pos = new Vector2 (GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;

            input = "PaddleLeft";
        }  
      else
        {
            //Place in the left side
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "PaddleRight";



        }
        // Update this paddles Position
        transform.position = pos;
        transform.name = input;
    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
        if (transform.position.y < GameManager.bottomLeft.y + hight / 2 && move < 0)
        {
            move = 0;
        }
        if (transform.position.y > GameManager.topRight.y - hight / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate (move * Vector2.up);
    }
}
