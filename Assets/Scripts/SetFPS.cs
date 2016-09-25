using UnityEngine;
using System.Collections;

public class SetFPS : MonoBehaviour {
	

	void Awake() {
		Application.targetFrameRate = 60;
	
	}	

}
