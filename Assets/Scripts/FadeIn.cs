﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDirection = -1;

	void OnGUI() {

		alpha += fadeDirection * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), fadeOutTexture);

	}


	public float BeginFade(int direction) {
		fadeDirection = direction;
		return(1 / fadeSpeed);
	}

	void OnLevelWasLoaded() {
		// alpha = 1;
		BeginFade(-1);

	}


}
