﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	public static MusicController instance;

	private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
		MakeInstance ();
		audioSource = GetComponent<AudioSource> ();
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

	public void PlayMusic(bool play){
		if (play) {
			if (!audioSource.isPlaying) {
				audioSource.Play ();
			}
		}
		else {
			if (audioSource.isPlaying) {
				audioSource.Stop ();
			}
		}
	}
}
