using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour {
	[SerializeField]
	private float MoveSpeed = 10;

	[SerializeField]
	private float SprintSpeed = 30;

	protected CharacterController movementController;

	private Vector3 fallVelocity;


	private void Start() {
		movementController = GetComponent<CharacterController>();  //  Character Controller
	}

	private void Update() {
		Vector3 walkDirection = Vector3.zero;
		walkDirection += transform.forward * Input.GetAxisRaw("Vertical");
		walkDirection += transform.right * Input.GetAxisRaw("Horizontal");

		walkDirection.Normalize();

		fallVelocity += -9.81f * Time.deltaTime * transform.up;  // Gravity

		float currMoveSpeed = Input.GetKey(KeyCode.LeftShift) ? SprintSpeed : MoveSpeed;

		movementController.Move(Time.deltaTime * (currMoveSpeed * walkDirection + fallVelocity));
	}
}
