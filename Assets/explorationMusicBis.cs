using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class explorationMusic : MonoBehaviour
{

    public int nextCode;

    void Start()
    {
        //AUDIO
            AudioManager.engine.ChangeSegmentTo(nextCode);
        //
    }

}
