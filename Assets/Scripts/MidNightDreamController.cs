using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers;

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

            //SAVE THE GAME
            SaveSystem.SaveToSlot(1);
            //ToDo: mensaje de 'partida guardada con exito'
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
