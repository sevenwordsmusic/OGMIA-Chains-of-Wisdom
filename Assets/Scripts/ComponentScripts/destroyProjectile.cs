using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyProjectile : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.1f);
    }
}
