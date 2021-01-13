using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTracker : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.activeSelf)
            transform.position = new Vector3(player.transform.position.x, 20, player.transform.position.z);
        if(mainCamera == null)
        {
            mainCamera = GameObject.Find("Main Camera");
        }
        if (mainCamera.activeSelf)
            transform.rotation = Quaternion.Euler(90, mainCamera.transform.rotation.eulerAngles.y, 0);
    }
}
