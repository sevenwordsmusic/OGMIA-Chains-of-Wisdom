using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        //------------------------------------------------------------------------
        //RENDERIZACIÓN BILLBOARD - ORIENTAR UN OBJETO 2D SIEMPRE HACIA LA CÁMARA
        //------------------------------------------------------------------------

        Vector3 targetVector = Camera.main.transform.position - transform.position; //Hallamos el vector que va desde el objeto a la cámara

        float newYAngle = Mathf.Atan2(targetVector.z, targetVector.x) * Mathf.Rad2Deg; //Hallamos la rotación que debe realizar el objeto para mirar hacia la cámara.


        //Y por último aplicamos esa rotación de manera negativa (ya que los grados van en el sentido horario y queremos que vayan al revés) al objeto, para que se oriente hacia la cámara
        transform.rotation = Quaternion.Euler(0, -newYAngle - 90, 0);
        //transform.rotation = Quaternion.LookRotation(targetVector,Vector3.up);
    }

}
