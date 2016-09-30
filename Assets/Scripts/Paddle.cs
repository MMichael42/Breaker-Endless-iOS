using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float paddleMinX;
	public float paddleMaxX;

	private Camera camera;

	void Start() {

		camera = GetComponent<Camera>();


		if (Screen.height == 1024 || Screen.height == 2048) {
			// set new min and max x values for the clamp in the touchSpace script
			paddleMaxX = 10.05f;
			paddleMinX = 0.65f;

			// center the paddle on iPad screens
			Vector3 tempPaddlePosX = this.transform.position;
			tempPaddlePosX.x = paddleMaxX / 2;
			this.transform.position = tempPaddlePosX;

		}


	}

		
}
