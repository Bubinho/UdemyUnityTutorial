using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HighScoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void GoBackToMainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
}
