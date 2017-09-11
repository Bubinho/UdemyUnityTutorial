using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// use this to scale the background for multiple resolutions

		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		Vector3 tempScale = transform.localScale;
		float width = sr.sprite.bounds.size.x;
		float worldHeight = Camera.main.orthographicSize * 2.0f;

		// (Screen.width / Screen.height) = aspectratio of screen 
		// to determine worldWidth multiply by worldHeight
		float worldWidth = worldHeight * Screen.width / Screen.height; 
	
		// to detremine scale worldWidth / spritewidth
		tempScale.x = worldWidth / width;
		transform.localScale = tempScale;
	}
}
