using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RoomController : MonoBehaviour
{
    static int lastId = 0;

    public static void resetLastId()
    {
        RoomController.lastId = 0;
    }

    public int id = 0;
    public bool completedBefore = false;
    public enum RoomeTypes { Connector, Empty, Enemy, Healing, Trap, Start, Fragment, Boss };
    public RoomeTypes roomType = RoomeTypes.Connector;
    public Transform startPos;
    public List<GameObject> gates = new List<GameObject>();
    public List<Transform> centerPoints = new List<Transform>();
    public List<GameObject> lights = new List<GameObject>();
    [SerializeField] bool commitChanges = false;
    //[SerializeField] Vector2Int position = new Vector2Int(0, 0);
    LevelController controller;
    [HideInInspector] public bool firstSpawn = true;

    public delegate void EnteredRoom();
    public EnteredRoom enteredRoom;
    public delegate void ExitedRoom();
    public ExitedRoom exitedRoom;

    /*[CustomEditor(typeof(RoomController))]
    public class ObjectBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            RoomController myScript = (RoomController)target;
            if (GUILayout.Button("Update Values"))
            {
                myScript.updateValues();
                myScript.commitChanges = false;
            }

            if (GUILayout.Button("Adjust Gates"))
            {
                myScript.adjustGates();
                myScript.commitChanges = false;
            }

            if (GUILayout.Button("Update Lights"))
            {
                myScript.updateLightsInit();
                myScript.commitChanges = false;
            }

            if (GUILayout.Button("TurnOnLights"))
            {
                myScript.turnOnLightsPrefab();
                myScript.commitChanges = false;
            }

            if (GUILayout.Button("TurnOffLights"))
            {
                myScript.turnOffLightsPrefab();
                myScript.commitChanges = false;
            }
        }
    }*/

    void updateValues()
    {
        gates.Clear();
        centerPoints.Clear();

        Transform perRoom = transform.Find("PerRoom");
        foreach(Transform tr in perRoom)
        {
            if (tr.tag.Equals("gate"))
            {
                gates.Add(tr.gameObject);
            }
            if (tr.tag.Equals("centerPoint"))
            {
                centerPoints.Add(tr);
            }
        }
    }

    void adjustGates()
    {
        foreach (GameObject gateObj in gates)
        {   
            if (gateObj.transform.tag.Equals("gate"))
            {   
                foreach (Transform cp in centerPoints)
                {
                    Vector3 dir = gateObj.transform.position - cp.position;
                    if (dir.magnitude < 1.1f * LevelController.baseRoomeSize/2)
                    {
                        if(dir.magnitude != LevelController.baseRoomeSize/2 || dir.x*dir.y != 0)
                        {
                            Debug.LogError("ERROR, puerta (" + gateObj.transform.name + ") o centerPoint (" + cp.name + ") mal posicionado");
                            goto innerLoop;
                        }
                        else
                        {
                            dir.Normalize();
                            gateObj.GetComponent<GateController>().setDirection(new Vector2Int(Mathf.RoundToInt(dir.x), Mathf.RoundToInt(dir.z)));
                        }
                    }
                }
            }
            innerLoop:;
        }
    }

    void updateLights(Transform t)
    {
        if (t.tag.Equals("lightComponent"))
        {
            lights.Add(t.gameObject);
        }
        if(t.childCount > 0)
        {
            foreach (Transform child in t)
            {
                updateLights(child);
            }
        }
    }

    void updateLightsInit()
    {
        lights.Clear();
        Transform t = transform;
        updateLights(t);
    }

    //start
    private void Start()
    {
        controller = transform.parent.gameObject.GetComponent<LevelController>();
        controller.roomArray[id] = this.gameObject;

        //completedBefore = controller.completedRooms[id];

        prepareGates();

        if (!controller.lightOptimiation)
        {
            turnOnLights();
        }

        enteredRoom += turnOnLights;
        exitedRoom += turnOffLights;
    }


    //add gates to room generation queue
    void prepareGates()
    {
        shuffleGates();
        for (int i = 0; i < gates.Count; i++)
        {
            controller.addRoomToSpawn(new Vector2Int(id, i));
        }
    }

    //add only gates that havent been yet connected to generation queue
    public void prepareFreeGates()
    {
        for (int i = 0; i < gates.Count; i++)
        {
            if (!gates[i].GetComponent<GateController>().isGate)
                controller.addRoomToSpawn(new Vector2Int(id, i));
        }
    }

    //get random room depending on room type
    GameObject fetchRoomPrefab()
    {
        if(controller.currentRoomAmount == ((int)(controller.roomAmount/3)) || controller.currentRoomAmount == ((int)(2*controller.roomAmount / 3)))
        {
            return controller.roomsFragment[controller.randomInt(0, controller.roomsFragment.Count)];
        }
        else if(controller.currentRoomAmount == controller.roomAmount-1)
        {
            return controller.roomsBoss[controller.randomInt(0, controller.roomsBoss.Count)];
        }
        else
        {
            float randomValue = controller.randomValue();
            switch (roomType)
            {
                case RoomeTypes.Start:
                    return controller.roomsConnector[controller.randomInt(0, controller.roomsConnector.Count)];
                    break;
                case RoomeTypes.Fragment:
                    if (randomValue <= 0.26f)
                    {
                        return controller.roomsConnector[controller.randomInt(0, controller.roomsConnector.Count)];
                    }
                    else if (randomValue <= 0.47f)
                    {
                        return controller.roomsEnemy[controller.randomInt(0, controller.roomsEnemy.Count)];
                    }
                    else if (randomValue <= 0.68f)
                    {
                        return controller.roomsTrap[controller.randomInt(0, controller.roomsTrap.Count)];
                    }
                    else if (randomValue <= 0.89f)
                    {
                        return controller.roomsHealing[controller.randomInt(0, controller.roomsHealing.Count)];
                    }
                    else
                    {
                        return controller.roomsEmpty[controller.randomInt(0, controller.roomsEmpty.Count)];
                    }
                    break;
                case RoomeTypes.Connector:
                    if (randomValue <= 0.45f)
                    {
                        return controller.roomsEnemy[controller.randomInt(0, controller.roomsEnemy.Count)];
                    }
                    else if (randomValue <= 0.9f)
                    {
                        return controller.roomsTrap[controller.randomInt(0, controller.roomsTrap.Count)];
                    }
                    else
                    {
                        return controller.roomsEmpty[controller.randomInt(0, controller.roomsEmpty.Count)];
                    }
                    break;
                case RoomeTypes.Empty:
                    if (randomValue <= 0.45f)
                    {
                        return controller.roomsEnemy[controller.randomInt(0, controller.roomsEnemy.Count)];
                    }
                    else if (randomValue <= 0.9f)
                    {
                        return controller.roomsTrap[controller.randomInt(0, controller.roomsTrap.Count)];
                    }
                    else
                    {
                        return controller.roomsConnector[controller.randomInt(0, controller.roomsConnector.Count)];
                    }
                    break;
                case RoomeTypes.Enemy:
                    if (randomValue <= 0.5f)
                    {
                        return controller.roomsConnector[controller.randomInt(0, controller.roomsConnector.Count)];
                    }
                    else if (randomValue <= 0.65f)
                    {
                        return controller.roomsEmpty[controller.randomInt(0, controller.roomsEmpty.Count)];
                    }
                    else
                    {
                        return controller.roomsHealing[controller.randomInt(0, controller.roomsHealing.Count)];
                    }
                    break;
                case RoomeTypes.Trap:
                    if (randomValue <= 0.5f)
                    {
                        return controller.roomsConnector[controller.randomInt(0, controller.roomsConnector.Count)];
                    }
                    else if (randomValue <= 0.65f)
                    {
                        return controller.roomsEmpty[controller.randomInt(0, controller.roomsEmpty.Count)];
                    }
                    else
                    {
                        return controller.roomsHealing[controller.randomInt(0, controller.roomsHealing.Count)];
                    }
                    break;
                case RoomeTypes.Healing:
                    if (randomValue <= 0.4f)
                    {
                        return controller.roomsEnemy[controller.randomInt(0, controller.roomsEnemy.Count)];
                    }
                    else if (randomValue <= 0.8f)
                    {
                        return controller.roomsTrap[controller.randomInt(0, controller.roomsTrap.Count)];
                    }
                    else if (randomValue <= 0.9f)
                    {
                        return controller.roomsConnector[controller.randomInt(0, controller.roomsConnector.Count)];
                    }
                    else
                    {
                        return controller.roomsEmpty[controller.randomInt(0, controller.roomsEmpty.Count)];
                    }
                    break;
            }
        }
        return controller.roomsConnector[controller.randomInt(0, controller.roomsConnector.Count)];
    }

    //randomize gates list
    void shuffleGates()
    {
        for(int i=0; i<gates.Count; i++)
        {
            GameObject aux = gates[i];
            int randPos = controller.randomInt(0, gates.Count);
            gates[i] = gates[randPos];
            gates[randPos] = aux;
        }
    }

    public void trySpawnRoom(int gateCounter)
    {
        GateController gate = gates[gateCounter].GetComponent<GateController>();
        Vector2Int dir = gate.getDirection();
       
        if (gate.spawnAlways || firstSpawn || controller.randomValue() <= controller.levelShape)
        {
            GameObject roomPrefab = fetchRoomPrefab();
            spawnRoom(gate, dir, roomPrefab, gate.spawnAlways);
        }
    }

    //create room, after adjusting position and rotation, if it doesnt fit, eliminate it
    void spawnRoom(GateController gate, Vector2Int dir, GameObject roomPrefab, bool tryAgain)
    {

        RoomController roomPrefabController = roomPrefab.GetComponent<RoomController>();

        int nextEntranceGate = controller.randomInt(0, roomPrefabController.gates.Count);

        var roomInstance = Instantiate(roomPrefab,
                                  Vector3.zero,
                                  /*Quaternion.Euler(0, nextRoomAngle, 0), */
                                  Quaternion.identity,
                                  transform.parent);

        RoomController roomInstanceController = roomInstance.GetComponent<RoomController>();

        int nextRoomAngle = uVecAngle(-dir, roomInstanceController.gates[nextEntranceGate].GetComponent<GateController>().getDirection());
        roomInstanceController.adjustRotation(nextRoomAngle);

        //adjusting physical position
        Vector3 newPos = gate.transform.position + (roomInstance.transform.position - roomInstanceController.gates[nextEntranceGate].transform.position);
        roomInstance.transform.position = newPos;
        //if (roomInstanceController.checkAvailableSpace(controller))
        if (roomInstanceController.checkAvailableSpace(controller))
        {
            roomInstanceController.ocupyAvailableSpace(controller);
            firstSpawn = false;
            gate.initializeGate();
            roomInstanceController.adjustId();
            controller.lastRoom = roomInstance;
            controller.currentRoomAmount++;

            roomInstanceController.completedBefore = controller.completedRooms[roomInstanceController.id];

            controller.createEdge(id, roomInstanceController.id, 1);         
            roomInstanceController.gates[nextEntranceGate].GetComponent<GateController>().initializeGate();
            //print("Room: " + id + " (dir="+dir+") --> Room: " + roomAux.GetComponent<RoomController>().id+ " (dir=" + roomAux.GetComponent<RoomController>().gates[nextEntranceGate].GetComponent<GateController>().getDirection() + ")");
        }
        else
        {
            Destroy(roomInstance);
            if (tryAgain)
            {
                spawnRoom(gate, dir, controller.basicConector, false);
            }
        }
    }

    //aux methods
    public void adjustId()
    {
        id = RoomController.lastId;
        RoomController.lastId++;
    }

    public void adjustRotation(int angle)
    {
        transform.Rotate(0, angle, 0);
        foreach(GameObject gateToAdjust in gates)
        {
            gateToAdjust.GetComponent<GateController>().adjustDirection(angle);
        }
    }

    public int getRandGate()
    {
        return (controller.randomInt(0, gates.Count));
    }

    int uVecAngle(Vector2Int a, Vector2Int b)
    {
        Vector2 a_aux= new Vector2(a.x, a.y);
        Vector2 b_aux = new Vector2(b.x, b.y);
        return Mathf.RoundToInt(Vector2.SignedAngle(a_aux, b_aux));
    }

    bool previousCheck(Vector2Int pos, LevelController controllerAux)
    {
        return !controllerAux.ocupiedSpaces.ContainsKey(pos);
    }

    bool checkAvailableSpace(LevelController controllerAux)
    {
        if(centerPoints.Count < 2)
        {
            return !controllerAux.ocupiedSpaces.ContainsKey(new Vector2Int(Mathf.RoundToInt(transform.position.x/LevelController.baseRoomeSize), Mathf.RoundToInt(transform.position.z / LevelController.baseRoomeSize)));
        }
        else
        {
            foreach (Transform centerP in centerPoints)
            {
                if (controllerAux.ocupiedSpaces.ContainsKey(new Vector2Int(Mathf.RoundToInt(centerP.transform.position.x / LevelController.baseRoomeSize), Mathf.RoundToInt(centerP.transform.position.z / LevelController.baseRoomeSize))))
                {
                    return false;
                }
            }
            return true;
        }
    }

    void ocupyAvailableSpace(LevelController controllerAux)
    {
         foreach (Transform centerP in centerPoints)
        {
            controllerAux.ocupiedSpaces.Add(new Vector2Int(Mathf.RoundToInt(centerP.transform.position.x / LevelController.baseRoomeSize), Mathf.RoundToInt(centerP.transform.position.z / LevelController.baseRoomeSize)), RoomController.lastId);
        }
    }

    public List<Transform> getCenterPos()
    {
        return centerPoints;
    }

    void printPoints()
    {
        foreach (Transform centerP in centerPoints)
        {
            print(centerP.position);
        }
        print("______________________________________");
    }

    //secondary generation, used for aditional interconectivity and creating walls in all non connected gates
    public void secondGeneration()
    {
        foreach(GameObject gate in gates)
        {
            GateController gateController = gate.GetComponent<GateController>();
            Vector2Int dirr = gateController.getDirection();
            Vector2Int key = new Vector2Int(Mathf.RoundToInt(gate.transform.position.x/LevelController.baseRoomeSize + ((float)dirr.x/2)), Mathf.RoundToInt(gate.transform.position.z / LevelController.baseRoomeSize + ((float)dirr.y / 2)));
            if (controller.ocupiedSpaces.ContainsKey(key))
            {
                int neighborRoomId = -123123;
                bool tryGet = controller.ocupiedSpaces.TryGetValue(key, out neighborRoomId);
                if(tryGet && neighborRoomId != -123123)
                {
                    if (!gateController.isGate)
                    {
                        GameObject conectingGate = controller.roomArray[neighborRoomId].GetComponent<RoomController>().findGateInRoom(gate.transform.position, 1);
                        if (conectingGate != null && controller.randomValue() < controller.interconectivity)
                        {
                            controller.createEdge(id, neighborRoomId, 2);            //DEBUG
                            gateController.initializeGate();
                            conectingGate.GetComponent<GateController>().initializeGate();
                        }
                    }
                }
                else
                {
                    print("something went wrong with tryGet of dictionary");
                }
            }
        }

        foreach(GameObject gate in gates)
        {
            GateController gateController2 = gate.GetComponent<GateController>();
            if (!gateController2.isGate)
            {
                gateController2.initializeWall();
            }
        }
    }

    GameObject findGateInRoom(Vector3 pos, float tolerance)
    {
        foreach (GameObject gate in gates)
        {
            if (Vector3.Distance(gate.transform.position, pos) < tolerance)
            {
                return gate;
            }
        }
        return null;
    }

    void turnOnLightsPrefab()
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }
    }
    void turnOffLightsPrefab()
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }
    }


    void turnOnLights()
    {
        if (controller.lightOptimiation)
        {
            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
        }
    }

    void turnOffLights()
    {

        if (controller.lightOptimiation)
        {
            foreach (GameObject light in lights)
            {
                light.SetActive(false);
            }
        }
    }

    public LevelController getLevelController()
    {
        return controller;
    }

    public void turnOnCloseLights(Vector3 playerPos)
    {
        foreach (GameObject light in lights)
        {
            if(Vector3.Distance(light.transform.position, playerPos) <= controller.lightUpDistance)
                light.SetActive(true);
            else
                light.SetActive(false);
        }
    }

    public void saveState()
    {
        getLevelController().saveGameState();
    }
    
}
