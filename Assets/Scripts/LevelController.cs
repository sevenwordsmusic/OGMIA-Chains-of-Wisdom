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
    public static int baseRoomeSize = 20;
    public GameObject initRoom;
    public List<GameObject> rooms = new List<GameObject>();
    [HideInInspector] public GameObject lastRoom;
    //[HideInInspector] public HashSet<Vector2Int> ocupiedSpaces = new HashSet<Vector2Int>(new spaceComparer());
    [HideInInspector] public Dictionary<Vector2Int, int> ocupiedSpaces = new Dictionary<Vector2Int, int>(new spaceComparer());
    [HideInInspector] public GameObject[] roomArray;
    [HideInInspector] public int[,] roomMatrix;            //DEBUG
    //[HideInInspector] public int[,] spaceMatrix;
    Vector2Int spaceMatrixMidPoint;

    [Header("Optimization Settings")]
    public bool optimization = false;
    public bool showExtraRooms = false;
    public bool lightOptimiation = false;
    public bool lightDistanceOptimization = false;
    public float lightUpDistance = 10f;

    [Header("Debug Settings")]
    public bool debug = false;
    [SerializeField] float nodeSize = 1.5f;
    [SerializeField] Color nodeColor = Color.magenta;
    [SerializeField] float lineWidth = 5;
    [SerializeField] Color baseLineColor = Color.white;
    [SerializeField] Color interconectedLineColor = Color.black;
    [SerializeField] float debugOffset = 2.5f;

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

        roomMatrix = new int[roomAmount, roomAmount];
        for (int i = 0; i < roomAmount; i++)
        {
            for (int j = 0; j < roomAmount; j++)
            {
                roomMatrix[i, j] = 0;
            }
        }

        if(roomSeed != -1)
            Random.InitState(roomSeed);

        foreach (Transform centerP in initRoom.GetComponent<RoomController>().getCenterPos())
        {
            ocupiedSpaces.Add(new Vector2Int(Mathf.RoundToInt(centerP.transform.position.x / LevelController.baseRoomeSize), Mathf.RoundToInt(centerP.transform.position.z / LevelController.baseRoomeSize)), 0);
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
        levelFinished();
        /*foreach (GameObject room in roomArray)
        {
            room.GetComponent<RoomController>().thirdGeneration();
        }*/
    }

    void levelFinished()
    {
        if (optimization)
        {
            for(int i=1; i< roomArray.Length; i++)
            {
                roomArray[i].SetActive(false);
            }
            if (showExtraRooms)
            {
                int aux = 0;
                if (ocupiedSpaces.TryGetValue(new Vector2Int(1, 0), out aux))
                    roomArray[aux].SetActive(true);
                aux = 0;
                if (ocupiedSpaces.TryGetValue(new Vector2Int(-1, 0), out aux))
                    roomArray[aux].SetActive(true);
                aux = 0;
                if (ocupiedSpaces.TryGetValue(new Vector2Int(0, 1), out aux))
                    roomArray[aux].SetActive(true);
                aux = 0;
                if (ocupiedSpaces.TryGetValue(new Vector2Int(0, -1), out aux))
                    roomArray[aux].SetActive(true);
            }
        }
    }

    public void debugEdge(int idA, int idB, int value)
    {
        roomMatrix[idA, idB] = value;
        roomMatrix[idB, idA] = value;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = nodeColor;
        if (debug && Application.isPlaying && roomMatrix != null)
        {
            for(int i=0; i<roomAmount; i++)
            {
                for(int j=i+1; j<roomAmount; j++)
                {
                    if (roomMatrix[i, j] == 1) {

                        Vector3 aux_i = new Vector3(roomArray[i].transform.position.x, roomArray[i].transform.position.y + debugOffset + nodeSize / 2, roomArray[i].transform.position.z);
                        Vector3 aux_j = new Vector3(roomArray[j].transform.position.x, roomArray[j].transform.position.y + debugOffset + nodeSize / 2, roomArray[j].transform.position.z);
                        Handles.DrawBezier(aux_i, aux_j, aux_i, aux_j, baseLineColor, null, lineWidth);
                    }
                    else if (roomMatrix[i, j] == 2)
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
    }*/
}
