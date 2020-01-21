using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Separate : StateMachineBehaviour
{
	private CameraManager cameraManager;

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// Finds the object the script "CameraManager" is attached to and assigns it to the gameobject called g.
		GameObject g = GameObject.FindGameObjectWithTag("MainCamera");
		//assigns the script component "CameraManager" to the public variable of type "CameraManager".
		cameraManager = g.GetComponent<CameraManager>();
		cameraManager.animationEnded = true;
		// Debug.Log("ended");
	}
}
