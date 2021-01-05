using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class ControlGuideUIController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    [SerializeField] PlayerInput playerInput;
    public GameObject PCControls;
    public GameObject MobileControls;
    public GameObject ControllerControls;

    public bool isMobile()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            return IsMobile();
        #endif
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //playerInput = FindObjectOfType<PlayerInput>();

        if(isMobile()) //Si estamos en movil
        {
            //Mostramos los controles de movil y nos olvidamos del resto
            PCControls.SetActive(false);
            ControllerControls.SetActive(false);
            MobileControls.SetActive(true);
        } 
        else
        {
            //En otro caso, simplemente mostramos los de PC por defecto, y comprobamos activamente en el update el esquema de control
            PCControls.SetActive(true);
            ControllerControls.SetActive(false);
            MobileControls.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMobile()) //Solo querremos hacer comprobacion activa si no estamos en movil.
        {
            print(playerInput.currentControlScheme);
            if(playerInput.currentControlScheme == "Controller") //Si el jugador está usando un mando,
            {
                //Muestra los contoles de mando
                PCControls.SetActive(false);
                ControllerControls.SetActive(true);
                MobileControls.SetActive(false);
            }
            else //En caso contrario, por descarte,
            {
                //Muestra los controles de PC
                PCControls.SetActive(true);
                ControllerControls.SetActive(false);
                MobileControls.SetActive(false);
            }



        }
    }
}
