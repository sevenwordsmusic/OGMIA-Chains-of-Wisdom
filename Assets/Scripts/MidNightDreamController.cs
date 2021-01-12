using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using PixelCrushers;
using UnityEngine.SceneManagement;
using Cinemachine;

public class MidNightDreamController : MonoBehaviour
{
    private GameObject player;
    private CharacterController characterController;
    [SerializeField] Transform startPos;
    [SerializeField] Transform hiddenPos;
    [SerializeField] GameObject playerDouble;
    [SerializeField] GameObject cutsceneCamera;
    [SerializeField] CinemachineVirtualCamera cinemaCam;
    [SerializeField] PlayableDirector normalIntroCutscene;
    [SerializeField] PlayableDirector firstTimeIntroCutscene;
    [SerializeField] PlayableDirector endGameCutscene;
    [Tooltip("Si es true, teletransporta al jugador a este punto al iniciarse esta escena")] public bool warpPlayerHereAtStart;


    [SerializeField] BoxCollider entranceLvl2;
    [SerializeField] List<GameObject> effectsLvl2;

    private CinemachineBrain cinemachineBrain;
    private float oldBlendTime;


    private void Awake()
    {
        cutsceneCamera.SetActive(false);

        //Escondemos al jugador durante la cutscene introductoria
        if(player == null || characterController == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            characterController = player.GetComponent<CharacterController>();
        }
        characterController.enabled = false;
        player.transform.position = hiddenPos.position;
        characterController.enabled = true;
        player.gameObject.SetActive(false);

        //Escondemos la interfaz durante la escena
        UIManager.UIM.HideGeneralHUD();

        //PROGRAMAR CORTE INSTANTANEO DE CAMARA
        cinemachineBrain = FindObjectOfType<CinemachineBrain>();
        oldBlendTime = cinemachineBrain.m_DefaultBlend.m_Time;
        cinemachineBrain.m_DefaultBlend.m_Time = 0;

        cinemaCam.Priority = 9000;

        if (PlayerPrefs.GetInt("numberOfPieces") == 2 && PlayerPrefs.GetInt("firstTimeMD") == 0) //Si tiene solo el 'nucleo' y es la primera visita del jugador al sueño de medianoche...
        {
            //Lanzamos la cutscene de introduccion al sueño de medianoche
            PlayerPrefs.SetInt("firstTimeMD", 1); //Evitamos que esta cutscene se vuelva a reproducir en el futuro
            firstTimeIntroCutscene.Play();
        }
        else if (PlayerPrefs.GetInt("numberOfPieces") >= 6) //Si los tiene todos
        {
            //Lanzamos la cutscene final del juego
            endGameCutscene.Play();
        } 
        else
        {
            normalIntroCutscene.Play();
            //endGameCutscene.Play();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //if (warpPlayerHereAtStart)
        //{
        //    if (player == null || characterController == null)
        //    {
        //        player = GameObject.FindGameObjectWithTag("Player");
        //        characterController = player.GetComponent<CharacterController>();
        //    }
        //    characterController.enabled = false;
        //    player.transform.position = this.transform.position;
        //    characterController.enabled = true;

        //    //SAVE THE GAME
        //    SaveSystem.SaveToSlot(1);
        //    //ToDo: mensaje de 'partida guardada con exito'
        //}

        if(ProgressTracker.PT.numberOfPieces >= 3)
        {
            entranceLvl2.enabled = true;
            foreach(GameObject gm in effectsLvl2)
            {
                gm.SetActive(true);
            }
        }
    }

    public void placePlayerAtStart()
    {
        playerDouble.SetActive(false);

        characterController.enabled = false;
        player.transform.position = startPos.position;
        characterController.enabled = true;
        player.gameObject.SetActive(true);

        cinemaCam.Priority = 0;
        //SAVE THE GAME
        SaveSystem.SaveToSlot(1);
        //ToDo: mensaje de 'partida guardada con exito'

    }


    public void EndA()
    {
        UIManager.UIM.goBackToMainMenu();
        SceneManager.LoadScene("EndA");
    }

    public void EndB()
    {
        UIManager.UIM.goBackToMainMenu();
        SceneManager.LoadScene("EndB");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
