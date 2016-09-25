using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {


	public int maxHits;
	public int pointValue = 1;
	
	
	private ScoreKeeper scoreKeeper;
	
	
	
	// Use this for initialization
	void Start () {
	
		scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();		
	
	}

	
	
	void OnCollisionEnter2D(Collision2D collision) {


		scoreKeeper.AddScore(pointValue);
		Destroy(transform.parent.gameObject);		
		
	}
	
	
}
