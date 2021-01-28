using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DungeonMaster : MonoBehaviour
{
    //SINGLETON
    //DM is a singleton, accesible from anywhere in the code
    public static DungeonMaster DM;

    [Tooltip("Weight of locar room comparison")]public float localComparisonWieght = 0.75f;
    [Tooltip("Weight of global room comparison")] public float globalComparisonWieght = 0.1f;
    [Tooltip("Weight of global room comparison, adjusted by distance from each room to spawn point")] public float distanceComparisonWieght = 0.15f;

    [Tooltip("Current difficulty")] public float difficulty = 1;
    [Tooltip("Minimum difficulty that can be reached")] public float minimumDifficulty = 0.7f;
    [Tooltip("Offset in difficulty caused by dying")] public float deathDynamicOffset = 0.1f;
    [Tooltip("Maximum Offset in difficulty caused by dying")] public float deathMaxOffset = 0.65f;
    [Tooltip("Offset in difficulty caused by loosing hp")] public float hpMaxOffset = 0.65f;
    [Tooltip("How much iddle time before spawning enemy")] [SerializeField] float spawnEnemyTime = 5;
    [Tooltip("Extra time randomness")] [SerializeField] float spawnEnemyVariation = 0.5f;
    float enemyTimerAux = 0;

    [SerializeField] GameObject enemy;
    [Tooltip("Enemy spawn radius")] [SerializeField] float spawnRadius = 10;

    [Tooltip("How many times has the player died")] public int playerDeaths = 0;
    [Tooltip("How much time has the player remained inactive")] public float inactiveTimer = 0;

    [SerializeField] GameObject player;
    BehaviourTracker bTracker;

    //SINGLETON
    private void Awake()
    {
        if (DM != null)
        {
            GameObject.Destroy(DM.gameObject);
        }
        else 
        {
            DM = this; 
        }

        playerDeaths = PlayerPrefs.GetInt("playerDeaths", 0);
    }

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //bTracker = player.GetComponent<BehaviourTracker>();

        playerDeaths = PlayerPrefs.GetInt("playerDeaths", 0);

        enemyTimerAux = Random.Range(spawnEnemyTime - spawnEnemyVariation, spawnEnemyTime + spawnEnemyVariation);
    }

    //method for obtaining current dynamic diffculty (for example: 1 being normal difficulty but 0.5 being half difficulty)
    public float dynamicDifficulty()
    {
        float deathDifficulty = Mathf.Max(1-playerDeaths * deathDynamicOffset , deathMaxOffset);
        float auxDIvider = (1 / (1 - hpMaxOffset));
        float hpDifficulty = Mathf.Max(hpMaxOffset + ((float)player.GetComponent<CombatController>().health / (float)player.GetComponent<CombatController>().maxHealth) / auxDIvider, hpMaxOffset);

        return Mathf.Max((deathDifficulty + hpDifficulty) / 2, minimumDifficulty);
    }

    //activating and deadctivating timer
    public void encounteredChallanage()
    {
        inactiveTimer = 0;
    }
    public void deactivateTimer()
    {
        inactiveTimer = -99999;
    }
    public void activateTimer()
    {
        inactiveTimer = 0;
    }

    private void Update()
    {
        inactiveTimer += Time.deltaTime;
        if(inactiveTimer >= enemyTimerAux)
        {
            inactiveTimer = 0;
            enemyTimerAux = Random.Range(spawnEnemyTime - spawnEnemyVariation, spawnEnemyTime + spawnEnemyVariation);
            if (SceneManager.GetActiveScene().buildIndex > 5)
            {
                Vector2 randomVecDir = Random.insideUnitCircle;
                Vector3 positionToSpawn = new Vector3(player.transform.position.x + randomVecDir.x*spawnRadius, player.transform.position.y, player.transform.position.z + randomVecDir.y*spawnRadius);

                NavMeshHit myNavHit;

                if (NavMesh.SamplePosition(positionToSpawn, out myNavHit, 25, -1))
                {
                    transform.position = myNavHit.position;
                    var enemyInstance = Instantiate(enemy, myNavHit.position, Quaternion.identity);
                    enemyInstance.GetComponent<EnemyController>().dmAdjustParams(dynamicDifficulty());
                }
            }
            else
            {
                print("not in right scene");
            }
        }
    }
}
