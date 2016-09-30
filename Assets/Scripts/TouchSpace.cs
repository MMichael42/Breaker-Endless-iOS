using UnityEngine;
using System.Collections;

public class TouchSpace : MonoBehaviour {


	private Paddle paddle;
	private Ball ball;
	private Collider2D touchSpace;
	private float screenBlockMultiplier = 8f; // number of world units wide when an iPhone.

	
	
	// Use this for initialization
	void Start () {
	
		paddle = GameObject.FindObjectOfType<Paddle>();
		ball = GameObject.FindObjectOfType<Ball>();

		if (Screen.height == 1024 || Screen.height == 2048) {
			screenBlockMultiplier = 10.7f; // this is how man world units the screen is wide when run on an ipad, portrait.
		}

	}
	
	// Update is called once per frame
	void Update () {
	
			if (Input.GetMouseButton(0)) {
				
				if (GameState.ballHasLaunched == false) {
					// launch the ball
					LaunchBall();
					// new game has started, so set this to false
					GameState.ballHasLaunched = true;
					
				}
				MoveWithMouse();
			}
		
	
	}
	
	void MoveWithMouse () {
	
		Vector3 paddlePos = new Vector3(0.5f, paddle.transform.position.y, 0f);
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width) * screenBlockMultiplier;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, paddle.paddleMinX, paddle.paddleMaxX);
		paddle.transform.position = paddlePos;
			
	}
	

	
	void LaunchBall() {
		ball.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
	}

	
}
