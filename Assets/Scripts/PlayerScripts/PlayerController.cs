using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using PixelCrushers.DialogueSystem;
using System.Runtime.InteropServices;

public class PlayerController : MonoBehaviour
{
    [Header("References", order = 0)]
    //Canvas & camera setting variables
    private Transform cam;
    [SerializeField] Camera UICamera;
    [SerializeField] CinemachineFreeLook cinemaCam;
    private Canvas canvas;

    [SerializeField] Animator animator;
    [Tooltip("Layer que contiene los objetos que se identificarán como 'suelo'")] [SerializeField] LayerMask groundMask;
    [Tooltip("Punto en el espacio donde se proyecta la esfera que detectará si el jugador está tocando el suelo")] [SerializeField] Transform groundCheck;
    private CharacterController controller;
    private PlayerInput playerInput;
    private InputMaster1 inputActions;
    private ProximitySelector proximitySelector;

    [Header("Movement variables", order = 1)]
    [Tooltip("Velocidad de movimiento del jugador")] [SerializeField] float speed = 6f;
    [Tooltip("Fuerza de la gravedad aplicada al jugador")] [SerializeField] float gravity = -9.81f;
    [Tooltip("Altura del salto del jugador")] [SerializeField] float jumpHeight = 3f;
    [Tooltip("Radio de la esfera proyectada en los pies del jugador para detectar si está tocando el suelo")] [SerializeField] float groundDistance = 0.4f;
    [Tooltip("Distancia recorrida en el dash")] [SerializeField] float dashDistance = 4f;
    [Tooltip("Cooldown del dash")] [SerializeField] float dashCooldownTime = 0.4f;
    [Tooltip("Cooldown de la voltereta")] [SerializeField] float rollCooldownTime = 0.6f;
    [Tooltip("Simulación de fuerzas (aire, fricción) que ralentizan y detienen al jugador al moverse, saltar, dashear, etc")]
    [SerializeField] Vector3 drag = new Vector3(10f, 1f, 10f);
    [Tooltip("Velocidad a la que rotará la cámara")] [SerializeField] float rotateCameraSpeed = 2; 
    [Tooltip("Velocidad a la que rotará la cámara en movil")] [SerializeField] float rotateCameraSpeedMobile = 50; 
    private Vector3 direction;
    private Vector3 moveDir;
    private Vector3 velocity;
    private bool isGrounded;
    [HideInInspector] public bool canDash;
    [HideInInspector] public bool canMove;
    private float rotateCameraAmount;

    public bool DashUpgrade;
    private PlayerAnimationScript playerAnimationScript;

