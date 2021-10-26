using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 25f;
    public float PlayerMotion = 25f;

    public bool hasShield = false;

    int jumpTicks = 0;
    public int maxJump = 0;

    private void Update()
    {
        if (jumpTicks > 0)
        {
            rb.AddForce(0, PlayerMotion * Time.deltaTime, 0, ForceMode.VelocityChange);
            jumpTicks--;

            Debug.Log("jump");
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
        if (rb.velocity.x < -50) //Forward Movement
        {
            rb.velocity = new Vector3(-50, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.z < -25) //Left Movement
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -25);
        }

        if (rb.velocity.z > 25) //Right Movement
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 25);
        }
    }

    public void Jump()
    {
        jumpTicks = maxJump;
    }

    public void Restart()
    {
        rb.velocity = Vector3.zero;
    }

    public void setShield(bool shield)
    {
        hasShield = shield;
    }

    public bool getShield()
    {
        return hasShield;
    }
}