using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    public bool launched;
    public bool canDamage;
    public CharacterController characterController;
    private arrowTrapController trapController;
    public float speed;
    private int damage;
    private TrailRenderer trailRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        characterController.enabled = false;
        trapController = GetComponentInParent<arrowTrapController>();
        speed = trapController.speed;
        damage = trapController.damage;
        canDamage = true;
        launched = true;
        trailRenderer = GetComponentInChildren<TrailRenderer>();

        StartCoroutine(arrowLayerChange());
    }

    // Update is called once per frame
    void Update()
    {
        if(launched)
        {
            characterController.Move(this.transform.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (canDamage)
            {
                arrowHit();

                other.GetComponent<CombatController>().takeDamage(damage, 0, Vector3.zero, this.gameObject);
            }

            RaycastHit hit;

            //Lanzamos un rayo hacia el jugador, y si este rayo acierta, 'pegamos' la flecha al punto donde ha impactado en el jugador.
            if(Physics.Raycast(this.transform.position, other.transform.position - this.transform.position,out hit, 10))
            {
                //ITERACION PARA BUSCAR EL HUESO MAS CERCANO AL PUNTO DE IMPACTO
                float closestDistance = 100;
                Transform closestBone = hit.transform;

                foreach(Transform child in hit.transform)
                {
                    if(Vector3.Distance(child.position,hit.point) < closestDistance)
                    {
                        closestDistance = Vector3.Distance(child.position, hit.point);
                        closestBone = child;
                    }
                }

                this.transform.position = closestBone.position;
                this.transform.SetParent(closestBone.transform);

                trailRenderer.emitting = false; //Detenemos el efecto de trail, ya que ya no es necesario
                characterController.enabled = false; //Ya no necesitamos el characterController, asi que lo desactivamos para evitar funcionamiento no deseado.
                Destroy(this.gameObject, 5); //Después de cinco segundos, destruimos la flecha
            }
            else //En caso contrario, destruimos la flecha inmediatamente.
            {
                Destroy(this.gameObject);
            }

        } 
        else if(!other.gameObject.GetComponent<arrowController>())
        {
            RaycastHit hit;

            //Hacemos lo mismo que en el caso anterior, pero con el objeto del entorno con el que chocase la flecha.
            if (Physics.Raycast(this.transform.position, other.transform.position - this.transform.position, out hit, 10))
            {
                this.transform.position = hit.point;
                this.transform.SetParent(other.transform);

                trailRenderer.emitting = false; //Detenemos el efecto de trail, ya que ya no es necesario
                characterController.enabled = false; //Ya no necesitamos el characterController, asi que lo desactivamos para evitar funcionamiento no deseado.
                Destroy(this.gameObject, 5); //Después de cinco segundos, destruimos la flecha
            }
            else //En caso contrario, destruimos la flecha inmediatamente.
            {
                Destroy(this.gameObject);
            }
        } 
        else
        {
            Destroy(this.gameObject);
        } 
    }

    private void arrowHit()
    {
        foreach(Transform child in this.transform.parent)
        {
            arrowController arrowScript = child.GetComponent<arrowController>();

            arrowScript.canDamage = false;
        }
    }

    IEnumerator arrowLayerChange()
    {
        this.gameObject.layer = 12; //Layer ARROW para evitar que al dispararse la flecha, choque contra la pared de la que sale.
        yield return new WaitForSeconds(0.5f);
        this.gameObject.layer = 8; //Layer ENVIRONMENT para que trascurrido ese 'tiempo de seguridad', la flecha pueda clavarse en una pared.
    }

}
