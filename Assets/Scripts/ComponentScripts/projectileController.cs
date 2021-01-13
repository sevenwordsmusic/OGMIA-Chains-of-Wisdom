using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{

    float speed;
    Vector3 direction;
    public int damage;

    public void initProjectile(float sp, Vector3 dir, int dmg)
    {
        speed = sp;
        direction = dir;
        damage = dmg;
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + direction * speed;
    }

    public void destroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
