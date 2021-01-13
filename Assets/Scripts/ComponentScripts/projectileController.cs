using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{

    float speed;
    Vector3 direction;
    public int damage;
    public GameObject impactVFXPrefab;

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
        GameObject deathVFX = Instantiate(impactVFXPrefab, this.transform.position, this.transform.rotation, null);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        //print("COLISION");
        if (other.tag == "Player")
        {
            //print("El jugador recibe " + damage + " puntos de daño!");
            other.GetComponent<CombatController>().takeDamage(damage, 0, transform.forward, this.gameObject);
            GameObject deathVFX = Instantiate(impactVFXPrefab, this.transform.position, this.transform.rotation, null);
            Destroy(gameObject);
        }
        else if (other.tag == "enemy")
        {
            // do nothing
        }
        else
        {
            GameObject deathVFX = Instantiate(impactVFXPrefab, this.transform.position, this.transform.rotation, null);
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameObject deathVFX = Instantiate(impactVFXPrefab, this.transform.position, this.transform.rotation, null);
        Destroy(gameObject);
    }
}
