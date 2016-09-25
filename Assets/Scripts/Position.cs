using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {


	// this was used in that bit of commented out code below. Keeping it for now, just for my records.
	// private bool hitBeforeLaunchTriggered = false;
	
	
	void OnTriggerEnter2D(Collider2D collider) {
	
		/* this is no longer needed now that the ball's velocity is tweaked with each impact. 
		/* 
		// this determines if the player hasn't even begun to play yet, sending them to the game over screen
		// so they can't just sit still and rack up points.		
		if (collider.tag == "ball" && GameState.ballHasLaunched == false && hitBeforeLaunchTriggered == false) {
			
			hitBeforeLaunchTriggered = true;
			LevelManager levelMananger = GameObject.FindObjectOfType<LevelManager>();
			levelMananger.LoadLevel("GameOverScene");	
		}
		*/
		
		if (collider.tag == "paddle") {
			// player paddle as been hit by the positio collider, load game over scene
			LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
			levelManager.LoadLevel("GameOverScene");
		}
		
		if (collider.tag == "lose collider") {
			// destory the position thingy because it is now off screen
			Destroy (gameObject);
		}		
	}
	
	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 1f);
	}
	
}
