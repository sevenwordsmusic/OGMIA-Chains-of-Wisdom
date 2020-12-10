using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RoomController : MonoBehaviour
{
    static int lastId = 0;
    public int id = 0;
    public List<GameObject> gates = new List<GameObject>();
    public List<Transform> centerPoints = new List<Transform>();
    [SerializeField] bool commitChanges = false;
    //[SerializeField] Vector2Int position = new Vector2Int(0, 0);
    LevelController controller;
    int counter = 0;
    bool firstSpawn = true;

    [CustomEditor(typeof(RoomController))]
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

            if (GUILayout.Button("Transparent Tags"))
            {
                myScript.transparentTags();
                myScript.commitChanges = false;
            }
        }
    }

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

    void transparentTags()
    {

        Transform model = transform.Find("model");
        foreach (Transform tr in model)
        {
            if (tr.tag.Equals("Untagged"))
            {
                tr.tag = "transparent";
            }
        }
    }


    private void Start()
    {
        controller = transform.parent.gameObject.GetComponent<LevelController>();
        controller.roomArray[id] = this.gameObject;
        if (id < controller.roomAmount - 1)
            StartCoroutine(roomCoroutine(false));
        else
            StartCoroutine(roomCoroutine(true));
    }

    void initializeRoom()
    {

    }

    public void levelInitialize()
    {
        initializeRoom();
    }

    IEnumerator roomCoroutine(bool end)
    {
        yield return new WaitForSeconds(controller.generationTime);
        if (controller.currentRoomAmount < controller.roomAmount && counter < gates.Count)
        {
            spawnRoom(counter);
            counter++;
            StartCoroutine(roomCoroutine(end));
        }
        else
        {
            for(int i= counter; i< gates.Count; i++)
            {   
                 if(!gates[i].GetComponent<GateController>().isGate)
                    gates[i].GetComponent<GateController>().initializeWall();
            }
            if(end)
                controller.endFirstGenerationWave();
        }
    }

    void spawnRoom(int gateCounter)
    {
        GateController gate = gates[gateCounter].GetComponent<GateController>();
        if (Random.value < controller.levelShape/2 || firstSpawn)
        {
            Vector2Int dir = gate.getDirection();

            GameObject roomPrefab = controller.rooms[Random.Range(0, controller.rooms.Count)];
            RoomController roomPrefabController = roomPrefab.GetComponent<RoomController>();
            int nextEntranceGate = Random.Range(0, roomPrefabController.gates.Count);

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

                controller.debugEdge(id, roomInstanceController.id, 1);                         //DEBUG

                roomInstanceController.gates[nextEntranceGate].GetComponent<GateController>().initializeGate();

                //print("Room: " + id + " (dir="+dir+") --> Room: " + roomAux.GetComponent<RoomController>().id+ " (dir=" + roomAux.GetComponent<RoomController>().gates[nextEntranceGate].GetComponent<GateController>().getDirection() + ")");
                roomInstanceController.initializeRoom();
            }
            else
            {
                Destroy(roomInstance);
                if(!gate.isGate)
                    gate.initializeWall();
            }
        }
        else
        {
            if (!gate.isGate)
                gate.initializeWall();
        }
    }

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
        return (Random.Range(0, gates.Count));
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
                        if (conectingGate != null && Random.value < controller.interconectivity)
                        {
                            controller.debugEdge(id, neighborRoomId, 2);            //DEBUG
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
    }

    GameObject findGateInRoom(Vector3 pos, float tolerance)
    {
        foreach(GameObject gate in gates)
        {
            if(Vector3.Distance(gate.transform.position, pos) < tolerance)
            {
                return gate;
            }
        }
        return null;
    }
    
}
