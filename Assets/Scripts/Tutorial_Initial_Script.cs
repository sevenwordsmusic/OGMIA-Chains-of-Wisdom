using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Initial_Script : MonoBehaviour
{
    private GameObject player;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();
        characterController.enabled = false;
        player.transform.position = this.transform.position;
        characterController.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
