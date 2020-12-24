using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    [Tooltip("Daño causado por este arma")] public int damage = 30;
    [Tooltip("Retroceso causado a los enemigos que daña este arma")] public float knockback = 0.35f;
    //[Tooltip("Cooldown entre ataque y ataque")] [SerializeField] float cooldown = 0.2f;
    [Tooltip("Cantidad de espacio que avanza el jugador al atacar en una direccion con este arma")] [SerializeField] float thrust = 1;
    //[Tooltip("Punto en el espacio utilizado para calcular la dirección del knockback aplicado a enemigos")] [SerializeField] Transform impactVector;
    //[Tooltip("Partículas generadas cada vez que este arma impacta a un enemigo")] [SerializeField] GameObject hitParticles; //Se generarán desde el enemigo
    //[Tooltip("Punto desde donde se lanzará el raycast para encontrar el punto de colisión del arma donde generar las hitParticles")] [SerializeField] GameObject RaycastOrigin;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy") //Sólo podrá hacer daño a objetos con el tag 'Enemy'
        {
            print("die evil thing");
            other.gameObject.GetComponent<EnemyController>().takeDamage(damage, knockback, this.transform.up, this.gameObject); //Aplica el daño al enemigo
            //other.gameObject.GetComponent<ForceApplier>().AddImpact(impactVector.forward.normalized, knockback); //Aplica un knockback junto al golpe, en direcccion de la punta de la espada (impactVector)
            //^Ojo con esto que a veces se bugea y lanza al enemigo a la mierda.

            ////Instanciación de partículas de golpe.
            //RaycastHit hit;
            ////Lanza un rayo desde el punto RaycastOrigin (que se encuentra en la base del arma) hacia el enemigo que ha sido golpeado. Si el raycast tiene éxito
            ////y choca con algo dentro de la distancia máxima, devolverá la información y posición de la colisión en la variable hit.
            //if (Physics.Raycast(RaycastOrigin.transform.position, other.transform.position - RaycastOrigin.transform.position, out hit, 3f))
            //{
            //    //Si el raycast tiene exito, instancia las particulas en el punto de colisión
            //    Instantiate(hitParticles, hit.point, Quaternion.identity);
            //}
        }
    }
}
