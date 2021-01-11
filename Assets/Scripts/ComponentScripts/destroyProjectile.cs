using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyProjectile : MonoBehaviour
{
    GameObject toDestroy;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(toDestroy, 0.1f);
    }
}
