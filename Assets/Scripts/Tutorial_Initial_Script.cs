using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using PixelCrushers;

public class Tutorial_Initial_Script : MonoBehaviour
{
    private GameObject player;
    private CharacterController characterController;
    public PlayableDirector initialCutscene;

    public Transform hiddenPos;
    public Transform initialPos;
    public bool playCutscene;
    public Camera cutsceneCamera;
    public CinemachineVirtualCamera cinemaCam;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();

        if(playCutscene)
        {
            characterController.enabled = false;
            player.transform.position = hiddenPos.position;
            characterController.enabled = true;

            UIManager.UIM.HideGeneralHUD();

            cutsceneCamera.gameObject.SetActive(true);
            cinemaCam.Priority = 9000;

            initialCutscene.Play();
        } else
        {
            characterController.enabled = false;
            player.transform.position = initialPos.position;
            characterController.enabled = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //GUARDADO AUTOMÁTICO
        SaveSystem.SaveToSlot(1);
    }


    public void placePlayerOnInitialPos()
    {
        characterController.enabled = false;
        player.transform.position = initialPos.position;
        characterController.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
