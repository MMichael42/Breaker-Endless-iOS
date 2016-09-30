using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {


	private float cameraSizeIphone4 = 6.0f;
	private float cameraSizeIphoneElse = 7.11f;
	private float cameraSizeIpad = 7.11f; // height is the same between iphone5 and iPads?
	private Camera camera;
	private GameObject cameraParent;




	// Use this for initialization
	void Start () {

		camera = GetComponent<Camera>();
		cameraParent = GameObject.Find("CameraParent");

		if (Screen.height == 960) {

			camera.orthographicSize = cameraSizeIphone4;

		} else if (Screen.height == 1024 || Screen.height == 2048) {

			camera.orthographicSize = cameraSizeIpad;

			// move the camera parent over so the camera is at 0,0,0
			Vector3 tempCamParentX = cameraParent.transform.position;
			tempCamParentX.x = 5.34f; 
			cameraParent.transform.position = tempCamParentX;

		} else {
			camera.orthographicSize = cameraSizeIphoneElse;
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
