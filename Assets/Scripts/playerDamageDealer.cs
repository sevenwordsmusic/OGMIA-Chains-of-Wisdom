using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamageDealer : MonoBehaviour
{
    public int damageToDeal;
    public float damageCooldownTime = 0.66f;
    private bool canDealDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<CombatController>().takeDamage(damageToDeal, 0, Vector3.zero, this.gameObject);
            
        }
    }


    IEnumerator damageCooldown()
    {
        canDealDamage = false;
        yield return new WaitForSeconds(damageCooldownTime);
        canDealDamage = true;
    }
}
