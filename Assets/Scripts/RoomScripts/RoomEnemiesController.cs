using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(RoomCloseDoors))]
public class RoomEnemiesController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] BoxCollider spawnArea;
    int defeatedEnemies = 0;

    void Start()
    {
        GetComponent<RoomCloseDoors>().doorsclosed += spawnEnemies;
    }

    void spawnEnemies()
    {
        if (!GetComponent<RoomController>().completedBefore)
        {
            print("SPAWNING ENEMIES");
            Bounds area = spawnArea.bounds;
            for (int i = 0; i < 20; i++)
            {
                Vector3 enemyPos = new Vector3(Random.Range(area.min.x, area.max.x), 0.5f, Random.Range(area.min.z, area.max.z));
                var enemy = Instantiate(enemyPrefab, enemyPos, Quaternion.identity, transform);
                enemy.GetComponent<EnemyController>().setRoomEnemyController(this);
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
