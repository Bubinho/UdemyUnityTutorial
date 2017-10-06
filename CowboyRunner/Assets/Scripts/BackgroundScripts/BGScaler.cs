using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class to supprt different rersaolution for backgrounds
public class BGScaler : MonoBehaviour {


	// Use this for initialization
	void Start () {
		float height = Camera.main.orthographicSize * 2f; // camera height
		float aspectRation_Screen = (float)Screen.width / Screen.height;
		float width = height * aspectRation_Screen; // camera width


		if (gameObject.name == "Background") {
			transform.localScale = new Vector3 (width, height, 0);
		} else {
			transform.localScale = new Vector3 (width + 3 , 5, 0); // add a little bit to width to spawn enemys here
		}
	}

}
