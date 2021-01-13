using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overlayCanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        UIManager.goBackToMainMenuEvent += destroyOverlayCanvas;
    }

    private void OnDisable()
    {
        UIManager.goBackToMainMenuEvent -= destroyOverlayCanvas;
    }


    private void destroyOverlayCanvas()
    {
        Destroy(this.gameObject);
    }

}
