using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODListenerController : MonoBehaviour
{
    [SerializeField] GameObject player;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            this.transform.position = player.transform.position;
        } 
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
