using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] float forwardForce;

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(Vector3.back * forwardForce);
        rb.velocity = Vector3.back * forwardForce;
    }
}
