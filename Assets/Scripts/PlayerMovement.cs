using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public bool moveLeft = false;
    public bool moveRight = false;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        if (Input.GetKey("a"))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }

        //add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (moveLeft)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (moveRight)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        
        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
