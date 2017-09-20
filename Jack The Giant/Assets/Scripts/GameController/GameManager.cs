using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[HideInInspector]
	public bool gameStartedFromMainMenu, gameStartedAfterDeath;

	[HideInInspector]
	public int score, coinCount, lifeCount;

	void Awake () {
		MakeGameManager ();
	}

	void Start(){
		InitializePreferences ();

	}

	void OnLevelWasLoaded() {
		if (SceneManager.GetActiveScene().name == "Gameplay"){
			if (gameStartedAfterDeath) {
				GameplayController.gameplayController.SetScore (score);
				GameplayController.gameplayController.SetCoinCount (coinCount);
				GameplayController.gameplayController.SetLifeCount (lifeCount);

				PlayerScore.scoreCount = score;
				PlayerScore.coinCount = coinCount;
				PlayerScore.lifeCount = lifeCount;
			} 
			else if (gameStartedFromMainMenu) {
				PlayerScore.scoreCount = 0;
				PlayerScore.coinCount = 0;
				PlayerScore.lifeCount = 2;

				GameplayController.gameplayController.SetScore (0);
				GameplayController.gameplayController.SetCoinCount (0);
				GameplayController.gameplayController.SetLifeCount (2);
			}
		}
	}

	void MakeGameManager(){
		// avoid to create multiple GameManagers when changing scenes
		if(instance != null){
			Destroy (gameObject);
		}else{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void CheckGameStatus(int score, int coinCount, int lifeCount){
		if(lifeCount < 0){ // player is gameOver

			// update higscores if necessary
			// for easy
			if (GamePreferences.GetEasyDifficulty () == 1) {
				int highScore = GamePreferences.GetEasyDifficultyHighScore ();
				int coinHighScore = GamePreferences.GetEasyDifficultyCoinScore ();

				if (highScore < score) {
					GamePreferences.SetEasyDifficultyHighScore (score);
				}
				if (coinHighScore < coinCount) {
					GamePreferences.SetEasyDifficultyCoinScore (coinCount);
				}
			}

			// for medium
			if (GamePreferences.GetMediumDifficulty () == 1) {
				int highScore = GamePreferences.GetMediumDifficultyHighScore ();
				int coinHighScore = GamePreferences.GetMediumDifficultyCoinScore ();

				if (highScore < score) {
					GamePreferences.SetMediumDifficultyHighScore (score);
				}
				if (coinHighScore < coinCount) {
					GamePreferences.SetMediumDifficultyCoinScore (coinCount);
				}
			}

			// for hard
			if (GamePreferences.GetHardDifficulty () == 1) {
				int highScore = GamePreferences.GetHardDifficultyHighScore ();
				int coinHighScore = GamePreferences.GetHardDifficultyCoinScore ();

				if (highScore < score) {
					GamePreferences.SetHardDifficultyHighScore (score);
				}
				if (coinHighScore < coinCount) {
					GamePreferences.SetHardDifficultyCoinScore (coinCount);
				}
			}


			gameStartedFromMainMenu = false;
			gameStartedAfterDeath = false;

			GameplayController.gameplayController.GameOverShowPanel (score, coinCount);
		} 
		else // we still have lifes left
		{ 
			this.score = score;
			this.coinCount = coinCount;
			this.lifeCount = lifeCount;

			gameStartedFromMainMenu = false;
			gameStartedAfterDeath = true;

			GameplayController.gameplayController.PlayerDiedRestartGame ();
		}
	}

	void InitializePreferences (){
		if (!PlayerPrefs.HasKey ("Game initialized")) {

			GamePreferences.SetEasyDifficulty (0);
			GamePreferences.SetEasyDifficultyHighScore (0);
			GamePreferences.SetEasyDifficultyCoinScore (0);

			GamePreferences.SetMediumDifficulty (1);
			GamePreferences.SetMediumDifficultyHighScore (0);
			GamePreferences.SetMediumDifficultyCoinScore (0);

			GamePreferences.SetHardDifficulty (0);
			GamePreferences.SetHardDifficultyHighScore (0);
			GamePreferences.SetHardDifficultyCoinScore (0);

			GamePreferences.SetMusicState (0);

			// this is important to recognize that game does not reset, when game is started for more than first time
			PlayerPrefs.SetInt ("Game initialized", 1);
		}
	}

}
	

