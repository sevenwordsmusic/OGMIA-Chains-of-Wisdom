using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class arrowTrapController : MonoBehaviour
{
    private BoxCollider TriggerCollider;
    [Tooltip("Si la trampa es smart, se activará por sí misma cuando se acerque el jugador a ella. En otro caso, se activará y desactivará cada x periodo de tiempo")] [SerializeField] bool isSmart;
    [Tooltip("Si la trampa no es smart, esta variable define el tiempo en segundos entre cada iteración (activarse,esconderse) de la trampa")] [SerializeField] float cycleTime;
    [Tooltip("Velocidad estándar a la que se moverán las flechas")] public float speed;
    [Tooltip("Daño que hará esta trampa al jugador si le alcanza")] public int damage = 10;
    //[Tooltip("Cantidad máxima de dispersión entre las flechas. A mayor el número, más dispersas las flechas")] [SerializeField] float positionOffset; //Desahabilitado por funcionalidad defectuosa
    [Tooltip("Variación máxima en la velocidad. A mayor el número, más variación de velocidad en cada flecha")] [SerializeField] float speedOffset;
    [SerializeField] GameObject arrowContainer; //Objeto que contiene los objetos flecha, y que se utilizará como contenedor para recorrerlas
    //private Animator animator;
    private float timer;
    private bool canLaunch;

    void Start()
    {
        TriggerCollider = GetComponent<BoxCollider>();
        //animator = GetComponent<Animator>();
        canLaunch = false;

        if (isSmart)
        {
            TriggerCollider.enabled = true;
        }
        else
        {
            TriggerCollider.enabled = false;
        }

    }

    private void Update()
    {
        if (isSmart && !canLaunch)
        {
            timer += Time.deltaTime;
            
            if(timer >= cycleTime)
            {
                canLaunch = true;
                timer = 0;
            }
        } 
        else if (!isSmart)
        {
            timer += Time.deltaTime;

            if(timer >= cycleTime)
            {
                launchArrows();
                timer = 0;
            }
        }
    }

    public void launchArrows()
    {
        GameObject spawnedArrows = Instantiate(arrowContainer, this.transform, true);
        spawnedArrows.SetActive(true);

        foreach(Transform child in spawnedArrows.transform)
        {
           arrowController arrowScript = child.GetComponent<arrowController>();

            //child.transform.position = new Vector3 (child.transform.position.x, child.transform.position.y, (child.transform.position.z + Random.Range(-positionOffset, positionOffset)));
            arrowScript.characterController.enabled = true;


            arrowScript.launched = true;
            arrowScript.canDamage = true;

            arrowScript.speed = speed + Random.Range(-speedOffset, speedOffset);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canLaunch)
        {
            launchArrows();
            canLaunch = false;
        }
    }
}
