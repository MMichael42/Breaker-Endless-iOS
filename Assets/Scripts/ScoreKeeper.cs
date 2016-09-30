using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	
	private Text scoreText;
	private int screenText;

	
	// Use this for initialization
	void Start () {
	
		scoreText = GetComponent<Text>();
		screenText = Screen.height;

		// move the score text based on what screen the game is being played on. The default value is for iPhone 5 and beyond.
		if (screenText == 960) { // iphone4

			Vector3 iPhone4Ypos = transform.position;
			iPhone4Ypos.y = 914f;
			scoreText.transform.position = iPhone4Ypos;

		} else if (screenText == 1024) { // iPad

			Vector3 iPadYpos = transform.position;
			iPadYpos.y = 950f;
			scoreText.transform.position = iPadYpos;

		} else if (screenText == 2048) { // retina iPad

			Vector3 iPadYpos = transform.position;
			iPadYpos.y = 1900f;
			scoreText.transform.position = iPadYpos;

		}
		
	}
	
	
	public void AddScore(int points) {
	
		GameState.score += points;
		scoreText.text = GameState.score.ToString();
		
	}
	
}
