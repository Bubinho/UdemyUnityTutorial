using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameplayController : MonoBehaviour {

	public static GameplayController gameplayController;

	[SerializeField]
	private Text scoreText, coinText, lifeText;

	[SerializeField]
	private GameObject pausePanel;

	void Awake (){
		createInstance ();
	}

	void createInstance(){
		if (gameplayController == null) {
			gameplayController = this;
		}
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
}
