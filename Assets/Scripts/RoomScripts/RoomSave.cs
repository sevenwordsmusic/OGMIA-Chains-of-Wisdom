using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RoomController))]
public class RoomSave : MonoBehaviour
{
    void Start()
    {
        RoomController roomController = GetComponent<RoomController>();
        roomController.enteredRoom += roomController.getLevelController().saveGameState;
    }
}
