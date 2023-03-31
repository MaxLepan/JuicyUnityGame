using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float sidewaysForce = 500;
    [SerializeField] float jumpForce = 10;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(new Vector3(-sidewaysForce * Time.deltaTime, 0, 0), ForceMode.VelocityChange);
        }
     
        if (Input.GetKey(KeyCode.D)){
            rb.AddForce(new Vector3(sidewaysForce * Time.deltaTime, 0, 0), ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpForce * Time.deltaTime, 0), ForceMode.Impulse);
        }

        if (rb.position.y < -2)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }

}
