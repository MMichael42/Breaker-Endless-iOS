using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	
	const string HIGH_SCORE_KEY = "high_score";


	// sets the hight score
	public static void SetHighScore (int highScore) {
		PlayerPrefs.SetInt (HIGH_SCORE_KEY, highScore);
	}
	
	// gets the high score
	public static int GetHighScore(){ 
		return PlayerPrefs.GetInt(HIGH_SCORE_KEY);
	
	}
	

}
