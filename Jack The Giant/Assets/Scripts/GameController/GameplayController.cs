using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class GameplayController : MonoBehaviour {

	public static GameplayController gameplayController;

	[SerializeField]
	private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel;

	[SerializeField]
	private GameObject readyButton;

	void Awake (){
		createInstance ();
	}

	void Start(){
		Time.timeScale = 0f;
	}

	void createInstance(){
		if (gameplayController == null) {
			gameplayController = this;
		}
	}

	public void GameOverShowPanel(int finalScore, int finalCoins){
		gameOverScoreText.text = finalScore.ToString();
		gameOverCoinText.text = finalCoins.ToString();
		gameOverPanel.SetActive (true);
		StartCoroutine (GameOverLoadMainMenu());
	}

	IEnumerator GameOverLoadMainMenu(){
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene ("MainMenu");
	}

	public void PlayerDiedRestartGame(){
		StartCoroutine( PlayerDiedRestart());
	}

	IEnumerator PlayerDiedRestart(){
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("Gameplay");
	}

	public void SetScore(int score){
		scoreText.text = score.ToString(); 
	}

	public void SetCoinCount (int coinCount){
		coinText.text = "x" + coinCount;
	}

	public void SetLifeCount (int lifeCount){
		lifeText.text = "x" + lifeCount;
	}

	public void PauseGame(){
		Time.timeScale = 0f; // stop the game
		pausePanel.SetActive (true);
	}

	public void ResumeGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void QuitGame(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}

	public void StartGame(){
		Time.timeScale = 1f;
		readyButton.SetActive (false);
	}
}
