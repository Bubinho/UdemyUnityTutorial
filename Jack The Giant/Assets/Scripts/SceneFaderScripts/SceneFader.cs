using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour {

	public static SceneFader instance;

	[SerializeField]
	private GameObject fadePanel;

	[SerializeField]
	private Animator fadeAnim;

	void Awake(){
		MakeInstance ();
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MakeInstance(){
		if (instance != null) 
		{
			Destroy (gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void loadLevel(string level){
		StartCoroutine (FadeInOut(level));
	}

	IEnumerator FadeInOut(string level){
		fadePanel.SetActive (true);
		fadeAnim.Play ("FadeIn");
		yield return new WaitForSecondsRealtime (0.3f); //MyCoroutine.WaitForRealSeconds (0.3f); //new WaitForSecondsRealtime (1f);
		SceneManager.LoadScene (level);
		fadeAnim.Play ("FadeOut");
		yield return new WaitForSecondsRealtime (0.3f);//MyCoroutine.WaitForRealSeconds(0.3f);//new WaitForSecondsRealtime (0.7f);
		fadePanel.SetActive (false);
	}
}
