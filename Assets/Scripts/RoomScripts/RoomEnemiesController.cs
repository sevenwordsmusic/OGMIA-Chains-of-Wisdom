using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(RoomCloseDoors))]
public class RoomEnemiesController : MonoBehaviour
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
                    Vector3 enemyPos = new Vector3(Random.Range(area.min.x, area.max.x), 0.5f, Random.Range(area.min.z, area.max.z));
                    var enemy = Instantiate(enemyPrefabs[0], enemyPos, Quaternion.identity, transform);
                    enemy.GetComponent<EnemyController>().setRoomEnemyController(this);
                }
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
