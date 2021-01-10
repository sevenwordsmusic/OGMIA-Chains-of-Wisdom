using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float sizeMult = 1;
    RoomEnemiesController controller;
    TutorialEnemiesController tutorialController;
    public bool isAlive = true;

    private Animator animator;
    [HideInInspector] public int currentHealth; //Salud actual del enemigo
    public int maxHealth; //Salud máxima del enemigo
    [Tooltip("Altura a la que representar la barra de vida sobre el enemigo")][SerializeField] float healthBarOffset = 1.5f;
    private HealthBarController healthBarScript;
    private GameObject healthBarObject;
    public bool isVulnerable; //Booleano que determina si el enemigo puede recibir daño en su estado actual.
    [SerializeField] float invulnerabilityAfterHitTime; //tiempo en segundos que pasa el enemigo siendo invulnerable tras recibir daño.
    //private EnemyHealthBar healthBar;

    //Variables relacionadas con el sistema de detección de enemigos en pantalla
    [HideInInspector] public bool onScreen;
    [HideInInspector] public bool addedToList;
    private float timeOutTimer;
    private float healthBarOnScreenTimer;



    /*[CustomEditor(typeof(EnemyController))]
    public class ObjectBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EnemyController myScript = (EnemyController)target;
            if (GUILayout.Button("Kill Enemy"))
            {
                myScript.takeDamage(1000, 0, Vector3.forward, myScript.transform.gameObject);
            }
        }
    }*/



    void Start()
    {
        isVulnerable = true;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBarScript = GetComponentInChildren<HealthBarController>();
        healthBarObject = healthBarScript.gameObject;
        healthBarScript.setMaxHealth(maxHealth);


        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerTransform == null)
        {
            playerTransform = GameObject.Find("Root Player").transform;
        }
        //Ignora la colisión entre el jugador y el fragmento para que no obstaculice la 'absorcion'
        Physics.IgnoreCollision(playerTransform.gameObject.GetComponent<CharacterController>(), GetComponent<CharacterController>(), true);

        setupHealthBar();
    }

    /// <summary>
    /// Prepara la barra de vida del enemigo haciéndola 'hija' del canvas auxiliar permanente en la escena
    /// </summary>
    private void setupHealthBar()
    {
        var canvas = GameObject.Find("Overlay_Canvas");
        healthBarObject.transform.SetParent(canvas.transform, false);
        healthBarObject.SetActive(false);
    }

    public void setRoomEnemyController(RoomEnemiesController rEC)
    {
        controller = rEC;
    }
    public void setTutorialEnemyController(TutorialEnemiesController tEC)
    {
        tutorialController = tEC;
    }

    public void enemyDefeated()
    {
        if(controller!= null){
            controller.enemyDefeated();
        }
        if (tutorialController != null)
        {
            tutorialController.enemyDefeated();
        }
    }

    void Update()
    {
        //transform.Rotate(0, dir, 0);

        //GESTIONAR SI EL ENEMIGO ESTÁ EN PANTALLA, Y SI LO ESTÁ, AÑADIRLO A LA LISTA DE ENEMIGOS EN EL COMBAT MANAGER

        //Determinamos la posición relativa del enemigo en el plano de la cámara.
        Vector3 enemyPosition = Camera.main.WorldToViewportPoint(transform.position);

        //Si los valores X e Y del vector anterior están entre 0 y 1, el enemigo se encuentra dentro de la pantalla.
        onScreen = enemyPosition.z > 0 && enemyPosition.x > 0 && enemyPosition.x < 1 && enemyPosition.y > 0 && enemyPosition.y < 1;

        //Finalmente, si el enemigo está dentro de la pantalla, lo añadimos a la lista de enemigos en el manager (una sola vez)
        if (onScreen && !addedToList)
        {
            addedToList = true;
            timeOutTimer = 0;
            CombatManager.CM.enemies.Add(this);
        }
        else if (!onScreen) //Pero si sale de la pantalla, no nos interesa mantenerlo en la lista, de manera que lo quitamos.
        {
            //Si el enemigo esta fuera de la pantalla,
            timeOutTimer += Time.deltaTime; //corre el contador de tiempo,
            if (timeOutTimer >= 5f) //si dicho contador supera los 5 segundos fuera de pantalla
            {
                //quita al enemigo de la lista
                addedToList = false;
                CombatManager.CM.enemies.Remove(this);
                timeOutTimer = 0;
            }
        }

        if (onScreen && addedToList)
        {

            if (healthBarObject.activeSelf) //Si las stats están siendo mostradas en pantalla,
            {
                //Actualiza la posición del widget para que siga al enemigo.
                Vector3 viewportPosition = Camera.main.WorldToScreenPoint(new Vector3(this.transform.position.x, this.transform.position.y + healthBarOffset, this.transform.position.z));
                healthBarObject.transform.position = new Vector3(viewportPosition.x, viewportPosition.y, -3);

                //Contamos cuanto tiempo lleva activa la barra de vida desde el ultimo golpe recibido
                healthBarOnScreenTimer += Time.deltaTime;
                //print(healthBarOnScreenTimer);
                if(healthBarOnScreenTimer >= 3f) //Si el enemigo no ha recibido daño en los ultimos tres segundos...
                {
                    healthBarObject.SetActive(false); //Escondemos su barra de vida.
                    healthBarOnScreenTimer = 0;
                }

            }
        }
    }


    public void takeDamage(int damage, float knockbackForce, Vector3 knockbackDir, GameObject other)
    {
        if (isVulnerable && isAlive) //Si el enemigo es vulnerable,
        {
            currentHealth -= damage;
            print("OUCH: " + damage + "  " + currentHealth);

            //Actualizamos el valor en el script de la barra de vida y manejamos el objeto, haciendo que se vuelva invisible tras unos segundos.
            healthBarObject.SetActive(true);
            healthBarScript.setHealth(currentHealth);
            healthBarOnScreenTimer = 0;

            //Cooldown durante el cual el enemigo no puede volver a recibir daño
            StartCoroutine(cooldownVulnerability());

            //Play hurt animation
            //animator.SetTrigger("Hurt");


            //Look at the one who attacked
            transform.LookAt(new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z));

            //Apply knockback received from the 'other' who attacks
            //if (knockbackForce != 0)
            //    forceApplier.AddImpact(new Vector3(knockbackDir.x, 0, knockbackDir.z), knockbackForce);

            if (currentHealth <= 0)
            {
                Die(); //Si el HP se reduce por debajo de 0, el enemigo muere.
            }
        }

    }

    private void Die()
    {
        print("enemyDead");
        //Play death animation
        //animator.SetTrigger("Death");

        isAlive = false;

        //Destruye el objeto healthBar
        Destroy(healthBarObject);

        CombatManager.CM.enemies.Remove(this);

        this.enabled = false;

        enemyDefeated();
        Destroy(gameObject, 3f);
    }


    public IEnumerator cooldownVulnerability()
    {
        isVulnerable = false;
        yield return new WaitForSeconds(invulnerabilityAfterHitTime);
        isVulnerable = true;
    }
}
