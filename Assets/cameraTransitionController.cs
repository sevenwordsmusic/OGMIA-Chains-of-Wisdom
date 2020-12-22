using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class cameraTransitionController : MonoBehaviour
{
    [SerializeField] PlayableDirector originalCamera;
    [SerializeField] PlayableDirector newCameraPoint;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Si no estamos en el nuevo punto de vista, realizamos la transición.
            if (newCameraPoint.state != PlayState.Playing || newCameraPoint.state == PlayState.Paused)
            {
                originalCamera.Stop();
                newCameraPoint.Play();
            }
            else //Si por otro lado, estamos ya en el nuevo punto de vista, eso quiere decir que estamos saliendo del area de cámara designada,
            {
                //Con lo cual volvemos al punto de vista original, el anterior a la transicion.
                newCameraPoint.Stop();
                originalCamera.Play();
            }
        }
    }
}
