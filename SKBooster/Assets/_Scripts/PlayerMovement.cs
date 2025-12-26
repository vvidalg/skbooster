/*using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float lookSpeed = 3f;

    private InputSystem_Actions controls;
    private Vector2 moveInput;
    private Vector2 lookInput;

    private Animator animator;

    public string playerName = "Yo";

    private void Awake()
    {
        controls = new InputSystem_Actions();
        animator = GetComponent<Animator>();   // ← Referencia al Animator
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        controls.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        controls.Player.Look.canceled += ctx => lookInput = Vector2.zero;
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void Update()
    {

        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(movement * speed * Time.deltaTime);

        Vector3 rotation = new Vector3(0, lookInput.x, 0) * lookSpeed;
        transform.Rotate(rotation * Time.deltaTime);

        float velocity = movement.magnitude;
        animator.SetFloat("velocity", velocity);
        animator.SetFloat("moveX", moveInput.x);
        animator.SetFloat("moveY", moveInput.y);
    }
}*/
using UnityEngine;
using VIDE_Data;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float lookSpeed = 3f;

    private InputSystem_Actions controls;
    private Vector2 moveInput;
    private Vector2 lookInput;
    
    public VIDEUIManager1 diagUI;
    public QuestChartDemo questUI;
    //public Animator blue;
    
    private Animator animator;

    public string playerName = "Yo";

    public VIDE_Assign inTrigger;
    
    private void Awake()
    {
        controls = new InputSystem_Actions();
        animator = GetComponent<Animator>(); 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VIDE_Assign>() != null)
            inTrigger = other.GetComponent<VIDE_Assign>();
    }
    void OnTriggerExit()
    {
        inTrigger = null;
    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        if (!VD.isActive)
        {
            controls.Player.Enable();
            controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
            controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
            controls.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
            controls.Player.Look.canceled += ctx => lookInput = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.visible = !Cursor.visible;
            if (Cursor.visible)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }

    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void Update()
    {

        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(movement * speed * Time.deltaTime);

        Vector3 rotation = new Vector3(0, lookInput.x, 0) * lookSpeed;
        transform.Rotate(rotation * Time.deltaTime);

        float velocity = movement.magnitude;
        animator.SetFloat("velocity", velocity);
        animator.SetFloat("moveX", moveInput.x);
        animator.SetFloat("moveY", moveInput.y);
    }

    void TryInteract()
    {
        /* Prioritize triggers */

        if (inTrigger)
        {
            diagUI.Interact(inTrigger);
            return;
        }
    }
}