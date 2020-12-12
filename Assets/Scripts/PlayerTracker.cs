using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{

    [SerializeField] LevelController controller;
    Vector2Int playerGridPos;
    Vector2Int previousGridPos;
    Vector2Int enterDir;
    public List<int> activeRooms;
    int currentRoom;
    int previousRoom;

    void Start()
    {
        playerGridPos = new Vector2Int(0, 0);
        previousGridPos = new Vector2Int(0, 0);
        enterDir = new Vector2Int(0, 0);
        activeRooms = new List<int>(4);
        currentRoom = 0;
        previousRoom = 0;
    }
    void Update()
    {
        playerGridPos.x = Mathf.RoundToInt(transform.position.x / LevelController.baseRoomeSize);
        playerGridPos.y = Mathf.RoundToInt(transform.position.z / LevelController.baseRoomeSize);


        if (playerGridPos != previousGridPos)
        {
            enterDir = playerGridPos - previousGridPos;
            controller.ocupiedSpaces.TryGetValue(playerGridPos, out currentRoom);
            if (currentRoom != previousRoom)
            {
                print("Entered new Room (" + currentRoom + ") with dir: (" + enterDir + ")" + "   prev:  " + previousRoom);
                controller.roomArray[currentRoom].GetComponent<RoomController>().enteredRoom();
                controller.roomArray[previousRoom].GetComponent<RoomController>().exitedRoom();
            }
            if (controller.optimization)
            {
                controller.roomArray[currentRoom].SetActive(true);
                if (!controller.showExtraRooms)
                {
                    controller.roomArray[previousRoom].SetActive(false);
                }
                else
                {
                    int aux;
                    Vector2Int vecAux;
                    bool foundValue;
                    activeRooms.Clear();

                    aux = 0;
                    vecAux = new Vector2Int(1, 0);
                    foundValue = controller.ocupiedSpaces.TryGetValue(playerGridPos + vecAux, out aux);
                    if (foundValue && controller.roomMatrix[currentRoom, aux] != 0)
                    {   
                        controller.roomArray[aux].SetActive(true);
                        activeRooms.Add(aux);
                    }
                    aux = 0;
                    vecAux = new Vector2Int(-1, 0);
                    foundValue = controller.ocupiedSpaces.TryGetValue(playerGridPos + vecAux, out aux);
                    if (foundValue && controller.roomMatrix[currentRoom, aux] != 0)
                    {
                        controller.roomArray[aux].SetActive(true);
                        activeRooms.Add(aux);
                    }
                    aux = 0;
                    vecAux = new Vector2Int(0, 1);
                    foundValue = controller.ocupiedSpaces.TryGetValue(playerGridPos + vecAux, out aux);
                    if (foundValue && controller.roomMatrix[currentRoom, aux] != 0)
                    {
                        controller.roomArray[aux].SetActive(true);
                        activeRooms.Add(aux);
                    }
                    aux = 0;
                    vecAux = new Vector2Int(0, -1);
                    foundValue = controller.ocupiedSpaces.TryGetValue(playerGridPos + vecAux, out aux);
                    if (foundValue && controller.roomMatrix[currentRoom, aux] != 0)
                    {
                        controller.roomArray[aux].SetActive(true);
                        activeRooms.Add(aux);
                    }

                    aux = 0;
                    vecAux = new Vector2Int(1, 0);
                    foundValue = controller.ocupiedSpaces.TryGetValue(previousGridPos + vecAux, out aux);
                    if (foundValue && vecAux != enterDir && !activeRooms.Contains(aux))
                    {
                        controller.roomArray[aux].SetActive(false);
                    }
                    aux = 0;
                    vecAux = new Vector2Int(-1, 0);
                    foundValue = controller.ocupiedSpaces.TryGetValue(previousGridPos + vecAux, out aux);
                    if (foundValue && vecAux != enterDir && !activeRooms.Contains(aux))
                    {
                        controller.roomArray[aux].SetActive(false);
                    }
                    aux = 0;
                    vecAux = new Vector2Int(0, 1);
                    foundValue = controller.ocupiedSpaces.TryGetValue(previousGridPos + vecAux, out aux);
                    if (foundValue && vecAux != enterDir && !activeRooms.Contains(aux))
                    {
                        controller.roomArray[aux].SetActive(false);
                    }
                    aux = 0;
                    vecAux = new Vector2Int(0, -1);
                    foundValue = controller.ocupiedSpaces.TryGetValue(previousGridPos + vecAux, out aux);
                    if (foundValue && vecAux != enterDir && !activeRooms.Contains(aux))
                    {
                        controller.roomArray[aux].SetActive(false);
                    }


                    controller.roomArray[currentRoom].SetActive(true);
                    controller.roomArray[previousRoom].SetActive(true);

                }
            }
        }


        if (controller.lightDistanceOptimization)
        {
            controller.roomArray[currentRoom].GetComponent<RoomController>().turnOnCloseLights(transform.position);
        }


        previousGridPos.x = playerGridPos.x;
        previousGridPos.y = playerGridPos.y;

        previousRoom = currentRoom;
    }
}
