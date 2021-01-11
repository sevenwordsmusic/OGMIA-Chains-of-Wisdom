using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(RoomController))]
public class RoomHeal : MonoBehaviour
{
    [SerializeField] float amount = 20;
    [SerializeField] float rate = 0.1f;
    [SerializeField] GameObject light;
    float current;
    GameObject player;
    bool heal = false;

    float intensityTracker;

    void Start()
    {
        current = amount;
        player = GameObject.FindGameObjectWithTag("player");
        intensityTracker = light.GetComponent<Light>().intensity;
    }


    private void Update()
    {
        if (heal)
        {
            current -= rate * Time.deltaTime;
            player.GetComponent<CombatController>().increaseHealth(rate * Time.deltaTime);
            light.GetComponent<Light>().intensity-= rate * Time.deltaTime * intensityTracker/amount;
        }
    }
}
