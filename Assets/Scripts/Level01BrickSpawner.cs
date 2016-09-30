using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level01BrickSpawner : MonoBehaviour {

	public GameObject brickPrefab;
	public GameObject positionPrefab;
	public float scrollDownSpeed = 1f;
	public float spawnDelay = 2f;


	private Vector3 brickPositionSpawn;

	private float brickXOffset = 2f;
	private float brickXpos = 1f;
	private float brickXposIpad = -1f;

	private float brickYOffset = 0.60f;
	private float brickYpos = 13f;

	private int numBricksToSpawn = 4;
	private int numBricksToSpawnIpad = 6;
	
	// colors to choose  from randomly
	private Color color1 = new Color(.900f, .700f, .100f, 1f); // 229.50   178.50    25.50 - this is the yellowish color
	private Color color2 = new Color(.900f, .200f, .000f, 1f); // 229.50    51.00     0.00 - this is a redish color
	private Color color3 = new Color(.500f, .500f, .150f, 1f); // 127.50   127.50    38.25 - this is the poopy yellow=green-brown
	// for the color conversions, I used this site: http://www.easyrgb.com/index.php?X=CALC#Result
	
	private Color[] colorsArray;


	// Use this for initialization
	void Start () {	
		
		// init the array and stuff it full of those colors. Is there a better, one line way to do this? Or maybe a for loop!
		colorsArray = new Color[3];
		colorsArray[0] = color1;
		colorsArray[1] = color2;
		colorsArray[2] = color3;

		if (Screen.height == 960) {
			brickYpos = 12f;
		}

		if (Screen.height == 1024) {
			brickXpos = brickXposIpad;
			numBricksToSpawn = numBricksToSpawnIpad;
		}

	
		// if this is the start screen, spawn the bricks for decoration.
		if (SceneManager.GetActiveScene().name == "Level01") {			
			// run the function that spawns bricks and scrolls the sideways. 
			InvokeRepeating("SpawnBricks", .000000001f, spawnDelay);
		}
				
	}


	// Update is called once per frame
	void Update () {

			ScrollBricks();

	}



	// spawn positions and bricks in one go
	public void SpawnBricks() { 
		
		// spawn the positions across the y access
		for (float x = 0; x < numBricksToSpawn; x++) {
			
			brickPositionSpawn = new Vector3(brickXpos, brickYpos, -1f);
			GameObject positionSpawn = Instantiate(positionPrefab, brickPositionSpawn, Quaternion.identity) as GameObject;
			positionSpawn.transform.parent = transform;

			brickXpos += brickXOffset;

		}

		
		// spawn the prefabs at the positions
		foreach (Transform child in transform) {
		
			// if the child doesn't have a brick, spawn a brick
			if (child.childCount <= 0){ 
				GameObject brickSpawn = Instantiate(brickPrefab, child.position, Quaternion.identity) as GameObject;
			
				SpriteRenderer sprite = brickSpawn.GetComponent<SpriteRenderer>();
				sprite.color = colorsArray[Random.Range(0,3)];
						
				brickSpawn.transform.parent = child;

			}

			/*
			if (child.transform.position.y > -2f) {
				Destroy(child.gameObject);
			}
			*/
		}
	
		if (Screen.height == 1024) {
			brickXpos = brickXposIpad;
		} else {
			// put the brick x position back to the start for the next row sapw
			brickXpos = 1f;	
			// brickYpos = 13f;
		}
		




	}

	// scroll dem bricks down
	void ScrollBricks() { 
		// change this so X is moving and Y is zero.
		this.transform.position += new Vector3(0, -scrollDownSpeed * Time.deltaTime);
	}
}

