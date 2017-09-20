using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

	[SerializeField]
	private AudioClip coinClip, lifeClip;

	private CameraScript cameraScript;

	private Vector3 previousPosition;
	private bool countScore;

	public static int scoreCount;
	public static int lifeCount;
	public static int coinCount;

	void Awake () {
		cameraScript = Camera.main.GetComponent<CameraScript> ();
	}

	// Use this for initialization
	void Start () {
		//GameplayController.gameplayController.SetScore (scoreCount);
		//GameplayController.gameplayController.SetCoinCount (coinCount);
		//GameplayController.gameplayController.SetLifeCount (lifeCount);
		previousPosition = transform.position;
		countScore = true;
	}
	
	// Update is called once per frame
	void Update () {
		CountScore ();
	}

	void CountScore(){
		if (countScore) {
			if (transform.position.y < previousPosition.y) {
				scoreCount++;

			}
			previousPosition = transform.position;
			GameplayController.gameplayController.SetScore (scoreCount);
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		// collect a coin
		if (target.tag == "Coin") {
			coinCount++;
			scoreCount += 200;
			GameplayController.gameplayController.SetScore (scoreCount);
			GameplayController.gameplayController.SetCoinCount (coinCount);
			AudioSource.PlayClipAtPoint (coinClip, transform.position);
			target.gameObject.SetActive (false);
		}

		//collect a life
		if (target.tag == "Life") {
			lifeCount++;
			scoreCount += 300;
			GameplayController.gameplayController.SetScore (scoreCount);
			GameplayController.gameplayController.SetLifeCount (lifeCount);
			AudioSource.PlayClipAtPoint (lifeClip, transform.position);
			target.gameObject.SetActive (false);
		}

		//bounds are the vertical bounds.
		// if a player is too high or too low or touches dark cloud he dies
		if (target.tag == "Bounds" || target.tag == "Deadly") {
			
			cameraScript.moveCamera = false;
			countScore = false;

			transform.position = new Vector3 (500, 500, 0); // move player outside the camera
			lifeCount--;
			GameManager.instance.CheckGameStatus (scoreCount, coinCount, lifeCount);
		
		}
	}
}
