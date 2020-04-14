using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public Transform[] transforms;
	public float transitionSpeed;
	public Camera[] cams;
	Transform currentTransform;
	public GameObject hands;
	public GameObject childHand;
	public GameObject gyroscopeIcon;
	public bool animationEnded = false;
	private bool viewsHaveSwitched = false;

	void Start()
	{
		cams[0].enabled = true;
		cams[1].enabled = false;
		currentTransform = transforms[0];
	}

	void Update()
	{
		if (animationEnded && !viewsHaveSwitched)
		{
			viewsHaveSwitched = true;
			currentTransform = transforms[1];

			Invoke("DisableHand", 0.1f);
			Invoke("EnableGyroscope", 4.6f);
			Invoke("SetViewToCurrent", 5.4f);
			Invoke("SwitchCameras", 6.8f);
		}
	}

	void DisableHand()
	{
		childHand.SetActive(false);
	}

	void EnableGyroscope()
	{
		gyroscopeIcon.SetActive(true); //2s delay in script
	}

	void SetViewToCurrent()
	{
		transitionSpeed += 0.2f;
		currentTransform = cams[1].transform;
	}

	void SwitchCameras()
	{
		cams[0].enabled = !cams[0].enabled;
		cams[1].enabled = !cams[1].enabled;
		hands.SetActive(false);
	}

	void LateUpdate()
	{
		transform.position = Vector3.Slerp(transform.position, currentTransform.position, Time.deltaTime * transitionSpeed);
		transform.rotation = Quaternion.Slerp(transform.rotation, currentTransform.rotation, Time.deltaTime * transitionSpeed);
	}
}
