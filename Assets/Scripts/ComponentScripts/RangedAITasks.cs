using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Panda;

[RequireComponent(typeof(EnemyController))]
public class RangedAITasks : MonoBehaviour
{
    [Header("AI Variables")]
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] float attackIddle = 1;
    [SerializeField] float attackSpeed = 2;
    [SerializeField] float escapeSpeed = 4;
    [SerializeField] float detectDistance = 10;
    [SerializeField] float attackDistance = 2;
    [SerializeField] float escapeTime = 3;

    float attackTimer = 0;
    bool attacking = false;
    Vector3 fleePlayerPos;
    float fleeTimer = 0;


    [Task]
    bool lowHealth = false;
    [Task]
    bool reEngage = false;
    [Task]
    bool playerDetected = false;
    [Task]
    bool playerNear = false;
    [Task]
    bool facingPlayer = false;

    [Task]
    void moveToPlayer()
    {
        agent.speed = attackSpeed;
        agent.SetDestination(player.transform.position);
    }


    [Task]
    void prepareFlee()
    {
        print("preparing flee");
        agent.speed = escapeSpeed;
        fleePlayerPos = player.transform.position;
        fleeTimer = 0;

        Task.current.Succeed();
    }


    [Task]
    void fleeFromPlayer()
    {
        print(agent.velocity);
        agent.speed = escapeSpeed;
        agent.SetDestination(transform.position + (transform.position - fleePlayerPos).normalized * (escapeSpeed + 0.1f));

        fleeTimer += Time.deltaTime;
        if (fleeTimer >= escapeTime)
        {
            reEngage = true;
            lowHealth = false;
        }
    }


    [Task]
    void turnToPlayer()
    {
        Vector3 lookrotation = player.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), 3 * Time.deltaTime);
    }


    [Task]
    void prepareAttack()
    {
        agent.SetDestination(transform.position);
        attackTimer = 0;
        attacking = true;
        print("preparing Attack");
        Task.current.Succeed();
    }

    [Task]
    void attack()
    {
        if (attacking)
        {
            attacking = false;
            print("enemy attack");
        }
        attackTimer += Time.deltaTime;

        if (attackTimer >= 2)
        {
            Task.current.Succeed();
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (player == null) { GameObject.FindGameObjectWithTag("Player"); print(player); }
        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distToPlayer < attackDistance)
        {
            playerNear = true;
            playerDetected = false;
        }
        else if (distToPlayer < detectDistance)
        {
            playerNear = false;
            playerDetected = true;
        }
        else
        {
            playerNear = false;
            playerDetected = false;
        }

        if (!playerNear)
        {
            Vector3 lookrotation = player.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), 3 * Time.deltaTime);
        }
    }
}
