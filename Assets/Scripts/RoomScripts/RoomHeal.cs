using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(RoomController))]
public class RoomHeal : MonoBehaviour
{
    [SerializeField] float amount = 20;
    [SerializeField] float rate = 2f;
    [SerializeField] GameObject light;
    [SerializeField] List<GameObject> effects;
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
        intensityTracker = light.GetComponent<FlickerLight>().maxIntensity;
    }


    private void Update()
    {
        if (player == null || cController == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            cController = player.GetComponent<CombatController>();
        }


        if (heal && cController.health < cController.maxHealth)
        {
            if (current > 0)
            {
                current -= rate * Time.deltaTime;
                cController.increaseHealth(rate * Time.deltaTime);
                //light.GetComponent<FlickerLight>().adjustIntenisty(rate * Time.deltaTime * intensityTracker / amount);
            }
            else
            {
                foreach (GameObject effect in effects)
                {
                    effect.SetActive(false);
                }
            }
        }
    }
}
