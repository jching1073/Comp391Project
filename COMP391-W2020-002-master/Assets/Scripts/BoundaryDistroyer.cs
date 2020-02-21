using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDistroyer : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        // Destry The other Object
        Destroy(other.gameObject);
    }
}
