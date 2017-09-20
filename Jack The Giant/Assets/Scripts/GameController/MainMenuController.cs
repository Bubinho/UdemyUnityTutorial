using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	[SerializeField]
	private Button musicButton;

	[SerializeField]
	private Sprite[] musicIcons;

	// Use this for initialization
	void Start () {
		CheckToPlayMusic ();
	}

	void CheckToPlayMusic(){
		if (GamePreferences.GetMusicState () == 1) {
			MusicController.instance.PlayMusic (true);
			musicButton.image.sprite = musicIcons [0];
		}
		else 
		{
			MusicController.instance.PlayMusic (false);
			musicButton.image.sprite = musicIcons [1];
		}
	}
	
	public void StartGame(){
		GameManager.instance.gameStartedFromMainMenu = true;
		SceneManager.LoadScene ("Gameplay");
	}

	public void HighscoreMenu(){
		SceneManager.LoadScene ("HighScore");
	}

	public void OptionsMenu(){
		SceneManager.LoadScene ("OptionsMenu");
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void MusicButton(){
		if (GamePreferences.GetMusicState () == 0) {
			GamePreferences.SetMusicState (1);
			MusicController.instance.PlayMusic (true);
			musicButton.image.sprite = musicIcons [0];
		} 
		else 
		{
			GamePreferences.SetMusicState (0);
			MusicController.instance.PlayMusic (false);
			musicButton.image.sprite = musicIcons [1];
		}
	}

}
