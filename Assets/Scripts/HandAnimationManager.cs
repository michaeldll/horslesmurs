using UnityEngine;
using System.Collections;

public class HandAnimationManager : MonoBehaviour
{
	public Animator anim;
	private Vector2 startPos;
	private Vector2 direction;
	private bool directionChosen;
	private bool animationPlayed = false;

	void Start()
	{

	}

	void Update()
	{
		anim = gameObject.GetComponent<Animator>();

		// Track a single touch as a direction control.
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			// Handle finger movements based on touch phase.
			switch (touch.phase)
			{
				// Record initial touch position.
				case TouchPhase.Began:
					startPos = touch.position;
					directionChosen = false;
					break;

				// Determine direction by comparing the current touch position with the initial one.
				case TouchPhase.Moved:
					direction = touch.position - startPos;
					break;

				// Report that a direction has been chosen when the finger is lifted.
				case TouchPhase.Ended:
					directionChosen = true;
					break;
			}
		}
		if (directionChosen && !animationPlayed || Input.GetKeyDown(KeyCode.Alpha1) && !animationPlayed)
		{
			animationPlayed = true;
			anim.Play("Separate Hands");
		}
	}
}

