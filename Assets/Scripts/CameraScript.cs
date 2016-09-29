using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {


	private float cameraSizeIphone4 = 6.0f;
	private float cameraSizeIphoneElse = 7.11f;
	private float cameraSizeIpad = 7.11f;
	private Camera camera;



	// Use this for initialization
	void Start () {

		camera = GetComponent<Camera>();

		if (Screen.height == 960) {
			camera.orthographicSize = cameraSizeIphone4;
		} else if (Screen.height == 1024) {
			// iPad screen size.
			camera.orthographicSize = cameraSizeIpad;
		} else {
			camera.orthographicSize = cameraSizeIphoneElse;
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
