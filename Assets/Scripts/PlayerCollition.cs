using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollition : MonoBehaviour
{

    public PlayerMovement movement;
    public GameObject player;
    Vector3 startPos;

    private void Start()
    {
        startPos = player.transform.position;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstical")
        {
            movement.enabled = false;
            Debug.Log("Dead");
        }

        if (collisionInfo.gameObject.CompareTag("JumpPad"))
        {
            movement.Jump();
            Debug.Log("Jump");
        }

        if (collisionInfo.gameObject.CompareTag("SuperJumpPad"))
        {
            movement.Jump();
            Debug.Log("SuperJump");
        }
    }

    void Update()
    {
        if (Input.GetButtonUp("Restart"))
        {
            player.transform.position = startPos;
            player.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);

            movement.Restart();
            movement.enabled = true;

            Debug.Log("Restart");
        }     
    }
}
