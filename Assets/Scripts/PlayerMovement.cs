using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 25f;
    public float PlayerMotion = 25f;

    int jumpTicks = 0;

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

        if (jumpTicks > 0)
        {
            rb.AddForce(0f, PlayerMotion * Time.deltaTime, 0f, ForceMode.VelocityChange);
            jumpTicks -= 1;
        }
    }

    public void SetJumpTicks()
    {
        jumpTicks = 100;
    }
}
