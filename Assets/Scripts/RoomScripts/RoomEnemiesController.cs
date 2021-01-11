using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

[RequireComponent(typeof(RoomCloseDoors))]
public class RoomEnemiesController : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] BoxCollider[] spawnAreas;
    int defeatedEnemies = 0;
    public int defaultEnemyNumber = 7;
    public int enemyVariance = 5;
    public float dificultyOffset = 1;
    int enemiesToDefeat = 0;

    [SerializeField] NavMeshSurface navMesh;
    void Start()
    {
        navMesh.BuildNavMesh();
        GetComponent<RoomCloseDoors>().doorsclosed += spawnEnemies;
    }

    void spawnEnemies()
    {
        if (!GetComponent<RoomController>().completedBefore)
        {
            print("SPAWNING ENEMIES");
            foreach(BoxCollider spawnArea in spawnAreas)
            {
                Bounds area = spawnArea.bounds;
                int enemyAux = Random.Range(defaultEnemyNumber - enemyVariance, defaultEnemyNumber + enemyVariance);
                enemiesToDefeat += enemyAux;
                for (int i = 0; i < enemyAux; i++)
                {
                    Vector3 enemyPos = new Vector3(Random.Range(area.min.x, area.max.x), 0, Random.Range(area.min.z, area.max.z));
                    var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], enemyPos, Quaternion.identity);
                    enemy.GetComponent<EnemyController>().setRoomEnemyController(this);
                }
                spawnArea.enabled = false;
            }
        }
    }

    public void enemyDefeated()
    {
        defeatedEnemies++;
        if (defeatedEnemies >= 20)
            enemiesDefeated();
    }

    void enemiesDefeated()
    {
        GetComponent<RoomCloseDoors>().deactivateTrapDoors();
    }


}
