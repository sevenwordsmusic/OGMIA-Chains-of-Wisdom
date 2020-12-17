using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jumpSpeed = 5;
    Rigidbody rb;
    Vector2 moveVec = new Vector2(0, 0);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = new Vector3((Input.GetAxis("Horizontal") + moveVec.x) * speed, rb.velocity.y, (Input.GetAxis("Vertical") + moveVec.y) * speed);

        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jumpSpeed, rb.velocity.z);
        }
    }

    private void OnTriggerEnter(Collider trig)
    {
        Transform trigParent = trig.transform.parent;
        if (trigParent.CompareTag("trap"))
        {
            print("Player Damaged: -" + trig.transform.parent.GetComponent<TrapSpikesController>().damage+ "hp");
        }
        else if (trigParent.CompareTag("enemy"))
        {
            print("enemy");
            Destroy(trigParent.gameObject);
        }
        else if (trigParent.CompareTag("portal"))
        {
            PortalController pController = trigParent.GetComponent<PortalController>();
            print("teleporting");
            pController.teleport();
        }
    }

    public void goRight()
    {
        moveVec.x = 1;
    }

    public void goLeft()
    {
        moveVec.x = -1;
    }

    public void goUp()
    {
        moveVec.y = 1;
    }

    public void goDown()
    {
        moveVec.y = -1;
    }

    public void stop()
    {
        moveVec.x = 0;
        moveVec.y = 0;
    }
}