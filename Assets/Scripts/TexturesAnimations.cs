using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TexturesAnimations : MonoBehaviour
{

	[SerializeField] private Material[] targetMats;
	[SerializeField] private GameObject[] artMaps;
	[SerializeField] private Material highLightMat;
	[SerializeField] private AudioSource[] audioSources;
	private bool[] animFlags;
	private Texture[] texturesA0;
	private Texture[] texturesA1;
	private Texture[] texturesA2;
	private Texture[] texturesA3;
	private int frameCounter = 0;
	private bool playingAnim = false;
	private int finishedCounter = 0;
	public static TexturesAnimations current;
	public event Action<int> onAnimFinished;


	private void Awake()
	{
		current = this;
	}

	void Start()
	{
		RaycastManager.current.onHitObject += onFindSign;
		UnityEngine.Object[] loadedFile0 = Resources.LoadAll("artSigns0", typeof(Texture));
		texturesA0 = new Texture[loadedFile0.Length];
		for (int i = 0; i < loadedFile0.Length; i++)
		{
			texturesA0[i] = (Texture)loadedFile0[i];
		}

		UnityEngine.Object[] loadedFile1 = Resources.LoadAll("artSigns1", typeof(Texture));
		texturesA1 = new Texture[loadedFile1.Length];
		for (int i = 0; i < loadedFile1.Length; i++)
		{
			texturesA1[i] = (Texture)loadedFile1[i];
		}

		UnityEngine.Object[] loadedFile2 = Resources.LoadAll("artSigns2", typeof(Texture));
		texturesA2 = new Texture[loadedFile2.Length];
		for (int i = 0; i < loadedFile2.Length; i++)
		{
			texturesA2[i] = (Texture)loadedFile2[i];
		}

		UnityEngine.Object[] loadedFile3 = Resources.LoadAll("artSigns3", typeof(Texture));
		texturesA3 = new Texture[loadedFile3.Length];
		for (int i = 0; i < loadedFile3.Length; i++)
		{
			texturesA3[i] = (Texture)loadedFile3[i];
		}


		animFlags = new bool[targetMats.Length];
		for (int i = 0; i < targetMats.Length; i++)
		{
			animFlags[i] = false;
		}

	}

	void onFindSign(RaycastHit hit)
	{
		if (playingAnim)
		{
			return;
		}
		else
		{
			int indexHit = hit.transform.GetSiblingIndex();
			playingAnim = true;
			animFlags[indexHit] = true;
			audioSources[indexHit].Play();
		}
	}


	void Update()
	{
		for (int i = 0; i < animFlags.Length; i++)
		{
			if (animFlags[i])
			{

				frameCounter += 1;
				Debug.Log(frameCounter);
				switch (i)
				{
					case 0:
						targetMats[i].mainTexture = texturesA0[frameCounter];
						if (frameCounter == texturesA0.Length - 1)
						{
							frameCounter = 0;
							animFlags[i] = false;
							Debug.Log("ya");
							onAnimFinished(i);
							Debug.Log("yo");
							playingAnim = false;
							artMaps[i].GetComponent<Renderer>().material = highLightMat;
							finishedCounter++;
						}
						break;

					case 1:
						targetMats[i].mainTexture = texturesA1[frameCounter];
						if (frameCounter == texturesA1.Length - 1)
						{
							frameCounter = 0;
							animFlags[i] = false;
							Debug.Log("ya");
							onAnimFinished(i);
							Debug.Log("yo");
							playingAnim = false;
							artMaps[i].GetComponent<Renderer>().material = highLightMat;
							finishedCounter++;

						}
						break;

					case 2:
						targetMats[i].mainTexture = texturesA2[frameCounter];
						if (frameCounter == texturesA2.Length - 1)
						{
							frameCounter = 0;
							animFlags[i] = false;
							Debug.Log("ya");
							onAnimFinished(i);
							Debug.Log("yo");
							playingAnim = false;
							artMaps[i].GetComponent<Renderer>().material = highLightMat;
							finishedCounter++;

						}
						break;

					case 3:
						targetMats[i].mainTexture = texturesA3[frameCounter];
						if (frameCounter == texturesA3.Length - 1)
						{
							frameCounter = 0;
							animFlags[i] = false;
							Debug.Log("ya");
							onAnimFinished(i);
							Debug.Log("yo");
							playingAnim = false;
							artMaps[i].GetComponent<Renderer>().material = highLightMat;
							finishedCounter++;

						}
						break;
				}
				if (finishedCounter == 4)
				{
					Debug.Log("YOU FOUND EVERYTHING");
					SceneManager.LoadScene(2);
				}
			}
		}
	}
}
