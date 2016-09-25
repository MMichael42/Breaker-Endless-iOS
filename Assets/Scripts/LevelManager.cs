using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {





	public void LoadLevel(string name) {
		// Debug.Log("Level load requested for " + name);
		
		
		// if we're going to the game screen, set the score to 0.
		// doing this allows the game over screen to keep the score of the last play session.
		if (name == "Level01") {
			// reset the appropiate variables now before we load into a new game
			GameState.score = 0;
			GameState.ballHasLaunched = false;
			GameState.newGameStarting = true;

		}
		
		
		// if the game over scene is triggered to load, do all this stuff before loading
		if (name == "GameOverScene") {
			
			// get the saved highscore from the playerprefs manager						
			int savedHighScore = PlayerPrefsManager.GetHighScore();
			
			// if that saved high score is less than the game that just ended score, make that the new high score in gamestate AND playerPrefs
			if (GameState.score > savedHighScore) {
				GameState.highScore = GameState.score;
				PlayerPrefsManager.SetHighScore(GameState.highScore);
			} else { // player score isn't higher than the saved highscore, so set the gamestate highscore to the saved highscore.
				GameState.highScore = savedHighScore;
			}
		
		}

		StartCoroutine(ChangeLevelFade(name));
	}



	IEnumerator ChangeLevelFade(string name) {


		float fadeTime = GameObject.Find("FadeInObject").GetComponent<FadeIn>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);

		SceneManager.LoadScene(name);
	}


}
