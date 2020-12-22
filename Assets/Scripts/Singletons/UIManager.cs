using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager UIM;

    public GameObject generalHUD,GameOverHUD;

    //EVENTS
    private void OnEnable()
    {
        CombatController.playerDeath += showGameOverHUD;
    }

    private void OnDisable()
    {
        CombatController.playerDeath -= showGameOverHUD;
    }


    private void Awake()
    {
        if (UIM != null) //Si por algún motivo ya existe un combatManager...
        {
            GameObject.Destroy(UIM); //Este script lo mata. Solo puede haber una abeja reina en la colmena.
        }
        else //En caso de que el trono esté libre...
        {
            UIM = this; //Lo toma para ella!
        }

        DontDestroyOnLoad(this); //Ah, y no destruyas esto al cargar
    }

    public void showGameOverHUD()
    {
        generalHUD.SetActive(false);
        GameOverHUD.SetActive(true);
    }

}
