using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retryFunctions : MonoBehaviour
{
    public void retryGame()
    {
        GameObject.FindGameObjectWithTag("gameController").GetComponent<GameController>().goToHUB();
        ProgressTracker.PT.getSavedPieces();
    }
}
