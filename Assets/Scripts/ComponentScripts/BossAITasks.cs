using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Panda;

[RequireComponent(typeof(EnemyController))]
public class BossAITasks : MonoBehaviour
{
    [Header("AI Variables")]
    public GameObject player;
    NavMeshAgent agent;
    [SerializeField] float attackSpeed = 2;
    [SerializeField] float escapeSpeed = 4;
    [SerializeField] float detectDistance = 10;
    [SerializeField] float attackDistance = 2;
    [SerializeField] int escapeHealth = 999999;
    [SerializeField] float escapeTime = 3;

    int chosenAttack = 0;
    [SerializeField] List<float> attackDuration;
    [SerializeField] float attackWait = 0.8f;

    [SerializeField] float attackBlendDefault = 0;

    bool firstAttack = true;

    [SerializeField] GameObject weapon;

    public int damage = 10;

    [SerializeField] Animator animator;

    float attackTimer = 0;
    bool attacking = false;
    Vector3 fleePlayerPos;
    float fleeTimer = 0;

    bool idleTrigger = false;
    public bool attackDamage = false;
    bool isAliveAux = true;

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
        bool specialAttack = Random.value > 0.8f;
        if (specialAttack || firstAttack)
        {
            firstAttack = false;
            chosenAttack = 2;
            weapon.GetComponent<parentReference>().deadly = true;

            attackDamage = true;
            animator.SetFloat("Blend", 0);
            animator.SetBool("inCombat", true);
            animator.SetTrigger("special");
        }
        else
        {
            chosenAttack = Random.Range(0, 2);
            weapon.GetComponent<parentReference>().deadly = true;

            attackDamage = true;
            animator.SetFloat("Blend", chosenAttack);
            animator.SetBool("inCombat", true);
            animator.SetTrigger("attack");
        }

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

        if (attackTimer >= attackDuration[chosenAttack] + attackWait)
        {
            if(chosenAttack == 2)
            {
                var trySpawnEnemies = GetComponent<EnemySpawner>();
                if(trySpawnEnemies != null)
                {
                    trySpawnEnemies.spawnENemies();
                }
            }
            chosenAttack = Random.Range(0, 2);
            Task.current.Succeed();
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
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

        if (!lowHealth)
        {
            Vector3 lookrotation = player.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), 3 * Time.deltaTime);
        }

        if(isAliveAux && GetComponent<EnemyController>().isAlive && GetComponent<EnemyController>().currentHealth <= 0)
        {
            isAliveAux = false;

            attackDamage = false;
            animator.SetFloat("Blend", 0);
            animator.SetBool("inCombat", false);
            animator.SetTrigger("death");
        }

    }
}
