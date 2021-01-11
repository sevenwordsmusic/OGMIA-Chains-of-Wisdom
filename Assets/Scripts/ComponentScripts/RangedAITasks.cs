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
    [SerializeField] float attackSpeed = 2;
    [SerializeField] float escapeSpeed = 4;
    [SerializeField] float detectDistance = 10;
    [SerializeField] float fleeDistance = 2;
    [SerializeField] float escapeTime = 3;

    [SerializeField] float attackDuration;
    [SerializeField] float attackDurationOffset = 0.75f;
    [SerializeField] float attackWait = 0.8f;

    [SerializeField] float projectileSpeed = 5;
    [SerializeField] int damage = 10;
    [SerializeField] GameObject projectle;
    [SerializeField] Transform spawnPoint1;
    [SerializeField] Transform spawnPoint2;

    [SerializeField] float attackBlendDefault = 0;


    [SerializeField] Animator animator;

    float attackTimer = 0;
    bool attacking = false;
    Vector3 fleePlayerPos;
    float fleeTimer = 0;
    bool isAliveAux = true;

    bool inAttackAnimation = false;


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
        animator.SetFloat("Blend", 0);
        animator.SetBool("inCombat", false);
        animator.SetTrigger("move");

        agent.speed = escapeSpeed;
        fleePlayerPos = player.transform.position;
        fleeTimer = 0;

        Task.current.Succeed();
    }


    [Task]
    void fleeFromPlayer()
    {
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
        animator.SetFloat("Blend", attackBlendDefault);
        animator.SetBool("inCombat", true);
        animator.SetTrigger("attack");

        agent.SetDestination(transform.position);
        attackTimer = 0;
        attacking = true;

        inAttackAnimation = true;

        Task.current.Succeed();
    }

    [Task]
    void attack()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDuration - attackDurationOffset && attacking)
        {
            attacking = false;
            Vector3 projSpawnPoint = (spawnPoint1.position + spawnPoint2.position) / 2;
            Vector3 targetPoint = player.transform.position;
            targetPoint.y += 1.6f;
            var proj = Instantiate(projectle, projSpawnPoint, Quaternion.identity);
            proj.GetComponent<projectileController>().initProjectile(projectileSpeed, (targetPoint - projSpawnPoint).normalized, damage);
        }

        if (attackTimer >= attackDuration + attackWait)
        {
            inAttackAnimation = false;
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
        if (!isAliveAux) { return; }
        if (player == null) { GameObject.FindGameObjectWithTag("Player"); print(player); }
        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distToPlayer < fleeDistance)
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

        if (!playerNear || inAttackAnimation)
        {
            Vector3 lookrotation = player.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), 3 * Time.deltaTime);
        }

        if (isAliveAux && GetComponent<EnemyController>().isAlive && GetComponent<EnemyController>().currentHealth <= 0)
        {
            isAliveAux = false;

            animator.SetFloat("Blend", 0);
            animator.SetBool("inCombat", false);
            animator.SetTrigger("death");
        }
    }
}
