using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	static GameState instance = null;
	public static bool playerIsAlive;
	public static bool newGameStarting;
	public static bool ballHasLaunched = false;
	public static int score;
	public static int highScore;



	void Start() {
		
		if (instance != null) {
			Destroy(gameObject);
			Debug.Log ("gameState already exists, destorying new one");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		
		playerIsAlive = true;
		newGameStarting = true;
		score = 0;
		
		
		
	}


}
