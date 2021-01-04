using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpikesController : MonoBehaviour
{
    private BoxCollider TriggerCollider;
    [Tooltip("Si la trampa es smart, se activará por sí misma cuando se acerque el jugador a ella. En otro caso, se activará y desactivará cada x periodo de tiempo")] [SerializeField] bool isSmart;
    [Tooltip("Si la trampa no es smart, esta variable define el tiempo en segundos entre cada iteración (activarse,esconderse) de la trampa")] [SerializeField] float cycleTime;
    [Tooltip("Si es true, los tiempos entre lanzar la trampa y esconderla serán distintos. Solo es relevante si la trampa no es smart")] [SerializeField] bool isAsymmetric;
    [Tooltip("Tiempo asimétrico que tarda en activarse la trampa, estando inactiva")][SerializeField] float asymmetricLaunchTime;
    [Tooltip("Tiempo asimétrico que tarda en desactivarse la trampa, una vez activa")][SerializeField] float asymmetricHideTime;
    [Tooltip("Daño que hará esta trampa al jugador si le alcanza")] [SerializeField] int damage = 10;
    private Animator animator;
    private float timer;
    private bool isLaunched;

    void Start()
    {
        TriggerCollider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        GetComponentInChildren<playerDamageDealer>().damageToDeal = damage;
        isLaunched = false;
        animator.SetTrigger("Hide");

        if (isSmart)
        {
            TriggerCollider.enabled = true;
        }
        else
        {
            TriggerCollider.enabled = false;
        }

        //if (isAsymmetric)
        //{
        //    timer = asymmetricLaunchTime;
        //}
        //else
        //{
        //    timer = cycleTime;
        //}
    }

    private void Update()
    {
        if (!isSmart || isLaunched)
        {
            timer += Time.deltaTime;
            

            if (isAsymmetric)
            {
                if (!isLaunched)
                {
                    if (timer >= asymmetricLaunchTime)
                    {
                        animator.SetTrigger("Launch");
                        isLaunched = true;
                        timer = 0;
                    }
                }
                else
                {
                    if (timer >= asymmetricHideTime)
                    {
                        animator.SetTrigger("Hide");
                        isLaunched = false;
                        timer = 0;
                    }
                }
            }
            else
            {
                if (timer >= cycleTime)
                {
                    if (!isLaunched)
                    {
                        animator.SetTrigger("Launch");
                        isLaunched = true;
                        timer = 0;
                    }
                    else
                    {
                        animator.SetTrigger("Hide");
                        isLaunched = false;
                        timer = 0;
                    }
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isLaunched)
        {
            animator.SetTrigger("Launch");
            isLaunched = true;
        }
    }
}
