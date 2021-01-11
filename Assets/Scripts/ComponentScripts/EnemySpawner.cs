using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] BoxCollider spawnArea;

    public int defaultEnemyNumber = 3;
    public int enemyVariance = 1;
    public float dificultyOffset = 1;

    public void spawnENemies()
    {
        Bounds area = spawnArea.bounds;
        int enemyAux = Random.Range(defaultEnemyNumber - enemyVariance, defaultEnemyNumber + enemyVariance);
        for (int i = 0; i < enemyAux; i++)
        {
            Vector3 enemyPos = new Vector3(Random.Range(area.min.x, area.max.x), 0, Random.Range(area.min.z, area.max.z));
            var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], enemyPos, Quaternion.identity);
        }
    }
}
