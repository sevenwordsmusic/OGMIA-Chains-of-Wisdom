using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressTracker : MonoBehaviour
{
    //SINGLETON
    public static ProgressTracker PT;

    public int numberOfPieces; //Numero de esquirlas de amuleto que tiene el jugador.
    public GameObject Amulet;
    private Image AmuletImage;
    public Sprite[] amuletSprites; //recipiente de sprites temporales para el amuleto


    private void Awake()
    {
        if (PT != null) //Si por algún motivo ya existe un combatManager...
        {
            GameObject.Destroy(PT); //Este script lo mata. Solo puede haber una abeja reina en la colmena.
        }
        else //En caso de que el trono esté libre...
        {
            PT = this; //Lo toma para ella!
        }

        DontDestroyOnLoad(this); //Ah, y no destruyas esto al cargar
    }

    // Start is called before the first frame update
    void Start()
    {
        //Amulet = GameObject.FindGameObjectWithTag("Amulet");
        AmuletImage = Amulet.GetComponent<Image>();
        Amulet.SetActive(false);
        if(!PlayerPrefs.HasKey("numberOfPieces"))
        {
            numberOfPieces = 0;
            PlayerPrefs.SetInt("numberOfPieces", numberOfPieces);
        }
    }


    public void addPiece()
    {
        numberOfPieces++;
        PlayerPrefs.SetInt("numberOfPieces", numberOfPieces);

        switch(numberOfPieces)
        {
            case 1:
                Amulet.gameObject.SetActive(true);
                break;

            case 2:
                //amuleto con 1 esquirla
                AmuletImage.sprite = amuletSprites[0];
                break;

            case 3:
                //amuleto con 2 esquirla
                AmuletImage.sprite = amuletSprites[1];
                break;

            case 4:
                //amuleto con 3 esquirla
                AmuletImage.sprite = amuletSprites[2];
                break;

            case 5:
                //amuleto con 4 esquirla
                AmuletImage.sprite = amuletSprites[3];
                break;

            case 6:
                //amuleto con 5 esquirla
                AmuletImage.sprite = amuletSprites[4];
                break;

            case 7:
                //amuleto COMPLETO
                AmuletImage.sprite = amuletSprites[5];
                break;

            default:
                print("something went wrong here..." + numberOfPieces + " fragments");
                break;



        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
