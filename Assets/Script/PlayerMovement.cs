using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerEnergy))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private PlayerControls playerControls;
    private Vector2 moveInput;
    private PlayerEnergy energy;

    private bool isSprinting;

    [Header("Movement Settings")]
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public float rotationSpeed = 10.0f;

    [Header("Animation Settings")]
    public float speedDampTime = 0.1f;

    [Header("Energy Drain Rates")]
    public float walkDrain = 5f;
    public float runDrain = 10f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        energy = GetComponent<PlayerEnergy>();
        playerControls = new PlayerControls();

        playerControls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerControls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        playerControls.Player.Sprint.performed += ctx => isSprinting = true;
        playerControls.Player.Sprint.canceled += ctx => isSprinting = false;
    }

    private void OnEnable() => playerControls.Player.Enable();
    private void OnDisable() => playerControls.Player.Disable();

    private void Update()
    {
        HandleMovement();
        HandleAnimation();
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = (transform.right * moveInput.x + transform.forward * moveInput.y).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            bool canSprint = isSprinting && energy.currentEnergy > 0;
            float currentSpeed = canSprint ? runSpeed : walkSpeed;

            controller.Move(moveDirection * currentSpeed * Time.deltaTime);

            // Energy Logic
            float currentDrain = canSprint ? runDrain : walkDrain;
            energy.UseEnergy(currentDrain);
        }

        if (!controller.isGrounded)
        {
            controller.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime);
        }
    }

    private void HandleAnimation()
    {
        float inputMagnitude = moveInput.magnitude;
        float targetAnimationSpeed = 0f;

        if (inputMagnitude > 0.1f)
        {
            bool canSprint = isSprinting && energy.currentEnergy > 0;
            targetAnimationSpeed = canSprint ? 1.0f : 0.5f;
        }

        animator.SetFloat("Speed", targetAnimationSpeed, speedDampTime, Time.deltaTime);
    }
}