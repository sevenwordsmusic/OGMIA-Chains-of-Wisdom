using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTrapController : MonoBehaviour
{
    private BoxCollider TriggerCollider;
    [Tooltip("Si la trampa es smart, se activará por sí misma cuando se acerque el jugador a ella. En otro caso, se activará y desactivará cada x periodo de tiempo")] [SerializeField] bool isSmart;
    [SerializeField] bool isSemiAuto;
    [SerializeField] float semiAutoTimer = 3;
    [Tooltip("Si la trampa es smart, esta variable define el espacio de tiempo minimo que pasará entre cada activación posible")][SerializeField] float cooldownTime = 3;
    [Tooltip("Define la velocidad a la que se moverá la trampa, el número base es 1, y el doble de velocidad sería 2")] [SerializeField] float speed;
    [Tooltip("Daño que hará esta trampa al jugador si le alcanza")] [SerializeField] int damage = 50;
    private Animator animator;
    private float timer;
    private bool canLaunch;

    void Start()
    {
        TriggerCollider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        GetComponentInChildren<playerDamageDealer>().damageToDeal = damage;
        canLaunch = true;

        if (!isSmart && !isSemiAuto)
        {
            animator.SetTrigger("Auto");
            TriggerCollider.enabled = false;
        }
        else if (isSmart)
        {
            TriggerCollider.enabled = true;
        }

        if(isSemiAuto)
        {
            timer = semiAutoTimer;
        }

        animator.SetFloat("speedMultiplier", speed);
    }

    private void Update()
    {
        if(isSemiAuto)
        {
            timer += Time.deltaTime;

            if(timer >= semiAutoTimer)
            {
                animator.SetTrigger("Launch");
                timer = 0;
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canLaunch)
        {
            animator.SetTrigger("Launch");
            StartCoroutine(launchCooldown());
        }
    }

    IEnumerator launchCooldown()
    {
        canLaunch = false;
        yield return new WaitForSeconds(cooldownTime);
        canLaunch = true;
    }
}
