/*using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputSystem_Actions controls;
    private Vector2 moveInput;
    public float speed = 5f;
    private Vector2 lookInput;
    public float lookSpeed = 3f; 

    private void Awake()
    {
        controls = new InputSystem_Actions();
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
    }
}*/
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float lookSpeed = 3f;

    private InputSystem_Actions controls;
    private Vector2 moveInput;
    private Vector2 lookInput;

    private Animator animator;

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
}
