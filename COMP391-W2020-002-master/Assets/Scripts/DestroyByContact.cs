using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //detect when other objcet collides with this object
    public void OnCollisionEnter2D(Collision2D other)

        
    {
        //if (other.gameObject.CompareTag)
        Instantiate(explosion, transform.position, transform.rotation);
        //create and position the explosion
        //delte the other pbject
        //delete this object
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
