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
        levelProgressTracker.fragmentCollected();

        light.intensity = 15;
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //Ignora la colisión entre el jugador y el fragmento para que no obstaculice la 'absorcion'
        Physics.IgnoreCollision(playerTransform.gameObject.GetComponent<CharacterController>(), characterController, true);
        absorbed = true;
        //StartCoroutine(absorbeFragmentVFX(this.transform.position,other.transform.position,100));
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


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player" && absorbed)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    //Esto de momento no funciona. Su intencion es hacer un lerp suave que mueva el fragmento hacia el jugador al mismo tiempo que va disminiuyendo su escala hasta 0,
    //dando la sensación de que lo 'absorbe'
    //IEnumerator absorbeFragmentVFX(Vector3 from, Vector3 to, float speed)
    //{
    //    Vector3 startPos = this.gameObject.transform.position;
    //    Vector3 startScale = this.gameObject.transform.localScale;

        

    //    while (this.gameObject.transform.position != to)
    //    {
    //        Vector3 temp = (this.transform.position - startPos) * speed;
    //        Vector3 tempPos = Vector3.Lerp(from, to, temp.magnitude);
    //        //float tempX = Mathf.Lerp(from.x, to.x, (this.transform.position.x - startPos.x) * speed);
    //        //float tempY = Mathf.Lerp(from.y, to.y, (this.transform.position.y - startPos.y) * speed);
    //        //float tempZ = Mathf.Lerp(from.z, to.z, (this.transform.position.z - startPos.z) * speed);
    //        this.transform.position = tempPos;

    //        //transform.position = Vector3.Lerp(from, to, speed);
    //        //this.transform.localScale = new Vector3(this.transform.localScale.x - 0.05f, this.transform.localScale.y - 0.05f, this.transform.localScale.z - 0.05f);

    //        yield return null;
    //    }


    //    //while (Time.timeScale != to)
    //    //{
    //    //    float tempTime = Mathf.Lerp(from, to, (Time.unscaledTime - startTime) * speed);
    //    //    Time.timeScale = tempTime;
    //    //    yield return null;
    //    //}

    //}


}
