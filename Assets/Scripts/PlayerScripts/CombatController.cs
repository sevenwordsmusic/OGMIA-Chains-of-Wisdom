using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CombatController : MonoBehaviour
{
    [Header("References", order = 0)]
    [SerializeField] Animator animator;
    //[SerializeField] WeaponBehaviour weaponBehaviour;

    [Header("Attack Pointer variables", order = 1)]
    [Tooltip("Objeto que contiene al puntero y sobre el que éste pivota")] [SerializeField] Transform attackPointerContainer;
    [Tooltip("Puntero de ataque que se orientará en dirección de donde apunte el jugador")] [SerializeField] Transform attackPointer;
    [Tooltip("Capas en las que puede colisionar el RayCast para hallar el punto al que debe mirar el puntero de ataque")] [SerializeField] LayerMask hitLayers;
    private Vector2 mousePos;

    private Transform playerTransform; //Transform del objeto 3D invisible que representa la lógica del jugador en el mundo
    private ForceApplier forceApplier; //Script dedicado a aplicar 'impulsos' a character controllers
    private PlayerController movementController;
    private PlayerInput playerInput;
    private PlayerAnimationScript playerAnimationScript;
    [HideInInspector] public weaponController weapon;

    [Header("Combat variables", order = 2)]
    public int maxHealth = 150;
    public int maxHealthUpgrade1 = 200;
    public int maxHealthUpgrade2 = 250;
    [HideInInspector] public int health;
    float healthAux;
    private HealthBarController healthBar1;
    private HealthBarController healthBar2;
    //private EnemyHealthBar enemyHPBar;
    [Tooltip("Impulso añadido al jugador cuando éste ataca")] [SerializeField] float attackImpulse = 1f;
    [HideInInspector] public bool canAttack;
    [HideInInspector] public bool isVulnerable;
    [HideInInspector] public bool isBlocking;
    [HideInInspector] public bool isDead;
    [HideInInspector] public int noOfTaps; //Número de taps o clicks que ha realizado el jugador desde que comenzó su combo de ataque.

    //PLAYER UPGRADES
    public bool thrustUpgrade;
    public bool roundAttackUpgrade;
    public bool blockUpgrade;

    //LOCK ON SYSTEM VARIABLES
    [HideInInspector] public EnemyController lockedEnemy;
    private bool lockedOn;
    [SerializeField] GameObject crosshair;
    [SerializeField] GameObject lockedCrosshair;
    private int enemyIndex = 0;

    public delegate void PlayerEvent();
    public static event PlayerEvent playerDeath; //Evento lanzado cuando el jugador muere, para causar una reacción global

    // Start is called before the first frame update
    void Start()
    {
        movementController = GetComponent<PlayerController>();
        playerTransform = GetComponent<Transform>();
        forceApplier = GetComponent<ForceApplier>();
        playerInput = GetComponent<PlayerInput>();
        weapon = GetComponentInChildren<weaponController>();
        //playerAnimationScript = GetComponentInChildren<PlayerAnimationScript>();
        healthBar1 = GameObject.FindGameObjectWithTag("HP1").GetComponent<HealthBarController>();
        healthBar2 = GameObject.FindGameObjectWithTag("HP2").GetComponent<HealthBarController>();
        //enemyHPBar = FindObjectOfType<EnemyHealthBar>();
        //playerAnimationScript.comboCheckEvent += comboAttack;

        noOfTaps = 0;
        canAttack = true;
        isVulnerable = true;
        isBlocking = false;
        health = maxHealth;
        healthBar1.setMaxHealth(maxHealth);
        healthBar2.setMaxHealth(maxHealth);

        healthAux = health;
    }

    //EVENTS
    private void OnEnable()
    {
        //playerAnimationScript.comboCheckEvent += comboAttack;
        

        canAttack = true;

    }

    private void OnDisable()
    {
        //playerAnimationScript.comboCheckEvent -= comboAttack;

        canAttack = false;
    }
    public void disableAttack()
    {
        canAttack = false;
    }

    public void enableAttack()
    {
        canAttack = true;
    }

    #region INPUT MANAGEMENT


    public void OnAttack()
    {
        //print("evento recibido");
        //print(canAttack);
        if (canAttack)
        {
            //AUDIO
            //AudioManager.engine.OnAttack();
            //
            noOfTaps++; //En cada paso del combo, si se puede atacar, acumula un "tap"
            //print("aumentando noOfTaps: " + noOfTaps);

            //Hacemos que el jugador se oriente hacia su enemigo fijado, para que los combos sean fluidos y comodos de ejecutar.
            if (lockedEnemy != null)
            {
                transform.LookAt(new Vector3(lockedEnemy.transform.position.x, transform.position.y, lockedEnemy.transform.position.z));
            }
            else if (playerInput.currentControlScheme == "Keyboard + mouse") //Si se está usando ratón y teclado, apunta el ataque en la dirección del ratón.
            {
                playerTransform.LookAt(new Vector3(attackPointer.position.x, playerTransform.position.y, attackPointer.position.z));
            }
        }

        if (noOfTaps == 1) //Si el número de  taps es exactamente 1, PRIMER GOLPE DEL COMBO
        {
            //Activa el trigger del animador para que reproduzca la animación correspondiente.
            animator.SetTrigger("Attack");
            //Al comenzar el combo, bloqueamos el movimiento y el dash del jugador, que no podrá volver a moverse libremente hasta que decida terminar el combo.
            movementController.canMove = false;
            movementController.canDash = false;
            animator.SetInteger("Combo", 1);
            //forceApplier.AddImpact(playerTransform.forward, attackImpulse);//AÑADIR IMPULSO
        }
    }

    public void On_360Attack(InputValue value)
    {
        //print("360");
        if (canAttack && roundAttackUpgrade)
        {
            animator.SetTrigger("360Attack");
        }

    }

    public void OnBlock()
    {
        if (movementController.canMove && blockUpgrade)
        {
            animator.SetTrigger("isBlocking");
            //El StateMachineBehaviour 'PlayerBlockingBehaviour' se ocupará de gestionar el resto de variables relacionadas con el bloqueo.
        }
    }

    public void OnLockOn()
    {
        if (!lockedOn)
        {
            if (lockedEnemy != null)
            {
                lockedOn = true;
            }
        }
        else
        {
            lockedOn = false;
        }

    }

    public void OnChangeLockOn(InputValue value)
    {
        if (lockedOn)
        {
            //VERSION EN TECLADO. CONTROL POR RUEDA DEL RATON
            if (playerInput.currentControlScheme == "Keyboard + mouse")
            {
                var reading = value.Get<Vector2>().y;

                if (reading > 0) //Si se mueve la rueda del ratón hacia delante,
                {
                    enemyIndex = (enemyIndex + 1) % CombatManager.CM.enemies.Count; //Aumenta el indice de la lista, manteniendolo siempre dentro del rango.
                    lockedEnemy = CombatManager.CM.enemies[enemyIndex]; //Y fija el enemigo encontrado en ese indice.
                }
                else if (reading < 0) //Si se mueve hacia atrás la rueda del ratón,
                {
                    enemyIndex--; //Disminuye el indice de la lista.
                    if (enemyIndex < 0) //Evita que el indice se salga del limite de la lista.
                        enemyIndex = CombatManager.CM.enemies.Count - 1;

                    lockedEnemy = CombatManager.CM.enemies[enemyIndex]; //Y fija el enemigo encontrado en ese indice.
                }
            }
            else if (playerInput.currentControlScheme == "Controller")
            {
                var reading = value.Get<Vector2>();

                if (reading.magnitude > 0) //Si se mueve la rueda del ratón hacia delante,
                {
                    enemyIndex = (enemyIndex + 1) % CombatManager.CM.enemies.Count; //Aumenta el indice de la lista, manteniendolo siempre dentro del rango.
                    lockedEnemy = CombatManager.CM.enemies[enemyIndex]; //Y fija el enemigo encontrado en ese indice.
                }
                else if (reading.magnitude < 0) //Si se mueve hacia atrás la rueda del ratón,
                {
                    enemyIndex--; //Disminuye el indice de la lista.
                    if (enemyIndex < 0) //Evita que el indice se salga del limite de la lista.
                        enemyIndex = CombatManager.CM.enemies.Count - 1;

                    lockedEnemy = CombatManager.CM.enemies[enemyIndex]; //Y fija el enemigo encontrado en ese indice.
                }

            }
        }
    }

    /// <summary>
    /// Transforma el timeScale global del juego desde un valor al otro de manera gradual (Lerp), a una velocidad de 'speed'.
    /// </summary>
    IEnumerator timeLerp(float from, float to, float speed)
    {
        float startTime = Time.unscaledTime;

        while (Time.timeScale != to)
        {
            float tempTime = Mathf.Lerp(from, to, (Time.unscaledTime - startTime) * speed);
            Time.timeScale = tempTime;
            yield return null;
        }

        Time.fixedDeltaTime = Time.timeScale * .2f; //Cambiamos el fixedDeltaTime para que las fisicas tambien adopten la camara lenta.
        //Se arreglará solo al salir del slowMo gracias a que en el Update, si no estamos en slowMo, lo normalizamos por la fuerza cada frame.
        //Un poco guarro, pero funciona.

    }

    public void OnMouseAim(InputValue value)
    {
        mousePos = value.Get<Vector2>(); //Actualiza la variable local que utilizaremos en update con el valor dado por el sistema de Input.
    }

    #endregion

    public void upgradeHealth1()
    {
        maxHealth = maxHealthUpgrade1;
        healthBar1.setMaxHealth(maxHealth);
        healthBar2.setMaxHealth(maxHealth);
        health = maxHealthUpgrade1;
    }

    public void upgradeHealth2()
    {
        maxHealth = maxHealthUpgrade2;
        healthBar1.setMaxHealth(maxHealth);
        healthBar2.setMaxHealth(maxHealth);
        health = maxHealthUpgrade2;
    }

    // Update is called once per frame
    void Update()
    {
        RotatePointer(); //Se deberia optimizar este codigo para que no sea necesario introducir un plano en los pies del jugador.

        //Muestra el puntero de ataque únicamente si se está utilizando ratón y teclado
        if (playerInput.currentControlScheme == "Keyboard + mouse" && !isDead)
        {
            attackPointer.gameObject.SetActive(true);
        }
        else
        {
            attackPointer.gameObject.SetActive(false);
        }

        //////////////////////////////////////////////////
        //SISTEMA DE FIJADO
        //////////////////////////////////////////////////

        if (CombatManager.CM.onCombat) //Solo serán necesarias estas operaciones en caso de que estemos en un combate.
        {
            LockOnSystem();

            if (lockedEnemy != null)
            {
                //enemyHPBar.gameObject.SetActive(true);
                //lockedEnemy.visualizeHealth();
            }
            else
            {
                //enemyHPBar.gameObject.SetActive(false);
            }

        }
        else
        {
            //enemyHPBar.gameObject.SetActive(false);
            crosshair.SetActive(false);
            lockedCrosshair.SetActive(false);
        }

    }

    private void LockOnSystem()
    {
        float distanceToEnemy = 9000f;

        if (!lockedOn) //FIJADO AUTOMÁTICO - SOLO EN CASO DE QUE EL JUGADOR NO HAYA FIJADO UN ENEMIGO.
        {
            lockedCrosshair.SetActive(false); //Por precaucion, desactivamos la mirlla fijada.
            lockedEnemy = null; //En cada iteracion se limpia la variable, para buscar el mejor candidato en ese momento.
                                //Adema, esto cumple el doble proposito de evitar que enemigos muertos permanezcan fijados.

            if (playerInput.currentControlScheme == "Keyboard + mouse")
            {
                foreach (EnemyController enemy in CombatManager.CM.enemies)
                {
                    //todo: Distinguir entre control por teclado y mando: en el control por mando, se utiliza la posición del jugador para el playerToEnemy,
                    //pero en el control por teclado, se debe utilizar el puntero para realizar esa comparación.

                    if(enemy != null)
                    {
                        //Direccion entre el jugador y el enemigo
                        Vector3 PlayerToEnemy = (enemy.transform.position - transform.position).normalized;

                    if (Vector3.Dot(PlayerToEnemy, attackPointer.up) > 0) //Si el producto entre esa direccion y el forward del jugador es positivo, eso significa que el jugador está en frente del enemigo.
                        {
                            //Los enemigos en frente del jugador tienen preferencia para ser fijados. De manera que no hay penalizacion.
                            if (Vector3.Distance(this.transform.position, enemy.transform.position) < distanceToEnemy) //Si la distancia al enemigo es la más cercana que se ha visto hasta ahora,
                            {
                                lockedEnemy = enemy; //Fija a ese enemigo.
                                distanceToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position); //Y guarda esa distancia como la más corta.
                            }
                        }
                        else //Si por el contrario el enemigo está detrás del jugador
                        {
                            //Se aplica una penalización en la comparacion de la distancia, para favorecer que los enemigos en frente del jugador sean fijados más facilmente.
                            if ((Vector3.Distance(this.transform.position, enemy.transform.position) * 2) + 20 < (distanceToEnemy)) //Si incluso con la penalizacion es el candidato favorito,
                            {
                                lockedEnemy = enemy; //Fija a ese enemigo.
                                distanceToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position); //Y guarda esa distancia como la más corta.
                            }
                        }
                    }
                }
            }
            else if (playerInput.currentControlScheme == "Controller")
            {
                foreach (EnemyController enemy in CombatManager.CM.enemies)
                {
                    //Direccion entre el jugador y el enemigo
                    Vector3 PlayerToEnemy = (enemy.transform.position - transform.position).normalized;

                    if (Vector3.Dot(PlayerToEnemy, transform.forward) > 0) //Si el producto entre esa direccion y el forward del jugador es positivo, eso significa que el jugador está en frente del enemigo.
                    {
                        //Los enemigos en frente del jugador tienen preferencia para ser fijados. De manera que no hay penalizacion.
                        if (Vector3.Distance(this.transform.position, enemy.transform.position) < distanceToEnemy) //Si la distancia al enemigo es la más cercana que se ha visto hasta ahora,
                        {
                            lockedEnemy = enemy; //Fija a ese enemigo.
                            distanceToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position); //Y guarda esa distancia como la más corta.
                        }
                    }
                    else //Si por el contrario el enemigo está detrás del jugador
                    {
                        //Se aplica una penalización en la comparacion de la distancia, para favorecer que los enemigos en frente del jugador sean fijados más facilmente.
                        if ((Vector3.Distance(this.transform.position, enemy.transform.position) * 2) + 5 < (distanceToEnemy)) //Si incluso con la penalizacion es el candidato favorito,
                        {
                            lockedEnemy = enemy; //Fija a ese enemigo.
                            distanceToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position); //Y guarda esa distancia como la más corta.
                        }
                    }

                }
            }
            //Tras comparar todos los enemigos que hay en la lista y encontrar el más adecuado para ser fijado, el sistema de fijado coloca el objetivo sobre éste.
            if (lockedEnemy != null)
            {
                crosshair.SetActive(true);
                crosshair.transform.position = lockedEnemy.transform.position;
                //Ponemos la mirilla en el punto relativo de la pantalla donde está el enemigo.
                crosshair.transform.Rotate(new Vector3(0, 0, -1)); //Rotamos la mirilla para que mire hacia la camara.
            }
            else
            {
                crosshair.SetActive(false);
            }


        }
        else //Por otro lado, si el jugador tiene un enemigo fijado...
        {
            //Basta con poner la mirilla de fijado sobre ese enemigo. No es necesario buscar mejores candidatos.
            if (lockedEnemy != null && lockedEnemy.isAlive)
            {
                crosshair.SetActive(false); //Desactivamos la mirilla normal.

                lockedCrosshair.SetActive(true); //Y activamos la mirilla de fijado.

                lockedCrosshair.transform.position = lockedEnemy.transform.position; //Ponemos la mirilla en el punto relativo de la pantalal donde está el enemigo.
                lockedCrosshair.transform.Rotate(new Vector3(0, 0, -1)); //Rotamos la mirilla para que mire hacia la camara.
            }
            else
            {
                lockedOn = false;
                crosshair.SetActive(false);
                lockedCrosshair.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Lanza un rayo desde el punto relativo del ratón hacia el suelo, hallando el punto de intersección al que mirará el Pointer.
    /// </summary>
    private void RotatePointer()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(mousePos); //Transforma la posición del ratón en un rayo que parte desde ese punto de la pantalla.
        RaycastHit rayCollisionPoint; //Punto del rayo en el que éste colisiona con el 'groundPlane'


        if (Physics.Raycast(cameraRay, out rayCollisionPoint, hitLayers)) //Si al proyectar el rayo colisiona con algún punto de las 'hitLayer', devuelve el punto del rayo donde se produce la intersección
        {
            //Actualmente, se ha predispuesto un plano 'Ground Plane' dentro del objeto jugador al nivel de sus pies cuya layer es 'Ground'. Es el único objeto con el que puede chocar el rayo,
            //de forma que el puntero siempre mirará en la dirección correcta gracias a que este plano invisible está a los pies del jugador y cubre un amplio rango de espacio.
            Vector3 pointToLookAt = rayCollisionPoint.point; //Y transforma ese punto en un vector3 que nos diga a qué punto del despacio debe mirar el Pointer
            Debug.DrawLine(cameraRay.origin, pointToLookAt, Color.blue); //Debug line para corroborar todo lo anterior

            attackPointerContainer.LookAt(new Vector3(pointToLookAt.x, attackPointer.transform.position.y, pointToLookAt.z)); //Finalmente, hacemos que el pointer mire hacia ese punto rotándolo únicamente en los ejes X y Z, manteniendo su altura Y
            //attackPointerContainer.LookAt(new Vector3(pointToLookAt.x, attackPointer.transform.position.y, pointToLookAt.z)); //Finalmente, hacemos que el pointer mire hacia ese punto rotándolo únicamente en los ejes X y Z, manteniendo su altura Y
            //attackPointerContainer.transform.rotation = new Quaternion(0, attackPointer.transform.rotation.y, 0, 0);
        }
    }


    /// <summary>
    /// Gestiona todas las consecuencias de que el jugador reciba daño: actualizar el HP, el animator, etc.
    /// </summary>
    /// <param name="damage">Daño recibido</param>
    /// <param name="knockbackForce">Knockback recibido</param>
    /// <param name="knockbackDir">Direccion en la que se aplicará el knockback</param>
    /// <param name="other">El objeto que ha causado el daño</param>
    public void takeDamage(int damage, float knockbackForce, Vector3 knockbackDir, GameObject other)
    {
        //print("player receives " + damage + " points of damage!");

        //Check if blocking & vulnerability
        if (!isBlocking && isVulnerable && !isDead)
        {
            //Reduce health
            health = health - damage;
            healthAux = health;
            healthBar1.setHealth(health);
            healthBar2.setHealth(health);
            if (health <= 0)
            {
                isDead = true;
                //Die & play die animation
                movementController.canMove = false;
                movementController.canDash = false;
                canAttack = false;

                animator.SetTrigger("Death");

                if(playerDeath != null)
                {
                    //ToDo: activar HUD de pantalla de game over
                    //ToDo: aplicar efecto slow motion a la muerte
                    playerDeath();
                }
            }
            //Hit VFX

            //Look at enemy
            transform.LookAt(new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z));

            //Apply knockback received from the 'other' who attacks
            if (knockbackForce != 0)
                forceApplier.AddImpact(new Vector3(knockbackDir.x, 0, knockbackDir.z), knockbackForce);

            //Play Hurt animation. The animator state machine bheaviour takes care of making the player invulnerable && unmovile during the hurt time window
            animator.SetTrigger("isHurt");
        }
        else if (isBlocking)
        {
            //Look at enemy
            transform.LookAt(new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z));

            animator.SetTrigger("BlockHit");//Cada vez que el jugador bloquea un golpe con éxito, el tiempo de bloqueo se extiende.

            //Aplica un tercio del knockback original del ataque.
            if (knockbackForce != 0)
                forceApplier.AddImpact(new Vector3(knockbackDir.x, 0, knockbackDir.z), knockbackForce / 3);


            //Play Block VFX
        }

    }

    public void increaseHealth(float h)
    {
        healthAux = Mathf.Min(maxHealth, healthAux + h);
        health = (int)healthAux;
        healthBar1.setHealth(health);
        healthBar2.setHealth(health);
    }

    /// <summary>
    /// Normalmente, esta función será invocada por eventos desencadenados en las animaciones de ataque. 
    /// En ese momento esta función decide qué animación ejecutar a continuación.
    /// </summary>
    public void comboAttack()
    {
        //print("combeando");
        //todo: buscar una implementación más cómoda y escalable que permita crear nuevos combos más fácilmente
        canAttack = false; //Ponemos "canAttack" a false durante la comprobación del estado del combo. Una vez lo sepamos, lo volveremos a poner a true. Así evitamos malas lecutras.

        //CUANDO SE LLAMA POR PRIMERA VEZ A ESTA FUNCION, YA SE HA COMPLETADO EL PRIMER ATAQUE.

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Combo1") && noOfTaps == 1)
        {
            //Si no se han registrado nuevos "taps" antes de haber llegado a este punto en la animación, vuelve a "idle" y corta el combo.
            animator.SetInteger("Combo", 0);
            movementController.canMove = true;
            movementController.canDash = true;
            StartCoroutine(attackCooldown(0.5f)); //El cooldown entre ataques viene definido por el arma del usuario.
            noOfTaps = 0; //Como el combo ha terminado, reseteamos esta variable.

        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Combo1") && noOfTaps >= 1) //AQUI SE LLAMA AL SEGUNDO ATAQUE DEL COMBO
        {
            //Si se han registrado uno o más taps durante la primera animación, eso quiere decir que el jugador quiere continuar con el combo.
            animator.SetInteger("Combo", 2);
            canAttack = true;
            StartCoroutine(cooldownMovement()); //Detiene en seco al jugador al poner canMove a falso durante un corto lapso de tiempo.
            //forceApplier.AddImpact(playerTransform.forward, attackImpulse);//AÑADIR IMPULSO
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Combo2") && noOfTaps == 2)
        {
            //Si durante el segundo ataque no se han registrado nuevos taps, eso quiere decir que el jugador no quiere continuar el combo. Volvemos a idle.
            animator.SetInteger("Combo", 0);
            movementController.canMove = true;
            movementController.canDash = true;
            StartCoroutine(attackCooldown(0.5f)); //El cooldown entre ataques viene definido por el arma del usuario.
            noOfTaps = 0; //Como el combo ha terminado, reseteamos esta variable.
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Combo2") && noOfTaps >= 3 && thrustUpgrade) //AQUI SE LLAMA AL TERCER ATAQUE DEL COMBO
        {
            //Si se han registrado nuevos taps durante el segundo ataque, eso quiere decir que el jugador quiere continuar con el combo.
            animator.SetInteger("Combo", 3);
            canAttack = true;
            StartCoroutine(cooldownMovement()); //Detiene en seco al jugador al poner canMove a falso durante un corto lapso de tiempo.
            //weaponBehaviour.knockback = weaponBehaviour.knockback * 5; //Como el movimiento es un finisher, queremos que tenga mayor knockback.
            //forceApplier.AddImpact(playerTransform.forward, attackImpulse);//AÑADIR IMPULSO
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Combo3"))
        {
            //Al ser el tercer ataque el último del combo, volveremos automáticamente a idle cuando termine.
            animator.SetInteger("Combo", 0);
            movementController.canMove = true;
            movementController.canDash = true;
            //weaponBehaviour.knockback = weaponBehaviour.knockback / 5; //Tras el finisher, devolvemos el valor del knockback al original.
            //IDEA: Asignar el knockback y el daño individual de cada ataque del combo mediante eventos en las propias animaciones!
            StartCoroutine(attackCooldown(0.5f)); //El cooldown entre ataques viene definido por el arma del usuario.
            noOfTaps = 0; //Como el combo ha terminado, reseteamos esta variable.
        }
        else
        {
            animator.SetInteger("Combo", 0);
            movementController.canMove = true;
            canAttack = true;
            movementController.canDash = true;
            //StartCoroutine(attackCooldown(weaponBehaviour.getCooldown())); //El cooldown entre ataques viene definido por el arma del usuario.
            noOfTaps = 0; //Como el combo ha terminado, reseteamos esta variable.
        }
    }

    IEnumerator attackCooldown(float sec)
    {
        canAttack = false;
        yield return new WaitForSeconds(sec);
        canAttack = true;
    }

    IEnumerator cooldownMovement()
    {
        movementController.canMove = false;
        yield return new WaitForSeconds(1); //parametrizar
        movementController.canMove = true;
    }

    /// <summary>
    /// Devuelve true si el animator pasado por referencia está ejecutando una animación.
    /// </summary>
    bool AnimatorIsPlaying(ref Animator anim)
    {
        return anim.GetCurrentAnimatorStateInfo(0).length >
               anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

}
