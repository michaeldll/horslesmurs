using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
	public AudioClip tap;
	public AudioClip gyro;
	public AudioClip main_end;
	public AudioClip main_fall;

	AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	void LaunchTap()
	{
		audioSource.PlayOneShot(tap, 10.0F);
	}

}
