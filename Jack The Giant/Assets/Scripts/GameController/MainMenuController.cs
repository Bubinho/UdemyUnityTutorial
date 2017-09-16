using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void StartGame(){
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
	}

}
