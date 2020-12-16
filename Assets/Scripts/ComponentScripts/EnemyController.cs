using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int dir;
    float sizeMult = 1;

    void Start()
    {
        dir = (Random.value<0.5f)?-1:1;
        sizeMult = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(sizeMult, sizeMult, sizeMult);
    }

    void Update()
    {
        transform.Rotate(0, dir, 0);
    }
}
