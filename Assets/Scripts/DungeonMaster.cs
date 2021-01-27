using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DungeonMaster : MonoBehaviour
{
    //SINGLETON
    public static DungeonMaster DM;


    public float difficulty = 1;
    public float minimumDifficulty = 0.7f;
    public float deathDynamicOffset = 0.1f;
    public float deathMaxOffset = 0.65f;
    public float hpMaxOffset = 0.65f;
    [SerializeField] float spawnEnemyTime = 5;
    [SerializeField] float spawnEnemyVariation = 0.5f;
    float enemyTimerAux = 0;

    [SerializeField] GameObject enemy;
    [SerializeField] float spawnRadius = 10;

    public int playerDeaths = 0;
    public float inactiveTimer = 0;

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

    public float dynamicDifficulty()
    {
        float deathDifficulty = Mathf.Max(1-playerDeaths * deathDynamicOffset , deathMaxOffset);
        float auxDIvider = (1 / (1 - hpMaxOffset));
        float hpDifficulty = Mathf.Max(hpMaxOffset + ((float)player.GetComponent<CombatController>().health / (float)player.GetComponent<CombatController>().maxHealth) / auxDIvider, hpMaxOffset);

        return Mathf.Max((deathDifficulty + hpDifficulty) / 2, minimumDifficulty);
    }

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
