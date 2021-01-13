using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODListenerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int maxDistanceAllowed;
    private GameObject playerBackup;
    private GameObject target;
    private Vector3 lastFramePos;


    private void OnEnable()
    {
        PlayerDoubleHandler.followDouble += replaceTarget;
        PlayerDoubleHandler.stopFollowingDouble += stopFollowingDouble;
    }

    private void OnDisable()
    {
        PlayerDoubleHandler.followDouble -= replaceTarget;
        PlayerDoubleHandler.stopFollowingDouble -= stopFollowingDouble;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = player;
    }

    private void replaceTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    private void stopFollowingDouble()
    {
        target = player;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            this.transform.position = target.transform.position;
        } 
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
