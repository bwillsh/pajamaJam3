﻿using UnityEngine;
using System.Collections;

public class TimedAlpha : MonoBehaviour {
	
	public float speed;
	public float timeDelay;
	public float startAlpha;
	public float endAlpha;

	public bool flashing;
	public float flashSpeed;

	float percent;
	float flashPercent;
	Color startColor;
	Color endColor;

	bool fadeIn;
	Color on = new Color (1f, 1f, 1f, 0.95f);
	Color off = new Color (1f, 1f, 1f, 0f);

	void Start() {
		startColor = new Color (1f, 1f, 1f, startAlpha);
		endColor = new Color (1f, 1f, 1f, endAlpha);

		GetComponent<SpriteRenderer> ().color = startColor;
		fadeIn = true;
	}

	// Update is called once per frame
	void Update () {
		
		if (timeDelay <= 0) {
			percent += Time.deltaTime * speed;


			GetComponent<SpriteRenderer> ().color = Color.Lerp (startColor, endColor, percent);

			if (flashing) {
				flashPercent += Time.deltaTime * flashSpeed;
				float percentNew = Mathf.Sin (flashPercent);
				percentNew = (percentNew + 1f) / 2f;
				GetComponent<SpriteRenderer> ().color = Color.Lerp (startColor, endColor, percentNew);
					
			}
			
		} else {
			timeDelay -= Time.deltaTime;
		}
	}

}
