using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverBrickTop : MonoBehaviour {

	public GameObject brickPrefab;
	public GameObject positionPrefab;
	public float scrollDownSpeed = 1f;
	public float scrollSideWaysSpeed = 1f;
	public float spawnDelay = 2f;
	public float spawnDelayHorizontal = 1f;


	private Vector3 brickPositionSpawn;

	private float brickXOffset = 2f;
	private float brickXpos = 0f;
	private float brickXspawnStart = -1.95f;


	private float brickYOffset = 0.60f;
	private float brickYpos = 14f;


	private float brickXfullScreen = 0f;
	private int numOfBricksTall;


	
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
			numOfBricksTall = 3;
		} else if (Screen.height == 1024 || Screen.height == 2048) {
			numOfBricksTall = 1;
		} else {
			numOfBricksTall = 5;
		}


		// spawn full screen of bricks
		SpawnBricksFullScreen();
		// run the function that spawns bricks and scrolls the sideways. 
		InvokeRepeating("SpawnBricksHorizontal", .000000001f, spawnDelayHorizontal);

				
	}


	// Update is called once per frame
	void Update () {

			ScrollBricksHorizontal();

	}


	// spawn positions and bricks in one go
	public void SpawnBricksFullScreen() { 
		
		// spawn the positions across the y access
		for (float x = 0; x < (numOfBricksTall * 5); x++) {
			
			brickPositionSpawn = new Vector3(brickXfullScreen, brickYpos, -1f);
			GameObject positionSpawn = Instantiate(positionPrefab, brickPositionSpawn, Quaternion.identity) as GameObject;
			positionSpawn.transform.parent = transform;

			brickYpos -= brickYOffset;

			if ((x + 1) % numOfBricksTall == 0) {
				brickXfullScreen += brickXOffset;
				brickYpos = 14f;
			}


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


		}




	}



	// spawn positions and bricks in one go
	public void SpawnBricksHorizontal() { 
		
		// spawn the positions across the y access
		for (float x = 0; x < numOfBricksTall; x++) {
			
			brickPositionSpawn = new Vector3(brickXspawnStart, brickYpos, -1f);
			GameObject positionSpawn = Instantiate(positionPrefab, brickPositionSpawn, Quaternion.identity) as GameObject;
			positionSpawn.transform.parent = transform;

			brickYpos -= brickYOffset;

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

			if (child.transform.position.x > 12f) {
				Destroy(child.gameObject);
			}

		}
	
		
		
		// put the brick x position back to the start for the next row sapw
		brickXpos = 0f;	
		brickYpos = 14f;



	}








	// scroll dem bricks down
	void ScrollBricksHorizontal() { 
		// change this so X is moving and Y is zero.
		this.transform.position += new Vector3(+scrollSideWaysSpeed * Time.deltaTime, 0);
	}
}
