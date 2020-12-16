using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpikesController : MonoBehaviour
{
    [SerializeField] BoxCollider damageCol;
    public int damage = 10;
    bool trapActive = false;
    void Start()
    {
        deactivateTrap();
    }

    public void activateTrap()
    {
        trapActive = true;
        damageCol.enabled = true;
        damageCol.gameObject.SetActive(true);
    }

    public void deactivateTrap()
    {
        trapActive = false;
        damageCol.enabled = false;
        damageCol.gameObject.SetActive(false);
    }

    public void toggleTrap()
    {
        if (trapActive)
        {
            deactivateTrap();
        }
        else
        {
            activateTrap();
        }
    }
}
