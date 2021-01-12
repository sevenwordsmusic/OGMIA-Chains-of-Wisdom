using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialHeal : MonoBehaviour
{
    [SerializeField] float amount = 10;
    [SerializeField] float rate = 1;
    [SerializeField] GameObject light;
    [SerializeField] float current;
    GameObject player;
    CombatController cController;
    public bool heal = false;

    float intensityTracker;

    void Start()
    {
        current = amount;
        player = GameObject.FindGameObjectWithTag("Player");
        cController = player.GetComponent<CombatController>();
        intensityTracker = light.GetComponent<FlickerLight>().maxIntensity;
    }


    private void Update()
    {
        if (player == null || cController == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            cController = player.GetComponent<CombatController>();
        }

        if (heal && cController.health < cController.maxHealth && current > 0)
        {
            current -= rate * Time.deltaTime;
            cController.increaseHealth(rate * Time.deltaTime);
            light.GetComponent<FlickerLight>().adjustIntenisty(rate * Time.deltaTime * intensityTracker / amount);
        }
    }
}
