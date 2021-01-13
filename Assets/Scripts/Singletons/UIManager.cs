using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager UIM;

    public GameObject PauseOptionsPanel;
    public GameObject MenuOptionsPanel;
    public GameObject menuPanel;
    public GameObject pausePanel;
    public GameObject creditsPanel;
    public GameObject mobileJoystick;

    public GameObject generalHUD,GameOverHUD;

    public GameObject generatingLevel1;
    public GameObject generatingLevel2;

    private GameObject activePanel;
    private MenuObject activePanelMenuObject;
    private EventSystem eventSystem;
    public Pause pause;

    public delegate void UIEvent();
    public static event UIEvent goBackToMainMenuEvent; //Evento lanzado cuando el jugador muere, para causar una reacción global

    //EVENTS
    private void OnEnable()
    {
        CombatController.playerDeath += showGameOverHUD;
    }

    private void OnDisable()
    {
        CombatController.playerDeath -= showGameOverHUD;
    }


    private void Awake()
    {
        pause = GetComponent<Pause>();
        if (UIM != null) //Si por algún motivo ya existe un combatManager...
        {
            GameObject.Destroy(UIM); //Este script lo mata. Solo puede haber una abeja reina en la colmena.
            GameObject.Destroy(UIM.gameObject);
        }
        else //En caso de que el trono esté libre...
        {
            UIM = this; //Lo toma para ella!
        }

        DontDestroyOnLoad(this); //Ah, y no destruyas esto al cargar
    }

    public void Start()
    {
        SetSelection(menuPanel);
    }

    private void SetSelection(GameObject panelToSetSelected)
    {
        activePanel = panelToSetSelected;
        activePanelMenuObject = activePanel.GetComponent<MenuObject>();
        if (activePanelMenuObject != null)
        {
            activePanelMenuObject.SetFirstSelected();
        }
    }

    public void ShowCreditsPanel()
    {
        PauseOptionsPanel.SetActive(false);
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
        SetSelection(creditsPanel);
    }

    public void HideCreditsPanel()
    {
        creditsPanel.SetActive(false);
    }

    //Call this function to activate and display the Options panel during the main menu
    public void ShowOptionsPanel()
    {
        PauseOptionsPanel.SetActive(true);
        //optionsTint.SetActive(true);
        //menuPanel.SetActive(false);
        //pausePanel.SetActive(false);
        SetSelection(PauseOptionsPanel);
    }

    public void ShowMenuoptionsPanel()
    {
        MenuOptionsPanel.SetActive(true);
        //optionsTint.SetActive(true);
        menuPanel.SetActive(false);
        SetSelection(MenuOptionsPanel);
    }

    public void HideMenuOptions()
    {
        MenuOptionsPanel.SetActive(false);
    }

    //Call this function to deactivate and hide the Options panel during the main menu
    public void HideOptionsPanel()
    {
        //menuPanel.SetActive(true);
        PauseOptionsPanel.SetActive(false);
    }

    //Call this function to activate and display the main menu panel during the main menu
    public void ShowMenu()
    {
        menuPanel.SetActive(true);
        SetSelection(menuPanel);
    }

    //Call this function to deactivate and hide the main menu panel during the main menu
    public void HideMenu()
    {
        menuPanel.SetActive(false);
    }

    //Call this function to activate and display the Pause panel during game play
    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
        SetSelection(pausePanel);
    }

    //Call this function to deactivate and hide the Pause panel during game play
    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
    }

    public void HideGeneralHUD()
    {
        generalHUD.SetActive(false);
        mobileJoystick.SetActive(false);
    }

    public void ShowGeneralHUD()
    {
        generalHUD.SetActive(true);
        mobileJoystick.SetActive(true);
    }

    public void showGameOverHUD()
    {
        generalHUD.SetActive(false);
        mobileJoystick.SetActive(false);
        GameOverHUD.SetActive(true);
    }

    public void goBackToMainMenu()
    {
        if (goBackToMainMenuEvent != null)
        {
            goBackToMainMenuEvent();
            Destroy(this.gameObject);
        }
    }
}
