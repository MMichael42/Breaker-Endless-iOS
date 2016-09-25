using UnityEngine;
using System.Collections;

public class LoadStart : MonoBehaviour {

	

	// Use this for initialization
	void Start () {

		LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
			
			// if we found it, then:
			if (levelManager) {
			
				levelManager.LoadLevel("StartScreen");
					
				
			} else {
				Debug.LogError("something very bad happened");
			}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
