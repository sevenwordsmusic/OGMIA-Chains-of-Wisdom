using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTracker : MonoBehaviour
{
    float passiveTime;
    float activeTime;
    int deaths;
    public int challangeAcumulator = 0;

    // Update is called once per frame
    void Update()
    {
        passiveTime += Time.deltaTime;
        activeTime += Time.deltaTime;
    }

    public void resetPassiveTime()
    {
        passiveTime = 0;
    }

    public void resetActiveTime()
    {
        activeTime = 0;
    }
}
