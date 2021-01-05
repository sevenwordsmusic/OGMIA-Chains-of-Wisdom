using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(RoomController))]
public class RoomCloseDoors : MonoBehaviour
{
    [SerializeField] List<GameObject> trapDoors = new List<GameObject>();
    [SerializeField] List<BoxCollider> triggers = new List<BoxCollider>();
    [SerializeField] bool commitChanges = false;
    public delegate void DoorsClosed();
    public DoorsClosed doorsclosed;

    [CustomEditor(typeof(RoomCloseDoors))]
    public class ObjectBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            RoomCloseDoors myScript = (RoomCloseDoors)target;
            if (GUILayout.Button("Update Trap Doors"))
            {
                myScript.updateTrapsDoorsInit();
                myScript.commitChanges = false;
            }
        }
    }

    void updateTrapDoors(Transform t)
    {
        if (t.tag.Equals("enemyGate"))
        {
            trapDoors.Add(t.gameObject);
        }
        if (t.childCount > 0)
        {
            foreach (Transform child in t)
            {
                updateTrapDoors(child);
            }
        }
    }

    void updateTrapsDoorsInit()
    {
        trapDoors.Clear();
        Transform t = transform;
        updateTrapDoors(t);
    }

    void Start()
    {
        deactivateTrapDoors();
    }

    public void activateTrapDoors()
    {
        if (!GetComponent<RoomController>().completedBefore)
        {
            foreach (BoxCollider bC in triggers)
            {
                bC.enabled = false;
            }
            foreach (GameObject trapDoor in trapDoors)
            {
                trapDoor.SetActive(true);
            }
        }
        doorsclosed?.Invoke();
        GetComponent<RoomController>().completedBefore = true;
    }

    public void deactivateTrapDoors()
    {
        foreach (BoxCollider bC in triggers)
        {
            bC.enabled = true;
        }
        foreach (GameObject trapDoor in trapDoors)
        {
            trapDoor.SetActive(false);
        }
    }
}
