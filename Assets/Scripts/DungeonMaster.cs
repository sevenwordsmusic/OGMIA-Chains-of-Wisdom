using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    public float difficulty = 1;
    public float deathInitialOffset = 0.1f;
    public float deathDynmicOffset = 0.1f;
    public float globalProximityTrackerOffset = 0.1f;

    GameObject player;
    BehaviourTracker bTracker;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //bTracker = player.GetComponent<BehaviourTracker>();
    }
}
