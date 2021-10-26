using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollition : MonoBehaviour
{

    public PlayerMovement movement;
    public GameObject player;
    Vector3 startPos;

    public GameObject shieldPrefab;
    GameObject shield;

    List<GameObject> moved = new List<GameObject>();

    private void Start()
    {
        startPos = player.transform.position;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.gameObject.CompareTag("ShieldPickUp"))
        {
            //Move PickUp Below Level
            Vector3 temp = collisionInfo.gameObject.transform.position;
            collisionInfo.gameObject.transform.position = new Vector3(temp.x, temp.y - 5, temp.z);

            moved.Add(collisionInfo.gameObject);

            //Add Shield
            temp = player.transform.position;
            shield = Instantiate(shieldPrefab, new Vector3(temp.x, 0, temp.z), Quaternion.identity);
            shield.transform.parent = player.transform;

            movement.setShield(true);
            Debug.Log("Got Shield");
        }

        if (collisionInfo.collider.tag == "Obstical")
        {
            if (movement.getShield()) //If Player Has Shiled they keep going
            {
                //Move obsticle below scene
                Vector3 temp = collisionInfo.gameObject.transform.position;
                collisionInfo.gameObject.transform.position = new Vector3(temp.x, temp.y - 5, temp.z);
                Debug.Log("Protected");

                moved.Add(collisionInfo.gameObject);

                //Deal with Shield
                Destroy(shield);
                movement.setShield(false);
            }
            else
            { //else Fail
                movement.enabled = false;
                Debug.Log("Dead");

                restart();
            }
        }

        if (collisionInfo.gameObject.CompareTag("JumpPad"))
        {
            movement.Jump();
            Debug.Log("Jump");
        }
    }

    void Update()
    {
        if (Input.GetButtonUp("Restart"))
        {
            restart();
            Debug.Log("Restart");
        }

        if (player.transform.position.y < -5)
        {
            restart();
            Debug.Log("Fell Off");
        }
    }

    void restart()
    {

        player.transform.position = startPos;
        player.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);

        Debug.Log("Restart");
        for (int i = 0; i < moved.Count; i++)
        {
            Vector3 temp = moved[i].transform.position;
            moved[i].transform.position = new Vector3(temp.x, temp.y + 5, temp.z);
            Debug.Log("Protected");
        }

        Destroy(shield);
        movement.setShield(false);

        moved.Clear();

        movement.Restart();
        movement.enabled = true;
    }
}