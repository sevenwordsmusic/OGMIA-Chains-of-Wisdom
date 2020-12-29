using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers;

public class TutorialController : MonoBehaviour
{
    private bool coreFound;


    // Start is called before the first frame update
    void Start()
    {
        coreFound = false;
    }

    public void playerGotTheCore()
    {
        coreFound = true;
    }

    public void tutorialEndCutscene()
    {
        if (!coreFound) //Si el jugador aun no ha obtenido el nucleo del amuleto, se reproducirá una cutscene que le indique que debe encontrarlo, dandole pistas.
        {
            print("busca el nucleo, idiota.");
            coreMissingCutscene();
        } 
        else
        {
            //Play cool ending cutscene for tutorial
            print("tutorial finalizado!");
            SaveSystem.LoadScene("MidNightsDream");
        }
    }

    private void coreMissingCutscene()
    {

    }

}
