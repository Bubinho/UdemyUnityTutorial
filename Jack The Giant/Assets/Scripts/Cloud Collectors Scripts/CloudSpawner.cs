using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] clouds;

	private float distanceBetweenClouds = 3.0f;
	private float minX, maxX;
	private float lastCloudPositionY;

	[SerializeField]
	private GameObject[] collectables;

	private float controlX; // used to determine ich next cloud has to be on the left or right side
	private GameObject player;


	void Awake () {
		controlX = 0;
		SetMinAndMaxX ();
		CreateClouds ();
		player = GameObject.Find ("Player");
	}

	void Start(){
		PositionPlayer ();
	}

	void SetMinAndMaxX(){
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0));
		maxX = bounds.x - (clouds [0].GetComponent<SpriteRenderer> ().sprite.bounds.size.x / 4.0f);
		minX = -bounds.x + (clouds [0].GetComponent<SpriteRenderer> ().sprite.bounds.size.x / 4.0f);
	}

	void Shuffle(GameObject[] arrayToShuffle){
		for(int i = 0; i < arrayToShuffle.Length; i++){
			GameObject temp = arrayToShuffle [i];
			int random = Random.Range (i, arrayToShuffle.Length);
			arrayToShuffle [i] = arrayToShuffle [random];
			arrayToShuffle [random] = temp;
		}
	}
	void CreateClouds(){
		Shuffle (clouds);
		float positionY = 0;
		for (int i = 0; i < clouds.Length; i++) {
			Vector3 temp = clouds [i].transform.position;

			temp.y = positionY;

			// avoid clouds exact under cloud above
			if (controlX == 0) {
				temp.x = Random.Range (0.0f, maxX);
				controlX = 1;
			}else if(controlX == 1){
				temp.x = Random.Range (0.0f, minX);
				controlX = 2;
			}else if(controlX == 2){
				temp.x = Random.Range (1.0f, maxX);
				controlX = 3;
			}
			else if(controlX == 3){
				temp.x = Random.Range (-1.0f, minX);
				controlX = 0;
			}

			lastCloudPositionY = positionY;
			clouds [i].transform.position = temp;

			positionY -= distanceBetweenClouds;
		}
	}

	void PositionPlayer(){
		GameObject[] darkClouds = GameObject.FindGameObjectsWithTag ("Deadly");
		GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag ("Cloud");

		// change dark clouds position if its on the first place
		for (int i = 0; i < darkClouds.Length; i++) {
			if(darkClouds[i].transform.position.y == 0f){
				Vector3 temp = darkClouds [i].transform.position;
				darkClouds [i].transform.position = new Vector3 (cloudsInGame[0].transform.position.x,
																 cloudsInGame[0].transform.position.y,
																 cloudsInGame[0].transform.position.z);
				cloudsInGame [0].transform.position = temp;
			}
		}

		// get the first cloud and set player poition to it
		Vector3 t = cloudsInGame[0].transform.position;
		for(int i = 1; i < cloudsInGame.Length; i++){
			if(t.y < cloudsInGame[i].transform.position.y){
				t = cloudsInGame[i].transform.position;
			}
		}
		t.y += (player.GetComponent<SpriteRenderer> ().bounds.size.y / 4.0f) + 0.1f;
		player.transform.position = t;
	}

	void OnTriggerEnter2D(Collider2D target) {

		if (target.tag == "Cloud" || target.tag == "Deadly") {
			if (target.transform.position.y == lastCloudPositionY) {
				Shuffle (clouds);
				Shuffle (collectables);

				Vector3 temp = target.transform.position;

				for(int i = 0; i < clouds.Length; i++){ // go through al clouds
					if(!clouds[i].activeInHierarchy){ // respawn cloud only if its not active
						// avoid clouds exact under cloud above
						if (controlX == 0) {
							temp.x = Random.Range (0.0f, maxX);
							controlX = 1;
						}else if(controlX == 1){
							temp.x = Random.Range (0.0f, minX);
							controlX = 2;
						}else if(controlX == 2){
							temp.x = Random.Range (1.0f, maxX);
							controlX = 3;
						}
						else if(controlX == 3){
							temp.x = Random.Range (-1.0f, minX);
							controlX = 0;
						}

						temp.y -= distanceBetweenClouds;
						lastCloudPositionY = temp.y;

						clouds [i].transform.position = temp;
						clouds [i].SetActive (true);
					}
				}


			}
		}

	}


}
