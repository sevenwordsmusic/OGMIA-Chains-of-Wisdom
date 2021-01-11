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
    private Vector3 oldPosition;
    public bool playCutscene;
    public Camera testingCamera;
    public CinemachineVirtualCamera cinemaCam;
    private CinemachineBrain cinemachineBrain;
    private float oldBlendTime;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();
        testingCamera.gameObject.SetActive(false);

        PlayerPrefs.SetInt("firstTimeMD", 0); //Esta variable se comprobara en el sueño de medianoche par alanzar la cutscene de primera vez

        if (playCutscene)
        {
            characterController.enabled = false;
            player.transform.position = hiddenPos.position;
            characterController.enabled = true;

            //player.gameObject.SetActive(false);

            UIManager.UIM.HideGeneralHUD();

            //PROGRAMAR CORTE INSTANTANEO DE CAMARA
            cinemachineBrain = FindObjectOfType<CinemachineBrain>();
            oldBlendTime = cinemachineBrain.m_DefaultBlend.m_Time;
            cinemachineBrain.m_DefaultBlend.m_Time = 0;

            cinemaCam.Priority = 9000;

            initialCutscene.Play();
        }
        else
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


    public void deactivatePlayer()
    {
        oldPosition = player.transform.position;

        characterController.enabled = false;
        player.transform.position = hiddenPos.position;
        characterController.enabled = true;
    }

    public void activatePlayer()
    {
        characterController.enabled = false;
        player.transform.position = oldPosition;
        characterController.enabled = true;
    }

    public void placePlayerOnInitialPos()
    {
        characterController.enabled = false;
        player.transform.position = initialPos.position;
        characterController.enabled = true;

        cinemaCam.Priority = 0; //Eliminamos la prioridad de camara, ya innecesaria

        //Restablecemos el blend time para evitar cortes indeseados.
        cinemachineBrain.m_DefaultBlend.m_Time = oldBlendTime;
        player.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
