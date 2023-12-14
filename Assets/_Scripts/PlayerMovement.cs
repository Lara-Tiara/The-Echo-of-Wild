using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 3f;
	public Rigidbody2D rb;
	public Animator animator;

	private Vector2 movement;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}


	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}
/*
	 private void OnEnable() {
        userInput.Gameplay._2DMovement.performed += _2Dmovement;
    }

    private void OnDisable() {
        userInput.Gameplay._2DMovement.performed -= _2Dmovement;
    }
*/
	//private void _2Dmovement(InputAction.CallbackContext context) {}
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);
	}

	void FixedUpdate()
	{
		//movement = userInput.Gameplay._2DMovement.ReadValue<Vector2>();
		//rb.AddForce(moveDirection * move);
		Vector2 pos = transform.position;
		pos += movement.normalized * moveSpeed * Time.fixedDeltaTime;
		//rb.MovePosition(rb.position * movement * moveSpeed * Time.fixedDeltaTime);
		transform.position = pos;
	}
}

