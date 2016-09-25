using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

	
	private Text highScoreText;
	

	// Use this for initialization
	void Start () {
	
		highScoreText = GetComponent<Text>();
		highScoreText.text = GameState.highScore.ToString();
	
	}
	


}
