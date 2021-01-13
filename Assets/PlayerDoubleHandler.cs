using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleHandler : MonoBehaviour
{
    public bool overwriteListener;

    public delegate void ListenerEvent(GameObject newTarget);
    public static event ListenerEvent followDouble; //Evento lanzado cuando el jugador muere, para causar una reacción global

    public delegate void ListenerStopFollowingEvent();
    public static event ListenerStopFollowingEvent stopFollowingDouble; //Evento lanzado cuando el jugador muere, para causar una reacción global

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if (overwriteListener)
        {
            if (followDouble != null)
                followDouble(this.gameObject);
        }
    }

    private void OnDisable()
    {
        if(overwriteListener)
        {
            if(stopFollowingDouble != null)
            {
                stopFollowingDouble();
            }
        }
    }

}
