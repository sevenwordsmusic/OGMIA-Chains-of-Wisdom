using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(RoomController))]
public class RoomEnemiesController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;


    void Start()
    {
        GetComponent<RoomController>().enteredRoom += spawnEnemies;
    }

    void spawnEnemies()
    {
        if (!GetComponent<RoomController>().completedBefore)
        {
            Instantiate(enemyPrefab, transform.position + new Vector3(0, 0, -5), Quaternion.identity, transform);
            GetComponent<RoomController>().completedBefore = true;
        }
    }


}
