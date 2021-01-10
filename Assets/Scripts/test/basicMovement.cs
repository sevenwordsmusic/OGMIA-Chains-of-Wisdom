using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMovement : MonoBehaviour
{
    public float speed = 3.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("weapon"))
        {
            var scriptReference = other.GetComponent<parentReference>();
            if(scriptReference != null)
            {
                print("damage: " + scriptReference.damage);
            }
            else
            {
                var scriptReference2 = other.GetComponent<projectileController>();
                print("damage: " + scriptReference2.damage);
                scriptReference2.destroyProjectile();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }
}
