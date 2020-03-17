using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // declare target
    public float smoothing; // camera moving speed
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() // acts last so no jerky movement
    {
        if (transform.position != target.position) // if transform position does not equal to traget position move camera last to target
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
