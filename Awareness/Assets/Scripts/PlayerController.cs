using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float accelerationForce = 5;

	[SerializeField]
	private float maxSpeed = 5;

	[SerializeField]
	private float jumpForce = 3;

	[SerializeField]
	private Rigidbody2D rb2d;

	[SerializeField]
	private Collider2D playerGroundCollider;

	[SerializeField]
	private Collider2D groundDetectTrigger;

	[SerializeField]
	private ContactFilter2D groundContactFilter;

	[SerializeField]
	private PhysicsMaterial2D playerMovingPhysicsMaterial, playerStoppingPhysicsMaterial;

	private float horizontalInput;
	private bool isOnGround;

	private Collider2D[] groundHitDetectionResults = new Collider2D[16];

	private void Update()
	{
		UpdateIsOnGround();
		UpdateHorizontalInput();
		HandleJumpInput();
	}

	private void FixedUpdate()
	{
		UpdatePhysicsMaterials();
		Move();
	}

	private void Move()
	{
		rb2d.AddForce(Vector2.right * horizontalInput * accelerationForce);
		Vector2 clampedVelocity = rb2d.velocity;
		clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = clampedVelocity;
	}

	private void UpdateHorizontalInput()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
	}

	private void UpdatePhysicsMaterials()
	{
		if (Mathf.Abs(horizontalInput) > 0)
		{
			playerGroundCollider.sharedMaterial = playerMovingPhysicsMaterial;
		}
		else
		{
			playerGroundCollider.sharedMaterial = playerStoppingPhysicsMaterial;
		}
	}

	private void HandleJumpInput()
	{
		if (Input.GetButtonDown("Jump") && isOnGround)
		{
			rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	private void UpdateIsOnGround()
	{
		isOnGround = groundDetectTrigger.OverlapCollider(groundContactFilter, groundHitDetectionResults) > 0;
	}
}
