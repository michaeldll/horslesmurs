using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody rb;
	public float forwardForce = 5f;
	public float maxSpeed = 2f;
	public Camera playerCam;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (Input.GetKey("w"))
		{
			rb.AddForce(playerCam.transform.forward, ForceMode.VelocityChange);
		}

		if (Input.touchCount > 0)
		{
			rb.AddForce(playerCam.transform.forward, ForceMode.VelocityChange);
		}

		if (rb.velocity.magnitude > maxSpeed)
		{
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		}

	}
}

