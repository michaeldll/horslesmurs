using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelCamera : MonoBehaviour
{
	public Rigidbody rb;
	public Vector3 accel;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		// Moves the GameObject using it's transform.
		rb.isKinematic = true;
	}

	void FixedUpdate()
	{
		accel = new Vector3(Input.acceleration.x * 20, 0, -Input.acceleration.z * 20);

		Debug.Log(transform.position);
		Debug.Log(accel);
		Debug.Log(transform.position + accel);

		var desiredPosition = transform.position + accel * Time.fixedDeltaTime;
		var currentPosition = transform.position;

		Vector3 direction = desiredPosition - currentPosition;

		Ray ray = new Ray(transform.position, direction);
		RaycastHit hit;

		if (!Physics.Raycast(ray, out hit, direction.magnitude))
			rb.MovePosition(desiredPosition);
		else
			rb.MovePosition(hit.point);
	}
}
