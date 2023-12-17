using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : Player
{
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] public float moveSpeed = 15f;
    [SerializeField] private Animator animator;


    protected override void Awake() {
        base.Awake();

        userInput = new UserInput();

        if (userInput == null) {
                Debug.LogError("UserInput controls not assigned.");
                return;
        }
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void _2Dmovement(InputAction.CallbackContext context) {
        //Debug.Log("Move");
    }

    private void OnEnable() {
        userInput.Gameplay.Talk.performed += Talk;
        userInput.Gameplay._2DMovement.performed += _2Dmovement;
    }

    private void OnDisable() {
        userInput.Gameplay.Talk.performed -= Talk;
        userInput.Gameplay._2DMovement.performed -= _2Dmovement;
    }

    private void Talk(InputAction.CallbackContext context) {

    }
    void Update()
    {
        moveDirection = userInput.Gameplay._2DMovement.ReadValue<Vector2>();
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        moveDirection = userInput.Gameplay._2DMovement.ReadValue<Vector2>();
        Vector2 pos = transform.position;
		pos += moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
        transform.position = pos;
    }
}
