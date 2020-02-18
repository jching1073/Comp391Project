using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;
    public Transform powerUp;
    // Start is called before the first frame update
    void Start()
    {
        // get component
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;   
        }
        if (inPlay == false)
        {
            transform.position = paddle.position;
           
        }
        if (Input.GetButtonDown("Jump") && !inPlay) 
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }
    //Trigger Collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bottom"))
        {
            Debug.Log("Ball left screen");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }
    // Collision Collider
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("BrickRed"))
        {
           int randChance = Random.Range(1, 101);
            if (randChance < 50)
            {
                Instantiate (powerUp, other.transform.position, other.transform.rotation);
            }
            //Particle system
            Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.0f);

            //Distroy brick on conatct
            gm.UpdateScore(other.gameObject.GetComponent<BrickScript>().points);
            gm.UpdateNumberOfBricks();
            Destroy(other.gameObject);
        }
    }
    
}
