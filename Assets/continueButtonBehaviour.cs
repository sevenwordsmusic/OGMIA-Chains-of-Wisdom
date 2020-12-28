using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers;

public class continueButtonBehaviour : MonoBehaviour
{

    [SerializeField] int saveSlotToCheck;

    // Start is called before the first frame update
    void Start()
    {
        if (SaveSystem.HasSavedGameInSlot(saveSlotToCheck))
        {
            this.gameObject.SetActive(true);
        } 
        else
        {
            this.gameObject.SetActive(false);
        }     
    }

    private void OnEnable()
    {
        if (SaveSystem.HasSavedGameInSlot(saveSlotToCheck))
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
