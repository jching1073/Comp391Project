using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float minX, minY, maxX, maxY;
    private Rigidbody2D rBody;
    public GameObject laser;
    public GameObject LaserSpawn;
    private float timer = 0;
        public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        //get cmpoenet attachted to the component
        //rigid body 2d 
        //change velocity
        rBody.velocity = new Vector2(vert , -horiz) * speed;
        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, minX, maxX),
            Mathf.Clamp(rBody.position.y, minY, maxY));

    }
    private void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && timer > fireRate)
        {
            //If yes spawn the laser
            GameObject go = GameObject.Instantiate(laser, LaserSpawn.transform.position, LaserSpawn.transform.rotation);
            go.transform.Rotate(new Vector3(0, 0, 90));

            //reset timer
            timer = 0;
            timer += Time.deltaTime;
        }
    }
}
