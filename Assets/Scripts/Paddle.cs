using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float paddleMinX;
	public float paddleMaxX;

	private Camera camera;

	void Start() {

		camera = GetComponent<Camera>();

		if (Screen.height == 1024) {
			paddleMaxX = 8.7f;
			paddleMinX = -0.7f;
		}

	}

		
}
