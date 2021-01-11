using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletFragmentScript : MonoBehaviour
{
    private bool absorbed;
    private Transform playerTransform;
    private Vector3 target;
    [SerializeField] Light light;
    private CharacterController characterController;
    private LevelProgressTracker levelProgressTracker;

    [SerializeField] float speed;
    [SerializeField] float disminutionFactor;


    // Start is called before the first frame update
    void Start()
    {
        levelProgressTracker = FindObjectOfType<LevelProgressTracker>(); //Solo puede haber UN LevelProgressTracker por nivel

        levelProgressTracker.addFragmentToCounter();

        characterController = GetComponent<CharacterController>();
        absorbed = false;
    }

    public void addFragment()
    {
        if(levelProgressTracker == null)
        {
            levelProgressTracker = FindObjectOfType<LevelProgressTracker>();
            if(levelProgressTracker == null)
            {
                levelProgressTracker = GameObject.Find("LevelController").GetComponent<LevelProgressTracker>();
            }
        }
        levelProgressTracker.fragmentCollected();

        RoomController deactivator = transform.parent.GetComponent<RoomController>();
        if (deactivator != null)
        {
            deactivator.completedBefore = true;
            deactivator.saveState();
        }

        light.intensity = 15;
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if(playerTransform == null)
        {
            playerTransform = GameObject.Find("Root Player").transform;
        }
        //Ignora la colisión entre el jugador y el fragmento para que no obstaculice la 'absorcion'
        Physics.IgnoreCollision(playerTransform.gameObject.GetComponent<CharacterController>(), characterController, true);
        absorbed = true;
        //StartCoroutine(absorbeFragmentVFX(this.transform.position,other.transform.position,100));

        //Hacemos que el jugador mire hacia el amuleto
        playerTransform.LookAt(new Vector3 (transform.position.x, playerTransform.position.y, transform.position.z));
        //Ejecutamos la animacion de 'adquirir objeto'
        playerTransform.gameObject.GetComponent<Animator>().SetTrigger("takeItem");
    }

    public void FixedUpdate()
    {
        if (absorbed)
        {
            target = new Vector3(playerTransform.position.x, playerTransform.position.y + 1.3f, playerTransform.position.z);
            Vector3 moveDir = target - this.transform.position;

            characterController.Move(moveDir.normalized * speed * Time.deltaTime);

            //this.transform.localScale = this.transform.localScale * disminutionFactor;
            light.intensity = light.intensity * disminutionFactor;

            if (Vector3.Distance(target, this.transform.position) < 0.1)
                Destroy(this.gameObject,0.2f);
        }
    }


}
