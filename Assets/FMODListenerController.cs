using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODListenerController : MonoBehaviour
{
    public static FMODListenerController Listener;

    [SerializeField] GameObject player;
    //[SerializeField] int maxDistanceAllowed;
    [SerializeField] float heightOffset = 1.5f;
    private GameObject playerBackup;
    private GameObject target;
    //private Vector3 lastFramePos;

    private void Awake()
    {
        if (Listener != null) //Si por algún motivo ya existe un combatManager...
        {
            GameObject.Destroy(Listener); //Este script lo mata. Solo puede haber una abeja reina en la colmena.
            GameObject.Destroy(Listener.gameObject);
        }
        else //En caso de que el trono esté libre...
        {
            Listener = this; //Lo toma para ella!
        }

        DontDestroyOnLoad(this); //Ah, y no destruyas esto al cargar
    }

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
            this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + heightOffset, target.transform.position.z);
        } 
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