    //CHEQUEOS DE PLATAFORMA
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public bool isMobile()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            return IsMobile();
        #endif
        return false;
    }


    void Awake()
    {
        inputActions = new InputMaster1();
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimationScript = GetComponentInChildren<PlayerAnimationScript>();
        proximitySelector = GetComponent<ProximitySelector>();

        //Esta linea cambia el estado del cursor cuando se está jugando, escondiéndolo y bloqueándolo en el centro de la ventana, para que no se vea y no estorbe.
        //Cursor.lockState = CursorLockMode.Confined;
        canMove = true;
        canDash = true;

        //playerAnimationScript.rollEvent += applyRoll;
        //playerAnimationScript.enableMovementEvent += enableMovement;

        //rb = GetComponent<Rigidbody>();

    }


    //EVENTS
    private void OnEnable()
    {
        //INPUT
        //playerInput = GetComponent<PlayerInput>();
        playerInput.ActivateInput();
        inputActions.Enable();
        //EVENTS
        UIManager.goBackToMainMenuEvent += DestroyPlayer; //Destruye el objeto jugador cuando se vuelva al menu principal para evitar arrastrar datos entre ciclos de juego.

        //Adaptación del Canvas para las funcionalidades 3D.
        cam = GetComponentInChildren<Camera>().transform;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>(); //Busca el GameObject llamado Canvas, por lo tanto, el Canvas NO debe cambiar de nombre
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = UICamera;

        //Cursor.lockState = CursorLockMode.Confined;

    }

    private void OnDisable()
    {
        playerInput.DeactivateInput();
        inputActions.Disable();
        UIManager.goBackToMainMenuEvent -= DestroyPlayer; //Destruye el objeto jugador cuando se vuelva al menu principal para evitar arrastrar datos entre ciclos de juego.

    }



    private void OnDestroy()
    {
        UIManager.goBackToMainMenuEvent -= DestroyPlayer; //Destruye el objeto jugador cuando se vuelva al menu principal para evitar arrastrar datos entre ciclos de juego.
    }

    private void DestroyPlayer()
    {
        Destroy(this.gameObject);
    }

    #region INPUT MANAGEMENT

    public void OnMovement(InputValue value)
    {
        if (!isMobile())
        {

            var v = value.Get<Vector2>(); //El valor leído siempre debe corresponder con el asignado a la acción dentro del Action Map

            if (v.magnitude < 0.1)
                v = Vector2.zero;

            if (canMove) //Recoge el input sólo si el jugador puede moverse.
            {
                direction = new Vector3(v.x, 0f, v.y); //Normalmente este vector deberia normalizarse, pero los valores vienen ya normalizados del sistema de Input.
            }
            else //Si no puede, resetea el vector a cero para que no queden 'direcciones residuales' recogidas de inputs anteriores. 
            {
                direction = Vector3.zero;
            }
        }
    }

    public void OnRotateCamera(InputValue value)
    {
        var v = value.Get<Vector2>(); //El valor leído siempre debe corresponder con el asignado a la acción dentro del Action Map

        if (v.magnitude < 0.1)
            v = Vector2.zero;

        rotateCameraAmount = v.x;
    }

    public void OnPause()
    {
        UIManager.UIM.gameObject.GetComponent<Pause>().DoPause();
        UIManager.UIM.ShowPausePanel();
        UIManager.UIM.HideGeneralHUD();
    }

    private void OnInteract()
    {
        proximitySelector.UseCurrentSelection();
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //Formula de salto 'realista' basada en físicas y en la elevación deseada del salto
            animator.SetBool("isJumping", true); //reproduce la animación de salto
        }

    }

    public void OnDash()
    {
        if (canDash)
        {
            //velocity = Vector3.zero;

            if (DashUpgrade)
            {
                animator.SetBool("isDashing", true); //Reproduce la animacion de dash. El booleano se pondrá automaticamente a false cuando acabe la animación gracias al 'DashBehaviour' (consultar animator para + info)
                StartCoroutine(dashCooldown(dashCooldownTime)); //Ponemos en cooldown el dash.
            }
            else
            {
                animator.SetBool("isRolling", true); //Reproduce la animacion de dash. El booleano se pondrá automaticamente a false cuando acabe la animación gracias al 'DashBehaviour' (consultar animator para + info)
                StartCoroutine(dashCooldown(rollCooldownTime)); //Ponemos en cooldown el dash.

                //Añade a la velocidad un vector resultante de la multiplicación de la dirección del jugador (transform.forward) por un vector compuesto a partir del
                //dashDistance y el drag, basado en fórmulas físicas 'realistas'.

            }

        }
    }
    //FUNCIONES AUXILIARES

    /// <summary>
    /// Desactiva el booleano "canDash", y no lo vuelve a poner a true hasta que transcurran "sec" segundos.
    /// </summary>
    IEnumerator dashCooldown(float sec)
    {
        canDash = false;
        yield return new WaitForSeconds(sec);
        canDash = true;
    }

    public void applyDash()
    {
        //Añade a la velocidad un vector resultante de la multiplicación de la dirección del jugador (transform.forward) por un vector compuesto a partir del
        //dashDistance y el drag, basado en fórmulas físicas 'realistas'.
        velocity += Vector3.Scale(transform.forward,
                                   dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * drag.x + 1)) / -Time.deltaTime),
                                                              0,//^No entiendo muy bien por qué, pero a mayor el drag, mayor el dash en este caso.
                                                              (Mathf.Log(1f / (Time.deltaTime * drag.z + 1)) / -Time.deltaTime)));
    }

    #endregion


    private void FixedUpdate()
    {
        //IF estamos en movil...
        if (isMobile())
        {
            //Recibimos el input del joystick virtual
            Vector2 movementInput = inputActions.Player.Movement.ReadValue<Vector2>();
            direction = new Vector3(movementInput.x, 0f, movementInput.y);

            //Aplicamos rotacion a la camara, si se ha recibido input para ello:
            Vector2 delta = inputActions.Player.RotateCamera.ReadValue<Vector2>();
            cinemaCam.m_XAxis.Value += (delta.x * rotateCameraSpeedMobile * Time.deltaTime);
        } 
        else
        {
            //En caso de estar en PC, solo necesitamos aplicar aquí la rotación de cámara.
            if(playerInput.currentControlScheme == "Keyboard + mouse") //Si se está usando teclado,
            {
                if (inputActions.Player.EnableCameraRotation.ReadValue<float>() > 0f) //Si el jugador está pulsando el boton que permite el giro de camara...
                    cinemaCam.m_XAxis.Value += (rotateCameraAmount * rotateCameraSpeed * Time.deltaTime); //La gira
            } 
            else //En caso de estar usando mando, no necesitamos combinaciones de teclas.
            {
                cinemaCam.m_XAxis.Value += (rotateCameraAmount * rotateCameraSpeed * Time.deltaTime); //La gira
            }
 
        }

        //DETECCION DE COLISIONES
        //Proyecta una esfera en el objeto groundcheck de radio groundDistance, devolviendo true si esa esfera colisiona con un objeto que esté en la capa "groundMask"
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) //Si está en el suelo y su velocidad es menor a 0,
        {
            velocity.y = -2f; //Resetea la velocidad a -2 para que no se incremente indefinidamente.
            //No se coloca a 0 porque pueden darse casos en los que isGrounded sea true antes de que el jugador esté verdaderamente en el suelo.
            animator.SetBool("Falling", false); //Sirve para detener la animación de salto
        }
        else if ((velocity.y < -1 && !isGrounded) || (animator.GetCurrentAnimatorStateInfo(0).IsName("JumpUp") && velocity.y < 0)) //Siempre que la velocidad sea inferior a -1, reproduce la animación de 'caida'. Sirve para saltos y para dejarse caer
        {
            animator.SetBool("Falling", true);
        }


        //MOVIMIENTO
        if (direction.magnitude >= 0.1f)
        {
            //MOVERSE EN FUNCION DE LA DIRECCIÓN A LA QUE APUNTA LA CAMARA.
            //La funcion Atan2 nos da la rotación en el eje Y que necesitamos a partir de la dirección en el x y en el z, lo pasamos a grados y le añadimos la coordenada y de la cámara,
            //para que el jugador se mueva en dirección a donde apunta la cámara
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; //Convierte la rotación de la cámara en una direccion con el vector3.forward

            if (canMove) //Si puede moverse, aplica el movimimiento en función del moveDir calculado.
            {
                //Mueve el personaje en dicha direccion, tomando en cuenta su velocidad y haciendolo independiente del framerate
                if (playerInput.currentControlScheme == "Controller" || playerInput.currentControlScheme == "Touch") //Si se está usando mando o joystick virtual,
                {
                    //La velocidad de movimiento dependerá de cuánto se haya movido el joystick
                    controller.Move(moveDir.normalized * direction.magnitude * speed * Time.deltaTime);
                }
                else //En cualquier otro caso, la velocidad es fija.
                {
                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
                }
            }
            else //Si no, para en seco al jugador.
            {
                controller.Move(Vector3.zero);
            }
        }

        //Pasamos las variables al animator para que se actualicen a tiempo real y funcionen adecuadamente.
        animator.SetFloat("Speed", direction.magnitude); //Para lo que necesita el animator, basta con pasarle la magnitud (longitud al cuadrado en este caso).
                                                         //^Cuando sea positiva, aplicará animaciones de movimiento. Cuando no, animaciones "idle".

        //GRAVEDAD Y FÍSICAS
        velocity.y += gravity * Time.deltaTime; //GRAVEDAD

        //Drag
        //Como queremos tener control del drag individual en cada eje, lo aplicamos individualmente de esta manera, cogiendo un Vector3 como drag.
        velocity.x /= 1 + drag.x * Time.deltaTime;
        velocity.y /= 1 + drag.y * Time.deltaTime;
        velocity.z /= 1 + drag.z * Time.deltaTime;


        //if (canMove)
        //{
        controller.Move(velocity * Time.deltaTime); //Finalmente, tras todas las simulaciones necesarias, movemos al jugador en función de la velocidad calculada
        //}
    }

    public void disableMovement()
    {
        canMove = false;
        canDash = false;
    }

    public void enableMovement()
    {
        canMove = true;
        canDash = true;
    }

    private void OnTriggerEnter(Collider trig)
    {
        Transform trigParent = trig.transform.parent;
        if (trig.transform.parent != null)
        {
            if (trigParent.CompareTag("trap"))
            {
                print("Player Damaged: -" + trig.transform.parent.GetComponent<TrapSpikesController>().damage + "hp");
            }
            else if (trigParent.CompareTag("enemy"))
            {
                //print("enemy");
                //trigParent.GetComponent<EnemyController>().enemyDefeated();
            }
            else if (trigParent.CompareTag("portal"))
            {
                PortalController pController = trigParent.GetComponent<PortalController>();
                print("teleporting");
                pController.teleport();
            }
            else if (trigParent.CompareTag("trapActivator"))
            {
                trigParent.GetComponent<RoomCloseDoors>().activateTrapDoors();
            }
            else
            {
                //nothing
            }
        }
    }


}