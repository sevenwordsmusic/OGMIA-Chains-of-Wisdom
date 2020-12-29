using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidNightDreamController : MonoBehaviour
{
    private GameObject player;
    private CharacterController characterController;
    [Tooltip("Si es true, teletransporta al jugador a este punto al iniciarse esta escena")] public bool warpPlayerHereAtStart;


    // Start is called before the first frame update
    void Start()
    {
        if (warpPlayerHereAtStart)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            characterController = player.GetComponent<CharacterController>();
            characterController.enabled = false;
            player.transform.position = this.transform.position;
            characterController.enabled = true;
        }

        //comprobamos si el jugador ha reunido todos los fragmentos del amuleto
        if(PlayerPrefs.GetInt("numberOfPieces") == 7) //Si los tiene todos
        {
            //Lanzamos la cutscene final del juego

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
