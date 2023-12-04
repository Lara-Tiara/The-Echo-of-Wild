using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionMovement : MonoBehaviour
{
	public float moveSpeed = 3f;
	public Rigidbody2D rb;
	public Animator animator;

	Vector2 movement;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

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
		Vector2 pos = transform.position;
		pos += movement.normalized * moveSpeed * Time.fixedDeltaTime;
		//rb.MovePosition(rb.position * movement * moveSpeed * Time.fixedDeltaTime);
		transform.position = pos;
	}
}