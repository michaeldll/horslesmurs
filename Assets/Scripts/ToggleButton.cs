using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
	public CanvasGroup button;
	public bool autoFadeOut = false;
	public float autoFadeOutTime = 5.0f;
	public float startFadeTime = 2.0f;
	void Start()
	{
		button.alpha = 0;
		Invoke("FadeIn", startFadeTime);
		if (autoFadeOut) Invoke("FadeOut", startFadeTime + autoFadeOutTime);
	}

	void FadeIn()
	{
		StartCoroutine(FadeButton(button, button.alpha, 1));
	}
	void FadeOut()
	{
		StartCoroutine(FadeButton(button, button.alpha, 0));
	}

	public IEnumerator FadeButton(CanvasGroup btn, float start, float end, float lerpTime = 0.5f)
	{
		float _timeStartedLerping = Time.time;
		float timeSinceStarted = Time.time - _timeStartedLerping;
		float percentageComplete = timeSinceStarted / lerpTime;

		while (true)
		{
			timeSinceStarted = Time.time - _timeStartedLerping;
			percentageComplete = timeSinceStarted / lerpTime;

			float currentValue = Mathf.Lerp(start, end, percentageComplete);

			btn.alpha = currentValue;

			if (percentageComplete >= 1) break;

			yield return new WaitForEndOfFrame();
		}

		// print("done");
	}
}
