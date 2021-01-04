using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(RoomCloseDoors))]
public class RoomCollectController : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] bool isFragment = true;

    void Start()
    {
        if (GetComponent<RoomController>().completedBefore)
        {
            foreach(GameObject obj in objects)
            {
                obj.SetActive(false);
            }
            if(isFragment)
                transform.parent.GetComponent<LevelProgressTracker>().addFragmentToCounter();
        }
    }

}
