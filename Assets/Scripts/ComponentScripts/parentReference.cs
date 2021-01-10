using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentReference : MonoBehaviour
{
    public GameObject parent;
    public int damage;
    private void Start()
    {
        damage = parent.GetComponent<MeeleAITasks>().damage;
    }
}
