using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int dir;
    float sizeMult = 1;
    RoomEnemiesController controller;
    public bool isAlive;

    [HideInInspector] public int currentHealth; //Salud actual del enemigo
    public int maxHealth; //Salud máxima del enemigo
    //private EnemyHealthBar healthBar;

    //Variables relacionadas con el sistema de detección de enemigos en pantalla
    [HideInInspector] public bool onScreen;
    [HideInInspector] public bool addedToList;
    private float timeOutTimer;

    void Start()
    {
        dir = (Random.value<0.5f)?-1:1;
        sizeMult = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(sizeMult, sizeMult, sizeMult);
    }

    public void setRoomEnemyController(RoomEnemiesController rEC)
    {
        controller = rEC;
    }

    public void enemyDefeated()
    {
        if(controller!= null){
            controller.enemyDefeated();
        }
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Rotate(0, dir, 0);

        //GESTIONAR SI EL ENEMIGO ESTÁ EN PANTALLA, Y SI LO ESTÁ, AÑADIRLO A LA LISTA DE ENEMIGOS EN EL COMBAT MANAGER

        //Determinamos la posición relativa del enemigo en el plano de la cámara.
        Vector3 enemyPosition = Camera.main.WorldToViewportPoint(transform.position);

        //Si los valores X e Y del vector anterior están entre 0 y 1, el enemigo se encuentra dentro de la pantalla.
        onScreen = enemyPosition.z > 0 && enemyPosition.x > 0 && enemyPosition.x < 1 && enemyPosition.y > 0 && enemyPosition.y < 1;

        //Finalmente, si el enemigo está dentro de la pantalla, lo añadimos a la lista de enemigos en el manager (una sola vez)
        if (onScreen && !addedToList)
        {
            addedToList = true;
            timeOutTimer = 0;
            CombatManager.CM.enemies.Add(this);
        }
        else if (!onScreen) //Pero si sale de la pantalla, no nos interesa mantenerlo en la lista, de manera que lo quitamos.
        {
            //Si el enemigo esta fuera de la pantalla,
            timeOutTimer += Time.deltaTime; //corre el contador de tiempo,
            if (timeOutTimer >= 4500) //si dicho contador supera los 4,5 segundos fuera de pantalla
            {
                //quita al enemigo de la lista
                addedToList = false;
                CombatManager.CM.enemies.Remove(this);
                timeOutTimer = 0;
            }
        }

        if (onScreen && addedToList)
        {

            //if (statsWidget.activeSelf == true) //Si las stats están siendo mostradas en pantalla,
            //{
            //    //Actualiza la posición del widget para que siga al enemigo,
            //    Vector3 viewportPosition = Camera.main.WorldToScreenPoint(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z));
            //    statsWidget.transform.position = new Vector3(viewportPosition.x, viewportPosition.y, -3);

            //    //Y activa la información de HP y WP
            //    statsWidget.GetComponent<StatsDisplayer>().updateWPandHP(currentHealth, willpower);
            //}
        }


    }
}
