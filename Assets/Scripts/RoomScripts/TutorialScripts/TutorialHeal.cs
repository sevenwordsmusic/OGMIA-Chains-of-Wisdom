using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialHeal : MonoBehaviour
{
    [SerializeField] float amount = 20;
    [SerializeField] float rate = 0.1f;
    [SerializeField] GameObject light;
    float current;
    GameObject player;
    CombatController cController;
    public bool heal = false;

    float intensityTracker;

    void Start()
    {
        current = amount;
        player = GameObject.FindGameObjectWithTag("Player");
        CombatController cController = player.GetComponent<CombatController>();
        intensityTracker = light.GetComponent<Light>().intensity;
    }


    private void Update()
    {
        if (heal && cController.health < cController.maxHealth)
        {
            current -= rate * Time.deltaTime;
            cController.increaseHealth(rate * Time.deltaTime);
            light.GetComponent<Light>().intensity-= rate * Time.deltaTime * intensityTracker/amount;
        }
    }
}
