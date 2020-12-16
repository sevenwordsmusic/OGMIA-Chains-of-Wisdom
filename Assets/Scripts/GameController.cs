using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameController : MonoBehaviour
{
    LevelInfoWrapper[] levelInfos;
    [SerializeField] GameObject player;
    int currentLevel = -1;
    LevelController currentLvlController;

    [SerializeField] Vector3 startPos;

    [CustomEditor(typeof(GameController))]
    public class ObjectBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameController myScript = (GameController)target;
            if (GUILayout.Button("Go To HUB"))
            {
                myScript.goToHUB();
            }

            if (GUILayout.Button("Go To Level 1"))
            {
                myScript.goToLevel(1);
            }

            if (GUILayout.Button("Save Level 1"))
            {
                myScript.saveLevel(1);
            }
        }
    }

    void goToHUB()
    {
        currentLevel = -1;
        currentLvlController = null;
        player.GetComponent<PlayerTracker>().enabled = false;
        player.transform.position = startPos;
        SceneManager.LoadScene("MidNightsDream");
    }

    void goToLevel(int num)
    {
        if(levelInfos[num] == null)
        {
            print("generating new Level " + num);
            levelInfos[num] = new LevelInfoWrapper(55, true, 25, 0, new Vector3(0, 1.28f, 0));
            levelInfos[num].printInfo();
        }
        else
        {
            levelInfos[num].printInfo();
        }
        currentLevel = num;
        SceneManager.LoadScene("test");
    }

    void saveLevel(int num)
    {
        if (currentLvlController == null)
        {
            Debug.LogError("NOT IN LEVEL SCENE");
        }
        else
        {
            bool[] auxCompletedRooms = new bool[currentLvlController.roomAmount];
            for(int i=0; i<currentLvlController.roomAmount; i++)
            {
                auxCompletedRooms[i] = currentLvlController.roomArray[i].GetComponent<RoomController>().completedBefore;
            }
            LevelInfoWrapper levelInfo = new LevelInfoWrapper(currentLvlController.roomSeed, false, currentLvlController.roomAmount, player.GetComponent<PlayerTracker>().getCurrentId(), player.transform.position, auxCompletedRooms);
            levelInfos[num] = levelInfo;
        }
    }

    public void readyForInitialization(LevelController levelController)
    {
        currentLvlController = levelController;
        print(currentLevel);
        currentLvlController.enabled = true;
        currentLvlController.initAllLevelValues(levelInfos[currentLevel]);
        currentLvlController.startLevelGeneration();
    }

    public void initializePlayerWhenReady(Vector3 pos, int cRoom, int pRoom)
    {
        player.transform.position = pos;
        player.GetComponent<PlayerTracker>().enabled = true;
        player.GetComponent<PlayerTracker>().initializePlayerTracker(currentLvlController, cRoom, pRoom);
    }

    public class LevelInfoWrapper{
        public int levelSeed;
        public bool firstTime;
        public int levelRoomsAmount;
        public int playerRoomId;
        public Vector3 playerPos;
        public bool showStartRoom;
        public bool[] completedRooms;

        public LevelInfoWrapper()
        {
            levelSeed = 55;
            firstTime = true;
            levelRoomsAmount = 25;
            playerRoomId = 0;
            playerPos = new Vector3(0,1.28f,0);
            completedRooms = new bool[levelRoomsAmount];
            for(int i=0; i< completedRooms.Length; i++)
            {
                completedRooms[i] = false;
            }
        }

        public LevelInfoWrapper(int lvlS, bool fT, int lvlRmA, int plRmId, Vector3 pPos)
        {
            levelSeed = lvlS;
            firstTime = fT;
            levelRoomsAmount = lvlRmA;
            playerRoomId = plRmId;
            playerPos = pPos;
            completedRooms = new bool[levelRoomsAmount];
            for (int i = 0; i < completedRooms.Length; i++)
            {
                completedRooms[i] = false;
            }
        }

        public LevelInfoWrapper(int lvlS, bool fT, int lvlRmA, int plRmId, Vector3 pPos, bool[] complRms)
        {
            levelSeed = lvlS;
            firstTime = fT;
            levelRoomsAmount = lvlRmA;
            playerRoomId = plRmId;
            playerPos = pPos;
            completedRooms = complRms;
        }

        public void printInfo()
        {
            print("Level Seed: " + levelSeed + " , Room Amount: " + levelRoomsAmount + " , Spawning Player in Room : " + playerRoomId + " at Position: " + playerPos);
            for (int i = 0; i < completedRooms.Length; i++)
            {
                print("Room: " + i + " Completed: " + completedRooms[i]);
            }
        }
    }
    void Start()
    {

        levelInfos = new LevelInfoWrapper[3];
        for(int i=0; i< levelInfos.Length; i++)
        {
            levelInfos[i] = null;
        }
    }
}
