using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSript : MonoBehaviour
{
    [SerializeField] int angle = 0;
    void Start()
    {
        GetComponent<GateController>().adjustDirection(angle);   
    }
}
