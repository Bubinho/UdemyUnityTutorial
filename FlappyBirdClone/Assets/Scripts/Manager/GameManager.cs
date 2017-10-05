using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	private const string HIGHSCORE = "highscore";
	private const string SELECTED_BIRD = "selected bird";
	private const string GREEN_BIRD = "green bird";
	private const string RED_BIRD = "red bird";


	void Awake () {
		CreateGameManager ();
		GameStartedForFirstTime ();
		//PlayerPrefs.DeleteAll ();

	}

	void CreateGameManager(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void GameStartedForFirstTime (){
		if(PlayerPrefs.HasKey("StartedForFirstTime") == false){
			PlayerPrefs.SetInt (HIGHSCORE, 0);
			PlayerPrefs.SetInt (SELECTED_BIRD, 0);
			PlayerPrefs.SetInt (GREEN_BIRD, 0);
			PlayerPrefs.SetInt (RED_BIRD, 0);
			PlayerPrefs.SetInt ("StartedForFirstTime", 0);
		}
	}

	public int GetHighScore(){
		return PlayerPrefs.GetInt (HIGHSCORE);
	}

	public void SetHighScore(int score){
		PlayerPrefs.SetInt (HIGHSCORE, score);
	}

	public int GetSelectedBird(){
		return PlayerPrefs.GetInt (SELECTED_BIRD);
	}

	public void SetSelectedBird(int selectedBird){
		PlayerPrefs.SetInt (SELECTED_BIRD, selectedBird);
	}

	public int IsGreenBirdUnlocked(){
		return PlayerPrefs.GetInt (GREEN_BIRD);
	}

	public void UnlockGreenBird(){
		PlayerPrefs.SetInt (GREEN_BIRD, 1);
	}
		
	public int IsRedBirdUnlocked(){
		return PlayerPrefs.GetInt (RED_BIRD);
	}

	public void UnlockRedBird(){
		PlayerPrefs.SetInt (RED_BIRD, 1);
	}
	

}
