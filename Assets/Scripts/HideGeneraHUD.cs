using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideGeneraHUD : MonoBehaviour
{
    void Awake()
    {
        SceneManager.sceneUnloaded += activateHUD;
    }

    void activateHUD<Scene>(Scene scene)
    {
        UIManager.UIM.generalHUD.SetActive(true);
        SceneManager.sceneUnloaded -= activateHUD;
    }

    void Start()
    {
        UIManager.UIM.generalHUD.SetActive(false);
        UIManager.UIM.generatingLevel1.SetActive(false);
        UIManager.UIM.generatingLevel2.SetActive(false);
    }
}
