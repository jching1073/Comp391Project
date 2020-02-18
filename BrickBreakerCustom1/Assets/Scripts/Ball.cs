using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //cofig papameter
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 8f;
    [SerializeField] AudioClip [] ballSounds;


    //state
    Vector2 paddleToBallVector;
    [SerializeField] bool hasStareted = false;

    //Cached Conponent reference
    AudioSource myAudioSocure;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSocure = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStareted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStareted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2 (xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStareted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
           myAudioSocure.PlayOneShot(clip);
        }
    }
}
