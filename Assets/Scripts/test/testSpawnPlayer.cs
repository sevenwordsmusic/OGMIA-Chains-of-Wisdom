using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSpawnPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject[] spawns;
    CharacterController characterController;


    void Start()
    {
        StartCoroutine(spawnCoroutine());
    }

    IEnumerator spawnCoroutine()
    {
        yield return new WaitForSeconds(1);

        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(true);

        GameObject gController = GameObject.FindGameObjectWithTag("gameController");
        gController.GetComponent<ProgressTracker>().AmuletAnimator.gameObject.SetActive(true);

        characterController = player.GetComponent<CharacterController>();

        characterController.enabled = false;
        player.transform.position = this.transform.position;
        characterController.enabled = true;


        foreach (GameObject spawn in spawns)
        {
            spawn.SetActive(true);
        }

        print("ACTIVANDO JUGADOR, si no se desea activar, borrar el script testSpawnPlayer de objeto: StartPos");
    }
}
