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


		if (screenText == 960) {
			Debug.Log("this is an iphone 4, move the score down");

			Vector3 iPhone4Ypos = transform.position;
			iPhone4Ypos.y = 914f;
			scoreText.transform.position = iPhone4Ypos;
		}
		
	}
	
	
	public void AddScore(int points) {
	
		GameState.score += points;
		scoreText.text = GameState.score.ToString();
		
	}
	
}
