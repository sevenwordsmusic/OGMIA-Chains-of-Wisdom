using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    enum PosibleDir { Up, Down, Right, Left }
    [SerializeField] PosibleDir direction = PosibleDir.Up;
    [HideInInspector] public bool isGate = false;
    [SerializeField] GameObject gateObj;
    [SerializeField] GameObject wallObj;

    public void adjustDirection(int angle)
    {
        Vector2Int dir = getDirection();
        Vector3 aux = new Vector3(dir.x, 0, dir.y);
        aux = Quaternion.Euler(0, angle, 0) * aux;
        dir.x = Mathf.RoundToInt(aux.x);
        dir.y = Mathf.RoundToInt(aux.z);

        if (dir.x != 0 || dir.y != 0)
        {
            if(dir.x == 1)
            {
                direction = PosibleDir.Right;
            }
            else if(dir.x == -1)
            {
                direction = PosibleDir.Left;
            }
            else if (dir.y == 1)
            {
                direction = PosibleDir.Up;
            }
            else if (dir.y == -1)
            {
                direction = PosibleDir.Down;
            }
        }
    }

    public Vector2Int getDirection()
    {
        switch (direction)
        {
            case PosibleDir.Up:
                return new Vector2Int(0, 1);
            case PosibleDir.Down:
                return new Vector2Int(0, -1);
            case PosibleDir.Right:
                return new Vector2Int(1, 0);
            case PosibleDir.Left:
                return new Vector2Int(-1, 0);
        }
        return Vector2Int.zero;
    }

    public void setDirection(Vector2Int dirr)
    {
        if(dirr.x == 1)
        {
            direction = PosibleDir.Right;
        }
        else if (dirr.x == -1)
        {
            direction = PosibleDir.Left;
        }
        else if (dirr.y == 1)
        {
            direction = PosibleDir.Up;
        }
        else if (dirr.y == -1)
        {
            direction = PosibleDir.Down;
        }
        else
        {
            Debug.LogError("Something went wrong with setDirection()");
        }
    }

    int vecAngle()
    {
        switch (direction)
        {
            case PosibleDir.Up:
                return 90;
            case PosibleDir.Down:
                return -90;
            case PosibleDir.Right:
                return 0;
            case PosibleDir.Left:
                return 180;
        }
        return 0;
    }

    public void initializeGate()
    {
        isGate = true;
        gateObj.SetActive(true);
        wallObj.SetActive(false);
    }
    /*public void initializeGateTest()
    {
        isGate = true;
        gateObj.SetActive(true);
        wallObj.SetActive(false);
        gateObj.GetComponent<MeshRenderer>().material = null;
    }*/
    public void initializeWall()
    {
        isGate = false;
        wallObj.SetActive(true);
        gateObj.SetActive(false);
    }
}
