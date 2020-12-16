using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    public GameObject player;
    public GameObject gameController;

    void Start()
    {
        player.SetActive(true);
        gameController.SetActive(true);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(gameController);


        SceneManager.LoadScene("Tutorial");

    }
}
