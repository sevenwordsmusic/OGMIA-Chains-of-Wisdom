using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    static int lastId = 0;
    public int id = 0;
    [SerializeField] Vector2Int size = new Vector2Int(20,20);
    public List<GameObject> gates = new List<GameObject>();
    [SerializeField] Vector2Int position = new Vector2Int(0, 0);
    LevelController controller;
    int counter = 0;
    bool firstSpawn = true;
    void Start()
    {
        controller = transform.parent.gameObject.GetComponent<LevelController>();
        controller.roomArray[id] = this.gameObject;
        if (id < controller.roomAmount - 1)
            StartCoroutine(roomCoroutine(false));
        else
            StartCoroutine(roomCoroutine(true));

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

            if (!controller.ocupiedSpaces.ContainsKey(position + dir))
            {
                controller.ocupiedSpaces.Add(position + dir, RoomController.lastId);

                firstSpawn = false;

                gate.initializeGate();

                GameObject chosenRoom = controller.rooms[Random.Range(0, controller.rooms.Count)];

                int nextEntranceGate = Random.Range(0, chosenRoom.GetComponent<RoomController>().gates.Count);
                int nextRoomAngle = uVecAngle(chosenRoom.GetComponent<RoomController>().gates[nextEntranceGate].GetComponent<GateController>().getDirection(), -dir);

                var roomAux = Instantiate(chosenRoom, 
                                          transform.position + (new Vector3(dir.x, 0, dir.y) * 20),
                                          /*Quaternion.Euler(0, nextRoomAngle, 0), */
                                          Quaternion.identity,
                                          transform.parent);

                RoomController roomController = roomAux.GetComponent<RoomController>();
                roomController.adjustId();
                roomController.adjustPosition(position + dir);
                roomController.adjustRotation(nextRoomAngle);

                controller.lastRoom = roomAux;
                controller.currentRoomAmount++;

                controller.createEdge(id, roomController.id, 1);

                //print("Room: " + id + " (dir="+dir+") --> Room: " + roomAux.GetComponent<RoomController>().id+ " (dir=" + roomAux.GetComponent<RoomController>().gates[nextEntranceGate].GetComponent<GateController>().getDirection() + ")");
            }
            else
            {
                gate.initializeWall();
            }
        }
        else
        {
            gate.initializeWall();
        }
    }

    public void adjustId()
    {
        id = RoomController.lastId;
        RoomController.lastId++;
    }

    public void adjustPosition(Vector2Int newPos)
    {
        position = newPos;
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
        return Mathf.RoundToInt(Mathf.Acos(a.x * b.x + a.y * b.y) * 180/Mathf.PI);
    }

    public void secondGeneration()
    {
        foreach(GameObject gate in gates)
        {
            Vector2Int key = position + gate.GetComponent<GateController>().getDirection();
            if (controller.ocupiedSpaces.ContainsKey(key))
            {
                int neighborRoomId = -123123;
                bool tryGet = controller.ocupiedSpaces.TryGetValue(key, out neighborRoomId);
                if(tryGet && neighborRoomId != -123123)
                {
                    if (controller.adjacencyMatrix[id, neighborRoomId] == 0)
                    {
                        if (Random.value < controller.interconectivity)
                        {
                            controller.createEdge(id, neighborRoomId, 2);
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

    public void thirdGeneration()
    {
        foreach (GameObject gate in gates)
        {
            Vector2Int key = position + gate.GetComponent<GateController>().getDirection();
            if (controller.ocupiedSpaces.ContainsKey(key))
            {
                int neighborRoomId = -123123;
                bool tryGet = controller.ocupiedSpaces.TryGetValue(key, out neighborRoomId);
                if (tryGet && neighborRoomId != -123123)
                {
                    if (controller.adjacencyMatrix[id, neighborRoomId] != 0)
                    {
                        if (!gate.GetComponent<GateController>().isGate)
                        {
                            gate.GetComponent<GateController>().initializeGate();
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
    
}
