using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    public static CombatManager CM;

    public List<EnemyController> enemies;

    //public GameObject combatHUD;

    public bool onCombat;

    private CombatController player;

    private void Awake()
    {
        if(CM != null) //Si por algún motivo ya existe un combatManager...
        {
            GameObject.Destroy(CM.gameObject); //Este script lo mata. Solo puede haber una abeja reina en la colmena.
        } 
        else //En caso de que el trono esté libre...
        {
            CM = this; //Lo toma para ella!
        }

        DontDestroyOnLoad(this); //Ah, y no destruyas esto al cargar
    }

    private void OnEnable()
    {
        GameInitializer.gameInitialized += getPlayerReference;
        UIManager.goBackToMainMenuEvent += DestroyCombatManager;
    }

    private void OnDisable()
    {
        GameInitializer.gameInitialized -= getPlayerReference;
        UIManager.goBackToMainMenuEvent -= DestroyCombatManager;
    }

    private void DestroyCombatManager()
    {
        Destroy(this.gameObject);
    }

    private void Start()
    {
        //getPlayerReference();
    }

    public void getPlayerReference()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatController>();
    }

    public void showAllStats()
    {
        foreach(EnemyController enemy in enemies)
        {
            //enemy.showStats();
        }
    }

    public void hideAllStats()
    {
        foreach (EnemyController enemy in enemies)
        {
            //enemy.hideStats();
        }
    }

    private void Update()
    {
        onCombat = enemies.Count > 0; //Si hay al menos un enemigo en la lista, eso significa que estamos en un combate.
        if (!onCombat)
        {
            //combatHUD.SetActive(false);

            //AUDIO
                //AudioManager.engine.segmentCode = 0.0f;
            //
        }
        else
        {
            if(!player.isDead)
            {
                //combatHUD.SetActive(true);
                calculateCombatState();
            } 
            else
            {
                //combatHUD.SetActive(false);
            }
        }
    }

    //AUDIO
    private void calculateCombatState()
    {
        //if (player.isDead)
        //{
        //    print("RIP Player");
        //}
        //else if (EnemiesLowHP())
        //{
        //    print("Enemy LowHP!");
        //    //AudioManager.engine.segmentCode = 3.0f;
        //}
        //else if (player.health <= (player.maxHealth / 2))
        //{
        //    print("Player LowHP!");
        //    //AudioManager.engine.segmentCode = 2.0f;
        //}
        //else
        //{
        //    print("Just defaulting over here");
        //    //AudioManager.engine.segmentCode = 1.0f;
        //}
    }
    //

    public bool EnemiesLowHP ()
    {
        int totalHP = 0;
        int actualHP = 0;

        foreach (EnemyController enemy in enemies)
        {
            //totalHP += enemy.stats.health;
        }

        foreach (EnemyController enemy in enemies)
        {
            //actualHP += enemy.currentHealth;
        }

        if (actualHP <= (totalHP / 4))
        {
            return true;
        } 
        else
        {
            return false;
        }

    }



}
