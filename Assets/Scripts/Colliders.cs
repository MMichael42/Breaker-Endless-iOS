using UnityEngine;
using System.Collections;

public class Colliders : MonoBehaviour {


	private Camera camera;
	private GameObject top;
	private GameObject left;
	private GameObject right;


	// Use this for initialization
	void Start () {


		if (Screen.height == 1024) {

			top = GameObject.Find("TopWall");
			left = GameObject.Find("LeftWall");
			right = GameObject.Find("RightWall");
			

			Vector3 tempTop = top.transform.position;
			Vector3 tempLeft = left.transform.position;
			Vector3 tempRight = right.transform.position;

			tempTop.y = 13.64f;
			tempLeft.x = 2.67f;
			tempRight.x = 15.33f;

			top.transform.position = tempTop;
			left.transform.position = tempLeft;
			right.transform.position = tempRight;

		}



	}

}
