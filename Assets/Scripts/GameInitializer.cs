using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    public GameObject player;
    public GameObject gameController;
    public string sceneToLoadAtStart;

    public delegate void GameEvent();
    public static event GameEvent gameInitialized; //Evento lanzado cuando el jugador muere, para causar una reacción global


    void Start()
    {
        //initializeGame();
    }

    public void initializeGame()
    {
        player.SetActive(true);
        gameController.SetActive(true);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(gameController);

        if (gameInitialized != null)
            gameInitialized();

        //if (sceneToLoadAtStart != null)
        //    SceneManager.LoadScene(sceneToLoadAtStart);
    }
}
