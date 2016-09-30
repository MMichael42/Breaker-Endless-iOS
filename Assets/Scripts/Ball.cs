using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {


	private Camera camera;

	void Start() {
			camera = GetComponent<Camera>();

		// center the ball on the iPad screens.
		if (Screen.height == 1024 || Screen.height == 2048) {

			Vector3 tempBallPosX = this.transform.position;
			tempBallPosX.x = 10.05f / 2;
			this.transform.position = tempBallPosX;

		}
	}


	void OnCollisionEnter2D(Collision2D collision) {
	
	
		// use this vector 3 to tweak the ball velocity each impact, to avoid boring bouncing loops
		// Vector2 tweak = new Vector2(Random.Range(0f, 0.35f), Random.Range(0f, 0.35f));
		Vector2 tweak = new Vector2(Random.Range(-0.35f, 0.35f), Random.Range(0f, 0.35f));
		GetComponent<Rigidbody2D>().velocity += tweak;

		
	
	}

	
}
