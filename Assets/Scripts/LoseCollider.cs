using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D collider) {

		// if the ball hits the lose collider off screen, GAME OVER.		
		if (collider.tag == "ball") {
			// find the LevelManager GameObject in the scene
			LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
			
			// if we found it, then:
			if (levelManager) {
			
				levelManager.LoadLevel("GameOverScene");
					
				
			} else { // we didn't find it? Big error. Should never happen.
				Debug.LogError("No level manager found? Shit is messed up");
			}
		}
	}

	
}
