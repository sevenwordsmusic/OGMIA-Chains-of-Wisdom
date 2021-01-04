using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyIfTheresNoChildrenLeft : MonoBehaviour
{
    //Podría hacer una broma de humor negro muy mala diciendo que este script en realidad cuenta la historia de unos padres que perdieron a sus hijos en trágicos accidentes y que se suicidaron al no poder superar su pérdida...
    //Pero no lo voy a hacer.


    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
