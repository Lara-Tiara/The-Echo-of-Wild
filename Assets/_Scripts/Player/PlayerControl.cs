using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public UserInput controls;
    private Vector2 moveDirection;
    private InputAction move;
    [SerializeField] public float moveSpeed = 15f;
    [SerializeField] private Animator animator;

    private void Awake() {
		rb = this.GetComponent<Rigidbody2D>();
        controls = new UserInput();
        if (controls == null) {
        Debug.LogError("UserInput controls not assigned.");
        return;
        }
        controls.Gameplay._2DMovement.performed += ctx => _2Dmovement(ctx);
        animator = GetComponent<Animator>();
	}
    void Update() {
        if (DialogueManager.dialogueIsPlaying || SignTrigger.isSignCanvasActive) {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
            return;
        }
        moveDirection = controls.Gameplay._2DMovement.ReadValue<Vector2>();
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (DialogueManager.dialogueIsPlaying || SignTrigger.isSignCanvasActive) {
            return;
        }
        moveDirection = controls.Gameplay._2DMovement.ReadValue<Vector2>();
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        //rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        //Vector2 pos = transform.position;
		//pos += moveDirection.normalized * moveSpeed;
        //transform.position = pos;
    }

    public void _2Dmovement(InputAction.CallbackContext context) {
        //Debug.Log("Move");
    }

     private void OnEnable() {
        move = controls.Gameplay._2DMovement;
        controls.Gameplay.Enable();
    }

    private void OnDisable() {
        move = controls.Gameplay._2DMovement;
        controls.Gameplay.Disable();
    }
}