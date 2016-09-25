using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LastScore : MonoBehaviour {


	private Text lastScoreText;

	// Use this for initialization
	void Start () {
	
		lastScoreText = GetComponent<Text>();
		lastScoreText.text = GameState.score.ToString();
	
	}

}
