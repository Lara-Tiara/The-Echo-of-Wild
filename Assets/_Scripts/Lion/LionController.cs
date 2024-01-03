using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LionController : MonoBehaviour
{
    public Rigidbody2D rb;
    public UserInput controls;
    private Vector2 moveDirection;
    private InputAction move;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float runSpeed;
    [SerializeField] private Animator animator;
    private bool isRunning = false;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        controls = new UserInput();
        controls.Gameplay.Enable();
        if (controls == null) {
            Debug.LogError("UserInput controls not assigned.");
            return;
        }

        controls.Gameplay._2DMovement.performed += ctx => _2Dmovement(ctx);
        controls.Gameplay.Run.performed += ctx => ToggleRun();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (DialogueManager.dialogueIsPlaying)
        {
            ResetMovement();
            return;
        }

        moveDirection = controls.Gameplay._2DMovement.ReadValue<Vector2>();
        UpdateAnimator(moveDirection);
    }

    void FixedUpdate()
    {
        if (DialogueManager.dialogueIsPlaying) {
            return;
        }

        float currentSpeed = isRunning ? runSpeed : moveSpeed;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void ToggleRun() {
        isRunning = !isRunning; 
        animator.SetBool("Run", isRunning); 
    }

    private void UpdateAnimator(Vector2 direction) {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    private void ResetMovement() {
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);
        animator.SetFloat("Speed", 0);
        animator.SetBool("Run", false);
    }

    private void OnEnable() {
        move = controls.Gameplay._2DMovement;
        controls.Gameplay.Enable();
    }

    private void OnDisable() {
        controls.Gameplay.Disable();
    }

    public void _2Dmovement(InputAction.CallbackContext context) {
        // Debug.Log("Move");
    }
}
