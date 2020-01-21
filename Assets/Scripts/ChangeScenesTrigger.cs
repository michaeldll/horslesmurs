using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenesTrigger : MonoBehaviour
{
	public bool enter = true;
	public MeshCollider meshCollider;

	private void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene(1);
	}
}