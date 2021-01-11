using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TutorialEnemiesController : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] BoxCollider[] spawnAreas;
    int defeatedEnemies = 0;
    public int defaultEnemyNumber = 12;
    public int enemyVariance = 5;
    public float dificultyOffset = 1;
    int enemiesToDefeat = 0;

    void Start()
    {
        GetComponent<TutorialCloseDoors>().doorsclosed += spawnEnemies;
    }

    void spawnEnemies()
    {
        print("SPAWNING ENEMIES");
        foreach(BoxCollider spawnArea in spawnAreas)
        {
            Bounds area = spawnArea.bounds;
            int enemyAux = Random.Range(defaultEnemyNumber - enemyVariance, defaultEnemyNumber + enemyVariance);
            enemiesToDefeat += enemyAux;
            for (int i = 0; i < enemyAux; i++)
            {
                Vector3 enemyPos = new Vector3(Random.Range(area.min.x, area.max.x), 20.5f, Random.Range(area.min.z, area.max.z));
                var enemy = Instantiate(enemyPrefabs[0], enemyPos, Quaternion.identity, transform);
                enemy.GetComponent<EnemyController>().setTutorialEnemyController(this);
                spawnArea.enabled = false;
            }
        }
    }

    public void enemyDefeated()
    {
        defeatedEnemies++;
        if (defeatedEnemies >= enemiesToDefeat)
            enemiesDefeated();
    }

    void enemiesDefeated()
    {
        GetComponent<TutorialCloseDoors>().deactivateTrapDoors();
    }


}
