using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers;
using PixelCrushers.DialogueSystem;

public class TutorialController : MonoBehaviour
{
    private bool coreFound;
    bool amuletSanityCheck = false;

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
            if (!amuletSanityCheck)
            {
                amuletSanityCheck = true;
                //Play cool ending cutscene for tutorial
                ProgressTracker.PT.addPiece();
                this.gameObject.SetActive(false);
                //SaveSystem.LoadScene("MidNightsDream");
            }
        }
    }

    private void coreMissingCutscene()
    {
        DialogueManager.StartConversation("Tutorial_Core_Missing");
    }

}
