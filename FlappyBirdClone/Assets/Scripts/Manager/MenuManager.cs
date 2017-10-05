using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public static MenuManager instance;

	[SerializeField]
	private GameObject[] birds;

	private bool isGreenBirdUnlocked;
	private bool isRedBirdUnlocked;

	void Awake(){
		MakeInstance ();
	}
	// Use this for initialization
	void Start () {
		
		birds [GameManager.instance.GetSelectedBird ()].SetActive (true);
		CheckIfBirdsUnlocked ();
	}

	void MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	private void CheckIfBirdsUnlocked (){
		if(GameManager.instance.IsRedBirdUnlocked() == 1){
			isRedBirdUnlocked = true;
		}
		if(GameManager.instance.IsGreenBirdUnlocked() == 1){
			isGreenBirdUnlocked = true;
		}
	}

	public void ChangeBird(){
		// the blue bird is active
		if (GameManager.instance.GetSelectedBird () == 0) {
			// you can only switch to green when it is unlocked
			if (isGreenBirdUnlocked) {
				birds [0].SetActive (false); // deactivate blue bird
				GameManager.instance.SetSelectedBird (1); // set new bird to green
				birds [GameManager.instance.GetSelectedBird ()].SetActive (true); // activate green Bird
			}
		}
		// the green bird is selected
		else if (GameManager.instance.GetSelectedBird () == 1) {
			if (isRedBirdUnlocked) {
				birds [1].SetActive (false); 
				GameManager.instance.SetSelectedBird (2); 
				birds [GameManager.instance.GetSelectedBird ()].SetActive (true); 
			} else { // red is not unlocked so change to green
				birds [1].SetActive (false); 
				GameManager.instance.SetSelectedBird (0); 
				birds [GameManager.instance.GetSelectedBird ()].SetActive (true); 
			}
		}
		// red Bird is Selected
		else if (GameManager.instance.GetSelectedBird () == 2){
			birds [2].SetActive (false); 
			GameManager.instance.SetSelectedBird (0); 
			birds [GameManager.instance.GetSelectedBird ()].SetActive (true); 
		}
	}

	public void StartGame(){
		SceneManager.LoadScene ("Main");
	}
	

}
