using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{

    public delegate void ComboEvent();
    public event ComboEvent comboCheckEvent; //Evento lanzado en las animaciones de ataque para ejecutar la lógica del combo en el script.
    public event ComboEvent rollEvent; //Evento lanzado en las animaciones de ataque para ejecutar la lógica del combo en el script.


    //public delegate void movementEvent();
    //public event movementEvent enableMovementEvent; //Evento lanzado en las animaciones de ataque para ejecutar la lógica del combo en el script.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Función llamada en selectivamente en las animaciones de ataque para gestionar la lógica del combo desde los scripts que reaccionen al evento que lanza ésta.
    /// </summary>
    public void comboCheck()
    {
        
        if (comboCheckEvent != null)
        {
            print("recibido, ejecutando comboCheck!");
            comboCheckEvent();
        }
            
    }

    public void rollCheck()
    {

        if (rollEvent != null)
        {
            rollEvent();
        }

    }

    //public void enableMovement()
    //{

    //    if (enableMovementEvent != null)
    //    {
    //        enableMovementEvent();
    //    }

    //}
}
