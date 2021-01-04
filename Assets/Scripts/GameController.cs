using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameController : MonoBehaviour
{
    LevelInfoWrapper[] levelInfos;
    [SerializeField] GameObject player;
    public int currentLevel = 0;
    LevelController currentLvlController;

    [SerializeField] Vector3 startPos;

    /*[CustomEditor(typeof(GameController))]
    public class ObjectBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameController myScript = (GameController)target;
            if (GUILayout.Button("Go To HUB"))
            {
                myScript.goToHUBInspector();
            }

            if (GUILayout.Button("Go To Level 1"))
            {
                myScript.goToLevel(1);
            }

            if (GUILayout.Button("Save Level 1"))
            {
                myScript.saveLevel();
            }
        }
    }*/

    public void goToHUB()
    {
        currentLevel = 0;
        currentLvlController = null;
        player.GetComponent<PlayerTracker>().enabled = false;
        player.transform.position = startPos;
    }

    public void goToHUBInspector()
    {
        goToHUB();
        SceneManager.LoadScene("MidNightsDream");
    }



    public void goToLevel(int num)
    {
        currentLevel = num;
        if (levelInfos[num] == null)
        {

            switch (num)
            {
                case 1:
                    print("generating new Level " + num);
                    levelInfos[num] = new LevelInfoWrapper(124, true, 20, 0, new Vector3(0, 1.28f, 0));
                    levelInfos[num].printInfo();
                    //SceneManager.LoadScene("level_1");
                    break;
                case 2:
                    print("generating new Level " + num);
                    levelInfos[num] = new LevelInfoWrapper(55, true, 30, 0, new Vector3(0, 1.28f, 0));
                    levelInfos[num].printInfo();
                    //SceneManager.LoadScene("level_2");
                    break;
                case 3:
                    print("generating new Level " + num);
                    levelInfos[num] = new LevelInfoWrapper(67867, true, 50, 0, new Vector3(0, 1.28f, 0));
                    levelInfos[num].printInfo();
                    //SceneManager.LoadScene("level_3");
                    break;
            }
        }
        else
        {
            levelInfos[num].printInfo();
            /*switch (num)
            {
                case 1:
                    SceneManager.LoadScene("level_1");
                    break;
                case 2:
                    SceneManager.LoadScene("level_2");
                    break;
                case 3:
                    SceneManager.LoadScene("level_3");
                    break;
            }*/
        }
    }

    public void resetInfo()
    {
        for (int i = 0; i < levelInfos.Length; i++)
        {
            levelInfos[i] = null;
        }
    }

    public void saveLevel()
    {
        if (currentLvlController == null)
        {
            Debug.LogError("NOT IN LEVEL SCENE");
        }
        else
        {
            print("saving game");
            bool[] auxCompletedRooms = new bool[currentLvlController.roomAmount];
            for(int i=0; i<currentLvlController.roomAmount; i++)
            {
                auxCompletedRooms[i] = currentLvlController.roomArray[i].GetComponent<RoomController>().completedBefore;
            }
            LevelInfoWrapper levelInfo = new LevelInfoWrapper(currentLvlController.roomSeed, false, currentLvlController.roomAmount, player.GetComponent<PlayerTracker>().getCurrentId(), player.transform.position, auxCompletedRooms);
            levelInfos[currentLevel] = levelInfo;


            for(int i=0; i<levelInfos.Length; i++)
            {
                if(levelInfos[i] != null) { 
                    string saveData = "";
                    saveData += (levelInfos[i].levelSeed + "@");
                    saveData += (levelInfos[i].firstTime + "@");
                    saveData += (levelInfos[i].levelRoomsAmount + "@");
                    saveData += (levelInfos[i].playerRoomId + "@");
                    saveData += (levelInfos[i].playerPos.x + "@");
                    saveData += (levelInfos[i].playerPos.y + "@");
                    saveData += (levelInfos[i].playerPos.z + "@");

                    string arrayAux = "";
                    foreach (bool completed in levelInfos[i].completedRooms)
                    {
                        arrayAux += (completed + "#");
                    }

                    saveData += (arrayAux + "@");

                    print(saveData);

                    PlayerPrefs.SetString("levelData" + i, saveData);
                }
            }
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

        levelInfos = new LevelInfoWrapper[4];

        string defValue = "null";
        for(int i=0; i< levelInfos.Length; i++)
        {
            string levelData = PlayerPrefs.GetString("levelData" + i, defValue);
            if (levelData.Equals(defValue))
            {
                levelInfos[i] = null;
            }
            else
            {
                //print(levelData);
                string[] infoAuxArray = levelData.Split('@');
                LevelInfoWrapper infoAux = new LevelInfoWrapper(int.Parse(infoAuxArray[0]), bool.Parse(infoAuxArray[1]), int.Parse(infoAuxArray[2]), int.Parse(infoAuxArray[3]), new Vector3(float.Parse(infoAuxArray[4]), float.Parse(infoAuxArray[5]), float.Parse(infoAuxArray[6])));

                string[] roomInfoArray = infoAuxArray[7].Split('#');
                bool[] roomInfoBools = new bool[roomInfoArray.Length-1];
                for(int j=0; j< roomInfoBools.Length; j++)
                {
                    roomInfoBools[j] = bool.Parse(roomInfoArray[j]);
                }

                infoAux.completedRooms = roomInfoBools;
                

                levelInfos[i] = infoAux;
            }
        }
    }
}
