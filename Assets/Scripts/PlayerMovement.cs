using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 25f;
    public float PlayerMotion = 25f;

    int jumpTicks = 0;
    public int maxJump = 0;

    private void Update()
    {
        if (jumpTicks > 0) {
            rb.AddForce(0, PlayerMotion * Time.deltaTime, 0, ForceMode.VelocityChange);
            jumpTicks--;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(-Speed, 0, 0 * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(0, 0, PlayerMotion * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(0, 0, -PlayerMotion * Time.deltaTime, ForceMode.VelocityChange);
        }


    //Clamp
        if(Speed > 50)
        {
            rb.velocity = new Vector3(50, rb.velocity.y, rb.velocity.z); 
        }
    }

    public void Jump()
    {
        jumpTicks = maxJump;
    }

    public void SuperJump()
    {
        jumpTicks = maxJump * 3;
    }

    public void Restart()
    {
        rb.velocity = Vector3.zero;
    }
}
