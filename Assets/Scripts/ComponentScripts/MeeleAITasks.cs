using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Panda;

[RequireComponent(typeof(EnemyController))]
public class MeeleAITasks : MonoBehaviour
{
    [Header("AI Variables")]
    public GameObject player;
    NavMeshAgent agent;
    [Tooltip("Enemy speed while chasing player")] [SerializeField] float attackSpeed = 2;
    [Tooltip("Enemy speed while fleeing")] [SerializeField] float escapeSpeed = 4;
    [Tooltip("Distance at wich enemy starts chasing the player")] [SerializeField] float detectDistance = 10;
    [Tooltip("Distance at wich enemy attacks the player")] [SerializeField] float attackDistance = 2;
    [Tooltip("Health at wich enemy starts fleeing")] [SerializeField] int escapeHealth = 999999;
    [Tooltip("Time spent fleeing before reengaging")] [SerializeField] float escapeTime = 3;

    [Tooltip("Don't change this")] [SerializeField] float attackDuration;
    [Tooltip("Time spent wating before attacking again")] [SerializeField] float attackWait = 0.8f;

    [Tooltip("Don't change this")] [SerializeField] float attackBlendDefault = 0;

    [Tooltip("Projectile damage")] public int damage = 10;

    [SerializeField] Animator animator;
    [SerializeField] PandaBehaviour pandaScript;

    EnemyController enemyController;

    float attackTimer = 0;
    bool attacking = false;
    Vector3 fleePlayerPos;
    float fleeTimer = 0;

    bool idleTrigger = false;
    public bool attackDamage = false;

    Vector3 prevPos;



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
    void prepareMove()
    {
        attackDamage = false;
        animator.SetBool("inCombat", true);
        animator.SetTrigger("move");

        GetComponent<EnemyController>().tutorialFix = false;

        agent.speed = attackSpeed;
        Task.current.Succeed();
    }

    [Task]
    void moveToPlayer()
    {
        agent.SetDestination(player.transform.position);
    }


    [Task]
    void prepareFlee()
    {
        attackDamage = false;
        animator.SetFloat("Blend", 0);
        animator.SetBool("inCombat", false);
        animator.SetTrigger("move");

        agent.speed = escapeSpeed;
        fleePlayerPos = player.transform.position;
        fleeTimer = 0;

        idleTrigger = false;

        Task.current.Succeed();
    }


    [Task]
    void fleeFromPlayer()
    {
        agent.speed = escapeSpeed;
        agent.SetDestination(transform.position + (transform.position - fleePlayerPos).normalized * (escapeSpeed + 0.1f));

        fleeTimer += Time.deltaTime;

        /*if (Vector3.Distance(prevPos, transform.position) == 0 && !idleTrigger)
        {
            print("asd");
            attackDamage = false;
            animator.SetFloat("Blend", 0);
            animator.SetBool("inCombat", false);
            animator.SetTrigger("idle");
            idleTrigger = true;
        }*/

        if (fleeTimer >= escapeTime)
        {
            reEngage = true;
            lowHealth = false;
        }

        //prevPos = transform.position;
    }


    [Task]
    void prepareAttack()
    {
        attackDamage = true;
        animator.SetFloat("Blend", attackBlendDefault);
        animator.SetBool("inCombat", true);
        animator.SetTrigger("attack");

        GetComponent<EnemyController>().tutorialFix = false;

        agent.SetDestination(transform.position);
        attackTimer = 0;
        facingPlayer = false;
        attacking = true;
        Task.current.Succeed();
    }

    [Task]
    void turnToPlayer()
    {
        Vector3 lookrotation = player.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), 3 * Time.deltaTime);
    }

    [Task]
    void attack()
    {
        if (attacking)
        {
            attacking = false;
        }
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDuration + attackWait)
        {
            Task.current.Succeed();
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        enemyController = GetComponent<EnemyController>();
        enemyController.enemyDead += enemyDead;

    }

    void enemyDead()
    {
        attackDamage = false;
        animator.SetFloat("Blend", (int)Random.Range(0, 2));
        animator.SetBool("inCombat", false);
        animator.SetTrigger("death");

        pandaScript.enabled = false;
        GetComponent<MeeleAITasks>().enabled = false;
    }

    private void Update()
    {
        if (player == null) { GameObject.FindGameObjectWithTag("Player"); }
        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (GetComponent<EnemyController>().currentHealth <= escapeHealth && !reEngage)
        {
            lowHealth = true;
            playerNear = false;
            playerDetected = false;
        }
        else if (distToPlayer < attackDistance)
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

        if (!lowHealth && !GetComponent<EnemyController>().tutorialFix)
        {
            Vector3 lookrotation = player.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), 3 * Time.deltaTime);
        }

    }
}
