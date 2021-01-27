using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(RoomController))]
public class RoomTrapController : MonoBehaviour
{
    [SerializeField] float damageInterval = 2f;
    float intervalAux = 0;
    [SerializeField] List<GameObject> traps = new List<GameObject>();
    [SerializeField] bool commitChanges = false;
    bool trapsEnabled = false;

    [CustomEditor(typeof(RoomTrapController))]
    public class ObjectBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            RoomTrapController myScript = (RoomTrapController)target;
            if (GUILayout.Button("Update Traps"))
            {
                myScript.updateTrapsInit();
                myScript.commitChanges = false;
            }
        }
    }

    void updateTraps(Transform t)
    {
        if (t.tag.Equals("trap"))
        {
            traps.Add(t.gameObject);
        }
        if (t.childCount > 0)
        {
            foreach (Transform child in t)
            {
                updateTraps(child);
            }
        }
    }

    void updateTrapsInit()
    {
        traps.Clear();
        Transform t = transform;
        updateTraps(t);
    }


    void Start()
    {
        GetComponent<RoomController>().enteredRoom += enteredTrapRoom;
        GetComponent<RoomController>().enteredRoom += enableTraps;
        GetComponent<RoomController>().exitedRoom += disableTraps;
    }



    void enteredTrapRoom()
    {
        DungeonMaster.DM.encounteredChallanage();

        foreach(GameObject trap in traps)
        {
            var attempt1 = trap.GetComponent<TrapSpikesController>();
            if(attempt1 != null)
            {
                attempt1.dmAdjustParams();
            }
            else
            {
                var attempt2 = trap.GetComponent<arrowTrapController>();
                if (attempt2 != null)
                {
                    attempt2.dmAdjustParams();
                }
            }
        }
    }

    void enableTraps()
    {
        trapsEnabled = true;
    }

    void disableTraps()
    {
        trapsEnabled = false;
    }

    /*private void Update()
    {
        if (trapsEnabled)
        {
            intervalAux += Time.deltaTime;
            if(intervalAux >= damageInterval)
            {
                intervalAux = 0 ;
                foreach (TrapSpikesController trap in traps)
                {
                    //trap.toggleTrap();
                }
            }
        }
    }*/


}
