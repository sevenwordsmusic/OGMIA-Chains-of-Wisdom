using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using PixelCrushers;

public class newGameWarningScript : MonoBehaviour
{
    public GameObject menuButtons,creditButton,newGameWarningPanel;
    public GameInitializer gameInitializer;
    public PlayableDirector introAnimation;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Se encarga de comprobar si existe una partida guardada. Si existen dichos datos, activa una ventana que avisará al jugador de que comenzar una nueva partida borrará la anterior.
    /// Dicha ventana se encargará de manejar el resto de la interacción. En caso de que no existan datos guardados, procede a iniciar una nueva partida.
    /// </summary>
    public void checkSavedGame()
    {
        if(SaveSystem.HasSavedGameInSlot(1))
        {
            menuButtons.SetActive(false);
            creditButton.SetActive(false);
            newGameWarningPanel.SetActive(true);
        } 
        else
        {
            //AUDIO
                AudioManager.engine.ChangeSegmentTo(3);
            //


            //gameInitializer.initializeGame();
            //UIManager.UIM.HideMenu();
            //UIManager.UIM.generalHUD.SetActive(true);
            //UIManager.UIM.mobileJoystick.SetActive(true);
            //GetComponent<ScenePortal>().UsePortal();
            introAnimation.Play();
        }
    }
}
