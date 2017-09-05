using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessTheNumberGame : MonoBehaviour {

	public InputField input;
	public Text infoText;

	private int guessNumber;
	private int usersGuess;
	// Use this for initialization
	void Start () {
		guessNumber = Random.Range (0, 100);
	}

	public void CheckGuess(){
		usersGuess = int.Parse(input.text);

		if (usersGuess == guessNumber) {
			infoText.text = "You Guessed The Number! You Are A Wizard";
		} else if (usersGuess > guessNumber) {
			infoText.text = "Your Number Is Greater";
		}else if (usersGuess < guessNumber) {
			infoText.text = "Your Number Is Lower";
		}

		input.text = "";
	}
}
