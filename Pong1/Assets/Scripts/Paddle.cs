using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float speed;
    float hight;

    string input;
    bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        hight = transform.localScale.y;
        speed = 5f;
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

            input = "PaddleRight";
        }  
      else
        {
            //Place in the left side
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "PaddleLeft";



        }
        // Update this paddles Position
        transform.position = pos;
        transform.name = input;
    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        transform.Translate (move * Vector2.up);
    }
}
