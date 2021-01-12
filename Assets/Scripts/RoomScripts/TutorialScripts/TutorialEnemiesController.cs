using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TutorialEnemiesController : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] BoxCollider[] spawnAreas;
    int defeatedEnemies = 0;
    public float dificultyOffset = 1;
    int enemiesToDefeat = 0;

    void Start()
    {
        GetComponent<TutorialCloseDoors>().doorsclosed += spawnEnemies;
    }

    void spawnEnemies()
    {
        print("SPAWNING ENEMIES");
        BoxCollider spawnArea = spawnAreas[0];
        Bounds area = spawnArea.bounds;
        int enemyAux = 2;
        enemiesToDefeat += enemyAux;
        for (int i = 0; i < enemyAux; i++)
        {
            Vector3 enemyPos = new Vector3(Random.Range(area.min.x, area.max.x), 20.5f, Random.Range(area.min.z, area.max.z));
            var enemy = Instantiate(enemyPrefabs[0], enemyPos, Quaternion.identity, transform);
            enemy.GetComponent<EnemyController>().setTutorialEnemyController(this);
            enemy.GetComponent<EnemyController>().initVariables(true);
        }
        spawnArea.enabled = false;

        spawnArea = spawnAreas[1];
        area = spawnArea.bounds;
        enemyAux = 1;
        enemiesToDefeat += enemyAux;
        for (int i = 0; i < enemyAux; i++)
        {
            Vector3 enemyPos = new Vector3(Random.Range(area.min.x, area.max.x), 20.5f, Random.Range(area.min.z, area.max.z));
            var enemy = Instantiate(enemyPrefabs[1], enemyPos, Quaternion.identity, transform);
            enemy.GetComponent<EnemyController>().setTutorialEnemyController(this);
            enemy.GetComponent<EnemyController>().initVariables(true);
        }
        spawnArea.enabled = false;
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
