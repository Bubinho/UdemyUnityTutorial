using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

	public static GameplayManager instance;

	[SerializeField]
	private Text scoreText, endScore, bestScore, gameOverText;

	[SerializeField]
	private Button restartGameButton, instructionsButton;

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private GameObject[] birds;

	[SerializeField]
	private Sprite[] medals;

	[SerializeField]
	private Image medalImage;

	void Awake(){
		CreateInstance ();
		Time.timeScale = 0f; // stop game time. Game is not starting immediatly, you have to click a button
	}

	// Use this for initialization
	void Start () {
		
	}

	void CreateInstance (){
		if (instance == null) {
			instance = this;
		}
	}

	public void PauseGame(){
		// if no bird exists the game is not started, so you cant pause the game 
		if (Bird.instance != null) {
			// check if alive, because when bird is dead it makes no sense to open pause panel
			if(Bird.instance.isAlive){
				pausePanel.SetActive (true); // open pause panel
				gameOverText.gameObject.SetActive(false); // dont display gameOver because its just paused
				endScore.text = Bird.instance.score.ToString(); // set actual score
				bestScore.text = GameManager.instance.GetHighScore().ToString(); // set hifghgscore
				Time.timeScale = 0f; // stop game time
				restartGameButton.onClick.RemoveAllListeners(); // remove Listeners, because resume button has two functions (resume, restart)
				restartGameButton.onClick.AddListener(() => ResumeGame());
			}
		}
	}

	public void GoToMenuButton(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void ResumeGame(){
		pausePanel.SetActive (false);
		Time.timeScale = 1f;
	}

	public void RestartGame(){
		SceneManager.LoadScene ("Main");
	}

	public void PlayGame(){
		scoreText.gameObject.SetActive (true);
		birds [GameManager.instance.GetSelectedBird ()].SetActive (true);
		instructionsButton.gameObject.SetActive (false);
		Time.timeScale = 1f;
	}

	public void SetScore(int score){
		scoreText.text = score.ToString ();
	}

	public void PlayerDiedShowScore(int score){
		pausePanel.SetActive (true); // acitvate pause panel
		gameOverText.gameObject.SetActive (true); // show gameover text
		scoreText.gameObject.SetActive (false);// deactivate score counter

		endScore.text = score.ToString (); // show actual score

		// check if new highscore is reached and actualize
		if(score > GameManager.instance.GetHighScore()){
			GameManager.instance.SetHighScore (score);
		}
			
		bestScore.text = GameManager.instance.GetHighScore ().ToString (); // show highscore

		// give a medal
		if (score <= 20) 
		{
			medalImage.sprite = medals [0];
		}
		else if (score > 20 && score < 40) 
		{
			medalImage.sprite = medals [1];

			// unlock greenbird
			if (GameManager.instance.IsGreenBirdUnlocked () == 0) { // only unlock if its locked
				GameManager.instance.UnlockGreenBird();
			}

		}
		else
		{
			medalImage.sprite = medals [2];
			// unlock red bird
			if (GameManager.instance.IsRedBirdUnlocked () == 0) { // only unlock if its locked
				GameManager.instance.UnlockRedBird();
			}
		}

		restartGameButton.onClick.RemoveAllListeners ();
		restartGameButton.onClick.AddListener (() => RestartGame());

	}



}
