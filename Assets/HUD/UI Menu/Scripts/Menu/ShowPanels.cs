using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShowPanels : MonoBehaviour {

	public GameObject PauseOptionsPanel;                         //Store a reference to the Game Object OptionsPanel 
	public GameObject MenuOptionsPanel;
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;                           //Store a reference to the Game Object PausePanel 
	public GameObject creditsPanel;

	private GameObject activePanel;                         
    private MenuObject activePanelMenuObject;
    private EventSystem eventSystem;



    private void SetSelection(GameObject panelToSetSelected)
    {

        activePanel = panelToSetSelected;
        activePanelMenuObject = activePanel.GetComponent<MenuObject>();
        if (activePanelMenuObject != null)
        {
            activePanelMenuObject.SetFirstSelected();
        }
    }

    public void Start()
    {
        SetSelection(menuPanel);
    }

	public void ShowCreditsPanel()
    {
		PauseOptionsPanel.SetActive(false);
		optionsTint.SetActive(false);
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
		optionsTint.SetActive(true);
        menuPanel.SetActive(false);
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
		optionsTint.SetActive(false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
		menuPanel.SetActive (true);
        SetSelection(menuPanel);
    }

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);

	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
        SetSelection(pausePanel);
    }

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);

	}
}
