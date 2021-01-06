using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// El cometido de este script es  'vigilar' al objeto objetivo, y activarse y desactivarse al mismo tiempo que su objetivo, copiando su estado.
/// </summary>
public class ActiveWatcherScript : MonoBehaviour
{

    [SerializeField] GameObject target;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.SetActive(target.activeInHierarchy);
    }
}
