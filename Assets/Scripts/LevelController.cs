using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("Level Settings")]
    public int roomSeed = 123;
    public int roomAmount = 20;
    [HideInInspector] public int currentRoomAmount = 0;
    [Range(0, 1)] public float levelShape = 0.5f;
    [Range(0, 1)] public float interconectivity = 0.2f;
    [Range(0.03f, 2)] public float generationTime = 0.3f;

    [Header("Room Settings")]
    public GameObject initRoom;
    public List<GameObject> rooms = new List<GameObject>();
    [HideInInspector] public GameObject lastRoom;
    //[HideInInspector] public HashSet<Vector2Int> ocupiedSpaces = new HashSet<Vector2Int>(new spaceComparer());
    [HideInInspector] public Dictionary<Vector2Int, int> ocupiedSpaces = new Dictionary<Vector2Int, int>(new spaceComparer());
    [HideInInspector] public GameObject[] roomArray;
    [HideInInspector] public int[,] debugMatrix;            //DEBUG
    //[HideInInspector] public int[,] spaceMatrix;
    Vector2Int spaceMatrixMidPoint;

    [Header("Debug Settings")]
    public bool debug = false;
    float nodeSize = 1.5f;
    Color nodeColor = Color.magenta;
    float lineWidth = 5;
    Color baseLineColor = Color.white;
    Color interconectedLineColor = Color.black;
    float debugOffset = 2.5f;

    [CustomEditor(typeof(LevelController))]
    public class MyScriptEditor : Editor
    {
        override public void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var lvlInspector = target as LevelController;

            if (lvlInspector.debug)
            {
                lvlInspector.nodeSize = EditorGUILayout.FloatField("Node Size", lvlInspector.nodeSize);
                lvlInspector.nodeColor = EditorGUILayout.ColorField("Node Color", lvlInspector.nodeColor);
                lvlInspector.lineWidth = EditorGUILayout.FloatField("Debug Offset", lvlInspector.lineWidth);
                lvlInspector.baseLineColor = EditorGUILayout.ColorField("Base Line Color", lvlInspector.baseLineColor);
                lvlInspector.interconectedLineColor = EditorGUILayout.ColorField("Interconected Line Color", lvlInspector.interconectedLineColor);
                lvlInspector.debugOffset = EditorGUILayout.FloatField("Debug Offset", lvlInspector.debugOffset);
            }

        }
    }

    class spaceComparer : IEqualityComparer<Vector2Int> { 
        public bool Equals(Vector2Int a, Vector2Int b)
        {
            //print("Comparing: (" + a.x + "," + b.x + ") with (" + a.y + "," + b.y + ")");
            return ((a.x == b.x) && (a.y == b.y));
        }
        public int GetHashCode(Vector2Int vec)
        {
            return vec.GetHashCode();
        }
    }

    private void Start()
    {
        print("level controler start");

        roomArray = new GameObject[roomAmount];
        /*spaceMatrix = new int[roomAmount * 2 - 1, roomAmount * 2 - 1];
        for (int i = 0; i < roomAmount * 2 - 1; i++)
        {
            for (int j = 0; j < roomAmount * 2 - 1; j++)
            {
                spaceMatrix[i, j] = -1;
            }
        }*/

        spaceMatrixMidPoint = new Vector2Int(roomAmount-1, roomAmount-1);

        //DEBUG
        debugMatrix = new int[roomAmount, roomAmount];
        for(int i=0; i<roomAmount; i++)
        {
            for(int j=0; j<roomAmount; j++)
            {
                debugMatrix[i, j] = 0;
            }
        }
        //DEBUG

        if(roomSeed != -1)
            Random.InitState(roomSeed);

        foreach (Transform centerP in initRoom.GetComponent<RoomController>().getCenterPos())
        {
            ocupiedSpaces.Add(new Vector2Int(Mathf.RoundToInt(centerP.transform.position.x / 20), Mathf.RoundToInt(centerP.transform.position.z / 20)), 0);
        }

        //setOcupiedSpace(new Vector2Int(0, 0), 0);
        currentRoomAmount++;

        var roomAux = Instantiate(initRoom, transform.position, Quaternion.identity, transform);
        roomAux.GetComponent<RoomController>().adjustId();
        roomAux.GetComponent<RoomController>().levelInitialize();
    }

    public void endFirstGenerationWave()
    {
        StartCoroutine(startSecondGemerationWave());
    }

    IEnumerator startSecondGemerationWave()
    {
        yield return new WaitForSeconds(generationTime);
        foreach(GameObject room in roomArray)
        {
            room.GetComponent<RoomController>().secondGeneration();
        }
        /*foreach (GameObject room in roomArray)
        {
            room.GetComponent<RoomController>().thirdGeneration();
        }*/
    }

    /*public void setOcupiedSpace(Vector2Int vPos, int roomId)
    {
        int normalizedPosX = vPos.x + spaceMatrixMidPoint.x;
        int normalizedPosY = vPos.y + spaceMatrixMidPoint.y;
        if((0 < normalizedPosX && normalizedPosX < roomAmount*2-1) && (0 < normalizedPosY && normalizedPosY < roomAmount * 2 - 1))
            spaceMatrix[normalizedPosY , normalizedPosX] = roomId;
    }

    public int getOcupiedSpace(Vector2Int vPos)
    {
        int normalizedPosX = vPos.x + spaceMatrixMidPoint.x;
        int normalizedPosY = vPos.y + spaceMatrixMidPoint.y;
        if ((0 < normalizedPosX && normalizedPosX < roomAmount * 2 - 1) && (0 < normalizedPosY && normalizedPosY < roomAmount * 2 - 1))
            return spaceMatrix[normalizedPosY, normalizedPosX];
        else
            return -2;
    }

    public void printSpaceMatrix()
    {
        print("______________________________________________________________________________");
        string aux = "";
        for (int i = 0; i < roomAmount * 2 - 1; i++)
        {
            for (int j = 0; j < roomAmount * 2 - 1; j++)
            {
                aux += (spaceMatrix[i, j] + "  ");
            }
            print(aux);
            aux = "";
        }
        print("______________________________________________________________________________");
    }*/

    public void debugEdge(int idA, int idB, int value)
    {
        debugMatrix[idA, idB] = value;
        debugMatrix[idB, idA] = value;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = nodeColor;
        if (debug && Application.isPlaying)
        {
            for(int i=0; i<roomAmount; i++)
            {
                for(int j=i+1; j<roomAmount; j++)
                {
                    if (debugMatrix[i, j] == 1) {

                        Vector3 aux_i = new Vector3(roomArray[i].transform.position.x, roomArray[i].transform.position.y + debugOffset + nodeSize / 2, roomArray[i].transform.position.z);
                        Vector3 aux_j = new Vector3(roomArray[j].transform.position.x, roomArray[j].transform.position.y + debugOffset + nodeSize / 2, roomArray[j].transform.position.z);
                        Handles.DrawBezier(aux_i, aux_j, aux_i, aux_j, baseLineColor, null, lineWidth);
                    }
                    else if (debugMatrix[i, j] == 2)
                    {
                        Vector3 aux_i = new Vector3(roomArray[i].transform.position.x, roomArray[i].transform.position.y + debugOffset + nodeSize / 2, roomArray[i].transform.position.z);
                        Vector3 aux_j = new Vector3(roomArray[j].transform.position.x, roomArray[j].transform.position.y + debugOffset + nodeSize / 2, roomArray[j].transform.position.z);
                        Handles.DrawBezier(aux_i, aux_j, aux_i, aux_j, interconectedLineColor, null, lineWidth);
                    }
                }
            }
            foreach (GameObject room in roomArray)
            {   
                if(room != null)
                    Gizmos.DrawSphere(new Vector3(room.transform.position.x, room.transform.position.y + debugOffset, room.transform.position.z), nodeSize);
            }
        }
    }
}
